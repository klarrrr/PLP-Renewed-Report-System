Imports System.Drawing.Imaging
Imports System.IO
Imports System.Net.Mail
Imports MySql.Data.MySqlClient
Imports QRCoder
Imports MessagingToolkit.QRCode.Codec
Imports AForge.Video.DirectShow
Imports AForge.Video

Public Class EntrancePage
    Dim conn As New MySqlConnection("server=localhost;username=root;password=;database=plpportal_db")
    Private Sub EntrancePage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetFormThemeLight(Me)
        LoadSectionBoxOnRegisterStudents()
    End Sub

    ' Also call this after adding a section in professor side
    Private Sub LoadSectionBoxOnRegisterStudents()
        conn.Open()
        Dim cmd As New MySqlCommand("SELECT section FROM sections", conn)
        Dim reader = cmd.ExecuteReader()
        While reader.Read
            Dim prof = reader.GetString("section")
            StuRegSectionBox.Items.Add(prof)
        End While
        conn.Close()
    End Sub

    Private Sub ChooseAdmin(sender As Object, e As EventArgs) Handles EnterAdminBtn.Click, ChooseAdminCard.Click, AdminPictureBox.Click, BigAdminLbl1.Click, SmolAdminLbl2.Click
        ProfLogCard.Show()
        ChooseUserCard.Hide()
        ProfLogUsernameTxtbox.Focus()
    End Sub

    Private Sub ChooseStudent(sender As Object, e As EventArgs) Handles EnterStudentBtn.Click, ChooseStudentCard.Click, StudentPicturebox.Click, BigStudentLbl1.Click, SmolStudentLbl2.Click
        StudentLoginCard.Show()
        ChooseUserCard.Hide()
        StuLogStudIdTxtBox.Focus()
    End Sub

    Private Sub StuQRBackBtn_Click(sender As Object, e As EventArgs) Handles StuQRBackBtn.Click
        StopWebcamForStudent()
        StudentLoginCard.Show()
        StuQRCard.Hide()
        Timer1.Stop()
    End Sub

    Private Sub StuQRForgPass_Click(sender As Object, e As EventArgs) Handles StuQRForgPass.Click
        StuForgPassCard.Show()
        StuQRCard.Hide()
    End Sub

    Private Sub ProfQRBackBtn_Click(sender As Object, e As EventArgs) Handles ProfQRBackBtn.Click
        StopWebcamForProfessor()
        ProfLogCard.Show()
        ProfQRCard.Hide()
        Timer2.Stop()
    End Sub

    Private Sub ProfQRForgPass_Click(sender As Object, e As EventArgs) Handles ProfQRForgPass.Click
        ProfForgPassCard.Show()
        ProfQRCard.Hide()
    End Sub

    Private Sub StuForgPassBackBtn_Click(sender As Object, e As EventArgs) Handles StuForgPassBackBtn.Click
        StudentLoginCard.Show()
        StuForgPassCard.Hide()
        StuForgPassStuNumBox.Clear()
        StuForgPassEmailBox.Clear()
    End Sub

    Private Sub StuForgPassRecovBtn_Click(sender As Object, e As EventArgs) Handles StuForgPassRecovBtn.Click
        If StuForgPassStuNumBox.Text = "" Or StuForgPassEmailBox.Text = "" Then
            MessageBox.Show("Please fill up all of the fields first!", "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf Not StuForgPassEmailBox.Text.EndsWith("@plpasig.edu.ph") Then
            MessageBox.Show("Invalid email address. Please use an email address from @plpasig.edu.ph.", "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Try
                conn.Open()

                Dim cmd As New MySqlCommand("SELECT * FROM studentinfo where studentnum = '" & StuForgPassStuNumBox.Text & "' and email = '" & StuForgPassEmailBox.Text & "'", conn)
                cmd.ExecuteNonQuery()
                conn.Close()

                Dim da As New MySqlDataAdapter(cmd)
                Dim dt As New DataTable

                da.Fill(dt)

                If dt.Rows.Count <= 0 Then
                    MessageBox.Show("Account is invalid! Please check your inputs.", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else

                    Dim lastname As String
                    Dim firstname As String
                    Dim middleinit As String

                    lastname = ""
                    firstname = ""
                    middleinit = ""

                    conn.Open()
                    Dim pcmd As New MySqlCommand("SELECT last_name FROM studentinfo where studentnum = '" & StuForgPassStuNumBox.Text & "'", conn)
                    pcmd.ExecuteNonQuery()
                    Dim pdr As MySqlDataReader

                    pdr = pcmd.ExecuteReader
                    If pdr.Read Then
                        lastname = pdr("last_name")

                    End If

                    conn.Close()

                    conn.Open()
                    Dim fcmd As New MySqlCommand("SELECT first_name FROM studentinfo where studentnum = '" & StuForgPassStuNumBox.Text & "'", conn)
                    fcmd.ExecuteNonQuery()
                    Dim fdr As MySqlDataReader

                    fdr = fcmd.ExecuteReader
                    If fdr.Read Then
                        firstname = fdr("first_name")

                    End If

                    conn.Close()

                    conn.Open()
                    Dim mcmd As New MySqlCommand("SELECT middle_initial FROM studentinfo where studentnum = '" & StuForgPassStuNumBox.Text & "'", conn)
                    mcmd.ExecuteNonQuery()
                    Dim mdr As MySqlDataReader

                    mdr = mcmd.ExecuteReader
                    If mdr.Read Then
                        middleinit = mdr("middle_initial")

                    End If

                    conn.Close()

                    Dim qrGenerator As New QRCodeGenerator
                    Dim qrCodeData = qrGenerator.CreateQrCode(StuForgPassStuNumBox.Text, QRCodeGenerator.ECCLevel.L)
                    Dim qrCode As New QRCode(qrCodeData)

                    Dim codeimage = qrCode.GetGraphic(20)

                    Dim stream As New MemoryStream
                    codeimage.Save(stream, ImageFormat.Jpeg)
                    stream.Position = 0

                    Dim attachment As New Attachment(stream, "QRCode.png")

                    Dim smtp As New SmtpClient
                    Dim mail As New MailMessage
                    smtp.UseDefaultCredentials = False
                    smtp.Credentials = New Net.NetworkCredential("alvarez_juanito@plpasig.edu.ph", "eauz vtwn tjty jpna")
                    smtp.Port = 587
                    smtp.EnableSsl = True
                    smtp.Host = "smtp.gmail.com"

                    mail.From = New MailAddress("alvarez_juanito@plpasig.edu.ph")
                    mail.To.Add(StuForgPassEmailBox.Text)
                    mail.Subject = "PLP STUDENT PORTAL ACCOUNT RETRIEVE"
                    mail.IsBodyHtml = True
                    mail.Body = "Hello " & firstname & " " & middleinit & " " & lastname & ", you can use this QR Code to Log in to PLP Student Portal."
                    mail.Attachments.Add(attachment)
                    smtp.Send(mail)
                    MessageBox.Show("Account Successfully Retrieved! Please Check your gmail account.", "Student Portal", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    codeimage.Dispose()
                    stream.Dispose()
                    attachment.Dispose()

                    StudentLoginCard.Show()
                    StuForgPassCard.Hide()
                    StuForgPassStuNumBox.Clear()
                    StuForgPassEmailBox.Clear()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub ProfForgPassBackBtn_Click(sender As Object, e As EventArgs) Handles ProfForgPassBackBtn.Click
        ProfLogCard.Show()
        ProfForgPassCard.Hide()
    End Sub

    Private Sub ProfForgPassRecovBtn_Click(sender As Object, e As EventArgs) Handles ProfForgPassRecovBtn.Click
        If ProfForgPassFullNameBox.Text = "" Or ProfForgPassEmailBox.Text = "" Or ProfForgPassUsernameBox.Text = "" Then
            MessageBox.Show("One or more field is empty!", "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf Not ProfForgPassEmailBox.Text.EndsWith("@plpasig.edu.ph") Then
            MessageBox.Show("Invalid email address. Please use an email address from @plpasig.edu.ph.", "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Try
                conn.Open()

                Dim cmd As New MySqlCommand("SELECT * FROM profinfo where name = '" & ProfForgPassFullNameBox.Text & "' and email = '" & ProfForgPassEmailBox.Text & "' and username = '" & ProfForgPassUsernameBox.Text & "'", conn)
                cmd.ExecuteNonQuery()
                conn.Close()

                Dim da As New MySqlDataAdapter(cmd)
                Dim dt As New DataTable

                da.Fill(dt)

                If dt.Rows.Count() <= 0 Then
                    MessageBox.Show("Account is invalid! Please check your inputs.", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else

                    Dim pass As String

                    pass = ""

                    conn.Open()
                    Dim pcmd As New MySqlCommand("SELECT password FROM profinfo where username = '" & ProfForgPassFullNameBox.Text & "'", conn)
                    pcmd.ExecuteNonQuery()
                    Dim pdr As MySqlDataReader

                    pdr = pcmd.ExecuteReader
                    If pdr.Read Then
                        pass = pdr("password")

                    End If

                    conn.Close()

                    Dim qrGenerator As New QRCodeGenerator
                    Dim qrCodeData As QRCodeData = qrGenerator.CreateQrCode(ProfForgPassFullNameBox.Text, QRCodeGenerator.ECCLevel.L)
                    Dim qrCode As New QRCode(qrCodeData)

                    Dim codeimage As Bitmap = qrCode.GetGraphic(20)

                    Dim stream As New MemoryStream()
                    codeimage.Save(stream, ImageFormat.Jpeg)
                    stream.Position = 0

                    Dim attachment As New Attachment(stream, "QRCode.png")

                    Dim smtp As New SmtpClient
                    Dim mail As New MailMessage
                    smtp.UseDefaultCredentials = False
                    smtp.Credentials = New Net.NetworkCredential("alvarez_juanito@plpasig.edu.ph", "eauz vtwn tjty jpna")
                    smtp.Port = 587
                    smtp.EnableSsl = True
                    smtp.Host = "smtp.gmail.com"

                    mail.From = New MailAddress("alvarez_juanito@plpasig.edu.ph")
                    mail.To.Add(ProfForgPassEmailBox.Text)
                    mail.Subject = "PLP TEACHER PORTAL ACCOUNT RETRIEVE"
                    mail.IsBodyHtml = True
                    mail.Body = "Hello Prof. " & ProfForgPassFullNameBox.Text & ", your password is " & pass & " and you can use this QR Code to Log in to PLP Admin Portal."
                    mail.Attachments.Add(attachment)
                    smtp.Send(mail)
                    MessageBox.Show("Account Successfully Retrieved! Please Check your gmail account.", "Admin Portal", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    codeimage.Dispose()
                    stream.Dispose()
                    attachment.Dispose()

                    ProfForgPassBackBtn.PerformClick()

                    ProfForgPassFullNameBox.Clear()
                    ProfForgPassEmailBox.Clear()
                    ProfForgPassUsernameBox.Clear()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                conn.Close()
            End Try
        End If
    End Sub

    Private Sub StuRegBackBtn_Click(sender As Object, e As EventArgs) Handles StuRegBackBtn.Click
        StudentLoginCard.Show()
        StuRegCard.Hide()
        ClearAllBoxesInStuReg()
    End Sub

    Private Sub StuRegSignUpBox_Click(sender As Object, e As EventArgs) Handles StuRegSignUpBox.Click
        If StuRegStuNumBox.Text = "" Or StuRegStuLastNameBox.Text = "" Or StuRegFirstNameBox.Text = "" Or StuRegEmailBox.Text = "" Or StuRegSectionBox.SelectedIndex = -1 Or StuRegYearLvlBox.SelectedIndex = -1 Or StuRegStatusBox.SelectedIndex = -1 Then
            MessageBox.Show("One or more field is empty!", "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf Not StuRegEmailBox.Text.EndsWith("@plpasig.edu.ph") Then
            MessageBox.Show("Invalid email address. Please use an email address from @plpasig.edu.ph.", "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Try
                conn.Open()
                Dim cmd As New MySqlCommand("INSERT INTO studentinfo VALUES ('" & StuRegStuNumBox.Text & "', '" & StuRegStuLastNameBox.Text & "', '" & StuRegFirstNameBox.Text & "', '" & StuRegMiddleInitialBox.Text & "', '" & StuRegSuffixBox.Text & "', '" & StuRegEmailBox.Text & "', '" & StuRegSectionBox.SelectedItem & "', '" & StuRegYearLvlBox.SelectedItem & "', '" & StuRegStatusBox.SelectedItem & "')", conn)
                cmd.ExecuteNonQuery()

                Dim qrGenerator As New QRCodeGenerator
                Dim qrCodeData As QRCodeData = qrGenerator.CreateQrCode(StuRegStuNumBox.Text, QRCodeGenerator.ECCLevel.L)
                Dim qrCode As New QRCode(qrCodeData)

                Dim codeimage As Bitmap = qrCode.GetGraphic(10)

                Dim stream As New MemoryStream()
                codeimage.Save(stream, ImageFormat.Png)
                stream.Position = 0

                Dim attachment As New Attachment(stream, "QRCode.png")

                Dim smtp As New SmtpClient
                Dim mail As New MailMessage
                smtp.UseDefaultCredentials = False
                smtp.Credentials = New Net.NetworkCredential("alvarez_juanito@plpasig.edu.ph", "eauz vtwn tjty jpna")
                smtp.Port = 587
                smtp.EnableSsl = True
                smtp.Host = "smtp.gmail.com"

                mail.From = New MailAddress("alvarez_juanito@plpasig.edu.ph")
                mail.To.Add(StuRegEmailBox.Text)
                mail.Subject = "QR CODE"
                mail.IsBodyHtml = True
                mail.Body = "Hello " & StuRegFirstNameBox.Text & " " & StuRegMiddleInitialBox.Text & ". " & StuRegStuLastNameBox.Text & ", you can use this QR Code to Log in to PLP Student Portal."
                mail.Attachments.Add(attachment)
                smtp.Send(mail)

                codeimage.Dispose()
                stream.Dispose()
                attachment.Dispose()
                MessageBox.Show("Account Successfully Saved!", "Student Portal", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ClearAllBoxesInStuReg()

                StuRegBackBtn.PerformClick()

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conn.Close()
            End Try
        End If
    End Sub

    Private Sub ClearAllBoxesInStuReg()
        StuRegStuNumBox.Clear()
        StuRegStuLastNameBox.Clear()
        StuRegFirstNameBox.Clear()
        StuRegMiddleInitialBox.Clear()

        StuRegSuffixBox.Text = ""
        StuRegSuffixBox.SelectedIndex = -1
        StuRegSuffixBox.Refresh()

        StuRegEmailBox.Clear()

        StuRegSectionBox.Text = ""
        StuRegSectionBox.SelectedIndex = -1
        StuRegSectionBox.Refresh()

        StuRegYearLvlBox.Text = ""
        StuRegYearLvlBox.SelectedIndex = -1
        StuRegYearLvlBox.Refresh()

        StuRegStatusBox.Text = ""
        StuRegStatusBox.SelectedIndex = -1
        StuRegStatusBox.Refresh()
    End Sub

    Private Sub ProfRegBackBtn_Click(sender As Object, e As EventArgs) Handles ProfRegBackBtn.Click
        ProfLogCard.Show()
        ProfRegCard.Hide()
    End Sub

    Private Sub ProfRegSignUpBtn_Click(sender As Object, e As EventArgs) Handles ProfRegSignUpBtn.Click
        If ProfRegFullNameBox.Text = "" Or ProfRegEmailBox.Text = "" Or ProfRegUsernameBox.Text = "" Or ProfRegPasswordBox.Text = "" Then
            MessageBox.Show("One or more field is empty!", "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf Not ProfRegEmailBox.Text.EndsWith("@plpasig.edu.ph") Then
            MessageBox.Show("Invalid email address. Please use an email address from @plpasig.edu.ph.", "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Try

                conn.Open()
                Dim cmd As New MySqlCommand("INSERT INTO profinfo VALUES ('" & ProfRegFullNameBox.Text & "', '" & ProfRegEmailBox.Text & "', '" & ProfRegUsernameBox.Text & "', '" & ProfRegPasswordBox.Text & "')", conn)

                cmd.ExecuteNonQuery()

                conn.Close()

                Dim qrGenerator As New QRCodeGenerator
                Dim qrCodeData As QRCodeData = qrGenerator.CreateQrCode(ProfRegUsernameBox.Text, QRCodeGenerator.ECCLevel.L)
                Dim qrCode As New QRCode(qrCodeData)

                Dim codeimage As Bitmap = qrCode.GetGraphic(10)
                Dim stream As New MemoryStream()
                codeimage.Save(stream, ImageFormat.Png)
                stream.Position = 0

                Dim attachment As New Attachment(stream, "QRCode.png")

                Dim smtp As New SmtpClient
                Dim mail As New MailMessage
                smtp.UseDefaultCredentials = False
                smtp.Credentials = New Net.NetworkCredential("alvarez_juanito@plpasig.edu.ph", "eauz vtwn tjty jpna")
                smtp.Port = 587
                smtp.EnableSsl = True
                smtp.Host = "smtp.gmail.com"

                mail.From = New MailAddress("alvarez_juanito@plpasig.edu.ph")
                mail.To.Add(ProfRegEmailBox.Text)
                mail.Subject = "QR CODE"
                mail.IsBodyHtml = True
                mail.Body = "Hello Professor " & ProfRegFullNameBox.Text & ", you can use this QR Code to Log in to Admin Portal."
                mail.Attachments.Add(attachment)
                smtp.Send(mail)
                MessageBox.Show("Account Successfully Saved!", "Admin Portal", MessageBoxButtons.OK, MessageBoxIcon.Information)

                codeimage.Dispose()
                stream.Dispose()
                attachment.Dispose()

                ProfRegBackBtn.PerformClick()
                ProfRegFullNameBox.Clear()
                ProfRegEmailBox.Clear()
                ProfRegUsernameBox.Clear()
                ProfRegPasswordBox.Clear()

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub StuLogBackBtn_Click(sender As Object, e As EventArgs) Handles StuLogBackBtn.Click
        ChooseUserCard.Show()
        StudentLoginCard.Hide()
    End Sub

    Private Sub StuLogQRCode_Click(sender As Object, e As EventArgs) Handles StuLogQRCode.Click
        StuQRCard.Show()
        StudentLoginCard.Hide()
    End Sub

    Private Sub StuLogForgPass_Click(sender As Object, e As EventArgs) Handles StuLogForgPass.Click
        StuForgPassCard.Show()
        StudentLoginCard.Hide()
    End Sub

    Private Sub StuLogCreateACc_Click(sender As Object, e As EventArgs) Handles StuLogCreateACc.Click
        StuRegCard.Show()
        StudentLoginCard.Hide()
    End Sub

    Private Sub StuLogSignInBtn_Click(sender As Object, e As EventArgs) Handles StuLogSignInBtn.Click
        conn.Open()

        Dim cmd As New MySqlCommand("SELECT * FROM studentinfo where studentnum = '" & StuLogStudIdTxtBox.Text & "'", conn)
        cmd.ExecuteNonQuery()
        conn.Close()

        Dim da As New MySqlDataAdapter(cmd)
        Dim dt As New DataTable

        da.Fill(dt)

        If dt.Rows.Count <= 0 Then
            MessageBox.Show("Student does not exist!", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Dim StudentForm As New StudentDashboard(StuLogStudIdTxtBox.Text)
            StudentForm.Show()
            StuLogStudIdTxtBox.Clear()
            Hide()
        End If
    End Sub

    Private Sub ProfLogBackBtn_Click(sender As Object, e As EventArgs) Handles ProfLogBackBtn.Click
        ChooseUserCard.Show()
        ProfLogCard.Hide()
    End Sub

    Private Sub ProfLogQRCode_Click(sender As Object, e As EventArgs) Handles ProfLogQRCode.Click
        ProfQRCard.Show()
        ProfLogCard.Hide()
    End Sub

    Private Sub ProfLogForgPass_Click(sender As Object, e As EventArgs) Handles ProfLogForgPass.Click
        ProfForgPassCard.Show()
        ProfLogCard.Hide()
    End Sub

    Private Sub ProfLogCreateAcc_Click(sender As Object, e As EventArgs) Handles ProfLogCreateAcc.Click
        ProfRegCard.Show()
        ProfLogCard.Hide()
    End Sub

    Private Sub ProfLogSignInBtn_Click(sender As Object, e As EventArgs) Handles ProfLogSignInBtn.Click
        conn.Open()

        Dim cmd As New MySqlCommand("SELECT * FROM profinfo where username = '" & ProfLogUsernameTxtbox.Text & "' and password = '" & ProfLogPassTxtBox.Text & "'", conn)
        cmd.ExecuteNonQuery()
        conn.Close()

        Dim da As New MySqlDataAdapter(cmd)
        Dim dt As New DataTable

        da.Fill(dt)

        If dt.Rows.Count() <= 0 Then
            MessageBox.Show("Username or Password Are Invalid!", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Dim ProfForm As New ProfessorDashboard(ProfLogUsernameTxtbox.Text)
            ProfForm.Show()
            ProfLogUsernameTxtbox.Clear()
            ProfLogPassTxtBox.Clear()
            Hide()
        End If
    End Sub

    Private Sub StuLogStudIdTxtBox_TextChanged(sender As Object, e As EventArgs) Handles StuLogStudIdTxtBox.TextChanged
        Dim textWithoutSpaces = StuLogStudIdTxtBox.Text.Replace(" ", "")
        ' Check if the text contains more than 2 digits
        If textWithoutSpaces.Length >= 2 Then
            ' Insert a space after every 2 digits
            StuLogStudIdTxtBox.Text = textWithoutSpaces.Insert(2, " ")
            StuLogStudIdTxtBox.SelectionStart = StuLogStudIdTxtBox.TextLength ' Move the cursor to the end
        End If
        ' Limit the total length to 7 digits (including spaces)
        If StuLogStudIdTxtBox.TextLength > 8 Then
            StuLogStudIdTxtBox.Text = StuLogStudIdTxtBox.Text.Substring(0, 8)
            StuLogStudIdTxtBox.SelectionStart = StuLogStudIdTxtBox.TextLength ' Move the cursor to the end
        End If
    End Sub

    Private Sub StuLogStudIdTxtBox_KeyDown(sender As Object, e As KeyEventArgs) Handles StuLogStudIdTxtBox.KeyDown
        If e.KeyCode = Keys.Back AndAlso StuLogStudIdTxtBox.TextLength = 3 Then
            StuLogStudIdTxtBox.Text = ""
        ElseIf e.KeyCode = Keys.Enter Then
            StuLogSignInBtn.PerformClick()
        End If
    End Sub

    ' FORGOT PASS STUDENT

    Private Sub StuForgPassStuNumBox_TextChanged(sender As Object, e As EventArgs) Handles StuForgPassStuNumBox.TextChanged
        Dim textWithoutSpaces = StuForgPassStuNumBox.Text.Replace(" ", "")
        ' Check if the text contains more than 2 digits
        If textWithoutSpaces.Length >= 2 Then
            ' Insert a space after every 2 digits
            StuForgPassStuNumBox.Text = textWithoutSpaces.Insert(2, " ")
            StuForgPassStuNumBox.SelectionStart = StuForgPassStuNumBox.TextLength ' Move the cursor to the end
        End If
        ' Limit the total length to 7 digits (including spaces)
        If StuForgPassStuNumBox.TextLength > 8 Then
            StuForgPassStuNumBox.Text = StuForgPassStuNumBox.Text.Substring(0, 8)
            StuForgPassStuNumBox.SelectionStart = StuForgPassStuNumBox.TextLength ' Move the cursor to the end
        End If
    End Sub

    Private Sub StuForgPassStuNumBox_KeyDown(sender As Object, e As KeyEventArgs) Handles StuForgPassStuNumBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            StuForgPassEmailBox.Focus()
        End If
        If e.KeyCode = Keys.Back AndAlso StuForgPassStuNumBox.TextLength = 3 Then
            StuForgPassStuNumBox.Text = ""
        End If
    End Sub

    Private Sub StuForgPassEmailBox_KeyDown(sender As Object, e As KeyEventArgs) Handles StuForgPassEmailBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            StuForgPassRecovBtn.PerformClick()
        End If
        If e.KeyCode = Keys.Space Then
            e.SuppressKeyPress = True
        End If
    End Sub

    ' REGISTER STUDENTS
    Private Sub StuRegStuNumBox_TextChanged(sender As Object, e As EventArgs) Handles StuRegStuNumBox.TextChanged
        Dim textWithoutSpaces As String = StuRegStuNumBox.Text.Replace(" ", "")

        ' Check if the text contains more than 2 digits
        If textWithoutSpaces.Length >= 2 Then
            ' Insert a space after every 2 digits
            StuRegStuNumBox.Text = textWithoutSpaces.Insert(2, " ")
            StuRegStuNumBox.SelectionStart = StuRegStuNumBox.TextLength ' Move the cursor to the end
        End If

        ' Limit the total length to 7 digits (including spaces)
        If StuRegStuNumBox.TextLength > 8 Then
            StuRegStuNumBox.Text = StuRegStuNumBox.Text.Substring(0, 8)
            StuRegStuNumBox.SelectionStart = StuRegStuNumBox.TextLength ' Move the cursor to the end
        End If
    End Sub

    Private Sub StuRegStuNumBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles StuRegStuNumBox.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub StuRegStuLastNameBox_TextChanged(sender As Object, e As EventArgs) Handles StuRegStuLastNameBox.TextChanged
        Dim currentText As String = StuRegStuLastNameBox.Text
        Dim upperCaseText As String = currentText.ToUpper()
        StuRegStuLastNameBox.Text = upperCaseText
        StuRegStuLastNameBox.SelectionStart = StuRegStuLastNameBox.Text.Length
    End Sub

    Private Sub StuRegFirstNameBox_TextChanged(sender As Object, e As EventArgs) Handles StuRegFirstNameBox.TextChanged
        Dim currentText As String = StuRegFirstNameBox.Text
        Dim upperCaseText As String = currentText.ToUpper()

        StuRegFirstNameBox.Text = upperCaseText
        StuRegFirstNameBox.SelectionStart = StuRegFirstNameBox.Text.Length
    End Sub

    Private Sub StuRegMiddleInitialBox_TextChanged(sender As Object, e As EventArgs) Handles StuRegMiddleInitialBox.TextChanged
        Dim currentText As String = StuRegMiddleInitialBox.Text
        Dim upperCaseText As String = currentText.ToUpper()

        StuRegMiddleInitialBox.Text = upperCaseText
        StuRegMiddleInitialBox.SelectionStart = StuRegMiddleInitialBox.Text.Length

        If StuRegMiddleInitialBox.TextLength > 2 Then
            StuRegMiddleInitialBox.Text = StuRegMiddleInitialBox.Text.Substring(0, 2)
            StuRegMiddleInitialBox.SelectionStart = StuRegMiddleInitialBox.TextLength
        End If
    End Sub

    ' STUDENT QR

    Private WithEvents VideoSourceOfStudentQR As New VideoCaptureDevice()
    Private WithEvents VideoSourceOfProfessorQR As New VideoCaptureDevice()

    Private Sub VideoSourceOfStudentQR_NewFrame(sender As Object, eventArgs As NewFrameEventArgs) Handles VideoSourceOfStudentQR.NewFrame
        StuQRPicBox.Image = DirectCast(eventArgs.Frame.Clone(), System.Drawing.Image)
    End Sub

    Private Sub VideoSourceOfProfessorQR_NewFrame(sender As Object, eventArgs As NewFrameEventArgs) Handles VideoSourceOfProfessorQR.NewFrame
        ProfQRPicBox.Image = DirectCast(eventArgs.Frame.Clone(), System.Drawing.Image)
    End Sub

    Private Sub StartWebcamForStudent()
        Try
            Dim videoDevices As VideoCaptureDeviceForm = New VideoCaptureDeviceForm()
            If videoDevices.ShowDialog() = DialogResult.OK Then
                VideoSourceOfStudentQR = videoDevices.VideoDevice
                VideoSourceOfStudentQR.Start()
            End If
        Catch ex As Exception
            MessageBox.Show("Error starting webcam: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub StopWebcamForStudent()
        Try
            If VideoSourceOfStudentQR IsNot Nothing AndAlso VideoSourceOfStudentQR.IsRunning Then
                VideoSourceOfStudentQR.SignalToStop()
                VideoSourceOfStudentQR.WaitForStop()
            End If
        Catch ex As Exception
            MessageBox.Show("Error stopping webcam: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub StartWebcamForProfessor()
        Try
            Dim videoDevices As VideoCaptureDeviceForm = New VideoCaptureDeviceForm()
            If videoDevices.ShowDialog() = DialogResult.OK Then
                VideoSourceOfProfessorQR = videoDevices.VideoDevice
                VideoSourceOfProfessorQR.Start()
            End If
        Catch ex As Exception
            MessageBox.Show("Error starting webcam: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub StopWebcamForProfessor()
        Try
            If VideoSourceOfProfessorQR IsNot Nothing AndAlso VideoSourceOfProfessorQR.IsRunning Then
                VideoSourceOfProfessorQR.SignalToStop()
                VideoSourceOfProfessorQR.WaitForStop()
            End If
        Catch ex As Exception
            MessageBox.Show("Error stopping webcam: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub StuQRCard_VisibleChanged(sender As Object, e As EventArgs) Handles StuQRCard.VisibleChanged
        If StuQRCard.Visible = True Then
            StartWebcamForStudent()
            Timer1.Start()
        End If
    End Sub

    Private Sub ScanQRCodeStudent()
        Dim Reader = New QRCodeDecoder
        Try
            If StuQRPicBox.Image IsNot Nothing Then
                Dim qrResult As String = Reader.Decode(New Data.QRCodeBitmapImage(StuQRPicBox.Image))
                Dim filterResult As String = ""
                Dim op As Boolean = False
                For Each letter As Char In qrResult
                    If letter = "[" Then
                        op = True
                        Continue For
                    End If
                    If letter = "]" Then
                        Exit For
                    End If
                    If op = True Then
                        filterResult += letter
                    End If
                Next
                filterResult = filterResult.Replace("[", "").Replace("-", " ")
                conn.Open()
                Dim cmd As New MySqlCommand("SELECT * FROM studentinfo where studentnum = '" & filterResult & "'", conn)
                cmd.ExecuteNonQuery()
                If op = False Then
                    cmd.CommandText = "SELECT * FROM studentinfo where studentnum = '" & qrResult & "'"
                    cmd.ExecuteNonQuery()
                End If
                conn.Close()

                Dim da As New MySqlDataAdapter(cmd)
                Dim dt As New DataTable

                da.Fill(dt)

                If dt.Rows.Count() > 0 Then
                    Timer1.Stop()
                    StopWebcamForStudent()
                    Dim StudentForm As New StudentDashboard(qrResult)
                    StuQRCard.Hide()
                    StudentLoginCard.Show()
                    StudentForm.Show()
                    Hide()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ScanQRCodeProfessor()
        Dim Reader = New QRCodeDecoder
        Try
            If ProfQRPicBox.Image IsNot Nothing Then
                Dim result As String = Reader.Decode(New Data.QRCodeBitmapImage(ProfQRPicBox.Image))
                conn.Open()
                Dim cmd As New MySqlCommand("SELECT * FROM profinfo where username = '" & result & "'", conn)
                cmd.ExecuteNonQuery()
                conn.Close()

                Dim da As New MySqlDataAdapter(cmd)
                Dim dt As New DataTable

                da.Fill(dt)

                If dt.Rows.Count() > 0 Then
                    Timer2.Stop()
                    StopWebcamForProfessor()
                    Dim ProfessorForm As New ProfessorDashboard(result)
                    ProfQRCard.Hide()
                    ProfLogCard.Show()
                    ProfessorForm.Show()
                    Hide()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    ' Timer delay between QR Scans in Student QR
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = True
        Timer1.Interval = 1
        ScanQRCodeStudent()
    End Sub

    ' Timer delay between QR Scans in Professor QR
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Timer2.Enabled = True
        Timer2.Interval = 1
        ScanQRCodeProfessor()
    End Sub

    Private Sub ProfLogUsernameTxtbox_KeyDown(sender As Object, e As KeyEventArgs) Handles ProfLogUsernameTxtbox.KeyDown
        If e.KeyCode = Keys.Enter Then
            ProfLogPassTxtBox.Focus()
        End If
    End Sub

    Private Sub ProfLogPassTxtBox_KeyDown(sender As Object, e As KeyEventArgs) Handles ProfLogPassTxtBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            ProfLogSignInBtn.PerformClick()
        End If
    End Sub

    Private Sub ProfForgPassFullNameBox_KeyDown(sender As Object, e As KeyEventArgs) Handles ProfForgPassFullNameBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            ProfForgPassEmailBox.Focus()
        End If
    End Sub

    Private Sub ProfForgPassEmailBox_KeyDown(sender As Object, e As KeyEventArgs) Handles ProfForgPassEmailBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            ProfForgPassUsernameBox.Focus()
        End If
    End Sub

    Private Sub ProfForgPassUsernameBox_KeyDown(sender As Object, e As KeyEventArgs) Handles ProfForgPassUsernameBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            ProfForgPassRecovBtn.PerformClick()
        End If
    End Sub

    Private Sub ProfQRCard_VisibleChanged(sender As Object, e As EventArgs) Handles ProfQRCard.VisibleChanged
        If ProfQRCard.Visible = True Then
            StartWebcamForProfessor()
            Timer2.Start()
        End If
    End Sub
End Class

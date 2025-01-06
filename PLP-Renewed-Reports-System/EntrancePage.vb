Imports MySql.Data.MySqlClient

Public Class EntrancePage
    Dim conn As New MySqlConnection("server=localhost;username=root;password=;database=plpportal_db")
    Private Sub EntrancePage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetFormThemeLight(Me)
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
    End Sub

    Private Sub ChooseStudent(sender As Object, e As EventArgs) Handles EnterStudentBtn.Click, ChooseStudentCard.Click, StudentPicturebox.Click, BigStudentLbl1.Click, SmolStudentLbl2.Click
        StudentLoginCard.Show()
        ChooseUserCard.Hide()
        StuLogStudIdTxtBox.Focus()
    End Sub

    Private Sub StuQRBackBtn_Click(sender As Object, e As EventArgs) Handles StuQRBackBtn.Click
        StudentLoginCard.Show()
        StuQRCard.Hide()
    End Sub

    Private Sub StuQRForgPass_Click(sender As Object, e As EventArgs) Handles StuQRForgPass.Click
        StuForgPassCard.Show()
        StuQRCard.Hide()
    End Sub

    Private Sub ProfQRBackBtn_Click(sender As Object, e As EventArgs) Handles ProfQRBackBtn.Click
        ProfLogCard.Show()
        ProfQRCard.Hide()
    End Sub

    Private Sub ProfQRForgPass_Click(sender As Object, e As EventArgs) Handles ProfQRForgPass.Click
        ProfForgPassCard.Show()
        ProfQRCard.Hide()
    End Sub

    Private Sub StuForgPassBackBtn_Click(sender As Object, e As EventArgs) Handles StuForgPassBackBtn.Click
        StudentLoginCard.Show()
        StuForgPassCard.Hide()
    End Sub

    Private Sub StuForgPassRecovBtn_Click(sender As Object, e As EventArgs) Handles StuForgPassRecovBtn.Click

    End Sub

    Private Sub ProfForgPassBackBtn_Click(sender As Object, e As EventArgs) Handles ProfForgPassBackBtn.Click
        ProfLogCard.Show()
        ProfForgPassCard.Hide()
    End Sub

    Private Sub ProfForgPassRecovBtn_Click(sender As Object, e As EventArgs) Handles ProfForgPassRecovBtn.Click

    End Sub

    Private Sub StuRegBackBtn_Click(sender As Object, e As EventArgs) Handles StuRegBackBtn.Click
        StudentLoginCard.Show()
        StuRegCard.Hide()
    End Sub

    Private Sub StuRegSignUpBox_Click(sender As Object, e As EventArgs) Handles StuRegSignUpBox.Click

    End Sub

    Private Sub ProfRegBackBtn_Click(sender As Object, e As EventArgs) Handles ProfRegBackBtn.Click
        ProfLogCard.Show()
        ProfRegCard.Hide()
    End Sub

    Private Sub ProfRegSignUpBtn_Click(sender As Object, e As EventArgs) Handles ProfRegSignUpBtn.Click

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
End Class

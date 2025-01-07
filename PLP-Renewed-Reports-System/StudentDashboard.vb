Imports MySql.Data.MySqlClient

Public Class StudentDashboard
    Private LoggedStudentID As String
    Private FirstName As String
    Private MiddleIni As String
    Private LastName As String
    Private Suffix As String
    Private Section As String
    Private TimeIn As String
    Dim conn As New MySqlConnection("server=localhost;username=root;password=;database=plpportal_db")
    Public Sub New(StudentID As String)
        InitializeComponent()
        LoggedStudentID = StudentID

        conn.Open()
        Dim fcmd As New MySqlCommand("SELECT first_name FROM studentinfo where studentnum = '" & LoggedStudentID & "'", conn)
        fcmd.ExecuteNonQuery()
        Dim fdr As MySqlDataReader
        fdr = fcmd.ExecuteReader
        If fdr.Read Then FirstName = fdr("first_name")
        conn.Close()

        conn.Open()
        Dim mcmd As New MySqlCommand("SELECT middle_initial FROM studentinfo where studentnum = '" & LoggedStudentID & "'", conn)
        mcmd.ExecuteNonQuery()
        Dim mdr As MySqlDataReader
        mdr = mcmd.ExecuteReader
        If mdr.Read Then MiddleIni = mdr("middle_initial")
        conn.Close()

        conn.Open()
        Dim lcmd As New MySqlCommand("SELECT last_name FROM studentinfo where studentnum = '" & LoggedStudentID & "'", conn)
        lcmd.ExecuteNonQuery()
        Dim ldr As MySqlDataReader
        ldr = lcmd.ExecuteReader
        If ldr.Read Then LastName = ldr("last_name")
        conn.Close()

        conn.Open()
        Dim scmd As New MySqlCommand("SELECT suffix FROM studentinfo where studentnum = '" & LoggedStudentID & "'", conn)
        scmd.ExecuteNonQuery()
        Dim sdr As MySqlDataReader
        sdr = scmd.ExecuteReader
        If sdr.Read Then Suffix = sdr("suffix") Else Suffix = ""
        conn.Close()

        conn.Open()
        Dim secmd As New MySqlCommand("SELECT section FROM studentinfo where studentnum = '" & LoggedStudentID & "'", conn)
        secmd.ExecuteNonQuery()
        Dim sedr As MySqlDataReader
        sedr = secmd.ExecuteReader
        If sedr.Read Then Section = sedr("section")
        conn.Close()
    End Sub

    ' WILL EXECUTE WHEN STUDENT DASHBOARD FORM SHOWS
    Private Sub StudentDashboard_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        SetFormThemeLight(Me) ' Default Light Theme
        StudentNameLbl.Text = FirstName & " " & MiddleIni & " " & LastName & " " & Suffix ' Sets the name of the logged in student
        LoggedStudentSection.Text = Section

        ' Sets the number of professors card
        conn.Open()
        Dim cmd As New MySqlCommand("SELECT * FROM profinfo", conn)
        Dim da As New MySqlDataAdapter(cmd)
        Dim dt As New DataTable()
        da.Fill(dt)
        NumOfProf.Text = dt.Rows.Count().ToString()
        conn.Close()

        ' Sets the number of students card
        conn.Open()
        Dim pcmd As New MySqlCommand("SELECT * FROM studentinfo", conn)
        Dim pda As New MySqlDataAdapter(pcmd)
        Dim pdt As New DataTable()
        pda.Fill(pdt)
        NumOfStudent.Text = pdt.Rows.Count().ToString()
        conn.Close()
        LoadTheBoxes()
    End Sub

    Private Sub LoadTheBoxes()

        ' Loads the professors into the prof combo box

        conn.Open()
        Dim cmd As New MySqlCommand("SELECT name FROM profinfo", conn)
        Dim reader = cmd.ExecuteReader()
        While reader.Read
            Dim prof = reader.GetString("name")
            ProfComboBox.Items.Add(prof)
        End While
        conn.Close()

        ' Loads the sctions into the year and section combo box

        conn.Open()
        Dim scmd As New MySqlCommand("SELECT section FROM sections", conn)
        Dim sreader = scmd.ExecuteReader()
        While sreader.Read
            Dim sprof = sreader.GetString("section")
            YearComboBox.Items.Add(sprof)
        End While
        conn.Close()

        ' selects the section of the loggend in student
        YearComboBox.SelectedItem = Section

        TimeIn = Date.Now.ToString("hh:mm tt").ToUpper
        Dim YearNow As String = DateTime.Now.ToString("yy")

        If LoggedStudentID.Length >= 2 Then
            Dim firstTwoDigits As String = LoggedStudentID.Substring(0, 2)

            Dim firstTwoDigitsInt As Integer
            If Integer.TryParse(firstTwoDigits, firstTwoDigitsInt) Then
                If firstTwoDigitsInt < (YearNow - 4) Then ' if alumni
                    ReasonComboBox.Items.Add("Graduation")
                    ReasonComboBox.SelectedItem = "Graduation"
                    Me.BeginInvoke(Sub() ReasonComboBox.Focus())
                    CheckGrad()
                ElseIf firstTwoDigitsInt < (YearNow - 3) Then ' if 4th year na graduating
                    conn.Open()
                    Dim tcmd As New MySqlCommand("SELECT reason FROM reasons WHERE special = 'True'", conn)
                    Dim treader = tcmd.ExecuteReader()
                    While treader.Read
                        Dim tprof = treader.GetString("reason")
                        ReasonComboBox.Items.Add(tprof)
                    End While
                    conn.Close()
                    conn.Open()
                    Dim rcmd As New MySqlCommand("SELECT reason FROM reasons WHERE special = 'False'", conn)
                    Dim rreader = rcmd.ExecuteReader()
                    While rreader.Read
                        Dim rprof = rreader.GetString("reason")
                        ReasonComboBox.Items.Add(rprof)
                    End While
                    conn.Close()
                Else
                    conn.Open()
                    Dim tcmd As New MySqlCommand("SELECT reason FROM reasons WHERE special = 'True'", conn)
                    Dim treader = tcmd.ExecuteReader()
                    While treader.Read
                        Dim tprof = treader.GetString("reason")
                        ReasonComboBox.Items.Add(tprof)
                        ReasonComboBox.Items.Remove("Graduation")
                    End While
                    conn.Close()
                    conn.Open()
                    Dim rcmd As New MySqlCommand("SELECT reason FROM reasons WHERE special = 'False'", conn)
                    Dim rreader = rcmd.ExecuteReader()
                    While rreader.Read
                        Dim rprof = rreader.GetString("reason")
                        ReasonComboBox.Items.Add(rprof)
                    End While
                    conn.Close()
                End If
            End If
        End If

    End Sub

    ' Checks if the student is already graduated
    Private Sub CheckGrad()
        If ReasonComboBox.SelectedItem = "Graduation" Then
            'graToga.Visible = True
            'ProfNameComboBox.Enabled = False
            Me.BeginInvoke(Sub() ReasonComboBox.Focus())
        Else
            'graToga.Visible = False
            'ProfNameComboBox.Enabled = True
        End If
    End Sub

    Private Sub SignOutBtn_Click(sender As Object, e As EventArgs) Handles SignOutBtn.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure on logging out?", "Sign Out", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            EntrancePage.Show()
            Close()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        TimeLbl.Text = Date.Now.ToString("hh:mm tt").ToUpper
        DateLbl.Text = Date.Now.ToString("MMMM dd, yyyy")
        DateLbl.Left = NavCard.Width - DateLbl.Width - 50
        TimeLbl.Left = NavCard.Width - TimeLbl.Width - 50
    End Sub

    Private Sub SubmitBtn_Click(sender As Object, e As EventArgs) Handles SubmitBtn.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure on submitting your report?", "Report Submission", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            Dim TimeOut As String = Date.Now.ToString("hh:mm tt").ToUpper
            Dim special As String = ""
            Dim DateNow As String = CDate(DateTime.Now).ToString("yyyy-dd-MM")

            conn.Open()
            Dim tcmd As New MySqlCommand("SELECT special FROM reasons WHERE reason = @SelectedReason", conn)
            If ReasonComboBox.SelectedItem <> Nothing Then
                tcmd.Parameters.AddWithValue("@SelectedReason", ReasonComboBox.SelectedItem.ToString())
            Else
                MessageBox.Show("One or more field is empty!", "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                conn.Close()
                Return
            End If

            Dim sdr As MySqlDataReader = tcmd.ExecuteReader()
            If sdr.Read() Then
                special = sdr("special").ToString().ToLower() ' Convert to lowercase for a case-insensitive check
            End If
            sdr.Close()
            conn.Close()
            If special = "true" Then ' if graduating na student
                Try
                    conn.Open()
                    Dim cmd As New MySqlCommand("INSERT INTO reports VALUES (NULL, '" & LoggedStudentID & "', '" & LastName & "', '" & FirstName & "', '" & MiddleIni & "', '" & Suffix & "', '" & YearComboBox.Text & "', '" & "" & "', '" & DateNow & "', '" & ReasonComboBox.Text & "', '" & CommentsBox.Text & "', '" & TimeIn & "', '" & TimeOut & "')", conn)

                    cmd.ExecuteNonQuery()

                    conn.Close()

                    conn.Open()
                    Dim umd As New MySqlCommand("UPDATE studentinfo SET section = '" & Section & "' WHERE studentnum = '" & LoggedStudentID & "'", conn)

                    umd.ExecuteNonQuery()

                    conn.Close()

                    MessageBox.Show("Report Successfully Saved!", "Online Registration System", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    EntrancePage.Show()
                    Close()

                Catch ex As Exception
                    MsgBox(ex.Message)
                    conn.Close()
                End Try
            Else
                If ProfComboBox.Text = "" Or ReasonComboBox.Text = "" Then
                    MessageBox.Show("One or more field is empty!", "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    Try
                        conn.Open()
                        Dim cmd As New MySqlCommand("INSERT INTO reports VALUES (NULL, '" & LoggedStudentID & "', '" & LastName & "', '" & FirstName & "', '" & MiddleIni & "', '" & Suffix & "', '" & YearComboBox.Text & "', '" & ProfComboBox.Text & "', '" & DateNow & "', '" & ReasonComboBox.Text & "', '" & CommentsBox.Text & "', '" & TimeIn & "', '" & TimeOut & "')", conn)

                        cmd.ExecuteNonQuery()

                        conn.Close()

                        conn.Open()
                        Dim umd As New MySqlCommand("UPDATE studentinfo SET section = '" & YearComboBox.Text & "' WHERE studentnum = '" & LoggedStudentID & "'", conn)

                        umd.ExecuteNonQuery()

                        conn.Close()

                        MessageBox.Show("Report Successfully Saved!", "Online Registration System", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        EntrancePage.Show()
                        Close()

                    Catch ex As Exception
                        MsgBox(ex.Message)
                        conn.Close()
                    End Try
                End If
            End If

        End If
    End Sub

    Private Sub ReasonComboBox_SelectedValueChanged(sender As Object, e As EventArgs) Handles ReasonComboBox.SelectedValueChanged
        CheckGrad()
    End Sub

    Private Sub ReasonComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ReasonComboBox.SelectedIndexChanged
        If ReasonComboBox.SelectedItem <> Nothing And ReasonComboBox.Focused = False Then
            Dim selectedReason As String = ReasonComboBox.SelectedItem.ToString()

            conn.Open()
            Dim checkCmd As New MySqlCommand("SELECT special FROM reasons WHERE reason = @reason", conn)
            checkCmd.Parameters.AddWithValue("@reason", selectedReason)
            Dim specialValue As String = checkCmd.ExecuteScalar().ToString()
            conn.Close()

            If specialValue = "True" Then
                ProfComboBox.Enabled = False
                ProfComboBox.Items.Clear()
            Else
                conn.Open()
                Dim cmd As New MySqlCommand("SELECT name FROM profinfo", conn)
                Dim reader = cmd.ExecuteReader()
                While reader.Read
                    Dim prof = reader.GetString("name")
                    ProfComboBox.Items.Add(prof)
                End While
                conn.Close()
                ProfComboBox.Enabled = True
            End If
        End If
    End Sub

    Private Sub SearchProfBox_TextChanged(sender As Object, e As EventArgs) Handles SearchProfBox.TextChanged
        Dim searchText As String = SearchProfBox.Text.Trim()

        If String.IsNullOrWhiteSpace(searchText) Then
            ProfComboBox.SelectedIndex = -1
            ProfComboBox.Text = String.Empty
            ProfComboBox.Refresh()
        Else
            Dim closestMatch As String = Nothing
            For Each item In ProfComboBox.Items
                If item.ToString().Contains(searchText, StringComparison.OrdinalIgnoreCase) Then
                    closestMatch = item.ToString()
                    Exit For
                End If
            Next
            If closestMatch IsNot Nothing Then
                ProfComboBox.SelectedItem = closestMatch
                ProfComboBox.Text = closestMatch
                ProfComboBox.Refresh()
            Else
                ProfComboBox.SelectedIndex = -1
                ProfComboBox.Text = searchText
                ProfComboBox.Refresh()
            End If
        End If
    End Sub
End Class
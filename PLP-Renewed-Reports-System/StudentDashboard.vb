Imports MySql.Data.MySqlClient

Public Class StudentDashboard
    Private LoggedStudentID As String
    Private FirstName As String
    Private MiddleIni As String
    Private LastName As String
    Private Suffix As String
    Private Section As String
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

    Private Sub StudentDashboard_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        SetFormThemeLight(Me) ' Default Light Theme
        StudentNameLbl.Text = FirstName & " " & MiddleIni & " " & LastName & " " & Suffix ' Sets the name of the logged in student
        LoggedStudentSection.Text = Section
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
            ' Execute submission of report here...
        End If
    End Sub
End Class
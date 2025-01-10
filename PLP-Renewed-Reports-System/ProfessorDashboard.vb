Imports MySql.Data.MySqlClient
Imports System.Collections.Specialized.BitVector32
Imports Windows.Networking

Public Class ProfessorDashboard
    Private Sub ProfessorDashboard_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        SetFormThemeLight(Me)
        RowBarChart(ConsultCategPanel)
        ColumnBarChart(ReportCountPanel)
        PieChart(YourConsultCountPanel, ProfNameLbl.Text)
        PopulateCardsInDashboard()
        ProfLoadData()
    End Sub

    Dim ProfUser As String
    Dim ProfName As String
    Dim conn As New MySqlConnection("server=localhost;username=root;password=;database=plpportal_db")

    Public Sub New(ProfUsername As String)
        InitializeComponent()
        ProfUser = ProfUsername

        conn.Open()
        Dim cmd As New MySqlCommand("SELECT name FROM profinfo where username = '" & ProfUsername & "'", conn)
        cmd.ExecuteNonQuery()
        Dim dr As MySqlDataReader

        dr = cmd.ExecuteReader

        If dr.Read Then
            profNameLbl.Text = "Prof. " & dr("name")
        Else
            profNameLbl.Text = "" & Text & ""
        End If

        dr.Close()
        conn.Close()
    End Sub

    Private Sub PopulateCardsInDashboard()
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
        NumOfStud.Text = pdt.Rows.Count().ToString()
        conn.Close()

        ' Sets the number of reports card
        conn.Open()
        Dim rcmd As New MySqlCommand("SELECT * FROM reports", conn)
        Dim rda As New MySqlDataAdapter(rcmd)
        Dim rdt As New DataTable()
        rda.Fill(rdt)
        NumOfRep.Text = rdt.Rows.Count().ToString()
        conn.Close()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        TimeLbl.Text = Date.Now.ToString("hh:mm tt").ToUpper
        DateLbl.Text = Date.Now.ToString("MMMM dd, yyyy")
    End Sub

    Private Sub ProfLoadData()
        conn.Open()

        Dim cmd As New MySqlCommand("SELECT name as Fullname, email as 'Email_Address', username as Username, password as Password  FROM profinfo", conn)
        cmd.ExecuteNonQuery()
        conn.Close()

        Dim da As New MySqlDataAdapter(cmd)
        Dim dt As New DataTable

        da.Fill(dt)
        ProfDataGrid.DataSource = dt
    End Sub

End Class
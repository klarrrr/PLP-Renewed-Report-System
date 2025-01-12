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

    Private Sub ProfSearchProf_TextChanged(sender As Object, e As EventArgs) Handles ProfSearchProf.TextChanged
        If ProfSearchProf.Text = "" Then
            ProfLoadData()
        Else
            conn.Open()
            Dim cmd As New MySqlCommand("SELECT * FROM profinfo WHERE CONCAT(name, email, username, password) like '%" & ProfSearchProf.Text & "%'", conn)

            Dim adapter As New MySqlDataAdapter(cmd)
            Dim table As New DataTable

            adapter.Fill(table)

            cmd.ExecuteNonQuery()

            ProfDataGrid.DataSource = table
            conn.Close()
        End If
    End Sub

    Private Sub ProfClrBtn_Click(sender As Object, e As EventArgs) Handles ProfClrBtn.Click
        ProfProfName.Clear()
        ProfEmail.Clear()
        ProfUsername.Clear()
        ProfPass.Clear()
    End Sub

    Private Sub ProfDelBtn_Click(sender As Object, e As EventArgs) Handles ProfDelBtn.Click
        If ProfUsername.Text Or ProfPass.Text = "" Then
            MessageBox.Show("Unable to Delete a Professor, Select a Username first!", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Dim ask As MsgBoxResult
            ask = MsgBox("Do you really want to Delete this Professor?", MsgBoxStyle.YesNo, "Online Registration System")
            If ask = MsgBoxResult.Yes Then
                conn.Open()
                Dim cmd As New MySqlCommand("DELETE FROM profinfo WHERE username = '" & ProfUsername.Text & "'", conn)
                cmd.ExecuteNonQuery()
                MessageBox.Show("Successfully Deleted!", "Online Registration System", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ProfClrBtn.PerformClick()
                conn.Close()
                ProfLoadData()
            End If
        End If
    End Sub

    Private Sub ProfUpdBtn_Click(sender As Object, e As EventArgs) Handles ProfUpdBtn.Click
        If ProfProfName.Text = "" Or ProfEmail.Text = "" Or ProfUsername.Text = "" Or ProfPass.Text = "" Then
            MessageBox.Show("Unable to Update a Team, Fill up all the fields first!", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            conn.Open()
            Dim cmd As New MySqlCommand("UPDATE profinfo SET name = '" & ProfProfName.Text & "', email = '" & ProfEmail.Text & "', password = '" & ProfPass.Text & "'  WHERE username = '" & ProfUsername.Text & "'", conn)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Successfully Updated!", "Online Registration System", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ProfClrBtn.PerformClick()
            conn.Close()
            ProfLoadData()
        End If
    End Sub

    Private Sub ProfAddBtn_Click(sender As Object, e As EventArgs) Handles ProfAddBtn.Click
        Try
            If ProfProfName.Text = "" Or ProfEmail.Text = "" Or ProfUsername.Text = "" Or ProfPass.Text = "" Then
                MessageBox.Show("Unable to Insert a Professor, Fill up all the fields first!", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                conn.Open()
                Dim cmd As New MySqlCommand("INSERT INTO profinfo VALUES ('" & ProfProfName.Text & "', '" & ProfEmail.Text & "', '" & ProfUsername.Text & "', '" & ProfPass.Text & "')", conn)

                cmd.ExecuteNonQuery()
                MessageBox.Show("Successfully Added!", "Online Registration System", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ProfClrBtn.PerformClick()
                conn.Close()
                ProfLoadData()

                ' Update the ProfComboBox in the Student Dashboard
            End If
        Catch ex As Exception
            MessageBox.Show("Unable to Insert a Professor, Username is already taken!", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            conn.Close()
            ProfLoadData()
        End Try
    End Sub

    Private Sub ProfDataGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles ProfDataGrid.CellContentClick
        Try
            Dim index As Integer
            index = e.RowIndex

            Dim row As DataGridViewRow
            row = ProfDataGrid.Rows(index)

            ProfProfName.Text = row.Cells(0).Value.ToString
            ProfEmail.Text = row.Cells(1).Value.ToString
            ProfUsername.Text = row.Cells(2).Value.ToString
            ProfPass.Text = row.Cells(3).Value.ToString
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
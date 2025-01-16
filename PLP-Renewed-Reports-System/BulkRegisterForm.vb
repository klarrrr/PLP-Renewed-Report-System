Imports ClosedXML.Excel
Imports MySql.Data.MySqlClient

Public Class BulkRegisterForm
    Private Sub BulkCancelBtn_Click(sender As Object, e As EventArgs) Handles BulkCancelBtn.Click
        Close()
    End Sub

    Dim ProfUser As String
    Dim conn As New MySqlConnection("server=localhost;username=root;password=;database=plpportal_db")

    Public Sub New(ProfUsername As String)
        InitializeComponent()
        ProfUser = ProfUsername

        conn.Open()
        Dim cmd As New MySqlCommand("SELECT name FROM profinfo where username = '" & ProfUsername & "'", conn)
        cmd.ExecuteNonQuery()
        Dim dr As MySqlDataReader

        dr = cmd.ExecuteReader

        dr.Close()
        conn.Close()
    End Sub

    Private Sub RegisterStudents()
        ' Database con string (update with your database details)
        Dim conString As String = "server=localhost;username=root;password=;database=plpportal_db"
        Dim con As New MySqlConnection(conString)

        ' Open the con
        con.Open()

        Dim invalidRows As New List(Of String) ' To store error messages for invalid rows
        Dim validRows As New List(Of DataGridViewRow) ' To store rows that pass validation

        ' Iterate through all rows in the DataGridView
        For Each row As DataGridViewRow In BulkDataGrid.Rows
            ' Skip empty rows
            If row.IsNewRow Then Continue For

            ' Retrieve cell values
            Dim studentId As String = If(row.Cells("student_id").Value?.ToString().Trim(), "")
            Dim lastName As String = If(row.Cells("last_name").Value?.ToString().Trim(), "")
            Dim firstName As String = If(row.Cells("first_name").Value?.ToString().Trim(), "")
            Dim middle As String = If(row.Cells("middle").Value?.ToString().Trim(), "")
            Dim suffix As String = If(row.Cells("Suffix").Value?.ToString().Trim(), "")
            Dim email As String = If(row.Cells("email").Value?.ToString().Trim(), "")
            Dim section As String = If(row.Cells("section").Value?.ToString().Trim(), "")
            Dim YearLevel As String = If(row.Cells("year_level").Value?.ToString().Trim(), "")
            Dim Status As String = If(row.Cells("Status").Value?.ToString().Trim(), "")

            ' Validate student ID: Format with space and ensure only numbers
            studentId = System.Text.RegularExpressions.Regex.Replace(studentId, "(.{2})(\d+)", "$1 $2")
            If Not System.Text.RegularExpressions.Regex.IsMatch(studentId.Replace(" ", ""), "^\d+$") Then
                invalidRows.Add($"Row {row.Index + 1}: Student ID '{studentId}' contains invalid characters.")
                Continue For
            End If

            ' Validate required fields (except middle and suffix)
            If String.IsNullOrWhiteSpace(studentId) OrElse String.IsNullOrWhiteSpace(lastName) OrElse String.IsNullOrWhiteSpace(firstName) OrElse String.IsNullOrWhiteSpace(email) OrElse String.IsNullOrWhiteSpace(section) OrElse String.IsNullOrWhiteSpace(YearLevel) OrElse String.IsNullOrWhiteSpace(Status) Then
                invalidRows.Add($"Row {row.Index + 1}: Required fields are missing.")
                Continue For
            End If

            ' Validate email format
            If Not email.EndsWith("@plpasig.edu.ph") Then
                invalidRows.Add($"Row {row.Index + 1}: Email '{email}' is invalid.")
                Continue For
            End If

            ' Validate section against "sections" table
            Dim sectionExists As Boolean
            Using sectionCmd As New MySqlCommand("SELECT COUNT(*) FROM sections WHERE section = @section", con)
                sectionCmd.Parameters.AddWithValue("@section", section)
                sectionExists = Convert.ToInt32(sectionCmd.ExecuteScalar()) > 0
            End Using

            If Not sectionExists Then
                invalidRows.Add($"Row {row.Index + 1}: Section '{section}' does not exist.")
                Continue For
            End If

            ' If all validations pass, add the row to validRows
            validRows.Add(row)
        Next

        ' If there are invalid rows, show error messages and prompt user to continue
        If invalidRows.Count > 0 Then
            Dim errorMessage As String = "The following rows failed validation:" & Environment.NewLine & String.Join(Environment.NewLine, invalidRows)
            errorMessage &= Environment.NewLine & Environment.NewLine & "Do you want to proceed with registering only the valid rows?"
            Dim result = MessageBox.Show(errorMessage, "Validation Errors", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            If result = DialogResult.No Then
                con.Close()
                Exit Sub
            End If
        End If

        ' Register valid rows
        Try
            Dim duplicates As New List(Of String)() ' List to store duplicate entries

            For Each row In validRows
                Dim studentId As String = If(row.Cells("student_id").Value?.ToString().Trim(), "")
                Dim lastName As String = If(row.Cells("last_name").Value?.ToString().Trim(), "")
                Dim firstName As String = If(row.Cells("first_name").Value?.ToString().Trim(), "")
                Dim middle As String = If(row.Cells("middle").Value?.ToString().Trim(), "")
                Dim suffix As String = If(row.Cells("suffix").Value?.ToString().Trim(), "")
                Dim email As String = If(row.Cells("email").Value?.ToString().Trim(), "")
                Dim section As String = If(row.Cells("section").Value?.ToString().Trim(), "")
                Dim yearLevel As String = If(row.Cells("year_level").Value?.ToString().Trim(), "")
                Dim status As String = If(row.Cells("status").Value?.ToString().Trim(), "")

                Dim insertCmd As New MySqlCommand("INSERT INTO studentinfo (studentnum, last_name, first_name, middle_initial, suffix, email, section, year_level, status) VALUES (@studentId, @lastName, @firstName, @middle, @suffix, @Email, @section, @year_level, @status)", con)
                insertCmd.Parameters.AddWithValue("@studentId", studentId)
                insertCmd.Parameters.AddWithValue("@lastName", lastName)
                insertCmd.Parameters.AddWithValue("@firstName", firstName)
                insertCmd.Parameters.AddWithValue("@middle", If(String.IsNullOrEmpty(middle), "", middle))
                insertCmd.Parameters.AddWithValue("@suffix", If(String.IsNullOrEmpty(suffix), "", suffix))
                insertCmd.Parameters.AddWithValue("@Email", email)
                insertCmd.Parameters.AddWithValue("@section", section)
                insertCmd.Parameters.AddWithValue("@year_level", yearLevel)
                insertCmd.Parameters.AddWithValue("@status", status)

                Try
                    insertCmd.ExecuteNonQuery()
                Catch ex As MySqlException
                    If ex.Number = 1062 Then
                        ' Add the duplicate studentId to the list
                        duplicates.Add($"Student ID: {studentId}, Name: {lastName}, {firstName}")
                    Else
                        Throw
                    End If
                End Try
            Next

            ' Display all duplicates if any
            If duplicates.Count > 0 Then
                Dim duplicateMessage As String = "Duplicate entries detected:" & Environment.NewLine &
                                         String.Join(Environment.NewLine, duplicates)
                MessageBox.Show(duplicateMessage, "Failed to Register", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        ' Close the con
        con.Close()

        ' Success message
        MessageBox.Show("Only the Valid students registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Dim ProfForm As New ProfessorDashboard(ProfUser)
        ProfForm.StuLoadData()
        ProfForm.StuDataGrid.Refresh()

        ' Close the form
        Close()
    End Sub

    Private Sub LoadExcelToDataGrid(filePath As String)
        Try
            ' Load the Excel workbook
            Dim workbook As New XLWorkbook(filePath)
            Dim worksheet As IXLWorksheet = workbook.Worksheet(1) ' First sheet in the workbook

            ' Define the required columns
            Dim requiredColumns As String() = {"student_id", "last_name", "first_name", "middle", "suffix", "email", "section", "year_level", "status"}

            ' Get headers from the first row of the Excel file
            Dim headers As New List(Of String)
            Dim firstRow = worksheet.Row(1)
            For Each cell In firstRow.CellsUsed()
                headers.Add(cell.GetValue(Of String)().Trim().ToLower())
            Next

            ' Validate if all required columns are present
            For Each requiredColumn In requiredColumns
                If Not headers.Contains(requiredColumn.ToLower()) Then
                    MessageBox.Show($"Error: Missing required column '{requiredColumn}' in the Excel file.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            Next

            ' Create a new DataTable
            Dim dt As New DataTable()

            ' Add columns to the DataTable based on the Excel headers
            For Each header In headers
                dt.Columns.Add(header)
            Next

            ' Add rows to DataTable (data from subsequent rows)
            For Each row In worksheet.RowsUsed().Skip(1) ' Skip the first row (headers)
                Dim dataRow = dt.NewRow()
                For colIndex As Integer = 1 To headers.Count
                    dataRow(colIndex - 1) = row.Cell(colIndex).GetValue(Of String)()
                Next
                dt.Rows.Add(dataRow)
            Next

            ' Bind DataTable to Guna2DataGridView
            BulkDataGrid.DataSource = Nothing
            BulkDataGrid.DataSource = dt
            BulkDataGrid.Refresh()

            MessageBox.Show("Data loaded successfully!")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BulkRegisterBtn_Click(sender As Object, e As EventArgs) Handles BulkRegisterBtn.Click
        RegisterStudents()
    End Sub

    Private Sub BulkUploadBtn_Click(sender As Object, e As EventArgs) Handles BulkUploadBtn.Click
        Dim OpenDialog As New OpenFileDialog With {
    .Filter = "Excel Files|*.xlsx"
}

        If OpenDialog.ShowDialog() = DialogResult.OK Then
            Dim FilePath As String = OpenDialog.FileName
            LoadExcelToDataGrid(FilePath)
        End If
    End Sub

    Private Sub BulkClrBtn_Click(sender As Object, e As EventArgs) Handles BulkClrBtn.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to clear the whole table?", "Table Clear Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then
            Return
        End If
        DirectCast(BulkDataGrid.DataSource, DataTable).Clear()
        BulkDataGrid.Refresh()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim ProfForm As New ProfessorDashboard(ProfUser)
        If ProfForm Is Nothing OrElse Not ProfForm.Visible OrElse ProfForm.IsDisposed Then
            Close()
        End If
    End Sub
End Class
Imports MySql.Data.MySqlClient
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO
Imports OxyPlot.WindowsForms
Imports System.Windows.Controls
Imports System.ComponentModel

Public Class ProfessorDashboard
    Private Sub ProfessorDashboard_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ' THEME
        SetFormThemeLight(Me)

        ' LAST VISITED TAB FOR SIGN OUT
        LastVisitedTab = 0

        ' DASHBOARD
        RowBarChart(ConsultCategPanel)
        ColumnBarChart(ReportCountPanel)
        PieChart(YourConsultCountPanel, ProfNameLbl.Text)
        PopulateCardsInDashboard()

        ' PROFESSORS
        ProfLoadData()

        ' STUDENTS
        StuLoadData()
        LoadSectionInStudents()
        LoadPromotionDate()

        ' REPORTS
        RepLoadData()
        ReportsChart(YearlyRepPanel, RepDataGrid)
        RepSortBy.SelectedIndex = -1
        RepProf1BoxLoadData()
        RepProf2BoxLoadData()
        RepYearBoxLoadData()
        RepYearBox.SelectedIndex = 0

        ' REASONS
        ReaLoadData()

        ' SECTIONS
        SectLoadData()

        'ARCHIVE
        ArchLoadData()
        ArchLoadFilter()

        ' DATE LABEL READJUSTMENT
        If Date.Now.Day >= 10 Then
            DateLbl.Left = DateLbl.Left - 8
        End If

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
            ProfNameLbl.Text = "Prof. " & dr("name")
        Else
            ProfNameLbl.Text = "" & Text & ""
        End If

        dr.Close()
        conn.Close()
    End Sub
    ' populate the number of something in the cards in dashboard tab
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
        If Date.Today.Date >= StudDateOfGrad.Value Then
            PromoteStudents()
        End If
    End Sub

    ' PROFESSORS TAB

    ' load professor data in data grid
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
    ' search bar in professor tab
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
    ' clear button in professor tab
    Private Sub ProfClrBtn_Click(sender As Object, e As EventArgs) Handles ProfClrBtn.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure on clearing text boxes?", "Clear Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then
            Return
        End If
        ProfClear()
    End Sub

    Private Sub ProfClear()
        ProfProfName.Clear()
        ProfEmail.Clear()
        ProfUsername.Clear()
        ProfPass.Clear()
    End Sub

    ' click delete button in professor tab
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
                ProfClear()
                conn.Close()
                ProfLoadData()
            End If
        End If
    End Sub

    ' click update button in professor tab
    Private Sub ProfUpdBtn_Click(sender As Object, e As EventArgs) Handles ProfUpdBtn.Click
        If ProfProfName.Text = "" Or ProfEmail.Text = "" Or ProfUsername.Text = "" Or ProfPass.Text = "" Then
            MessageBox.Show("Unable to Update a Team, Fill up all the fields first!", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            conn.Open()
            Dim cmd As New MySqlCommand("UPDATE profinfo SET name = '" & ProfProfName.Text & "', email = '" & ProfEmail.Text & "', password = '" & ProfPass.Text & "'  WHERE username = '" & ProfUsername.Text & "'", conn)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Successfully Updated!", "Online Registration System", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ProfClear()
            conn.Close()
            ProfLoadData()
        End If
    End Sub

    ' click add button in professor tab
    Private Sub ProfAddBtn_Click(sender As Object, e As EventArgs) Handles ProfAddBtn.Click
        Try
            If ProfProfName.Text = "" Or ProfEmail.Text = "" Or ProfUsername.Text = "" Or ProfPass.Text = "" Then
                MessageBox.Show("Unable to Insert a Professor, Fill up all the fields first!", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                conn.Open()
                Dim cmd As New MySqlCommand("INSERT INTO profinfo VALUES ('" & ProfProfName.Text & "', '" & ProfEmail.Text & "', '" & ProfUsername.Text & "', '" & ProfPass.Text & "')", conn)

                cmd.ExecuteNonQuery()
                MessageBox.Show("Successfully Added!", "Online Registration System", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ProfClear()
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

    ' Click something in the professor data grid
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

    ' STUDENTS TAB
    Public Sub StuLoadData()
        conn.Open()

        Dim cmd As New MySqlCommand("SELECT studentnum as 'Student ID', last_name as 'Last Name', first_name as 'First Name', middle_initial as 'Middle Initial', suffix as Suffix, email as Email, section as Section, year_level as 'Year Level', status as Status FROM studentinfo", conn)
        cmd.ExecuteNonQuery()
        conn.Close()

        Dim da As New MySqlDataAdapter(cmd)
        Dim dt As New DataTable
        dt.Clear()
        da.Fill(dt)
        StuDataGrid.DataSource = dt
    End Sub
    ' search bar of student tab
    Private Sub StudSearchStud_TextChanged(sender As Object, e As EventArgs) Handles StudSearchStud.TextChanged
        If StudSearchStud.Text = "" Then
            StuLoadData()
        Else
            conn.Open()
            Dim cmd As New MySqlCommand("SELECT studentnum as 'Student ID', last_name as 'Last Name', first_name as 'First Name', middle_initial as 'Middle Initial', suffix as Suffix, email as Email, section as Section, year_level as 'Year Level', status as Status FROM studentinfo WHERE CONCAT(studentnum, last_name, first_name, middle_initial, suffix, email, section) like '%" & StudSearchStud.Text & "%'", conn)

            Dim adapter As New MySqlDataAdapter(cmd)
            Dim table As New DataTable

            adapter.Fill(table)

            cmd.ExecuteNonQuery()

            StuDataGrid.DataSource = table
            conn.Close()
        End If
    End Sub
    ' load section in the section combo box in students
    Private Sub LoadSectionInStudents()
        conn.Open()
        Dim cmd As New MySqlCommand("SELECT section FROM sections", conn)
        Dim reader = cmd.ExecuteReader()
        While reader.Read
            Dim sect = reader.GetString("section")
            StudSection.Items.Add(sect)
        End While
        conn.Close()
    End Sub

    ' connection string just for another way of connecting to database
    Dim connectionString As String = "server=localhost;username=root;password=;database=plpportal_db"
    ' load the promotion or graduation date in the date picker student
    Private Sub LoadPromotionDate()
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()

                ' Query to get the promotion date
                Dim query As String = "SELECT value_date FROM config WHERE key_name = 'promotion_date'"
                Dim cmd As New MySqlCommand(query, conn)
                Dim result As Object = cmd.ExecuteScalar()

                ' If a date is found, set it to the DateTimePicker
                If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                    StudDateOfGrad.Value = Convert.ToDateTime(result)
                Else
                    MessageBox.Show("Promotion date not set. Please set a valid date.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading promotion date: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    ' student clear button
    Private Sub StudClrBtn_Click(sender As Object, e As EventArgs) Handles StudClrBtn.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure on clearing text boxes?", "Clear Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then
            Return
        End If
        ClearStudBoxes()
    End Sub

    Private Sub ClearStudBoxes()
        StudNum.Text = ""
        StudLastName.Text = ""
        StudFirstName.Text = ""
        StudMiddleInitial.Text = ""

        StudSuffix.SelectedIndex = -1
        StudSuffix.Text = ""
        StudSuffix.Refresh()

        StudEmail.Text = ""

        StudYear.SelectedIndex = -1
        StudYear.Text = ""
        StudYear.Refresh()

        StudSection.SelectedIndex = -1
        StudSection.Text = ""
        StudSection.Refresh()
    End Sub

    ' delete button from db
    Private Sub StudDelBtn_Click(sender As Object, e As EventArgs) Handles StudDelBtn.Click
        If StudNum.Text = "" Then
            MessageBox.Show("Unable to Delete a Student, Select a Student Number first!", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Dim ask As MsgBoxResult
            ask = MsgBox("Do you really want to Delete this Student?", MsgBoxStyle.YesNo, "Online Registration System")
            If ask = MsgBoxResult.Yes Then
                conn.Open()

                Dim cmd As New MySqlCommand("DELETE FROM studentinfo WHERE studentnum = '" & StudNum.Text & "'", conn)
                cmd.ExecuteNonQuery()
                MessageBox.Show("Successfully Deleted!", "Online Registration System", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ClearStudBoxes()

                conn.Close()

                StuLoadData()
            End If
        End If
    End Sub
    ' update student to db
    Private Sub StudUpdBtn_Click(sender As Object, e As EventArgs) Handles StudUpdBtn.Click
        If StudNum.Text = "" Or StudLastName.Text = "" Or StudFirstName.Text = "" Or StudEmail.Text = "" Or StudSection.Text = "" Then
            MessageBox.Show("Unable to Update a Student, Fill up all the required fields first!", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            conn.Open()

            Dim cmd As New MySqlCommand("UPDATE studentinfo SET last_name = '" & StudLastName.Text & "', first_name = '" & StudFirstName.Text & "',  middle_initial = '" & StudMiddleInitial.Text & "', suffix = '" & StudSuffix.Text & "', email = '" & StudEmail.Text & "', section = '" & StudSection.Text & "', year_level = '" & StudYear.SelectedItem & "', status = '" & StudStatus.SelectedItem & "'  WHERE studentnum = '" & StudNum.Text & "'", conn)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Successfully Updated!", "Online Registration System", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearStudBoxes()

            conn.Close()

            StuLoadData()
        End If
    End Sub
    ' add student to db
    Private Sub StudAddBtn_Click(sender As Object, e As EventArgs) Handles StudAddBtn.Click
        Try
            If StudNum.Text = "" Or StudLastName.Text = "" Or StudFirstName.Text = "" Or StudEmail.Text = "" Or StudSection.Text = "" Or StudYear.SelectedItem = Nothing Or StudStatus.SelectedItem = Nothing Then
                MessageBox.Show("Unable to Insert a Student, Fill up all the required fields first!", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else

                conn.Open()

                Dim cmd As New MySqlCommand("INSERT INTO studentinfo VALUES ('" & StudNum.Text & "', '" & StudLastName.Text & "', '" & StudFirstName.Text & "', '" & StudMiddleInitial.Text & "', '" & StudSuffix.Text & "', '" & StudEmail.Text & "', '" & StudSection.Text & "', '" & StudYear.SelectedItem & "', '" & StudStatus.SelectedItem & "')", conn)
                cmd.ExecuteNonQuery()
                MessageBox.Show("Successfully Added!", "Online Registration System", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ClearStudBoxes()

                conn.Close()

                StuLoadData()

            End If
        Catch ex As Exception
            MessageBox.Show("Unable to Insert a Student, Student Number is already taken!", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            conn.Close()

            StuLoadData()
        End Try
    End Sub

    ' Promote the students to a higher level by 1
    Private Sub PromoteStudents()
        ' Get the promotion date from DateTimePicker
        Dim promotionDate As Date = StudDateOfGrad.Value.ToUniversalTime().Date ' Assume the DateTimePicker is named "PromotionDatePicker"
        Dim currentDate As Date = Date.Today

        If currentDate >= promotionDate Then
            Using conn As New MySqlConnection(connectionString)
                conn.Open()

                ' Move 4th year Regular students to the archive table
                Dim archiveQuery As String = "
            INSERT INTO archive (studentnum, last_name, first_name, middle_initial, suffix, email, section, graduation_date)
            SELECT studentnum, last_name, first_name, middle_initial, suffix, email, section, CURDATE()
            FROM studentinfo
            WHERE year_level = '4' AND status = 'Regular'"

                Dim archiveCmd As New MySqlCommand(archiveQuery, conn)
                archiveCmd.ExecuteNonQuery()

                ' Delete archived students from the studentinfo table
                Dim deleteQuery As String = "
            DELETE FROM studentinfo
            WHERE year_level = '4' AND status = 'Regular'"

                Dim deleteCmd As New MySqlCommand(deleteQuery, conn)
                deleteCmd.ExecuteNonQuery()
            End Using

            ' Increment the promotion date by one year
            Dim newPromotionDate As Date = promotionDate.AddYears(1)
            StudDateOfGrad.Value = newPromotionDate
            StudDateOfGrad.Refresh()

            ' Save the updated promotion date to the database
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim updateDateQuery As String = "UPDATE config SET value_date = @newPromotionDate"
                Dim updateDateCmd As New MySqlCommand(updateDateQuery, conn)
                updateDateCmd.Parameters.AddWithValue("@newPromotionDate", newPromotionDate)
                updateDateCmd.ExecuteNonQuery()
            End Using

            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                ' Promote students to the next year level and update section
                Dim YearLevelQuery As String = "
                UPDATE studentinfo 
                SET 
                    year_level = CASE 
                        WHEN year_level = '1' THEN '2'
                        WHEN year_level = '2' THEN '3'
                        WHEN year_level = '3' THEN '4'
                    END
                WHERE year_level IN ('1', '2', '3');
                "
                Dim promoteYearLevel As New MySqlCommand(YearLevelQuery, conn)
                promoteYearLevel.ExecuteNonQuery()

                Dim SectionQuery As String = "
               UPDATE studentinfo 
                SET 
                    section = CASE
                        WHEN section IS NOT NULL AND section != '' AND LENGTH(section) >= 3 THEN 
                            CONCAT(
                                LEFT(section, LENGTH(section) - 2),
                                CASE 
                                    WHEN year_level = '2' THEN '2'
                                    WHEN year_level = '3' THEN '3'
                                    WHEN year_level = '4' THEN '4'
                                END,
                                RIGHT(section, 1)
                            )
                        ELSE section
                    END
                WHERE year_level IN ('2', '3', '4')
                  AND section IS NOT NULL AND section != '';
                "
                Dim promoteSection As New MySqlCommand(SectionQuery, conn)
                promoteSection.ExecuteNonQuery()
            End Using

            ' Notify the user after the promotion process is done
            MessageBox.Show("Promotion process completed successfully! Promotion date has been updated to " & newPromotionDate.ToString("yyyy-MM-dd"), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            StuLoadData()

            ' FIX LATER

            'If Application.OpenForms().OfType(Of AdminArchive).Any Then
            '    AdminArchive.ApplyFilters()
            '    AdminArchive.archdatagrid.Refresh()
            'End If
            'If Application.OpenForms().OfType(Of StudentDashboard).Any Then
            '    StudentDashboard.LoadAll()
            'End If
        Else
            MessageBox.Show("The promotion date has not been reached yet.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    ' save student graduation to db
    Private Sub SavePromotionDate()
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()

                ' Query to update the promotion date
                Dim query As String = "UPDATE config SET value_date = @date WHERE key_name = 'promotion_date'"
                Dim cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@date", StudDateOfGrad.Value)

                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                If rowsAffected > 0 Then
                    MessageBox.Show("Promotion date updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Failed to update promotion date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error saving promotion date: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    ' uppercase first name student
    Private Sub StudFirstName_TextChanged(sender As Object, e As EventArgs) Handles StudFirstName.TextChanged
        Dim currentText As String = StudFirstName.Text
        Dim upperCaseText As String = currentText.ToUpper()

        StudFirstName.Text = upperCaseText
        StudFirstName.SelectionStart = StudFirstName.Text.Length
    End Sub
    ' uppercase last name student
    Private Sub StudLastName_TextChanged(sender As Object, e As EventArgs) Handles StudLastName.TextChanged
        Dim currentText As String = StudLastName.Text
        Dim upperCaseText As String = currentText.ToUpper()

        StudLastName.Text = upperCaseText
        StudLastName.SelectionStart = StudLastName.Text.Length
    End Sub

    ' just for proper spacing of student number
    Private Sub StudNum_TextChanged(sender As Object, e As EventArgs) Handles StudNum.TextChanged
        Dim textWithoutSpaces As String = StudNum.Text.Replace(" ", "")
        If textWithoutSpaces.Length >= 2 Then
            StudNum.Text = textWithoutSpaces.Insert(2, " ")
            StudNum.SelectionStart = StudNum.TextLength
        End If
        If StudNum.TextLength > 8 Then
            StudNum.Text = StudNum.Text.Substring(0, 8)
            StudNum.SelectionStart = StudNum.TextLength
        End If
    End Sub

    ' Button to Save the student's graduation date

    Private Sub StudSaveDate_Click(sender As Object, e As EventArgs) Handles StudSaveDate.Click
        Dim result As DialogResult = MessageBox.Show("Are you setting the graduation date?", "Graduation Date Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then
            Return
        End If
        SavePromotionDate()
    End Sub

    Private Sub StuDataGrid_SelectionChanged(sender As Object, e As EventArgs) Handles StuDataGrid.SelectionChanged
        Try
            Dim current_row = 0
            If StuDataGrid.CurrentRow IsNot Nothing Then
                current_row = StuDataGrid.CurrentRow.Index
            End If
            If current_row >= 0 Then
                ' Update the text boxes and combo boxes with values from the selected row
                StudNum.Text = StuDataGrid(0, current_row).Value
                StudLastName.Text = StuDataGrid(1, current_row).Value
                StudFirstName.Text = StuDataGrid(2, current_row).Value
                StudMiddleInitial.Text = StuDataGrid(3, current_row).Value
                If StuDataGrid(4, current_row).Value <> Nothing Then
                    StudSuffix.SelectedItem = StuDataGrid(4, current_row).Value
                    StudSuffix.Text = StuDataGrid(4, current_row).Value
                    StudSuffix.Refresh()
                Else
                    StudSuffix.SelectedItem = Nothing
                    StudSuffix.Text = Nothing
                    StudSuffix.Refresh()
                End If
                StudEmail.Text = StuDataGrid(5, current_row).Value
                If StuDataGrid(6, current_row).Value <> Nothing Then
                    StudSection.SelectedItem = StuDataGrid(6, current_row).Value
                    StudSection.Text = StuDataGrid(6, current_row).Value
                    StudSection.Refresh()
                Else
                    StudSection.SelectedItem = Nothing
                    StudSection.Text = Nothing
                    StudSection.Refresh()
                End If
                If StuDataGrid(7, current_row).Value <> Nothing Then
                    StudYear.SelectedItem = StuDataGrid(7, current_row).Value
                    StudYear.Text = StuDataGrid(7, current_row).Value
                    StudYear.Refresh()
                Else
                    StudYear.SelectedItem = Nothing
                    StudYear.Text = Nothing
                    StudYear.Refresh()
                End If
                If StuDataGrid(8, current_row).Value <> Nothing Then
                    StudStatus.SelectedItem = StuDataGrid(8, current_row).Value
                    StudStatus.Text = StuDataGrid(8, current_row).Value
                    StudStatus.Refresh()
                Else
                    StudStatus.SelectedItem = Nothing
                    StudStatus.Text = Nothing
                    StudStatus.Refresh()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub StudNum_KeyDown(sender As Object, e As KeyEventArgs) Handles StudNum.KeyDown
        If e.KeyCode = Keys.Enter Then
            StudLastName.Focus()
        End If
    End Sub

    Private Sub StudLastName_KeyDown(sender As Object, e As KeyEventArgs) Handles StudLastName.KeyDown
        If e.KeyCode = Keys.Enter Then
            StudFirstName.Focus()
        End If
    End Sub

    Private Sub StudFirstName_KeyDown(sender As Object, e As KeyEventArgs) Handles StudFirstName.KeyDown
        If e.KeyCode = Keys.Enter Then
            StudMiddleInitial.Focus()
        End If
    End Sub

    Private Sub StudMiddleInitial_KeyDown(sender As Object, e As KeyEventArgs) Handles StudMiddleInitial.KeyDown
        If e.KeyCode = Keys.Enter Then
            StudSuffix.Focus()
        End If
    End Sub

    Private Sub StudEmail_KeyDown(sender As Object, e As KeyEventArgs) Handles StudEmail.KeyDown
        If e.KeyCode = Keys.Enter Then
            StudSection.Focus()
        End If
    End Sub

    Private Sub StudSection_SelectedIndexChanged(sender As Object, e As EventArgs) Handles StudSection.SelectedIndexChanged
        Dim ChosenItem As String = StudSection.SelectedItem
        If StudSection.SelectedIndex <> -1 Then
            If ChosenItem.Contains("4"c) Then
                StudYear.SelectedItem = 4
                StudYear.Text = 4
                StudYear.Refresh()
            ElseIf ChosenItem.Contains("3"c) Then
                StudYear.SelectedItem = 3
                StudYear.Text = 3
                StudYear.Refresh()
            ElseIf ChosenItem.Contains("2"c) Then
                StudYear.SelectedItem = 2
                StudYear.Text = 2
                StudYear.Refresh()
            ElseIf ChosenItem.Contains("1"c) Then
                StudYear.SelectedItem = 1
                StudYear.Text = 1
                StudYear.Refresh()
            End If
        End If
    End Sub

    ' FIX LATER
    ' This changes the year of the section combo box if year combo box is changed

    'Private Sub StudYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles StudYear.SelectedIndexChanged
    '    Dim ChosenItem As String = StudYear.SelectedItem
    '    Dim CurrentItem As String = StudSection.SelectedItem
    '    If ChosenItem.Contains("123") Then
    '        Dim ReplacedItem As String = Regex.Replace(CurrentItem, "[0-3]{2,}", "4")
    '        StudSection.SelectedItem = ReplacedItem
    '        StudSection.Text = StudSection.SelectedItem
    '        StudSection.Refresh()
    '    ElseIf ChosenItem.Contains("3"c) Then
    '        StudSection.SelectedItem = StudSection.FindString(ChosenItem)
    '        StudSection.Text = StudSection.SelectedItem
    '        StudSection.Refresh()
    '    ElseIf ChosenItem.Contains("2"c) Then
    '        StudSection.SelectedItem = StudSection.FindString(ChosenItem)
    '        StudSection.Text = StudSection.SelectedItem
    '        StudSection.Refresh()
    '    ElseIf ChosenItem.Contains("1"c) Then
    '        StudSection.SelectedItem = StudSection.FindString(ChosenItem)
    '        StudSection.Text = StudSection.SelectedItem
    '        StudSection.Refresh()
    '    End If
    'End Sub

    ' Bulk registration of student from excel

    ' FIX LATER

    'Private Sub StudUploadBtn_Click(sender As Object, e As EventArgs) Handles StudUploadBtn.Click
    '    If Application.OpenForms().OfType(Of BulkRegistrationStudents).Any Then
    '        MessageBox.Show("Bulk Add is already opened")
    '    Else
    '        BulkRegistrationStudents.Show()
    '    End If
    'End Sub

    ' REPORTS TAB



    ' REASONS TAB

    Private Sub ReaLoadData()
        conn.Open()

        Dim cmd As New MySqlCommand("SELECT reason_ID as 'Reason ID', reason as 'Reason Name', special as 'Special Event' FROM reasons", conn)
        cmd.ExecuteNonQuery()
        conn.Close()

        Dim da As New MySqlDataAdapter(cmd)
        Dim dt As New DataTable

        da.Fill(dt)
        ReaDataGrid.DataSource = dt
    End Sub

    Private Sub ReaSearchReason_TextChanged(sender As Object, e As EventArgs) Handles ReaSearchReason.TextChanged
        If ReaSearchReason.Text = "" Then
            ReaLoadData()
        Else
            conn.Open()
            Dim cmd As New MySqlCommand("SELECT reason_ID as 'Reason ID', reason as 'Reason Name', special as 'Special Event' FROM reasons WHERE CONCAT(reason_ID, reason, special) like '%" & ReaSearchReason.Text & "%'", conn)

            Dim adapter As New MySqlDataAdapter(cmd)
            Dim table As New DataTable()

            adapter.Fill(table)

            cmd.ExecuteNonQuery()

            ReaDataGrid.DataSource = table
            conn.Close()
        End If
    End Sub

    ' Clear Reason boxes
    Private Sub ReaClear()
        ReaReasonID.Text = ""
        ReaReasonName.Text = ""
        ReaSpecialEvent.Text = ""
        ReaSpecialEvent.SelectedItem = -1
        ReaSpecialEvent.Refresh()
    End Sub

    Private Sub ReaDataGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles ReaDataGrid.CellContentClick
        Try
            Dim index As Integer
            index = e.RowIndex

            Dim row As DataGridViewRow
            row = ReaDataGrid.Rows(index)

            ReaReasonID.Text = row.Cells(0).Value.ToString
            ReaReasonName.Text = row.Cells(1).Value.ToString
            ReaSpecialEvent.Text = row.Cells(2).Value.ToString
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    ' Delete button in reason
    Private Sub ReaDelBtn_Click(sender As Object, e As EventArgs) Handles ReaDelBtn.Click
        If ReaReasonID.Text = "" Then
            MessageBox.Show("Unable to Delete a Reason, Select an ID first!", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Dim ask As MsgBoxResult
            ask = MsgBox("Do you really want to Delete this Reason?", MsgBoxStyle.YesNo, "Online Registration System")
            If ask = MsgBoxResult.Yes Then
                conn.Open()

                Dim cmd As New MySqlCommand("DELETE FROM reasons WHERE reason_ID = '" & ReaReasonID.Text & "'", conn)
                cmd.ExecuteNonQuery()
                MessageBox.Show("Successfully Deleted!", "Online Registration System", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ReaClear()
                conn.Close()

                ReaLoadData()
            End If
        End If
    End Sub

    ' Update Button in Reason
    Private Sub ReaUpdBtn_Click(sender As Object, e As EventArgs) Handles ReaUpdBtn.Click
        If ReaReasonName.Text = "" Or ReaReasonID.Text = "" Then
            MessageBox.Show("Unable to Update a Reason, Fill up all the fields first!", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            conn.Open()
            Dim cmd As New MySqlCommand("UPDATE reasons SET reason = '" & ReaReasonName.Text & "', special = '" & ReaSpecialEvent.Text & "' WHERE reason_ID = '" & ReaReasonID.Text & "'", conn)

            cmd.ExecuteNonQuery()
            MessageBox.Show("Successfully Updated!", "Online Registration System", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ReaClear()
            conn.Close()

            ReaLoadData()
        End If
    End Sub

    ' Add Button on Reason
    Private Sub ReaAddBtn_Click(sender As Object, e As EventArgs) Handles ReaAddBtn.Click
        Try
            If ReaReasonName.Text = "" Or ReaReasonID.Text = "" Or ReaSpecialEvent.Text = "" Then
                MessageBox.Show("Unable to Insert a Reason, Fill up the field first!", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                conn.Open()
                Dim cmd As New MySqlCommand("INSERT INTO reasons VALUES (" & ReaReasonID.Text & ", '" & ReaReasonName.Text & "' , '" & ReaSpecialEvent.Text & "')", conn)

                cmd.ExecuteNonQuery()
                MessageBox.Show("Successfully Added!", "Online Registration System", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ReaClear()
                conn.Close()

                ReaLoadData()
            End If
        Catch ex As Exception
            MessageBox.Show("Unable to Insert a Reason, ID is already taken!", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            conn.Close()

            ReaLoadData()
        End Try
    End Sub

    Private Sub ReaReasonID_KeyDown(sender As Object, e As KeyEventArgs) Handles ReaReasonID.KeyDown
        If e.KeyCode = Keys.Enter Then
            ReaReasonName.Focus()
        End If
    End Sub

    Private Sub ReaReasonName_KeyDown(sender As Object, e As KeyEventArgs) Handles ReaReasonName.KeyDown
        If e.KeyCode = Keys.Enter Then
            ReaSpecialEvent.Focus()
        End If
    End Sub

    Private Sub ReaClrBtn_Click(sender As Object, e As EventArgs) Handles ReaClrBtn.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure on clearing text boxes?", "Clear Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then
            Return
        End If
        ReaClear()
    End Sub

    ' SECTIONS TAB

    Private Sub SectLoadData()
        conn.Open()

        Dim cmd As New MySqlCommand("SELECT id as 'Section ID', section as 'Section Name' FROM sections", conn)
        cmd.ExecuteNonQuery()
        conn.Close()

        Dim da As New MySqlDataAdapter(cmd)
        Dim dt As New DataTable

        da.Fill(dt)
        SectDataGrid.DataSource = dt
    End Sub

    Private Sub SectClrBtn_Click(sender As Object, e As EventArgs) Handles SectClrBtn.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure on clearing text boxes?", "Clear Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then
            Return
        End If
        SectClear()
    End Sub

    Private Sub SectClear()
        SectSectID.Clear()
        SectName.Clear()
    End Sub

    Private Sub SectSearchSect_TextChanged(sender As Object, e As EventArgs) Handles SectSearchSect.TextChanged
        If SectSearchSect.Text = "" Then
            SectLoadData()
        Else
            conn.Open()
            Dim cmd As New MySqlCommand("SELECT id as 'Section ID', section as 'Section Name' FROM sections WHERE CONCAT(id, section) like '%" & SectSearchSect.Text & "%'", conn)

            Dim adapter As New MySqlDataAdapter(cmd)
            Dim table As New DataTable()

            adapter.Fill(table)

            cmd.ExecuteNonQuery()

            SectDataGrid.DataSource = table
            conn.Close()
        End If
    End Sub

    Private Sub SectAddBtn_Click(sender As Object, e As EventArgs) Handles SectAddBtn.Click
        Try
            If SectName.Text = "" Or SectSectID.Text = "" Then
                MessageBox.Show("Unable to Insert a Section, Fill up the field first!", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                conn.Open()
                Dim cmd As New MySqlCommand("INSERT INTO sections VALUES (" & SectSectID.Text & ", '" & SectSectID.Text & "')", conn)

                cmd.ExecuteNonQuery()
                MessageBox.Show("Successfully Added!", "Online Registration System", MessageBoxButtons.OK, MessageBoxIcon.Information)

                SectClear()
                conn.Close()

                SectLoadData()
            End If
        Catch ex As Exception
            MessageBox.Show("Unable to Insert a Section, ID is already taken!", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            conn.Close()
            SectLoadData()
        End Try
    End Sub

    Private Sub SectUpdBtn_Click(sender As Object, e As EventArgs) Handles SectUpdBtn.Click
        If SectSearchSect.Text = "" Or SectSectID.Text = "" Then
            MessageBox.Show("Unable to Update a Section, Fill up all the fields first!", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            conn.Open()
            Dim cmd As New MySqlCommand("UPDATE sections SET section = '" & SectName.Text & "' WHERE id = '" & SectSectID.Text & "'", conn)

            cmd.ExecuteNonQuery()
            MessageBox.Show("Successfully Updated!", "Online Registration System", MessageBoxButtons.OK, MessageBoxIcon.Information)
            SectClear()
            conn.Close()

            SectLoadData()
        End If
    End Sub

    Private Sub SectDelBtn_Click(sender As Object, e As EventArgs) Handles SectDelBtn.Click
        If SectSectID.Text = "" Then
            MessageBox.Show("Unable to Delete a Section, Select an ID first!", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Dim ask As MsgBoxResult
            ask = MsgBox("Do you really want to Delete this Section?", MsgBoxStyle.YesNo, "Online Registration System")
            If ask = MsgBoxResult.Yes Then
                conn.Open()

                Dim cmd As New MySqlCommand("DELETE FROM sections WHERE id = '" & SectSectID.Text & "'", conn)
                cmd.ExecuteNonQuery()
                MessageBox.Show("Successfully Deleted!", "Online Registration System", MessageBoxButtons.OK, MessageBoxIcon.Information)
                SectClear()
                conn.Close()

                SectLoadData()
            End If
        End If
    End Sub

    Private Sub SectDataGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles SectDataGrid.CellContentClick
        Try
            If SectDataGrid.SelectedCells IsNot Nothing Then
                Dim index As Integer
                index = e.RowIndex

                Dim row As DataGridViewRow
                row = SectDataGrid.Rows(index)

                SectSectID.Text = row.Cells(0).Value.ToString
                SectName.Text = row.Cells(1).Value.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub SectSectID_KeyDown(sender As Object, e As KeyEventArgs) Handles SectSectID.KeyDown
        If e.KeyCode = Keys.Enter Then
            SectName.Focus()
        End If
    End Sub

    Private Sub SectName_KeyDown(sender As Object, e As KeyEventArgs) Handles SectName.KeyDown
        If e.KeyCode = Keys.Enter Then
            SectAddBtn.PerformClick()
        End If
    End Sub

    ' ARCHIVES TAB

    Private Sub ArchFilBySect_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ArchFilBySect.SelectedIndexChanged
        ArchLoadData()
    End Sub

    Private Sub ArchFilByYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ArchFilByYear.SelectedIndexChanged
        ArchLoadData()
    End Sub

    Private Sub ArchClrBtn_Click(sender As Object, e As EventArgs) Handles ArchClrBtn.Click
        SaveFileDialog1.ShowDialog()
        If SaveFileDialog1.FileName = "" Then
            MsgBox("Enter filename to create PDF!", vbExclamation)
        Else
            Dim pdfTable As New PdfPTable(ArchDataGrid.ColumnCount)
            pdfTable.DefaultCell.Padding = 3
            pdfTable.WidthPercentage = 85
            pdfTable.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
            pdfTable.DefaultCell.BorderWidth = 1

            Dim nameParagraph As New Paragraph("" & ProfNameLbl.Text & " / " & DateLbl.Text & " / " & TimeLbl.Text & "", New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12))
            nameParagraph.Alignment = iTextSharp.text.Element.ALIGN_LEFT

            ' Load the first image
            Dim imagePath1 As String = "plp_logo\plplogo.jpg" ' Replace with the actual path to your first image
            Dim img1 As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(imagePath1)
            img1.ScaleAbsoluteWidth(20.0F) ' Adjust the size as needed

            ' Load the second image
            Dim imagePath2 As String = "plp_logo\ccslogo.png" ' Replace with the actual path to your second image
            Dim img2 As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(imagePath2)
            img2.ScaleAbsoluteWidth(20.0F) ' Adjust the size as needed

            ' Create a PdfPTable with two cells
            Dim imageTable As New PdfPTable(7)
            imageTable.TotalWidth = 900.0F ' Set total width of the table
            imageTable.LockedWidth = True ' Lock the width
            imageTable.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
            imageTable.DefaultCell.Border = 0 ' No border for the cells
            imageTable.DefaultCell.PaddingTop = 50 ' No padding for the cells
            imageTable.DefaultCell.FixedHeight = 150.0F ' Set fixed height for the cells

            ' Add the first image to the first cell
            imageTable.AddCell(img1)

            Dim emptyCell1 As New PdfPCell()
            emptyCell1.Border = 0 ' No border for the em    pty cell
            imageTable.AddCell(emptyCell1)

            Dim PLPBold As New Paragraph("Pamantasan ng Lungsod ng Pasig" & vbCrLf, New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 20, iTextSharp.text.Font.BOLD)) With {.SpacingAfter = 10}
            Dim PLPAddress As New Paragraph("Alkalde Jose St. Kapasigan, Pasig City" & vbCrLf, New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14)) With {.SpacingAfter = 10}
            Dim CCS As New Paragraph(vbCrLf & "College of Computer Studies", New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14)) With {.SpacingAfter = 10}
            Dim space As New Chunk(" " & vbCrLf, New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8))

            Dim combinedText As New Phrase From {
                PLPBold,
                space,
                PLPAddress,
                space,
                CCS
            }

            Dim PLPTItle As New PdfPCell(combinedText) With {
                .Border = 0, ' No border for the paragraph cell
                .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                .PaddingTop = 70,
                .Colspan = 3
            }
            imageTable.AddCell(PLPTItle)

            Dim emptyCell As New PdfPCell With {
                .Border = 0
            }
            imageTable.AddCell(emptyCell)

            ' Add the second image to the second cell
            imageTable.AddCell(img2)

            ' Set Font Size
            Const FontSize As Integer = 14 ' Adjust the font size as needed

            Dim heading As Paragraph

            If ArchFilBySect.Text IsNot "" AndAlso ArchFilByYear.Text IsNot "" AndAlso ArchSearchBox.Text IsNot "" Then
                heading = New Paragraph("Online Registration System" & vbCrLf &
                            "Archived Students (Section: " & ArchFilBySect.Text &
                            ", Year: " & ArchFilByYear.Text &
                            ", Search: " & ArchSearchBox.Text & ")",
                            New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 20, iTextSharp.text.Font.BOLD))
            ElseIf ArchFilBySect.Text IsNot "" AndAlso ArchFilByYear.Text IsNot "" Then
                heading = New Paragraph("Online Registration System" & vbCrLf &
                            "Archived Students (Section: " & ArchFilBySect.Text &
                            ", Year: " & ArchFilByYear.Text & ")",
                            New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 20, iTextSharp.text.Font.BOLD))
            ElseIf ArchFilBySect.Text IsNot "" AndAlso ArchSearchBox.Text IsNot "" Then
                heading = New Paragraph("Online Registration System" & vbCrLf &
                            "Archived Students (Section: " & ArchFilBySect.Text &
                            ", Search: " & ArchSearchBox.Text & ")",
                            New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 20, iTextSharp.text.Font.BOLD))
            ElseIf ArchFilByYear.Text IsNot "" AndAlso ArchSearchBox.Text IsNot "" Then
                heading = New Paragraph("Online Registration System" & vbCrLf &
                            "Archived Students (Year: " & ArchFilByYear.Text &
                            ", Search: " & ArchSearchBox.Text & ")",
                            New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 20, iTextSharp.text.Font.BOLD))
            ElseIf ArchFilBySect.Text IsNot "" Then
                heading = New Paragraph("Online Registration System" & vbCrLf &
                            "Archived Students (Section: " & ArchFilBySect.Text & ")",
                            New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 20, iTextSharp.text.Font.BOLD))
            ElseIf ArchFilByYear.Text IsNot "" Then
                heading = New Paragraph("Online Registration System" & vbCrLf &
                            "Archived Students (Year: " & ArchFilByYear.Text & ")",
                            New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 20, iTextSharp.text.Font.BOLD))
            ElseIf ArchSearchBox.Text IsNot "" Then
                heading = New Paragraph("Online Registration System" & vbCrLf &
                            "Archived Students (Search: " & ArchSearchBox.Text & ")",
                            New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 20, iTextSharp.text.Font.BOLD))
            Else
                heading = New Paragraph("Online Registration System" & vbCrLf &
                            "Archived Students",
                            New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 20, iTextSharp.text.Font.BOLD))
            End If


            heading.Alignment = iTextSharp.text.Element.ALIGN_CENTER
            heading.SpacingBefore = 40
            pdfTable.SpacingBefore = 20

            ' Adding Header row
            For Each column As DataGridViewColumn In ArchDataGrid.Columns
                Dim cell As New PdfPCell(New Phrase(column.HeaderText, New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, FontSize))) With {
                    .BackgroundColor = New iTextSharp.text.BaseColor(76, 175, 80)
                }
                pdfTable.AddCell(cell)
            Next

            ' Adding DataRow
            Dim cellvalue As String = ""
            For Each row As DataGridViewRow In ArchDataGrid.Rows
                For Each cell As DataGridViewCell In row.Cells
                    cellvalue = cell.FormattedValue
                    pdfTable.AddCell(New Phrase(Convert.ToString(cellvalue), New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, FontSize)))
                Next
            Next

            Dim tableTitle As New Paragraph("Graduate Students", New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 20, iTextSharp.text.Font.BOLD)) With {
                .SpacingBefore = 40,
                .SpacingAfter = 20,
                .Alignment = iTextSharp.text.Element.ALIGN_CENTER
            }

            Dim pdfDoc As New Document(iTextSharp.text.PageSize.A2, 10.0F, 10.0F, 10.0F, 0.0F)
            Dim writer As PdfWriter = PdfWriter.GetInstance(pdfDoc, New FileStream(SaveFileDialog1.FileName + ".pdf", FileMode.Create))

            Dim eventHandler As New PageNumberEventHandler()
            writer.PageEvent = New PageNumberEventHandler()

            pdfDoc.Open()
            pdfDoc.Add(nameParagraph)
            pdfDoc.Add(imageTable)
            pdfDoc.Add(heading)
            pdfDoc.Add(tableTitle)
            pdfDoc.Add(pdfTable)
            pdfDoc.Close()

            MessageBox.Show("Successfully Saved!", "Online Registration System", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ShellExecute(IntPtr.Zero, "open", SaveFileDialog1.FileName + ".pdf", Nothing, Nothing, 1)
        End If
    End Sub

    Private Declare Function ShellExecute Lib "shell32.dll" Alias "ShellExecuteA" (
ByVal hwnd As IntPtr,
ByVal lpOperation As String,
ByVal lpFile As String,
ByVal lpParameters As String,
ByVal lpDirectory As String,
ByVal nShowCmd As Integer
) As IntPtr

    Public Class PageNumberEventHandler
        Inherits PdfPageEventHelper

        Public Overrides Sub OnEndPage(writer As PdfWriter, document As Document)
            MyBase.OnEndPage(writer, document)

            Dim pageNumber As Integer = writer.PageNumber
            Dim contentByte As PdfContentByte = writer.DirectContent
            Dim font As BaseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED)
            Dim fontSize As Single = 12
            Dim color As BaseColor = BaseColor.BLACK
            Dim alignment As Integer = iTextSharp.text.Element.ALIGN_RIGHT
            Dim offsetX As Single = 40
            Dim offsetY As Single = 30

            contentByte.BeginText()
            contentByte.SetFontAndSize(font, fontSize)
            contentByte.SetColorFill(color)
            contentByte.ShowTextAligned(alignment, "Page " & pageNumber, document.PageSize.Width - offsetX, offsetY, 0)
            contentByte.EndText()
        End Sub
    End Class

    Private Sub ArchLoadData()
        Dim DtArchive As New DataTable
        Dim MySqlString As String = "server=localhost;username=root;password=;database=plpportal_db"

        Dim FilteredSection As String = If(ArchFilBySect.SelectedItem IsNot Nothing, ArchFilBySect.SelectedItem.ToString(), "")
        Dim FilteredYear As String = If(ArchFilByYear.SelectedItem IsNot Nothing, ArchFilByYear.SelectedItem.ToString(), "")
        Dim SearchBox As String = If(ArchSearchBox.Text <> "", ArchSearchBox.Text, "")
        SearchBox = "%" & SearchBox & "%"
        FilteredSection = "%" & FilteredSection & "%"

        ' Initialize the query
        Dim baseQuery As String = " SELECT studentnum as 'Student ID', last_name as 'Last Name', first_name as 'First Name', middle_initial as 'Middle Initial', suffix as Suffix, email as Email, section as Section, graduation_date as 'Graduation Date' FROM archive WHERE YEAR(graduation_date) = '" & Date.Today.Year & "'"

        ' Add filters dynamically
        If Not String.IsNullOrEmpty(FilteredSection) Then
            baseQuery &= " AND section like '" & FilteredSection & "'"
        End If

        If Not String.IsNullOrEmpty(FilteredYear) Then
            baseQuery &= " AND YEAR(graduation_date) = @year"
        End If

        If Not String.IsNullOrEmpty(SearchBox) Then
            baseQuery &= " AND section like @search"
        End If

        ' Clear previous data
        DtArchive.Clear()

        ' Execute the query
        Using con As New MySqlConnection(MySqlString)
            con.Open()
            Using cmd As New MySqlCommand(baseQuery, con)
                cmd.Parameters.Clear()
                ' Add parameters dynamically
                If Not String.IsNullOrEmpty(FilteredSection) Then
                    cmd.Parameters.AddWithValue("@section", FilteredSection)
                End If

                If Not String.IsNullOrEmpty(FilteredYear) Then
                    cmd.Parameters.AddWithValue("@year", FilteredYear)
                End If

                If Not String.IsNullOrEmpty(SearchBox) Then
                    cmd.Parameters.AddWithValue("@search", SearchBox)
                End If
                ' Load data
                cmd.ExecuteNonQuery()
                Dim adapter As New MySqlDataAdapter(cmd)
                adapter.Fill(DtArchive)
            End Using

        End Using

        ' Populate the ListView
        ArchDataGrid.DataSource = DtArchive
    End Sub

    Private Sub ArchLoadFilter()
        ArchFilByYear.Items.Clear()
        ArchFilBySect.Items.Clear()
        ArchFilByYear.Items.Add("")
        ArchFilBySect.Items.Add("")
        conn.Open()
        Dim ycmd As New MySqlCommand("SELECT DISTINCT YEAR(graduation_date) AS Year FROM archive", conn)
        Dim yreader = ycmd.ExecuteReader()
        While yreader.Read
            ArchFilByYear.Items.Add(yreader("Year").ToString())
        End While
        conn.Close()
        conn.Open()
        Dim scmd As New MySqlCommand("SELECT section FROM sections", conn)
        Dim sreader = scmd.ExecuteReader()
        While sreader.Read
            Dim ssection = sreader.GetString("section")
            ArchFilBySect.Items.Add(ssection)
        End While
        conn.Close()
    End Sub



    ' SIGN OUT TAB

    Private LastVisitedTab As Integer

    Private Sub SignOutCancel_Click(sender As Object, e As EventArgs) Handles SignOutCancel.Click
        If LastVisitedTab = 0 Then
            MaterialTabControl1.SelectedTab = DashboardTab
        ElseIf LastVisitedTab = 1 Then
            MaterialTabControl1.SelectedTab = ProfessorsTab
        ElseIf LastVisitedTab = 2 Then
            MaterialTabControl1.SelectedTab = StudentsTab
        ElseIf LastVisitedTab = 3 Then
            MaterialTabControl1.SelectedTab = ReportsTab
        ElseIf LastVisitedTab = 4 Then
            MaterialTabControl1.SelectedTab = ReasonsTab
        ElseIf LastVisitedTab = 5 Then
            MaterialTabControl1.SelectedTab = SectionsTab
        ElseIf LastVisitedTab = 6 Then
            MaterialTabControl1.SelectedTab = ArchiveTab
        End If
    End Sub

    Private Sub MaterialTabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MaterialTabControl1.SelectedIndexChanged
        If MaterialTabControl1.SelectedIndex = 0 Then
            LastVisitedTab = 0
        ElseIf MaterialTabControl1.SelectedIndex = 1 Then
            LastVisitedTab = 1
        ElseIf MaterialTabControl1.SelectedIndex = 2 Then
            LastVisitedTab = 2
        ElseIf MaterialTabControl1.SelectedIndex = 3 Then
            LastVisitedTab = 3
        ElseIf MaterialTabControl1.SelectedIndex = 4 Then
            LastVisitedTab = 4
        ElseIf MaterialTabControl1.SelectedIndex = 5 Then
            LastVisitedTab = 5
        ElseIf MaterialTabControl1.SelectedIndex = 6 Then
            LastVisitedTab = 6
        End If
    End Sub

    Private Sub SignOutYes_Click(sender As Object, e As EventArgs) Handles SignOutYes.Click
        EntrancePage.Show()
        Timer1.Stop()
        Hide()
    End Sub

    ' REPORTS TAB

    Private Sub RepLoadData()
        conn.Open()

        Dim cmd As New MySqlCommand("SELECT report_ID as 'Report ID', studentnum as 'Student ID', last_name as 'Last Name', first_name as 'First Name', middle_initial as 'Middle Initial', suffix as Suffix, section as Section, teacher as Professor, consultation_date as 'Consultation Date', reason as Reason, message as Message, time_in as 'Time In', time_out as 'Time Out' FROM reports", conn)
        cmd.ExecuteNonQuery()
        conn.Close()

        Dim da As New MySqlDataAdapter(cmd)
        Dim dt As New DataTable

        da.Fill(dt)
        RepDataGrid.DataSource = dt
    End Sub

    Private Sub RepSearchBox_TextChanged(sender As Object, e As EventArgs) Handles RepSearchBox.TextChanged
        RepSortBy.SelectedIndex = -1
        RepProf1Box.SelectedIndex = -1
        RepYearBox.SelectedIndex = -1
        RepProf2Box.SelectedIndex = -1
        RepFromMonthBox.SelectedIndex = -1
        RepToMonthBox.SelectedIndex = -1

        RepFromDayBox.SelectedIndex = -1
        RepToDayBox.SelectedIndex = -1

        RepProf1Box.Visible = False
        RepYearBox.Visible = False

        RepFromMonthBox.Visible = False
        RepMonthToLbl.Visible = False
        RepToMonthBox.Visible = False

        RepFromDayBox.Visible = False
        RepDayToLbl.Visible = False
        RepDayToLbl.Visible = False

        RepSortBy.Visible = False

        If RepSearchBox.Text = "" Then
            RepLoadData()
        Else
            conn.Open()
            Dim cmd As New MySqlCommand("SELECT report_ID as 'Report ID', studentnum as 'Student ID', last_name as 'Last Name', first_name as 'First Name', middle_initial as 'Middle Initial', suffix as Suffix, section as Section, teacher as Professor, consultation_date as 'Consultation Date', reason as Reason, message as Message, time_in as 'Time In', time_out as 'Time Out' FROM reports WHERE CONCAT(report_ID, studentnum, last_name, first_name, middle_initial, suffix, section, teacher, consultation_date, reason, message, time_in, time_out) like '%" & RepSearchBox.Text & "%'", conn)

            Dim adapter As New MySqlDataAdapter(cmd)
            Dim table As New DataTable()

            adapter.Fill(table)

            cmd.ExecuteNonQuery()

            ArchDataGrid.DataSource = table
            conn.Close()
        End If
        ReportsChart(YearlyRepPanel, RepDataGrid)
    End Sub

    Dim sortVal As String
    Dim profActive As Boolean
    Dim minNum As Integer = 0
    Dim maxNum As Integer = 10

    Private Sub RepSortBy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RepSortBy.SelectedIndexChanged
        'RepSortBy.SelectedIndex = -1
        RepProf1Box.SelectedIndex = -1
        RepYearBox.SelectedIndex = -1
        RepFromMonthBox.SelectedIndex = -1
        RepToMonthBox.SelectedIndex = -1

        RepFromDayBox.SelectedIndex = -1
        RepToDayBox.SelectedIndex = -1

        'RepSortBy.Visible = False
        'RepSortByLbl.Visible = false

        ' Labels

        RepProf1Lbl.Visible = False
        RepMonthLbl.Visible = False
        RepDayLbl.Visible = False
        RepYearLbl.Visible = False
        RepProf2Lbl.Visible = False

        ' Labels end of

        RepProf1Box.Visible = False
        RepYearBox.Visible = False

        RepFromMonthBox.Visible = False
        RepMonthToLbl.Visible = False
        RepToMonthBox.Visible = False

        RepFromDayBox.Visible = False
        RepDayToLbl.Visible = False
        RepDayToLbl.Visible = False

        'RepSortBy.Visible = False

        If RepSortBy.SelectedIndex = 3 Then
            RepProf1Lbl.Visible = True
            RepProf1Box.Visible = True
            profActive = True
        Else
            RepProf1Lbl.Visible = False
            RepProf1Box.Visible = False
            profActive = False
            RepProf1Box.SelectedIndex = -1
            RepLoadData()
        End If

        If RepSortBy.SelectedIndex = 4 Then
            RepYearBox.Visible = True
            RepYearLbl.Visible = True
        Else
            RepMonthLbl.Visible = False
            RepDayLbl.Visible = False
            RepFromMonthBox.Visible = False
            RepToMonthBox.Visible = False
            RepFromMonthBox.SelectedIndex = -1
            RepToMonthBox.SelectedIndex = -1
            RepYearLbl.Visible = False
            RepYearBox.Visible = False
            RepYearBox.SelectedIndex = -1
            RepLoadData()
        End If

        If RepDataGrid.CurrentCell IsNot Nothing Then
            If RepSortBy.SelectedIndex = 0 Then
                RepDataGrid.Sort(RepDataGrid.Columns(1), ListSortDirection.Ascending)
                sortVal = "Student Num"
            ElseIf RepSortBy.SelectedIndex = 1 Then
                RepDataGrid.Sort(RepDataGrid.Columns(2), ListSortDirection.Ascending)
                sortVal = "Student Last Name"
            ElseIf RepSortBy.SelectedIndex = 2 Then
                RepDataGrid.Sort(RepDataGrid.Columns(6), ListSortDirection.Ascending)
                sortVal = "Section"
            ElseIf RepSortBy.SelectedIndex = 3 Then
                RepDataGrid.Sort(RepDataGrid.Columns(7), ListSortDirection.Ascending)
                sortVal = "Professor Name"
            ElseIf RepSortBy.SelectedIndex = 4 Then
                RepDataGrid.Sort(RepDataGrid.Columns(8), ListSortDirection.Ascending)
                sortVal = "Date"
            End If
        End If

        minNum = 0
        maxNum = 10
        ReportsChart(YearlyRepPanel, RepDataGrid)
    End Sub

    Private Sub RepProf1BoxLoadData()
        conn.Open()
        Dim cmd As New MySqlCommand("SELECT name FROM profinfo", conn)
        Dim reader = cmd.ExecuteReader()
        While reader.Read
            Dim prof = reader.GetString("name")
            RepProf1Box.Items.Add(prof)
        End While
        conn.Close()
    End Sub

    Private Sub RepProf2BoxLoadData()
        conn.Open()
        Dim pcmd As New MySqlCommand("SELECT name FROM profinfo", conn)
        Dim preader = pcmd.ExecuteReader()
        While preader.Read
            Dim prof = preader.GetString("name")
            RepProf2Box.Items.Add(prof)
        End While
        conn.Close()
    End Sub

    Private Sub RepYearBoxLoadData()
        conn.Open()
        Dim ycmd As New MySqlCommand("SELECT DISTINCT YEAR(consultation_date) AS Year FROM reports", conn)
        Dim yreader = ycmd.ExecuteReader()
        While yreader.Read
            RepYearBox.Items.Add(yreader("Year").ToString())
        End While
        conn.Close()
    End Sub



    Private Sub RepProf1Box_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RepProf1Box.SelectedIndexChanged
        conn.Open()

        Dim cmd As New MySqlCommand("SELECT report_ID as 'Report ID', studentnum as 'Student ID', last_name as 'Last Name', first_name as 'First Name', middle_initial as 'Middle Initial', suffix as Suffix, section as Section, teacher as Professor, consultation_date as 'Consultation Date', reason as Reason, message as Message, time_in as 'Time In', time_out as 'Time Out' FROM reports where teacher = '" & RepProf1Box.Text & "'", conn)
        cmd.ExecuteNonQuery()
        conn.Close()

        Dim adapter As New MySqlDataAdapter(cmd)
        Dim table As New DataTable()

        adapter.Fill(table)
        RepDataGrid.DataSource = table
        minNum = 0
        maxNum = 10
        ReportsChart(YearlyRepPanel, RepDataGrid)
    End Sub

    Private Sub RepYearBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RepYearBox.SelectedIndexChanged
        RepFromMonthBox.SelectedIndex = -1
        RepToMonthBox.SelectedIndex = -1
        RepFromDayBox.SelectedIndex = -1
        RepToDayBox.SelectedIndex = -1
        RepProf2Box.SelectedIndex = -1

        If RepSortBy.SelectedIndex = -1 Then
            ' Labels

            RepProf1Lbl.Visible = False
            RepMonthLbl.Visible = False
            RepDayLbl.Visible = False
            RepProf2Lbl.Visible = False

            ' Labels end of

            RepProf1Box.Visible = False

            RepFromMonthBox.Visible = False
            RepMonthToLbl.Visible = False
            RepToMonthBox.Visible = False

            RepFromDayBox.Visible = False
            RepDayToLbl.Visible = False
            RepDayToLbl.Visible = False

            Return
        End If

        If RepYearBox.SelectedIndex <> -1 Then
            RepMonthLbl.Visible = True
            RepDayLbl.Visible = True
            RepFromMonthBox.Visible = True
            RepToMonthBox.Visible = True
            RepFromDayBox.Visible = True
            RepToDayBox.Visible = True
            RepDayToLbl.Visible = True
            RepMonthToLbl.Visible = True
            RepProf2Box.Visible = True
            RepProf2Lbl.Visible = True
            conn.Open()

            Dim cmd As New MySqlCommand("SELECT report_ID as 'Report ID', studentnum as 'Student ID', last_name as 'Last Name', first_name as 'First Name', middle_initial as 'Middle Initial', suffix as Suffix, section as Section, teacher as Professor, consultation_date as 'Consultation Date', reason as Reason, message as Message, time_in as 'Time In', time_out as 'Time Out' FROM reports WHERE YEAR(consultation_date) = " & RepYearBox.Text & "", conn)
            cmd.ExecuteNonQuery()

            Dim adapter As New MySqlDataAdapter(cmd)
            Dim table As New DataTable

            adapter.Fill(table)

            RepDataGrid.DataSource = table
            conn.Close()
        End If
        minNum = 0
        maxNum = 10
        ReportsChart(YearlyRepPanel, RepDataGrid)
    End Sub

    Private Sub MonthBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RepFromMonthBox.SelectedIndexChanged, RepToMonthBox.SelectedIndexChanged
        RepProf2Box.SelectedIndex = -1

        If RepYearBox.SelectedIndex = -1 Then
            ' Labels

            RepProf1Lbl.Visible = False
            RepMonthLbl.Visible = False
            RepDayLbl.Visible = False
            RepYearLbl.Visible = False
            RepProf2Lbl.Visible = False

            ' Labels end of

            RepProf1Box.Visible = False
            RepYearBox.Visible = False

            RepFromMonthBox.Visible = False
            RepMonthToLbl.Visible = False
            RepToMonthBox.Visible = False

            RepFromDayBox.Visible = False
            RepDayToLbl.Visible = False
            RepDayToLbl.Visible = False

            Return
        End If

        If RepFromMonthBox.SelectedIndex <> -1 AndAlso RepToMonthBox.SelectedIndex <> -1 AndAlso RepYearBox.Text IsNot "" Then
            Dim monthNames As New Dictionary(Of String, Integer) From {
            {"January", 1}, {"February", 2}, {"March", 3}, {"April", 4},
            {"May", 5}, {"June", 6}, {"July", 7}, {"August", 8},
            {"September", 9}, {"October", 10}, {"November", 11}, {"December", 12}
        }

            Dim selectedFromMonth = RepFromMonthBox.Text
            Dim selectedToMonth = RepToMonthBox.Text
            Dim selectedYear = RepYearBox.Text

            Dim fromMonthNumber = monthNames(selectedFromMonth)
            Dim toMonthNumber = monthNames(selectedToMonth)

            ' Calculate the start and end dates
            Dim startDate = selectedYear & "-" & fromMonthNumber.ToString("00") & "-01"
            Dim endDate As String

            If toMonthNumber = 12 Then
                endDate = selectedYear & "-" & toMonthNumber.ToString("00") & "-31"
            Else
                endDate = selectedYear & "-" & (toMonthNumber + 1).ToString("00") & "-01"
            End If
            If RepFromMonthBox.SelectedIndex <> -1 AndAlso RepProf2Box.SelectedIndex <> -1 Then
                DayHelperSub(startDate, endDate)
            ElseIf RepFromMonthBox.SelectedIndex <> -1 AndAlso RepProf2Box.SelectedIndex = -1 Then
                DayNoProfHelperSub(startDate, endDate)
            Else
                conn.Open()
                Dim cmd As New MySqlCommand("SELECT report_ID as 'Report ID', studentnum as 'Student ID', last_name as 'Last Name', first_name as 'First Name', middle_initial as 'Middle Initial', suffix as Suffix, section as Section, teacher as Professor, consultation_date as 'Consultation Date', reason as Reason, message as Message, time_in as 'Time In', time_out as 'Time Out' FROM reports WHERE consultation_date >= @startDate AND consultation_date <= @endDate", conn)
                cmd.Parameters.AddWithValue("@startDate", startDate)
                cmd.Parameters.AddWithValue("@endDate", endDate)

                Dim adapter As New MySqlDataAdapter(cmd)
                Dim table As New DataTable
                adapter.Fill(table)
                RepDataGrid.DataSource = table
                conn.Close()
            End If
        End If
        minNum = 0
        maxNum = 10
        ReportsChart(YearlyRepPanel, RepDataGrid)
    End Sub

    Private Sub DayComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RepFromDayBox.SelectedIndexChanged, RepToDayBox.SelectedIndexChanged
        RepProf2Box.SelectedIndex = -1

        If RepYearBox.SelectedIndex = -1 Then
            ' Labels

            RepProf1Lbl.Visible = False
            RepMonthLbl.Visible = False
            RepDayLbl.Visible = False
            RepYearLbl.Visible = False
            RepProf2Lbl.Visible = False

            ' Labels end of

            RepProf1Box.Visible = False
            RepYearBox.Visible = False

            RepFromMonthBox.Visible = False
            RepMonthToLbl.Visible = False
            RepToMonthBox.Visible = False

            RepFromDayBox.Visible = False
            RepDayToLbl.Visible = False
            RepDayToLbl.Visible = False

            Return
        End If

        If RepFromDayBox.SelectedIndex <> -1 AndAlso RepToDayBox.SelectedIndex <> -1 AndAlso RepProf2Box.SelectedIndex = -1 Then
            Dim selectedYear = RepYearBox.Text
            Dim selectedFromDay As Integer = Convert.ToInt32(RepFromDayBox.Text)
            Dim selectedToDay As Integer = Convert.ToInt32(RepToDayBox.Text)

            If selectedFromDay > selectedToDay Then
                MessageBox.Show("Start day cannot be greater than end day.")
                Return
            End If

            Dim selectedMonth = RepFromMonthBox.Text
            Dim monthNames As New Dictionary(Of String, Integer) From {
            {"January", 1}, {"February", 2}, {"March", 3}, {"April", 4},
            {"May", 5}, {"June", 6}, {"July", 7}, {"August", 8},
            {"September", 9}, {"October", 10}, {"November", 11}, {"December", 12}
        }

            Dim selectedMonthNumber As Integer
            If RepFromMonthBox.SelectedIndex = -1 Then
                selectedMonthNumber = 1
            Else
                selectedMonthNumber = monthNames(selectedMonth)
            End If

            Dim startDate As String = selectedYear & "-" & selectedMonthNumber.ToString("00") & "-" & selectedFromDay.ToString("00")
            Dim endDate As String = selectedYear & "-" & selectedMonthNumber.ToString("00") & "-" & selectedToDay.ToString("00")

            DayNoProfHelperSub(startDate, endDate)

        ElseIf RepFromDayBox.SelectedIndex <> -1 AndAlso RepToDayBox.SelectedIndex <> -1 AndAlso RepProf2Box.SelectedIndex <> -1 Then
            Dim selectedYear = RepYearBox.Text
            Dim selectedFromDay As Integer = Convert.ToInt32(RepFromDayBox.Text)
            Dim selectedToDay As Integer = Convert.ToInt32(RepToDayBox.Text)

            If selectedFromDay > selectedToDay Then
                MessageBox.Show("Start day cannot be greater than end day.")
                Return
            End If

            Dim selectedMonth = RepFromMonthBox.Text
            Dim monthNames As New Dictionary(Of String, Integer) From {
            {"Jan", 1}, {"Feb", 2}, {"Mar", 3}, {"Apr", 4},
            {"May", 5}, {"Jun", 6}, {"Jul", 7}, {"Aug", 8},
            {"Sep", 9}, {"Oct", 10}, {"Nov", 11}, {"Dec", 12}
        }

            Dim selectedMonthNumber As Integer
            If RepFromMonthBox.SelectedIndex = -1 Then
                selectedMonthNumber = 1
            Else
                selectedMonthNumber = monthNames(selectedMonth)
            End If

            Dim startDate As String = selectedYear & "-" & selectedMonthNumber.ToString("00") & "-" & selectedFromDay.ToString("00")
            Dim endDate As String = selectedYear & "-" & selectedMonthNumber.ToString("00") & "-" & selectedToDay.ToString("00")

            DayHelperSub(startDate, endDate)
        End If

        minNum = 0
        maxNum = 10
        ReportsChart(YearlyRepPanel, RepDataGrid)
    End Sub

    Sub DayHelperSub(startDate As Date, endDate As Date)
        startDate = startDate.ToString("yyyy-MM-dd")
        endDate = endDate.ToString("yyyy-MM-dd")
        conn.Open()
        Dim cmd As New MySqlCommand("SELECT report_ID as 'Report ID', studentnum as 'Student ID', last_name as 'Last Name', first_name as 'First Name', middle_initial as 'Middle Initial', suffix as Suffix, section as Section, teacher as Professor, consultation_date as 'Consultation Date', reason as Reason, message as Message, time_in as 'Time In', time_out as 'Time Out' FROM reports WHERE teacher = @teacher AND consultation_date >= @startDate AND consultation_date <= @endDate", conn)
        cmd.Parameters.AddWithValue("@teacher", RepProf2Box.Text)
        cmd.Parameters.AddWithValue("@startDate", startDate)
        cmd.Parameters.AddWithValue("@endDate", endDate)

        Dim adapter As New MySqlDataAdapter(cmd)
        Dim table As New DataTable()
        adapter.Fill(table)
        RepDataGrid.DataSource = table
        conn.Close()
    End Sub

    Sub DayNoProfHelperSub(startDate As Date, endDate As Date)
        startDate = startDate.ToString("yyyy-MM-dd")
        endDate = endDate.ToString("yyyy-MM-dd")
        conn.Open()
        Dim cmd As New MySqlCommand("SELECT report_ID as 'Report ID', studentnum as 'Student ID', last_name as 'Last Name', first_name as 'First Name', middle_initial as 'Middle Initial', suffix as Suffix, section as Section, teacher as Professor, consultation_date as 'Consultation Date', reason as Reason, message as Message, time_in as 'Time In', time_out as 'Time Out' FROM reports WHERE consultation_date >= @startDate AND consultation_date <= @endDate", conn)
        cmd.Parameters.AddWithValue("@startDate", startDate)
        cmd.Parameters.AddWithValue("@endDate", endDate)

        Dim adapter As New MySqlDataAdapter(cmd)
        Dim table As New DataTable
        adapter.Fill(table)
        RepDataGrid.DataSource = table
        conn.Close()
    End Sub

    Private Sub ArchPrintBtn_Click(sender As Object, e As EventArgs) Handles ArchPrintBtn.Click
        SaveFileDialog1.ShowDialog()
        If SaveFileDialog1.FileName = "" Then
            MsgBox("Enter filename to create PDF!", vbExclamation)
        Else
            Dim pdfTable As New PdfPTable(RepDataGrid.ColumnCount)
            pdfTable.DefaultCell.Padding = 3
            pdfTable.WidthPercentage = 85
            pdfTable.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
            pdfTable.DefaultCell.BorderWidth = 1

            Dim nameParagraph As New Paragraph("" & ProfNameLbl.Text & " / " & DateLbl.Text & " / " & TimeLbl.Text & "", New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12))
            nameParagraph.Alignment = iTextSharp.text.Element.ALIGN_LEFT

            ' Load the first image
            Dim imagePath1 As String = "plp_logo\plplogo.jpg" ' Replace with the actual path to your first image
            Dim img1 As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(imagePath1)
            img1.ScaleAbsoluteWidth(20.0F) ' Adjust the size as needed

            ' Load the second image
            Dim imagePath2 As String = "plp_logo\ccslogo.png" ' Replace with the actual path to your second image
            Dim img2 As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(imagePath2)
            img2.ScaleAbsoluteWidth(20.0F) ' Adjust the size as needed

            ' Create a PdfPTable with two cells
            Dim imageTable As New PdfPTable(7)
            imageTable.TotalWidth = 900.0F ' Set total width of the table
            imageTable.LockedWidth = True ' Lock the width
            imageTable.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
            imageTable.DefaultCell.Border = 0 ' No border for the cells
            imageTable.DefaultCell.PaddingTop = 50 ' No padding for the cells
            imageTable.DefaultCell.FixedHeight = 150.0F ' Set fixed height for the cells

            ' Add the first image to the first cell
            imageTable.AddCell(img1)

            Dim emptyCell1 As New PdfPCell()
            emptyCell1.Border = 0 ' No border for the em    pty cell
            imageTable.AddCell(emptyCell1)

            Dim PLPBold As New Paragraph("Pamantasan ng Lungsod ng Pasig" & vbCrLf, New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 20, iTextSharp.text.Font.BOLD)) With {.SpacingAfter = 10}
            Dim PLPAddress As New Paragraph("Alkalde Jose St. Kapasigan, Pasig City" & vbCrLf, New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14)) With {.SpacingAfter = 10}
            Dim CCS As New Paragraph(vbCrLf & "College of Computer Studies", New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14)) With {.SpacingAfter = 10}
            Dim space As New Chunk(" " & vbCrLf, New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8))

            Dim combinedText As New Phrase From {
                PLPBold,
                space,
                PLPAddress,
                space,
                CCS
            }

            Dim PLPTItle As New PdfPCell(combinedText) With {
                .Border = 0, ' No border for the paragraph cell
                .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                .PaddingTop = 70,
                .Colspan = 3
            }
            imageTable.AddCell(PLPTItle)

            Dim emptyCell As New PdfPCell With {
                .Border = 0
            }
            imageTable.AddCell(emptyCell)

            ' Add the second image to the second cell
            imageTable.AddCell(img2)

            ' Set Font Size
            Const FontSize As Integer = 14 ' Adjust the font size as needed

            YearlyRepPanel.Enabled = True
            Dim chartTable As New PdfPTable(1) With {
                .HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                .SpacingBefore = 40,
                .SpacingAfter = 20
            }

            'Dim chartsImage As Image = ConvertPanelToITextSharpImage(DailyReportChartPanel)
            Dim chartsImage As iTextSharp.text.Image = ConvertPanelToITextSharpImage(YearlyRepPanel)
            chartTable.AddCell(chartsImage)

            Dim heading As Paragraph

            If RepProf1Box.Text IsNot "" Then
                heading = New Paragraph("Online Registration System" & vbCrLf & "Reports by Professor " & RepProf1Box.Text & "", New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 20, iTextSharp.text.Font.BOLD))
            ElseIf RepSortBy.Text = "Date" And RepYearBox.Text IsNot "" And RepFromMonthBox.Text = "" And RepFromDayBox.Text IsNot "" And RepToDayBox.Text IsNot "" Then
                heading = New Paragraph("Online Registration System" & vbCrLf & "Reports from " & RepFromDayBox.Text & " to " & RepToDayBox.Text & " of " & RepYearBox.Text & "", New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 20, iTextSharp.text.Font.BOLD))
            ElseIf RepSortBy.Text = "Date" And RepYearBox.Text IsNot "" And RepFromMonthBox.Text IsNot "" And RepFromDayBox.Text IsNot "" And RepToDayBox.Text IsNot "" Then
                heading = New Paragraph("Online Registration System" & vbCrLf & "Reports from " & RepFromMonthBox.Text & " " & RepFromDayBox.Text & " to " & RepToMonthBox.Text & " " & RepToDayBox.Text & " of Year " & RepYearBox.Text & "", New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 20, iTextSharp.text.Font.BOLD))
            ElseIf RepSortBy.Text = "Date" And RepYearBox.Text IsNot "" And RepFromMonthBox.Text IsNot "" And RepFromDayBox.Text IsNot "" And RepProf2Box.Text IsNot "" Then
                heading = New Paragraph("Online Registration System" & vbCrLf & "Reports by Professor " & RepProf2Box.Text & " Year " & RepYearBox.Text & " of " & RepFromMonthBox.Text & " " & RepFromDayBox.Text & "", New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 20, iTextSharp.text.Font.BOLD))
            ElseIf RepSortBy.Text = "Date" And RepYearBox.Text IsNot "" And RepFromMonthBox.Text = "" And RepFromDayBox.Text IsNot "" Then
                heading = New Paragraph("Online Registration System" & vbCrLf & "Reports for " & RepFromDayBox.Text & " of Year " & RepYearBox.Text & "", New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 20, iTextSharp.text.Font.BOLD))
            ElseIf RepSortBy.Text = "Date" And RepYearBox.Text IsNot "" And RepFromMonthBox.Text IsNot "" And RepFromDayBox.Text IsNot "" Then
                heading = New Paragraph("Online Registration System" & vbCrLf & "Reports by " & RepFromMonthBox.Text & " " & RepFromDayBox.Text & " " & RepYearBox.Text & "", New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 20, iTextSharp.text.Font.BOLD))
            Else
                heading = New Paragraph("Online Registration System" & vbCrLf & "Reports sorted by " & sortVal & "", New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 20, iTextSharp.text.Font.BOLD))
            End If

            heading.Alignment = iTextSharp.text.Element.ALIGN_CENTER
            heading.SpacingBefore = 40
            pdfTable.SpacingBefore = 20

            ' Adding Header row
            For Each column As DataGridViewColumn In RepDataGrid.Columns
                Dim cell As New PdfPCell(New Phrase(column.HeaderText, New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, FontSize))) With {
                    .BackgroundColor = New iTextSharp.text.BaseColor(76, 175, 80)
                }
                pdfTable.AddCell(cell)
            Next

            ' Adding DataRow
            Dim cellvalue As String = ""
            For Each row As DataGridViewRow In RepDataGrid.Rows
                For Each cell As DataGridViewCell In row.Cells
                    cellvalue = cell.FormattedValue
                    pdfTable.AddCell(New Phrase(Convert.ToString(cellvalue), New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, FontSize)))
                Next
            Next

            Dim tableTitle As New Paragraph("Data Table", New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 20, iTextSharp.text.Font.BOLD)) With {
                .SpacingBefore = 40,
                .SpacingAfter = 20,
                .Alignment = iTextSharp.text.Element.ALIGN_CENTER
            }

            Dim pdfDoc As New Document(iTextSharp.text.PageSize.A2, 10.0F, 10.0F, 10.0F, 0.0F)
            Dim writer As PdfWriter = PdfWriter.GetInstance(pdfDoc, New FileStream(SaveFileDialog1.FileName + ".pdf", FileMode.Create))

            Dim eventHandler As New PageNumberEventHandler()
            writer.PageEvent = New PageNumberEventHandler()

            pdfDoc.Open()
            pdfDoc.Add(nameParagraph)
            pdfDoc.Add(imageTable)
            pdfDoc.Add(heading)
            pdfDoc.Add(chartTable)
            pdfDoc.Add(tableTitle)
            pdfDoc.Add(pdfTable)
            pdfDoc.Close()

            MessageBox.Show("Successfully Saved!", "Online Registration System", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ShellExecute(IntPtr.Zero, "open", SaveFileDialog1.FileName + ".pdf", Nothing, Nothing, 1)
        End If
    End Sub

    Private Sub RepProf2Box_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RepProf2Box.SelectedIndexChanged
        Try
            If RepYearBox.Text IsNot "" And RepFromMonthBox.Text = "" Then
                conn.Open()
                Dim cmd As New MySqlCommand("SELECT report_ID as 'Report ID', studentnum as 'Student ID', last_name as 'Last Name', first_name as 'First Name', middle_initial as 'Middle Initial', suffix as Suffix, section as Section, teacher as Professor, consultation_date as 'Consultation Date', reason as Reason, message as Message, time_in as 'Time In', time_out as 'Time Out' FROM reports WHERE teacher = @teacher AND YEAR(consultation_date) = @year", conn)
                cmd.Parameters.AddWithValue("@teacher", RepProf2Box.Text)
                cmd.Parameters.AddWithValue("@year", RepYearBox.Text)
                cmd.ExecuteNonQuery()

                Dim adapter As New MySqlDataAdapter(cmd)
                Dim table As New DataTable()
                adapter.Fill(table)
                RepDataGrid.DataSource = table
                conn.Close()
            Else
                Dim monthNames As New Dictionary(Of String, Integer) From {
                    {"Jan", 1}, {"Feb", 2}, {"Mar", 3}, {"Apr", 4},
                    {"May", 5}, {"Jun", 6}, {"Jul", 7}, {"Aug", 8},
                    {"Sep", 9}, {"Oct", 10}, {"Nov", 11}, {"Dec", 12}
                }

                Dim selectedFromMonth As String = RepFromMonthBox.Text
                Dim selectedToMonth As String = RepToMonthBox.Text
                Dim selectedYear As String = RepYearBox.Text

                Dim fromMonthNumber As Integer = monthNames(selectedFromMonth)
                Dim toMonthNumber As Integer
                If RepToMonthBox.SelectedIndex = -1 Then
                    toMonthNumber = 12
                Else
                    toMonthNumber = monthNames(selectedToMonth)
                End If

                Dim selectedFromDay As Integer = If(RepFromDayBox.SelectedIndex = -1, 1, Convert.ToInt32(RepFromDayBox.Text))
                Dim selectedToDay As Integer = If(RepToDayBox.SelectedIndex = -1, 31, Convert.ToInt32(RepToDayBox.Text))

                Dim startDate As String = selectedYear & "-" & fromMonthNumber.ToString("00") & "-" & selectedFromDay.ToString("00")
                Dim endDate As String = selectedYear & "-" & toMonthNumber.ToString("00") & "-" & selectedToDay.ToString("00")

                If RepFromMonthBox.SelectedIndex <> -1 AndAlso RepToMonthBox.SelectedIndex <> -1 Then
                    If fromMonthNumber = toMonthNumber Then
                        endDate = selectedYear & "-" & fromMonthNumber.ToString("00") & "-" & selectedToDay.ToString("00")
                        If RepProf2Box.SelectedIndex <> -1 Then
                            DayHelperSub(startDate, endDate)
                        Else
                            DayNoProfHelperSub(startDate, endDate)
                        End If
                    Else
                        If toMonthNumber = 12 Then
                            endDate = selectedYear & "-" & toMonthNumber.ToString("00") & "-31"
                        Else
                            endDate = selectedYear & "-" & toMonthNumber.ToString("00") & "-01"
                        End If

                        If RepProf2Box.SelectedIndex <> -1 Then
                            DayHelperSub(startDate, endDate)
                        Else
                            DayNoProfHelperSub(startDate, endDate)
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        minNum = 0
        maxNum = 10
        ReportsChart(YearlyRepPanel, RepDataGrid)
    End Sub

    Private Sub StudUploadBtn_Click(sender As Object, e As EventArgs) Handles StudUploadBtn.Click
        Dim BulkForm As New BulkRegisterForm(ProfUser)
        BulkForm.Show()
    End Sub
End Class
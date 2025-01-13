Imports MySql.Data.MySqlClient
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO
Imports OxyPlot.WindowsForms
Imports System.Windows.Controls

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
                ProfClrBtn.PerformClick()
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
            ProfClrBtn.PerformClick()
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

    Private Sub StuLoadData()
        conn.Open()

        Dim cmd As New MySqlCommand("SELECT * FROM studentinfo", conn)
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
            Dim cmd As New MySqlCommand("SELECT * FROM studentinfo WHERE CONCAT(studentnum, last_name, first_name, middle_initial, suffix, email, section) like '%" & StudSearchStud.Text & "%'", conn)

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
        StudEmail.Text = ""
        StudSection.SelectedIndex = -1
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
            '    AdminArchive.ArchiveDataGrid.Refresh()
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

    Private Sub ReaLoadData()
        conn.Open()

        Dim cmd As New MySqlCommand("SELECT * FROM reasons", conn)
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
            Dim cmd As New MySqlCommand("SELECT * FROM reasons WHERE CONCAT(reason_ID, reason, special) like '%" & ReaSearchReason.Text & "%'", conn)

            Dim adapter As New MySqlDataAdapter(cmd)
            Dim table As New DataTable()

            adapter.Fill(table)

            cmd.ExecuteNonQuery()

            ReaDataGrid.DataSource = table
            conn.Close()
        End If
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
End Class
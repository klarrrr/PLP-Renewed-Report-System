<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StudentDashboard
    Inherits MaterialSkin.Controls.MaterialForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StudentDashboard))
        MaterialCard1 = New MaterialSkin.Controls.MaterialCard()
        NavCard = New MaterialSkin.Controls.MaterialCard()
        MaterialLabel15 = New MaterialSkin.Controls.MaterialLabel()
        PictureBox7 = New PictureBox()
        DateLbl = New MaterialSkin.Controls.MaterialLabel()
        TimeLbl = New MaterialSkin.Controls.MaterialLabel()
        SignOutBtn = New MaterialSkin.Controls.MaterialButton()
        SubmitBtn = New MaterialSkin.Controls.MaterialButton()
        MaterialLabel41 = New MaterialSkin.Controls.MaterialLabel()
        YearComboBox = New MaterialSkin.Controls.MaterialComboBox()
        ReasonComboBox = New MaterialSkin.Controls.MaterialComboBox()
        ProfComboBox = New MaterialSkin.Controls.MaterialComboBox()
        SearchProfBox = New MaterialSkin.Controls.MaterialTextBox()
        MaterialLabel6 = New MaterialSkin.Controls.MaterialLabel()
        CommentsBox = New MaterialSkin.Controls.MaterialMultiLineTextBox2()
        MaterialCard7 = New MaterialSkin.Controls.MaterialCard()
        PictureBox3 = New PictureBox()
        MaterialLabel13 = New MaterialSkin.Controls.MaterialLabel()
        LoggedStudentSection = New MaterialSkin.Controls.MaterialLabel()
        MaterialCard6 = New MaterialSkin.Controls.MaterialCard()
        PictureBox2 = New PictureBox()
        MaterialLabel11 = New MaterialSkin.Controls.MaterialLabel()
        NumOfStudent = New MaterialSkin.Controls.MaterialLabel()
        MaterialCard5 = New MaterialSkin.Controls.MaterialCard()
        PictureBox1 = New PictureBox()
        MaterialLabel10 = New MaterialSkin.Controls.MaterialLabel()
        NumOfProf = New MaterialSkin.Controls.MaterialLabel()
        MaterialLabel5 = New MaterialSkin.Controls.MaterialLabel()
        MaterialLabel4 = New MaterialSkin.Controls.MaterialLabel()
        MaterialLabel3 = New MaterialSkin.Controls.MaterialLabel()
        StudentNameLbl = New MaterialSkin.Controls.MaterialLabel()
        MaterialLabel1 = New MaterialSkin.Controls.MaterialLabel()
        Timer1 = New Timer(components)
        MaterialCard1.SuspendLayout()
        NavCard.SuspendLayout()
        CType(PictureBox7, ComponentModel.ISupportInitialize).BeginInit()
        MaterialCard7.SuspendLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        MaterialCard6.SuspendLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        MaterialCard5.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' MaterialCard1
        ' 
        MaterialCard1.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        MaterialCard1.Controls.Add(NavCard)
        MaterialCard1.Controls.Add(SignOutBtn)
        MaterialCard1.Controls.Add(SubmitBtn)
        MaterialCard1.Controls.Add(MaterialLabel41)
        MaterialCard1.Controls.Add(YearComboBox)
        MaterialCard1.Controls.Add(ReasonComboBox)
        MaterialCard1.Controls.Add(ProfComboBox)
        MaterialCard1.Controls.Add(SearchProfBox)
        MaterialCard1.Controls.Add(MaterialLabel6)
        MaterialCard1.Controls.Add(CommentsBox)
        MaterialCard1.Controls.Add(MaterialCard7)
        MaterialCard1.Controls.Add(MaterialCard6)
        MaterialCard1.Controls.Add(MaterialCard5)
        MaterialCard1.Controls.Add(MaterialLabel5)
        MaterialCard1.Controls.Add(MaterialLabel4)
        MaterialCard1.Controls.Add(MaterialLabel3)
        MaterialCard1.Controls.Add(StudentNameLbl)
        MaterialCard1.Controls.Add(MaterialLabel1)
        MaterialCard1.Depth = 0
        MaterialCard1.Dock = DockStyle.Fill
        MaterialCard1.ForeColor = Color.FromArgb(CByte(222), CByte(0), CByte(0), CByte(0))
        MaterialCard1.Location = New Point(3, 24)
        MaterialCard1.Margin = New Padding(0)
        MaterialCard1.MouseState = MaterialSkin.MouseState.HOVER
        MaterialCard1.Name = "MaterialCard1"
        MaterialCard1.Padding = New Padding(14)
        MaterialCard1.Size = New Size(1914, 1053)
        MaterialCard1.TabIndex = 0
        ' 
        ' NavCard
        ' 
        NavCard.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        NavCard.Controls.Add(MaterialLabel15)
        NavCard.Controls.Add(PictureBox7)
        NavCard.Controls.Add(DateLbl)
        NavCard.Controls.Add(TimeLbl)
        NavCard.Depth = 0
        NavCard.Dock = DockStyle.Top
        NavCard.ForeColor = Color.FromArgb(CByte(222), CByte(0), CByte(0), CByte(0))
        NavCard.Location = New Point(14, 14)
        NavCard.Margin = New Padding(0, 0, 50, 0)
        NavCard.MouseState = MaterialSkin.MouseState.HOVER
        NavCard.Name = "NavCard"
        NavCard.Padding = New Padding(50, 14, 50, 14)
        NavCard.Size = New Size(1886, 139)
        NavCard.TabIndex = 19
        ' 
        ' MaterialLabel15
        ' 
        MaterialLabel15.AutoSize = True
        MaterialLabel15.Depth = 0
        MaterialLabel15.Font = New Font("Roboto", 48F, FontStyle.Bold, GraphicsUnit.Pixel)
        MaterialLabel15.FontType = MaterialSkin.MaterialSkinManager.fontType.H3
        MaterialLabel15.Location = New Point(516, 40)
        MaterialLabel15.MouseState = MaterialSkin.MouseState.HOVER
        MaterialLabel15.Name = "MaterialLabel15"
        MaterialLabel15.Size = New Size(855, 58)
        MaterialLabel15.TabIndex = 3
        MaterialLabel15.Text = "PAMANTASAN NG LUNGSOD NG PASIG"
        ' 
        ' PictureBox7
        ' 
        PictureBox7.BackgroundImage = My.Resources.Resources.PLP_logo1
        PictureBox7.BackgroundImageLayout = ImageLayout.Zoom
        PictureBox7.Location = New Point(53, 25)
        PictureBox7.Name = "PictureBox7"
        PictureBox7.Size = New Size(87, 89)
        PictureBox7.TabIndex = 2
        PictureBox7.TabStop = False
        ' 
        ' DateLbl
        ' 
        DateLbl.AutoSize = True
        DateLbl.Depth = 0
        DateLbl.Font = New Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel)
        DateLbl.Location = New Point(1718, 71)
        DateLbl.MouseState = MaterialSkin.MouseState.HOVER
        DateLbl.Name = "DateLbl"
        DateLbl.Size = New Size(115, 19)
        DateLbl.TabIndex = 18
        DateLbl.Text = "January 1, 2025"
        ' 
        ' TimeLbl
        ' 
        TimeLbl.AutoSize = True
        TimeLbl.Depth = 0
        TimeLbl.Font = New Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel)
        TimeLbl.Location = New Point(1764, 49)
        TimeLbl.MouseState = MaterialSkin.MouseState.HOVER
        TimeLbl.Name = "TimeLbl"
        TimeLbl.Size = New Size(69, 19)
        TimeLbl.TabIndex = 17
        TimeLbl.Text = "12:00 PM"
        ' 
        ' SignOutBtn
        ' 
        SignOutBtn.AutoSize = False
        SignOutBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink
        SignOutBtn.BackColor = Color.White
        SignOutBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default
        SignOutBtn.Depth = 0
        SignOutBtn.HighEmphasis = True
        SignOutBtn.Icon = My.Resources.Resources.log_out
        SignOutBtn.Location = New Point(67, 938)
        SignOutBtn.Margin = New Padding(4, 6, 4, 6)
        SignOutBtn.MouseState = MaterialSkin.MouseState.HOVER
        SignOutBtn.Name = "SignOutBtn"
        SignOutBtn.NoAccentTextColor = Color.Empty
        SignOutBtn.Size = New Size(181, 45)
        SignOutBtn.TabIndex = 2
        SignOutBtn.Text = "Sign Out"
        SignOutBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
        SignOutBtn.UseAccentColor = True
        SignOutBtn.UseVisualStyleBackColor = False
        ' 
        ' SubmitBtn
        ' 
        SubmitBtn.AutoSize = False
        SubmitBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink
        SubmitBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default
        SubmitBtn.Depth = 0
        SubmitBtn.HighEmphasis = True
        SubmitBtn.Icon = My.Resources.Resources.application
        SubmitBtn.Location = New Point(1665, 938)
        SubmitBtn.Margin = New Padding(4, 6, 4, 6)
        SubmitBtn.MouseState = MaterialSkin.MouseState.HOVER
        SubmitBtn.Name = "SubmitBtn"
        SubmitBtn.NoAccentTextColor = Color.Empty
        SubmitBtn.Size = New Size(181, 45)
        SubmitBtn.TabIndex = 16
        SubmitBtn.Text = "SUBMIT"
        SubmitBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
        SubmitBtn.UseAccentColor = False
        SubmitBtn.UseVisualStyleBackColor = True
        ' 
        ' MaterialLabel41
        ' 
        MaterialLabel41.AutoSize = True
        MaterialLabel41.Depth = 0
        MaterialLabel41.Font = New Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel)
        MaterialLabel41.FontType = MaterialSkin.MaterialSkinManager.fontType.Caption
        MaterialLabel41.Location = New Point(847, 969)
        MaterialLabel41.MouseState = MaterialSkin.MouseState.HOVER
        MaterialLabel41.Name = "MaterialLabel41"
        MaterialLabel41.Size = New Size(221, 14)
        MaterialLabel41.TabIndex = 15
        MaterialLabel41.Text = "Powered by College of Computer Studies"
        MaterialLabel41.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' YearComboBox
        ' 
        YearComboBox.AutoResize = False
        YearComboBox.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        YearComboBox.Depth = 0
        YearComboBox.DrawMode = DrawMode.OwnerDrawVariable
        YearComboBox.DropDownHeight = 174
        YearComboBox.DropDownStyle = ComboBoxStyle.DropDownList
        YearComboBox.DropDownWidth = 121
        YearComboBox.Font = New Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel)
        YearComboBox.ForeColor = Color.FromArgb(CByte(222), CByte(0), CByte(0), CByte(0))
        YearComboBox.FormattingEnabled = True
        YearComboBox.Hint = "Select your year and section"
        YearComboBox.IntegralHeight = False
        YearComboBox.ItemHeight = 43
        YearComboBox.Location = New Point(1272, 577)
        YearComboBox.MaxDropDownItems = 4
        YearComboBox.MouseState = MaterialSkin.MouseState.OUT
        YearComboBox.Name = "YearComboBox"
        YearComboBox.Size = New Size(574, 49)
        YearComboBox.StartIndex = 0
        YearComboBox.TabIndex = 14
        YearComboBox.UseAccent = False
        ' 
        ' ReasonComboBox
        ' 
        ReasonComboBox.AutoResize = False
        ReasonComboBox.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        ReasonComboBox.Depth = 0
        ReasonComboBox.DrawMode = DrawMode.OwnerDrawVariable
        ReasonComboBox.DropDownHeight = 174
        ReasonComboBox.DropDownStyle = ComboBoxStyle.DropDownList
        ReasonComboBox.DropDownWidth = 121
        ReasonComboBox.Font = New Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel)
        ReasonComboBox.ForeColor = Color.FromArgb(CByte(222), CByte(0), CByte(0), CByte(0))
        ReasonComboBox.FormattingEnabled = True
        ReasonComboBox.Hint = "Select a reason"
        ReasonComboBox.IntegralHeight = False
        ReasonComboBox.ItemHeight = 43
        ReasonComboBox.Location = New Point(669, 575)
        ReasonComboBox.MaxDropDownItems = 4
        ReasonComboBox.MouseState = MaterialSkin.MouseState.OUT
        ReasonComboBox.Name = "ReasonComboBox"
        ReasonComboBox.Size = New Size(574, 49)
        ReasonComboBox.StartIndex = 0
        ReasonComboBox.TabIndex = 13
        ReasonComboBox.UseAccent = False
        ' 
        ' ProfComboBox
        ' 
        ProfComboBox.AutoResize = False
        ProfComboBox.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        ProfComboBox.Depth = 0
        ProfComboBox.DrawMode = DrawMode.OwnerDrawVariable
        ProfComboBox.DropDownHeight = 174
        ProfComboBox.DropDownStyle = ComboBoxStyle.DropDownList
        ProfComboBox.DropDownWidth = 121
        ProfComboBox.Font = New Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel)
        ProfComboBox.ForeColor = Color.FromArgb(CByte(222), CByte(0), CByte(0), CByte(0))
        ProfComboBox.FormattingEnabled = True
        ProfComboBox.Hint = "Select a professor"
        ProfComboBox.IntegralHeight = False
        ProfComboBox.ItemHeight = 43
        ProfComboBox.Location = New Point(67, 633)
        ProfComboBox.MaxDropDownItems = 4
        ProfComboBox.MouseState = MaterialSkin.MouseState.OUT
        ProfComboBox.Name = "ProfComboBox"
        ProfComboBox.Size = New Size(574, 49)
        ProfComboBox.StartIndex = 0
        ProfComboBox.TabIndex = 12
        ProfComboBox.UseAccent = False
        ' 
        ' SearchProfBox
        ' 
        SearchProfBox.AnimateReadOnly = False
        SearchProfBox.BorderStyle = BorderStyle.None
        SearchProfBox.Depth = 0
        SearchProfBox.Font = New Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel)
        SearchProfBox.Hint = "Search for a professor (You can type prof. Name here)"
        SearchProfBox.LeadingIcon = Nothing
        SearchProfBox.Location = New Point(67, 577)
        SearchProfBox.MaxLength = 50
        SearchProfBox.MouseState = MaterialSkin.MouseState.OUT
        SearchProfBox.Multiline = False
        SearchProfBox.Name = "SearchProfBox"
        SearchProfBox.Size = New Size(574, 50)
        SearchProfBox.TabIndex = 11
        SearchProfBox.Text = ""
        SearchProfBox.TrailingIcon = Nothing
        SearchProfBox.UseAccent = False
        ' 
        ' MaterialLabel6
        ' 
        MaterialLabel6.AutoSize = True
        MaterialLabel6.Depth = 0
        MaterialLabel6.Font = New Font("Roboto", 24F, FontStyle.Bold, GraphicsUnit.Pixel)
        MaterialLabel6.FontType = MaterialSkin.MaterialSkinManager.fontType.H5
        MaterialLabel6.Location = New Point(67, 725)
        MaterialLabel6.MouseState = MaterialSkin.MouseState.HOVER
        MaterialLabel6.Name = "MaterialLabel6"
        MaterialLabel6.Size = New Size(119, 29)
        MaterialLabel6.TabIndex = 10
        MaterialLabel6.Text = "Comments"
        ' 
        ' CommentsBox
        ' 
        CommentsBox.AnimateReadOnly = False
        CommentsBox.BackgroundImageLayout = ImageLayout.None
        CommentsBox.CharacterCasing = CharacterCasing.Normal
        CommentsBox.Depth = 0
        CommentsBox.HideSelection = True
        CommentsBox.Hint = "Enter your comments, remarks or messages here (optional)"
        CommentsBox.Location = New Point(67, 780)
        CommentsBox.MaxLength = 32767
        CommentsBox.MouseState = MaterialSkin.MouseState.OUT
        CommentsBox.Name = "CommentsBox"
        CommentsBox.PasswordChar = ChrW(0)
        CommentsBox.ReadOnly = False
        CommentsBox.ScrollBars = ScrollBars.None
        CommentsBox.SelectedText = ""
        CommentsBox.SelectionLength = 0
        CommentsBox.SelectionStart = 0
        CommentsBox.ShortcutsEnabled = True
        CommentsBox.Size = New Size(1779, 125)
        CommentsBox.TabIndex = 9
        CommentsBox.TabStop = False
        CommentsBox.TextAlign = HorizontalAlignment.Left
        CommentsBox.UseAccent = False
        CommentsBox.UseSystemPasswordChar = False
        ' 
        ' MaterialCard7
        ' 
        MaterialCard7.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        MaterialCard7.Controls.Add(PictureBox3)
        MaterialCard7.Controls.Add(MaterialLabel13)
        MaterialCard7.Controls.Add(LoggedStudentSection)
        MaterialCard7.Depth = 0
        MaterialCard7.ForeColor = Color.FromArgb(CByte(222), CByte(0), CByte(0), CByte(0))
        MaterialCard7.Location = New Point(1272, 282)
        MaterialCard7.Margin = New Padding(14)
        MaterialCard7.MouseState = MaterialSkin.MouseState.HOVER
        MaterialCard7.Name = "MaterialCard7"
        MaterialCard7.Padding = New Padding(30)
        MaterialCard7.Size = New Size(574, 208)
        MaterialCard7.TabIndex = 8
        ' 
        ' PictureBox3
        ' 
        PictureBox3.BackgroundImage = My.Resources.Resources.user_interface
        PictureBox3.BackgroundImageLayout = ImageLayout.Zoom
        PictureBox3.Location = New Point(474, 113)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(67, 62)
        PictureBox3.TabIndex = 7
        PictureBox3.TabStop = False
        ' 
        ' MaterialLabel13
        ' 
        MaterialLabel13.AutoSize = True
        MaterialLabel13.Depth = 0
        MaterialLabel13.Font = New Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel)
        MaterialLabel13.Location = New Point(33, 32)
        MaterialLabel13.MouseState = MaterialSkin.MouseState.HOVER
        MaterialLabel13.Name = "MaterialLabel13"
        MaterialLabel13.Size = New Size(89, 19)
        MaterialLabel13.TabIndex = 6
        MaterialLabel13.Text = "Your section"
        ' 
        ' LoggedStudentSection
        ' 
        LoggedStudentSection.AutoSize = True
        LoggedStudentSection.Depth = 0
        LoggedStudentSection.Font = New Font("Roboto Light", 96F, FontStyle.Regular, GraphicsUnit.Pixel)
        LoggedStudentSection.FontType = MaterialSkin.MaterialSkinManager.fontType.H1
        LoggedStudentSection.Location = New Point(33, 51)
        LoggedStudentSection.MouseState = MaterialSkin.MouseState.HOVER
        LoggedStudentSection.Name = "LoggedStudentSection"
        LoggedStudentSection.Size = New Size(342, 115)
        LoggedStudentSection.TabIndex = 5
        LoggedStudentSection.Text = "BSIT-2C"
        ' 
        ' MaterialCard6
        ' 
        MaterialCard6.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        MaterialCard6.Controls.Add(PictureBox2)
        MaterialCard6.Controls.Add(MaterialLabel11)
        MaterialCard6.Controls.Add(NumOfStudent)
        MaterialCard6.Depth = 0
        MaterialCard6.ForeColor = Color.FromArgb(CByte(222), CByte(0), CByte(0), CByte(0))
        MaterialCard6.Location = New Point(669, 282)
        MaterialCard6.Margin = New Padding(14)
        MaterialCard6.MouseState = MaterialSkin.MouseState.HOVER
        MaterialCard6.Name = "MaterialCard6"
        MaterialCard6.Padding = New Padding(30)
        MaterialCard6.Size = New Size(574, 208)
        MaterialCard6.TabIndex = 7
        ' 
        ' PictureBox2
        ' 
        PictureBox2.BackgroundImage = My.Resources.Resources.student_with_graduation_cap__1_
        PictureBox2.BackgroundImageLayout = ImageLayout.Zoom
        PictureBox2.Location = New Point(474, 113)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(67, 62)
        PictureBox2.TabIndex = 7
        PictureBox2.TabStop = False
        ' 
        ' MaterialLabel11
        ' 
        MaterialLabel11.AutoSize = True
        MaterialLabel11.Depth = 0
        MaterialLabel11.Font = New Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel)
        MaterialLabel11.Location = New Point(33, 32)
        MaterialLabel11.MouseState = MaterialSkin.MouseState.HOVER
        MaterialLabel11.Name = "MaterialLabel11"
        MaterialLabel11.Size = New Size(122, 19)
        MaterialLabel11.TabIndex = 6
        MaterialLabel11.Text = "Total of students"
        ' 
        ' NumOfStudent
        ' 
        NumOfStudent.AutoSize = True
        NumOfStudent.Depth = 0
        NumOfStudent.Font = New Font("Roboto Light", 96F, FontStyle.Regular, GraphicsUnit.Pixel)
        NumOfStudent.FontType = MaterialSkin.MaterialSkinManager.fontType.H1
        NumOfStudent.Location = New Point(33, 51)
        NumOfStudent.MouseState = MaterialSkin.MouseState.HOVER
        NumOfStudent.Name = "NumOfStudent"
        NumOfStudent.Size = New Size(160, 115)
        NumOfStudent.TabIndex = 5
        NumOfStudent.Text = "217"
        ' 
        ' MaterialCard5
        ' 
        MaterialCard5.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        MaterialCard5.Controls.Add(PictureBox1)
        MaterialCard5.Controls.Add(MaterialLabel10)
        MaterialCard5.Controls.Add(NumOfProf)
        MaterialCard5.Depth = 0
        MaterialCard5.ForeColor = Color.FromArgb(CByte(222), CByte(0), CByte(0), CByte(0))
        MaterialCard5.Location = New Point(67, 282)
        MaterialCard5.Margin = New Padding(14)
        MaterialCard5.MouseState = MaterialSkin.MouseState.HOVER
        MaterialCard5.Name = "MaterialCard5"
        MaterialCard5.Padding = New Padding(30)
        MaterialCard5.Size = New Size(574, 208)
        MaterialCard5.TabIndex = 6
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackgroundImage = My.Resources.Resources.manager
        PictureBox1.BackgroundImageLayout = ImageLayout.Zoom
        PictureBox1.Location = New Point(474, 113)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(67, 62)
        PictureBox1.TabIndex = 4
        PictureBox1.TabStop = False
        ' 
        ' MaterialLabel10
        ' 
        MaterialLabel10.AutoSize = True
        MaterialLabel10.Depth = 0
        MaterialLabel10.Font = New Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel)
        MaterialLabel10.Location = New Point(33, 30)
        MaterialLabel10.MouseState = MaterialSkin.MouseState.HOVER
        MaterialLabel10.Name = "MaterialLabel10"
        MaterialLabel10.Size = New Size(136, 19)
        MaterialLabel10.TabIndex = 3
        MaterialLabel10.Text = "Total of professors"
        ' 
        ' NumOfProf
        ' 
        NumOfProf.AutoSize = True
        NumOfProf.Depth = 0
        NumOfProf.Font = New Font("Roboto Light", 96F, FontStyle.Regular, GraphicsUnit.Pixel)
        NumOfProf.FontType = MaterialSkin.MaterialSkinManager.fontType.H1
        NumOfProf.Location = New Point(33, 49)
        NumOfProf.MouseState = MaterialSkin.MouseState.HOVER
        NumOfProf.Name = "NumOfProf"
        NumOfProf.Size = New Size(107, 115)
        NumOfProf.TabIndex = 2
        NumOfProf.Text = "27"
        ' 
        ' MaterialLabel5
        ' 
        MaterialLabel5.AutoSize = True
        MaterialLabel5.Depth = 0
        MaterialLabel5.Font = New Font("Roboto", 24F, FontStyle.Bold, GraphicsUnit.Pixel)
        MaterialLabel5.FontType = MaterialSkin.MaterialSkinManager.fontType.H5
        MaterialLabel5.Location = New Point(1272, 524)
        MaterialLabel5.MouseState = MaterialSkin.MouseState.HOVER
        MaterialLabel5.Name = "MaterialLabel5"
        MaterialLabel5.Size = New Size(180, 29)
        MaterialLabel5.TabIndex = 5
        MaterialLabel5.Text = "Year and section"
        ' 
        ' MaterialLabel4
        ' 
        MaterialLabel4.AutoSize = True
        MaterialLabel4.Depth = 0
        MaterialLabel4.Font = New Font("Roboto", 24F, FontStyle.Bold, GraphicsUnit.Pixel)
        MaterialLabel4.FontType = MaterialSkin.MaterialSkinManager.fontType.H5
        MaterialLabel4.Location = New Point(669, 524)
        MaterialLabel4.MouseState = MaterialSkin.MouseState.HOVER
        MaterialLabel4.Name = "MaterialLabel4"
        MaterialLabel4.Size = New Size(93, 29)
        MaterialLabel4.TabIndex = 4
        MaterialLabel4.Text = "Reasons"
        ' 
        ' MaterialLabel3
        ' 
        MaterialLabel3.AutoSize = True
        MaterialLabel3.Depth = 0
        MaterialLabel3.Font = New Font("Roboto", 24F, FontStyle.Bold, GraphicsUnit.Pixel)
        MaterialLabel3.FontType = MaterialSkin.MaterialSkinManager.fontType.H5
        MaterialLabel3.Location = New Point(67, 524)
        MaterialLabel3.MouseState = MaterialSkin.MouseState.HOVER
        MaterialLabel3.Name = "MaterialLabel3"
        MaterialLabel3.Size = New Size(117, 29)
        MaterialLabel3.TabIndex = 2
        MaterialLabel3.Text = "Professors"
        ' 
        ' StudentNameLbl
        ' 
        StudentNameLbl.AutoSize = True
        StudentNameLbl.Depth = 0
        StudentNameLbl.Font = New Font("Roboto", 34F, FontStyle.Bold, GraphicsUnit.Pixel)
        StudentNameLbl.FontType = MaterialSkin.MaterialSkinManager.fontType.H4
        StudentNameLbl.Location = New Point(67, 190)
        StudentNameLbl.MouseState = MaterialSkin.MouseState.HOVER
        StudentNameLbl.Name = "StudentNameLbl"
        StudentNameLbl.Size = New Size(338, 41)
        StudentNameLbl.TabIndex = 1
        StudentNameLbl.Text = "NAME OF T. STUDENT"
        ' 
        ' MaterialLabel1
        ' 
        MaterialLabel1.AutoSize = True
        MaterialLabel1.Depth = 0
        MaterialLabel1.Font = New Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel)
        MaterialLabel1.Location = New Point(67, 231)
        MaterialLabel1.MouseState = MaterialSkin.MouseState.HOVER
        MaterialLabel1.Name = "MaterialLabel1"
        MaterialLabel1.Size = New Size(279, 19)
        MaterialLabel1.TabIndex = 0
        MaterialLabel1.Text = "Welcome to Online Registration System"
        ' 
        ' Timer1
        ' 
        Timer1.Enabled = True
        Timer1.Interval = 1000
        ' 
        ' StudentDashboard
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1920, 1080)
        Controls.Add(MaterialCard1)
        FormStyle = FormStyles.ActionBar_None
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "StudentDashboard"
        Padding = New Padding(3, 24, 3, 3)
        Sizable = False
        StartPosition = FormStartPosition.CenterScreen
        Text = "StudentDashboard"
        WindowState = FormWindowState.Maximized
        MaterialCard1.ResumeLayout(False)
        MaterialCard1.PerformLayout()
        NavCard.ResumeLayout(False)
        NavCard.PerformLayout()
        CType(PictureBox7, ComponentModel.ISupportInitialize).EndInit()
        MaterialCard7.ResumeLayout(False)
        MaterialCard7.PerformLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        MaterialCard6.ResumeLayout(False)
        MaterialCard6.PerformLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        MaterialCard5.ResumeLayout(False)
        MaterialCard5.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents MaterialCard1 As MaterialSkin.Controls.MaterialCard
    Friend WithEvents PictureBox7 As PictureBox
    Friend WithEvents StudentNameLbl As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents MaterialLabel1 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents SignOutBtn As MaterialSkin.Controls.MaterialButton
    Friend WithEvents MaterialCard5 As MaterialSkin.Controls.MaterialCard
    Friend WithEvents MaterialLabel5 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents MaterialLabel4 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents MaterialLabel3 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents MaterialCard7 As MaterialSkin.Controls.MaterialCard
    Friend WithEvents MaterialCard6 As MaterialSkin.Controls.MaterialCard
    Friend WithEvents YearComboBox As MaterialSkin.Controls.MaterialComboBox
    Friend WithEvents ReasonComboBox As MaterialSkin.Controls.MaterialComboBox
    Friend WithEvents ProfComboBox As MaterialSkin.Controls.MaterialComboBox
    Friend WithEvents SearchProfBox As MaterialSkin.Controls.MaterialTextBox
    Friend WithEvents MaterialLabel6 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents CommentsBox As MaterialSkin.Controls.MaterialMultiLineTextBox2
    Friend WithEvents MaterialLabel41 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents DateLbl As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents TimeLbl As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents SubmitBtn As MaterialSkin.Controls.MaterialButton
    Friend WithEvents MaterialLabel10 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents NumOfProf As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents MaterialLabel13 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents LoggedStudentSection As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents MaterialLabel11 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents NumOfStudent As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents NavCard As MaterialSkin.Controls.MaterialCard
    Friend WithEvents MaterialLabel15 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents Timer1 As Timer
End Class

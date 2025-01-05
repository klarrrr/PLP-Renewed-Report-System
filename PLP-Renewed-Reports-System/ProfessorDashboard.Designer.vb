<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProfessorDashboard
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProfessorDashboard))
        MaterialLabel1 = New MaterialSkin.Controls.MaterialLabel()
        MaterialLabel2 = New MaterialSkin.Controls.MaterialLabel()
        MaterialTabControl1 = New MaterialSkin.Controls.MaterialTabControl()
        Dashboard = New TabPage()
        MaterialCard2 = New MaterialSkin.Controls.MaterialCard()
        MaterialCard3 = New MaterialSkin.Controls.MaterialCard()
        MaterialCard4 = New MaterialSkin.Controls.MaterialCard()
        MaterialCard5 = New MaterialSkin.Controls.MaterialCard()
        MaterialCard7 = New MaterialSkin.Controls.MaterialCard()
        PictureBox3 = New PictureBox()
        MaterialLabel13 = New MaterialSkin.Controls.MaterialLabel()
        MaterialLabel14 = New MaterialSkin.Controls.MaterialLabel()
        MaterialCard8 = New MaterialSkin.Controls.MaterialCard()
        PictureBox1 = New PictureBox()
        MaterialLabel10 = New MaterialSkin.Controls.MaterialLabel()
        MaterialLabel9 = New MaterialSkin.Controls.MaterialLabel()
        MaterialCard6 = New MaterialSkin.Controls.MaterialCard()
        PictureBox2 = New PictureBox()
        MaterialLabel11 = New MaterialSkin.Controls.MaterialLabel()
        MaterialLabel12 = New MaterialSkin.Controls.MaterialLabel()
        Professors = New TabPage()
        MaterialCard9 = New MaterialSkin.Controls.MaterialCard()
        MaterialTextBox4 = New MaterialSkin.Controls.MaterialTextBox()
        MaterialLabel8 = New MaterialSkin.Controls.MaterialLabel()
        MaterialTextBox3 = New MaterialSkin.Controls.MaterialTextBox()
        MaterialLabel7 = New MaterialSkin.Controls.MaterialLabel()
        MaterialTextBox2 = New MaterialSkin.Controls.MaterialTextBox()
        MaterialLabel6 = New MaterialSkin.Controls.MaterialLabel()
        DataGridView1 = New DataGridView()
        MaterialLabel5 = New MaterialSkin.Controls.MaterialLabel()
        MaterialTextBox1 = New MaterialSkin.Controls.MaterialTextBox()
        Students = New TabPage()
        MaterialCard10 = New MaterialSkin.Controls.MaterialCard()
        Reports = New TabPage()
        MaterialCard11 = New MaterialSkin.Controls.MaterialCard()
        Reasons = New TabPage()
        MaterialCard12 = New MaterialSkin.Controls.MaterialCard()
        SectionsTab = New TabPage()
        MaterialCard14 = New MaterialSkin.Controls.MaterialCard()
        ArchiveTab = New TabPage()
        MaterialCard15 = New MaterialSkin.Controls.MaterialCard()
        SignOutTab = New TabPage()
        MaterialCard16 = New MaterialSkin.Controls.MaterialCard()
        ImageList1 = New ImageList(components)
        MaterialCard1 = New MaterialSkin.Controls.MaterialCard()
        MaterialLabel4 = New MaterialSkin.Controls.MaterialLabel()
        MaterialLabel3 = New MaterialSkin.Controls.MaterialLabel()
        MaterialTextBox5 = New MaterialSkin.Controls.MaterialTextBox()
        MaterialLabel15 = New MaterialSkin.Controls.MaterialLabel()
        MaterialLabel16 = New MaterialSkin.Controls.MaterialLabel()
        MaterialTabControl1.SuspendLayout()
        Dashboard.SuspendLayout()
        MaterialCard2.SuspendLayout()
        MaterialCard7.SuspendLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        MaterialCard8.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        MaterialCard6.SuspendLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        Professors.SuspendLayout()
        MaterialCard9.SuspendLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        Students.SuspendLayout()
        Reports.SuspendLayout()
        Reasons.SuspendLayout()
        SectionsTab.SuspendLayout()
        ArchiveTab.SuspendLayout()
        SignOutTab.SuspendLayout()
        MaterialCard1.SuspendLayout()
        SuspendLayout()
        ' 
        ' MaterialLabel1
        ' 
        MaterialLabel1.AutoSize = True
        MaterialLabel1.Depth = 0
        MaterialLabel1.Font = New Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel)
        MaterialLabel1.Location = New Point(71, 91)
        MaterialLabel1.MouseState = MaterialSkin.MouseState.HOVER
        MaterialLabel1.Name = "MaterialLabel1"
        MaterialLabel1.Size = New Size(279, 19)
        MaterialLabel1.TabIndex = 9
        MaterialLabel1.Text = "Welcome to Online Registration System"
        ' 
        ' MaterialLabel2
        ' 
        MaterialLabel2.AutoSize = True
        MaterialLabel2.Depth = 0
        MaterialLabel2.Font = New Font("Roboto", 34F, FontStyle.Bold, GraphicsUnit.Pixel)
        MaterialLabel2.FontType = MaterialSkin.MaterialSkinManager.fontType.H4
        MaterialLabel2.Location = New Point(71, 50)
        MaterialLabel2.MouseState = MaterialSkin.MouseState.HOVER
        MaterialLabel2.Name = "MaterialLabel2"
        MaterialLabel2.Size = New Size(378, 41)
        MaterialLabel2.TabIndex = 10
        MaterialLabel2.Text = "NAME OF T. PROFESSOR"
        ' 
        ' MaterialTabControl1
        ' 
        MaterialTabControl1.Controls.Add(Dashboard)
        MaterialTabControl1.Controls.Add(Professors)
        MaterialTabControl1.Controls.Add(Students)
        MaterialTabControl1.Controls.Add(Reports)
        MaterialTabControl1.Controls.Add(Reasons)
        MaterialTabControl1.Controls.Add(SectionsTab)
        MaterialTabControl1.Controls.Add(ArchiveTab)
        MaterialTabControl1.Controls.Add(SignOutTab)
        MaterialTabControl1.Depth = 0
        MaterialTabControl1.ImageList = ImageList1
        MaterialTabControl1.Location = New Point(50, 137)
        MaterialTabControl1.MouseState = MaterialSkin.MouseState.HOVER
        MaterialTabControl1.Multiline = True
        MaterialTabControl1.Name = "MaterialTabControl1"
        MaterialTabControl1.SelectedIndex = 0
        MaterialTabControl1.Size = New Size(1817, 869)
        MaterialTabControl1.TabIndex = 1
        ' 
        ' Dashboard
        ' 
        Dashboard.BackColor = Color.White
        Dashboard.Controls.Add(MaterialCard2)
        Dashboard.ImageKey = "home-4-fill.png"
        Dashboard.Location = New Point(4, 39)
        Dashboard.Name = "Dashboard"
        Dashboard.Padding = New Padding(3)
        Dashboard.Size = New Size(1809, 826)
        Dashboard.TabIndex = 0
        Dashboard.Text = "Dashboard"
        Dashboard.ToolTipText = "Dashboard"
        ' 
        ' MaterialCard2
        ' 
        MaterialCard2.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        MaterialCard2.Controls.Add(MaterialCard3)
        MaterialCard2.Controls.Add(MaterialCard4)
        MaterialCard2.Controls.Add(MaterialCard5)
        MaterialCard2.Controls.Add(MaterialCard7)
        MaterialCard2.Controls.Add(MaterialCard8)
        MaterialCard2.Controls.Add(MaterialCard6)
        MaterialCard2.Depth = 0
        MaterialCard2.ForeColor = Color.FromArgb(CByte(222), CByte(0), CByte(0), CByte(0))
        MaterialCard2.Location = New Point(-17, -23)
        MaterialCard2.Margin = New Padding(14)
        MaterialCard2.MouseState = MaterialSkin.MouseState.HOVER
        MaterialCard2.Name = "MaterialCard2"
        MaterialCard2.Padding = New Padding(14)
        MaterialCard2.Size = New Size(1841, 900)
        MaterialCard2.TabIndex = 0
        ' 
        ' MaterialCard3
        ' 
        MaterialCard3.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        MaterialCard3.Depth = 0
        MaterialCard3.ForeColor = Color.FromArgb(CByte(222), CByte(0), CByte(0), CByte(0))
        MaterialCard3.Location = New Point(1238, 215)
        MaterialCard3.Margin = New Padding(14)
        MaterialCard3.MouseState = MaterialSkin.MouseState.HOVER
        MaterialCard3.Name = "MaterialCard3"
        MaterialCard3.Padding = New Padding(14)
        MaterialCard3.Size = New Size(523, 671)
        MaterialCard3.TabIndex = 27
        ' 
        ' MaterialCard4
        ' 
        MaterialCard4.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        MaterialCard4.Depth = 0
        MaterialCard4.ForeColor = Color.FromArgb(CByte(222), CByte(0), CByte(0), CByte(0))
        MaterialCard4.Location = New Point(34, 463)
        MaterialCard4.Margin = New Padding(14)
        MaterialCard4.MouseState = MaterialSkin.MouseState.HOVER
        MaterialCard4.Name = "MaterialCard4"
        MaterialCard4.Padding = New Padding(14)
        MaterialCard4.Size = New Size(1173, 423)
        MaterialCard4.TabIndex = 26
        ' 
        ' MaterialCard5
        ' 
        MaterialCard5.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        MaterialCard5.Depth = 0
        MaterialCard5.ForeColor = Color.FromArgb(CByte(222), CByte(0), CByte(0), CByte(0))
        MaterialCard5.Location = New Point(34, 215)
        MaterialCard5.Margin = New Padding(14)
        MaterialCard5.MouseState = MaterialSkin.MouseState.HOVER
        MaterialCard5.Name = "MaterialCard5"
        MaterialCard5.Padding = New Padding(14)
        MaterialCard5.Size = New Size(1173, 220)
        MaterialCard5.TabIndex = 25
        ' 
        ' MaterialCard7
        ' 
        MaterialCard7.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        MaterialCard7.Controls.Add(PictureBox3)
        MaterialCard7.Controls.Add(MaterialLabel13)
        MaterialCard7.Controls.Add(MaterialLabel14)
        MaterialCard7.Depth = 0
        MaterialCard7.ForeColor = Color.FromArgb(CByte(222), CByte(0), CByte(0), CByte(0))
        MaterialCard7.Location = New Point(1238, 43)
        MaterialCard7.Margin = New Padding(14)
        MaterialCard7.MouseState = MaterialSkin.MouseState.HOVER
        MaterialCard7.Name = "MaterialCard7"
        MaterialCard7.Padding = New Padding(30)
        MaterialCard7.Size = New Size(523, 144)
        MaterialCard7.TabIndex = 24
        ' 
        ' PictureBox3
        ' 
        PictureBox3.BackgroundImage = My.Resources.Resources.user_interface
        PictureBox3.BackgroundImageLayout = ImageLayout.Zoom
        PictureBox3.Location = New Point(423, 41)
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
        MaterialLabel13.Location = New Point(33, 30)
        MaterialLabel13.MouseState = MaterialSkin.MouseState.HOVER
        MaterialLabel13.Name = "MaterialLabel13"
        MaterialLabel13.Size = New Size(110, 19)
        MaterialLabel13.TabIndex = 6
        MaterialLabel13.Text = "Total of reports"
        ' 
        ' MaterialLabel14
        ' 
        MaterialLabel14.AutoSize = True
        MaterialLabel14.Depth = 0
        MaterialLabel14.Font = New Font("Roboto Light", 60F, FontStyle.Regular, GraphicsUnit.Pixel)
        MaterialLabel14.FontType = MaterialSkin.MaterialSkinManager.fontType.H2
        MaterialLabel14.Location = New Point(33, 49)
        MaterialLabel14.MouseState = MaterialSkin.MouseState.HOVER
        MaterialLabel14.Name = "MaterialLabel14"
        MaterialLabel14.Size = New Size(34, 72)
        MaterialLabel14.TabIndex = 5
        MaterialLabel14.Text = "0"
        ' 
        ' MaterialCard8
        ' 
        MaterialCard8.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        MaterialCard8.Controls.Add(PictureBox1)
        MaterialCard8.Controls.Add(MaterialLabel10)
        MaterialCard8.Controls.Add(MaterialLabel9)
        MaterialCard8.Depth = 0
        MaterialCard8.ForeColor = Color.FromArgb(CByte(222), CByte(0), CByte(0), CByte(0))
        MaterialCard8.Location = New Point(34, 40)
        MaterialCard8.Margin = New Padding(14)
        MaterialCard8.MouseState = MaterialSkin.MouseState.HOVER
        MaterialCard8.Name = "MaterialCard8"
        MaterialCard8.Padding = New Padding(30)
        MaterialCard8.Size = New Size(574, 147)
        MaterialCard8.TabIndex = 22
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackgroundImage = My.Resources.Resources.manager
        PictureBox1.BackgroundImageLayout = ImageLayout.Zoom
        PictureBox1.Location = New Point(474, 42)
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
        ' MaterialLabel9
        ' 
        MaterialLabel9.AutoSize = True
        MaterialLabel9.Depth = 0
        MaterialLabel9.Font = New Font("Roboto Light", 60F, FontStyle.Regular, GraphicsUnit.Pixel)
        MaterialLabel9.FontType = MaterialSkin.MaterialSkinManager.fontType.H2
        MaterialLabel9.Location = New Point(33, 49)
        MaterialLabel9.MouseState = MaterialSkin.MouseState.HOVER
        MaterialLabel9.Name = "MaterialLabel9"
        MaterialLabel9.Size = New Size(67, 72)
        MaterialLabel9.TabIndex = 2
        MaterialLabel9.Text = "27"
        ' 
        ' MaterialCard6
        ' 
        MaterialCard6.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        MaterialCard6.Controls.Add(PictureBox2)
        MaterialCard6.Controls.Add(MaterialLabel11)
        MaterialCard6.Controls.Add(MaterialLabel12)
        MaterialCard6.Depth = 0
        MaterialCard6.ForeColor = Color.FromArgb(CByte(222), CByte(0), CByte(0), CByte(0))
        MaterialCard6.Location = New Point(636, 40)
        MaterialCard6.Margin = New Padding(14)
        MaterialCard6.MouseState = MaterialSkin.MouseState.HOVER
        MaterialCard6.Name = "MaterialCard6"
        MaterialCard6.Padding = New Padding(30)
        MaterialCard6.Size = New Size(574, 147)
        MaterialCard6.TabIndex = 23
        ' 
        ' PictureBox2
        ' 
        PictureBox2.BackgroundImage = My.Resources.Resources.student_with_graduation_cap__1_
        PictureBox2.BackgroundImageLayout = ImageLayout.Zoom
        PictureBox2.Location = New Point(474, 42)
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
        MaterialLabel11.Location = New Point(33, 30)
        MaterialLabel11.MouseState = MaterialSkin.MouseState.HOVER
        MaterialLabel11.Name = "MaterialLabel11"
        MaterialLabel11.Size = New Size(122, 19)
        MaterialLabel11.TabIndex = 6
        MaterialLabel11.Text = "Total of students"
        ' 
        ' MaterialLabel12
        ' 
        MaterialLabel12.AutoSize = True
        MaterialLabel12.Depth = 0
        MaterialLabel12.Font = New Font("Roboto Light", 60F, FontStyle.Regular, GraphicsUnit.Pixel)
        MaterialLabel12.FontType = MaterialSkin.MaterialSkinManager.fontType.H2
        MaterialLabel12.Location = New Point(33, 49)
        MaterialLabel12.MouseState = MaterialSkin.MouseState.HOVER
        MaterialLabel12.Name = "MaterialLabel12"
        MaterialLabel12.Size = New Size(100, 72)
        MaterialLabel12.TabIndex = 5
        MaterialLabel12.Text = "217"
        ' 
        ' Professors
        ' 
        Professors.Controls.Add(MaterialCard9)
        Professors.ImageKey = "user-2-fill.png"
        Professors.Location = New Point(4, 39)
        Professors.Name = "Professors"
        Professors.Padding = New Padding(3)
        Professors.Size = New Size(1809, 826)
        Professors.TabIndex = 1
        Professors.Text = "Professors"
        Professors.UseVisualStyleBackColor = True
        ' 
        ' MaterialCard9
        ' 
        MaterialCard9.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        MaterialCard9.Controls.Add(MaterialLabel16)
        MaterialCard9.Controls.Add(MaterialTextBox5)
        MaterialCard9.Controls.Add(MaterialLabel15)
        MaterialCard9.Controls.Add(MaterialTextBox4)
        MaterialCard9.Controls.Add(MaterialLabel8)
        MaterialCard9.Controls.Add(MaterialTextBox3)
        MaterialCard9.Controls.Add(MaterialLabel7)
        MaterialCard9.Controls.Add(MaterialTextBox2)
        MaterialCard9.Controls.Add(MaterialLabel6)
        MaterialCard9.Controls.Add(DataGridView1)
        MaterialCard9.Controls.Add(MaterialLabel5)
        MaterialCard9.Controls.Add(MaterialTextBox1)
        MaterialCard9.Depth = 0
        MaterialCard9.ForeColor = Color.FromArgb(CByte(222), CByte(0), CByte(0), CByte(0))
        MaterialCard9.Location = New Point(-16, -22)
        MaterialCard9.Margin = New Padding(14)
        MaterialCard9.MouseState = MaterialSkin.MouseState.HOVER
        MaterialCard9.Name = "MaterialCard9"
        MaterialCard9.Padding = New Padding(14)
        MaterialCard9.Size = New Size(1841, 902)
        MaterialCard9.TabIndex = 1
        ' 
        ' MaterialTextBox4
        ' 
        MaterialTextBox4.AnimateReadOnly = False
        MaterialTextBox4.BorderStyle = BorderStyle.None
        MaterialTextBox4.Depth = 0
        MaterialTextBox4.Font = New Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel)
        MaterialTextBox4.Hint = "Enter the username"
        MaterialTextBox4.LeadingIcon = Nothing
        MaterialTextBox4.Location = New Point(1347, 426)
        MaterialTextBox4.MaxLength = 50
        MaterialTextBox4.MouseState = MaterialSkin.MouseState.OUT
        MaterialTextBox4.Multiline = False
        MaterialTextBox4.Name = "MaterialTextBox4"
        MaterialTextBox4.Size = New Size(413, 50)
        MaterialTextBox4.TabIndex = 10
        MaterialTextBox4.Text = ""
        MaterialTextBox4.TrailingIcon = Nothing
        ' 
        ' MaterialLabel8
        ' 
        MaterialLabel8.AutoSize = True
        MaterialLabel8.Depth = 0
        MaterialLabel8.Font = New Font("Roboto Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel)
        MaterialLabel8.FontType = MaterialSkin.MaterialSkinManager.fontType.H6
        MaterialLabel8.Location = New Point(1347, 376)
        MaterialLabel8.MouseState = MaterialSkin.MouseState.HOVER
        MaterialLabel8.Name = "MaterialLabel8"
        MaterialLabel8.Size = New Size(92, 24)
        MaterialLabel8.TabIndex = 9
        MaterialLabel8.Text = "Username"
        ' 
        ' MaterialTextBox3
        ' 
        MaterialTextBox3.AnimateReadOnly = False
        MaterialTextBox3.BorderStyle = BorderStyle.None
        MaterialTextBox3.Depth = 0
        MaterialTextBox3.Font = New Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel)
        MaterialTextBox3.Hint = "Enter valid school email address"
        MaterialTextBox3.LeadingIcon = Nothing
        MaterialTextBox3.Location = New Point(1347, 300)
        MaterialTextBox3.MaxLength = 50
        MaterialTextBox3.MouseState = MaterialSkin.MouseState.OUT
        MaterialTextBox3.Multiline = False
        MaterialTextBox3.Name = "MaterialTextBox3"
        MaterialTextBox3.Size = New Size(413, 50)
        MaterialTextBox3.TabIndex = 8
        MaterialTextBox3.Text = ""
        MaterialTextBox3.TrailingIcon = Nothing
        ' 
        ' MaterialLabel7
        ' 
        MaterialLabel7.AutoSize = True
        MaterialLabel7.Depth = 0
        MaterialLabel7.Font = New Font("Roboto Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel)
        MaterialLabel7.FontType = MaterialSkin.MaterialSkinManager.fontType.H6
        MaterialLabel7.Location = New Point(1347, 250)
        MaterialLabel7.MouseState = MaterialSkin.MouseState.HOVER
        MaterialLabel7.Name = "MaterialLabel7"
        MaterialLabel7.Size = New Size(126, 24)
        MaterialLabel7.TabIndex = 7
        MaterialLabel7.Text = "Email address"
        ' 
        ' MaterialTextBox2
        ' 
        MaterialTextBox2.AnimateReadOnly = False
        MaterialTextBox2.BorderStyle = BorderStyle.None
        MaterialTextBox2.Depth = 0
        MaterialTextBox2.Font = New Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel)
        MaterialTextBox2.Hint = "Enter full name of professor"
        MaterialTextBox2.LeadingIcon = Nothing
        MaterialTextBox2.Location = New Point(1347, 174)
        MaterialTextBox2.MaxLength = 50
        MaterialTextBox2.MouseState = MaterialSkin.MouseState.OUT
        MaterialTextBox2.Multiline = False
        MaterialTextBox2.Name = "MaterialTextBox2"
        MaterialTextBox2.Size = New Size(413, 50)
        MaterialTextBox2.TabIndex = 6
        MaterialTextBox2.Text = ""
        MaterialTextBox2.TrailingIcon = Nothing
        ' 
        ' MaterialLabel6
        ' 
        MaterialLabel6.AutoSize = True
        MaterialLabel6.Depth = 0
        MaterialLabel6.Font = New Font("Roboto Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel)
        MaterialLabel6.FontType = MaterialSkin.MaterialSkinManager.fontType.H6
        MaterialLabel6.Location = New Point(1347, 124)
        MaterialLabel6.MouseState = MaterialSkin.MouseState.HOVER
        MaterialLabel6.Name = "MaterialLabel6"
        MaterialLabel6.Size = New Size(143, 24)
        MaterialLabel6.TabIndex = 5
        MaterialLabel6.Text = "Professor name"
        ' 
        ' DataGridView1
        ' 
        DataGridView1.BackgroundColor = Color.White
        DataGridView1.BorderStyle = BorderStyle.Fixed3D
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(33, 84)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersWidth = 51
        DataGridView1.RowTemplate.Height = 29
        DataGridView1.Size = New Size(1252, 768)
        DataGridView1.TabIndex = 4
        ' 
        ' MaterialLabel5
        ' 
        MaterialLabel5.AutoSize = True
        MaterialLabel5.Depth = 0
        MaterialLabel5.Font = New Font("Roboto", 24F, FontStyle.Bold, GraphicsUnit.Pixel)
        MaterialLabel5.FontType = MaterialSkin.MaterialSkinManager.fontType.H5
        MaterialLabel5.Location = New Point(1347, 28)
        MaterialLabel5.MouseState = MaterialSkin.MouseState.HOVER
        MaterialLabel5.Name = "MaterialLabel5"
        MaterialLabel5.Size = New Size(229, 29)
        MaterialLabel5.TabIndex = 3
        MaterialLabel5.Text = "Edit professor details"
        ' 
        ' MaterialTextBox1
        ' 
        MaterialTextBox1.AnimateReadOnly = False
        MaterialTextBox1.BorderStyle = BorderStyle.None
        MaterialTextBox1.Depth = 0
        MaterialTextBox1.Font = New Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel)
        MaterialTextBox1.Hint = "Search for a professor"
        MaterialTextBox1.LeadingIcon = My.Resources.Resources.magnifying_glass
        MaterialTextBox1.Location = New Point(33, 28)
        MaterialTextBox1.MaxLength = 50
        MaterialTextBox1.MouseState = MaterialSkin.MouseState.OUT
        MaterialTextBox1.Multiline = False
        MaterialTextBox1.Name = "MaterialTextBox1"
        MaterialTextBox1.Size = New Size(1252, 50)
        MaterialTextBox1.TabIndex = 0
        MaterialTextBox1.Text = ""
        MaterialTextBox1.TrailingIcon = Nothing
        ' 
        ' Students
        ' 
        Students.Controls.Add(MaterialCard10)
        Students.ImageKey = "group-fill.png"
        Students.Location = New Point(4, 39)
        Students.Name = "Students"
        Students.Size = New Size(1809, 826)
        Students.TabIndex = 2
        Students.Text = "Students"
        Students.UseVisualStyleBackColor = True
        ' 
        ' MaterialCard10
        ' 
        MaterialCard10.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        MaterialCard10.Depth = 0
        MaterialCard10.ForeColor = Color.FromArgb(CByte(222), CByte(0), CByte(0), CByte(0))
        MaterialCard10.Location = New Point(-16, -22)
        MaterialCard10.Margin = New Padding(14)
        MaterialCard10.MouseState = MaterialSkin.MouseState.HOVER
        MaterialCard10.Name = "MaterialCard10"
        MaterialCard10.Padding = New Padding(14)
        MaterialCard10.Size = New Size(1841, 902)
        MaterialCard10.TabIndex = 2
        ' 
        ' Reports
        ' 
        Reports.Controls.Add(MaterialCard11)
        Reports.ImageKey = "folder-chart-fill.png"
        Reports.Location = New Point(4, 39)
        Reports.Name = "Reports"
        Reports.Size = New Size(1809, 826)
        Reports.TabIndex = 3
        Reports.Text = "Reports"
        Reports.UseVisualStyleBackColor = True
        ' 
        ' MaterialCard11
        ' 
        MaterialCard11.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        MaterialCard11.Depth = 0
        MaterialCard11.ForeColor = Color.FromArgb(CByte(222), CByte(0), CByte(0), CByte(0))
        MaterialCard11.Location = New Point(-16, -22)
        MaterialCard11.Margin = New Padding(14)
        MaterialCard11.MouseState = MaterialSkin.MouseState.HOVER
        MaterialCard11.Name = "MaterialCard11"
        MaterialCard11.Padding = New Padding(14)
        MaterialCard11.Size = New Size(1841, 902)
        MaterialCard11.TabIndex = 2
        ' 
        ' Reasons
        ' 
        Reasons.Controls.Add(MaterialCard12)
        Reasons.ImageKey = "file-list-2-fill.png"
        Reasons.Location = New Point(4, 39)
        Reasons.Name = "Reasons"
        Reasons.Size = New Size(1809, 826)
        Reasons.TabIndex = 4
        Reasons.Text = "Reasons"
        Reasons.UseVisualStyleBackColor = True
        ' 
        ' MaterialCard12
        ' 
        MaterialCard12.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        MaterialCard12.Depth = 0
        MaterialCard12.ForeColor = Color.FromArgb(CByte(222), CByte(0), CByte(0), CByte(0))
        MaterialCard12.Location = New Point(-16, -22)
        MaterialCard12.Margin = New Padding(14)
        MaterialCard12.MouseState = MaterialSkin.MouseState.HOVER
        MaterialCard12.Name = "MaterialCard12"
        MaterialCard12.Padding = New Padding(14)
        MaterialCard12.Size = New Size(1841, 902)
        MaterialCard12.TabIndex = 2
        ' 
        ' SectionsTab
        ' 
        SectionsTab.Controls.Add(MaterialCard14)
        SectionsTab.ImageKey = "school-fill.png"
        SectionsTab.Location = New Point(4, 39)
        SectionsTab.Name = "SectionsTab"
        SectionsTab.Size = New Size(1809, 826)
        SectionsTab.TabIndex = 6
        SectionsTab.Text = "Sections"
        SectionsTab.UseVisualStyleBackColor = True
        ' 
        ' MaterialCard14
        ' 
        MaterialCard14.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        MaterialCard14.Depth = 0
        MaterialCard14.ForeColor = Color.FromArgb(CByte(222), CByte(0), CByte(0), CByte(0))
        MaterialCard14.Location = New Point(-16, -22)
        MaterialCard14.Margin = New Padding(14)
        MaterialCard14.MouseState = MaterialSkin.MouseState.HOVER
        MaterialCard14.Name = "MaterialCard14"
        MaterialCard14.Padding = New Padding(14)
        MaterialCard14.Size = New Size(1841, 902)
        MaterialCard14.TabIndex = 2
        ' 
        ' ArchiveTab
        ' 
        ArchiveTab.Controls.Add(MaterialCard15)
        ArchiveTab.ImageKey = "graduation-cap-fill (1).png"
        ArchiveTab.Location = New Point(4, 39)
        ArchiveTab.Name = "ArchiveTab"
        ArchiveTab.Size = New Size(1809, 826)
        ArchiveTab.TabIndex = 7
        ArchiveTab.Text = "Archive"
        ArchiveTab.UseVisualStyleBackColor = True
        ' 
        ' MaterialCard15
        ' 
        MaterialCard15.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        MaterialCard15.Depth = 0
        MaterialCard15.ForeColor = Color.FromArgb(CByte(222), CByte(0), CByte(0), CByte(0))
        MaterialCard15.Location = New Point(-16, -22)
        MaterialCard15.Margin = New Padding(14)
        MaterialCard15.MouseState = MaterialSkin.MouseState.HOVER
        MaterialCard15.Name = "MaterialCard15"
        MaterialCard15.Padding = New Padding(14)
        MaterialCard15.Size = New Size(1841, 902)
        MaterialCard15.TabIndex = 2
        ' 
        ' SignOutTab
        ' 
        SignOutTab.Controls.Add(MaterialCard16)
        SignOutTab.ImageKey = "logout-box-fill.png"
        SignOutTab.Location = New Point(4, 39)
        SignOutTab.Name = "SignOutTab"
        SignOutTab.Size = New Size(1809, 826)
        SignOutTab.TabIndex = 8
        SignOutTab.Text = "Sign Out"
        SignOutTab.UseVisualStyleBackColor = True
        ' 
        ' MaterialCard16
        ' 
        MaterialCard16.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        MaterialCard16.Depth = 0
        MaterialCard16.ForeColor = Color.FromArgb(CByte(222), CByte(0), CByte(0), CByte(0))
        MaterialCard16.Location = New Point(-16, -22)
        MaterialCard16.Margin = New Padding(14)
        MaterialCard16.MouseState = MaterialSkin.MouseState.HOVER
        MaterialCard16.Name = "MaterialCard16"
        MaterialCard16.Padding = New Padding(14)
        MaterialCard16.Size = New Size(1841, 902)
        MaterialCard16.TabIndex = 2
        ' 
        ' ImageList1
        ' 
        ImageList1.ColorDepth = ColorDepth.Depth32Bit
        ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), ImageListStreamer)
        ImageList1.TransparentColor = Color.Transparent
        ImageList1.Images.SetKeyName(0, "home-4-fill.png")
        ImageList1.Images.SetKeyName(1, "logout-box-fill.png")
        ImageList1.Images.SetKeyName(2, "group-fill.png")
        ImageList1.Images.SetKeyName(3, "school-fill.png")
        ImageList1.Images.SetKeyName(4, "file-list-2-fill.png")
        ImageList1.Images.SetKeyName(5, "folder-chart-fill.png")
        ImageList1.Images.SetKeyName(6, "graduation-cap-fill (1).png")
        ImageList1.Images.SetKeyName(7, "user-2-fill.png")
        ' 
        ' MaterialCard1
        ' 
        MaterialCard1.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        MaterialCard1.Controls.Add(MaterialLabel4)
        MaterialCard1.Controls.Add(MaterialLabel3)
        MaterialCard1.Controls.Add(MaterialTabControl1)
        MaterialCard1.Controls.Add(MaterialLabel2)
        MaterialCard1.Controls.Add(MaterialLabel1)
        MaterialCard1.Depth = 0
        MaterialCard1.Dock = DockStyle.Fill
        MaterialCard1.ForeColor = Color.FromArgb(CByte(222), CByte(0), CByte(0), CByte(0))
        MaterialCard1.Location = New Point(0, 24)
        MaterialCard1.Margin = New Padding(0)
        MaterialCard1.MouseState = MaterialSkin.MouseState.HOVER
        MaterialCard1.Name = "MaterialCard1"
        MaterialCard1.Padding = New Padding(50, 50, 50, 14)
        MaterialCard1.Size = New Size(1917, 1053)
        MaterialCard1.TabIndex = 0
        ' 
        ' MaterialLabel4
        ' 
        MaterialLabel4.AutoSize = True
        MaterialLabel4.Depth = 0
        MaterialLabel4.Font = New Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel)
        MaterialLabel4.Location = New Point(1683, 72)
        MaterialLabel4.MouseState = MaterialSkin.MouseState.HOVER
        MaterialLabel4.Name = "MaterialLabel4"
        MaterialLabel4.Size = New Size(115, 19)
        MaterialLabel4.TabIndex = 12
        MaterialLabel4.Text = "January 1, 2025"
        ' 
        ' MaterialLabel3
        ' 
        MaterialLabel3.AutoSize = True
        MaterialLabel3.Depth = 0
        MaterialLabel3.Font = New Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel)
        MaterialLabel3.Location = New Point(1729, 50)
        MaterialLabel3.MouseState = MaterialSkin.MouseState.HOVER
        MaterialLabel3.Name = "MaterialLabel3"
        MaterialLabel3.Size = New Size(69, 19)
        MaterialLabel3.TabIndex = 11
        MaterialLabel3.Text = "12:00 PM"
        ' 
        ' MaterialTextBox5
        ' 
        MaterialTextBox5.AnimateReadOnly = False
        MaterialTextBox5.BorderStyle = BorderStyle.None
        MaterialTextBox5.Depth = 0
        MaterialTextBox5.Font = New Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel)
        MaterialTextBox5.Hint = "Enter the password"
        MaterialTextBox5.LeadingIcon = Nothing
        MaterialTextBox5.Location = New Point(1347, 552)
        MaterialTextBox5.MaxLength = 50
        MaterialTextBox5.MouseState = MaterialSkin.MouseState.OUT
        MaterialTextBox5.Multiline = False
        MaterialTextBox5.Name = "MaterialTextBox5"
        MaterialTextBox5.Password = True
        MaterialTextBox5.Size = New Size(413, 50)
        MaterialTextBox5.TabIndex = 12
        MaterialTextBox5.Text = ""
        MaterialTextBox5.TrailingIcon = Nothing
        ' 
        ' MaterialLabel15
        ' 
        MaterialLabel15.AutoSize = True
        MaterialLabel15.Depth = 0
        MaterialLabel15.Font = New Font("Roboto Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel)
        MaterialLabel15.FontType = MaterialSkin.MaterialSkinManager.fontType.H6
        MaterialLabel15.Location = New Point(1347, 502)
        MaterialLabel15.MouseState = MaterialSkin.MouseState.HOVER
        MaterialLabel15.Name = "MaterialLabel15"
        MaterialLabel15.Size = New Size(89, 24)
        MaterialLabel15.TabIndex = 11
        MaterialLabel15.Text = "Password"
        ' 
        ' MaterialLabel16
        ' 
        MaterialLabel16.AutoSize = True
        MaterialLabel16.Depth = 0
        MaterialLabel16.Font = New Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel)
        MaterialLabel16.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1
        MaterialLabel16.Location = New Point(1347, 57)
        MaterialLabel16.MouseState = MaterialSkin.MouseState.HOVER
        MaterialLabel16.Name = "MaterialLabel16"
        MaterialLabel16.Size = New Size(162, 19)
        MaterialLabel16.TabIndex = 13
        MaterialLabel16.Text = "Add, update and delete"
        ' 
        ' ProfessorDashboard
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1920, 1080)
        Controls.Add(MaterialCard1)
        DrawerAutoShow = True
        DrawerShowIconsWhenHidden = True
        DrawerTabControl = MaterialTabControl1
        DrawerUseColors = True
        FormStyle = FormStyles.ActionBar_None
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "ProfessorDashboard"
        Padding = New Padding(0, 24, 3, 3)
        Sizable = False
        StartPosition = FormStartPosition.CenterScreen
        Text = "ProfessorDashboard"
        WindowState = FormWindowState.Maximized
        MaterialTabControl1.ResumeLayout(False)
        Dashboard.ResumeLayout(False)
        MaterialCard2.ResumeLayout(False)
        MaterialCard7.ResumeLayout(False)
        MaterialCard7.PerformLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        MaterialCard8.ResumeLayout(False)
        MaterialCard8.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        MaterialCard6.ResumeLayout(False)
        MaterialCard6.PerformLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        Professors.ResumeLayout(False)
        MaterialCard9.ResumeLayout(False)
        MaterialCard9.PerformLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        Students.ResumeLayout(False)
        Reports.ResumeLayout(False)
        Reasons.ResumeLayout(False)
        SectionsTab.ResumeLayout(False)
        ArchiveTab.ResumeLayout(False)
        SignOutTab.ResumeLayout(False)
        MaterialCard1.ResumeLayout(False)
        MaterialCard1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents MaterialLabel1 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents MaterialLabel2 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents MaterialTabControl1 As MaterialSkin.Controls.MaterialTabControl
    Friend WithEvents Dashboard As TabPage
    Friend WithEvents MaterialCard2 As MaterialSkin.Controls.MaterialCard
    Friend WithEvents MaterialCard4 As MaterialSkin.Controls.MaterialCard
    Friend WithEvents MaterialCard5 As MaterialSkin.Controls.MaterialCard
    Friend WithEvents MaterialCard7 As MaterialSkin.Controls.MaterialCard
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents MaterialLabel13 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents MaterialLabel14 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents MaterialCard8 As MaterialSkin.Controls.MaterialCard
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents MaterialLabel10 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents MaterialLabel9 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents MaterialCard6 As MaterialSkin.Controls.MaterialCard
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents MaterialLabel11 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents MaterialLabel12 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents Professors As TabPage
    Friend WithEvents Students As TabPage
    Friend WithEvents Reports As TabPage
    Friend WithEvents Reasons As TabPage
    Friend WithEvents SectionsTab As TabPage
    Friend WithEvents ArchiveTab As TabPage
    Friend WithEvents MaterialCard1 As MaterialSkin.Controls.MaterialCard
    Friend WithEvents MaterialCard3 As MaterialSkin.Controls.MaterialCard
    Friend WithEvents MaterialLabel4 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents MaterialLabel3 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents SignOutTab As TabPage
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents MaterialCard9 As MaterialSkin.Controls.MaterialCard
    Friend WithEvents MaterialCard10 As MaterialSkin.Controls.MaterialCard
    Friend WithEvents MaterialCard11 As MaterialSkin.Controls.MaterialCard
    Friend WithEvents MaterialCard12 As MaterialSkin.Controls.MaterialCard
    Friend WithEvents MaterialCard14 As MaterialSkin.Controls.MaterialCard
    Friend WithEvents MaterialCard15 As MaterialSkin.Controls.MaterialCard
    Friend WithEvents MaterialCard16 As MaterialSkin.Controls.MaterialCard
    Friend WithEvents MaterialTextBox1 As MaterialSkin.Controls.MaterialTextBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents MaterialLabel5 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents MaterialTextBox2 As MaterialSkin.Controls.MaterialTextBox
    Friend WithEvents MaterialLabel6 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents MaterialTextBox4 As MaterialSkin.Controls.MaterialTextBox
    Friend WithEvents MaterialLabel8 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents MaterialTextBox3 As MaterialSkin.Controls.MaterialTextBox
    Friend WithEvents MaterialLabel7 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents MaterialLabel16 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents MaterialTextBox5 As MaterialSkin.Controls.MaterialTextBox
    Friend WithEvents MaterialLabel15 As MaterialSkin.Controls.MaterialLabel
End Class

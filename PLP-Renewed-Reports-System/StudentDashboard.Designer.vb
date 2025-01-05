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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StudentDashboard))
        MaterialCard1 = New MaterialSkin.Controls.MaterialCard()
        MaterialCard3 = New MaterialSkin.Controls.MaterialCard()
        MaterialButton1 = New MaterialSkin.Controls.MaterialButton()
        PictureBox7 = New PictureBox()
        MaterialLabel8 = New MaterialSkin.Controls.MaterialLabel()
        MaterialLabel7 = New MaterialSkin.Controls.MaterialLabel()
        MaterialButton11 = New MaterialSkin.Controls.MaterialButton()
        MaterialLabel41 = New MaterialSkin.Controls.MaterialLabel()
        MaterialComboBox3 = New MaterialSkin.Controls.MaterialComboBox()
        MaterialComboBox2 = New MaterialSkin.Controls.MaterialComboBox()
        MaterialComboBox1 = New MaterialSkin.Controls.MaterialComboBox()
        MaterialTextBox1 = New MaterialSkin.Controls.MaterialTextBox()
        MaterialLabel6 = New MaterialSkin.Controls.MaterialLabel()
        MaterialMultiLineTextBox21 = New MaterialSkin.Controls.MaterialMultiLineTextBox2()
        MaterialCard7 = New MaterialSkin.Controls.MaterialCard()
        PictureBox3 = New PictureBox()
        MaterialLabel13 = New MaterialSkin.Controls.MaterialLabel()
        MaterialLabel14 = New MaterialSkin.Controls.MaterialLabel()
        MaterialCard6 = New MaterialSkin.Controls.MaterialCard()
        PictureBox2 = New PictureBox()
        MaterialLabel11 = New MaterialSkin.Controls.MaterialLabel()
        MaterialLabel12 = New MaterialSkin.Controls.MaterialLabel()
        MaterialCard5 = New MaterialSkin.Controls.MaterialCard()
        PictureBox1 = New PictureBox()
        MaterialLabel10 = New MaterialSkin.Controls.MaterialLabel()
        MaterialLabel9 = New MaterialSkin.Controls.MaterialLabel()
        MaterialLabel5 = New MaterialSkin.Controls.MaterialLabel()
        MaterialLabel4 = New MaterialSkin.Controls.MaterialLabel()
        MaterialLabel3 = New MaterialSkin.Controls.MaterialLabel()
        MaterialLabel2 = New MaterialSkin.Controls.MaterialLabel()
        MaterialLabel1 = New MaterialSkin.Controls.MaterialLabel()
        MaterialCard1.SuspendLayout()
        MaterialCard3.SuspendLayout()
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
        MaterialCard1.Controls.Add(MaterialCard3)
        MaterialCard1.Controls.Add(MaterialLabel8)
        MaterialCard1.Controls.Add(MaterialLabel7)
        MaterialCard1.Controls.Add(MaterialButton11)
        MaterialCard1.Controls.Add(MaterialLabel41)
        MaterialCard1.Controls.Add(MaterialComboBox3)
        MaterialCard1.Controls.Add(MaterialComboBox2)
        MaterialCard1.Controls.Add(MaterialComboBox1)
        MaterialCard1.Controls.Add(MaterialTextBox1)
        MaterialCard1.Controls.Add(MaterialLabel6)
        MaterialCard1.Controls.Add(MaterialMultiLineTextBox21)
        MaterialCard1.Controls.Add(MaterialCard7)
        MaterialCard1.Controls.Add(MaterialCard6)
        MaterialCard1.Controls.Add(MaterialCard5)
        MaterialCard1.Controls.Add(MaterialLabel5)
        MaterialCard1.Controls.Add(MaterialLabel4)
        MaterialCard1.Controls.Add(MaterialLabel3)
        MaterialCard1.Controls.Add(MaterialLabel2)
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
        ' MaterialCard3
        ' 
        MaterialCard3.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        MaterialCard3.Controls.Add(MaterialButton1)
        MaterialCard3.Controls.Add(PictureBox7)
        MaterialCard3.Depth = 0
        MaterialCard3.Dock = DockStyle.Left
        MaterialCard3.ForeColor = Color.FromArgb(CByte(222), CByte(0), CByte(0), CByte(0))
        MaterialCard3.Location = New Point(14, 14)
        MaterialCard3.Margin = New Padding(0, 0, 50, 0)
        MaterialCard3.MouseState = MaterialSkin.MouseState.HOVER
        MaterialCard3.Name = "MaterialCard3"
        MaterialCard3.Padding = New Padding(14)
        MaterialCard3.Size = New Size(250, 1025)
        MaterialCard3.TabIndex = 19
        ' 
        ' MaterialButton1
        ' 
        MaterialButton1.AutoSizeMode = AutoSizeMode.GrowAndShrink
        MaterialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Dense
        MaterialButton1.Depth = 0
        MaterialButton1.DrawShadows = False
        MaterialButton1.HighEmphasis = False
        MaterialButton1.Icon = My.Resources.Resources.log_out
        MaterialButton1.Location = New Point(68, 961)
        MaterialButton1.Margin = New Padding(4, 6, 4, 6)
        MaterialButton1.MouseState = MaterialSkin.MouseState.HOVER
        MaterialButton1.Name = "MaterialButton1"
        MaterialButton1.NoAccentTextColor = Color.Empty
        MaterialButton1.Size = New Size(115, 36)
        MaterialButton1.TabIndex = 2
        MaterialButton1.Text = "Sign Out"
        MaterialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text
        MaterialButton1.UseAccentColor = False
        MaterialButton1.UseVisualStyleBackColor = True
        ' 
        ' PictureBox7
        ' 
        PictureBox7.BackgroundImage = My.Resources.Resources.PLP_logo1
        PictureBox7.BackgroundImageLayout = ImageLayout.Zoom
        PictureBox7.Location = New Point(82, 44)
        PictureBox7.Name = "PictureBox7"
        PictureBox7.Size = New Size(87, 89)
        PictureBox7.TabIndex = 2
        PictureBox7.TabStop = False
        ' 
        ' MaterialLabel8
        ' 
        MaterialLabel8.AutoSize = True
        MaterialLabel8.Depth = 0
        MaterialLabel8.Font = New Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel)
        MaterialLabel8.Location = New Point(1715, 66)
        MaterialLabel8.MouseState = MaterialSkin.MouseState.HOVER
        MaterialLabel8.Name = "MaterialLabel8"
        MaterialLabel8.Size = New Size(115, 19)
        MaterialLabel8.TabIndex = 18
        MaterialLabel8.Text = "January 1, 2025"
        ' 
        ' MaterialLabel7
        ' 
        MaterialLabel7.AutoSize = True
        MaterialLabel7.Depth = 0
        MaterialLabel7.Font = New Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel)
        MaterialLabel7.Location = New Point(1761, 44)
        MaterialLabel7.MouseState = MaterialSkin.MouseState.HOVER
        MaterialLabel7.Name = "MaterialLabel7"
        MaterialLabel7.Size = New Size(69, 19)
        MaterialLabel7.TabIndex = 17
        MaterialLabel7.Text = "12:00 PM"
        ' 
        ' MaterialButton11
        ' 
        MaterialButton11.AutoSize = False
        MaterialButton11.AutoSizeMode = AutoSizeMode.GrowAndShrink
        MaterialButton11.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default
        MaterialButton11.Depth = 0
        MaterialButton11.HighEmphasis = True
        MaterialButton11.Icon = Nothing
        MaterialButton11.Location = New Point(1677, 971)
        MaterialButton11.Margin = New Padding(4, 6, 4, 6)
        MaterialButton11.MouseState = MaterialSkin.MouseState.HOVER
        MaterialButton11.Name = "MaterialButton11"
        MaterialButton11.NoAccentTextColor = Color.Empty
        MaterialButton11.Size = New Size(181, 45)
        MaterialButton11.TabIndex = 16
        MaterialButton11.Text = "SUBMIT"
        MaterialButton11.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
        MaterialButton11.UseAccentColor = False
        MaterialButton11.UseVisualStyleBackColor = True
        ' 
        ' MaterialLabel41
        ' 
        MaterialLabel41.AutoSize = True
        MaterialLabel41.Depth = 0
        MaterialLabel41.Font = New Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel)
        MaterialLabel41.FontType = MaterialSkin.MaterialSkinManager.fontType.Caption
        MaterialLabel41.Location = New Point(1396, 1002)
        MaterialLabel41.MouseState = MaterialSkin.MouseState.HOVER
        MaterialLabel41.Name = "MaterialLabel41"
        MaterialLabel41.Size = New Size(221, 14)
        MaterialLabel41.TabIndex = 15
        MaterialLabel41.Text = "Powered by College of Computer Studies"
        MaterialLabel41.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' MaterialComboBox3
        ' 
        MaterialComboBox3.AutoResize = False
        MaterialComboBox3.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        MaterialComboBox3.Depth = 0
        MaterialComboBox3.DrawMode = DrawMode.OwnerDrawVariable
        MaterialComboBox3.DropDownHeight = 174
        MaterialComboBox3.DropDownStyle = ComboBoxStyle.DropDownList
        MaterialComboBox3.DropDownWidth = 121
        MaterialComboBox3.Font = New Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel)
        MaterialComboBox3.ForeColor = Color.FromArgb(CByte(222), CByte(0), CByte(0), CByte(0))
        MaterialComboBox3.FormattingEnabled = True
        MaterialComboBox3.IntegralHeight = False
        MaterialComboBox3.ItemHeight = 43
        MaterialComboBox3.Location = New Point(1363, 519)
        MaterialComboBox3.MaxDropDownItems = 4
        MaterialComboBox3.MouseState = MaterialSkin.MouseState.OUT
        MaterialComboBox3.Name = "MaterialComboBox3"
        MaterialComboBox3.Size = New Size(495, 49)
        MaterialComboBox3.StartIndex = 0
        MaterialComboBox3.TabIndex = 14
        ' 
        ' MaterialComboBox2
        ' 
        MaterialComboBox2.AutoResize = False
        MaterialComboBox2.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        MaterialComboBox2.Depth = 0
        MaterialComboBox2.DrawMode = DrawMode.OwnerDrawVariable
        MaterialComboBox2.DropDownHeight = 174
        MaterialComboBox2.DropDownStyle = ComboBoxStyle.DropDownList
        MaterialComboBox2.DropDownWidth = 121
        MaterialComboBox2.Font = New Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel)
        MaterialComboBox2.ForeColor = Color.FromArgb(CByte(222), CByte(0), CByte(0), CByte(0))
        MaterialComboBox2.FormattingEnabled = True
        MaterialComboBox2.IntegralHeight = False
        MaterialComboBox2.ItemHeight = 43
        MaterialComboBox2.Location = New Point(840, 517)
        MaterialComboBox2.MaxDropDownItems = 4
        MaterialComboBox2.MouseState = MaterialSkin.MouseState.OUT
        MaterialComboBox2.Name = "MaterialComboBox2"
        MaterialComboBox2.Size = New Size(495, 49)
        MaterialComboBox2.StartIndex = 0
        MaterialComboBox2.TabIndex = 13
        ' 
        ' MaterialComboBox1
        ' 
        MaterialComboBox1.AutoResize = False
        MaterialComboBox1.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        MaterialComboBox1.Depth = 0
        MaterialComboBox1.DrawMode = DrawMode.OwnerDrawVariable
        MaterialComboBox1.DropDownHeight = 174
        MaterialComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        MaterialComboBox1.DropDownWidth = 121
        MaterialComboBox1.Font = New Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel)
        MaterialComboBox1.ForeColor = Color.FromArgb(CByte(222), CByte(0), CByte(0), CByte(0))
        MaterialComboBox1.FormattingEnabled = True
        MaterialComboBox1.IntegralHeight = False
        MaterialComboBox1.ItemHeight = 43
        MaterialComboBox1.Location = New Point(317, 575)
        MaterialComboBox1.MaxDropDownItems = 4
        MaterialComboBox1.MouseState = MaterialSkin.MouseState.OUT
        MaterialComboBox1.Name = "MaterialComboBox1"
        MaterialComboBox1.Size = New Size(495, 49)
        MaterialComboBox1.StartIndex = 0
        MaterialComboBox1.TabIndex = 12
        ' 
        ' MaterialTextBox1
        ' 
        MaterialTextBox1.AnimateReadOnly = False
        MaterialTextBox1.BorderStyle = BorderStyle.None
        MaterialTextBox1.Depth = 0
        MaterialTextBox1.Font = New Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel)
        MaterialTextBox1.Hint = "Search for a professor"
        MaterialTextBox1.LeadingIcon = Nothing
        MaterialTextBox1.Location = New Point(317, 519)
        MaterialTextBox1.MaxLength = 50
        MaterialTextBox1.MouseState = MaterialSkin.MouseState.OUT
        MaterialTextBox1.Multiline = False
        MaterialTextBox1.Name = "MaterialTextBox1"
        MaterialTextBox1.Size = New Size(495, 50)
        MaterialTextBox1.TabIndex = 11
        MaterialTextBox1.Text = ""
        MaterialTextBox1.TrailingIcon = Nothing
        ' 
        ' MaterialLabel6
        ' 
        MaterialLabel6.AutoSize = True
        MaterialLabel6.Depth = 0
        MaterialLabel6.Font = New Font("Roboto Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel)
        MaterialLabel6.FontType = MaterialSkin.MaterialSkinManager.fontType.H6
        MaterialLabel6.Location = New Point(317, 699)
        MaterialLabel6.MouseState = MaterialSkin.MouseState.HOVER
        MaterialLabel6.Name = "MaterialLabel6"
        MaterialLabel6.Size = New Size(98, 24)
        MaterialLabel6.TabIndex = 10
        MaterialLabel6.Text = "Comments"
        ' 
        ' MaterialMultiLineTextBox21
        ' 
        MaterialMultiLineTextBox21.AnimateReadOnly = False
        MaterialMultiLineTextBox21.BackgroundImageLayout = ImageLayout.None
        MaterialMultiLineTextBox21.CharacterCasing = CharacterCasing.Normal
        MaterialMultiLineTextBox21.Depth = 0
        MaterialMultiLineTextBox21.HideSelection = True
        MaterialMultiLineTextBox21.Hint = "Enter your comments, remarks or messages here (optional)"
        MaterialMultiLineTextBox21.Location = New Point(317, 761)
        MaterialMultiLineTextBox21.MaxLength = 32767
        MaterialMultiLineTextBox21.MouseState = MaterialSkin.MouseState.OUT
        MaterialMultiLineTextBox21.Name = "MaterialMultiLineTextBox21"
        MaterialMultiLineTextBox21.PasswordChar = ChrW(0)
        MaterialMultiLineTextBox21.ReadOnly = False
        MaterialMultiLineTextBox21.ScrollBars = ScrollBars.None
        MaterialMultiLineTextBox21.SelectedText = ""
        MaterialMultiLineTextBox21.SelectionLength = 0
        MaterialMultiLineTextBox21.SelectionStart = 0
        MaterialMultiLineTextBox21.ShortcutsEnabled = True
        MaterialMultiLineTextBox21.Size = New Size(1018, 255)
        MaterialMultiLineTextBox21.TabIndex = 9
        MaterialMultiLineTextBox21.TabStop = False
        MaterialMultiLineTextBox21.TextAlign = HorizontalAlignment.Left
        MaterialMultiLineTextBox21.UseSystemPasswordChar = False
        ' 
        ' MaterialCard7
        ' 
        MaterialCard7.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        MaterialCard7.Controls.Add(PictureBox3)
        MaterialCard7.Controls.Add(MaterialLabel13)
        MaterialCard7.Controls.Add(MaterialLabel14)
        MaterialCard7.Depth = 0
        MaterialCard7.ForeColor = Color.FromArgb(CByte(222), CByte(0), CByte(0), CByte(0))
        MaterialCard7.Location = New Point(1363, 182)
        MaterialCard7.Margin = New Padding(14)
        MaterialCard7.MouseState = MaterialSkin.MouseState.HOVER
        MaterialCard7.Name = "MaterialCard7"
        MaterialCard7.Padding = New Padding(30)
        MaterialCard7.Size = New Size(495, 208)
        MaterialCard7.TabIndex = 8
        ' 
        ' PictureBox3
        ' 
        PictureBox3.BackgroundImage = My.Resources.Resources.user_interface
        PictureBox3.BackgroundImageLayout = ImageLayout.Zoom
        PictureBox3.Location = New Point(395, 115)
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
        ' MaterialLabel14
        ' 
        MaterialLabel14.AutoSize = True
        MaterialLabel14.Depth = 0
        MaterialLabel14.Font = New Font("Roboto Light", 60F, FontStyle.Regular, GraphicsUnit.Pixel)
        MaterialLabel14.FontType = MaterialSkin.MaterialSkinManager.fontType.H2
        MaterialLabel14.Location = New Point(33, 51)
        MaterialLabel14.MouseState = MaterialSkin.MouseState.HOVER
        MaterialLabel14.Name = "MaterialLabel14"
        MaterialLabel14.Size = New Size(215, 72)
        MaterialLabel14.TabIndex = 5
        MaterialLabel14.Text = "BSIT-2C"
        ' 
        ' MaterialCard6
        ' 
        MaterialCard6.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        MaterialCard6.Controls.Add(PictureBox2)
        MaterialCard6.Controls.Add(MaterialLabel11)
        MaterialCard6.Controls.Add(MaterialLabel12)
        MaterialCard6.Depth = 0
        MaterialCard6.ForeColor = Color.FromArgb(CByte(222), CByte(0), CByte(0), CByte(0))
        MaterialCard6.Location = New Point(840, 182)
        MaterialCard6.Margin = New Padding(14)
        MaterialCard6.MouseState = MaterialSkin.MouseState.HOVER
        MaterialCard6.Name = "MaterialCard6"
        MaterialCard6.Padding = New Padding(30)
        MaterialCard6.Size = New Size(495, 208)
        MaterialCard6.TabIndex = 7
        ' 
        ' PictureBox2
        ' 
        PictureBox2.BackgroundImage = My.Resources.Resources.student_with_graduation_cap__1_
        PictureBox2.BackgroundImageLayout = ImageLayout.Zoom
        PictureBox2.Location = New Point(395, 115)
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
        ' MaterialLabel12
        ' 
        MaterialLabel12.AutoSize = True
        MaterialLabel12.Depth = 0
        MaterialLabel12.Font = New Font("Roboto Light", 60F, FontStyle.Regular, GraphicsUnit.Pixel)
        MaterialLabel12.FontType = MaterialSkin.MaterialSkinManager.fontType.H2
        MaterialLabel12.Location = New Point(33, 51)
        MaterialLabel12.MouseState = MaterialSkin.MouseState.HOVER
        MaterialLabel12.Name = "MaterialLabel12"
        MaterialLabel12.Size = New Size(100, 72)
        MaterialLabel12.TabIndex = 5
        MaterialLabel12.Text = "217"
        ' 
        ' MaterialCard5
        ' 
        MaterialCard5.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        MaterialCard5.Controls.Add(PictureBox1)
        MaterialCard5.Controls.Add(MaterialLabel10)
        MaterialCard5.Controls.Add(MaterialLabel9)
        MaterialCard5.Depth = 0
        MaterialCard5.ForeColor = Color.FromArgb(CByte(222), CByte(0), CByte(0), CByte(0))
        MaterialCard5.Location = New Point(317, 182)
        MaterialCard5.Margin = New Padding(14)
        MaterialCard5.MouseState = MaterialSkin.MouseState.HOVER
        MaterialCard5.Name = "MaterialCard5"
        MaterialCard5.Padding = New Padding(30)
        MaterialCard5.Size = New Size(495, 208)
        MaterialCard5.TabIndex = 6
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackgroundImage = My.Resources.Resources.manager
        PictureBox1.BackgroundImageLayout = ImageLayout.Zoom
        PictureBox1.Location = New Point(395, 113)
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
        ' MaterialLabel5
        ' 
        MaterialLabel5.AutoSize = True
        MaterialLabel5.Depth = 0
        MaterialLabel5.Font = New Font("Roboto Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel)
        MaterialLabel5.FontType = MaterialSkin.MaterialSkinManager.fontType.H6
        MaterialLabel5.Location = New Point(1363, 456)
        MaterialLabel5.MouseState = MaterialSkin.MouseState.HOVER
        MaterialLabel5.Name = "MaterialLabel5"
        MaterialLabel5.Size = New Size(150, 24)
        MaterialLabel5.TabIndex = 5
        MaterialLabel5.Text = "Year and section"
        ' 
        ' MaterialLabel4
        ' 
        MaterialLabel4.AutoSize = True
        MaterialLabel4.Depth = 0
        MaterialLabel4.Font = New Font("Roboto Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel)
        MaterialLabel4.FontType = MaterialSkin.MaterialSkinManager.fontType.H6
        MaterialLabel4.Location = New Point(840, 456)
        MaterialLabel4.MouseState = MaterialSkin.MouseState.HOVER
        MaterialLabel4.Name = "MaterialLabel4"
        MaterialLabel4.Size = New Size(77, 24)
        MaterialLabel4.TabIndex = 4
        MaterialLabel4.Text = "Reasons"
        ' 
        ' MaterialLabel3
        ' 
        MaterialLabel3.AutoSize = True
        MaterialLabel3.Depth = 0
        MaterialLabel3.Font = New Font("Roboto Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel)
        MaterialLabel3.FontType = MaterialSkin.MaterialSkinManager.fontType.H6
        MaterialLabel3.Location = New Point(317, 456)
        MaterialLabel3.MouseState = MaterialSkin.MouseState.HOVER
        MaterialLabel3.Name = "MaterialLabel3"
        MaterialLabel3.Size = New Size(98, 24)
        MaterialLabel3.TabIndex = 2
        MaterialLabel3.Text = "Professors"
        ' 
        ' MaterialLabel2
        ' 
        MaterialLabel2.AutoSize = True
        MaterialLabel2.Depth = 0
        MaterialLabel2.Font = New Font("Roboto", 34F, FontStyle.Bold, GraphicsUnit.Pixel)
        MaterialLabel2.FontType = MaterialSkin.MaterialSkinManager.fontType.H4
        MaterialLabel2.Location = New Point(317, 44)
        MaterialLabel2.MouseState = MaterialSkin.MouseState.HOVER
        MaterialLabel2.Name = "MaterialLabel2"
        MaterialLabel2.Size = New Size(338, 41)
        MaterialLabel2.TabIndex = 1
        MaterialLabel2.Text = "NAME OF T. STUDENT"
        ' 
        ' MaterialLabel1
        ' 
        MaterialLabel1.AutoSize = True
        MaterialLabel1.Depth = 0
        MaterialLabel1.Font = New Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel)
        MaterialLabel1.Location = New Point(317, 85)
        MaterialLabel1.MouseState = MaterialSkin.MouseState.HOVER
        MaterialLabel1.Name = "MaterialLabel1"
        MaterialLabel1.Size = New Size(279, 19)
        MaterialLabel1.TabIndex = 0
        MaterialLabel1.Text = "Welcome to Online Registration System"
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
        StartPosition = FormStartPosition.CenterScreen
        Text = "StudentDashboard"
        WindowState = FormWindowState.Maximized
        MaterialCard1.ResumeLayout(False)
        MaterialCard1.PerformLayout()
        MaterialCard3.ResumeLayout(False)
        MaterialCard3.PerformLayout()
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
    Friend WithEvents MaterialLabel2 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents MaterialLabel1 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents MaterialButton1 As MaterialSkin.Controls.MaterialButton
    Friend WithEvents MaterialCard5 As MaterialSkin.Controls.MaterialCard
    Friend WithEvents MaterialLabel5 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents MaterialLabel4 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents MaterialLabel3 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents MaterialCard7 As MaterialSkin.Controls.MaterialCard
    Friend WithEvents MaterialCard6 As MaterialSkin.Controls.MaterialCard
    Friend WithEvents MaterialComboBox3 As MaterialSkin.Controls.MaterialComboBox
    Friend WithEvents MaterialComboBox2 As MaterialSkin.Controls.MaterialComboBox
    Friend WithEvents MaterialComboBox1 As MaterialSkin.Controls.MaterialComboBox
    Friend WithEvents MaterialTextBox1 As MaterialSkin.Controls.MaterialTextBox
    Friend WithEvents MaterialLabel6 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents MaterialMultiLineTextBox21 As MaterialSkin.Controls.MaterialMultiLineTextBox2
    Friend WithEvents MaterialLabel41 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents MaterialLabel8 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents MaterialLabel7 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents MaterialButton11 As MaterialSkin.Controls.MaterialButton
    Friend WithEvents MaterialLabel10 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents MaterialLabel9 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents MaterialLabel13 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents MaterialLabel14 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents MaterialLabel11 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents MaterialLabel12 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents MaterialCard3 As MaterialSkin.Controls.MaterialCard
End Class

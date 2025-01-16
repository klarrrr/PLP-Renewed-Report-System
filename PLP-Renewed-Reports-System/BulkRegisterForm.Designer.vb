<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BulkRegisterForm
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
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        BulkDataGrid = New DataGridView()
        BulkClrBtn = New MaterialSkin.Controls.MaterialButton()
        BulkRegisterBtn = New MaterialSkin.Controls.MaterialButton()
        BulkUploadBtn = New MaterialSkin.Controls.MaterialButton()
        BulkCancelBtn = New MaterialSkin.Controls.MaterialButton()
        Timer1 = New Timer(components)
        CType(BulkDataGrid, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' BulkDataGrid
        ' 
        BulkDataGrid.AllowUserToAddRows = False
        BulkDataGrid.AllowUserToDeleteRows = False
        BulkDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        BulkDataGrid.BackgroundColor = Color.White
        BulkDataGrid.BorderStyle = BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = SystemColors.Control
        DataGridViewCellStyle1.Font = New Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point)
        DataGridViewCellStyle1.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle1.Padding = New Padding(15)
        DataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        BulkDataGrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        BulkDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        BulkDataGrid.Location = New Point(33, 33)
        BulkDataGrid.Name = "BulkDataGrid"
        BulkDataGrid.RowHeadersWidth = 51
        DataGridViewCellStyle2.Padding = New Padding(5)
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        BulkDataGrid.RowsDefaultCellStyle = DataGridViewCellStyle2
        BulkDataGrid.RowTemplate.Height = 29
        BulkDataGrid.Size = New Size(1030, 696)
        BulkDataGrid.TabIndex = 5
        ' 
        ' BulkClrBtn
        ' 
        BulkClrBtn.AutoSize = False
        BulkClrBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink
        BulkClrBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default
        BulkClrBtn.Depth = 0
        BulkClrBtn.HighEmphasis = True
        BulkClrBtn.Icon = My.Resources.Resources.clean
        BulkClrBtn.Location = New Point(672, 738)
        BulkClrBtn.Margin = New Padding(4, 6, 4, 6)
        BulkClrBtn.MouseState = MaterialSkin.MouseState.HOVER
        BulkClrBtn.Name = "BulkClrBtn"
        BulkClrBtn.NoAccentTextColor = Color.Empty
        BulkClrBtn.Size = New Size(40, 45)
        BulkClrBtn.TabIndex = 19
        BulkClrBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
        BulkClrBtn.UseAccentColor = False
        BulkClrBtn.UseVisualStyleBackColor = True
        ' 
        ' BulkRegisterBtn
        ' 
        BulkRegisterBtn.AutoSize = False
        BulkRegisterBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink
        BulkRegisterBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default
        BulkRegisterBtn.Depth = 0
        BulkRegisterBtn.HighEmphasis = True
        BulkRegisterBtn.Icon = Nothing
        BulkRegisterBtn.Location = New Point(942, 738)
        BulkRegisterBtn.Margin = New Padding(4, 6, 4, 6)
        BulkRegisterBtn.MouseState = MaterialSkin.MouseState.HOVER
        BulkRegisterBtn.Name = "BulkRegisterBtn"
        BulkRegisterBtn.NoAccentTextColor = Color.Empty
        BulkRegisterBtn.Size = New Size(120, 45)
        BulkRegisterBtn.TabIndex = 22
        BulkRegisterBtn.Text = "Register"
        BulkRegisterBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
        BulkRegisterBtn.UseAccentColor = False
        BulkRegisterBtn.UseVisualStyleBackColor = True
        ' 
        ' BulkUploadBtn
        ' 
        BulkUploadBtn.AutoSize = False
        BulkUploadBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink
        BulkUploadBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default
        BulkUploadBtn.Depth = 0
        BulkUploadBtn.HighEmphasis = True
        BulkUploadBtn.Icon = My.Resources.Resources.upload_big_arrow1
        BulkUploadBtn.Location = New Point(720, 738)
        BulkUploadBtn.Margin = New Padding(4, 6, 4, 6)
        BulkUploadBtn.MouseState = MaterialSkin.MouseState.HOVER
        BulkUploadBtn.Name = "BulkUploadBtn"
        BulkUploadBtn.NoAccentTextColor = Color.Empty
        BulkUploadBtn.Size = New Size(214, 45)
        BulkUploadBtn.TabIndex = 21
        BulkUploadBtn.Text = "Upload Excel"
        BulkUploadBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
        BulkUploadBtn.UseAccentColor = True
        BulkUploadBtn.UseVisualStyleBackColor = True
        ' 
        ' BulkCancelBtn
        ' 
        BulkCancelBtn.AutoSize = False
        BulkCancelBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink
        BulkCancelBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default
        BulkCancelBtn.Depth = 0
        BulkCancelBtn.HighEmphasis = True
        BulkCancelBtn.Icon = Nothing
        BulkCancelBtn.Location = New Point(33, 738)
        BulkCancelBtn.Margin = New Padding(4, 6, 4, 6)
        BulkCancelBtn.MouseState = MaterialSkin.MouseState.HOVER
        BulkCancelBtn.Name = "BulkCancelBtn"
        BulkCancelBtn.NoAccentTextColor = Color.Empty
        BulkCancelBtn.Size = New Size(120, 45)
        BulkCancelBtn.TabIndex = 20
        BulkCancelBtn.Text = "Cancel"
        BulkCancelBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
        BulkCancelBtn.UseAccentColor = False
        BulkCancelBtn.UseVisualStyleBackColor = True
        ' 
        ' Timer1
        ' 
        ' 
        ' BulkRegisterForm
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1096, 819)
        Controls.Add(BulkRegisterBtn)
        Controls.Add(BulkUploadBtn)
        Controls.Add(BulkCancelBtn)
        Controls.Add(BulkClrBtn)
        Controls.Add(BulkDataGrid)
        FormStyle = FormStyles.ActionBar_None
        Name = "BulkRegisterForm"
        Padding = New Padding(30)
        StartPosition = FormStartPosition.CenterScreen
        Text = "BulkRegisterForm"
        CType(BulkDataGrid, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents BulkDataGrid As DataGridView
    Friend WithEvents BulkClrBtn As MaterialSkin.Controls.MaterialButton
    Friend WithEvents BulkRegisterBtn As MaterialSkin.Controls.MaterialButton
    Friend WithEvents BulkUploadBtn As MaterialSkin.Controls.MaterialButton
    Friend WithEvents BulkCancelBtn As MaterialSkin.Controls.MaterialButton
    Friend WithEvents Timer1 As Timer
End Class

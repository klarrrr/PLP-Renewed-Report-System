Imports MaterialSkin
Imports MaterialSkin.Controls

Module SetTheme

    Public Sub SetFormThemeLight(Form As MaterialForm)
        Dim SkinManager As MaterialSkinManager = MaterialSkinManager.Instance
        SkinManager.AddFormToManage(Form)
        SkinManager.Theme = MaterialSkinManager.Themes.LIGHT
        SkinManager.ColorScheme = New ColorScheme(Primary.Green800, Primary.Green900, Primary.Green500, Accent.Amber700, TextShade.WHITE)
    End Sub

End Module

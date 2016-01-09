
Public Class Form1
    Dim Skin As Bitmap = My.Resources.steve
    Dim File As String
    Private Sub UpdateImage()
        Dim Image As New Bitmap(MainSkin.Width, MainSkin.Height) 'Create the skin preview bitmao
        If Not (Skin.Width = 64 AndAlso Skin.Height = 64) Then : Throw New ExSkinRes() : Exit Sub : End If 'Check the skin resolution
        '****************Writing pixels to the preview****************
        For Y As Byte = 0 To MainSkin.Height - 1
            For X As Byte = 0 To MainSkin.Width - 1
                Image.SetPixel(X, Y, Skin.GetPixel(X \ 2, Y \ 2))
            Next
        Next
        '*************************************************************
        MainSkin.Image = Image 'Apply preview
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UpdateImage() 'Load preview
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        OpenFileDialog.ShowDialog()
    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        File = "" 'Reset the File value
        Skin = My.Resources.steve 'Reset the skin value
        UpdateImage() 'Load the preview
        Text = "Minecraft Skiner" 'Reset the form text
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        If File = "" Then
            SaveFileDialog.ShowDialog() 'Show the save dialog if the file wasn't saved before
        Else
            Skin.Save(File, Imaging.ImageFormat.Png) 'If the skin was saved before save it to the last location
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        SaveFileDialog.ShowDialog()
    End Sub

    Private Sub OpenFileDialog_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog.FileOk
        File = OpenFileDialog.FileName 'Update the File value
        OpenFileDialog.FileName = "" 'Rest the FileName value
        Skin = New Bitmap(File) 'Update Skin value
        If Skin.Height = 32 Then 'If the skin was 1.7 skin then convert it to 1.8 skin
            Dim tmpSkin As Bitmap = Skin
            Skin = New Bitmap(64, 64)
            Dim g As Graphics = Graphics.FromImage(Skin)
            g.DrawImage(tmpSkin, New Rectangle(0, 0, 64, 32),
                       New Rectangle(0, 0, 64, 32),
                       GraphicsUnit.Pixel)
        End If
        UpdateImage() 'Load the preview
        Text = "Minecraft Skiner - " + IO.Path.GetFileName(File) 'Update text value
    End Sub

    Private Sub SaveFileDialog_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialog.FileOk
        Skin.Save(SaveFileDialog.FileName, Imaging.ImageFormat.Png) 'Save the skin
        File = SaveFileDialog.FileName 'Update the File value
        SaveFileDialog.FileName = "Untitled" 'Rest the FileName value
        Text = "Minecraft Skiner - " + IO.Path.GetFileName(File) 'Update text value
    End Sub

    Private Sub SaveAs17SkinToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAs17SkinToolStripMenuItem.Click
        MsgBox("You will lose the 2nd layer except the 2nd head layer", MsgBoxStyle.Exclamation, "Save") 'Warning message
        Dim tmpSkin As Bitmap = Skin 'Create temporary image
        Skin = New Bitmap(64, 32) 'Create new skin image
        Dim g As Graphics = Graphics.FromImage(Skin) 'Create garphics variable
        g.DrawImage(tmpSkin, New Rectangle(0, 0, 64, 32), New Rectangle(0, 0, 64, 32), GraphicsUnit.Pixel) 'Crop the image
        SaveFileDialog.ShowDialog() 'Open the save dialog
        Skin = tmpSkin 'Rest the skin value to 1.8 old skin
    End Sub
End Class

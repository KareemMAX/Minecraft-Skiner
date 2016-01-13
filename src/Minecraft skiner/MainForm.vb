Public Class MainForm
    Friend Skin As Bitmap = My.Resources.steve
    Friend File As String

    Friend Sub UpdateImage()
        Dim Image As New Bitmap(MainSkin.Width, MainSkin.Height) 'Create the skin preview bitmao
        If Not (Skin.Width = 64 AndAlso Skin.Height = 64) Then 'Check the skin resolution
            MsgBox("Not valid skin", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        '****************Writing pixels to the preview****************
        For Y As Byte = 0 To MainSkin.Height - 1
            For X As Byte = 0 To MainSkin.Width - 1
                Image.SetPixel(X, Y, Skin.GetPixel(X \ 2, Y \ 2))
            Next
        Next
        '*************************************************************
        MainSkin.Image = Image 'Apply preview
        Renderer2D.Skin = Skin
        Renderer2D.Refresh() 'Render
        Renderer3D.Skin = Skin
        Renderer3D.Refresh() 'Render
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UpdateImage() 'Load preview
        Renderer2D.Skin = Skin
        Renderer2D.Refresh()
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        OpenFileDialog.ShowDialog()
        Renderer2D.Skin = Skin
        Renderer2D.Refresh()
    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        File = "" 'Reset the File value
        Skin = My.Resources.steve 'Reset the skin value
        UpdateImage() 'Load the preview
        Text = "Minecraft Skiner" 'Reset the form text
        Renderer2D.Skin = Skin
        Renderer2D.Refresh()
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        If File = "" Then
            SaveFileDialog.ShowDialog() 'Show the save dialog if the file wasn't saved before
        Else
            Skin.Save(File, Imaging.ImageFormat.Png) 'If the skin was saved before save it to the last location
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        Dim Dialog As New UserNameDialog
        SaveFileDialog.ShowDialog()
    End Sub

    Private Sub OpenFileDialog_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog.FileOk
        Dim tmpFile As String = File
        Dim tmpSkin As Bitmap = Skin
        File = OpenFileDialog.FileName 'Update the File value
        OpenFileDialog.FileName = "" 'Rest the FileName value
        Skin = New Bitmap(File) 'Update Skin value
        If Skin.Height = 32 AndAlso Skin.Width = 64 Then 'If the skin was 1.7 skin then convert it to 1.8 skin
            ConvertSkin()
        ElseIf Skin.Height = 64 AndAlso Skin.Width = 64 Then 'If the skin was valid then exit If
        Else
            MsgBox("Not valid skin", MsgBoxStyle.Critical, "Error")
            Skin = tmpSkin
            File = tmpFile
            e.Cancel = True 'Prevent the dialog from close
            Exit Sub
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

    Private Sub Renderer2D1_SizeChanged(sender As Object, e As EventArgs) Handles Renderer2D.SizeChanged
        Renderer2D.Refresh()
    End Sub

    Private Sub OpenFromplayerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenFromplayerToolStripMenuItem.Click
        Dim Dialog As New UserNameDialog
        Dialog.ShowDialog()
    End Sub
    Sub ConvertSkin()
        Dim tmpSkin As Bitmap = Skin
        Skin = New Bitmap(64, 64)
        Dim g As Graphics = Graphics.FromImage(Skin)
        g.DrawImage(tmpSkin, New Rectangle(0, 0, 64, 32), New Rectangle(0, 0, 64, 32), GraphicsUnit.Pixel)
        g.DrawImage(tmpSkin, New Rectangle(16, 48, 16, 16), New Rectangle(0, 16, 16, 16), GraphicsUnit.Pixel) 'Adding the left leg
        g.DrawImage(tmpSkin, New Rectangle(32, 48, 16, 16), New Rectangle(40, 16, 16, 16), GraphicsUnit.Pixel) 'Adding the left arm
    End Sub

    Private Sub Steverdb_CheckedChanged(sender As Object, e As EventArgs) Handles Steverdb.CheckedChanged
        If Steverdb.Checked Then
            Renderer2D.Model = Renderer2D.Models.Steve
            Renderer3D.Model = Renderer3D.Models.Steve
        Else
            Renderer2D.Model = Renderer2D.Models.Alex
            Renderer3D.Model = Renderer3D.Models.Alex
        End If
        Renderer2D.Refresh()
        Renderer3D.Refresh()
    End Sub

    Private Sub Alexrdb_CheckedChanged(sender As Object, e As EventArgs) Handles Alexrdb.CheckedChanged
        If Steverdb.Checked Then
            Renderer2D.Model = Renderer2D.Models.Steve
            Renderer3D.Model = Renderer3D.Models.Steve
        Else
            Renderer2D.Model = Renderer2D.Models.Alex
            Renderer3D.Model = Renderer3D.Models.Alex
        End If
        Renderer2D.Refresh()
        Renderer3D.Refresh()
    End Sub

    Private Sub RenderSelector_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RenderSelector.SelectedIndexChanged
        If RenderSelector.SelectedIndex = 0 Then
            Renderer3D.Show()
        Else
            Renderer3D.Hide()
        End If
    End Sub
End Class

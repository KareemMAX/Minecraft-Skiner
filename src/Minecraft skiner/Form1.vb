
Public Class Form1
    Dim Skin As Bitmap = My.Resources.steve
    Dim File As String
    Private Sub UpdateImage()
        Dim Image As New Bitmap(MainSkin.Width, MainSkin.Height)
        Dim Ref As Double = MainSkin.Height / 64
        If Not (Skin.Width = 64 AndAlso Skin.Height = 64) Then : Throw New ExSkinRes() : Exit Sub : End If
        For Y As Byte = 0 To MainSkin.Height - 1
            For X As Byte = 0 To MainSkin.Width - 1
                Image.SetPixel(X, Y, Skin.GetPixel(X \ 2, Y \ 2))
            Next
        Next
        MainSkin.Image = Image
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UpdateImage()
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        OpenFileDialog.ShowDialog()
    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        File = ""
        Skin = My.Resources.steve
        UpdateImage()
        Text = "Minecraft Skiner"
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        If File = "" Then
            SaveFileDialog.ShowDialog()
        Else
            Skin.Save(File, Imaging.ImageFormat.Png)
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        SaveFileDialog.ShowDialog()
    End Sub

    Private Sub OpenFileDialog_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog.FileOk
        File = OpenFileDialog.FileName
        OpenFileDialog.FileName = ""
        Skin = New Bitmap(File)
        If Skin.Height = 32 Then
            Dim tmpSkin As Bitmap = Skin
            Skin = New Bitmap(64, 64)
            Dim g As Graphics = Graphics.FromImage(Skin)
            g.DrawImage(tmpSkin, New Rectangle(0, 0, 64, 32),
                       New Rectangle(0, 0, 64, 32),
                       GraphicsUnit.Pixel)
        End If
        UpdateImage()
        Text = "Minecraft Skiner - " + IO.Path.GetFileName(File)
    End Sub

    Private Sub SaveFileDialog_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialog.FileOk
        Skin.Save(SaveFileDialog.FileName, Imaging.ImageFormat.Png)
        File = SaveFileDialog.FileName
        SaveFileDialog.FileName = "Untitled"
        Text = "Minecraft Skiner - " + IO.Path.GetFileName(File)

    End Sub

    Private Sub SaveAs17SkinToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAs17SkinToolStripMenuItem.Click
        Dim tmpSkin As Bitmap = Skin
        Skin = New Bitmap(64, 32)
        Dim g As Graphics = Graphics.FromImage(Skin)
        g.DrawImage(tmpSkin, New Rectangle(0, 0, 64, 32),
                   New Rectangle(0, 0, 64, 32),
                   GraphicsUnit.Pixel)

        SaveFileDialog.ShowDialog()
        Skin = tmpSkin
    End Sub
End Class

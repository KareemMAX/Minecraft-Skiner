
Public Class MainForm
    Friend Skin As Bitmap = My.Resources.steve
    Friend File As String

    Friend Changed As Boolean

    Dim UndoStack As New Stack(Of Bitmap)
    Dim RedoStack As New Stack(Of Bitmap)

    Friend Sub UpdateImage()
        Dim Image As New Bitmap(MainSkin.Width, MainSkin.Height) 'Create the skin preview bitmao
        If Not (Skin.Width = 64 AndAlso Skin.Height = 64) Then 'Check the skin resolution
            MsgBox("Skin isn't valid.", MsgBoxStyle.Critical, "Error")
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
        Renderer3D.Skin = Skin
        Renderer3D.Refresh() 'Render
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Renderer3D.InDesignMode = False
        ColorPicker.InDesignMode = False
        UpdateImage() 'Load preview
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        If Changed Then
            Dim dlg As New CloseBox
            dlg.ShowDialog()
            Select Case dlg.CloseResult
                Case CloseBox.CloseBoxResult.Save
                    SaveToolStripMenuItem_Click(dlg, New EventArgs)
                Case CloseBox.CloseBoxResult.Cancel
                    Exit Sub
            End Select
        End If
        OpenFileDialog.ShowDialog()
        Changed = False
    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        If Changed Then
            Dim dlg As New CloseBox
            dlg.ShowDialog()
            Select Case dlg.CloseResult
                Case CloseBox.CloseBoxResult.Save
                    SaveToolStripMenuItem_Click(dlg, New EventArgs)
                Case CloseBox.CloseBoxResult.Cancel
                    Exit Sub
            End Select
        End If
        File = "" 'Reset the File value
        Skin = My.Resources.steve 'Reset the skin value
        UpdateImage() 'Load the preview
        Text = "Minecraft Skiner" 'Reset the form text
        Renderer3D.Skin = Skin
        Renderer3D.Refresh()
        Changed = False
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        If File = "" Then
            SaveFileDialog.ShowDialog() 'Show the save dialog if the file wasn't saved before
        Else
            Dim BitmapStream As IO.Stream = IO.File.Open(File, IO.FileMode.Open)
            Try
                Skin.Save(BitmapStream, Imaging.ImageFormat.Png) 'If the skin was saved before save it to the last location
            Catch
                MsgBox("Something wrong with saving the file, Try save as.", MsgBoxStyle.Critical, "Error!")
            Finally
                BitmapStream.Close()
            End Try
        End If
        Changed = False
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        Dim tmpSkin As Bitmap = Skin
        If ModeToolStripMenuItem.Checked Then
            Skin = Skin.Clone(New Rectangle(0, 0, 64, 32), Skin.PixelFormat)
        End If
        SaveFileDialog.ShowDialog()
        Changed = False
        If ModeToolStripMenuItem.Checked Then
            Skin = tmpSkin
        End If
    End Sub

    Private Sub OpenFileDialog_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog.FileOk
        If Changed Then
            Dim dlg As New CloseBox
            dlg.ShowDialog()
            Select Case dlg.CloseResult
                Case CloseBox.CloseBoxResult.Save
                    SaveToolStripMenuItem_Click(dlg, New EventArgs)
                Case CloseBox.CloseBoxResult.Cancel
                    Exit Sub
            End Select
        End If
        Dim tmpFile As String = File
        Dim tmpSkin As Bitmap = Skin
        File = OpenFileDialog.FileName 'Update the File value
        OpenFileDialog.FileName = "" 'Rest the FileName value
        Dim BitmapStream As IO.Stream = IO.File.Open(File, IO.FileMode.Open)
        Try
            Skin = New Bitmap(BitmapStream) 'Update Skin value
        Catch
            MsgBox("Something wrong with opening the file.", MsgBoxStyle.Critical, "Error!")
            File = tmpFile
            Skin = tmpSkin
        Finally
            BitmapStream.Close()
        End Try
        If Skin.Height = 32 AndAlso Skin.Width = 64 Then 'If the skin was 1.7 skin then convert it to 1.8 skin
            ConvertSkin()
        ElseIf Skin.Height = 64 AndAlso Skin.Width = 64 Then 'If the skin was valid then exit If
        Else
            MsgBox("Skin isn't valid.", MsgBoxStyle.Critical, "Error!")
            Skin = tmpSkin
            File = tmpFile
            e.Cancel = True 'Prevent the dialog from close
            Exit Sub
        End If
        UpdateImage() 'Load the preview
        Text = "Minecraft Skiner - " + IO.Path.GetFileName(File) 'Update text value
        Changed = False
    End Sub

    Private Sub SaveFileDialog_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialog.FileOk
        Dim tmpSkin As Bitmap = Skin
        If ModeToolStripMenuItem.Checked AndAlso SaveFileDialog.Tag <> 8 Then
            Skin = Skin.Clone(New Rectangle(0, 0, 64, 32), Skin.PixelFormat)
        End If
        Dim BitmapStream As IO.Stream = IO.File.Open(SaveFileDialog.FileName, IO.FileMode.OpenOrCreate)
        Try
            Skin.Save(BitmapStream, Imaging.ImageFormat.Png) 'Save the skin
        Catch
            MsgBox("Something wrong with saving the file.", MsgBoxStyle.Critical, "Error!")
        Finally
            BitmapStream.Close()
        End Try
        File = SaveFileDialog.FileName 'Update the File value
        SaveFileDialog.FileName = "Untitled" 'Reset the FileName value
        Text = "Minecraft Skiner - " + IO.Path.GetFileName(File) 'Update text value
        Changed = False
        If ModeToolStripMenuItem.Checked AndAlso SaveFileDialog.Tag <> 8 Then
            Skin = tmpSkin
        End If
    End Sub

    Private Sub SaveAs17SkinToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAs17SkinToolStripMenuItem.Click
        If Not ModeToolStripMenuItem.Checked Then
            Dim Dialog As New OldSkinPreview
            Dim tmpSkin As Bitmap = Skin 'Create temporary image
            Dim newSkin As New Bitmap(64, 32) 'Create new skin image
            Dim g As Graphics = Graphics.FromImage(newSkin) 'Create garphics variable
            g.DrawImage(tmpSkin, New Rectangle(0, 0, 64, 32), New Rectangle(0, 0, 64, 32), GraphicsUnit.Pixel) 'Crop the image
            Skin = newSkin
            ConvertSkin()
            Dialog.Renderer3D.InDesignMode = False
            Dialog.Renderer3D.Skin = Skin
            Dialog.ShowDialog()
            If Dialog.DialogResult = DialogResult.OK Then
                Skin = newSkin
                SaveFileDialog.ShowDialog() 'Open the save dialog
            End If
            Skin = tmpSkin 'Rest the skin value to 1.8 old skin
            Changed = False
        Else
            SaveFileDialog.Tag = 8
            SaveFileDialog.ShowDialog()
            SaveFileDialog.Tag = Nothing
            Changed = False
        End If
    End Sub

    Private Sub OpenFromplayerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenFromplayerToolStripMenuItem.Click
        If Changed Then
            Dim dlg As New CloseBox
            dlg.ShowDialog()
            Select Case dlg.CloseResult
                Case CloseBox.CloseBoxResult.Save
                    SaveToolStripMenuItem_Click(dlg, New EventArgs)
                Case CloseBox.CloseBoxResult.Cancel
                    Exit Sub
            End Select
        End If
        Dim Dialog As New UserNameDialog
        Dialog.ShowDialog()
        Changed = False
    End Sub
    Sub ConvertSkin()
        Dim tmpSkin As Bitmap = Skin
        Skin = New Bitmap(64, 64)
        Dim g As Graphics = Graphics.FromImage(Skin)
        g.DrawImage(tmpSkin, New Rectangle(0, 0, 64, 32), New Rectangle(0, 0, 64, 32), GraphicsUnit.Pixel)
        '--------------Draw the leg---------------
        g.DrawImage(tmpSkin, New Rectangle(20, 52, 8, 12), New Rectangle(8, 20, -8, 12), GraphicsUnit.Pixel)
        g.DrawImage(tmpSkin, New Rectangle(16, 52, 4, 12), New Rectangle(12, 20, -4, 12), GraphicsUnit.Pixel)
        g.DrawImage(tmpSkin, New Rectangle(28, 52, 4, 12), New Rectangle(16, 20, -4, 12), GraphicsUnit.Pixel)
        g.DrawImage(tmpSkin, New Rectangle(20, 48, 4, 4), New Rectangle(8, 16, -4, 4), GraphicsUnit.Pixel)
        g.DrawImage(tmpSkin, New Rectangle(24, 48, 4, 4), New Rectangle(12, 16, -4, 4), GraphicsUnit.Pixel)
        '--------------Draw the arm---------------
        g.DrawImage(tmpSkin, New Rectangle(36, 52, 8, 12), New Rectangle(48, 20, -8, 12), GraphicsUnit.Pixel)
        g.DrawImage(tmpSkin, New Rectangle(32, 52, 4, 12), New Rectangle(52, 20, -4, 12), GraphicsUnit.Pixel)
        g.DrawImage(tmpSkin, New Rectangle(44, 52, 4, 12), New Rectangle(56, 20, -4, 12), GraphicsUnit.Pixel)
        g.DrawImage(tmpSkin, New Rectangle(36, 48, 4, 4), New Rectangle(48, 16, -4, 4), GraphicsUnit.Pixel)
        g.DrawImage(tmpSkin, New Rectangle(40, 48, 4, 4), New Rectangle(52, 16, -4, 4), GraphicsUnit.Pixel)
    End Sub

    Sub RevertConvert()
        Dim tmpSkin As Bitmap = Skin
        Skin = New Bitmap(64, 64)
        Dim g As Graphics = Graphics.FromImage(Skin)
        g.DrawImage(tmpSkin, New Rectangle(0, 0, 64, 32), New Rectangle(0, 0, 64, 32), GraphicsUnit.Pixel)
        '--------------Draw the leg---------------
        g.DrawImage(tmpSkin, New Rectangle(8, 20, -8, 12), New Rectangle(20, 52, 8, 12), GraphicsUnit.Pixel)
        g.DrawImage(tmpSkin, New Rectangle(12, 20, -4, 12), New Rectangle(16, 52, 4, 12), GraphicsUnit.Pixel)
        g.DrawImage(tmpSkin, New Rectangle(16, 20, -4, 12), New Rectangle(28, 52, 4, 12), GraphicsUnit.Pixel)
        g.DrawImage(tmpSkin, New Rectangle(8, 16, -4, 4), New Rectangle(20, 48, 4, 4), GraphicsUnit.Pixel)
        g.DrawImage(tmpSkin, New Rectangle(12, 16, -4, 4), New Rectangle(24, 48, 4, 4), GraphicsUnit.Pixel)
        '--------------Draw the arm---------------
        g.DrawImage(tmpSkin, New Rectangle(48, 20, -8, 12), New Rectangle(36, 52, 8, 12), GraphicsUnit.Pixel)
        g.DrawImage(tmpSkin, New Rectangle(52, 20, -4, 12), New Rectangle(32, 52, 4, 12), GraphicsUnit.Pixel)
        g.DrawImage(tmpSkin, New Rectangle(56, 20, -4, 12), New Rectangle(44, 52, 4, 12), GraphicsUnit.Pixel)
        g.DrawImage(tmpSkin, New Rectangle(48, 16, -4, 4), New Rectangle(36, 48, 4, 4), GraphicsUnit.Pixel)
        g.DrawImage(tmpSkin, New Rectangle(52, 16, -4, 4), New Rectangle(40, 48, 4, 4), GraphicsUnit.Pixel)
    End Sub

    Private Sub Steverdb_CheckedChanged(sender As Object, e As EventArgs) Handles Steverdb.CheckedChanged
        If Steverdb.Checked Then
            Renderer3D.Model = Renderer3D.Models.Steve
        Else
            Renderer3D.Model = Renderer3D.Models.Alex
        End If
        Renderer3D.Refresh()
    End Sub

    Private Sub Alexrdb_CheckedChanged(sender As Object, e As EventArgs) Handles Alexrdb.CheckedChanged
        If Steverdb.Checked Then
            Renderer3D.Model = Renderer3D.Models.Steve
        Else
            Renderer3D.Model = Renderer3D.Models.Alex
        End If
        Renderer3D.Refresh()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        MsgBox("Minecraft Skiner" & vbCrLf &
               "Great tool to create Minecraft skins" & vbTab & "V" & My.Application.Info.Version.ToString,
               MsgBoxStyle.Information, "About")
    End Sub

    Private Sub WebsiteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WebsiteToolStripMenuItem.Click
        Process.Start("https://github.com/KareemMAX/Minecraft-Skiner")
    End Sub

    Private Sub BugTrackerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BugTrackerToolStripMenuItem.Click
        Dim Dialog As New BugTracker
        Dialog.ShowDialog()
    End Sub

    Private Sub ChangeYourSkinToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangeYourSkinToolStripMenuItem.Click
        Dim Dialog As New UploadingSkin
        Dialog.Skin = Skin
        Dialog.IsAlex = Alexrdb.Checked
        Dialog.ShowDialog()
    End Sub

    Private Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Changed Then
            Dim dlg As New CloseBox
            dlg.ShowDialog()
            Select Case dlg.CloseResult
                Case CloseBox.CloseBoxResult.Save
                    SaveToolStripMenuItem_Click(dlg, New EventArgs)
                Case CloseBox.CloseBoxResult.Cancel
                    Exit Sub
            End Select
        End If
    End Sub

    Private Sub Renderer3D_SkinChanged(sender As Object, IsLeft As Boolean) Handles Renderer3D.SkinChanged
        Changed = True
        If ModeToolStripMenuItem.Checked Then
            If IsLeft Then RevertConvert()
            Skin = Skin.Clone(New Rectangle(0, 0, 64, 32), Skin.PixelFormat)
            ConvertSkin()
            UpdateImage()
        End If
    End Sub

    Private Sub Renderer3D_BeginChanged(sender As Object, LastSkin As Bitmap) Handles Renderer3D.BeginChanged
        RedoStack.Clear()
        UndoStack.Push(LastSkin)
        UndoToolStripMenuItem.Enabled = True
        RedoToolStripMenuItem.Enabled = False
    End Sub

    Private Sub UndoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UndoToolStripMenuItem.Click
        Changed = True
        RedoStack.Push(Skin)
        Skin = UndoStack.Pop()
        UpdateImage()
        RedoToolStripMenuItem.Enabled = True
        If Not (UndoStack.Count > 0) Then
            UndoToolStripMenuItem.Enabled = False
        End If
    End Sub

    Private Sub RedoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RedoToolStripMenuItem.Click
        Changed = True
        UndoStack.Push(Skin)
        Skin = RedoStack.Pop()
        UpdateImage()
        UndoToolStripMenuItem.Enabled = True
        If Not (RedoStack.Count > 0) Then
            RedoToolStripMenuItem.Enabled = False
        End If
    End Sub

    Private Sub ModeToolStripMenuItem_CheckedChanged(sender As Object, e As EventArgs) Handles ModeToolStripMenuItem.CheckedChanged
        If ModeToolStripMenuItem.Checked Then
            LayerSelector.Is1point7 = True
            LayerSelector.Show2ndBody = False
            LayerSelector.Show2ndLeftArm = False
            LayerSelector.Show2ndLeftLeg = False
            LayerSelector.Show2ndRightArm = False
            LayerSelector.Show2ndRightLeg = False
            SaveAs17SkinToolStripMenuItem.Text = "Save As 1.&8 skin"
            ConvertSkin()
            UpdateImage()
        Else
            LayerSelector.Is1point7 = False
            LayerSelector.Show2ndBody = True
            LayerSelector.Show2ndLeftArm = True
            LayerSelector.Show2ndLeftLeg = True
            LayerSelector.Show2ndRightArm = True
            LayerSelector.Show2ndRightLeg = True
            SaveAs17SkinToolStripMenuItem.Text = "Save As 1.&7 skin"
        End If
        LayerSelector.Refresh()
        LayerSelector.UpdateSelectors()
    End Sub

End Class

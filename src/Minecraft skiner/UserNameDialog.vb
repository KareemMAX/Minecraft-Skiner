Imports System.Windows.Forms

Public Class UserNameDialog

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim tmpfile As String = Form1.File
        Form1.File = "https://mcapi.ca/skin/file/" + txtUsername.Text 'Update the File value
        Try
            Dim request As Net.WebRequest = Net.WebRequest.Create(Form1.File)
            Dim response As System.Net.WebResponse = request.GetResponse()
            Dim responseStream As IO.Stream = response.GetResponseStream()
            Form1.Skin = New Bitmap(responseStream) 'Update Skin value
        Catch
            MsgBox("Can't get the skin", MsgBoxStyle.Critical, "Error")
            Form1.File = tmpfile
            Exit Sub
        End Try
        If Form1.Skin.Height = 32 Then 'If the skin was 1.7 skin then convert it to 1.8 skin
            Form1.ConvertSkin()
        End If
        Form1.UpdateImage() 'Load the preview
        Text = "Minecraft Skiner - " + txtUsername.Text 'Update text value
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class

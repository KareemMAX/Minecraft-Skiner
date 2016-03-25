Imports System.ComponentModel
Imports System.Net

Public Class UploadingSkin
    Dim Finish As Boolean
    Dim URL As String
    Dim DelHash As String
    Dim NeedToFinish As Boolean
    Property Skin As Bitmap

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Abort()
        Timer.Stop()
        If Not String.IsNullOrEmpty(DelHash) Then
            Cancel_Button.Enabled = False
            Dim wc As New WebClient
            wc.Headers.Item(HttpRequestHeader.Authorization) = "Client-ID e67f1dab50a550a"
            wc.UploadValues("https://api.imgur.com/3/image/" & DelHash, "DELETE", New Specialized.NameValueCollection)
        End If
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


    Private Sub BackgroundWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker.DoWork
        Dim wc As New WebClient
        Try
            'Get the skin bytes
            Dim stream As IO.MemoryStream = New IO.MemoryStream()
            Skin.Save(stream, Imaging.ImageFormat.Png)
            Dim bytes() As Byte = stream.ToArray()
            'Add parameters and headers
            wc.Headers.Item(HttpRequestHeader.Authorization) = "Client-ID e67f1dab50a550a"
            If Newtonsoft.Json.JsonConvert.DeserializeObject(Of Credits.Credits)(wc.DownloadString("https://api.imgur.com/3/credits")).Data.ClientRemaining < 5 Then
                MsgBox("We reach the rate limit, Can't upload the skin.", MsgBoxStyle.Critical, "Rate limit")
                Exit Sub
            End If
            Dim Parameters As New Specialized.NameValueCollection
            Parameters.Add("image", Convert.ToBase64String(bytes))
            Dim responsebytes As Byte() = wc.UploadValues("https://api.imgur.com/3/image", "POST", Parameters)
            Dim responsebody As String = System.Text.Encoding.ASCII.GetString(responsebytes)
            Dim responedecode As Image.ImageRespone = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Image.ImageRespone)(responsebody)
            URL = responedecode.Data.Link
            DelHash = responedecode.Data.DeleteHash
            NeedToFinish = True
            Do Until Finish : Loop
            wc.UploadValues("https://api.imgur.com/3/image/" & responedecode.Data.DeleteHash, "DELETE", New Specialized.NameValueCollection)
        Catch ex As Exception
            MsgBox("Can't upload the skin", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles Timer.Tick
        If NeedToFinish Then
            Timer.Stop()
            Dim Dialog As New ChangeSkinWebsite
            Dialog.WebBrowser.Navigate("http://minecraft.net/profile/skin/remote?url=" & URL)
            Dialog.ShowDialog()
            Finish = True
        End If
    End Sub

    Sub Abort()
        BackgroundWorker.Dispose()
    End Sub

    Private Sub UploadingSkin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BackgroundWorker.RunWorkerAsync()
    End Sub

    Private Sub BackgroundWorker_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker.RunWorkerCompleted
        DialogResult = DialogResult.OK
        Close()
    End Sub
End Class

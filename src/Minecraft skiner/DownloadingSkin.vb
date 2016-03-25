Imports System.ComponentModel
Imports System.Net

Public Class DownloadingSkin
    Dim tmpfile As String = MainForm.File
    Dim tmptxt As String = MainForm.Text
    Dim tmpskin As Bitmap = MainForm.Skin
    Dim file As String = MainForm.File
    Dim txt As String = MainForm.Text
    Dim skin As Bitmap = MainForm.Skin
    Dim isalex As Boolean

    Property UserInput As String

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private failed As Boolean

    Private Sub BackgroundWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker.DoWork
        file = "" 'Update the File value
        Dim wc As New WebClient
        Try
            If wc.DownloadString("https://minecraft.net/haspaid.jsp?user=" + UserInput) = "false" Then
                MsgBox("Username not exist", MsgBoxStyle.Critical, "Error")
                file = tmpfile
                failed = True
                Exit Sub
            End If
            Dim request As WebRequest = WebRequest.Create("https://mcapi.ca/skin/file/" + UserInput)
            Dim response As WebResponse = request.GetResponse()
            Dim responseStream As IO.Stream = response.GetResponseStream()
            skin = New Bitmap(responseStream) 'Update Skin value
        Catch
            MsgBox("Can't get the skin", MsgBoxStyle.Critical, "Error")
            file = tmpfile
            failed = True
            Exit Sub
        End Try
        If MainForm.Skin.Height = 32 Then 'If the skin was 1.7 skin then convert it to 1.8 skin
            MainForm.ConvertSkin()
        End If
        Dim RealName As String = UserInput
        Try
            '--------------Get the UUID-----------------
            Dim UUIDJson As UUID = Newtonsoft.Json.JsonConvert.DeserializeObject(Of UUID)(
                wc.DownloadString("https://eu.mc-api.net/v3/uuid/" + UserInput))
            RealName = UUIDJson.Name
            '--------------Get Skin type----------------
            Dim tmpstr As String = wc.DownloadString("https://sessionserver.mojang.com/session/minecraft/profile/" + UUIDJson.UUID)
            Dim NameJson As Name = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Name)(tmpstr)
            Dim decoded As PropertiesDecoded = Newtonsoft.Json.JsonConvert.DeserializeObject(Of PropertiesDecoded)(
                System.Text.Encoding.ASCII.GetString(Convert.FromBase64String(NameJson.Properties(0).Value)))
            If decoded.Textures.Skin.MetaDate.Model = "slim" Then
                isalex = True
            End If
        Catch
            MsgBox("Can't get the skin info, Some times the mojang blocks the skin informations, Just try again after 10 minutes" & vbCrLf &
                   "Change the model to Alex if the skin was 3-pixel", MsgBoxStyle.Exclamation, "Error")
        End Try
        txt = "Minecraft Skiner - " + RealName  'Update text value
    End Sub

    Private Sub DownloadingSkin_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If BackgroundWorker.IsBusy Then
            Abort()
            DialogResult = System.Windows.Forms.DialogResult.Cancel
        End If
    End Sub
    Sub Abort()
        BackgroundWorker.Dispose()
        MainForm.File = tmpfile
        MainForm.Text = tmptxt
        MainForm.Skin = tmpskin
    End Sub

    Private Sub DownloadingSkin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BackgroundWorker.RunWorkerAsync()
    End Sub

    Private Sub BackgroundWorker_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker.RunWorkerCompleted
        If failed Then
            failed = False
            DialogResult = DialogResult.Cancel
            Close()
            Exit Sub
        End If
        MainForm.Skin = skin
        MainForm.Text = txt
        MainForm.File = file
        MainForm.Alexrdb.Checked = isalex
        MainForm.Steverdb.Checked = Not isalex
        If MainForm.Skin.Height = 32 Then MainForm.ConvertSkin()
        MainForm.UpdateImage() 'Load the preview
        DialogResult = DialogResult.OK
        Close()
    End Sub
End Class

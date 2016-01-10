Imports System.Net
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

        '--------------Get the UUID-----------------
        Dim UUIDrequest As HttpWebRequest = HttpWebRequest.Create(New Uri("https://api.mojang.com/users/profiles/minecraft/" + txtUsername.Text))
        UUIDrequest.Method = WebRequestMethods.Http.Get
        Dim UUIDresponse As HttpWebResponse = UUIDrequest.GetResponse()
        Dim UUIDreader As New IO.StreamReader(UUIDresponse.GetResponseStream())
        Dim UUIDResponseString As String = UUIDreader.ReadToEnd
        UUIDresponse.Close()
        Dim UUIDJson As MojangUUID = Newtonsoft.Json.JsonConvert.DeserializeObject(Of MojangUUID)(UUIDResponseString)

        '--------------Get Skin type----------------
        Dim Namerequest As HttpWebRequest = HttpWebRequest.Create(New Uri("https://mcapi.ca/name/uuid/" + UUIDJson.UUID))
        Namerequest.Method = WebRequestMethods.Http.Get
        Dim Nameresponse As HttpWebResponse = Namerequest.GetResponse()
        Dim Namereader As New IO.StreamReader(Nameresponse.GetResponseStream())
        Dim NameResponseString As String = UUIDreader.ReadToEnd
        Nameresponse.Close()
        Dim NameJson As Name = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Name)(NameResponseString)
        If NameJson.PropertiesDecoded.Textures.Skin.MetaDate = "slim" Then
            Form1.Alexrdb.Checked = True
        End If

        Form1.UpdateImage() 'Load the preview
        Form1.Text = "Minecraft Skiner - " + UUIDJson.Name 'Update text value
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class

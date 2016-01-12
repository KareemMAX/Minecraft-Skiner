﻿Imports System.ComponentModel
Imports System.Net

Public Class DownloadingSkin
    Dim tmpfile As String = Form1.File
    Dim tmptxt As String = Form1.Text
    Dim tmpskin As Bitmap = Form1.Skin
    Dim file As String
    Dim txt As String
    Dim skin As Bitmap
    Dim isalex As Boolean

    Property UserInput As New TextBox

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub BackgroundWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker.DoWork
        file = "" 'Update the File value
        Try
            Dim request As Net.WebRequest = Net.WebRequest.Create("https://mcapi.ca/skin/file/" + UserInput.Text)
            Dim response As System.Net.WebResponse = request.GetResponse()
            Dim responseStream As IO.Stream = response.GetResponseStream()
            skin = New Bitmap(responseStream) 'Update Skin value
        Catch
            MsgBox("Can't get the skin", MsgBoxStyle.Critical, "Error")
            file = tmpfile
            Exit Sub
        End Try
        If Form1.Skin.Height = 32 Then 'If the skin was 1.7 skin then convert it to 1.8 skin
            Form1.ConvertSkin()
        End If

        Try
            Dim wc As New WebClient
            '--------------Get the UUID-----------------
            Dim UUIDJson As MojangUUID = Newtonsoft.Json.JsonConvert.DeserializeObject(Of MojangUUID)(
                wc.DownloadString("https://api.mojang.com/users/profiles/minecraft/" + UserInput.Text))
            '--------------Get Skin type----------------
            Dim tmpstr As String = wc.DownloadString("https://mcapi.ca/name/uuid/" + UUIDJson.UUID)
            tmpstr = Replace(tmpstr, "[", "")
            tmpstr = Replace(tmpstr, "]", "")
            Dim NameJson As Name = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Name)(tmpstr)
            Dim decoded As PropertiesDecoded = Newtonsoft.Json.JsonConvert.DeserializeObject(Of PropertiesDecoded)(
                System.Text.Encoding.ASCII.GetString(Convert.FromBase64String(NameJson.Properties.Value)))
            If decoded.Textures.Skin.MetaDate.model = "slim" Then
                isalex = True
            End If
        Catch
            MsgBox("Can't get the skin info, Some times the mojang blocks the skin informations, Just try again after 10 minutes" & vbCrLf &
                   "Change the model to Alex if the skin was 3-pixel", MsgBoxStyle.Exclamation, "Error")
        End Try
        txt = "Minecraft Skiner - " + UserInput.Text 'Update text value
    End Sub

    Private Sub DownloadingSkin_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If BackgroundWorker.IsBusy Then
            Abort()
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        End If
    End Sub
    Sub Abort()
        BackgroundWorker.Dispose()
        Form1.File = tmpfile
        Form1.Text = tmptxt
        Form1.Skin = tmpskin
    End Sub

    Private Sub DownloadingSkin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BackgroundWorker.RunWorkerAsync()
    End Sub

    Private Sub BackgroundWorker_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker.RunWorkerCompleted
        Form1.Skin = skin
        Form1.Text = txt
        Form1.File = file
        Form1.Alexrdb.Checked = isalex
        Form1.UpdateImage() 'Load the preview
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub
End Class
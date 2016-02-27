Imports System.Net

Public Class BugTracker

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If String.IsNullOrWhiteSpace(txtTitle.Text) Then
            MsgBox("Please fill the Title field", MsgBoxStyle.Critical, "Empty fields")
            Exit Sub
        ElseIf String.IsNullOrWhiteSpace(txtDes.Text) Then
            MsgBox("Please fill the Description field", MsgBoxStyle.Critical, "Empty fields")
            Exit Sub
        ElseIf Not (txtEmail.Text Like "*@*.*" OrElse String.IsNullOrWhiteSpace(txtEmail.Text)) Then
            MsgBox("Please write a valid Email", MsgBoxStyle.Critical, "Wrong fields")
            Exit Sub
        End If

        Try
            Dim Description As String = ""
            For Each value As String In txtDes.Lines
                Description += ">" & value & vbCrLf
            Next

            Dim Issue As String
            If String.IsNullOrWhiteSpace(txtEmail.Text) Then
                Issue = "**This issue sent by the bug tracker in the app**" & vbCrLf & vbCrLf &
                "**Description :**" & vbCrLf & vbCrLf &
                Description & vbCrLf
            Else
                Issue = "**This issue sent by the bug tracker in the app**" & vbCrLf & vbCrLf &
                "**Description :**" & vbCrLf & vbCrLf &
                Description & vbCrLf &
                "**Email :** " & txtEmail.Text
            End If

            Dim wc As New WebClient()
            Dim nc As New Specialized.NameValueCollection()

            nc.Add("title", txtTitle.Text)
            nc.Add("body", Issue)
            If IsBug.Checked Then
                nc.Add("type", "bug")
            ElseIf IsFeature.Checked Then
                nc.Add("type", "Feature")
            End If

            If Not System.Text.Encoding.ASCII.GetChars(wc.UploadValues("http://minecraftskiner.esy.es/bugtracker.php", nc)) = "Done" Then
                Throw New Exception
            End If
            MsgBox("Thanks for sending this bug." & vbCrLf &
               "We will fix it as soon as we can.", MsgBoxStyle.Information, "Thanks")
        Catch
            MsgBox("Something wrong happend. Please try again later", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End Try

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub IsFeature_CheckedChanged(sender As Object, e As EventArgs) Handles IsFeature.CheckedChanged
        InfoLabel.Text = "New ideas will help us to improve our app." & vbCrLf &
            "Please tell about all stuff that you think." & vbCrLf &
            "More Information mean quick better features."
    End Sub

    Private Sub IsBug_CheckedChanged(sender As Object, e As EventArgs) Handles IsBug.CheckedChanged
        InfoLabel.Text = "We are so sorry about this bug." & vbCrLf &
            "Please tell about all stuff that you see." & vbCrLf &
            "More Information mean quick fix."
    End Sub
End Class

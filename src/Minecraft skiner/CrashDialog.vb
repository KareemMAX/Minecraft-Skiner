Imports System.Net

Public Class CrashDialog
    Property Info As ApplicationServices.UnhandledExceptionEventArgs

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If Not (txtEmail.Text Like "*@*.*" OrElse String.IsNullOrWhiteSpace(txtEmail.Text)) Then
            MsgBox("Please write a valid Email", MsgBoxStyle.Critical, "Wrong fields")
            Exit Sub
        End If
        
        Try
            Dim Description As String = ""
            For Each value As String In txtDes.Lines
                Description += ">" & value & vbCrLf
            Next

            Dim StackTrace As String = ""
            For Each value As String In Info.Exception.StackTrace.Split(vbCrLf)
                StackTrace += ">" & value & vbCrLf
            Next

            Dim Issue As String = ""
            If String.IsNullOrWhiteSpace(txtEmail.Text) AndAlso Not String.IsNullOrWhiteSpace(txtDes.Text) Then
                Issue = "**This issue sent by the bug tracker in the app**" & vbCrLf & vbCrLf &
                "**Description :**" & vbCrLf & vbCrLf &
                Description & vbCrLf & "**Type :** " & Info.Exception.GetType.FullName & vbCrLf & vbCrLf &
                "**Message :** " & Info.Exception.Message &
                vbCrLf & vbCrLf & "**Stack Trace :**" & vbCrLf & StackTrace &
                "**Help Link :** " & Info.Exception.HelpLink
            ElseIf Not String.IsNullOrWhiteSpace(txtEmail.Text) AndAlso Not String.IsNullOrWhiteSpace(txtDes.Text) Then
                Issue = "**This issue sent by the bug tracker in the app**" & vbCrLf & vbCrLf &
                "**Description :**" & vbCrLf & vbCrLf &
                Description & vbCrLf & "**Type :** " & Info.Exception.GetType.FullName & vbCrLf & vbCrLf &
                "**Message :** " & Info.Exception.Message &
                vbCrLf & vbCrLf & "**Stack Trace :**" & vbCrLf & StackTrace &
                "**Help Link :** " & Info.Exception.HelpLink & vbCrLf & vbCrLf &
                "**Email :** " & txtEmail.Text
            ElseIf Not String.IsNullOrWhiteSpace(txtEmail.Text) AndAlso String.IsNullOrWhiteSpace(txtDes.Text) Then
                Issue = "**This issue sent by the bug tracker in the app**" & vbCrLf & vbCrLf &
                "**Type :** " & Info.Exception.GetType.FullName & vbCrLf & vbCrLf &
                "**Message :** " & Info.Exception.Message &
                vbCrLf & vbCrLf & "**Stack Trace :**" & vbCrLf & StackTrace &
                "**Help Link :** " & Info.Exception.HelpLink & vbCrLf & vbCrLf &
                "**Email :** " & txtEmail.Text
            ElseIf String.IsNullOrWhiteSpace(txtEmail.Text) AndAlso String.IsNullOrWhiteSpace(txtDes.Text) Then
                Issue = "**This issue sent by the bug tracker in the app**" & vbCrLf & vbCrLf &
                "**Type :** " & Info.Exception.GetType.FullName & vbCrLf & vbCrLf &
                "**Message :** " & Info.Exception.Message &
                vbCrLf & vbCrLf & "**Stack Trace :**" & vbCrLf & StackTrace & vbCrLf &
                "**Help Link :** " & Info.Exception.HelpLink
            End If

            Dim wc As New WebClient()
            Dim nc As New Specialized.NameValueCollection()

            nc.Add("title", "Crashed with" & Info.Exception.Message)
            nc.Add("body", Issue)
            nc.Add("type", "Crash report")

            If Not System.Text.Encoding.ASCII.GetChars(wc.UploadValues("http://minecraftskiner.esy.es/bugtracker.php", nc)) = "Done" Then
                Throw New Exception
            End If
            MsgBox("Thanks for sending this bug." & vbCrLf &
               "We will fix it as soon as we can.", MsgBoxStyle.Information, "Thanks")
        Catch
            MsgBox("Something wrong happend. Please try again later", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End Try

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Report_Click(sender As Object, e As EventArgs) Handles Report.Click
        Dim Dialog As New ViewReport
        Dialog.TextBox1.Text = "Type : " & Info.Exception.GetType.FullName & vbCrLf & vbCrLf &
                "Message : " & Info.Exception.Message &
                vbCrLf & vbCrLf & "Stack Trace :" & vbCrLf & Info.Exception.StackTrace &
                "Help Link : " & Info.Exception.HelpLink
        Dialog.ShowDialog()
    End Sub
End Class

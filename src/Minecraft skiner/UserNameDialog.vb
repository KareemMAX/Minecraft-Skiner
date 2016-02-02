Imports System.ComponentModel


Public Class UserNameDialog
    Dim WithEvents dlg As New DownloadingSkin
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        dlg = New DownloadingSkin
        dlg.UserInput = txtUsername.Text
        dlg.ShowDialog()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub



    Private Sub BackgroundWorker_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs)
        dlg.Close()
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub dlg_FormClosed(sender As Object, e As FormClosedEventArgs) Handles dlg.FormClosed
        If dlg.DialogResult = DialogResult.OK Then
            Me.Close()
        End If
    End Sub

    Private Sub txtUsername_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUsername.KeyPress
        If Not (e.KeyChar = vbBack OrElse System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(),
                                                                                       "[0-z]|_") OrElse Char.IsControl(e.KeyChar)) Then
            'Stop the character from being entered into the control since it Is illegal.
            Beep()
            e.Handled = True
        End If
    End Sub

End Class

Public Class CloseBox

    Property CloseResult As CloseBoxResult

    Enum CloseBoxResult
        Save
        Discard
        Cancel
    End Enum
    Private Sub Save_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Save_Button.Click
        CloseResult = CloseBoxResult.Save
        Close()
    End Sub

    Private Sub Discard_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Discard_Button.Click
        CloseResult = CloseBoxResult.Discard
        Close()
    End Sub

    Private Sub Cancel_Button_Click(sender As Object, e As EventArgs) Handles Cancel_Button.Click
        CloseResult = CloseBoxResult.Cancel
        Close()
    End Sub
End Class

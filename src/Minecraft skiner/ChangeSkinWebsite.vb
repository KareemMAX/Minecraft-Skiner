Imports System.Windows.Forms

Public Class ChangeSkinWebsite
    Private Sub WebBrowser_Navigated(sender As Object, e As WebBrowserNavigatedEventArgs) Handles WebBrowser.Navigated
        If e.Url.AbsoluteUri = "https://minecraft.net/profile?uploadSuccess=1" Then
            Close()
        End If
        Text = WebBrowser.DocumentTitle
    End Sub
End Class

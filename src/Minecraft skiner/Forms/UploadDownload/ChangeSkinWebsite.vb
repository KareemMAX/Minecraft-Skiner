Imports System.Windows.Forms
Imports CefSharp
Imports CefSharp.WinForms

Public Class ChangeSkinWebsite
    Friend WithEvents browser As New ChromiumWebBrowser("about:blank")

    Private Sub ChangeSkinWebsite_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not CefSharp.Cef.IsInitialized Then
            CefSharp.Cef.Initialize(New CefSettings())
        End If
        Controls.Add(browser)
        browser.Dock = DockStyle.Fill
    End Sub
End Class
Imports System.Globalization
Imports System.Threading
Imports Microsoft.VisualBasic.ApplicationServices

Namespace My
    ' The following events are available for MyApplication:
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication
        Private Sub AppStart(ByVal sender As Object, ByVal e As StartupEventArgs) Handles Me.Startup
            AddHandler AppDomain.CurrentDomain.AssemblyResolve, AddressOf ResolveAssemblies
        End Sub

        Private Sub MyApplication_UnhandledException(sender As Object, e As UnhandledExceptionEventArgs)
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture
            Dim Dialog As New CrashDialog
            Dialog.Info = e
            Dialog.ShowDialog()
            End
        End Sub

        Private Function ResolveAssemblies(sender As Object, e As System.ResolveEventArgs) As Reflection.Assembly
            Dim desiredAssembly = New Reflection.AssemblyName(e.Name)

            If desiredAssembly.Name = "Newtonsoft.Json" Then
                Return Reflection.Assembly.Load(My.Resources.Newtonsoft_Json)
            ElseIf desiredAssembly.Name = "OpenTK" Then
                Return Reflection.Assembly.Load(My.Resources.OpenTK)
            ElseIf desiredAssembly.Name = "OpenTK.GLControl" Then
                Return Reflection.Assembly.Load(My.Resources.OpenTK_GLControl)
            Else
                Return Nothing
            End If
        End Function
    End Class
End Namespace

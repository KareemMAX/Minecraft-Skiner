<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Renderer3D
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.GlControl = New OpenTK.GLControl()
        Me.Timer = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'GlControl
        '
        Me.GlControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GlControl.BackColor = System.Drawing.Color.Black
        Me.GlControl.Location = New System.Drawing.Point(0, 0)
        Me.GlControl.Name = "GlControl"
        Me.GlControl.Size = New System.Drawing.Size(150, 150)
        Me.GlControl.TabIndex = 0
        Me.GlControl.VSync = True
        '
        'Timer
        '
        Me.Timer.Enabled = True
        Me.Timer.Interval = 1
        '
        'Renderer3D
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GlControl)
        Me.Name = "Renderer3D"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GlControl As OpenTK.GLControl
    Friend WithEvents Timer As Timer
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ColorPicker
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
        Me.HSV = New OpenTK.GLControl()
        Me.Hue = New OpenTK.GLControl()
        Me.Saturation = New OpenTK.GLControl()
        Me.Value = New OpenTK.GLControl()
        Me.CurrentColor = New OpenTK.GLControl()
        Me.MouseDown = New System.Windows.Forms.Timer(Me.components)
        Me.RGBHex = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Transparent = New System.Windows.Forms.PictureBox()
        CType(Me.Transparent, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'HSV
        '
        Me.HSV.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.HSV.BackColor = System.Drawing.Color.Black
        Me.HSV.Location = New System.Drawing.Point(3, 3)
        Me.HSV.Name = "HSV"
        Me.HSV.Size = New System.Drawing.Size(250, 250)
        Me.HSV.TabIndex = 0
        Me.HSV.VSync = False
        '
        'Hue
        '
        Me.Hue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Hue.BackColor = System.Drawing.Color.Black
        Me.Hue.Location = New System.Drawing.Point(31, 263)
        Me.Hue.Name = "Hue"
        Me.Hue.Size = New System.Drawing.Size(28, 217)
        Me.Hue.TabIndex = 1
        Me.Hue.VSync = False
        '
        'Saturation
        '
        Me.Saturation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Saturation.BackColor = System.Drawing.Color.Black
        Me.Saturation.Location = New System.Drawing.Point(82, 263)
        Me.Saturation.Name = "Saturation"
        Me.Saturation.Size = New System.Drawing.Size(28, 217)
        Me.Saturation.TabIndex = 2
        Me.Saturation.VSync = False
        '
        'Value
        '
        Me.Value.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Value.BackColor = System.Drawing.Color.Black
        Me.Value.Location = New System.Drawing.Point(145, 263)
        Me.Value.Name = "Value"
        Me.Value.Size = New System.Drawing.Size(28, 217)
        Me.Value.TabIndex = 3
        Me.Value.VSync = False
        '
        'CurrentColor
        '
        Me.CurrentColor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CurrentColor.BackColor = System.Drawing.Color.Black
        Me.CurrentColor.Location = New System.Drawing.Point(201, 263)
        Me.CurrentColor.Name = "CurrentColor"
        Me.CurrentColor.Size = New System.Drawing.Size(28, 217)
        Me.CurrentColor.TabIndex = 4
        Me.CurrentColor.VSync = False
        '
        'MouseDown
        '
        Me.MouseDown.Enabled = True
        Me.MouseDown.Interval = 1
        '
        'RGBHex
        '
        Me.RGBHex.Location = New System.Drawing.Point(100, 491)
        Me.RGBHex.MaxLength = 6
        Me.RGBHex.Name = "RGBHex"
        Me.RGBHex.Size = New System.Drawing.Size(52, 20)
        Me.RGBHex.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(88, 494)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(14, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "#"
        '
        'Tranparent
        '
        Me.Transparent.Image = Global.Minecraft_skiner.My.Resources.Resources.Transparent
        Me.Transparent.Location = New System.Drawing.Point(3, 3)
        Me.Transparent.Name = "Tranparent"
        Me.Transparent.Size = New System.Drawing.Size(35, 35)
        Me.Transparent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Transparent.TabIndex = 7
        Me.Transparent.TabStop = False
        '
        'ColorPicker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Transparent)
        Me.Controls.Add(Me.RGBHex)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CurrentColor)
        Me.Controls.Add(Me.Value)
        Me.Controls.Add(Me.Saturation)
        Me.Controls.Add(Me.Hue)
        Me.Controls.Add(Me.HSV)
        Me.Name = "ColorPicker"
        Me.Size = New System.Drawing.Size(257, 521)
        CType(Me.Transparent, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents HSV As OpenTK.GLControl
    Friend WithEvents Hue As OpenTK.GLControl
    Friend WithEvents Saturation As OpenTK.GLControl
    Friend WithEvents Value As OpenTK.GLControl
    Friend WithEvents CurrentColor As OpenTK.GLControl
    Friend WithEvents MouseDown As Timer
    Friend WithEvents RGBHex As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Transparent As PictureBox
End Class

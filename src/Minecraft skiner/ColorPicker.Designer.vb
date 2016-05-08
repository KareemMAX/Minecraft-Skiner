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
        Me.HSV = New OpenTK.GLControl(New OpenTK.Graphics.GraphicsMode(32, 16, 8, 16))
        Me.Hue = New OpenTK.GLControl()
        Me.Saturation = New OpenTK.GLControl()
        Me.Value = New OpenTK.GLControl()
        Me.CurrentColor = New OpenTK.GLControl()
        Me.timMouseDown = New System.Windows.Forms.Timer(Me.components)
        Me.RGBHex = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Camo = New System.Windows.Forms.PictureBox()
        Me.Mirror = New System.Windows.Forms.PictureBox()
        Me.Fill = New System.Windows.Forms.PictureBox()
        Me.Size3 = New System.Windows.Forms.PictureBox()
        Me.Size2 = New System.Windows.Forms.PictureBox()
        Me.Size1 = New System.Windows.Forms.PictureBox()
        Me.ColorPick = New System.Windows.Forms.PictureBox()
        Me.Transparent = New System.Windows.Forms.PictureBox()
        CType(Me.Camo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Mirror, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Fill, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Size3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Size2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Size1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ColorPick, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Hue.Location = New System.Drawing.Point(31, 299)
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
        Me.Saturation.Location = New System.Drawing.Point(82, 299)
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
        Me.Value.Location = New System.Drawing.Point(145, 299)
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
        Me.CurrentColor.Location = New System.Drawing.Point(201, 299)
        Me.CurrentColor.Name = "CurrentColor"
        Me.CurrentColor.Size = New System.Drawing.Size(28, 217)
        Me.CurrentColor.TabIndex = 4
        Me.CurrentColor.VSync = False
        '
        'timMouseDown
        '
        Me.timMouseDown.Enabled = True
        Me.timMouseDown.Interval = 1
        '
        'RGBHex
        '
        Me.RGBHex.Location = New System.Drawing.Point(99, 529)
        Me.RGBHex.MaxLength = 6
        Me.RGBHex.Name = "RGBHex"
        Me.RGBHex.Size = New System.Drawing.Size(52, 20)
        Me.RGBHex.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(87, 532)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(15, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "#"
        '
        'Camo
        '
        Me.Camo.Image = Global.Minecraft_skiner.My.Resources.Resources.CamoEffect
        Me.Camo.Location = New System.Drawing.Point(214, 258)
        Me.Camo.Name = "Camo"
        Me.Camo.Size = New System.Drawing.Size(35, 35)
        Me.Camo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Camo.TabIndex = 14
        Me.Camo.TabStop = False
        Me.Camo.Visible = False
        '
        'Mirror
        '
        Me.Mirror.Image = Global.Minecraft_skiner.My.Resources.Resources.MirrorEffect
        Me.Mirror.Location = New System.Drawing.Point(173, 258)
        Me.Mirror.Name = "Mirror"
        Me.Mirror.Size = New System.Drawing.Size(35, 35)
        Me.Mirror.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Mirror.TabIndex = 13
        Me.Mirror.TabStop = False
        Me.Mirror.Visible = False
        '
        'Fill
        '
        Me.Fill.Image = Global.Minecraft_skiner.My.Resources.Resources.FillBucket
        Me.Fill.Location = New System.Drawing.Point(132, 258)
        Me.Fill.Name = "Fill"
        Me.Fill.Size = New System.Drawing.Size(35, 35)
        Me.Fill.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Fill.TabIndex = 12
        Me.Fill.TabStop = False
        '
        'Size3
        '
        Me.Size3.Image = Global.Minecraft_skiner.My.Resources.Resources.Size3
        Me.Size3.Location = New System.Drawing.Point(91, 258)
        Me.Size3.Name = "Size3"
        Me.Size3.Size = New System.Drawing.Size(35, 35)
        Me.Size3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Size3.TabIndex = 11
        Me.Size3.TabStop = False
        Me.Size3.Tag = "3"
        '
        'Size2
        '
        Me.Size2.Image = Global.Minecraft_skiner.My.Resources.Resources.Size2
        Me.Size2.Location = New System.Drawing.Point(50, 258)
        Me.Size2.Name = "Size2"
        Me.Size2.Size = New System.Drawing.Size(35, 35)
        Me.Size2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Size2.TabIndex = 10
        Me.Size2.TabStop = False
        Me.Size2.Tag = "2"
        '
        'Size1
        '
        Me.Size1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Size1.Image = Global.Minecraft_skiner.My.Resources.Resources.Size1
        Me.Size1.Location = New System.Drawing.Point(9, 258)
        Me.Size1.Name = "Size1"
        Me.Size1.Size = New System.Drawing.Size(35, 35)
        Me.Size1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Size1.TabIndex = 9
        Me.Size1.TabStop = False
        Me.Size1.Tag = "1"
        '
        'ColorPick
        '
        Me.ColorPick.Image = Global.Minecraft_skiner.My.Resources.Resources.ColorPicker
        Me.ColorPick.Location = New System.Drawing.Point(218, 3)
        Me.ColorPick.Name = "ColorPick"
        Me.ColorPick.Size = New System.Drawing.Size(35, 35)
        Me.ColorPick.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ColorPick.TabIndex = 8
        Me.ColorPick.TabStop = False
        '
        'Transparent
        '
        Me.Transparent.Image = Global.Minecraft_skiner.My.Resources.Resources.Transparent
        Me.Transparent.Location = New System.Drawing.Point(3, 3)
        Me.Transparent.Name = "Transparent"
        Me.Transparent.Size = New System.Drawing.Size(35, 35)
        Me.Transparent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Transparent.TabIndex = 7
        Me.Transparent.TabStop = False
        '
        'ColorPicker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Camo)
        Me.Controls.Add(Me.Mirror)
        Me.Controls.Add(Me.Fill)
        Me.Controls.Add(Me.Size3)
        Me.Controls.Add(Me.Size2)
        Me.Controls.Add(Me.Size1)
        Me.Controls.Add(Me.ColorPick)
        Me.Controls.Add(Me.Transparent)
        Me.Controls.Add(Me.RGBHex)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CurrentColor)
        Me.Controls.Add(Me.Value)
        Me.Controls.Add(Me.Saturation)
        Me.Controls.Add(Me.Hue)
        Me.Controls.Add(Me.HSV)
        Me.Name = "ColorPicker"
        Me.Size = New System.Drawing.Size(257, 557)
        CType(Me.Camo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Mirror, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Fill, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Size3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Size2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Size1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ColorPick, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Transparent, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents HSV As OpenTK.GLControl
    Friend WithEvents Hue As OpenTK.GLControl
    Friend WithEvents Saturation As OpenTK.GLControl
    Friend WithEvents Value As OpenTK.GLControl
    Friend WithEvents CurrentColor As OpenTK.GLControl
    Friend WithEvents timMouseDown As Timer
    Friend WithEvents RGBHex As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Transparent As PictureBox
    Friend WithEvents ColorPick As PictureBox
    Friend WithEvents Size1 As PictureBox
    Friend WithEvents Size2 As PictureBox
    Friend WithEvents Size3 As PictureBox
    Friend WithEvents Fill As PictureBox
    Friend WithEvents Mirror As PictureBox
    Friend WithEvents Camo As PictureBox
End Class

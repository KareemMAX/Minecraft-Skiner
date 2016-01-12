<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFromplayerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveAs17SkinToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Alexrdb = New System.Windows.Forms.RadioButton()
        Me.Steverdb = New System.Windows.Forms.RadioButton()
        Me.MainSkin = New System.Windows.Forms.PictureBox()
        Me.RenderSelector = New System.Windows.Forms.ComboBox()
        Me.Renderer3D = New Minecraft_skiner.Renderer3D()
        Me.LayerSelector1 = New Minecraft_skiner.LayerSelector()
        Me.Renderer2D = New Minecraft_skiner.Renderer2D()
        Me.MenuStrip.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.MainSkin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(767, 24)
        Me.MenuStrip.TabIndex = 1
        Me.MenuStrip.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.OpenToolStripMenuItem, Me.OpenFromplayerToolStripMenuItem, Me.SaveToolStripMenuItem, Me.SaveAsToolStripMenuItem, Me.SaveAs17SkinToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.NewToolStripMenuItem.Text = "&New"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.OpenToolStripMenuItem.Text = "&Open"
        '
        'OpenFromplayerToolStripMenuItem
        '
        Me.OpenFromplayerToolStripMenuItem.Name = "OpenFromplayerToolStripMenuItem"
        Me.OpenFromplayerToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.OpenFromplayerToolStripMenuItem.Text = "Open from &player"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.SaveToolStripMenuItem.Text = "&Save"
        '
        'SaveAsToolStripMenuItem
        '
        Me.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem"
        Me.SaveAsToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.SaveAsToolStripMenuItem.Text = "Save &As"
        '
        'SaveAs17SkinToolStripMenuItem
        '
        Me.SaveAs17SkinToolStripMenuItem.Name = "SaveAs17SkinToolStripMenuItem"
        Me.SaveAs17SkinToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.SaveAs17SkinToolStripMenuItem.Text = "Save As 1.&7 skin"
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.Filter = "Png file (*.png)|*.png"
        Me.OpenFileDialog.RestoreDirectory = True
        Me.OpenFileDialog.Title = "Open Skin"
        '
        'SaveFileDialog
        '
        Me.SaveFileDialog.FileName = "Untitled"
        Me.SaveFileDialog.Filter = "Png file (*.png)|*.png"
        Me.SaveFileDialog.RestoreDirectory = True
        Me.SaveFileDialog.Title = "Save skin"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Alexrdb)
        Me.GroupBox1.Controls.Add(Me.Steverdb)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 161)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(128, 70)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Model"
        '
        'Alexrdb
        '
        Me.Alexrdb.AutoSize = True
        Me.Alexrdb.Location = New System.Drawing.Point(6, 42)
        Me.Alexrdb.Name = "Alexrdb"
        Me.Alexrdb.Size = New System.Drawing.Size(46, 17)
        Me.Alexrdb.TabIndex = 1
        Me.Alexrdb.TabStop = True
        Me.Alexrdb.Text = "Alex"
        Me.Alexrdb.UseVisualStyleBackColor = True
        '
        'Steverdb
        '
        Me.Steverdb.AutoSize = True
        Me.Steverdb.Checked = True
        Me.Steverdb.Location = New System.Drawing.Point(6, 19)
        Me.Steverdb.Name = "Steverdb"
        Me.Steverdb.Size = New System.Drawing.Size(53, 17)
        Me.Steverdb.TabIndex = 0
        Me.Steverdb.TabStop = True
        Me.Steverdb.Text = "Steve"
        Me.Steverdb.UseVisualStyleBackColor = True
        '
        'MainSkin
        '
        Me.MainSkin.Image = CType(resources.GetObject("MainSkin.Image"), System.Drawing.Image)
        Me.MainSkin.Location = New System.Drawing.Point(12, 27)
        Me.MainSkin.Name = "MainSkin"
        Me.MainSkin.Size = New System.Drawing.Size(128, 128)
        Me.MainSkin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.MainSkin.TabIndex = 6
        Me.MainSkin.TabStop = False
        '
        'RenderSelector
        '
        Me.RenderSelector.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RenderSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.RenderSelector.FormattingEnabled = True
        Me.RenderSelector.ItemHeight = 13
        Me.RenderSelector.Items.AddRange(New Object() {"3D Render", "2D Render"})
        Me.RenderSelector.Location = New System.Drawing.Point(595, 27)
        Me.RenderSelector.Name = "RenderSelector"
        Me.RenderSelector.Size = New System.Drawing.Size(160, 21)
        Me.RenderSelector.TabIndex = 9
        Me.RenderSelector.SelectedIndex = 0
        '
        'Renderer3D
        '
        Me.Renderer3D.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Renderer3D.Location = New System.Drawing.Point(173, 27)
        Me.Renderer3D.Model = Minecraft_skiner.Renderer3D.Models.Steve
        Me.Renderer3D.Name = "Renderer3D"
        Me.Renderer3D.Show2ndBody = True
        Me.Renderer3D.Show2ndHead = True
        Me.Renderer3D.Show2ndLeftArm = True
        Me.Renderer3D.Show2ndLeftLeg = True
        Me.Renderer3D.Show2ndRightArm = True
        Me.Renderer3D.Show2ndRightLeg = True
        Me.Renderer3D.ShowBody = True
        Me.Renderer3D.ShowHead = True
        Me.Renderer3D.ShowLeftArm = True
        Me.Renderer3D.ShowLeftLeg = True
        Me.Renderer3D.ShowRightArm = True
        Me.Renderer3D.ShowRightLeg = True
        Me.Renderer3D.Size = New System.Drawing.Size(416, 314)
        Me.Renderer3D.Skin = Global.Minecraft_skiner.My.Resources.Resources.steve
        Me.Renderer3D.TabIndex = 8
        '
        'LayerSelector1
        '
        Me.LayerSelector1._2DRenderer = Me.Renderer2D
        Me.LayerSelector1._3DRenderer = Me.Renderer3D
        Me.LayerSelector1.Location = New System.Drawing.Point(12, 237)
        Me.LayerSelector1.Name = "LayerSelector1"
        Me.LayerSelector1.Show2ndBody = True
        Me.LayerSelector1.Show2ndHead = True
        Me.LayerSelector1.Show2ndLeftArm = True
        Me.LayerSelector1.Show2ndLeftLeg = True
        Me.LayerSelector1.Show2ndRightArm = True
        Me.LayerSelector1.Show2ndRightLeg = True
        Me.LayerSelector1.ShowBody = True
        Me.LayerSelector1.ShowHead = True
        Me.LayerSelector1.ShowLeftArm = True
        Me.LayerSelector1.ShowLeftLeg = True
        Me.LayerSelector1.ShowRightArm = True
        Me.LayerSelector1.ShowRightLeg = True
        Me.LayerSelector1.Size = New System.Drawing.Size(120, 120)
        Me.LayerSelector1.TabIndex = 7
        '
        'Renderer2D
        '
        Me.Renderer2D.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Renderer2D.BackColor = System.Drawing.Color.White
        Me.Renderer2D.Location = New System.Drawing.Point(173, 27)
        Me.Renderer2D.Model = Minecraft_skiner.Renderer2D.Models.Steve
        Me.Renderer2D.Name = "Renderer2D"
        Me.Renderer2D.Show2ndBody = True
        Me.Renderer2D.Show2ndHead = True
        Me.Renderer2D.Show2ndLeftArm = True
        Me.Renderer2D.Show2ndLeftLeg = True
        Me.Renderer2D.Show2ndRightArm = True
        Me.Renderer2D.Show2ndRightLeg = True
        Me.Renderer2D.ShowBody = True
        Me.Renderer2D.ShowHead = True
        Me.Renderer2D.ShowLeftArm = True
        Me.Renderer2D.ShowLeftLeg = True
        Me.Renderer2D.ShowRightArm = True
        Me.Renderer2D.ShowRightLeg = True
        Me.Renderer2D.Size = New System.Drawing.Size(416, 314)
        Me.Renderer2D.Skin = CType(resources.GetObject("Renderer2D.Skin"), System.Drawing.Bitmap)
        Me.Renderer2D.TabIndex = 4
        Me.Renderer2D.ViewPortAngle = Minecraft_skiner.Renderer2D.Angles.Normal
        Me.Renderer2D.ViewPortSide = Minecraft_skiner.Renderer2D.Sides.Front
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(767, 353)
        Me.Controls.Add(Me.RenderSelector)
        Me.Controls.Add(Me.Renderer3D)
        Me.Controls.Add(Me.LayerSelector1)
        Me.Controls.Add(Me.MainSkin)
        Me.Controls.Add(Me.Renderer2D)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip)
        Me.MainMenuStrip = Me.MenuStrip
        Me.MinimumSize = New System.Drawing.Size(16, 279)
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Minecraft Skiner"
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.MainSkin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveAsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenFileDialog As OpenFileDialog
    Friend WithEvents NewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveFileDialog As SaveFileDialog
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Alexrdb As RadioButton
    Friend WithEvents Steverdb As RadioButton
    Friend WithEvents SaveAs17SkinToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Renderer2D As Renderer2D
    Friend WithEvents MainSkin As PictureBox
    Friend WithEvents OpenFromplayerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LayerSelector1 As LayerSelector
    Friend WithEvents Renderer3D As Renderer3D
    Friend WithEvents RenderSelector As ComboBox
End Class

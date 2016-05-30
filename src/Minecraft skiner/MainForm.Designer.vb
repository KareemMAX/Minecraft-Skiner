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
        Me.ChangeYourSkinToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UndoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RedoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WebsiteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BugTrackerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Alexrdb = New System.Windows.Forms.RadioButton()
        Me.Steverdb = New System.Windows.Forms.RadioButton()
        Me.ColorPicker = New Minecraft_skiner.ColorPicker()
        Me.LayerSelector = New Minecraft_skiner.LayerSelector()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Renderer3D = New Minecraft_skiner.Renderer3D()
        Me.MainSkin = New System.Windows.Forms.PictureBox()
        Me.MenuStrip.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.MainSkin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(1036, 24)
        Me.MenuStrip.TabIndex = 1
        Me.MenuStrip.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.OpenToolStripMenuItem, Me.OpenFromplayerToolStripMenuItem, Me.SaveToolStripMenuItem, Me.SaveAsToolStripMenuItem, Me.SaveAs17SkinToolStripMenuItem, Me.ChangeYourSkinToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(242, 22)
        Me.NewToolStripMenuItem.Text = "&New"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(242, 22)
        Me.OpenToolStripMenuItem.Text = "&Open"
        '
        'OpenFromplayerToolStripMenuItem
        '
        Me.OpenFromplayerToolStripMenuItem.Name = "OpenFromplayerToolStripMenuItem"
        Me.OpenFromplayerToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.OpenFromplayerToolStripMenuItem.Size = New System.Drawing.Size(242, 22)
        Me.OpenFromplayerToolStripMenuItem.Text = "Open from &player"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(242, 22)
        Me.SaveToolStripMenuItem.Text = "&Save"
        '
        'SaveAsToolStripMenuItem
        '
        Me.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem"
        Me.SaveAsToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveAsToolStripMenuItem.Size = New System.Drawing.Size(242, 22)
        Me.SaveAsToolStripMenuItem.Text = "Save &As"
        '
        'SaveAs17SkinToolStripMenuItem
        '
        Me.SaveAs17SkinToolStripMenuItem.Name = "SaveAs17SkinToolStripMenuItem"
        Me.SaveAs17SkinToolStripMenuItem.Size = New System.Drawing.Size(242, 22)
        Me.SaveAs17SkinToolStripMenuItem.Text = "Save As 1.&7 skin"
        '
        'ChangeYourSkinToolStripMenuItem
        '
        Me.ChangeYourSkinToolStripMenuItem.Name = "ChangeYourSkinToolStripMenuItem"
        Me.ChangeYourSkinToolStripMenuItem.Size = New System.Drawing.Size(242, 22)
        Me.ChangeYourSkinToolStripMenuItem.Text = "&Change your skin"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UndoToolStripMenuItem, Me.RedoToolStripMenuItem, Me.ToolStripSeparator1, Me.ModeToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.EditToolStripMenuItem.Text = "&Edit"
        '
        'UndoToolStripMenuItem
        '
        Me.UndoToolStripMenuItem.Enabled = False
        Me.UndoToolStripMenuItem.Name = "UndoToolStripMenuItem"
        Me.UndoToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
        Me.UndoToolStripMenuItem.Text = "&Undo"
        '
        'RedoToolStripMenuItem
        '
        Me.RedoToolStripMenuItem.Enabled = False
        Me.RedoToolStripMenuItem.Name = "RedoToolStripMenuItem"
        Me.RedoToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
        Me.RedoToolStripMenuItem.Text = "&Redo"
        '
        'ModeToolStripMenuItem
        '
        Me.ModeToolStripMenuItem.CheckOnClick = True
        Me.ModeToolStripMenuItem.Name = "ModeToolStripMenuItem"
        Me.ModeToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
        Me.ModeToolStripMenuItem.Text = "1.7 &Mode"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem, Me.WebsiteToolStripMenuItem, Me.BugTrackerToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "&Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.AboutToolStripMenuItem.Text = "&About"
        '
        'WebsiteToolStripMenuItem
        '
        Me.WebsiteToolStripMenuItem.Name = "WebsiteToolStripMenuItem"
        Me.WebsiteToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.WebsiteToolStripMenuItem.Text = "&Website"
        '
        'BugTrackerToolStripMenuItem
        '
        Me.BugTrackerToolStripMenuItem.Name = "BugTrackerToolStripMenuItem"
        Me.BugTrackerToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.BugTrackerToolStripMenuItem.Text = "&Bug tracker"
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
        'ColorPicker
        '
        Me.ColorPicker.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ColorPicker.BrushSize = CType(1, Byte)
        Me.ColorPicker.Color = System.Drawing.Color.Red
        Me.ColorPicker.InDesignMode = True
        Me.ColorPicker.IsFilling = False
        Me.ColorPicker.IsPicking = False
        Me.ColorPicker.Location = New System.Drawing.Point(768, 27)
        Me.ColorPicker.Name = "ColorPicker"
        Me.ColorPicker.Size = New System.Drawing.Size(257, 557)
        Me.ColorPicker.TabIndex = 9
        '
        'LayerSelector
        '
        Me.LayerSelector._3DRenderer = Me.Renderer3D
        Me.LayerSelector.Is1point7 = False
        Me.LayerSelector.Location = New System.Drawing.Point(12, 237)
        Me.LayerSelector.Name = "LayerSelector"
        Me.LayerSelector.Show2ndBody = True
        Me.LayerSelector.Show2ndHead = True
        Me.LayerSelector.Show2ndLeftArm = True
        Me.LayerSelector.Show2ndLeftLeg = True
        Me.LayerSelector.Show2ndRightArm = True
        Me.LayerSelector.Show2ndRightLeg = True
        Me.LayerSelector.ShowBody = True
        Me.LayerSelector.ShowHead = True
        Me.LayerSelector.ShowLeftArm = True
        Me.LayerSelector.ShowLeftLeg = True
        Me.LayerSelector.ShowRightArm = True
        Me.LayerSelector.ShowRightLeg = True
        Me.LayerSelector.Size = New System.Drawing.Size(120, 120)
        Me.LayerSelector.TabIndex = 7
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(120, 6)
        '
        'Renderer3D
        '
        Me.Renderer3D.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Renderer3D.BackColor = System.Drawing.Color.White
        Me.Renderer3D.ColorPicker = Me.ColorPicker
        Me.Renderer3D.InDesignMode = True
        Me.Renderer3D.Location = New System.Drawing.Point(173, 27)
        Me.Renderer3D.LookX = 0R
        Me.Renderer3D.LookY = 0R
        Me.Renderer3D.Model = Minecraft_skiner.Renderer3D.Models.Steve
        Me.Renderer3D.Name = "Renderer3D"
        Me.Renderer3D.Paintable = True
        Me.Renderer3D.RotationX = 0
        Me.Renderer3D.RotationY = 0
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
        Me.Renderer3D.Size = New System.Drawing.Size(589, 607)
        Me.Renderer3D.Skin = Global.Minecraft_skiner.My.Resources.Resources.steve
        Me.Renderer3D.TabIndex = 8
        Me.Renderer3D.Zoom = 1.0R
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
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1036, 646)
        Me.Controls.Add(Me.ColorPicker)
        Me.Controls.Add(Me.Renderer3D)
        Me.Controls.Add(Me.LayerSelector)
        Me.Controls.Add(Me.MainSkin)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip
        Me.MinimumSize = New System.Drawing.Size(16, 389)
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
    Friend WithEvents MainSkin As PictureBox
    Friend WithEvents OpenFromplayerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LayerSelector As LayerSelector
    Friend WithEvents Renderer3D As Renderer3D
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WebsiteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BugTrackerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ColorPicker As ColorPicker
    Friend WithEvents ChangeYourSkinToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UndoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RedoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ModeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
End Class

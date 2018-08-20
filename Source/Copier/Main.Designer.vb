<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.OptionPanel1 = New System.Windows.Forms.Panel()
        Me.MainContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AutomaticCheckSizeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddCopierToRightClickContextMenuOfWindowsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CheckForUpdatesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EndToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TotalSizeLabel = New System.Windows.Forms.Label()
        Me.checksizemanual = New System.Windows.Forms.Button()
        Me.TransparencyLevel = New System.Windows.Forms.Label()
        Me.TransparencyLabelHead = New System.Windows.Forms.Label()
        Me.TansparencyTrackBar = New System.Windows.Forms.TrackBar()
        Me.checkclipboard = New System.Windows.Forms.CheckBox()
        Me.alwaysontopcheck = New System.Windows.Forms.CheckBox()
        Me.CopyButton = New System.Windows.Forms.Button()
        Me.MenuButton = New System.Windows.Forms.PictureBox()
        Me.TopPanel1 = New System.Windows.Forms.Panel()
        Me.StatusLabel = New System.Windows.Forms.Label()
        Me.MaximizeButton = New System.Windows.Forms.PictureBox()
        Me.MinimizeButton = New System.Windows.Forms.PictureBox()
        Me.EndButton = New System.Windows.Forms.PictureBox()
        Me.TitleLabel = New System.Windows.Forms.Label()
        Me.CopierIcon = New System.Windows.Forms.PictureBox()
        Me.ItemsList = New System.Windows.Forms.ListBox()
        Me.ListContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteThisItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasteClipboardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GetLastListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.CheckClipboardTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TotalItemsLabel = New System.Windows.Forms.Label()
        Me.OptionPanel1.SuspendLayout()
        Me.MainContextMenuStrip.SuspendLayout()
        CType(Me.TansparencyTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MenuButton, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TopPanel1.SuspendLayout()
        CType(Me.MaximizeButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MinimizeButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EndButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CopierIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ListContextMenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'OptionPanel1
        '
        Me.OptionPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.OptionPanel1.ContextMenuStrip = Me.MainContextMenuStrip
        Me.OptionPanel1.Controls.Add(Me.Label5)
        Me.OptionPanel1.Controls.Add(Me.Label4)
        Me.OptionPanel1.Controls.Add(Me.Label3)
        Me.OptionPanel1.Controls.Add(Me.Label2)
        Me.OptionPanel1.Controls.Add(Me.Label1)
        Me.OptionPanel1.Controls.Add(Me.TotalSizeLabel)
        Me.OptionPanel1.Controls.Add(Me.checksizemanual)
        Me.OptionPanel1.Controls.Add(Me.TransparencyLevel)
        Me.OptionPanel1.Controls.Add(Me.TransparencyLabelHead)
        Me.OptionPanel1.Controls.Add(Me.TansparencyTrackBar)
        Me.OptionPanel1.Controls.Add(Me.checkclipboard)
        Me.OptionPanel1.Controls.Add(Me.alwaysontopcheck)
        Me.OptionPanel1.Controls.Add(Me.CopyButton)
        Me.OptionPanel1.Controls.Add(Me.MenuButton)
        Me.OptionPanel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.OptionPanel1.Location = New System.Drawing.Point(0, 33)
        Me.OptionPanel1.Name = "OptionPanel1"
        Me.OptionPanel1.Size = New System.Drawing.Size(200, 356)
        Me.OptionPanel1.TabIndex = 0
        '
        'MainContextMenuStrip
        '
        Me.MainContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AutomaticCheckSizeToolStripMenuItem, Me.AddCopierToRightClickContextMenuOfWindowsToolStripMenuItem, Me.CheckForUpdatesToolStripMenuItem, Me.AboutToolStripMenuItem, Me.EndToolStripMenuItem})
        Me.MainContextMenuStrip.Name = "ContextMenuStrip1"
        Me.MainContextMenuStrip.Size = New System.Drawing.Size(344, 114)
        '
        'AutomaticCheckSizeToolStripMenuItem
        '
        Me.AutomaticCheckSizeToolStripMenuItem.Name = "AutomaticCheckSizeToolStripMenuItem"
        Me.AutomaticCheckSizeToolStripMenuItem.Size = New System.Drawing.Size(343, 22)
        Me.AutomaticCheckSizeToolStripMenuItem.Text = "Automatic Check Size"
        '
        'AddCopierToRightClickContextMenuOfWindowsToolStripMenuItem
        '
        Me.AddCopierToRightClickContextMenuOfWindowsToolStripMenuItem.Name = "AddCopierToRightClickContextMenuOfWindowsToolStripMenuItem"
        Me.AddCopierToRightClickContextMenuOfWindowsToolStripMenuItem.Size = New System.Drawing.Size(343, 22)
        Me.AddCopierToRightClickContextMenuOfWindowsToolStripMenuItem.Text = "Add Copier to right click context menu of windows"
        '
        'CheckForUpdatesToolStripMenuItem
        '
        Me.CheckForUpdatesToolStripMenuItem.Image = CType(resources.GetObject("CheckForUpdatesToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CheckForUpdatesToolStripMenuItem.Name = "CheckForUpdatesToolStripMenuItem"
        Me.CheckForUpdatesToolStripMenuItem.Size = New System.Drawing.Size(343, 22)
        Me.CheckForUpdatesToolStripMenuItem.Text = "Check for updates"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Image = CType(resources.GetObject("AboutToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(343, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'EndToolStripMenuItem
        '
        Me.EndToolStripMenuItem.Image = CType(resources.GetObject("EndToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EndToolStripMenuItem.Name = "EndToolStripMenuItem"
        Me.EndToolStripMenuItem.Size = New System.Drawing.Size(343, 22)
        Me.EndToolStripMenuItem.Text = "End"
        '
        'Label5
        '
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Location = New System.Drawing.Point(0, 324)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(200, 2)
        Me.Label5.TabIndex = 16
        '
        'Label4
        '
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Location = New System.Drawing.Point(0, 212)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(200, 2)
        Me.Label4.TabIndex = 15
        '
        'Label3
        '
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Location = New System.Drawing.Point(3, 160)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(200, 2)
        Me.Label3.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Location = New System.Drawing.Point(3, 117)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(200, 2)
        Me.Label2.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Location = New System.Drawing.Point(-3, 76)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(200, 2)
        Me.Label1.TabIndex = 12
        '
        'TotalSizeLabel
        '
        Me.TotalSizeLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TotalSizeLabel.AutoSize = True
        Me.TotalSizeLabel.Font = New System.Drawing.Font("Century Gothic", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalSizeLabel.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.TotalSizeLabel.Location = New System.Drawing.Point(16, 331)
        Me.TotalSizeLabel.Name = "TotalSizeLabel"
        Me.TotalSizeLabel.Size = New System.Drawing.Size(75, 16)
        Me.TotalSizeLabel.TabIndex = 11
        Me.TotalSizeLabel.Text = "Total Size: 0"
        '
        'checksizemanual
        '
        Me.checksizemanual.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.checksizemanual.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.checksizemanual.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.checksizemanual.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.checksizemanual.Font = New System.Drawing.Font("Century Gothic", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checksizemanual.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.checksizemanual.Image = CType(resources.GetObject("checksizemanual.Image"), System.Drawing.Image)
        Me.checksizemanual.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.checksizemanual.Location = New System.Drawing.Point(3, 171)
        Me.checksizemanual.Name = "checksizemanual"
        Me.checksizemanual.Size = New System.Drawing.Size(194, 33)
        Me.checksizemanual.TabIndex = 11
        Me.checksizemanual.Text = "Check Size"
        Me.checksizemanual.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.checksizemanual.UseVisualStyleBackColor = True
        '
        'TransparencyLevel
        '
        Me.TransparencyLevel.AutoSize = True
        Me.TransparencyLevel.Font = New System.Drawing.Font("Century Gothic", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TransparencyLevel.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.TransparencyLevel.Location = New System.Drawing.Point(62, 264)
        Me.TransparencyLevel.Name = "TransparencyLevel"
        Me.TransparencyLevel.Size = New System.Drawing.Size(29, 16)
        Me.TransparencyLevel.TabIndex = 10
        Me.TransparencyLevel.Text = "100"
        '
        'TransparencyLabelHead
        '
        Me.TransparencyLabelHead.AutoSize = True
        Me.TransparencyLabelHead.Font = New System.Drawing.Font("Century Gothic", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TransparencyLabelHead.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.TransparencyLabelHead.Location = New System.Drawing.Point(63, 222)
        Me.TransparencyLabelHead.Name = "TransparencyLabelHead"
        Me.TransparencyLabelHead.Size = New System.Drawing.Size(87, 16)
        Me.TransparencyLabelHead.TabIndex = 9
        Me.TransparencyLabelHead.Text = "Transparency"
        '
        'TansparencyTrackBar
        '
        Me.TansparencyTrackBar.Location = New System.Drawing.Point(12, 213)
        Me.TansparencyTrackBar.Maximum = 100
        Me.TansparencyTrackBar.Minimum = 20
        Me.TansparencyTrackBar.Name = "TansparencyTrackBar"
        Me.TansparencyTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.TansparencyTrackBar.Size = New System.Drawing.Size(45, 112)
        Me.TansparencyTrackBar.TabIndex = 8
        Me.ToolTip1.SetToolTip(Me.TansparencyTrackBar, "Transparency of Copier")
        Me.TansparencyTrackBar.Value = 100
        '
        'checkclipboard
        '
        Me.checkclipboard.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.checkclipboard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.checkclipboard.Font = New System.Drawing.Font("Century Gothic", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkclipboard.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.checkclipboard.Location = New System.Drawing.Point(8, 130)
        Me.checkclipboard.Name = "checkclipboard"
        Me.checkclipboard.Size = New System.Drawing.Size(176, 20)
        Me.checkclipboard.TabIndex = 4
        Me.checkclipboard.Text = "Clipboard Auto-Check"
        Me.ToolTip1.SetToolTip(Me.checkclipboard, "Check if any item is copied and put it in the list (Ctrl + C)")
        Me.checkclipboard.UseVisualStyleBackColor = True
        '
        'alwaysontopcheck
        '
        Me.alwaysontopcheck.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.alwaysontopcheck.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.alwaysontopcheck.Font = New System.Drawing.Font("Century Gothic", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.alwaysontopcheck.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.alwaysontopcheck.Location = New System.Drawing.Point(8, 87)
        Me.alwaysontopcheck.Name = "alwaysontopcheck"
        Me.alwaysontopcheck.Size = New System.Drawing.Size(176, 20)
        Me.alwaysontopcheck.TabIndex = 3
        Me.alwaysontopcheck.Text = "Top always"
        Me.ToolTip1.SetToolTip(Me.alwaysontopcheck, "Always in the front")
        Me.alwaysontopcheck.UseVisualStyleBackColor = True
        '
        'CopyButton
        '
        Me.CopyButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.CopyButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CopyButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CopyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CopyButton.Font = New System.Drawing.Font("Century Gothic", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CopyButton.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.CopyButton.Image = CType(resources.GetObject("CopyButton.Image"), System.Drawing.Image)
        Me.CopyButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CopyButton.Location = New System.Drawing.Point(0, 32)
        Me.CopyButton.Name = "CopyButton"
        Me.CopyButton.Size = New System.Drawing.Size(197, 33)
        Me.CopyButton.TabIndex = 2
        Me.CopyButton.Text = "Copy"
        Me.CopyButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.CopyButton, "Click to add items to clipboard")
        Me.CopyButton.UseVisualStyleBackColor = True
        '
        'MenuButton
        '
        Me.MenuButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.MenuButton.Image = CType(resources.GetObject("MenuButton.Image"), System.Drawing.Image)
        Me.MenuButton.Location = New System.Drawing.Point(168, 5)
        Me.MenuButton.Name = "MenuButton"
        Me.MenuButton.Size = New System.Drawing.Size(25, 25)
        Me.MenuButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.MenuButton.TabIndex = 1
        Me.MenuButton.TabStop = False
        '
        'TopPanel1
        '
        Me.TopPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TopPanel1.Controls.Add(Me.StatusLabel)
        Me.TopPanel1.Controls.Add(Me.MaximizeButton)
        Me.TopPanel1.Controls.Add(Me.MinimizeButton)
        Me.TopPanel1.Controls.Add(Me.EndButton)
        Me.TopPanel1.Controls.Add(Me.TitleLabel)
        Me.TopPanel1.Controls.Add(Me.CopierIcon)
        Me.TopPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TopPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TopPanel1.Name = "TopPanel1"
        Me.TopPanel1.Size = New System.Drawing.Size(681, 33)
        Me.TopPanel1.TabIndex = 1
        '
        'StatusLabel
        '
        Me.StatusLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StatusLabel.AutoSize = True
        Me.StatusLabel.Font = New System.Drawing.Font("Century Gothic", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusLabel.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.StatusLabel.Location = New System.Drawing.Point(263, 9)
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New System.Drawing.Size(78, 16)
        Me.StatusLabel.TabIndex = 5
        Me.StatusLabel.Text = "Status: Null"
        Me.ToolTip1.SetToolTip(Me.StatusLabel, "Status to show progress of the process")
        '
        'MaximizeButton
        '
        Me.MaximizeButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MaximizeButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.MaximizeButton.Image = CType(resources.GetObject("MaximizeButton.Image"), System.Drawing.Image)
        Me.MaximizeButton.Location = New System.Drawing.Point(625, 6)
        Me.MaximizeButton.Name = "MaximizeButton"
        Me.MaximizeButton.Size = New System.Drawing.Size(20, 19)
        Me.MaximizeButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.MaximizeButton.TabIndex = 4
        Me.MaximizeButton.TabStop = False
        Me.ToolTip1.SetToolTip(Me.MaximizeButton, "Maximize")
        '
        'MinimizeButton
        '
        Me.MinimizeButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MinimizeButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.MinimizeButton.Image = CType(resources.GetObject("MinimizeButton.Image"), System.Drawing.Image)
        Me.MinimizeButton.Location = New System.Drawing.Point(599, 6)
        Me.MinimizeButton.Name = "MinimizeButton"
        Me.MinimizeButton.Size = New System.Drawing.Size(20, 20)
        Me.MinimizeButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.MinimizeButton.TabIndex = 3
        Me.MinimizeButton.TabStop = False
        Me.ToolTip1.SetToolTip(Me.MinimizeButton, "Minimize")
        '
        'EndButton
        '
        Me.EndButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.EndButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.EndButton.Image = CType(resources.GetObject("EndButton.Image"), System.Drawing.Image)
        Me.EndButton.Location = New System.Drawing.Point(651, 6)
        Me.EndButton.Name = "EndButton"
        Me.EndButton.Size = New System.Drawing.Size(20, 20)
        Me.EndButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.EndButton.TabIndex = 2
        Me.EndButton.TabStop = False
        Me.ToolTip1.SetToolTip(Me.EndButton, "End")
        '
        'TitleLabel
        '
        Me.TitleLabel.AutoSize = True
        Me.TitleLabel.Font = New System.Drawing.Font("Century Gothic", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TitleLabel.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.TitleLabel.Location = New System.Drawing.Point(46, 9)
        Me.TitleLabel.Name = "TitleLabel"
        Me.TitleLabel.Size = New System.Drawing.Size(89, 16)
        Me.TitleLabel.TabIndex = 0
        Me.TitleLabel.Text = "B++ -Copier-"
        '
        'CopierIcon
        '
        Me.CopierIcon.Image = CType(resources.GetObject("CopierIcon.Image"), System.Drawing.Image)
        Me.CopierIcon.Location = New System.Drawing.Point(12, 6)
        Me.CopierIcon.Name = "CopierIcon"
        Me.CopierIcon.Size = New System.Drawing.Size(28, 24)
        Me.CopierIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.CopierIcon.TabIndex = 0
        Me.CopierIcon.TabStop = False
        '
        'ItemsList
        '
        Me.ItemsList.AllowDrop = True
        Me.ItemsList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ItemsList.BackColor = System.Drawing.SystemColors.HotTrack
        Me.ItemsList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ItemsList.ContextMenuStrip = Me.ListContextMenuStrip
        Me.ItemsList.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.ItemsList.ForeColor = System.Drawing.SystemColors.Info
        Me.ItemsList.FormattingEnabled = True
        Me.ItemsList.ItemHeight = 16
        Me.ItemsList.Location = New System.Drawing.Point(206, 38)
        Me.ItemsList.Name = "ItemsList"
        Me.ItemsList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.ItemsList.Size = New System.Drawing.Size(465, 322)
        Me.ItemsList.Sorted = True
        Me.ItemsList.TabIndex = 2
        '
        'ListContextMenuStrip
        '
        Me.ListContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteThisItemToolStripMenuItem, Me.ClearAllToolStripMenuItem, Me.ExportListToolStripMenuItem, Me.ImportListToolStripMenuItem, Me.PasteClipboardToolStripMenuItem, Me.GetLastListToolStripMenuItem})
        Me.ListContextMenuStrip.Name = "ContextMenuStrip2"
        Me.ListContextMenuStrip.Size = New System.Drawing.Size(169, 136)
        '
        'DeleteThisItemToolStripMenuItem
        '
        Me.DeleteThisItemToolStripMenuItem.Image = CType(resources.GetObject("DeleteThisItemToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DeleteThisItemToolStripMenuItem.Name = "DeleteThisItemToolStripMenuItem"
        Me.DeleteThisItemToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.DeleteThisItemToolStripMenuItem.Text = "Delete item\items"
        '
        'ClearAllToolStripMenuItem
        '
        Me.ClearAllToolStripMenuItem.Image = CType(resources.GetObject("ClearAllToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ClearAllToolStripMenuItem.Name = "ClearAllToolStripMenuItem"
        Me.ClearAllToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.ClearAllToolStripMenuItem.Text = "Clear All"
        '
        'ExportListToolStripMenuItem
        '
        Me.ExportListToolStripMenuItem.Image = CType(resources.GetObject("ExportListToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ExportListToolStripMenuItem.Name = "ExportListToolStripMenuItem"
        Me.ExportListToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.ExportListToolStripMenuItem.Text = "Export List"
        '
        'ImportListToolStripMenuItem
        '
        Me.ImportListToolStripMenuItem.Image = CType(resources.GetObject("ImportListToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ImportListToolStripMenuItem.Name = "ImportListToolStripMenuItem"
        Me.ImportListToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.ImportListToolStripMenuItem.Text = "Import List"
        '
        'PasteClipboardToolStripMenuItem
        '
        Me.PasteClipboardToolStripMenuItem.Image = CType(resources.GetObject("PasteClipboardToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PasteClipboardToolStripMenuItem.Name = "PasteClipboardToolStripMenuItem"
        Me.PasteClipboardToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.PasteClipboardToolStripMenuItem.Text = "Paste Clipboard"
        '
        'GetLastListToolStripMenuItem
        '
        Me.GetLastListToolStripMenuItem.Image = CType(resources.GetObject("GetLastListToolStripMenuItem.Image"), System.Drawing.Image)
        Me.GetLastListToolStripMenuItem.Name = "GetLastListToolStripMenuItem"
        Me.GetLastListToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.GetLastListToolStripMenuItem.Text = "Get last list"
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.FileName = "Copier"
        Me.SaveFileDialog1.Filter = "Text Document (*.txt)|*.txt"
        Me.SaveFileDialog1.Title = "Save File"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = "Text File (*.txt)|*.txt"
        '
        'CheckClipboardTimer
        '
        Me.CheckClipboardTimer.Interval = 200
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 5000
        Me.ToolTip1.BackColor = System.Drawing.SystemColors.Highlight
        Me.ToolTip1.InitialDelay = 1500
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ReshowDelay = 1000
        '
        'TotalItemsLabel
        '
        Me.TotalItemsLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TotalItemsLabel.AutoSize = True
        Me.TotalItemsLabel.Font = New System.Drawing.Font("Century Gothic", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalItemsLabel.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.TotalItemsLabel.Location = New System.Drawing.Point(206, 364)
        Me.TotalItemsLabel.Name = "TotalItemsLabel"
        Me.TotalItemsLabel.Size = New System.Drawing.Size(132, 16)
        Me.TotalItemsLabel.TabIndex = 10
        Me.TotalItemsLabel.Text = "Total items to copy: 0"
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(46, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(681, 389)
        Me.ContextMenuStrip = Me.MainContextMenuStrip
        Me.Controls.Add(Me.TotalItemsLabel)
        Me.Controls.Add(Me.ItemsList)
        Me.Controls.Add(Me.OptionPanel1)
        Me.Controls.Add(Me.TopPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Main"
        Me.OptionPanel1.ResumeLayout(False)
        Me.OptionPanel1.PerformLayout()
        Me.MainContextMenuStrip.ResumeLayout(False)
        CType(Me.TansparencyTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MenuButton, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TopPanel1.ResumeLayout(False)
        Me.TopPanel1.PerformLayout()
        CType(Me.MaximizeButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MinimizeButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EndButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CopierIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ListContextMenuStrip.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents OptionPanel1 As Panel
    Friend WithEvents MenuButton As PictureBox
    Friend WithEvents CopierIcon As PictureBox
    Friend WithEvents TopPanel1 As Panel
    Friend WithEvents MaximizeButton As PictureBox
    Friend WithEvents MinimizeButton As PictureBox
    Friend WithEvents EndButton As PictureBox
    Friend WithEvents TitleLabel As Label
    Friend WithEvents ItemsList As ListBox
    Friend WithEvents ListContextMenuStrip As ContextMenuStrip
    Friend WithEvents DeleteThisItemToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClearAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExportListToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImportListToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PasteClipboardToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MainContextMenuStrip As ContextMenuStrip
    Friend WithEvents AutomaticCheckSizeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddCopierToRightClickContextMenuOfWindowsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CheckForUpdatesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EndToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents CheckClipboardTimer As Timer
    Friend WithEvents CopyButton As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents alwaysontopcheck As CheckBox
    Friend WithEvents checkclipboard As CheckBox
    Friend WithEvents TransparencyLabelHead As Label
    Friend WithEvents TansparencyTrackBar As TrackBar
    Friend WithEvents TransparencyLevel As Label
    Friend WithEvents checksizemanual As Button
    Friend WithEvents StatusLabel As Label
    Friend WithEvents TotalItemsLabel As Label
    Friend WithEvents TotalSizeLabel As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents GetLastListToolStripMenuItem As ToolStripMenuItem
End Class

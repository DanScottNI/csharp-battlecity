namespace BattleCityEdit
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.ofdOpenROM = new System.Windows.Forms.OpenFileDialog();
            this.ssStatusBar = new System.Windows.Forms.StatusStrip();
            this.lblEditingMode = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLevelName = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDataFile = new System.Windows.Forms.ToolStripStatusLabel();
            this.mnuMainMenu = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpenROM = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaveROM = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDistributeHack = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCloseROM = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuPreferences = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMapEditingMode = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuObjectEditingMode = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuView = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewGridlines = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewPlayerStartPos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewEnemyStartPos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewFlag = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTSAEditor = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPaletteEditor = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEnemyEditor = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFlagTSAEditor = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPlayerEditor = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuKeyboardLayout = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.picLevel = new System.Windows.Forms.PictureBox();
            this.picTileSelector = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tlbOpenROM = new System.Windows.Forms.ToolStripButton();
            this.tlbSaveROM = new System.Windows.Forms.ToolStripButton();
            this.tlbCloseROM = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tlbMapEditingMode = new System.Windows.Forms.ToolStripButton();
            this.tlbObjectEditingMode = new System.Windows.Forms.ToolStripButton();
            this.tlbViewGridlines = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tlbTSAEditor = new System.Windows.Forms.ToolStripButton();
            this.tlbPaletteEditor = new System.Windows.Forms.ToolStripButton();
            this.tlbEnemyEditor = new System.Windows.Forms.ToolStripButton();
            this.tlbPlayerEditor = new System.Windows.Forms.ToolStripButton();
            this.ssStatusBar.SuspendLayout();
            this.mnuMainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTileSelector)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ofdOpenROM
            // 
            this.ofdOpenROM.Filter = "iNESImage (*.nes)|*.nes";
            this.ofdOpenROM.Title = "Select a Battle City ROM";
            // 
            // ssStatusBar
            // 
            this.ssStatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblEditingMode,
            this.lblLevelName,
            this.lblDataFile});
            this.ssStatusBar.Location = new System.Drawing.Point(0, 471);
            this.ssStatusBar.Name = "ssStatusBar";
            this.ssStatusBar.Size = new System.Drawing.Size(494, 22);
            this.ssStatusBar.SizingGrip = false;
            this.ssStatusBar.TabIndex = 4;
            this.ssStatusBar.Text = "StatusStrip1";
            // 
            // lblEditingMode
            // 
            this.lblEditingMode.Name = "lblEditingMode";
            this.lblEditingMode.Size = new System.Drawing.Size(91, 17);
            this.lblEditingMode.Text = "Map Editing Mode";
            // 
            // lblLevelName
            // 
            this.lblLevelName.Name = "lblLevelName";
            this.lblLevelName.Size = new System.Drawing.Size(357, 17);
            this.lblLevelName.Spring = true;
            // 
            // lblDataFile
            // 
            this.lblDataFile.Name = "lblDataFile";
            this.lblDataFile.Size = new System.Drawing.Size(0, 17);
            this.lblDataFile.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // mnuMainMenu
            // 
            this.mnuMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuEdit,
            this.mnuView,
            this.mnuTools,
            this.mnuHelp});
            this.mnuMainMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMainMenu.Name = "mnuMainMenu";
            this.mnuMainMenu.ShowItemToolTips = true;
            this.mnuMainMenu.Size = new System.Drawing.Size(494, 24);
            this.mnuMainMenu.TabIndex = 3;
            this.mnuMainMenu.Text = "MenuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpenROM,
            this.mnuSaveROM,
            this.mnuDistributeHack,
            this.mnuCloseROM,
            this.ToolStripMenuItem2,
            this.mnuPreferences,
            this.ToolStripMenuItem5,
            this.toolStripSeparator3,
            this.mnuExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(35, 20);
            this.mnuFile.Text = "File";
            // 
            // mnuOpenROM
            // 
            this.mnuOpenROM.Image = ((System.Drawing.Image)(resources.GetObject("mnuOpenROM.Image")));
            this.mnuOpenROM.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuOpenROM.Name = "mnuOpenROM";
            this.mnuOpenROM.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuOpenROM.Size = new System.Drawing.Size(196, 22);
            this.mnuOpenROM.Text = "Open ROM";
            this.mnuOpenROM.Click += new System.EventHandler(this.mnuOpenROM_Click);
            // 
            // mnuSaveROM
            // 
            this.mnuSaveROM.Image = ((System.Drawing.Image)(resources.GetObject("mnuSaveROM.Image")));
            this.mnuSaveROM.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuSaveROM.Name = "mnuSaveROM";
            this.mnuSaveROM.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuSaveROM.Size = new System.Drawing.Size(196, 22);
            this.mnuSaveROM.Text = "Save ROM";
            this.mnuSaveROM.Click += new System.EventHandler(this.mnuSaveROM_Click);
            // 
            // mnuDistributeHack
            // 
            this.mnuDistributeHack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuDistributeHack.Name = "mnuDistributeHack";
            this.mnuDistributeHack.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.mnuDistributeHack.Size = new System.Drawing.Size(196, 22);
            this.mnuDistributeHack.Text = "Distribute Hack";
            // 
            // mnuCloseROM
            // 
            this.mnuCloseROM.Image = ((System.Drawing.Image)(resources.GetObject("mnuCloseROM.Image")));
            this.mnuCloseROM.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuCloseROM.Name = "mnuCloseROM";
            this.mnuCloseROM.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.mnuCloseROM.Size = new System.Drawing.Size(196, 22);
            this.mnuCloseROM.Text = "Close ROM";
            this.mnuCloseROM.Click += new System.EventHandler(this.mnuCloseROM_Click);
            // 
            // ToolStripMenuItem2
            // 
            this.ToolStripMenuItem2.Name = "ToolStripMenuItem2";
            this.ToolStripMenuItem2.Size = new System.Drawing.Size(193, 6);
            // 
            // mnuPreferences
            // 
            this.mnuPreferences.Image = ((System.Drawing.Image)(resources.GetObject("mnuPreferences.Image")));
            this.mnuPreferences.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuPreferences.Name = "mnuPreferences";
            this.mnuPreferences.Size = new System.Drawing.Size(196, 22);
            this.mnuPreferences.Text = "Preferences";
            // 
            // ToolStripMenuItem5
            // 
            this.ToolStripMenuItem5.Name = "ToolStripMenuItem5";
            this.ToolStripMenuItem5.Size = new System.Drawing.Size(193, 6);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(193, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Image = ((System.Drawing.Image)(resources.GetObject("mnuExit.Image")));
            this.mnuExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.mnuExit.Size = new System.Drawing.Size(196, 22);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // mnuEdit
            // 
            this.mnuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMapEditingMode,
            this.mnuObjectEditingMode});
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(37, 20);
            this.mnuEdit.Text = "Edit";
            // 
            // mnuMapEditingMode
            // 
            this.mnuMapEditingMode.Name = "mnuMapEditingMode";
            this.mnuMapEditingMode.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.mnuMapEditingMode.Size = new System.Drawing.Size(200, 22);
            this.mnuMapEditingMode.Text = "Map Editing Mode";
            this.mnuMapEditingMode.Click += new System.EventHandler(this.mnuMapEditingMode_Click);
            // 
            // mnuObjectEditingMode
            // 
            this.mnuObjectEditingMode.Name = "mnuObjectEditingMode";
            this.mnuObjectEditingMode.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.mnuObjectEditingMode.Size = new System.Drawing.Size(200, 22);
            this.mnuObjectEditingMode.Text = "Object Editing Mode";
            this.mnuObjectEditingMode.Click += new System.EventHandler(this.mnuObjectEditingMode_Click);
            // 
            // mnuView
            // 
            this.mnuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuViewGridlines,
            this.mnuViewPlayerStartPos,
            this.mnuViewEnemyStartPos,
            this.mnuViewFlag});
            this.mnuView.Name = "mnuView";
            this.mnuView.Size = new System.Drawing.Size(41, 20);
            this.mnuView.Text = "View";
            // 
            // mnuViewGridlines
            // 
            this.mnuViewGridlines.Name = "mnuViewGridlines";
            this.mnuViewGridlines.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F2)));
            this.mnuViewGridlines.Size = new System.Drawing.Size(252, 22);
            this.mnuViewGridlines.Text = "Gridlines";
            // 
            // mnuViewPlayerStartPos
            // 
            this.mnuViewPlayerStartPos.Name = "mnuViewPlayerStartPos";
            this.mnuViewPlayerStartPos.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F3)));
            this.mnuViewPlayerStartPos.Size = new System.Drawing.Size(252, 22);
            this.mnuViewPlayerStartPos.Text = "Player Starting Positions";
            // 
            // mnuViewEnemyStartPos
            // 
            this.mnuViewEnemyStartPos.Name = "mnuViewEnemyStartPos";
            this.mnuViewEnemyStartPos.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F4)));
            this.mnuViewEnemyStartPos.Size = new System.Drawing.Size(252, 22);
            this.mnuViewEnemyStartPos.Text = "Enemy Starting Positions";
            // 
            // mnuViewFlag
            // 
            this.mnuViewFlag.Name = "mnuViewFlag";
            this.mnuViewFlag.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F5)));
            this.mnuViewFlag.Size = new System.Drawing.Size(252, 22);
            this.mnuViewFlag.Text = "Flag";
            // 
            // mnuTools
            // 
            this.mnuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTSAEditor,
            this.mnuPaletteEditor,
            this.mnuEnemyEditor,
            this.mnuFlagTSAEditor,
            this.mnuPlayerEditor});
            this.mnuTools.Name = "mnuTools";
            this.mnuTools.Size = new System.Drawing.Size(44, 20);
            this.mnuTools.Text = "Tools";
            // 
            // mnuTSAEditor
            // 
            this.mnuTSAEditor.Image = ((System.Drawing.Image)(resources.GetObject("mnuTSAEditor.Image")));
            this.mnuTSAEditor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuTSAEditor.Name = "mnuTSAEditor";
            this.mnuTSAEditor.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.mnuTSAEditor.Size = new System.Drawing.Size(196, 22);
            this.mnuTSAEditor.Text = "TSA Editor";
            this.mnuTSAEditor.Click += new System.EventHandler(this.mnuTSAEditor_Click);
            // 
            // mnuPaletteEditor
            // 
            this.mnuPaletteEditor.Image = ((System.Drawing.Image)(resources.GetObject("mnuPaletteEditor.Image")));
            this.mnuPaletteEditor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuPaletteEditor.Name = "mnuPaletteEditor";
            this.mnuPaletteEditor.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.mnuPaletteEditor.Size = new System.Drawing.Size(196, 22);
            this.mnuPaletteEditor.Text = "Palette Editor";
            // 
            // mnuEnemyEditor
            // 
            this.mnuEnemyEditor.Image = ((System.Drawing.Image)(resources.GetObject("mnuEnemyEditor.Image")));
            this.mnuEnemyEditor.ImageTransparentColor = System.Drawing.Color.Black;
            this.mnuEnemyEditor.Name = "mnuEnemyEditor";
            this.mnuEnemyEditor.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.mnuEnemyEditor.Size = new System.Drawing.Size(196, 22);
            this.mnuEnemyEditor.Text = "Enemy Editor";
            // 
            // mnuFlagTSAEditor
            // 
            this.mnuFlagTSAEditor.Name = "mnuFlagTSAEditor";
            this.mnuFlagTSAEditor.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.mnuFlagTSAEditor.Size = new System.Drawing.Size(196, 22);
            this.mnuFlagTSAEditor.Text = "Flag TSA Editor";
            // 
            // mnuPlayerEditor
            // 
            this.mnuPlayerEditor.Image = ((System.Drawing.Image)(resources.GetObject("mnuPlayerEditor.Image")));
            this.mnuPlayerEditor.ImageTransparentColor = System.Drawing.Color.Black;
            this.mnuPlayerEditor.Name = "mnuPlayerEditor";
            this.mnuPlayerEditor.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.mnuPlayerEditor.Size = new System.Drawing.Size(196, 22);
            this.mnuPlayerEditor.Text = "Player Editor";
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuKeyboardLayout,
            this.mnuAbout});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(40, 20);
            this.mnuHelp.Text = "Help";
            // 
            // mnuKeyboardLayout
            // 
            this.mnuKeyboardLayout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuKeyboardLayout.Name = "mnuKeyboardLayout";
            this.mnuKeyboardLayout.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.K)));
            this.mnuKeyboardLayout.Size = new System.Drawing.Size(205, 22);
            this.mnuKeyboardLayout.Text = "Keyboard Layout";
            // 
            // mnuAbout
            // 
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.mnuAbout.Size = new System.Drawing.Size(205, 22);
            this.mnuAbout.Text = "About";
            // 
            // picLevel
            // 
            this.picLevel.Location = new System.Drawing.Point(0, 52);
            this.picLevel.Name = "picLevel";
            this.picLevel.Size = new System.Drawing.Size(416, 416);
            this.picLevel.TabIndex = 5;
            this.picLevel.TabStop = false;
            this.picLevel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picLevel_MouseMove);
            this.picLevel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picLevel_MouseDown);
            this.picLevel.Paint += new System.Windows.Forms.PaintEventHandler(this.picLevel_Paint);
            this.picLevel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picLevel_MouseUp);
            // 
            // picTileSelector
            // 
            this.picTileSelector.Location = new System.Drawing.Point(422, 52);
            this.picTileSelector.Name = "picTileSelector";
            this.picTileSelector.Size = new System.Drawing.Size(64, 256);
            this.picTileSelector.TabIndex = 8;
            this.picTileSelector.TabStop = false;
            this.picTileSelector.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picTileSelector_MouseDown);
            this.picTileSelector.Paint += new System.Windows.Forms.PaintEventHandler(this.picTileSelector_Paint);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlbOpenROM,
            this.tlbSaveROM,
            this.tlbCloseROM,
            this.toolStripSeparator1,
            this.tlbMapEditingMode,
            this.tlbObjectEditingMode,
            this.tlbViewGridlines,
            this.toolStripSeparator2,
            this.tlbTSAEditor,
            this.tlbPaletteEditor,
            this.tlbEnemyEditor,
            this.tlbPlayerEditor});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(494, 25);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tlbOpenROM
            // 
            this.tlbOpenROM.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlbOpenROM.Image = ((System.Drawing.Image)(resources.GetObject("tlbOpenROM.Image")));
            this.tlbOpenROM.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlbOpenROM.Name = "tlbOpenROM";
            this.tlbOpenROM.Size = new System.Drawing.Size(23, 22);
            this.tlbOpenROM.Text = "Open ROM";
            this.tlbOpenROM.Click += new System.EventHandler(this.mnuOpenROM_Click);
            // 
            // tlbSaveROM
            // 
            this.tlbSaveROM.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlbSaveROM.Image = ((System.Drawing.Image)(resources.GetObject("tlbSaveROM.Image")));
            this.tlbSaveROM.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlbSaveROM.Name = "tlbSaveROM";
            this.tlbSaveROM.Size = new System.Drawing.Size(23, 22);
            this.tlbSaveROM.Text = "Save ROM";
            this.tlbSaveROM.Click += new System.EventHandler(this.mnuSaveROM_Click);
            // 
            // tlbCloseROM
            // 
            this.tlbCloseROM.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlbCloseROM.Image = ((System.Drawing.Image)(resources.GetObject("tlbCloseROM.Image")));
            this.tlbCloseROM.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlbCloseROM.Name = "tlbCloseROM";
            this.tlbCloseROM.Size = new System.Drawing.Size(23, 22);
            this.tlbCloseROM.Text = "Close ROM";
            this.tlbCloseROM.Click += new System.EventHandler(this.mnuCloseROM_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tlbMapEditingMode
            // 
            this.tlbMapEditingMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlbMapEditingMode.Image = ((System.Drawing.Image)(resources.GetObject("tlbMapEditingMode.Image")));
            this.tlbMapEditingMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlbMapEditingMode.Name = "tlbMapEditingMode";
            this.tlbMapEditingMode.Size = new System.Drawing.Size(23, 22);
            this.tlbMapEditingMode.Text = "Map Editing Mode";
            this.tlbMapEditingMode.Click += new System.EventHandler(this.mnuMapEditingMode_Click);
            // 
            // tlbObjectEditingMode
            // 
            this.tlbObjectEditingMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlbObjectEditingMode.Image = ((System.Drawing.Image)(resources.GetObject("tlbObjectEditingMode.Image")));
            this.tlbObjectEditingMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlbObjectEditingMode.Name = "tlbObjectEditingMode";
            this.tlbObjectEditingMode.Size = new System.Drawing.Size(23, 22);
            this.tlbObjectEditingMode.Text = "Object Editing Mode";
            this.tlbObjectEditingMode.Click += new System.EventHandler(this.mnuObjectEditingMode_Click);
            // 
            // tlbViewGridlines
            // 
            this.tlbViewGridlines.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlbViewGridlines.Image = ((System.Drawing.Image)(resources.GetObject("tlbViewGridlines.Image")));
            this.tlbViewGridlines.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlbViewGridlines.Name = "tlbViewGridlines";
            this.tlbViewGridlines.Size = new System.Drawing.Size(23, 22);
            this.tlbViewGridlines.Text = "View Gridlines";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tlbTSAEditor
            // 
            this.tlbTSAEditor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlbTSAEditor.Image = ((System.Drawing.Image)(resources.GetObject("tlbTSAEditor.Image")));
            this.tlbTSAEditor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlbTSAEditor.Name = "tlbTSAEditor";
            this.tlbTSAEditor.Size = new System.Drawing.Size(23, 22);
            this.tlbTSAEditor.Text = "TSA Editor";
            // 
            // tlbPaletteEditor
            // 
            this.tlbPaletteEditor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlbPaletteEditor.Image = ((System.Drawing.Image)(resources.GetObject("tlbPaletteEditor.Image")));
            this.tlbPaletteEditor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlbPaletteEditor.Name = "tlbPaletteEditor";
            this.tlbPaletteEditor.Size = new System.Drawing.Size(23, 22);
            this.tlbPaletteEditor.Text = "Palette Editor";
            // 
            // tlbEnemyEditor
            // 
            this.tlbEnemyEditor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlbEnemyEditor.Image = ((System.Drawing.Image)(resources.GetObject("tlbEnemyEditor.Image")));
            this.tlbEnemyEditor.ImageTransparentColor = System.Drawing.Color.Black;
            this.tlbEnemyEditor.Name = "tlbEnemyEditor";
            this.tlbEnemyEditor.Size = new System.Drawing.Size(23, 22);
            this.tlbEnemyEditor.Text = "Enemy Editor";
            // 
            // tlbPlayerEditor
            // 
            this.tlbPlayerEditor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlbPlayerEditor.Image = ((System.Drawing.Image)(resources.GetObject("tlbPlayerEditor.Image")));
            this.tlbPlayerEditor.ImageTransparentColor = System.Drawing.Color.Black;
            this.tlbPlayerEditor.Name = "tlbPlayerEditor";
            this.tlbPlayerEditor.Size = new System.Drawing.Size(23, 22);
            this.tlbPlayerEditor.Text = "Player Editor";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 493);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.picLevel);
            this.Controls.Add(this.picTileSelector);
            this.Controls.Add(this.ssStatusBar);
            this.Controls.Add(this.mnuMainMenu);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quarrel";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ssStatusBar.ResumeLayout(false);
            this.ssStatusBar.PerformLayout();
            this.mnuMainMenu.ResumeLayout(false);
            this.mnuMainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTileSelector)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.OpenFileDialog ofdOpenROM;
        internal System.Windows.Forms.StatusStrip ssStatusBar;
        internal System.Windows.Forms.MenuStrip mnuMainMenu;
        internal System.Windows.Forms.ToolStripMenuItem mnuFile;
        internal System.Windows.Forms.ToolStripMenuItem mnuOpenROM;
        internal System.Windows.Forms.ToolStripMenuItem mnuSaveROM;
        internal System.Windows.Forms.ToolStripMenuItem mnuDistributeHack;
        internal System.Windows.Forms.ToolStripMenuItem mnuCloseROM;
        internal System.Windows.Forms.ToolStripSeparator ToolStripMenuItem2;
        internal System.Windows.Forms.ToolStripMenuItem mnuPreferences;
        internal System.Windows.Forms.ToolStripSeparator ToolStripMenuItem5;
        internal System.Windows.Forms.ToolStripMenuItem mnuExit;
        internal System.Windows.Forms.ToolStripMenuItem mnuEdit;
        internal System.Windows.Forms.ToolStripMenuItem mnuMapEditingMode;
        internal System.Windows.Forms.ToolStripMenuItem mnuObjectEditingMode;
        internal System.Windows.Forms.ToolStripMenuItem mnuView;
        internal System.Windows.Forms.ToolStripMenuItem mnuViewGridlines;
        internal System.Windows.Forms.ToolStripMenuItem mnuViewPlayerStartPos;
        internal System.Windows.Forms.ToolStripMenuItem mnuViewEnemyStartPos;
        internal System.Windows.Forms.ToolStripMenuItem mnuViewFlag;
        internal System.Windows.Forms.ToolStripMenuItem mnuTools;
        internal System.Windows.Forms.ToolStripMenuItem mnuTSAEditor;
        internal System.Windows.Forms.ToolStripMenuItem mnuPaletteEditor;
        internal System.Windows.Forms.ToolStripMenuItem mnuEnemyEditor;
        internal System.Windows.Forms.ToolStripMenuItem mnuFlagTSAEditor;
        internal System.Windows.Forms.ToolStripMenuItem mnuPlayerEditor;
        internal System.Windows.Forms.ToolStripMenuItem mnuHelp;
        internal System.Windows.Forms.ToolStripMenuItem mnuKeyboardLayout;
        internal System.Windows.Forms.ToolStripMenuItem mnuAbout;
        internal System.Windows.Forms.PictureBox picTileSelector;
        private System.Windows.Forms.PictureBox picLevel;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tlbOpenROM;
        private System.Windows.Forms.ToolStripButton tlbSaveROM;
        private System.Windows.Forms.ToolStripButton tlbCloseROM;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tlbMapEditingMode;
        private System.Windows.Forms.ToolStripButton tlbObjectEditingMode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tlbTSAEditor;
        private System.Windows.Forms.ToolStripButton tlbPaletteEditor;
        private System.Windows.Forms.ToolStripButton tlbEnemyEditor;
        private System.Windows.Forms.ToolStripButton tlbPlayerEditor;
        private System.Windows.Forms.ToolStripButton tlbViewGridlines;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripStatusLabel lblEditingMode;
        private System.Windows.Forms.ToolStripStatusLabel lblLevelName;
        private System.Windows.Forms.ToolStripStatusLabel lblDataFile;
    }
}


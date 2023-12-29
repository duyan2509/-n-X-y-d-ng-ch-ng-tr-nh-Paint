namespace UI
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pnContainer = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tcMain = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.btAdd = new ComponentFactory.Krypton.Navigator.ButtonSpecNavigator();
            this.kryptonPage1 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.btClose1 = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.btSuccess = new Guna.UI2.WinForms.Guna2Button();
            this.fileName = new Guna.UI2.WinForms.Guna2TextBox();
            this.pnTitleBar = new System.Windows.Forms.Panel();
            this.btMaxi = new Guna.UI2.WinForms.Guna2Button();
            this.btClose = new Guna.UI2.WinForms.Guna2Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btMini = new System.Windows.Forms.Button();
            this.kryptonManager1 = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.dlgColor = new System.Windows.Forms.ColorDialog();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dlgPrint = new System.Windows.Forms.PrintDialog();
            this.pnContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcMain)).BeginInit();
            this.tcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage1)).BeginInit();
            this.kryptonPage1.SuspendLayout();
            this.pnTitleBar.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnContainer
            // 
            this.pnContainer.BackColor = System.Drawing.SystemColors.Highlight;
            this.pnContainer.Controls.Add(this.label1);
            this.pnContainer.Controls.Add(this.tcMain);
            this.pnContainer.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnContainer.Location = new System.Drawing.Point(0, 0);
            this.pnContainer.Name = "pnContainer";
            this.pnContainer.Size = new System.Drawing.Size(897, 536);
            this.pnContainer.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "label1";
            // 
            // tcMain
            // 
            this.tcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcMain.Bar.BarOrientation = ComponentFactory.Krypton.Toolkit.VisualOrientation.Right;
            this.tcMain.Bar.ItemOrientation = ComponentFactory.Krypton.Toolkit.ButtonOrientation.FixedTop;
            this.tcMain.Bar.ItemSizing = ComponentFactory.Krypton.Navigator.BarItemSizing.Individual;
            this.tcMain.Bar.TabStyle = ComponentFactory.Krypton.Toolkit.TabStyle.Custom1;
            this.tcMain.Button.ButtonDisplayLogic = ComponentFactory.Krypton.Navigator.ButtonDisplayLogic.None;
            this.tcMain.Button.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Navigator.ButtonSpecNavigator[] {
            this.btAdd});
            this.tcMain.Button.CloseButtonAction = ComponentFactory.Krypton.Navigator.CloseButtonAction.None;
            this.tcMain.Button.CloseButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.tcMain.Header.HeaderPositionBar = ComponentFactory.Krypton.Toolkit.VisualOrientation.Right;
            this.tcMain.Header.HeaderStyleBar = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.tcMain.Header.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.tcMain.Header.HeaderStyleSecondary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.tcMain.Location = new System.Drawing.Point(0, 40);
            this.tcMain.Name = "tcMain";
            this.tcMain.PageBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ButtonButtonSpec;
            this.tcMain.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.kryptonPage1});
            this.tcMain.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(897, 496);
            this.tcMain.TabIndex = 0;
            this.tcMain.Text = "kryptonNavigator1";
            this.tcMain.SelectedPageChanged += new System.EventHandler(this.tcMain_SelectedPageChanged);
            // 
            // btAdd
            // 
            this.btAdd.ColorMap = System.Drawing.Color.White;
            this.btAdd.Text = "+";
            this.btAdd.UniqueName = "21A66A7F699546DC99A10B175D9F63A8";
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // kryptonPage1
            // 
            this.kryptonPage1.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage1.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btClose1});
            this.kryptonPage1.Controls.Add(this.btSuccess);
            this.kryptonPage1.Flags = 65534;
            this.kryptonPage1.LastVisibleSet = true;
            this.kryptonPage1.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage1.Name = "kryptonPage1";
            this.kryptonPage1.Size = new System.Drawing.Size(852, 494);
            this.kryptonPage1.Text = "1";
            this.kryptonPage1.TextTitle = "";
            this.kryptonPage1.ToolTipTitle = "Page ToolTip";
            this.kryptonPage1.UniqueName = "9747C14037B0411865A685BC4244194F";
            // 
            // btClose1
            // 
            this.btClose1.Type = ComponentFactory.Krypton.Toolkit.PaletteButtonSpecStyle.Close;
            this.btClose1.UniqueName = "31A147EECA5F43286FA9B6E033F7570B";
            this.btClose1.Click += new System.EventHandler(this.btClose1_Click);
            // 
            // btSuccess
            // 
            this.btSuccess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSuccess.BackColor = System.Drawing.Color.Transparent;
            this.btSuccess.BackgroundImage = global::UI.Properties.Resources.icons8_check_48;
            this.btSuccess.BorderRadius = 20;
            this.btSuccess.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btSuccess.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btSuccess.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btSuccess.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btSuccess.FillColor = System.Drawing.Color.Transparent;
            this.btSuccess.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btSuccess.ForeColor = System.Drawing.Color.Transparent;
            this.btSuccess.Image = global::UI.Properties.Resources.icons8_check_48;
            this.btSuccess.ImageSize = new System.Drawing.Size(50, 50);
            this.btSuccess.Location = new System.Drawing.Point(811, 458);
            this.btSuccess.Name = "btSuccess";
            this.btSuccess.Size = new System.Drawing.Size(25, 25);
            this.btSuccess.TabIndex = 0;
            // 
            // fileName
            // 
            this.fileName.AcceptsTab = true;
            this.fileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileName.BackColor = System.Drawing.Color.Transparent;
            this.fileName.BorderRadius = 10;
            this.fileName.BorderThickness = 0;
            this.fileName.Cursor = System.Windows.Forms.Cursors.Default;
            this.fileName.DefaultText = "";
            this.fileName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.fileName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.fileName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.fileName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.fileName.FillColor = System.Drawing.SystemColors.MenuHighlight;
            this.fileName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.fileName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.fileName.ForeColor = System.Drawing.Color.Black;
            this.fileName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.fileName.Location = new System.Drawing.Point(215, 6);
            this.fileName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fileName.Name = "fileName";
            this.fileName.PasswordChar = '\0';
            this.fileName.PlaceholderText = "";
            this.fileName.ReadOnly = true;
            this.fileName.SelectedText = "";
            this.fileName.Size = new System.Drawing.Size(418, 30);
            this.fileName.TabIndex = 5;
            this.fileName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pnTitleBar
            // 
            this.pnTitleBar.BackColor = System.Drawing.SystemColors.HotTrack;
            this.pnTitleBar.Controls.Add(this.fileName);
            this.pnTitleBar.Controls.Add(this.btMaxi);
            this.pnTitleBar.Controls.Add(this.btClose);
            this.pnTitleBar.Controls.Add(this.menuStrip1);
            this.pnTitleBar.Controls.Add(this.btMini);
            this.pnTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTitleBar.Location = new System.Drawing.Point(0, 0);
            this.pnTitleBar.Name = "pnTitleBar";
            this.pnTitleBar.Size = new System.Drawing.Size(897, 42);
            this.pnTitleBar.TabIndex = 1;
            this.pnTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnTitleBar_MouseDown);
            // 
            // btMaxi
            // 
            this.btMaxi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btMaxi.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btMaxi.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btMaxi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btMaxi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btMaxi.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btMaxi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btMaxi.ForeColor = System.Drawing.Color.White;
            this.btMaxi.Image = global::UI.Properties.Resources.icons8_toggle_full_screen_50;
            this.btMaxi.Location = new System.Drawing.Point(810, 3);
            this.btMaxi.Name = "btMaxi";
            this.btMaxi.Size = new System.Drawing.Size(40, 40);
            this.btMaxi.TabIndex = 4;
            this.btMaxi.Click += new System.EventHandler(this.btMaxi_Click);
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btClose.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btClose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btClose.ForeColor = System.Drawing.Color.White;
            this.btClose.Image = global::UI.Properties.Resources.icons8_close_50;
            this.btClose.Location = new System.Drawing.Point(845, 2);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(40, 40);
            this.btClose.TabIndex = 1;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(9, 6);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(103, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.menuStrip1_MouseDown_1);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.printToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(221, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.saveAsToolStripMenuItem.Text = "Save &As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator3,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.undoToolStripMenuItem.Text = "&Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.redoToolStripMenuItem.Text = "&Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(221, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripMenuItem.Image")));
            this.cutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.cutToolStripMenuItem.Text = "Cu&t";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripMenuItem.Image")));
            this.copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.copyToolStripMenuItem.Text = "&Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripMenuItem.Image")));
            this.pasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.pasteToolStripMenuItem.Text = "&Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // btMini
            // 
            this.btMini.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btMini.FlatAppearance.BorderSize = 0;
            this.btMini.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btMini.Location = new System.Drawing.Point(769, 11);
            this.btMini.Name = "btMini";
            this.btMini.Size = new System.Drawing.Size(44, 28);
            this.btMini.TabIndex = 1;
            this.btMini.Text = "__";
            this.btMini.UseVisualStyleBackColor = true;
            this.btMini.Click += new System.EventHandler(this.btMini_Click);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.printToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.printToolStripMenuItem.Text = "Print";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // dlgPrint
            // 
            this.dlgPrint.UseEXDialog = true;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(897, 536);
            this.Controls.Add(this.pnTitleBar);
            this.Controls.Add(this.pnContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.pnContainer.ResumeLayout(false);
            this.pnContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcMain)).EndInit();
            this.tcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage1)).EndInit();
            this.kryptonPage1.ResumeLayout(false);
            this.pnTitleBar.ResumeLayout(false);
            this.pnTitleBar.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnContainer;
        private System.Windows.Forms.Panel pnTitleBar;
        private System.Windows.Forms.Button btMini;
        private ComponentFactory.Krypton.Navigator.KryptonNavigator tcMain;
        private ComponentFactory.Krypton.Navigator.ButtonSpecNavigator btAdd;
        private ComponentFactory.Krypton.Navigator.KryptonPage kryptonPage1;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btClose1;
        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColorDialog dlgColor;
        private Guna.UI2.WinForms.Guna2Button btSuccess;
        private Guna.UI2.WinForms.Guna2Button btClose;
        private Guna.UI2.WinForms.Guna2Button btMaxi;
        private Guna.UI2.WinForms.Guna2TextBox fileName;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.PrintDialog dlgPrint;
    }
}


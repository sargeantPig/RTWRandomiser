namespace Randomiser
{
    partial class MainForm1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txt_modFolderLoc = new System.Windows.Forms.TextBox();
            this.btn_selModFolder = new System.Windows.Forms.Button();
            this.txt_Output = new System.Windows.Forms.TextBox();
            this.butt_LoadData = new System.Windows.Forms.Button();
            this.txt_FolderPath = new System.Windows.Forms.TextBox();
            this.butt_FolderSelect = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.numupdown_nocities = new System.Windows.Forms.NumericUpDown();
            this.chk_ai = new System.Windows.Forms.CheckBox();
            this.chk_treasury = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chk_UnitSizes = new System.Windows.Forms.CheckBox();
            this.chk_rndSounds = new System.Windows.Forms.CheckBox();
            this.chk_rndStats = new System.Windows.Forms.CheckBox();
            this.chk_costs = new System.Windows.Forms.CheckBox();
            this.txt_Seed = new System.Windows.Forms.TextBox();
            this.chx_useSeed = new System.Windows.Forms.CheckBox();
            this.txt_randomiserOutput = new System.Windows.Forms.TextBox();
            this.but_randomize = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.chk_viewRandomised = new System.Windows.Forms.CheckBox();
            this.chk_viewVanilla = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbox_regions = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_outputview = new System.Windows.Forms.TextBox();
            this.cbox_factions = new System.Windows.Forms.ComboBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.txt_toolsOutput = new System.Windows.Forms.TextBox();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.chk_rndTraining = new System.Windows.Forms.CheckBox();
            this.chk_rndAttri = new System.Windows.Forms.CheckBox();
            this.numUpDown_maxAtrri = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chk_selectAll = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numupdown_nocities)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown_maxAtrri)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(472, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(448, 372);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txt_modFolderLoc);
            this.tabPage1.Controls.Add(this.btn_selModFolder);
            this.tabPage1.Controls.Add(this.txt_Output);
            this.tabPage1.Controls.Add(this.butt_LoadData);
            this.tabPage1.Controls.Add(this.txt_FolderPath);
            this.tabPage1.Controls.Add(this.butt_FolderSelect);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(440, 280);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Load";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txt_modFolderLoc
            // 
            this.txt_modFolderLoc.Location = new System.Drawing.Point(7, 91);
            this.txt_modFolderLoc.Name = "txt_modFolderLoc";
            this.txt_modFolderLoc.ReadOnly = true;
            this.txt_modFolderLoc.Size = new System.Drawing.Size(111, 20);
            this.txt_modFolderLoc.TabIndex = 6;
            // 
            // btn_selModFolder
            // 
            this.btn_selModFolder.Location = new System.Drawing.Point(7, 61);
            this.btn_selModFolder.Name = "btn_selModFolder";
            this.btn_selModFolder.Size = new System.Drawing.Size(111, 23);
            this.btn_selModFolder.TabIndex = 5;
            this.btn_selModFolder.Text = "Select Mod Folder";
            this.btn_selModFolder.UseVisualStyleBackColor = true;
            this.btn_selModFolder.Click += new System.EventHandler(this.btn_selModFolder_Click);
            // 
            // txt_Output
            // 
            this.txt_Output.Location = new System.Drawing.Point(128, 6);
            this.txt_Output.Multiline = true;
            this.txt_Output.Name = "txt_Output";
            this.txt_Output.ReadOnly = true;
            this.txt_Output.Size = new System.Drawing.Size(306, 268);
            this.txt_Output.TabIndex = 4;
            // 
            // butt_LoadData
            // 
            this.butt_LoadData.Location = new System.Drawing.Point(7, 251);
            this.butt_LoadData.Name = "butt_LoadData";
            this.butt_LoadData.Size = new System.Drawing.Size(111, 23);
            this.butt_LoadData.TabIndex = 2;
            this.butt_LoadData.Text = "Load Data";
            this.butt_LoadData.UseVisualStyleBackColor = true;
            this.butt_LoadData.Click += new System.EventHandler(this.butt_LoadData_Click);
            // 
            // txt_FolderPath
            // 
            this.txt_FolderPath.Location = new System.Drawing.Point(7, 35);
            this.txt_FolderPath.Name = "txt_FolderPath";
            this.txt_FolderPath.ReadOnly = true;
            this.txt_FolderPath.Size = new System.Drawing.Size(111, 20);
            this.txt_FolderPath.TabIndex = 1;
            this.txt_FolderPath.WordWrap = false;
            // 
            // butt_FolderSelect
            // 
            this.butt_FolderSelect.Location = new System.Drawing.Point(6, 6);
            this.butt_FolderSelect.Name = "butt_FolderSelect";
            this.butt_FolderSelect.Size = new System.Drawing.Size(112, 23);
            this.butt_FolderSelect.TabIndex = 0;
            this.butt_FolderSelect.Text = "Select RTW Folder";
            this.butt_FolderSelect.UseVisualStyleBackColor = true;
            this.butt_FolderSelect.Click += new System.EventHandler(this.butt_FolderSelect_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.txt_Seed);
            this.tabPage2.Controls.Add(this.chx_useSeed);
            this.tabPage2.Controls.Add(this.txt_randomiserOutput);
            this.tabPage2.Controls.Add(this.but_randomize);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(440, 346);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Randomise";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.numupdown_nocities);
            this.groupBox2.Controls.Add(this.chk_ai);
            this.groupBox2.Controls.Add(this.chk_treasury);
            this.groupBox2.Location = new System.Drawing.Point(163, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(153, 224);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Factions";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 182);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Max No. Cities per faction";
            // 
            // numupdown_nocities
            // 
            this.numupdown_nocities.Location = new System.Drawing.Point(9, 198);
            this.numupdown_nocities.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numupdown_nocities.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numupdown_nocities.Name = "numupdown_nocities";
            this.numupdown_nocities.Size = new System.Drawing.Size(120, 20);
            this.numupdown_nocities.TabIndex = 5;
            this.numupdown_nocities.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // chk_ai
            // 
            this.chk_ai.AutoSize = true;
            this.chk_ai.Location = new System.Drawing.Point(6, 42);
            this.chk_ai.Name = "chk_ai";
            this.chk_ai.Size = new System.Drawing.Size(84, 17);
            this.chk_ai.TabIndex = 3;
            this.chk_ai.Text = "Random Ai?";
            this.chk_ai.UseVisualStyleBackColor = true;
            // 
            // chk_treasury
            // 
            this.chk_treasury.AutoSize = true;
            this.chk_treasury.Location = new System.Drawing.Point(6, 19);
            this.chk_treasury.Name = "chk_treasury";
            this.chk_treasury.Size = new System.Drawing.Size(141, 17);
            this.chk_treasury.TabIndex = 1;
            this.chk_treasury.Text = "Random Start Treasury?";
            this.chk_treasury.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numUpDown_maxAtrri);
            this.groupBox1.Controls.Add(this.chk_rndAttri);
            this.groupBox1.Controls.Add(this.chk_rndTraining);
            this.groupBox1.Controls.Add(this.chk_UnitSizes);
            this.groupBox1.Controls.Add(this.chk_rndSounds);
            this.groupBox1.Controls.Add(this.chk_rndStats);
            this.groupBox1.Controls.Add(this.chk_costs);
            this.groupBox1.Location = new System.Drawing.Point(7, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(149, 224);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Units";
            // 
            // chk_UnitSizes
            // 
            this.chk_UnitSizes.AutoSize = true;
            this.chk_UnitSizes.Location = new System.Drawing.Point(9, 19);
            this.chk_UnitSizes.Name = "chk_UnitSizes";
            this.chk_UnitSizes.Size = new System.Drawing.Size(122, 17);
            this.chk_UnitSizes.TabIndex = 7;
            this.chk_UnitSizes.Text = "Random Unit Sizes?";
            this.chk_UnitSizes.UseVisualStyleBackColor = true;
            // 
            // chk_rndSounds
            // 
            this.chk_rndSounds.AutoSize = true;
            this.chk_rndSounds.Location = new System.Drawing.Point(9, 88);
            this.chk_rndSounds.Name = "chk_rndSounds";
            this.chk_rndSounds.Size = new System.Drawing.Size(133, 17);
            this.chk_rndSounds.TabIndex = 15;
            this.chk_rndSounds.Text = "Random Unit Sounds?";
            this.chk_rndSounds.UseVisualStyleBackColor = true;
            // 
            // chk_rndStats
            // 
            this.chk_rndStats.AutoSize = true;
            this.chk_rndStats.Location = new System.Drawing.Point(9, 65);
            this.chk_rndStats.Name = "chk_rndStats";
            this.chk_rndStats.Size = new System.Drawing.Size(98, 17);
            this.chk_rndStats.TabIndex = 3;
            this.chk_rndStats.Text = "Ransom Stats?";
            this.chk_rndStats.UseVisualStyleBackColor = true;
            // 
            // chk_costs
            // 
            this.chk_costs.AutoSize = true;
            this.chk_costs.Location = new System.Drawing.Point(9, 42);
            this.chk_costs.Name = "chk_costs";
            this.chk_costs.Size = new System.Drawing.Size(101, 17);
            this.chk_costs.TabIndex = 10;
            this.chk_costs.Text = "Random Costs?";
            this.chk_costs.UseVisualStyleBackColor = true;
            // 
            // txt_Seed
            // 
            this.txt_Seed.Location = new System.Drawing.Point(7, 262);
            this.txt_Seed.MaxLength = 20;
            this.txt_Seed.Name = "txt_Seed";
            this.txt_Seed.ShortcutsEnabled = false;
            this.txt_Seed.Size = new System.Drawing.Size(140, 20);
            this.txt_Seed.TabIndex = 18;
            this.txt_Seed.Text = "Enter Seed";
            this.txt_Seed.WordWrap = false;
            // 
            // chx_useSeed
            // 
            this.chx_useSeed.AutoSize = true;
            this.chx_useSeed.Location = new System.Drawing.Point(6, 239);
            this.chx_useSeed.Name = "chx_useSeed";
            this.chx_useSeed.Size = new System.Drawing.Size(77, 17);
            this.chx_useSeed.TabIndex = 17;
            this.chx_useSeed.Text = "Use seed?";
            this.chx_useSeed.UseVisualStyleBackColor = true;
            // 
            // txt_randomiserOutput
            // 
            this.txt_randomiserOutput.Location = new System.Drawing.Point(162, 239);
            this.txt_randomiserOutput.Multiline = true;
            this.txt_randomiserOutput.Name = "txt_randomiserOutput";
            this.txt_randomiserOutput.ReadOnly = true;
            this.txt_randomiserOutput.Size = new System.Drawing.Size(272, 100);
            this.txt_randomiserOutput.TabIndex = 14;
            // 
            // but_randomize
            // 
            this.but_randomize.Location = new System.Drawing.Point(6, 288);
            this.but_randomize.Name = "but_randomize";
            this.but_randomize.Size = new System.Drawing.Size(140, 51);
            this.but_randomize.TabIndex = 8;
            this.but_randomize.Text = "Randomize";
            this.but_randomize.UseVisualStyleBackColor = true;
            this.but_randomize.Click += new System.EventHandler(this.but_randomize_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.chk_viewRandomised);
            this.tabPage3.Controls.Add(this.chk_viewVanilla);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.cbox_regions);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.txt_outputview);
            this.tabPage3.Controls.Add(this.cbox_factions);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(440, 280);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "View";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // chk_viewRandomised
            // 
            this.chk_viewRandomised.AutoSize = true;
            this.chk_viewRandomised.Location = new System.Drawing.Point(7, 236);
            this.chk_viewRandomised.Name = "chk_viewRandomised";
            this.chk_viewRandomised.Size = new System.Drawing.Size(85, 17);
            this.chk_viewRandomised.TabIndex = 6;
            this.chk_viewRandomised.Text = "Randomised";
            this.chk_viewRandomised.UseVisualStyleBackColor = true;
            // 
            // chk_viewVanilla
            // 
            this.chk_viewVanilla.AutoSize = true;
            this.chk_viewVanilla.Location = new System.Drawing.Point(7, 259);
            this.chk_viewVanilla.Name = "chk_viewVanilla";
            this.chk_viewVanilla.Size = new System.Drawing.Size(57, 17);
            this.chk_viewVanilla.TabIndex = 5;
            this.chk_viewVanilla.Text = "Vanilla";
            this.chk_viewVanilla.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Regions";
            // 
            // cbox_regions
            // 
            this.cbox_regions.FormattingEnabled = true;
            this.cbox_regions.Items.AddRange(new object[] {
            "armenia",
            "britons",
            "carthage",
            "dacia",
            "egypt",
            "gauls",
            "germans",
            "greek_cities",
            "macedon",
            "numidia",
            "parthia",
            "pontus",
            "roman",
            "scythia",
            "seleucid",
            "slave",
            "spain",
            "thrace"});
            this.cbox_regions.Location = new System.Drawing.Point(4, 80);
            this.cbox_regions.Name = "cbox_regions";
            this.cbox_regions.Size = new System.Drawing.Size(109, 21);
            this.cbox_regions.Sorted = true;
            this.cbox_regions.TabIndex = 3;
            this.cbox_regions.SelectedIndexChanged += new System.EventHandler(this.cbox_regions_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Faction";
            // 
            // txt_outputview
            // 
            this.txt_outputview.Location = new System.Drawing.Point(119, 3);
            this.txt_outputview.Multiline = true;
            this.txt_outputview.Name = "txt_outputview";
            this.txt_outputview.ReadOnly = true;
            this.txt_outputview.Size = new System.Drawing.Size(318, 274);
            this.txt_outputview.TabIndex = 1;
            // 
            // cbox_factions
            // 
            this.cbox_factions.FormattingEnabled = true;
            this.cbox_factions.Items.AddRange(new object[] {
            "armenia",
            "britons",
            "carthage",
            "dacia",
            "egypt",
            "gauls",
            "germans",
            "greek_cities",
            "macedon",
            "numidia",
            "parthia",
            "pontus",
            "roman",
            "scythia",
            "seleucid",
            "slave",
            "spain",
            "thrace"});
            this.cbox_factions.Location = new System.Drawing.Point(4, 27);
            this.cbox_factions.Name = "cbox_factions";
            this.cbox_factions.Size = new System.Drawing.Size(109, 21);
            this.cbox_factions.Sorted = true;
            this.cbox_factions.TabIndex = 0;
            this.cbox_factions.SelectedIndexChanged += new System.EventHandler(this.cbox_factions_SelectedIndexChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.txt_toolsOutput);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(440, 280);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Tools";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // txt_toolsOutput
            // 
            this.txt_toolsOutput.Location = new System.Drawing.Point(277, 196);
            this.txt_toolsOutput.Multiline = true;
            this.txt_toolsOutput.Name = "txt_toolsOutput";
            this.txt_toolsOutput.ReadOnly = true;
            this.txt_toolsOutput.Size = new System.Drawing.Size(157, 78);
            this.txt_toolsOutput.TabIndex = 2;
            // 
            // chk_rndTraining
            // 
            this.chk_rndTraining.AutoSize = true;
            this.chk_rndTraining.Location = new System.Drawing.Point(9, 111);
            this.chk_rndTraining.Name = "chk_rndTraining";
            this.chk_rndTraining.Size = new System.Drawing.Size(113, 17);
            this.chk_rndTraining.TabIndex = 17;
            this.chk_rndTraining.Text = "Random Training?";
            this.chk_rndTraining.UseVisualStyleBackColor = true;
            // 
            // chk_rndAttri
            // 
            this.chk_rndAttri.AutoSize = true;
            this.chk_rndAttri.Location = new System.Drawing.Point(9, 134);
            this.chk_rndAttri.Name = "chk_rndAttri";
            this.chk_rndAttri.Size = new System.Drawing.Size(119, 17);
            this.chk_rndAttri.TabIndex = 18;
            this.chk_rndAttri.Text = "Random Attributes?";
            this.chk_rndAttri.UseVisualStyleBackColor = true;
            // 
            // numUpDown_maxAtrri
            // 
            this.numUpDown_maxAtrri.Location = new System.Drawing.Point(6, 198);
            this.numUpDown_maxAtrri.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numUpDown_maxAtrri.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDown_maxAtrri.Name = "numUpDown_maxAtrri";
            this.numUpDown_maxAtrri.Size = new System.Drawing.Size(120, 20);
            this.numUpDown_maxAtrri.TabIndex = 7;
            this.numUpDown_maxAtrri.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Max Attributes";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chk_selectAll);
            this.groupBox3.Location = new System.Drawing.Point(323, 9);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(114, 224);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Misc";
            // 
            // chk_selectAll
            // 
            this.chk_selectAll.AutoSize = true;
            this.chk_selectAll.Location = new System.Drawing.Point(6, 19);
            this.chk_selectAll.Name = "chk_selectAll";
            this.chk_selectAll.Size = new System.Drawing.Size(76, 17);
            this.chk_selectAll.TabIndex = 7;
            this.chk_selectAll.Text = "Select All?";
            this.chk_selectAll.UseVisualStyleBackColor = true;
            this.chk_selectAll.CheckedChanged += new System.EventHandler(this.chk_selectAll_CheckedChanged);
            // 
            // MainForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 411);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm1";
            this.Text = "Rome TW Randomiser";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numupdown_nocities)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown_maxAtrri)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txt_FolderPath;
        private System.Windows.Forms.Button butt_FolderSelect;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Button butt_LoadData;
        private System.Windows.Forms.TextBox txt_Output;
        private System.Windows.Forms.TextBox txt_outputview;
        private System.Windows.Forms.ComboBox cbox_factions;
        private System.Windows.Forms.CheckBox chk_costs;
        private System.Windows.Forms.Button but_randomize;
        private System.Windows.Forms.CheckBox chk_UnitSizes;
        private System.Windows.Forms.CheckBox chk_rndStats;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_randomiserOutput;
        private System.Windows.Forms.CheckBox chk_rndSounds;
        private System.Windows.Forms.TextBox txt_modFolderLoc;
        private System.Windows.Forms.Button btn_selModFolder;
        private System.Windows.Forms.TextBox txt_Seed;
        private System.Windows.Forms.CheckBox chx_useSeed;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox txt_toolsOutput;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbox_regions;
        private System.Windows.Forms.CheckBox chk_viewRandomised;
        private System.Windows.Forms.CheckBox chk_viewVanilla;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numupdown_nocities;
        private System.Windows.Forms.CheckBox chk_ai;
        private System.Windows.Forms.CheckBox chk_treasury;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chk_rndTraining;
        private System.Windows.Forms.CheckBox chk_rndAttri;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numUpDown_maxAtrri;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chk_selectAll;
    }
}


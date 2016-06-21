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
            this.txt_FolderPath = new System.Windows.Forms.TextBox();
            this.butt_FolderSelect = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.butt_LoadData = new System.Windows.Forms.Button();
            this.txt_LoadConfirm = new System.Windows.Forms.TextBox();
            this.txt_Output = new System.Windows.Forms.TextBox();
            this.cbox_factions = new System.Windows.Forms.ComboBox();
            this.txt_outputview = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbx_ownershipPerUnit = new System.Windows.Forms.ComboBox();
            this.chk_rndStats = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chk_statsWithReason = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chk_UnitSizes = new System.Windows.Forms.CheckBox();
            this.but_randomize = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.chk_costs = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbx_UnitsPerFaction = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_randomiserOutput = new System.Windows.Forms.TextBox();
            this.chk_rndSounds = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
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
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(448, 306);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txt_Output);
            this.tabPage1.Controls.Add(this.txt_LoadConfirm);
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
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.chk_rndSounds);
            this.tabPage2.Controls.Add(this.txt_randomiserOutput);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.cbx_UnitsPerFaction);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.chk_costs);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.but_randomize);
            this.tabPage2.Controls.Add(this.chk_UnitSizes);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.chk_statsWithReason);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.chk_rndStats);
            this.tabPage2.Controls.Add(this.cbx_ownershipPerUnit);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(440, 280);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Randomise";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
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
            // butt_LoadData
            // 
            this.butt_LoadData.Location = new System.Drawing.Point(7, 61);
            this.butt_LoadData.Name = "butt_LoadData";
            this.butt_LoadData.Size = new System.Drawing.Size(111, 23);
            this.butt_LoadData.TabIndex = 2;
            this.butt_LoadData.Text = "Load Data";
            this.butt_LoadData.UseVisualStyleBackColor = true;
            this.butt_LoadData.Click += new System.EventHandler(this.butt_LoadData_Click);
            // 
            // txt_LoadConfirm
            // 
            this.txt_LoadConfirm.Location = new System.Drawing.Point(7, 90);
            this.txt_LoadConfirm.Name = "txt_LoadConfirm";
            this.txt_LoadConfirm.ReadOnly = true;
            this.txt_LoadConfirm.Size = new System.Drawing.Size(111, 20);
            this.txt_LoadConfirm.TabIndex = 3;
            this.txt_LoadConfirm.Text = "Unloaded";
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
            // txt_outputview
            // 
            this.txt_outputview.Location = new System.Drawing.Point(119, 3);
            this.txt_outputview.Multiline = true;
            this.txt_outputview.Name = "txt_outputview";
            this.txt_outputview.ReadOnly = true;
            this.txt_outputview.Size = new System.Drawing.Size(318, 274);
            this.txt_outputview.TabIndex = 1;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ownership per unit";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(286, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Random Stats?";
            // 
            // cbx_ownershipPerUnit
            // 
            this.cbx_ownershipPerUnit.FormattingEnabled = true;
            this.cbx_ownershipPerUnit.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "RANDOM"});
            this.cbx_ownershipPerUnit.Location = new System.Drawing.Point(10, 24);
            this.cbx_ownershipPerUnit.Name = "cbx_ownershipPerUnit";
            this.cbx_ownershipPerUnit.Size = new System.Drawing.Size(92, 21);
            this.cbx_ownershipPerUnit.TabIndex = 2;
            // 
            // chk_rndStats
            // 
            this.chk_rndStats.AutoSize = true;
            this.chk_rndStats.Location = new System.Drawing.Point(401, 7);
            this.chk_rndStats.Name = "chk_rndStats";
            this.chk_rndStats.Size = new System.Drawing.Size(15, 14);
            this.chk_rndStats.TabIndex = 3;
            this.chk_rndStats.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(286, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Stats within reason?";
            // 
            // chk_statsWithReason
            // 
            this.chk_statsWithReason.AutoSize = true;
            this.chk_statsWithReason.Location = new System.Drawing.Point(401, 33);
            this.chk_statsWithReason.Name = "chk_statsWithReason";
            this.chk_statsWithReason.Size = new System.Drawing.Size(15, 14);
            this.chk_statsWithReason.TabIndex = 5;
            this.chk_statsWithReason.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(118, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Random Unit Sizes?";
            // 
            // chk_UnitSizes
            // 
            this.chk_UnitSizes.AutoSize = true;
            this.chk_UnitSizes.Location = new System.Drawing.Point(227, 8);
            this.chk_UnitSizes.Name = "chk_UnitSizes";
            this.chk_UnitSizes.Size = new System.Drawing.Size(15, 14);
            this.chk_UnitSizes.TabIndex = 7;
            this.chk_UnitSizes.UseVisualStyleBackColor = true;
            // 
            // but_randomize
            // 
            this.but_randomize.Location = new System.Drawing.Point(7, 223);
            this.but_randomize.Name = "but_randomize";
            this.but_randomize.Size = new System.Drawing.Size(126, 51);
            this.but_randomize.TabIndex = 8;
            this.but_randomize.Text = "Randomize";
            this.but_randomize.UseVisualStyleBackColor = true;
            this.but_randomize.Click += new System.EventHandler(this.but_randomize_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(118, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Random Costs?";
            // 
            // chk_costs
            // 
            this.chk_costs.AutoSize = true;
            this.chk_costs.Location = new System.Drawing.Point(227, 32);
            this.chk_costs.Name = "chk_costs";
            this.chk_costs.Size = new System.Drawing.Size(15, 14);
            this.chk_costs.TabIndex = 10;
            this.chk_costs.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Units per faction";
            // 
            // cbx_UnitsPerFaction
            // 
            this.cbx_UnitsPerFaction.FormattingEnabled = true;
            this.cbx_UnitsPerFaction.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "RANDOM"});
            this.cbx_UnitsPerFaction.Location = new System.Drawing.Point(13, 92);
            this.cbx_UnitsPerFaction.Name = "cbx_UnitsPerFaction";
            this.cbx_UnitsPerFaction.Size = new System.Drawing.Size(121, 21);
            this.cbx_UnitsPerFaction.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.DarkRed;
            this.label8.Location = new System.Drawing.Point(140, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "EXPERIMENTAL";
            // 
            // txt_randomiserOutput
            // 
            this.txt_randomiserOutput.Location = new System.Drawing.Point(139, 159);
            this.txt_randomiserOutput.Multiline = true;
            this.txt_randomiserOutput.Name = "txt_randomiserOutput";
            this.txt_randomiserOutput.ReadOnly = true;
            this.txt_randomiserOutput.Size = new System.Drawing.Size(295, 115);
            this.txt_randomiserOutput.TabIndex = 14;
            // 
            // chk_rndSounds
            // 
            this.chk_rndSounds.AutoSize = true;
            this.chk_rndSounds.Location = new System.Drawing.Point(401, 54);
            this.chk_rndSounds.Name = "chk_rndSounds";
            this.chk_rndSounds.Size = new System.Drawing.Size(15, 14);
            this.chk_rndSounds.TabIndex = 15;
            this.chk_rndSounds.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(286, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Random Unit Sounds?";
            // 
            // MainForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 345);
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
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
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
        private System.Windows.Forms.TextBox txt_LoadConfirm;
        private System.Windows.Forms.Button butt_LoadData;
        private System.Windows.Forms.TextBox txt_Output;
        private System.Windows.Forms.TextBox txt_outputview;
        private System.Windows.Forms.ComboBox cbox_factions;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbx_UnitsPerFaction;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chk_costs;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button but_randomize;
        private System.Windows.Forms.CheckBox chk_UnitSizes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chk_statsWithReason;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chk_rndStats;
        private System.Windows.Forms.ComboBox cbx_ownershipPerUnit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_randomiserOutput;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chk_rndSounds;
    }
}


﻿namespace RTWR_RTWLIB
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.btn_load = new System.Windows.Forms.Button();
			this.grp_box_settings = new System.Windows.Forms.GroupBox();
			this.grp_settings_misc = new System.Windows.Forms.GroupBox();
			this.chk_misc_selectU = new System.Windows.Forms.CheckBox();
			this.chk_misc_selectF = new System.Windows.Forms.CheckBox();
			this.chk_misc_selectA = new System.Windows.Forms.CheckBox();
			this.grp_settings_factions = new System.Windows.Forms.GroupBox();
			this.chk_faction_balanced = new System.Windows.Forms.CheckBox();
			this.chk_faction_rosters = new System.Windows.Forms.CheckBox();
			this.chk_faction_ai = new System.Windows.Forms.CheckBox();
			this.chk_faction_treasury = new System.Windows.Forms.CheckBox();
			this.grp_settings_units = new System.Windows.Forms.GroupBox();
			this.chk_unit_groundb = new System.Windows.Forms.CheckBox();
			this.chk_unit_attributes = new System.Windows.Forms.CheckBox();
			this.chk_unit_training = new System.Windows.Forms.CheckBox();
			this.chk_unit_sounds = new System.Windows.Forms.CheckBox();
			this.chk_unit_stats = new System.Windows.Forms.CheckBox();
			this.chk_unit_costs = new System.Windows.Forms.CheckBox();
			this.chk_units_sizes = new System.Windows.Forms.CheckBox();
			this.txt_seed = new System.Windows.Forms.TextBox();
			this.chk_seed = new System.Windows.Forms.CheckBox();
			this.btn_randomise = new System.Windows.Forms.Button();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.lbl_progress = new System.Windows.Forms.ToolStripStatusLabel();
			this.pb_progress = new System.Windows.Forms.ToolStripProgressBar();
			this.numUpDown_unit_attributes = new System.Windows.Forms.NumericUpDown();
			this.lbl_unit_attributes = new System.Windows.Forms.Label();
			this.chk_misc_Ufactions = new System.Windows.Forms.CheckBox();
			this.numUpDown_unit_ownership = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.chk_faction_settlements = new System.Windows.Forms.CheckBox();
			this.numUpDown_faction_cities = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.grp_box_settings.SuspendLayout();
			this.grp_settings_misc.SuspendLayout();
			this.grp_settings_factions.SuspendLayout();
			this.grp_settings_units.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numUpDown_unit_attributes)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numUpDown_unit_ownership)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numUpDown_faction_cities)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Transparent;
			this.panel1.Controls.Add(this.pictureBox1);
			this.panel1.Controls.Add(this.btn_load);
			this.panel1.Controls.Add(this.grp_box_settings);
			this.panel1.Location = new System.Drawing.Point(3, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(719, 358);
			this.panel1.TabIndex = 0;
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackgroundImage = global::RTWR_RTWLIB.Properties.Resources.symbol48_romans_julii;
			this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBox1.InitialImage = null;
			this.pictureBox1.Location = new System.Drawing.Point(9, 8);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(61, 60);
			this.pictureBox1.TabIndex = 3;
			this.pictureBox1.TabStop = false;
			// 
			// btn_load
			// 
			this.btn_load.BackgroundImage = global::RTWR_RTWLIB.Properties.Resources.marble;
			this.btn_load.Location = new System.Drawing.Point(178, 315);
			this.btn_load.Name = "btn_load";
			this.btn_load.Size = new System.Drawing.Size(108, 35);
			this.btn_load.TabIndex = 2;
			this.btn_load.Text = "Load";
			this.btn_load.UseVisualStyleBackColor = true;
			this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
			// 
			// grp_box_settings
			// 
			this.grp_box_settings.Controls.Add(this.grp_settings_misc);
			this.grp_box_settings.Controls.Add(this.grp_settings_factions);
			this.grp_box_settings.Controls.Add(this.grp_settings_units);
			this.grp_box_settings.Controls.Add(this.txt_seed);
			this.grp_box_settings.Controls.Add(this.chk_seed);
			this.grp_box_settings.Controls.Add(this.btn_randomise);
			this.grp_box_settings.Location = new System.Drawing.Point(292, 3);
			this.grp_box_settings.Name = "grp_box_settings";
			this.grp_box_settings.Size = new System.Drawing.Size(414, 352);
			this.grp_box_settings.TabIndex = 0;
			this.grp_box_settings.TabStop = false;
			this.grp_box_settings.Text = "Settings";
			// 
			// grp_settings_misc
			// 
			this.grp_settings_misc.Controls.Add(this.chk_misc_selectU);
			this.grp_settings_misc.Controls.Add(this.chk_misc_selectF);
			this.grp_settings_misc.Controls.Add(this.chk_misc_selectA);
			this.grp_settings_misc.Location = new System.Drawing.Point(283, 20);
			this.grp_settings_misc.Name = "grp_settings_misc";
			this.grp_settings_misc.Size = new System.Drawing.Size(125, 286);
			this.grp_settings_misc.TabIndex = 9;
			this.grp_settings_misc.TabStop = false;
			this.grp_settings_misc.Text = "Misc Settings";
			// 
			// chk_misc_selectU
			// 
			this.chk_misc_selectU.AutoSize = true;
			this.chk_misc_selectU.Location = new System.Drawing.Point(7, 68);
			this.chk_misc_selectU.Name = "chk_misc_selectU";
			this.chk_misc_selectU.Size = new System.Drawing.Size(95, 17);
			this.chk_misc_selectU.TabIndex = 2;
			this.chk_misc_selectU.Text = "Select all unit?";
			this.chk_misc_selectU.UseVisualStyleBackColor = true;
			// 
			// chk_misc_selectF
			// 
			this.chk_misc_selectF.AutoSize = true;
			this.chk_misc_selectF.Location = new System.Drawing.Point(7, 44);
			this.chk_misc_selectF.Name = "chk_misc_selectF";
			this.chk_misc_selectF.Size = new System.Drawing.Size(110, 17);
			this.chk_misc_selectF.TabIndex = 1;
			this.chk_misc_selectF.Text = "Select all faction?";
			this.chk_misc_selectF.UseVisualStyleBackColor = true;
			// 
			// chk_misc_selectA
			// 
			this.chk_misc_selectA.AutoSize = true;
			this.chk_misc_selectA.Location = new System.Drawing.Point(7, 20);
			this.chk_misc_selectA.Name = "chk_misc_selectA";
			this.chk_misc_selectA.Size = new System.Drawing.Size(75, 17);
			this.chk_misc_selectA.TabIndex = 0;
			this.chk_misc_selectA.Text = "Select all?";
			this.chk_misc_selectA.UseVisualStyleBackColor = true;
			this.chk_misc_selectA.CheckedChanged += new System.EventHandler(this.chk_misc_selectA_CheckedChanged);
			// 
			// grp_settings_factions
			// 
			this.grp_settings_factions.Controls.Add(this.label2);
			this.grp_settings_factions.Controls.Add(this.numUpDown_faction_cities);
			this.grp_settings_factions.Controls.Add(this.chk_faction_settlements);
			this.grp_settings_factions.Controls.Add(this.chk_misc_Ufactions);
			this.grp_settings_factions.Controls.Add(this.chk_faction_ai);
			this.grp_settings_factions.Controls.Add(this.chk_faction_treasury);
			this.grp_settings_factions.Location = new System.Drawing.Point(151, 20);
			this.grp_settings_factions.Name = "grp_settings_factions";
			this.grp_settings_factions.Size = new System.Drawing.Size(126, 286);
			this.grp_settings_factions.TabIndex = 8;
			this.grp_settings_factions.TabStop = false;
			this.grp_settings_factions.Text = "Faction Settings";
			// 
			// chk_faction_balanced
			// 
			this.chk_faction_balanced.AutoSize = true;
			this.chk_faction_balanced.Location = new System.Drawing.Point(6, 183);
			this.chk_faction_balanced.Name = "chk_faction_balanced";
			this.chk_faction_balanced.Size = new System.Drawing.Size(111, 17);
			this.chk_faction_balanced.TabIndex = 3;
			this.chk_faction_balanced.Tag = "BalancedRosters?";
			this.chk_faction_balanced.Text = "Balanced rosters?";
			this.chk_faction_balanced.UseVisualStyleBackColor = true;
			// 
			// chk_faction_rosters
			// 
			this.chk_faction_rosters.AutoSize = true;
			this.chk_faction_rosters.Location = new System.Drawing.Point(6, 160);
			this.chk_faction_rosters.Name = "chk_faction_rosters";
			this.chk_faction_rosters.Size = new System.Drawing.Size(125, 17);
			this.chk_faction_rosters.TabIndex = 2;
			this.chk_faction_rosters.Tag = "RandomOwnership";
			this.chk_faction_rosters.Text = "Random Ownership?";
			this.chk_faction_rosters.UseVisualStyleBackColor = true;
			// 
			// chk_faction_ai
			// 
			this.chk_faction_ai.AutoSize = true;
			this.chk_faction_ai.Location = new System.Drawing.Point(7, 43);
			this.chk_faction_ai.Name = "chk_faction_ai";
			this.chk_faction_ai.Size = new System.Drawing.Size(85, 17);
			this.chk_faction_ai.TabIndex = 1;
			this.chk_faction_ai.Tag = "RandomAI";
			this.chk_faction_ai.Text = "Random AI?";
			this.chk_faction_ai.UseVisualStyleBackColor = true;
			// 
			// chk_faction_treasury
			// 
			this.chk_faction_treasury.AutoSize = true;
			this.chk_faction_treasury.Location = new System.Drawing.Point(7, 19);
			this.chk_faction_treasury.Name = "chk_faction_treasury";
			this.chk_faction_treasury.Size = new System.Drawing.Size(112, 17);
			this.chk_faction_treasury.TabIndex = 0;
			this.chk_faction_treasury.Tag = "RandomTreasury";
			this.chk_faction_treasury.Text = "Random treasury?";
			this.chk_faction_treasury.UseVisualStyleBackColor = true;
			// 
			// grp_settings_units
			// 
			this.grp_settings_units.Controls.Add(this.label1);
			this.grp_settings_units.Controls.Add(this.numUpDown_unit_ownership);
			this.grp_settings_units.Controls.Add(this.lbl_unit_attributes);
			this.grp_settings_units.Controls.Add(this.chk_faction_balanced);
			this.grp_settings_units.Controls.Add(this.numUpDown_unit_attributes);
			this.grp_settings_units.Controls.Add(this.chk_faction_rosters);
			this.grp_settings_units.Controls.Add(this.chk_unit_groundb);
			this.grp_settings_units.Controls.Add(this.chk_unit_attributes);
			this.grp_settings_units.Controls.Add(this.chk_unit_training);
			this.grp_settings_units.Controls.Add(this.chk_unit_sounds);
			this.grp_settings_units.Controls.Add(this.chk_unit_stats);
			this.grp_settings_units.Controls.Add(this.chk_unit_costs);
			this.grp_settings_units.Controls.Add(this.chk_units_sizes);
			this.grp_settings_units.Location = new System.Drawing.Point(7, 20);
			this.grp_settings_units.Name = "grp_settings_units";
			this.grp_settings_units.Size = new System.Drawing.Size(138, 286);
			this.grp_settings_units.TabIndex = 7;
			this.grp_settings_units.TabStop = false;
			this.grp_settings_units.Text = "Unit Settings";
			// 
			// chk_unit_groundb
			// 
			this.chk_unit_groundb.AutoSize = true;
			this.chk_unit_groundb.Location = new System.Drawing.Point(6, 137);
			this.chk_unit_groundb.Name = "chk_unit_groundb";
			this.chk_unit_groundb.Size = new System.Drawing.Size(129, 17);
			this.chk_unit_groundb.TabIndex = 12;
			this.chk_unit_groundb.Tag = "RandomGBonus";
			this.chk_unit_groundb.Text = "Rand Ground Bonus?";
			this.chk_unit_groundb.UseVisualStyleBackColor = true;
			// 
			// chk_unit_attributes
			// 
			this.chk_unit_attributes.AutoSize = true;
			this.chk_unit_attributes.Location = new System.Drawing.Point(6, 209);
			this.chk_unit_attributes.Name = "chk_unit_attributes";
			this.chk_unit_attributes.Size = new System.Drawing.Size(119, 17);
			this.chk_unit_attributes.TabIndex = 11;
			this.chk_unit_attributes.Tag = "RandomAttributes";
			this.chk_unit_attributes.Text = "Random Attributes?";
			this.chk_unit_attributes.UseVisualStyleBackColor = true;
			// 
			// chk_unit_training
			// 
			this.chk_unit_training.AutoSize = true;
			this.chk_unit_training.Location = new System.Drawing.Point(6, 114);
			this.chk_unit_training.Name = "chk_unit_training";
			this.chk_unit_training.Size = new System.Drawing.Size(113, 17);
			this.chk_unit_training.TabIndex = 10;
			this.chk_unit_training.Tag = "RandomTraining";
			this.chk_unit_training.Text = "Random Training?";
			this.chk_unit_training.UseVisualStyleBackColor = true;
			// 
			// chk_unit_sounds
			// 
			this.chk_unit_sounds.AutoSize = true;
			this.chk_unit_sounds.Location = new System.Drawing.Point(6, 90);
			this.chk_unit_sounds.Name = "chk_unit_sounds";
			this.chk_unit_sounds.Size = new System.Drawing.Size(111, 17);
			this.chk_unit_sounds.TabIndex = 9;
			this.chk_unit_sounds.Tag = "RandomSounds";
			this.chk_unit_sounds.Text = "Random Sounds?";
			this.chk_unit_sounds.UseVisualStyleBackColor = true;
			// 
			// chk_unit_stats
			// 
			this.chk_unit_stats.AutoSize = true;
			this.chk_unit_stats.Location = new System.Drawing.Point(6, 67);
			this.chk_unit_stats.Name = "chk_unit_stats";
			this.chk_unit_stats.Size = new System.Drawing.Size(99, 17);
			this.chk_unit_stats.TabIndex = 8;
			this.chk_unit_stats.Tag = "RandomStats";
			this.chk_unit_stats.Text = "Random Stats?";
			this.chk_unit_stats.UseVisualStyleBackColor = true;
			// 
			// chk_unit_costs
			// 
			this.chk_unit_costs.AutoSize = true;
			this.chk_unit_costs.Location = new System.Drawing.Point(6, 43);
			this.chk_unit_costs.Name = "chk_unit_costs";
			this.chk_unit_costs.Size = new System.Drawing.Size(101, 17);
			this.chk_unit_costs.TabIndex = 7;
			this.chk_unit_costs.Tag = "RandomCosts";
			this.chk_unit_costs.Text = "Random Costs?";
			this.chk_unit_costs.UseVisualStyleBackColor = true;
			// 
			// chk_units_sizes
			// 
			this.chk_units_sizes.AutoSize = true;
			this.chk_units_sizes.Location = new System.Drawing.Point(6, 19);
			this.chk_units_sizes.Name = "chk_units_sizes";
			this.chk_units_sizes.Size = new System.Drawing.Size(100, 17);
			this.chk_units_sizes.TabIndex = 6;
			this.chk_units_sizes.Tag = "RandomSizes";
			this.chk_units_sizes.Text = "Random Sizes?";
			this.chk_units_sizes.UseVisualStyleBackColor = true;
			// 
			// txt_seed
			// 
			this.txt_seed.Location = new System.Drawing.Point(119, 320);
			this.txt_seed.Name = "txt_seed";
			this.txt_seed.Size = new System.Drawing.Size(159, 20);
			this.txt_seed.TabIndex = 5;
			this.txt_seed.Text = "Seed here";
			// 
			// chk_seed
			// 
			this.chk_seed.AutoSize = true;
			this.chk_seed.Location = new System.Drawing.Point(292, 320);
			this.chk_seed.Name = "chk_seed";
			this.chk_seed.Size = new System.Drawing.Size(73, 17);
			this.chk_seed.TabIndex = 4;
			this.chk_seed.Text = "Use Seed";
			this.chk_seed.UseVisualStyleBackColor = true;
			// 
			// btn_randomise
			// 
			this.btn_randomise.BackColor = System.Drawing.Color.Transparent;
			this.btn_randomise.BackgroundImage = global::RTWR_RTWLIB.Properties.Resources.marble;
			this.btn_randomise.Enabled = false;
			this.btn_randomise.ForeColor = System.Drawing.Color.Black;
			this.btn_randomise.Location = new System.Drawing.Point(7, 312);
			this.btn_randomise.Name = "btn_randomise";
			this.btn_randomise.Size = new System.Drawing.Size(106, 34);
			this.btn_randomise.TabIndex = 3;
			this.btn_randomise.Text = "Randomise";
			this.btn_randomise.UseVisualStyleBackColor = false;
			this.btn_randomise.Click += new System.EventHandler(this.btn_randomise_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.BackColor = System.Drawing.Color.White;
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbl_progress,
            this.pb_progress});
			this.statusStrip1.Location = new System.Drawing.Point(0, 375);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(734, 22);
			this.statusStrip1.TabIndex = 2;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// lbl_progress
			// 
			this.lbl_progress.Name = "lbl_progress";
			this.lbl_progress.Size = new System.Drawing.Size(517, 17);
			this.lbl_progress.Spring = true;
			this.lbl_progress.Text = "            ";
			// 
			// pb_progress
			// 
			this.pb_progress.Name = "pb_progress";
			this.pb_progress.Size = new System.Drawing.Size(200, 16);
			// 
			// numUpDown_unit_attributes
			// 
			this.numUpDown_unit_attributes.Location = new System.Drawing.Point(90, 232);
			this.numUpDown_unit_attributes.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.numUpDown_unit_attributes.Name = "numUpDown_unit_attributes";
			this.numUpDown_unit_attributes.Size = new System.Drawing.Size(35, 20);
			this.numUpDown_unit_attributes.TabIndex = 13;
			this.numUpDown_unit_attributes.Tag = "RandomAttributes";
			// 
			// lbl_unit_attributes
			// 
			this.lbl_unit_attributes.AutoSize = true;
			this.lbl_unit_attributes.Location = new System.Drawing.Point(3, 234);
			this.lbl_unit_attributes.Name = "lbl_unit_attributes";
			this.lbl_unit_attributes.Size = new System.Drawing.Size(74, 13);
			this.lbl_unit_attributes.TabIndex = 14;
			this.lbl_unit_attributes.Text = "Max Attributes";
			// 
			// chk_misc_Ufactions
			// 
			this.chk_misc_Ufactions.AutoSize = true;
			this.chk_misc_Ufactions.Location = new System.Drawing.Point(7, 66);
			this.chk_misc_Ufactions.Name = "chk_misc_Ufactions";
			this.chk_misc_Ufactions.Size = new System.Drawing.Size(106, 17);
			this.chk_misc_Ufactions.TabIndex = 3;
			this.chk_misc_Ufactions.Tag = "UnlockFactions";
			this.chk_misc_Ufactions.Text = "Unlock factions?";
			this.chk_misc_Ufactions.UseVisualStyleBackColor = true;
			// 
			// numUpDown_unit_ownership
			// 
			this.numUpDown_unit_ownership.Location = new System.Drawing.Point(90, 258);
			this.numUpDown_unit_ownership.Name = "numUpDown_unit_ownership";
			this.numUpDown_unit_ownership.Size = new System.Drawing.Size(35, 20);
			this.numUpDown_unit_ownership.TabIndex = 15;
			this.numUpDown_unit_ownership.Tag = "RandomOwnership";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 260);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 13);
			this.label1.TabIndex = 16;
			this.label1.Text = "Max Ownership";
			// 
			// chk_faction_settlements
			// 
			this.chk_faction_settlements.AutoSize = true;
			this.chk_faction_settlements.Location = new System.Drawing.Point(7, 90);
			this.chk_faction_settlements.Name = "chk_faction_settlements";
			this.chk_faction_settlements.Size = new System.Drawing.Size(100, 17);
			this.chk_faction_settlements.TabIndex = 4;
			this.chk_faction_settlements.Tag = "RandomSettlements";
			this.chk_faction_settlements.Text = "Random Cities?";
			this.chk_faction_settlements.UseVisualStyleBackColor = true;
			// 
			// numUpDown_faction_cities
			// 
			this.numUpDown_faction_cities.Location = new System.Drawing.Point(77, 258);
			this.numUpDown_faction_cities.Name = "numUpDown_faction_cities";
			this.numUpDown_faction_cities.Size = new System.Drawing.Size(36, 20);
			this.numUpDown_faction_cities.TabIndex = 5;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 260);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(55, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Max Cities";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::RTWR_RTWLIB.Properties.Resources.marble;
			this.ClientSize = new System.Drawing.Size(734, 397);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.panel1);
			this.Name = "Form1";
			this.Text = "Rome Total War Randomiser";
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.grp_box_settings.ResumeLayout(false);
			this.grp_box_settings.PerformLayout();
			this.grp_settings_misc.ResumeLayout(false);
			this.grp_settings_misc.PerformLayout();
			this.grp_settings_factions.ResumeLayout(false);
			this.grp_settings_factions.PerformLayout();
			this.grp_settings_units.ResumeLayout(false);
			this.grp_settings_units.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numUpDown_unit_attributes)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numUpDown_unit_ownership)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numUpDown_faction_cities)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button btn_load;
		private System.Windows.Forms.GroupBox grp_box_settings;
		private System.Windows.Forms.Button btn_randomise;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripProgressBar pb_progress;
		private System.Windows.Forms.ToolStripStatusLabel lbl_progress;
		private System.Windows.Forms.GroupBox grp_settings_misc;
		private System.Windows.Forms.CheckBox chk_misc_selectU;
		private System.Windows.Forms.CheckBox chk_misc_selectF;
		private System.Windows.Forms.CheckBox chk_misc_selectA;
		private System.Windows.Forms.GroupBox grp_settings_factions;
		private System.Windows.Forms.CheckBox chk_faction_balanced;
		private System.Windows.Forms.CheckBox chk_faction_rosters;
		private System.Windows.Forms.CheckBox chk_faction_ai;
		private System.Windows.Forms.CheckBox chk_faction_treasury;
		private System.Windows.Forms.GroupBox grp_settings_units;
		private System.Windows.Forms.CheckBox chk_unit_groundb;
		private System.Windows.Forms.CheckBox chk_unit_attributes;
		private System.Windows.Forms.CheckBox chk_unit_training;
		private System.Windows.Forms.CheckBox chk_unit_sounds;
		private System.Windows.Forms.CheckBox chk_unit_stats;
		private System.Windows.Forms.CheckBox chk_unit_costs;
		private System.Windows.Forms.CheckBox chk_units_sizes;
		private System.Windows.Forms.TextBox txt_seed;
		private System.Windows.Forms.CheckBox chk_seed;
		private System.Windows.Forms.Label lbl_unit_attributes;
		private System.Windows.Forms.NumericUpDown numUpDown_unit_attributes;
		private System.Windows.Forms.CheckBox chk_misc_Ufactions;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown numUpDown_unit_ownership;
		private System.Windows.Forms.CheckBox chk_faction_settlements;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown numUpDown_faction_cities;
	}
}

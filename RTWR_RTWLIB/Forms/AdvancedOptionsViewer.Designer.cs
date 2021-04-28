namespace RTWR_RTWLIB.Forms
{
    partial class AdvancedOptionsViewer
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
            this.numUpDown_ragingRebelsVal = new System.Windows.Forms.NumericUpDown();
            this.lbl_ragingRebels = new System.Windows.Forms.Label();
            this.grp_advancedSettings = new System.Windows.Forms.GroupBox();
            this.btn_hideAdvancedOptions = new System.Windows.Forms.Button();
            this.chk_realisticAttributes = new System.Windows.Forms.CheckBox();
            this.grp_rdb_ownership_algos = new System.Windows.Forms.GroupBox();
            this.rdb_randomShuffle = new System.Windows.Forms.RadioButton();
            this.rdb_balancedShuffle = new System.Windows.Forms.RadioButton();
            this.rdb_regionShuffling = new System.Windows.Forms.RadioButton();
            this.chk_balanceCosts = new System.Windows.Forms.CheckBox();
            this.chk_rndFarmlvl = new System.Windows.Forms.CheckBox();
            this.chk_rndResources = new System.Windows.Forms.CheckBox();
            this.grp_advRegionModifiers = new System.Windows.Forms.GroupBox();
            this.advToolTips = new System.Windows.Forms.ToolTip(this.components);
            this.chk_equalFarms = new System.Windows.Forms.CheckBox();
            this.grp_unitModifiers = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown_ragingRebelsVal)).BeginInit();
            this.grp_advancedSettings.SuspendLayout();
            this.grp_rdb_ownership_algos.SuspendLayout();
            this.grp_advRegionModifiers.SuspendLayout();
            this.grp_unitModifiers.SuspendLayout();
            this.SuspendLayout();
            // 
            // numUpDown_ragingRebelsVal
            // 
            this.numUpDown_ragingRebelsVal.BackColor = System.Drawing.Color.White;
            this.numUpDown_ragingRebelsVal.Location = new System.Drawing.Point(119, 30);
            this.numUpDown_ragingRebelsVal.Name = "numUpDown_ragingRebelsVal";
            this.numUpDown_ragingRebelsVal.Size = new System.Drawing.Size(30, 20);
            this.numUpDown_ragingRebelsVal.TabIndex = 0;
            // 
            // lbl_ragingRebels
            // 
            this.lbl_ragingRebels.AutoSize = true;
            this.lbl_ragingRebels.BackColor = System.Drawing.Color.Transparent;
            this.lbl_ragingRebels.Location = new System.Drawing.Point(6, 32);
            this.lbl_ragingRebels.Name = "lbl_ragingRebels";
            this.lbl_ragingRebels.Size = new System.Drawing.Size(107, 13);
            this.lbl_ragingRebels.TabIndex = 1;
            this.lbl_ragingRebels.Text = "Raging Rebels Value";
            // 
            // grp_advancedSettings
            // 
            this.grp_advancedSettings.BackColor = System.Drawing.Color.Transparent;
            this.grp_advancedSettings.Controls.Add(this.grp_unitModifiers);
            this.grp_advancedSettings.Controls.Add(this.grp_advRegionModifiers);
            this.grp_advancedSettings.Controls.Add(this.btn_hideAdvancedOptions);
            this.grp_advancedSettings.Controls.Add(this.grp_rdb_ownership_algos);
            this.grp_advancedSettings.Controls.Add(this.lbl_ragingRebels);
            this.grp_advancedSettings.Controls.Add(this.numUpDown_ragingRebelsVal);
            this.grp_advancedSettings.Location = new System.Drawing.Point(12, 12);
            this.grp_advancedSettings.Name = "grp_advancedSettings";
            this.grp_advancedSettings.Size = new System.Drawing.Size(252, 383);
            this.grp_advancedSettings.TabIndex = 2;
            this.grp_advancedSettings.TabStop = false;
            this.grp_advancedSettings.Text = "Advanced Settings";
            // 
            // btn_hideAdvancedOptions
            // 
            this.btn_hideAdvancedOptions.BackgroundImage = global::RTWR_RTWLIB.Properties.Resources.marble;
            this.btn_hideAdvancedOptions.Location = new System.Drawing.Point(171, 354);
            this.btn_hideAdvancedOptions.Name = "btn_hideAdvancedOptions";
            this.btn_hideAdvancedOptions.Size = new System.Drawing.Size(75, 23);
            this.btn_hideAdvancedOptions.TabIndex = 8;
            this.btn_hideAdvancedOptions.Text = "Hide";
            this.btn_hideAdvancedOptions.UseVisualStyleBackColor = true;
            this.btn_hideAdvancedOptions.Click += new System.EventHandler(this.btn_hideAdvancedOptions_Click);
            // 
            // chk_realisticAttributes
            // 
            this.chk_realisticAttributes.AutoSize = true;
            this.chk_realisticAttributes.Location = new System.Drawing.Point(10, 42);
            this.chk_realisticAttributes.Name = "chk_realisticAttributes";
            this.chk_realisticAttributes.Size = new System.Drawing.Size(138, 17);
            this.chk_realisticAttributes.TabIndex = 7;
            this.chk_realisticAttributes.Text = "Realistic unit attributes?";
            this.chk_realisticAttributes.UseVisualStyleBackColor = true;
            // 
            // grp_rdb_ownership_algos
            // 
            this.grp_rdb_ownership_algos.Controls.Add(this.rdb_randomShuffle);
            this.grp_rdb_ownership_algos.Controls.Add(this.rdb_balancedShuffle);
            this.grp_rdb_ownership_algos.Controls.Add(this.rdb_regionShuffling);
            this.grp_rdb_ownership_algos.Location = new System.Drawing.Point(9, 56);
            this.grp_rdb_ownership_algos.Name = "grp_rdb_ownership_algos";
            this.grp_rdb_ownership_algos.Size = new System.Drawing.Size(172, 100);
            this.grp_rdb_ownership_algos.TabIndex = 6;
            this.grp_rdb_ownership_algos.TabStop = false;
            this.grp_rdb_ownership_algos.Text = "Ownership Distribution Method";
            // 
            // rdb_randomShuffle
            // 
            this.rdb_randomShuffle.AutoSize = true;
            this.rdb_randomShuffle.Checked = true;
            this.rdb_randomShuffle.Location = new System.Drawing.Point(6, 69);
            this.rdb_randomShuffle.Name = "rdb_randomShuffle";
            this.rdb_randomShuffle.Size = new System.Drawing.Size(142, 17);
            this.rdb_randomShuffle.TabIndex = 7;
            this.rdb_randomShuffle.TabStop = true;
            this.rdb_randomShuffle.Text = "Random Shuffle (default)";
            this.rdb_randomShuffle.UseVisualStyleBackColor = true;
            // 
            // rdb_balancedShuffle
            // 
            this.rdb_balancedShuffle.AutoSize = true;
            this.rdb_balancedShuffle.Location = new System.Drawing.Point(6, 45);
            this.rdb_balancedShuffle.Name = "rdb_balancedShuffle";
            this.rdb_balancedShuffle.Size = new System.Drawing.Size(106, 17);
            this.rdb_balancedShuffle.TabIndex = 6;
            this.rdb_balancedShuffle.Text = "Balanced Shuffle";
            this.rdb_balancedShuffle.UseVisualStyleBackColor = true;
            // 
            // rdb_regionShuffling
            // 
            this.rdb_regionShuffling.AutoSize = true;
            this.rdb_regionShuffling.Location = new System.Drawing.Point(6, 22);
            this.rdb_regionShuffling.Name = "rdb_regionShuffling";
            this.rdb_regionShuffling.Size = new System.Drawing.Size(133, 17);
            this.rdb_regionShuffling.TabIndex = 5;
            this.rdb_regionShuffling.Text = "Region based shuffling";
            this.rdb_regionShuffling.UseVisualStyleBackColor = true;
            // 
            // chk_balanceCosts
            // 
            this.chk_balanceCosts.AutoSize = true;
            this.chk_balanceCosts.Location = new System.Drawing.Point(10, 19);
            this.chk_balanceCosts.Name = "chk_balanceCosts";
            this.chk_balanceCosts.Size = new System.Drawing.Size(119, 17);
            this.chk_balanceCosts.TabIndex = 4;
            this.chk_balanceCosts.Text = "Balance unit costs?";
            this.chk_balanceCosts.UseVisualStyleBackColor = true;
            // 
            // chk_rndFarmlvl
            // 
            this.chk_rndFarmlvl.AutoSize = true;
            this.chk_rndFarmlvl.Location = new System.Drawing.Point(6, 19);
            this.chk_rndFarmlvl.Name = "chk_rndFarmlvl";
            this.chk_rndFarmlvl.Size = new System.Drawing.Size(121, 17);
            this.chk_rndFarmlvl.TabIndex = 9;
            this.chk_rndFarmlvl.Text = "Random Farm Level";
            this.advToolTips.SetToolTip(this.chk_rndFarmlvl, "The amount of growth/money a region recieves from farms");
            this.chk_rndFarmlvl.UseVisualStyleBackColor = true;
            // 
            // chk_rndResources
            // 
            this.chk_rndResources.AutoSize = true;
            this.chk_rndResources.Location = new System.Drawing.Point(6, 66);
            this.chk_rndResources.Name = "chk_rndResources";
            this.chk_rndResources.Size = new System.Drawing.Size(120, 17);
            this.chk_rndResources.TabIndex = 10;
            this.chk_rndResources.Text = "Random Resources";
            this.advToolTips.SetToolTip(this.chk_rndResources, "Randomly distribute resources across the map");
            this.chk_rndResources.UseVisualStyleBackColor = true;
            // 
            // grp_advRegionModifiers
            // 
            this.grp_advRegionModifiers.Controls.Add(this.chk_equalFarms);
            this.grp_advRegionModifiers.Controls.Add(this.chk_rndFarmlvl);
            this.grp_advRegionModifiers.Controls.Add(this.chk_rndResources);
            this.grp_advRegionModifiers.Location = new System.Drawing.Point(9, 255);
            this.grp_advRegionModifiers.Name = "grp_advRegionModifiers";
            this.grp_advRegionModifiers.Size = new System.Drawing.Size(172, 93);
            this.grp_advRegionModifiers.TabIndex = 11;
            this.grp_advRegionModifiers.TabStop = false;
            this.grp_advRegionModifiers.Text = "Region Modifiers";
            // 
            // chk_equalFarms
            // 
            this.chk_equalFarms.AutoSize = true;
            this.chk_equalFarms.Location = new System.Drawing.Point(6, 43);
            this.chk_equalFarms.Name = "chk_equalFarms";
            this.chk_equalFarms.Size = new System.Drawing.Size(126, 17);
            this.chk_equalFarms.TabIndex = 11;
            this.chk_equalFarms.Text = "Equalise Farm Levels";
            this.advToolTips.SetToolTip(this.chk_equalFarms, "Force all regions to have the same farm level");
            this.chk_equalFarms.UseVisualStyleBackColor = true;
            // 
            // grp_unitModifiers
            // 
            this.grp_unitModifiers.Controls.Add(this.chk_balanceCosts);
            this.grp_unitModifiers.Controls.Add(this.chk_realisticAttributes);
            this.grp_unitModifiers.Location = new System.Drawing.Point(9, 166);
            this.grp_unitModifiers.Name = "grp_unitModifiers";
            this.grp_unitModifiers.Size = new System.Drawing.Size(172, 83);
            this.grp_unitModifiers.TabIndex = 12;
            this.grp_unitModifiers.TabStop = false;
            this.grp_unitModifiers.Text = "Unit Modifiers";
            // 
            // AdvancedOptionsViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::RTWR_RTWLIB.Properties.Resources.marble;
            this.ClientSize = new System.Drawing.Size(276, 407);
            this.ControlBox = false;
            this.Controls.Add(this.grp_advancedSettings);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdvancedOptionsViewer";
            this.ShowInTaskbar = false;
            this.Text = "Advanced Settings";
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown_ragingRebelsVal)).EndInit();
            this.grp_advancedSettings.ResumeLayout(false);
            this.grp_advancedSettings.PerformLayout();
            this.grp_rdb_ownership_algos.ResumeLayout(false);
            this.grp_rdb_ownership_algos.PerformLayout();
            this.grp_advRegionModifiers.ResumeLayout(false);
            this.grp_advRegionModifiers.PerformLayout();
            this.grp_unitModifiers.ResumeLayout(false);
            this.grp_unitModifiers.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numUpDown_ragingRebelsVal;
        private System.Windows.Forms.Label lbl_ragingRebels;
        private System.Windows.Forms.GroupBox grp_advancedSettings;
        private System.Windows.Forms.CheckBox chk_realisticAttributes;
        private System.Windows.Forms.GroupBox grp_rdb_ownership_algos;
        private System.Windows.Forms.RadioButton rdb_randomShuffle;
        private System.Windows.Forms.RadioButton rdb_balancedShuffle;
        private System.Windows.Forms.RadioButton rdb_regionShuffling;
        private System.Windows.Forms.CheckBox chk_balanceCosts;
        private System.Windows.Forms.Button btn_hideAdvancedOptions;
        private System.Windows.Forms.GroupBox grp_advRegionModifiers;
        private System.Windows.Forms.CheckBox chk_rndFarmlvl;
        private System.Windows.Forms.CheckBox chk_rndResources;
        private System.Windows.Forms.ToolTip advToolTips;
        private System.Windows.Forms.GroupBox grp_unitModifiers;
        private System.Windows.Forms.CheckBox chk_equalFarms;
    }
}
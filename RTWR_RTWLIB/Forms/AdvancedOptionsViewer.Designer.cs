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
            this.chk_balanceUnitStats = new System.Windows.Forms.CheckBox();
            this.chk_usizeConstraints = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown_ragingRebelsVal)).BeginInit();
            this.grp_advancedSettings.SuspendLayout();
            this.grp_rdb_ownership_algos.SuspendLayout();
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
            this.grp_advancedSettings.Controls.Add(this.btn_hideAdvancedOptions);
            this.grp_advancedSettings.Controls.Add(this.chk_realisticAttributes);
            this.grp_advancedSettings.Controls.Add(this.grp_rdb_ownership_algos);
            this.grp_advancedSettings.Controls.Add(this.chk_balanceCosts);
            this.grp_advancedSettings.Controls.Add(this.chk_balanceUnitStats);
            this.grp_advancedSettings.Controls.Add(this.chk_usizeConstraints);
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
            this.chk_realisticAttributes.Location = new System.Drawing.Point(9, 218);
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
            this.chk_balanceCosts.Location = new System.Drawing.Point(9, 195);
            this.chk_balanceCosts.Name = "chk_balanceCosts";
            this.chk_balanceCosts.Size = new System.Drawing.Size(119, 17);
            this.chk_balanceCosts.TabIndex = 4;
            this.chk_balanceCosts.Text = "Balance unit costs?";
            this.chk_balanceCosts.UseVisualStyleBackColor = true;
            // 
            // chk_balanceUnitStats
            // 
            this.chk_balanceUnitStats.AutoSize = true;
            this.chk_balanceUnitStats.Location = new System.Drawing.Point(9, 172);
            this.chk_balanceUnitStats.Name = "chk_balanceUnitStats";
            this.chk_balanceUnitStats.Size = new System.Drawing.Size(116, 17);
            this.chk_balanceUnitStats.TabIndex = 3;
            this.chk_balanceUnitStats.Text = "Balance unit stats?";
            this.chk_balanceUnitStats.UseVisualStyleBackColor = true;
            // 
            // chk_usizeConstraints
            // 
            this.chk_usizeConstraints.AutoSize = true;
            this.chk_usizeConstraints.Location = new System.Drawing.Point(9, 241);
            this.chk_usizeConstraints.Name = "chk_usizeConstraints";
            this.chk_usizeConstraints.Size = new System.Drawing.Size(183, 17);
            this.chk_usizeConstraints.TabIndex = 2;
            this.chk_usizeConstraints.Text = "Use custom unit size constraints?";
            this.chk_usizeConstraints.UseVisualStyleBackColor = true;
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
        private System.Windows.Forms.CheckBox chk_balanceUnitStats;
        private System.Windows.Forms.CheckBox chk_usizeConstraints;
        private System.Windows.Forms.Button btn_hideAdvancedOptions;
    }
}
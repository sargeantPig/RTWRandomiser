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
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown_ragingRebelsVal)).BeginInit();
            this.SuspendLayout();
            // 
            // numUpDown_ragingRebelsVal
            // 
            this.numUpDown_ragingRebelsVal.BackColor = System.Drawing.Color.White;
            this.numUpDown_ragingRebelsVal.Location = new System.Drawing.Point(126, 12);
            this.numUpDown_ragingRebelsVal.Name = "numUpDown_ragingRebelsVal";
            this.numUpDown_ragingRebelsVal.Size = new System.Drawing.Size(30, 20);
            this.numUpDown_ragingRebelsVal.TabIndex = 0;
            // 
            // lbl_ragingRebels
            // 
            this.lbl_ragingRebels.AutoSize = true;
            this.lbl_ragingRebels.BackColor = System.Drawing.Color.Transparent;
            this.lbl_ragingRebels.Location = new System.Drawing.Point(12, 14);
            this.lbl_ragingRebels.Name = "lbl_ragingRebels";
            this.lbl_ragingRebels.Size = new System.Drawing.Size(107, 13);
            this.lbl_ragingRebels.TabIndex = 1;
            this.lbl_ragingRebels.Text = "Raging Rebels Value";
            // 
            // AdvancedOptionsViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::RTWR_RTWLIB.Properties.Resources.marble;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbl_ragingRebels);
            this.Controls.Add(this.numUpDown_ragingRebelsVal);
            this.Name = "AdvancedOptionsViewer";
            this.Text = "AdvancedOptions";
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown_ragingRebelsVal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numUpDown_ragingRebelsVal;
        private System.Windows.Forms.Label lbl_ragingRebels;
    }
}
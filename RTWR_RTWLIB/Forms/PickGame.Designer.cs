namespace RTWR_RTWLIB.Forms
{
    partial class PickGame
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
            this.rdb_Rome = new System.Windows.Forms.RadioButton();
            this.rdb_bi = new System.Windows.Forms.RadioButton();
            this.lbl_msg = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_ok = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdb_Rome
            // 
            this.rdb_Rome.AutoSize = true;
            this.rdb_Rome.Location = new System.Drawing.Point(3, 39);
            this.rdb_Rome.Name = "rdb_Rome";
            this.rdb_Rome.Size = new System.Drawing.Size(53, 17);
            this.rdb_Rome.TabIndex = 0;
            this.rdb_Rome.TabStop = true;
            this.rdb_Rome.Text = "Rome";
            this.rdb_Rome.UseVisualStyleBackColor = true;
            // 
            // rdb_bi
            // 
            this.rdb_bi.AutoSize = true;
            this.rdb_bi.Location = new System.Drawing.Point(3, 16);
            this.rdb_bi.Name = "rdb_bi";
            this.rdb_bi.Size = new System.Drawing.Size(113, 17);
            this.rdb_bi.TabIndex = 1;
            this.rdb_bi.TabStop = true;
            this.rdb_bi.Text = "Barbarian Invasion";
            this.rdb_bi.UseVisualStyleBackColor = true;
            // 
            // lbl_msg
            // 
            this.lbl_msg.AutoSize = true;
            this.lbl_msg.Location = new System.Drawing.Point(3, 0);
            this.lbl_msg.Name = "lbl_msg";
            this.lbl_msg.Size = new System.Drawing.Size(141, 13);
            this.lbl_msg.TabIndex = 1;
            this.lbl_msg.Text = "Pick the game to randomise.";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackgroundImage = global::RTWR_RTWLIB.Properties.Resources.backcol;
            this.flowLayoutPanel1.Controls.Add(this.lbl_msg);
            this.flowLayoutPanel1.Controls.Add(this.rdb_bi);
            this.flowLayoutPanel1.Controls.Add(this.rdb_Rome);
            this.flowLayoutPanel1.Controls.Add(this.btn_ok);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(148, 100);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // btn_ok
            // 
            this.btn_ok.Image = global::RTWR_RTWLIB.Properties.Resources.backcol;
            this.btn_ok.Location = new System.Drawing.Point(3, 62);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 2;
            this.btn_ok.Text = "Confirm";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // PickGame
            // 
            this.AcceptButton = this.btn_ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = global::RTWR_RTWLIB.Properties.Resources.backcol;
            this.ClientSize = new System.Drawing.Size(385, 314);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PickGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Select";
            this.TopMost = true;
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rdb_Rome;
        private System.Windows.Forms.RadioButton rdb_bi;
        private System.Windows.Forms.Label lbl_msg;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btn_ok;
    }
}
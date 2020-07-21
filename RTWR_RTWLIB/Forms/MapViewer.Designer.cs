namespace RTWR_RTWLIB
{
    partial class MapViewer
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
            this.pic_map = new System.Windows.Forms.PictureBox();
            this.btn_close = new System.Windows.Forms.Button();
            this.lbl_chosenfaction = new System.Windows.Forms.Label();
            this.dsv_diplo = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.pic_map)).BeginInit();
            this.SuspendLayout();
            // 
            // pic_map
            // 
            this.pic_map.BackColor = System.Drawing.Color.Transparent;
            this.pic_map.Location = new System.Drawing.Point(12, 30);
            this.pic_map.Name = "pic_map";
            this.pic_map.Size = new System.Drawing.Size(473, 353);
            this.pic_map.TabIndex = 0;
            this.pic_map.TabStop = false;
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.Color.Transparent;
            this.btn_close.Location = new System.Drawing.Point(491, 349);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(140, 29);
            this.btn_close.TabIndex = 1;
            this.btn_close.Text = "Close";
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // lbl_chosenfaction
            // 
            this.lbl_chosenfaction.AutoSize = true;
            this.lbl_chosenfaction.Location = new System.Drawing.Point(488, 9);
            this.lbl_chosenfaction.Name = "lbl_chosenfaction";
            this.lbl_chosenfaction.Size = new System.Drawing.Size(35, 13);
            this.lbl_chosenfaction.TabIndex = 2;
            this.lbl_chosenfaction.Text = "label1";
            // 
            // dsv_diplo
            // 
            this.dsv_diplo.BackColor = System.Drawing.Color.Black;
            this.dsv_diplo.ForeColor = System.Drawing.SystemColors.Menu;
            this.dsv_diplo.Location = new System.Drawing.Point(491, 25);
            this.dsv_diplo.Name = "dsv_diplo";
            this.dsv_diplo.Size = new System.Drawing.Size(140, 318);
            this.dsv_diplo.TabIndex = 3;
            this.dsv_diplo.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.dsv_diplo_NodeMouseClick);
            // 
            // MapViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::RTWR_RTWLIB.Properties.Resources.marble;
            this.ClientSize = new System.Drawing.Size(647, 390);
            this.ControlBox = false;
            this.Controls.Add(this.dsv_diplo);
            this.Controls.Add(this.lbl_chosenfaction);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.pic_map);
            this.Name = "MapViewer";
            this.Text = "MapViewer";
            ((System.ComponentModel.ISupportInitialize)(this.pic_map)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_map;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Label lbl_chosenfaction;
        private System.Windows.Forms.TreeView dsv_diplo;
    }
}
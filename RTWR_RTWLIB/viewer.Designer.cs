namespace RTWR_RTWLIB
{
    partial class EDU_viewer
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
            this.lst_units = new System.Windows.Forms.ListBox();
            this.pic_unit = new System.Windows.Forms.PictureBox();
            this.rtxt_unit = new System.Windows.Forms.RichTextBox();
            this.lbl_units = new System.Windows.Forms.Label();
            this.cbx_faction_list = new System.Windows.Forms.ComboBox();
            this.rdb_all = new System.Windows.Forms.RadioButton();
            this.grp_show = new System.Windows.Forms.GroupBox();
            this.rdb_faction_only = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pic_unit)).BeginInit();
            this.grp_show.SuspendLayout();
            this.SuspendLayout();
            // 
            // lst_units
            // 
            this.lst_units.FormattingEnabled = true;
            this.lst_units.Location = new System.Drawing.Point(12, 25);
            this.lst_units.Name = "lst_units";
            this.lst_units.Size = new System.Drawing.Size(138, 407);
            this.lst_units.TabIndex = 0;
            this.lst_units.SelectedIndexChanged += new System.EventHandler(this.lst_units_SelectedIndexChanged);
            // 
            // pic_unit
            // 
            this.pic_unit.BackColor = System.Drawing.Color.Transparent;
            this.pic_unit.Location = new System.Drawing.Point(347, 12);
            this.pic_unit.Name = "pic_unit";
            this.pic_unit.Size = new System.Drawing.Size(138, 132);
            this.pic_unit.TabIndex = 1;
            this.pic_unit.TabStop = false;
            // 
            // rtxt_unit
            // 
            this.rtxt_unit.Location = new System.Drawing.Point(491, 12);
            this.rtxt_unit.Name = "rtxt_unit";
            this.rtxt_unit.ReadOnly = true;
            this.rtxt_unit.Size = new System.Drawing.Size(454, 414);
            this.rtxt_unit.TabIndex = 2;
            this.rtxt_unit.Text = "";
            // 
            // lbl_units
            // 
            this.lbl_units.AutoSize = true;
            this.lbl_units.Location = new System.Drawing.Point(12, 9);
            this.lbl_units.Name = "lbl_units";
            this.lbl_units.Size = new System.Drawing.Size(35, 13);
            this.lbl_units.TabIndex = 3;
            this.lbl_units.Text = "label1";
            // 
            // cbx_faction_list
            // 
            this.cbx_faction_list.FormattingEnabled = true;
            this.cbx_faction_list.Location = new System.Drawing.Point(263, 217);
            this.cbx_faction_list.Name = "cbx_faction_list";
            this.cbx_faction_list.Size = new System.Drawing.Size(121, 21);
            this.cbx_faction_list.TabIndex = 4;
            this.cbx_faction_list.SelectedIndexChanged += new System.EventHandler(this.cbx_faction_list_SelectedIndexChanged);
            // 
            // rdb_all
            // 
            this.rdb_all.AutoSize = true;
            this.rdb_all.Location = new System.Drawing.Point(6, 19);
            this.rdb_all.Name = "rdb_all";
            this.rdb_all.Size = new System.Drawing.Size(66, 17);
            this.rdb_all.TabIndex = 5;
            this.rdb_all.TabStop = true;
            this.rdb_all.Text = "Show All";
            this.rdb_all.UseVisualStyleBackColor = true;
            this.rdb_all.CheckedChanged += new System.EventHandler(this.rdb_all_CheckedChanged);
            // 
            // grp_show
            // 
            this.grp_show.Controls.Add(this.rdb_faction_only);
            this.grp_show.Controls.Add(this.rdb_all);
            this.grp_show.Location = new System.Drawing.Point(156, 217);
            this.grp_show.Name = "grp_show";
            this.grp_show.Size = new System.Drawing.Size(101, 208);
            this.grp_show.TabIndex = 6;
            this.grp_show.TabStop = false;
            this.grp_show.Text = "Show";
            // 
            // rdb_faction_only
            // 
            this.rdb_faction_only.AutoSize = true;
            this.rdb_faction_only.Location = new System.Drawing.Point(6, 43);
            this.rdb_faction_only.Name = "rdb_faction_only";
            this.rdb_faction_only.Size = new System.Drawing.Size(84, 17);
            this.rdb_faction_only.TabIndex = 6;
            this.rdb_faction_only.TabStop = true;
            this.rdb_faction_only.Text = "Faction Only";
            this.rdb_faction_only.UseVisualStyleBackColor = true;
            this.rdb_faction_only.CheckedChanged += new System.EventHandler(this.rdb_faction_only_CheckedChanged);
            // 
            // EDU_viewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::RTWR_RTWLIB.Properties.Resources.marble;
            this.ClientSize = new System.Drawing.Size(957, 450);
            this.Controls.Add(this.grp_show);
            this.Controls.Add(this.cbx_faction_list);
            this.Controls.Add(this.lbl_units);
            this.Controls.Add(this.rtxt_unit);
            this.Controls.Add(this.pic_unit);
            this.Controls.Add(this.lst_units);
            this.Name = "EDU_viewer";
            this.Text = "RTWR EDU Viewer";
            ((System.ComponentModel.ISupportInitialize)(this.pic_unit)).EndInit();
            this.grp_show.ResumeLayout(false);
            this.grp_show.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lst_units;
        private System.Windows.Forms.PictureBox pic_unit;
        private System.Windows.Forms.RichTextBox rtxt_unit;
        private System.Windows.Forms.Label lbl_units;
        private System.Windows.Forms.ComboBox cbx_faction_list;
        private System.Windows.Forms.RadioButton rdb_all;
        private System.Windows.Forms.GroupBox grp_show;
        private System.Windows.Forms.RadioButton rdb_faction_only;
    }
}
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
            this.grp_show = new System.Windows.Forms.GroupBox();
            this.chk_ships = new System.Windows.Forms.CheckBox();
            this.chk_missile_cavalry = new System.Windows.Forms.CheckBox();
            this.chk_missile_infantry = new System.Windows.Forms.CheckBox();
            this.chk_missile = new System.Windows.Forms.CheckBox();
            this.chk_All = new System.Windows.Forms.CheckBox();
            this.chk_spearmen = new System.Windows.Forms.CheckBox();
            this.chk_command = new System.Windows.Forms.CheckBox();
            this.chk_artillery = new System.Windows.Forms.CheckBox();
            this.chk_heavy_cavalry = new System.Windows.Forms.CheckBox();
            this.chk_light_cavalry = new System.Windows.Forms.CheckBox();
            this.chk_cavalry = new System.Windows.Forms.CheckBox();
            this.chk_heavy_infantry = new System.Windows.Forms.CheckBox();
            this.chk_light_infantry = new System.Windows.Forms.CheckBox();
            this.chk_infantry = new System.Windows.Forms.CheckBox();
            this.chk_FactionOnly = new System.Windows.Forms.CheckBox();
            this.grp_highlights = new System.Windows.Forms.GroupBox();
            this.chk_highlight_number = new System.Windows.Forms.CheckBox();
            this.chk_highlight_recruitCost = new System.Windows.Forms.CheckBox();
            this.chk_highlight_upkeep = new System.Windows.Forms.CheckBox();
            this.chk_hightlight_ammo = new System.Windows.Forms.CheckBox();
            this.chk_highlight_missleRange = new System.Windows.Forms.CheckBox();
            this.chk_highlight_chargeb = new System.Windows.Forms.CheckBox();
            this.chk_highlight_defence = new System.Windows.Forms.CheckBox();
            this.chk_highlight_attack = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_unit)).BeginInit();
            this.grp_show.SuspendLayout();
            this.grp_highlights.SuspendLayout();
            this.SuspendLayout();
            // 
            // lst_units
            // 
            this.lst_units.BackColor = System.Drawing.Color.Black;
            this.lst_units.ForeColor = System.Drawing.Color.White;
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
            this.pic_unit.Location = new System.Drawing.Point(300, 25);
            this.pic_unit.Name = "pic_unit";
            this.pic_unit.Size = new System.Drawing.Size(138, 132);
            this.pic_unit.TabIndex = 1;
            this.pic_unit.TabStop = false;
            // 
            // rtxt_unit
            // 
            this.rtxt_unit.BackColor = System.Drawing.Color.Black;
            this.rtxt_unit.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxt_unit.ForeColor = System.Drawing.Color.White;
            this.rtxt_unit.Location = new System.Drawing.Point(444, 25);
            this.rtxt_unit.Name = "rtxt_unit";
            this.rtxt_unit.ReadOnly = true;
            this.rtxt_unit.Size = new System.Drawing.Size(508, 407);
            this.rtxt_unit.TabIndex = 2;
            this.rtxt_unit.Text = "";
            this.rtxt_unit.WordWrap = false;
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
            this.cbx_faction_list.Location = new System.Drawing.Point(156, 25);
            this.cbx_faction_list.Name = "cbx_faction_list";
            this.cbx_faction_list.Size = new System.Drawing.Size(138, 21);
            this.cbx_faction_list.TabIndex = 4;
            this.cbx_faction_list.SelectedIndexChanged += new System.EventHandler(this.cbx_faction_list_SelectedIndexChanged);
            // 
            // grp_show
            // 
            this.grp_show.BackColor = System.Drawing.Color.Transparent;
            this.grp_show.Controls.Add(this.chk_missile_cavalry);
            this.grp_show.Controls.Add(this.chk_missile_infantry);
            this.grp_show.Controls.Add(this.chk_missile);
            this.grp_show.Controls.Add(this.chk_All);
            this.grp_show.Controls.Add(this.chk_spearmen);
            this.grp_show.Controls.Add(this.chk_command);
            this.grp_show.Controls.Add(this.chk_artillery);
            this.grp_show.Controls.Add(this.chk_heavy_cavalry);
            this.grp_show.Controls.Add(this.chk_light_cavalry);
            this.grp_show.Controls.Add(this.chk_cavalry);
            this.grp_show.Controls.Add(this.chk_heavy_infantry);
            this.grp_show.Controls.Add(this.chk_light_infantry);
            this.grp_show.Controls.Add(this.chk_infantry);
            this.grp_show.Location = new System.Drawing.Point(156, 75);
            this.grp_show.Name = "grp_show";
            this.grp_show.Size = new System.Drawing.Size(138, 357);
            this.grp_show.TabIndex = 6;
            this.grp_show.TabStop = false;
            this.grp_show.Text = "Show";
            this.grp_show.Click += new System.EventHandler(this.grp_show_clicked);
            // 
            // chk_ships
            // 
            this.chk_ships.AutoSize = true;
            this.chk_ships.Location = new System.Drawing.Point(7, 318);
            this.chk_ships.Name = "chk_ships";
            this.chk_ships.Size = new System.Drawing.Size(52, 17);
            this.chk_ships.TabIndex = 28;
            this.chk_ships.Text = "Ships";
            this.chk_ships.UseVisualStyleBackColor = true;
            // 
            // chk_missile_cavalry
            // 
            this.chk_missile_cavalry.AutoSize = true;
            this.chk_missile_cavalry.Location = new System.Drawing.Point(7, 295);
            this.chk_missile_cavalry.Name = "chk_missile_cavalry";
            this.chk_missile_cavalry.Size = new System.Drawing.Size(95, 17);
            this.chk_missile_cavalry.TabIndex = 27;
            this.chk_missile_cavalry.Text = "Missile Cavalry";
            this.chk_missile_cavalry.UseVisualStyleBackColor = true;
            this.chk_missile_cavalry.CheckedChanged += new System.EventHandler(this.chk_missile_cavalry_CheckedChanged);
            // 
            // chk_missile_infantry
            // 
            this.chk_missile_infantry.AutoSize = true;
            this.chk_missile_infantry.Location = new System.Drawing.Point(7, 272);
            this.chk_missile_infantry.Name = "chk_missile_infantry";
            this.chk_missile_infantry.Size = new System.Drawing.Size(95, 17);
            this.chk_missile_infantry.TabIndex = 26;
            this.chk_missile_infantry.Text = "Missile Infantry";
            this.chk_missile_infantry.UseVisualStyleBackColor = true;
            this.chk_missile_infantry.CheckedChanged += new System.EventHandler(this.chk_missile_infantry_CheckedChanged);
            // 
            // chk_missile
            // 
            this.chk_missile.AutoSize = true;
            this.chk_missile.Location = new System.Drawing.Point(7, 249);
            this.chk_missile.Name = "chk_missile";
            this.chk_missile.Size = new System.Drawing.Size(57, 17);
            this.chk_missile.TabIndex = 25;
            this.chk_missile.Text = "Missile";
            this.chk_missile.UseVisualStyleBackColor = true;
            this.chk_missile.CheckedChanged += new System.EventHandler(this.chk_missile_CheckedChanged);
            // 
            // chk_All
            // 
            this.chk_All.AutoSize = true;
            this.chk_All.Location = new System.Drawing.Point(7, 19);
            this.chk_All.Name = "chk_All";
            this.chk_All.Size = new System.Drawing.Size(37, 17);
            this.chk_All.TabIndex = 24;
            this.chk_All.Text = "All";
            this.chk_All.UseVisualStyleBackColor = true;
            this.chk_All.CheckedChanged += new System.EventHandler(this.chk_All_CheckedChanged);
            // 
            // chk_spearmen
            // 
            this.chk_spearmen.AutoSize = true;
            this.chk_spearmen.Location = new System.Drawing.Point(7, 226);
            this.chk_spearmen.Name = "chk_spearmen";
            this.chk_spearmen.Size = new System.Drawing.Size(74, 17);
            this.chk_spearmen.TabIndex = 23;
            this.chk_spearmen.Text = "Spearmen";
            this.chk_spearmen.UseVisualStyleBackColor = true;
            this.chk_spearmen.CheckedChanged += new System.EventHandler(this.chk_spearmen_CheckedChanged);
            // 
            // chk_command
            // 
            this.chk_command.AutoSize = true;
            this.chk_command.Location = new System.Drawing.Point(7, 203);
            this.chk_command.Name = "chk_command";
            this.chk_command.Size = new System.Drawing.Size(73, 17);
            this.chk_command.TabIndex = 22;
            this.chk_command.Text = "Command";
            this.chk_command.UseVisualStyleBackColor = true;
            this.chk_command.CheckedChanged += new System.EventHandler(this.chk_command_CheckedChanged);
            // 
            // chk_artillery
            // 
            this.chk_artillery.AutoSize = true;
            this.chk_artillery.Location = new System.Drawing.Point(7, 180);
            this.chk_artillery.Name = "chk_artillery";
            this.chk_artillery.Size = new System.Drawing.Size(59, 17);
            this.chk_artillery.TabIndex = 21;
            this.chk_artillery.Text = "Artillery";
            this.chk_artillery.UseVisualStyleBackColor = true;
            this.chk_artillery.CheckedChanged += new System.EventHandler(this.chk_artillery_CheckedChanged);
            // 
            // chk_heavy_cavalry
            // 
            this.chk_heavy_cavalry.AutoSize = true;
            this.chk_heavy_cavalry.Location = new System.Drawing.Point(7, 157);
            this.chk_heavy_cavalry.Name = "chk_heavy_cavalry";
            this.chk_heavy_cavalry.Size = new System.Drawing.Size(95, 17);
            this.chk_heavy_cavalry.TabIndex = 20;
            this.chk_heavy_cavalry.Text = "Heavy Cavalry";
            this.chk_heavy_cavalry.UseVisualStyleBackColor = true;
            this.chk_heavy_cavalry.CheckedChanged += new System.EventHandler(this.chk_heavy_cavalry_CheckedChanged);
            // 
            // chk_light_cavalry
            // 
            this.chk_light_cavalry.AutoSize = true;
            this.chk_light_cavalry.Location = new System.Drawing.Point(7, 134);
            this.chk_light_cavalry.Name = "chk_light_cavalry";
            this.chk_light_cavalry.Size = new System.Drawing.Size(87, 17);
            this.chk_light_cavalry.TabIndex = 19;
            this.chk_light_cavalry.Text = "Light Cavalry";
            this.chk_light_cavalry.UseVisualStyleBackColor = true;
            this.chk_light_cavalry.CheckedChanged += new System.EventHandler(this.chk_light_cavalry_CheckedChanged);
            // 
            // chk_cavalry
            // 
            this.chk_cavalry.AutoSize = true;
            this.chk_cavalry.Location = new System.Drawing.Point(7, 111);
            this.chk_cavalry.Name = "chk_cavalry";
            this.chk_cavalry.Size = new System.Drawing.Size(61, 17);
            this.chk_cavalry.TabIndex = 18;
            this.chk_cavalry.Text = "Cavalry";
            this.chk_cavalry.UseVisualStyleBackColor = true;
            this.chk_cavalry.CheckedChanged += new System.EventHandler(this.chk_cavalry_CheckedChanged);
            // 
            // chk_heavy_infantry
            // 
            this.chk_heavy_infantry.AutoSize = true;
            this.chk_heavy_infantry.Location = new System.Drawing.Point(7, 88);
            this.chk_heavy_infantry.Name = "chk_heavy_infantry";
            this.chk_heavy_infantry.Size = new System.Drawing.Size(94, 17);
            this.chk_heavy_infantry.TabIndex = 17;
            this.chk_heavy_infantry.Text = "Heavy infantry";
            this.chk_heavy_infantry.UseVisualStyleBackColor = true;
            this.chk_heavy_infantry.CheckedChanged += new System.EventHandler(this.chk_heavy_infantry_CheckedChanged);
            // 
            // chk_light_infantry
            // 
            this.chk_light_infantry.AutoSize = true;
            this.chk_light_infantry.Location = new System.Drawing.Point(7, 65);
            this.chk_light_infantry.Name = "chk_light_infantry";
            this.chk_light_infantry.Size = new System.Drawing.Size(87, 17);
            this.chk_light_infantry.TabIndex = 16;
            this.chk_light_infantry.Text = "Light Infantry";
            this.chk_light_infantry.UseVisualStyleBackColor = true;
            this.chk_light_infantry.CheckedChanged += new System.EventHandler(this.chk_light_infantry_CheckedChanged);
            // 
            // chk_infantry
            // 
            this.chk_infantry.AutoSize = true;
            this.chk_infantry.Location = new System.Drawing.Point(7, 42);
            this.chk_infantry.Name = "chk_infantry";
            this.chk_infantry.Size = new System.Drawing.Size(61, 17);
            this.chk_infantry.TabIndex = 15;
            this.chk_infantry.Text = "Infantry";
            this.chk_infantry.UseVisualStyleBackColor = true;
            this.chk_infantry.CheckedChanged += new System.EventHandler(this.chk_infantry_CheckedChanged);
            // 
            // chk_FactionOnly
            // 
            this.chk_FactionOnly.AutoSize = true;
            this.chk_FactionOnly.Location = new System.Drawing.Point(156, 52);
            this.chk_FactionOnly.Name = "chk_FactionOnly";
            this.chk_FactionOnly.Size = new System.Drawing.Size(85, 17);
            this.chk_FactionOnly.TabIndex = 7;
            this.chk_FactionOnly.Text = "Faction Only";
            this.chk_FactionOnly.UseVisualStyleBackColor = true;
            this.chk_FactionOnly.CheckedChanged += new System.EventHandler(this.chk_FactionOnly_CheckedChanged);
            // 
            // grp_highlights
            // 
            this.grp_highlights.BackColor = System.Drawing.Color.Transparent;
            this.grp_highlights.Controls.Add(this.chk_highlight_number);
            this.grp_highlights.Controls.Add(this.chk_highlight_recruitCost);
            this.grp_highlights.Controls.Add(this.chk_highlight_upkeep);
            this.grp_highlights.Controls.Add(this.chk_hightlight_ammo);
            this.grp_highlights.Controls.Add(this.chk_highlight_missleRange);
            this.grp_highlights.Controls.Add(this.chk_highlight_chargeb);
            this.grp_highlights.Controls.Add(this.chk_highlight_defence);
            this.grp_highlights.Controls.Add(this.chk_highlight_attack);
            this.grp_highlights.Location = new System.Drawing.Point(301, 164);
            this.grp_highlights.Name = "grp_highlights";
            this.grp_highlights.Size = new System.Drawing.Size(137, 242);
            this.grp_highlights.TabIndex = 8;
            this.grp_highlights.TabStop = false;
            this.grp_highlights.Text = "Highlights";
            // 
            // chk_highlight_number
            // 
            this.chk_highlight_number.AutoSize = true;
            this.chk_highlight_number.BackColor = System.Drawing.Color.Tan;
            this.chk_highlight_number.Location = new System.Drawing.Point(7, 188);
            this.chk_highlight_number.Name = "chk_highlight_number";
            this.chk_highlight_number.Size = new System.Drawing.Size(96, 17);
            this.chk_highlight_number.TabIndex = 7;
            this.chk_highlight_number.Tag = "number";
            this.chk_highlight_number.Text = "Soldiers in Unit";
            this.chk_highlight_number.UseVisualStyleBackColor = false;
            // 
            // chk_highlight_recruitCost
            // 
            this.chk_highlight_recruitCost.AutoSize = true;
            this.chk_highlight_recruitCost.BackColor = System.Drawing.Color.LimeGreen;
            this.chk_highlight_recruitCost.ForeColor = System.Drawing.Color.Black;
            this.chk_highlight_recruitCost.Location = new System.Drawing.Point(7, 164);
            this.chk_highlight_recruitCost.Name = "chk_highlight_recruitCost";
            this.chk_highlight_recruitCost.Size = new System.Drawing.Size(84, 17);
            this.chk_highlight_recruitCost.TabIndex = 6;
            this.chk_highlight_recruitCost.Tag = "construct";
            this.chk_highlight_recruitCost.Text = "Recruit Cost";
            this.chk_highlight_recruitCost.UseVisualStyleBackColor = false;
            // 
            // chk_highlight_upkeep
            // 
            this.chk_highlight_upkeep.AutoSize = true;
            this.chk_highlight_upkeep.BackColor = System.Drawing.Color.SteelBlue;
            this.chk_highlight_upkeep.Location = new System.Drawing.Point(7, 140);
            this.chk_highlight_upkeep.Name = "chk_highlight_upkeep";
            this.chk_highlight_upkeep.Size = new System.Drawing.Size(64, 17);
            this.chk_highlight_upkeep.TabIndex = 5;
            this.chk_highlight_upkeep.Tag = "upkeep";
            this.chk_highlight_upkeep.Text = "Upkeep";
            this.chk_highlight_upkeep.UseVisualStyleBackColor = false;
            // 
            // chk_hightlight_ammo
            // 
            this.chk_hightlight_ammo.AutoSize = true;
            this.chk_hightlight_ammo.BackColor = System.Drawing.Color.HotPink;
            this.chk_hightlight_ammo.Location = new System.Drawing.Point(7, 116);
            this.chk_hightlight_ammo.Name = "chk_hightlight_ammo";
            this.chk_hightlight_ammo.Size = new System.Drawing.Size(55, 17);
            this.chk_hightlight_ammo.TabIndex = 4;
            this.chk_hightlight_ammo.Tag = "missileAmmo";
            this.chk_hightlight_ammo.Text = "Ammo";
            this.chk_hightlight_ammo.UseVisualStyleBackColor = false;
            // 
            // chk_highlight_missleRange
            // 
            this.chk_highlight_missleRange.AutoSize = true;
            this.chk_highlight_missleRange.BackColor = System.Drawing.Color.MediumOrchid;
            this.chk_highlight_missleRange.Location = new System.Drawing.Point(7, 92);
            this.chk_highlight_missleRange.Name = "chk_highlight_missleRange";
            this.chk_highlight_missleRange.Size = new System.Drawing.Size(92, 17);
            this.chk_highlight_missleRange.TabIndex = 3;
            this.chk_highlight_missleRange.Tag = "missileRange";
            this.chk_highlight_missleRange.Text = "Missile Range";
            this.chk_highlight_missleRange.UseVisualStyleBackColor = false;
            // 
            // chk_highlight_chargeb
            // 
            this.chk_highlight_chargeb.AutoSize = true;
            this.chk_highlight_chargeb.BackColor = System.Drawing.Color.SandyBrown;
            this.chk_highlight_chargeb.Location = new System.Drawing.Point(7, 68);
            this.chk_highlight_chargeb.Name = "chk_highlight_chargeb";
            this.chk_highlight_chargeb.Size = new System.Drawing.Size(93, 17);
            this.chk_highlight_chargeb.TabIndex = 2;
            this.chk_highlight_chargeb.Tag = "chargeBonus";
            this.chk_highlight_chargeb.Text = "Charge Bonus";
            this.chk_highlight_chargeb.UseVisualStyleBackColor = false;
            // 
            // chk_highlight_defence
            // 
            this.chk_highlight_defence.AutoSize = true;
            this.chk_highlight_defence.BackColor = System.Drawing.Color.LightSeaGreen;
            this.chk_highlight_defence.Location = new System.Drawing.Point(7, 44);
            this.chk_highlight_defence.Name = "chk_highlight_defence";
            this.chk_highlight_defence.Size = new System.Drawing.Size(67, 17);
            this.chk_highlight_defence.TabIndex = 1;
            this.chk_highlight_defence.Tag = "defence";
            this.chk_highlight_defence.Text = "Defence";
            this.chk_highlight_defence.UseVisualStyleBackColor = false;
            // 
            // chk_highlight_attack
            // 
            this.chk_highlight_attack.AutoSize = true;
            this.chk_highlight_attack.BackColor = System.Drawing.Color.LightCoral;
            this.chk_highlight_attack.Location = new System.Drawing.Point(7, 20);
            this.chk_highlight_attack.Name = "chk_highlight_attack";
            this.chk_highlight_attack.Size = new System.Drawing.Size(57, 17);
            this.chk_highlight_attack.TabIndex = 0;
            this.chk_highlight_attack.Tag = "attack";
            this.chk_highlight_attack.Text = "Attack";
            this.chk_highlight_attack.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(301, 412);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(137, 20);
            this.textBox1.TabIndex = 9;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // EDU_viewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::RTWR_RTWLIB.Properties.Resources.marble;
            this.ClientSize = new System.Drawing.Size(964, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.grp_highlights);
            this.Controls.Add(this.chk_FactionOnly);
            this.Controls.Add(this.grp_show);
            this.Controls.Add(this.cbx_faction_list);
            this.Controls.Add(this.lbl_units);
            this.Controls.Add(this.rtxt_unit);
            this.Controls.Add(this.pic_unit);
            this.Controls.Add(this.lst_units);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "EDU_viewer";
            this.Text = "RTWR EDU Viewer";
            ((System.ComponentModel.ISupportInitialize)(this.pic_unit)).EndInit();
            this.grp_show.ResumeLayout(false);
            this.grp_show.PerformLayout();
            this.grp_highlights.ResumeLayout(false);
            this.grp_highlights.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lst_units;
        private System.Windows.Forms.PictureBox pic_unit;
        private System.Windows.Forms.RichTextBox rtxt_unit;
        private System.Windows.Forms.Label lbl_units;
        private System.Windows.Forms.ComboBox cbx_faction_list;
        private System.Windows.Forms.GroupBox grp_show;
        private System.Windows.Forms.CheckBox chk_FactionOnly;
        private System.Windows.Forms.CheckBox chk_missile_cavalry;
        private System.Windows.Forms.CheckBox chk_missile_infantry;
        private System.Windows.Forms.CheckBox chk_missile;
        private System.Windows.Forms.CheckBox chk_All;
        private System.Windows.Forms.CheckBox chk_spearmen;
        private System.Windows.Forms.CheckBox chk_command;
        private System.Windows.Forms.CheckBox chk_artillery;
        private System.Windows.Forms.CheckBox chk_heavy_cavalry;
        private System.Windows.Forms.CheckBox chk_light_cavalry;
        private System.Windows.Forms.CheckBox chk_cavalry;
        private System.Windows.Forms.CheckBox chk_heavy_infantry;
        private System.Windows.Forms.CheckBox chk_light_infantry;
        private System.Windows.Forms.CheckBox chk_infantry;
        private System.Windows.Forms.GroupBox grp_highlights;
        private System.Windows.Forms.CheckBox chk_highlight_attack;
        private System.Windows.Forms.CheckBox chk_highlight_chargeb;
        private System.Windows.Forms.CheckBox chk_highlight_defence;
        private System.Windows.Forms.CheckBox chk_highlight_missleRange;
        private System.Windows.Forms.CheckBox chk_highlight_upkeep;
        private System.Windows.Forms.CheckBox chk_hightlight_ammo;
        private System.Windows.Forms.CheckBox chk_highlight_recruitCost;
        private System.Windows.Forms.CheckBox chk_highlight_number;
        private System.Windows.Forms.CheckBox chk_ships;
        private System.Windows.Forms.TextBox textBox1;
    }
}
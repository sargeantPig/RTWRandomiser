namespace RTWR_RTWLIB.Forms
{
    partial class MapGeneratorForm
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
            this.picbox_maps = new System.Windows.Forms.PictureBox();
            this.btn_generate = new System.Windows.Forms.Button();
            this.lbl_mapName = new System.Windows.Forms.Label();
            this.btn_next = new System.Windows.Forms.Button();
            this.btn_previous = new System.Windows.Forms.Button();
            this.grp_GenOptions = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numupdown_offset = new System.Windows.Forms.NumericUpDown();
            this.lbl_tilt = new System.Windows.Forms.Label();
            this.numupdown_tilt = new System.Windows.Forms.NumericUpDown();
            this.lbl_threads = new System.Windows.Forms.Label();
            this.numUpD_Threads = new System.Windows.Forms.NumericUpDown();
            this.lbl_elevation = new System.Windows.Forms.Label();
            this.numUpDown_elevation = new System.Windows.Forms.NumericUpDown();
            this.lbl_roughness = new System.Windows.Forms.Label();
            this.numUpD_roughness = new System.Windows.Forms.NumericUpDown();
            this.lbl_seaLevel = new System.Windows.Forms.Label();
            this.numUpD_seaLevel = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numUpD_freq = new System.Windows.Forms.NumericUpDown();
            this.lbl_offset = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picbox_maps)).BeginInit();
            this.grp_GenOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numupdown_offset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numupdown_tilt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_Threads)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown_elevation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_roughness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_seaLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_freq)).BeginInit();
            this.SuspendLayout();
            // 
            // picbox_maps
            // 
            this.picbox_maps.Location = new System.Drawing.Point(12, 25);
            this.picbox_maps.Name = "picbox_maps";
            this.picbox_maps.Size = new System.Drawing.Size(637, 363);
            this.picbox_maps.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picbox_maps.TabIndex = 0;
            this.picbox_maps.TabStop = false;
            // 
            // btn_generate
            // 
            this.btn_generate.Location = new System.Drawing.Point(97, 394);
            this.btn_generate.Name = "btn_generate";
            this.btn_generate.Size = new System.Drawing.Size(75, 23);
            this.btn_generate.TabIndex = 1;
            this.btn_generate.Text = "Generate";
            this.btn_generate.UseVisualStyleBackColor = true;
            this.btn_generate.Click += new System.EventHandler(this.btn_generate_Click);
            // 
            // lbl_mapName
            // 
            this.lbl_mapName.AutoSize = true;
            this.lbl_mapName.Location = new System.Drawing.Point(12, 9);
            this.lbl_mapName.Name = "lbl_mapName";
            this.lbl_mapName.Size = new System.Drawing.Size(35, 13);
            this.lbl_mapName.TabIndex = 2;
            this.lbl_mapName.Text = "label1";
            // 
            // btn_next
            // 
            this.btn_next.Location = new System.Drawing.Point(259, 394);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(75, 23);
            this.btn_next.TabIndex = 3;
            this.btn_next.Text = "Next";
            this.btn_next.UseVisualStyleBackColor = true;
            this.btn_next.Click += new System.EventHandler(this.btn_next_Click);
            // 
            // btn_previous
            // 
            this.btn_previous.Location = new System.Drawing.Point(178, 394);
            this.btn_previous.Name = "btn_previous";
            this.btn_previous.Size = new System.Drawing.Size(75, 23);
            this.btn_previous.TabIndex = 4;
            this.btn_previous.Text = "Previous";
            this.btn_previous.UseVisualStyleBackColor = true;
            this.btn_previous.Click += new System.EventHandler(this.btn_previous_Click);
            // 
            // grp_GenOptions
            // 
            this.grp_GenOptions.Controls.Add(this.lbl_offset);
            this.grp_GenOptions.Controls.Add(this.label2);
            this.grp_GenOptions.Controls.Add(this.numupdown_offset);
            this.grp_GenOptions.Controls.Add(this.lbl_tilt);
            this.grp_GenOptions.Controls.Add(this.numupdown_tilt);
            this.grp_GenOptions.Controls.Add(this.lbl_threads);
            this.grp_GenOptions.Controls.Add(this.numUpD_Threads);
            this.grp_GenOptions.Controls.Add(this.lbl_elevation);
            this.grp_GenOptions.Controls.Add(this.numUpDown_elevation);
            this.grp_GenOptions.Controls.Add(this.lbl_roughness);
            this.grp_GenOptions.Controls.Add(this.numUpD_roughness);
            this.grp_GenOptions.Controls.Add(this.lbl_seaLevel);
            this.grp_GenOptions.Controls.Add(this.numUpD_seaLevel);
            this.grp_GenOptions.Controls.Add(this.label1);
            this.grp_GenOptions.Controls.Add(this.numUpD_freq);
            this.grp_GenOptions.Location = new System.Drawing.Point(655, 12);
            this.grp_GenOptions.Name = "grp_GenOptions";
            this.grp_GenOptions.Size = new System.Drawing.Size(133, 279);
            this.grp_GenOptions.TabIndex = 5;
            this.grp_GenOptions.TabStop = false;
            this.grp_GenOptions.Text = "Generation Options";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 0;
            // 
            // numupdown_offset
            // 
            this.numupdown_offset.DecimalPlaces = 2;
            this.numupdown_offset.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numupdown_offset.Location = new System.Drawing.Point(7, 165);
            this.numupdown_offset.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numupdown_offset.Name = "numupdown_offset";
            this.numupdown_offset.Size = new System.Drawing.Size(48, 20);
            this.numupdown_offset.TabIndex = 12;
            this.numupdown_offset.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lbl_tilt
            // 
            this.lbl_tilt.AutoSize = true;
            this.lbl_tilt.Location = new System.Drawing.Point(61, 138);
            this.lbl_tilt.Name = "lbl_tilt";
            this.lbl_tilt.Size = new System.Drawing.Size(64, 13);
            this.lbl_tilt.TabIndex = 11;
            this.lbl_tilt.Text = "Tilt Degrees";
            // 
            // numupdown_tilt
            // 
            this.numupdown_tilt.DecimalPlaces = 2;
            this.numupdown_tilt.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numupdown_tilt.Location = new System.Drawing.Point(7, 136);
            this.numupdown_tilt.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numupdown_tilt.Name = "numupdown_tilt";
            this.numupdown_tilt.Size = new System.Drawing.Size(48, 20);
            this.numupdown_tilt.TabIndex = 10;
            this.numupdown_tilt.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // lbl_threads
            // 
            this.lbl_threads.AutoSize = true;
            this.lbl_threads.Location = new System.Drawing.Point(57, 216);
            this.lbl_threads.Name = "lbl_threads";
            this.lbl_threads.Size = new System.Drawing.Size(46, 13);
            this.lbl_threads.TabIndex = 9;
            this.lbl_threads.Text = "Threads";
            // 
            // numUpD_Threads
            // 
            this.numUpD_Threads.Location = new System.Drawing.Point(3, 214);
            this.numUpD_Threads.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numUpD_Threads.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpD_Threads.Name = "numUpD_Threads";
            this.numUpD_Threads.Size = new System.Drawing.Size(48, 20);
            this.numUpD_Threads.TabIndex = 8;
            this.numUpD_Threads.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // lbl_elevation
            // 
            this.lbl_elevation.AutoSize = true;
            this.lbl_elevation.Location = new System.Drawing.Point(61, 111);
            this.lbl_elevation.Name = "lbl_elevation";
            this.lbl_elevation.Size = new System.Drawing.Size(42, 13);
            this.lbl_elevation.TabIndex = 7;
            this.lbl_elevation.Text = "Land %";
            // 
            // numUpDown_elevation
            // 
            this.numUpDown_elevation.DecimalPlaces = 2;
            this.numUpDown_elevation.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numUpDown_elevation.Location = new System.Drawing.Point(7, 109);
            this.numUpDown_elevation.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numUpDown_elevation.Name = "numUpDown_elevation";
            this.numUpDown_elevation.Size = new System.Drawing.Size(48, 20);
            this.numUpDown_elevation.TabIndex = 6;
            this.numUpDown_elevation.Value = new decimal(new int[] {
            70,
            0,
            0,
            0});
            // 
            // lbl_roughness
            // 
            this.lbl_roughness.AutoSize = true;
            this.lbl_roughness.Location = new System.Drawing.Point(61, 84);
            this.lbl_roughness.Name = "lbl_roughness";
            this.lbl_roughness.Size = new System.Drawing.Size(54, 13);
            this.lbl_roughness.TabIndex = 5;
            this.lbl_roughness.Text = "Lake Size";
            // 
            // numUpD_roughness
            // 
            this.numUpD_roughness.Location = new System.Drawing.Point(7, 82);
            this.numUpD_roughness.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.numUpD_roughness.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpD_roughness.Name = "numUpD_roughness";
            this.numUpD_roughness.Size = new System.Drawing.Size(48, 20);
            this.numUpD_roughness.TabIndex = 4;
            this.numUpD_roughness.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // lbl_seaLevel
            // 
            this.lbl_seaLevel.AutoSize = true;
            this.lbl_seaLevel.Location = new System.Drawing.Point(61, 58);
            this.lbl_seaLevel.Name = "lbl_seaLevel";
            this.lbl_seaLevel.Size = new System.Drawing.Size(55, 13);
            this.lbl_seaLevel.TabIndex = 3;
            this.lbl_seaLevel.Text = "Sea Level";
            // 
            // numUpD_seaLevel
            // 
            this.numUpD_seaLevel.Location = new System.Drawing.Point(7, 56);
            this.numUpD_seaLevel.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.numUpD_seaLevel.Name = "numUpD_seaLevel";
            this.numUpD_seaLevel.Size = new System.Drawing.Size(48, 20);
            this.numUpD_seaLevel.TabIndex = 2;
            this.numUpD_seaLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Border fuzz";
            // 
            // numUpD_freq
            // 
            this.numUpD_freq.Location = new System.Drawing.Point(7, 29);
            this.numUpD_freq.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numUpD_freq.Name = "numUpD_freq";
            this.numUpD_freq.Size = new System.Drawing.Size(48, 20);
            this.numUpD_freq.TabIndex = 0;
            this.numUpD_freq.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // lbl_offset
            // 
            this.lbl_offset.AutoSize = true;
            this.lbl_offset.Location = new System.Drawing.Point(65, 167);
            this.lbl_offset.Name = "lbl_offset";
            this.lbl_offset.Size = new System.Drawing.Size(35, 13);
            this.lbl_offset.TabIndex = 13;
            this.lbl_offset.Text = "Offset";
            // 
            // MapGeneratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::RTWR_RTWLIB.Properties.Resources.marble;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grp_GenOptions);
            this.Controls.Add(this.btn_previous);
            this.Controls.Add(this.btn_next);
            this.Controls.Add(this.lbl_mapName);
            this.Controls.Add(this.btn_generate);
            this.Controls.Add(this.picbox_maps);
            this.Name = "MapGeneratorForm";
            this.Text = "MapGenerator";
            ((System.ComponentModel.ISupportInitialize)(this.picbox_maps)).EndInit();
            this.grp_GenOptions.ResumeLayout(false);
            this.grp_GenOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numupdown_offset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numupdown_tilt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_Threads)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown_elevation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_roughness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_seaLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpD_freq)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picbox_maps;
        private System.Windows.Forms.Button btn_generate;
        private System.Windows.Forms.Label lbl_mapName;
        private System.Windows.Forms.Button btn_next;
        private System.Windows.Forms.Button btn_previous;
        private System.Windows.Forms.GroupBox grp_GenOptions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numUpD_freq;
        private System.Windows.Forms.Label lbl_seaLevel;
        private System.Windows.Forms.NumericUpDown numUpD_seaLevel;
        private System.Windows.Forms.Label lbl_roughness;
        private System.Windows.Forms.NumericUpDown numUpD_roughness;
        private System.Windows.Forms.Label lbl_elevation;
        private System.Windows.Forms.NumericUpDown numUpDown_elevation;
        private System.Windows.Forms.Label lbl_threads;
        private System.Windows.Forms.NumericUpDown numUpD_Threads;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numupdown_offset;
        private System.Windows.Forms.Label lbl_tilt;
        private System.Windows.Forms.NumericUpDown numupdown_tilt;
        private System.Windows.Forms.Label lbl_offset;
    }
}
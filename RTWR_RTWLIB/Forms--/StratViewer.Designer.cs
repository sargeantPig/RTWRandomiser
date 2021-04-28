namespace RTWR_RTWLIB
{
    partial class StratViewer
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
            this.dsv_treeView = new System.Windows.Forms.TreeView();
            this.grp_faction = new System.Windows.Forms.GroupBox();
            this.lbl_armiesVal = new System.Windows.Forms.Label();
            this.lbl_citiesVal = new System.Windows.Forms.Label();
            this.lbl_armies = new System.Windows.Forms.Label();
            this.lbl_No_cities = new System.Windows.Forms.Label();
            this.lbl_treasurylbl = new System.Windows.Forms.Label();
            this.lbl_treasury = new System.Windows.Forms.Label();
            this.btn_campaignMap = new System.Windows.Forms.Button();
            this.pic_symbol = new System.Windows.Forms.PictureBox();
            this.lbl_navies = new System.Windows.Forms.Label();
            this.lbl_naviesVal = new System.Windows.Forms.Label();
            this.lbl_agents = new System.Windows.Forms.Label();
            this.lbl_agentsVal = new System.Windows.Forms.Label();
            this.grp_faction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_symbol)).BeginInit();
            this.SuspendLayout();
            // 
            // dsv_treeView
            // 
            this.dsv_treeView.BackColor = System.Drawing.Color.Black;
            this.dsv_treeView.ForeColor = System.Drawing.Color.White;
            this.dsv_treeView.Location = new System.Drawing.Point(12, 12);
            this.dsv_treeView.Name = "dsv_treeView";
            this.dsv_treeView.Size = new System.Drawing.Size(280, 426);
            this.dsv_treeView.TabIndex = 0;
            this.dsv_treeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.dsv_treeView_NodeMouseClick);
            // 
            // grp_faction
            // 
            this.grp_faction.BackColor = System.Drawing.Color.Transparent;
            this.grp_faction.Controls.Add(this.lbl_agentsVal);
            this.grp_faction.Controls.Add(this.lbl_agents);
            this.grp_faction.Controls.Add(this.lbl_naviesVal);
            this.grp_faction.Controls.Add(this.lbl_navies);
            this.grp_faction.Controls.Add(this.lbl_armiesVal);
            this.grp_faction.Controls.Add(this.lbl_citiesVal);
            this.grp_faction.Controls.Add(this.lbl_armies);
            this.grp_faction.Controls.Add(this.lbl_No_cities);
            this.grp_faction.Controls.Add(this.lbl_treasurylbl);
            this.grp_faction.Controls.Add(this.lbl_treasury);
            this.grp_faction.Location = new System.Drawing.Point(312, 123);
            this.grp_faction.Name = "grp_faction";
            this.grp_faction.Size = new System.Drawing.Size(102, 138);
            this.grp_faction.TabIndex = 1;
            this.grp_faction.TabStop = false;
            this.grp_faction.Text = "Faction Details";
            // 
            // lbl_armiesVal
            // 
            this.lbl_armiesVal.AutoSize = true;
            this.lbl_armiesVal.Location = new System.Drawing.Point(61, 64);
            this.lbl_armiesVal.Name = "lbl_armiesVal";
            this.lbl_armiesVal.Size = new System.Drawing.Size(0, 13);
            this.lbl_armiesVal.TabIndex = 5;
            // 
            // lbl_citiesVal
            // 
            this.lbl_citiesVal.AutoSize = true;
            this.lbl_citiesVal.Location = new System.Drawing.Point(61, 42);
            this.lbl_citiesVal.Name = "lbl_citiesVal";
            this.lbl_citiesVal.Size = new System.Drawing.Size(0, 13);
            this.lbl_citiesVal.TabIndex = 4;
            // 
            // lbl_armies
            // 
            this.lbl_armies.AutoSize = true;
            this.lbl_armies.Location = new System.Drawing.Point(6, 64);
            this.lbl_armies.Name = "lbl_armies";
            this.lbl_armies.Size = new System.Drawing.Size(38, 13);
            this.lbl_armies.TabIndex = 3;
            this.lbl_armies.Text = "Armies";
            // 
            // lbl_No_cities
            // 
            this.lbl_No_cities.AutoSize = true;
            this.lbl_No_cities.Location = new System.Drawing.Point(7, 42);
            this.lbl_No_cities.Name = "lbl_No_cities";
            this.lbl_No_cities.Size = new System.Drawing.Size(32, 13);
            this.lbl_No_cities.TabIndex = 2;
            this.lbl_No_cities.Text = "Cities";
            // 
            // lbl_treasurylbl
            // 
            this.lbl_treasurylbl.AutoSize = true;
            this.lbl_treasurylbl.Location = new System.Drawing.Point(6, 20);
            this.lbl_treasurylbl.Name = "lbl_treasurylbl";
            this.lbl_treasurylbl.Size = new System.Drawing.Size(48, 13);
            this.lbl_treasurylbl.TabIndex = 1;
            this.lbl_treasurylbl.Text = "Treasury";
            // 
            // lbl_treasury
            // 
            this.lbl_treasury.AutoSize = true;
            this.lbl_treasury.Location = new System.Drawing.Point(61, 20);
            this.lbl_treasury.Name = "lbl_treasury";
            this.lbl_treasury.Size = new System.Drawing.Size(0, 13);
            this.lbl_treasury.TabIndex = 0;
            // 
            // btn_campaignMap
            // 
            this.btn_campaignMap.BackColor = System.Drawing.Color.Transparent;
            this.btn_campaignMap.BackgroundImage = global::RTWR_RTWLIB.Properties.Resources.marble;
            this.btn_campaignMap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_campaignMap.Location = new System.Drawing.Point(312, 398);
            this.btn_campaignMap.Name = "btn_campaignMap";
            this.btn_campaignMap.Size = new System.Drawing.Size(102, 39);
            this.btn_campaignMap.TabIndex = 2;
            this.btn_campaignMap.Text = "Map View";
            this.btn_campaignMap.UseVisualStyleBackColor = false;
            this.btn_campaignMap.Click += new System.EventHandler(this.btn_campaignMap_Click);
            // 
            // pic_symbol
            // 
            this.pic_symbol.BackColor = System.Drawing.Color.Transparent;
            this.pic_symbol.Location = new System.Drawing.Point(298, 12);
            this.pic_symbol.Name = "pic_symbol";
            this.pic_symbol.Size = new System.Drawing.Size(102, 105);
            this.pic_symbol.TabIndex = 3;
            this.pic_symbol.TabStop = false;
            // 
            // lbl_navies
            // 
            this.lbl_navies.AutoSize = true;
            this.lbl_navies.Location = new System.Drawing.Point(7, 90);
            this.lbl_navies.Name = "lbl_navies";
            this.lbl_navies.Size = new System.Drawing.Size(40, 13);
            this.lbl_navies.TabIndex = 6;
            this.lbl_navies.Text = "Navies";
            // 
            // lbl_naviesVal
            // 
            this.lbl_naviesVal.AutoSize = true;
            this.lbl_naviesVal.Location = new System.Drawing.Point(61, 90);
            this.lbl_naviesVal.Name = "lbl_naviesVal";
            this.lbl_naviesVal.Size = new System.Drawing.Size(0, 13);
            this.lbl_naviesVal.TabIndex = 7;
            // 
            // lbl_agents
            // 
            this.lbl_agents.AutoSize = true;
            this.lbl_agents.Location = new System.Drawing.Point(9, 113);
            this.lbl_agents.Name = "lbl_agents";
            this.lbl_agents.Size = new System.Drawing.Size(40, 13);
            this.lbl_agents.TabIndex = 8;
            this.lbl_agents.Text = "Agents";
            // 
            // lbl_agentsVal
            // 
            this.lbl_agentsVal.AutoSize = true;
            this.lbl_agentsVal.Location = new System.Drawing.Point(61, 113);
            this.lbl_agentsVal.Name = "lbl_agentsVal";
            this.lbl_agentsVal.Size = new System.Drawing.Size(0, 13);
            this.lbl_agentsVal.TabIndex = 9;
            // 
            // StratViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::RTWR_RTWLIB.Properties.Resources.marble;
            this.ClientSize = new System.Drawing.Size(424, 450);
            this.Controls.Add(this.pic_symbol);
            this.Controls.Add(this.btn_campaignMap);
            this.Controls.Add(this.grp_faction);
            this.Controls.Add(this.dsv_treeView);
            this.Name = "StratViewer";
            this.Text = "Descr_Strat Viewer";
            this.grp_faction.ResumeLayout(false);
            this.grp_faction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_symbol)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView dsv_treeView;
        private System.Windows.Forms.GroupBox grp_faction;
        private System.Windows.Forms.Label lbl_armies;
        private System.Windows.Forms.Label lbl_No_cities;
        private System.Windows.Forms.Label lbl_treasurylbl;
        private System.Windows.Forms.Label lbl_treasury;
        private System.Windows.Forms.Label lbl_armiesVal;
        private System.Windows.Forms.Label lbl_citiesVal;
        private System.Windows.Forms.Button btn_campaignMap;
        private System.Windows.Forms.PictureBox pic_symbol;
        private System.Windows.Forms.Label lbl_agentsVal;
        private System.Windows.Forms.Label lbl_agents;
        private System.Windows.Forms.Label lbl_naviesVal;
        private System.Windows.Forms.Label lbl_navies;
    }
}
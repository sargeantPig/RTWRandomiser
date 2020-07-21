using RTWLib.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.PerformanceData;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTWR_RTWLIB
{
    public partial class MapViewer : Form
    {
        TreeView ds;
        StratViewer sv;
        public MapViewer(TreeView ds, StratViewer sv)
        {
            this.Icon = RTWR_RTWLIB.Properties.Resources.julii_icon;
            this.ds = ds;
            this.sv = sv;
            InitializeComponent();
        }

        public void SetMapImage(Image img)
        {
            pic_map.Image = img;
        }

        public void PopulateDiplo(string faction)
        {
            dsv_diplo.Nodes.Clear();
            dsv_diplo.Nodes.Add((TreeNode)ds.Nodes[faction].Nodes["Relationships"].Clone());
            dsv_diplo.Nodes["Relationships"].Nodes["Allied"].ForeColor = Color.Green;
            dsv_diplo.Nodes["Relationships"].Nodes["Neutral"].ForeColor = Color.Aqua;
            dsv_diplo.Nodes["Relationships"].Nodes["Hostile"].ForeColor = Color.MediumVioletRed;
            dsv_diplo.Nodes["Relationships"].Nodes["Suspicous"].ForeColor = Color.Blue;
            dsv_diplo.Nodes["Relationships"].Nodes["At War"].ForeColor = Color.DarkRed;
            dsv_diplo.ExpandAll();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void SetData(string selectedfaction)
        {

            lbl_chosenfaction.Text = selectedfaction;
        }

        private void dsv_diplo_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string selected = e.Node.Text;
            LookUpTables lut = new LookUpTables();
            if (lut.LookUpKey<FactionOwnership>(selected) != null)
            {
                sv.UpdateScreens(selected);
            }

        }
    }
}

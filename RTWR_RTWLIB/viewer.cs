using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RTWLib.Functions;
using RTWLib.Objects;
using RTWLib.Data;
using ImageMagick;
using System.IO;

namespace RTWR_RTWLIB
{
    public partial class EDU_viewer : Form
    {
        EDU edu;
        public EDU_viewer(EDU edu)
        {
            this.edu = edu;
            InitializeComponent();

            lst_units.Items.AddRange(edu.GetUnitNameList());
            lst_units.SetSelected(1, true);
            Unit unit = edu.FindUnit((string)lst_units.SelectedItem);
            rtxt_unit.Text = unit.unitOutput();
            UpdateUnitLabel();
            cbx_faction_list.Items.AddRange(LookUpTables.dic_factions.Values.ToArray());
        }

        private void lst_units_SelectedIndexChanged(object sender, EventArgs e)
        {
            Unit unit = edu.FindUnit((string)lst_units.SelectedItem);
            rtxt_unit.Text = unit.unitOutput();
            ChangeUnitPic();
        }
        private void ChangeUnitPic()
        {
            if (Directory.Exists(@"randomiser\data\ui\units\assets\"))
            {
                string unit = (string)lst_units.SelectedItem;
                string name = "#" + unit + ".tga";
                string fullpath = FilePaths.ASSETS + name;
                if(File.Exists(fullpath))
                {
                    MagickImage image = new MagickImage(fullpath);
                    image.Scale(new Percentage(200));
                    pic_unit.Image = image.ToBitmap();
                }
                else pic_unit.Load(@"randomiser\error.png");

            }
            else
                pic_unit.Load(@"randomiser\error.png");
        }

        private void rdb_all_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_all.Checked)
            {
                lst_units.Items.Clear();
                lst_units.Items.AddRange(edu.GetUnitNameList());
                UpdateUnitLabel();
            }
        }

        private void rdb_faction_only_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_faction_only.Checked)
            {
                GetUnitsInFaction();
            }
        }

        private void GetUnitsInFaction()
        {
            lst_units.Items.Clear();
            List<Unit> units = edu.FindUnitsByFaction((string)cbx_faction_list.SelectedItem);
            foreach (Unit unit in units)
            {
                lst_units.Items.Add(unit.dictionary);
            }
            UpdateUnitLabel();
        }

        private void cbx_faction_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(rdb_faction_only.Checked)
                GetUnitsInFaction();
        }

        private void UpdateUnitLabel()
        {
            lbl_units.Text = lst_units.Items.Count.ToString() + " units";
        }
    }
}

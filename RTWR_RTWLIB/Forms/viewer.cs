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
using RTWR_RTWLIB.Data;
using RTWLib.Functions.EDU;
namespace RTWR_RTWLIB
{
    public partial class EDU_viewer : Form
    {
        EDU edu;
        StratViewer sv;
        bool isUpdating = false;

        string[] errorpic = new string[] { 
            @"randomiser\error.png",
            @"mods\mrandomiser\error.png"};

        int errorAccess = 0;

        public EDU_viewer(EDU edu, bool isM2tw)
        {
            this.Icon = RTWR_RTWLIB.Properties.Resources.julii_icon;
            this.edu = edu;

            if (isM2tw)
                errorAccess = 1;

            InitializeComponent();

            lst_units.Items.AddRange(edu.GetUnitNameList());
            lst_units.SetSelected(1, true);
            lst_units.SelectedIndex = 1;

            UpdateUnitTxt();
            
            UpdateUnitLabel();
            cbx_faction_list.Items.AddRange(LookUpTables.dic_factions.Values.ToArray());
            cbx_faction_list.SelectedIndex = 0;
            chk_All.Checked = true;
        }

        private void lst_units_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!isUpdating)
                UpdateUnitTxt();
        }
        private void ChangeUnitPic()
        {
            if (Directory.Exists(FileDestinations.ASSETS))
            {
                string unit = (string)lst_units.SelectedItem;
                string name = unit.ToUpper() + "_INFO.tga";
                string fullpath = FileDestinations.ASSETS + name;
                if (File.Exists(fullpath))
                {
                    MagickImage image = new MagickImage(fullpath);
                    image.Scale(new Percentage(100));
                    pic_unit.Image = image.ToBitmap();
                }
                else pic_unit.Load(errorpic[errorAccess]);

            }
            else
                pic_unit.Load(errorpic[errorAccess]);
        }

        private void GetUnitsInFaction()
        {
            /*lst_units.Items.Clear();
            List<Unit> units = edu.FindUnitsByFaction((string)cbx_faction_list.SelectedItem);
            foreach (Unit unit in units)
            {
                lst_units.Items.Add(unit.dictionary);
            }
            UpdateUnitLabel();*/
        }

        private void cbx_faction_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chk_FactionOnly.Checked)
                ReloadUnitList();
        }

        private void UpdateUnitLabel()
        {
            lbl_units.Text = lst_units.Items.Count.ToString() + " units";
        }

        private void ReloadUnitList()
        {
            lst_units.Items.Clear();
            List<string> args = new List<string>();
            bool usefaction = chk_FactionOnly.Checked;
            string faction = null;
            if (usefaction)
                faction = (string)cbx_faction_list.SelectedItem;
            if (chk_infantry.Checked)
                args.Add("infantry");
            if (chk_cavalry.Checked)
                args.Add("cavalry");
            if (chk_light_infantry.Checked)
                args.Add("light infantry");
            if (chk_heavy_infantry.Checked)
                args.Add("heavy infantry");
            if (chk_light_cavalry.Checked)
                args.Add("light cavalry");
            if (chk_heavy_cavalry.Checked)
                args.Add("heavy cavalry");
            if (chk_artillery.Checked)
                args.Add("siege");
            if (chk_missile.Checked)
                args.Add("missile");
            if (chk_missile_cavalry.Checked)
                args.Add("missile cavalry");
            if (chk_missile_infantry.Checked)
                args.Add("missile infantry");
            if (chk_spearmen.Checked)
                args.Add("spearmen");
            if (chk_ships.Checked)
                args.Add("ship");
            if (chk_command.Checked)
                args.Add("general");
            if (chk_All.Checked)
                args.Add("All");

            List<Unit> units = edu.FindUnitsByArgAndFaction(args.ToArray(), faction, usefaction);

            foreach (Unit unit in units)
            {
                lst_units.Items.Add(unit.dic);
            }
            UpdateUnitLabel();
        }

        private void grp_show_clicked(object sender, EventArgs e)
        {
            ReloadUnitList();
        }

        private void chk_All_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_All.Checked)
            {
                foreach (Control c in grp_show.Controls)
                {
                    if (c is CheckBox && c != (CheckBox)sender)
                    {
                        ((CheckBox)c).Checked = false;
                    }
                }
            }

            ReloadUnitList();

        }

        private void chk_infantry_CheckedChanged(object sender, EventArgs e)
        {
            Uncheck_all(sender);
            ReloadUnitList();
        }

        private void chk_light_infantry_CheckedChanged(object sender, EventArgs e)
        {
            Uncheck_all(sender);
            ReloadUnitList();
        }

        private void chk_heavy_infantry_CheckedChanged(object sender, EventArgs e)
        {
            Uncheck_all(sender);
            ReloadUnitList();
        }

        private void chk_cavalry_CheckedChanged(object sender, EventArgs e)
        {
            Uncheck_all(sender);
            ReloadUnitList();
        }

        private void chk_light_cavalry_CheckedChanged(object sender, EventArgs e)
        {
            Uncheck_all(sender);
            ReloadUnitList();
        }

        private void chk_heavy_cavalry_CheckedChanged(object sender, EventArgs e)
        {
            Uncheck_all(sender);
            ReloadUnitList();
        }

        private void chk_artillery_CheckedChanged(object sender, EventArgs e)
        {
            Uncheck_all(sender);
            ReloadUnitList();
        }

        private void chk_command_CheckedChanged(object sender, EventArgs e)
        {
            Uncheck_all(sender);
            ReloadUnitList();
        }

        private void chk_spearmen_CheckedChanged(object sender, EventArgs e)
        {
            Uncheck_all(sender);
            ReloadUnitList();
        }

        private void chk_missile_CheckedChanged(object sender, EventArgs e)
        {
            Uncheck_all(sender);
            ReloadUnitList();
        }

        private void chk_missile_infantry_CheckedChanged(object sender, EventArgs e)
        {
            Uncheck_all(sender);
            ReloadUnitList();
        }

        private void chk_missile_cavalry_CheckedChanged(object sender, EventArgs e)
        {
            Uncheck_all(sender);
            ReloadUnitList();
        }

        private void chk_FactionOnly_CheckedChanged(object sender, EventArgs e)
        {
            ReloadUnitList();
        }

        private void Uncheck_all(object sender)
        {
            if (((CheckBox)sender).Checked)
                chk_All.Checked = false;

        }

        private Dictionary<string, Color> GetHighlightArgs()
        {
            Dictionary<string, Color> items = new Dictionary<string, Color>();
            foreach (Control ctrl in grp_highlights.Controls)
            {
                if (((CheckBox)ctrl).Checked)
                    items.Add((string)((CheckBox)ctrl).Tag, ctrl.BackColor);
            }
            return items;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == '\r')
                UpdateUnitTxt(((TextBox)sender).Text);
        }

        public void UpdateUnitTxt(string command = null, string lookup = null)
        {
            isUpdating = true;

            if (lst_units.Items.Count == 0 || lookup != null)
            {
                chk_All.Checked = true;
            }


            if (lst_units.SelectedItem == null)
                lst_units.SelectedItem = lst_units.Items[0];

            string search = (string)lst_units.SelectedItem;

            if (lookup != null)
            {
                search = lookup;
            }
            rtxt_unit.Clear();
           
            Unit unit = edu.FindUnit(search);

            lst_units.SelectedItem = unit.dic;

            Dictionary<string, Color> highlights = GetHighlightArgs();

            if (command != null)
                highlights.Add(command, Color.DarkRed);

            string text = unit.unitOutput();
            string[] linedOutput = text.Split('\r');
            Dictionary<int, Color> marked = new Dictionary<int, Color>();
            foreach (string line in linedOutput)
            {
                foreach (KeyValuePair<string, Color> light in highlights)
                {
                    if (EDU.edu_scheme.Scheme.ContainsKey(LibFuncs.GetFirstWord(line.Trim())))
                    {
                        Dictionary<string, int> components = EDU.edu_scheme.GetComponents(LibFuncs.GetFirstWord(line.Trim()));
                        if (components.ContainsKey(light.Key))
                        {
                            int highLightIndex = EDU.edu_scheme.GetComponentIndex(light.Key);
                            marked.Add(highLightIndex, light.Value);
                        }

                        else
                        {
                            foreach (KeyValuePair<string, int> comp in components)
                            {
                                if (comp.Key.Contains(light.Key))
                                {
                                    int highLightIndex = EDU.edu_scheme.GetComponentIndex(comp.Key);
                                    if(!marked.ContainsKey(highLightIndex))
                                        marked.Add(highLightIndex, light.Value);
                                }
                            }
                        }
                    }

                }
                if (marked.Count > 0)
                {
                    string space = spaces(LibFuncs.GetFirstWord(line), 25);
                    rtxt_unit.AppendText(LibFuncs.GetFirstWord(line) + space);
                    string firstRemoved = LibFuncs.RemoveFirstWord(line);
                    string[] split = firstRemoved.Split('\t', ' ', ',');

                    split = split.CleanStringArray();

                    for (int i = 0; i < split.Count(); i++)
                    {
                        if (i != 0)
                            rtxt_unit.AppendText(", ");
                        if (marked.ContainsKey(i))
                            rtxt_unit.AppendText(split[i], marked[i]);
                        else rtxt_unit.AppendText(split[i]);
                    }

                    rtxt_unit.AppendText("\r\n");
                }
                else
                {
                    string space = spaces(LibFuncs.GetFirstWord(line), 25);
                    rtxt_unit.AppendText(LibFuncs.GetFirstWord(line) + space);
                    rtxt_unit.AppendText(LibFuncs.RemoveFirstWord(line) + "\r\n");

                }

                marked.Clear();
            }


            ChangeUnitPic();
            isUpdating = false;
        }

        private string spaces(string a, int target)
        {
            string b = "";
            int lengthA = a.Length;
            int spacesNeed = target - lengthA;

            for (int i = 0; i < spacesNeed; i++)
            {
                b += " ";
            }

            return b;
        }

        public StratViewer StratViewer
        { 
            set { sv = value; }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if(sv != null)
                sv.Edu_viewer = null;
            base.OnClosing(e);
        }
    }

}

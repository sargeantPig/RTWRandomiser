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
using RTWLib.Objects.Descr_strat;
using RTWLib.Objects.Buildings;
using System.IO;
using RTWR_RTWLIB.Data;

namespace RTWR_RTWLIB
{ 
    public partial class StratViewer : Form
    {
        Descr_Strat ds;
        Descr_Region dr;
        SM_Factions smf;
        SelectMaps map;
        MapViewer mv;
        EDU_viewer eduViewer;
        string prevSelected ="";
        public StratViewer(EDU_viewer edu)
        {
            this.Icon = RTWR_RTWLIB.Properties.Resources.julii_icon;
            map = new SelectMaps(FileDestinations.selectMapPaths[0], FileDestinations.selectMapPaths[1]);
            eduViewer = edu;
            InitializeComponent();
        }


        public void PopulateTree()
        {
            LookUpTables lut = new LookUpTables();
            dsv_treeView.Nodes.Add("descr_strat", "descr_strat");
            foreach (Faction faction in ds.factions)
            {
                dsv_treeView.Nodes.Add(faction.name, faction.name);
                dsv_treeView.Nodes[faction.name].Nodes.Add("Settlements", "Settlements");
                foreach (Settlement settlement in faction.settlements)
                {
                    dsv_treeView.Nodes[faction.name].Nodes["Settlements"].Nodes.Add(settlement.region, settlement.region + " " + settlement.s_level);
                    dsv_treeView.Nodes[faction.name].Nodes["Settlements"].Nodes[settlement.region].Nodes.Add("Resources", "Resources");
                    foreach (DSBuilding building in settlement.b_types)
                    {
                        dsv_treeView.Nodes[faction.name].Nodes["Settlements"].Nodes[settlement.region].Nodes.Add(building.name);
                    }
                    foreach (var resource in dr.rgbRegions[settlement.region].resources)
                    {
                        dsv_treeView.Nodes[faction.name].Nodes["Settlements"].Nodes[settlement.region].Nodes["Resources"].Nodes.Add(resource, resource);
                    }
                }
                dsv_treeView.Nodes[faction.name].Nodes.Add("Characters", "Characters");
                foreach (DSCharacter character in faction.characters)
                {
                    dsv_treeView.Nodes[faction.name].Nodes["Characters"].Nodes.Add(character.name, character.name);
                    foreach (DSUnit unit in character.army)
                    {
                        dsv_treeView.Nodes[faction.name].Nodes["Characters"].Nodes[character.name].Nodes.Add(unit.Name);

                    }
                }
                dsv_treeView.Nodes[faction.name].Nodes.Add("Character Records", "Character Records");
                foreach (CharacterRecord rec in faction.characterRecords)
                {
                    dsv_treeView.Nodes[faction.name].Nodes["Character Records"].Nodes.Add(rec.name, rec.name);
                }

                dsv_treeView.Nodes[faction.name].Nodes.Add("Relationships", "Relationships");
                dsv_treeView.Nodes[faction.name].Nodes["Relationships"].Nodes.Add("Allied", "Allied");
                dsv_treeView.Nodes[faction.name].Nodes["Relationships"].Nodes.Add("Suspicous", "Suspicous");
                dsv_treeView.Nodes[faction.name].Nodes["Relationships"].Nodes.Add("Neutral", "Neutral");
                dsv_treeView.Nodes[faction.name].Nodes["Relationships"].Nodes.Add("Hostile", "Hostile");
                dsv_treeView.Nodes[faction.name].Nodes["Relationships"].Nodes.Add("At War", "At War");
                foreach (var fr in ds.factionRelationships.attitudes)
                {
                    if (faction.name == fr.Key)
                    {
                        foreach (KeyValuePair<int, List<string>> relation in fr.Value)
                        {
                            foreach (string fo in relation.Value)
                            {
                                int rvalue = relation.Key;
                                if(rvalue < 100) dsv_treeView.Nodes[faction.name].Nodes["Relationships"].Nodes["Allied"].Nodes.Add(fo);
                                else if(rvalue < 200) dsv_treeView.Nodes[faction.name].Nodes["Relationships"].Nodes["Suspicous"].Nodes.Add(fo);
                                else if (rvalue < 400) dsv_treeView.Nodes[faction.name].Nodes["Relationships"].Nodes["Neutral"].Nodes.Add(fo);
                                else if (rvalue < 600) dsv_treeView.Nodes[faction.name].Nodes["Relationships"].Nodes["Hostile"].Nodes.Add(fo);
                                else if (rvalue >= 600) dsv_treeView.Nodes[faction.name].Nodes["Relationships"].Nodes["At War"].Nodes.Add(fo);
                            }
                        }
                    }
                    
                }
            }

            mv = new MapViewer(dsv_treeView, this);
            UpdateScreens(dsv_treeView.Nodes[1].Text);
        }

        public Descr_Strat descr_strat
        {
            set { ds = value; }
        }
        public Descr_Region descr_region
        {
            set { dr = value; }
        }
        public SM_Factions sm_factions
        {
            set { smf = value; }
        }

        public EDU_viewer Edu_viewer
        { 
            set { eduViewer = value; }
        }

        private void btn_campaignMap_Click(object sender, EventArgs e)
        {
            mv.Show();
        }

        private void dsv_treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
           
            dsv_treeView.SelectedNode = e.Node;
            string selected = dsv_treeView.SelectedNode.Text;
            //check node is a faction
            UpdateScreens(selected);
            

        }

        public void UpdateScreens(string selected)
        {
            LookUpTables lut = new LookUpTables();
            if (lut.LookUpKey<FactionOwnership>(selected) == null)
            {
                string path = dsv_treeView.SelectedNode.FullPath;
                string[] split = path.Split('\\');
                if (split.Count() > 3)
                {
                    if (split[1] == "Characters" && eduViewer != null)
                        eduViewer.UpdateUnitTxt(null, dsv_treeView.SelectedNode.Text);


                }

                selected = split[0];
            }

            if (prevSelected != selected)
            {
                UpdateLabels(selected);
                UpdateFactionSymbol(selected);
                UpdateDiploMap(selected);
            }
            prevSelected = selected;
        }



        private void UpdateLabels(string fo)
        {
            int index = ds.factions.FindIndex(x => x.name == fo);
            int armiesCount = ds.GetArmyCount(index);
            int cityCount = ds.factions[index].settlements.Count();
            int treasury = ds.factions[index].denari;
            int navyCount = ds.GetNavyCount(index);
            int agentCount = ds.GetAgentCount(index);


            lbl_armiesVal.Text = armiesCount.ToString();
            lbl_citiesVal.Text = cityCount.ToString();
            lbl_treasury.Text = treasury.ToString();
            lbl_naviesVal.Text = navyCount.ToString();
            lbl_agentsVal.Text = agentCount.ToString();
        
        }

        private void UpdateFactionSymbol(string fo)
        {
            string symbol = @"\symbol48_" + fo + ".tga";
            string fullDirectory = @"randomiser\van_data\menu\symbols\FE_buttons_48" + symbol;
            MagickImage mi;
            //find map
            if (File.Exists(fullDirectory))
            {
                mi = new MagickImage(fullDirectory);
                mi.Resize(new Percentage(200));
                pic_symbol.Image = mi.ToBitmap();
            }
        }

        private void UpdateDiploMap(string selected)
        {
            LookUpTables lut = new LookUpTables();
            string mapName = @"\map_" + selected + ".tga";
            string fullDirectory = @"randomiser\data\world\maps\campaign\imperial_campaign" + mapName;
            MagickImage mi;
            //find map
            if (File.Exists(fullDirectory))
            {
                mi = map.CreateDiplomacyMap(ds, dr, smf, selected, "");
                mi.Resize(new Percentage(200));
                mv.SetMapImage(mi.ToBitmap());
            }


            mv.SetData(selected);
            mv.PopulateDiplo(selected);
        }
    }
}

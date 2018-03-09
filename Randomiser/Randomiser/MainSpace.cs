using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Numerics;

namespace Randomiser
{
    public partial class MainForm1 : Form
    {
        public MainForm1()
        {
            InitializeComponent();


        }

        private void butt_FolderSelect_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog;

            folderDialog = new FolderBrowserDialog();

            folderDialog.ShowDialog();

            Data.RtwFolderPath = @folderDialog.SelectedPath;

            txt_FolderPath.Text = Data.RtwFolderPath;

            
        }

        private void btn_selModFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog;

            folderDialog = new FolderBrowserDialog();

            folderDialog.ShowDialog();

            Data.ModFolderPath = @folderDialog.SelectedPath;

            txt_modFolderLoc.Text = Data.ModFolderPath;
        }

        private void butt_LoadData_Click(object sender, EventArgs e)
        {

#if DEBUG
           Data.ModFolderPath = @"G:\Games\Rome Total war testing\randomiser";
            Data.RtwFolderPath = @"G:\Games\Rome Total war testing";

#endif

            string completeEduPath = Data.RtwFolderPath + Data.EDUFILEPATH;
            string completedEdbPath = Data.ModFolderPath + Data.EDBFILEPATH;
            string completedStratPath = Data.RtwFolderPath + Data.DESCSTRAT;
      
            txt_Output.AppendText("Loading files...\r\n");
            
            txt_Output.AppendText("Loading " + completeEduPath + "\r\n");

            if (File.Exists(completeEduPath))
            {
                Parsers.ParseEdu(completeEduPath, ref txt_Output);
            }

            else txt_Output.AppendText("File cannot be found!\r\n");

            if (File.Exists(completedStratPath))
            {
                Parsers.ParseDscrStrat(completedStratPath, ref txt_Output);
            }

            else txt_Output.AppendText("File cannot be found!\r\n");

            Data.EDUFILEPATHMOD = Data.ModFolderPath + Data.EDUFILEPATHMOD;

            // needs changing to work like above
          
            //Parsers.ParseDscrStrat(ref txt_Output);

            if (File.Exists(Data.RtwFolderPath + Data.REGIONSFILEPATH))
            {
                Parsers.ParseVanRegions(Data.RtwFolderPath + Data.REGIONSFILEPATH, ref txt_Output);
            }

            List<string> tempRegions = new List<string>();

            foreach(Settlement s in Data.settlements)
            {
                tempRegions.Add(s.region);
            }

            List<string> unitNames = new List<string>();

            foreach(Unit s in Data.Vanunits)
            {
                unitNames.Add(s.dictionary);
            }

            cbox_regions.DataSource = tempRegions;
            cbox_regions.Refresh();
            cbx_units.DataSource = unitNames;
            cbx_units.Refresh();
        }

        private void cbox_regions_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewTabData.viewVan = !chk_viewRandomised.Checked;
            ViewTabData.viewModded = !chk_viewVanilla.Checked;

            string selected = cbox_regions.SelectedItem.ToString();

            txt_outputview.Clear();

            foreach(Settlement s in Data.settlements)
            {
                if(s.region == selected)
                {
                    txt_outputview.AppendText(
                       "\n" + "Region: " + s.region + "\r\n" +
                       "\n" + "Level: " + s.s_level + "\r\n" +
                       "\n" + "Buildings: " + "\r\n");

                    foreach(string b in s.b_types)
                    {
                        txt_outputview.AppendText(
                            "\n____" + b + "\r\n");
                    }
                }
            }



        }
        private void cbox_factions_SelectedIndexChanged(object sender, EventArgs e)
        {

            ViewTabData.viewVan = !chk_viewRandomised.Checked;
            ViewTabData.viewModded = !chk_viewVanilla.Checked;

            string selected = cbox_factions.SelectedItem.ToString();

            txt_outputview.Clear();

            int amount = 0;

            foreach (Unit unit in Data.Vanunits)
            {
                FactionOwnership f = enumsToStrings.StringToFaction(selected);

                if ((unit.ownership & f) !=0)
                {
                    txt_outputview.AppendText(unit.type + " (" + unit.dictionary + ")\n");
                    amount++;
                }
            }
            txt_outputview.AppendText(" Units: " + amount);
        }

        private void but_randomize_Click(object sender, EventArgs e)
        {

            RandomiseData.unitSizes = chk_UnitSizes.Checked;
            RandomiseData.stats = chk_rndStats.Checked;
            RandomiseData.rndCost = chk_costs.Checked;
            RandomiseData.rndSounds = chk_rndSounds.Checked;
            RandomiseData.maxCities = (int)numupdown_nocities.Value;
            RandomiseData.maxAttri = (int)numUpDown_maxAtrri.Value;
            RandomiseData.rndAI = chk_ai.Checked;
            RandomiseData.rndTreasury = chk_treasury.Checked;
            RandomiseData.rndTraining = chk_rndTraining.Checked;
            RandomiseData.rndAttri = chk_rndAttri.Checked;
            RandomiseData.rndGroundBonus = chk_groundBonus.Checked;


            if (chx_useSeed.Checked)
            {
                Data.Seed = txt_Seed.Text.GetHashCode();
                Data.rnd = new Random(Data.Seed);

                txt_randomiserOutput.AppendText(Data.Seed.ToString() + "\n");
            }

            else {

                txt_randomiserOutput.AppendText("No custom seed" + "\n");

            }
            

            Randomise.RandomiseEdu();
            //SAVE EDU and then randomise and save DS
            SaveEDU();
            SaveDStrat();
        }

        private void butt_coordOutput_Click(object sender, EventArgs e)
        {
            Parsers.DsCoordGet("", ref txt_toolsOutput);
        }

        public void SaveEDU()
        {
            StreamWriter edu = new StreamWriter( Data.ModFolderPath + Data.EDUFILEPATH);

            edu.WriteLine(";RANDOMISED SEED: " + Convert.ToString(Data.Seed) + "\r\n\n");

            foreach (Unit unit in Data.ModdedUnits)
            {
                edu.Write(unit.unitOutput());
            }

            edu.Close();
            
            
        }

        public void SaveDStrat()
        {
            List<Settlement> tempSettlements = new List<Settlement>(Data.settlements);
            List<Region> templist = new List<Region>(Data.rgbRegions);
            List<string> tempsettles = new List<string>();
            Vector2 capitalCoords = new Vector2();
            

            string faction = "";
            int factionNo = 0;
            int charnum = -1;
            int modifierx = 0;
            int modifiery = 0;
            bool useModifier = false;
            bool isAdmiral = false;
            bool isDiploOrSpy = false;

            StreamWriter strat = new StreamWriter(Data.ModFolderPath + Data.DESCSTRAT);

            strat.WriteLine(";RANDOMISED SEED: " + Convert.ToString(Data.Seed) + "\r\n\n");

            foreach (string s in Data.desc_StratData)
            {
                if(s.StartsWith("faction") && !s.StartsWith("faction_relationships"))
                {
                    //strat.WriteLine(s);
                    string[] split = s.Split(',');
                    string[] splitAgain = split[0].Split('\t');
                    string[] aiSplit = split[1].Split(' ');

                    if (RandomiseData.rndAI)
                    {
                        int rnds = Data.rnd.Next(0, RandomiseData.AIEconomy.Count() - 1);
                        int rnd2 = Data.rnd.Next(0, RandomiseData.AIMilitary.Count() - 1);
                        aiSplit[0] = RandomiseData.AIEconomy[rnds];
                        aiSplit[1] = RandomiseData.AIMilitary[rnd2];

                        faction = splitAgain[1].Trim();

                        string final = split[0] + ", " + aiSplit[0] + "\t" + aiSplit[1] + "\r\n";

                        strat.WriteLine(final);
                    }
                    else strat.WriteLine(s);


                    txt_randomiserOutput.AppendText("Randomising " + faction + "\r\n");
                }


                else if (s.StartsWith("denari")) 
                {
                    string[] split = s.Split('\t');

                    if (RandomiseData.rndCost) {

                        split[1] = Convert.ToString(Data.rnd.Next(0, 6000));

                        strat.WriteLine(split[0] + "\t" + split[1] + "\r\n");
                    }

                    else strat.WriteLine(s);

                    tempsettles.Clear();

                    factionNo++;

                    Vector2 cityLocation;
                    List<Settlement> settlementsToAdd = new List<Settlement>();
                  
                    int rndNum = Data.rnd.Next(0, tempSettlements.Count - 1);


                    //capital get location etc
                    string region = tempSettlements[rndNum].region;
                    strat.WriteLine(tempSettlements[rndNum].outputSettlement()); //writeline
                    int index = templist.FindIndex(x => x.name == region); //get city coords
                    cityLocation = new Vector2(templist[index].x, templist[index].y);
                    tempsettles.Add(tempSettlements[rndNum].region);

                    capitalCoords.X = cityLocation.X;
                    capitalCoords.Y = cityLocation.Y;

                    templist.RemoveAt(index);
                    tempSettlements.Remove(tempSettlements[rndNum]);
                    //get other locations which are closest to the capital
                    int rndAmount = Data.rnd.Next(1, RandomiseData.maxCities);
                    for (int i = 0; i < rndAmount; i++)
                    {
                        double tempDistance = 10000;
                        string tempRegion = "";
                       
                        Region toRemove = new Region();

                        foreach (Settlement city in tempSettlements)
                        {

                            int rindex = templist.FindIndex(x => x.name == city.region);
                            Region r = templist[rindex];
                            

                            double dis = Math.Sqrt(Math.Pow((cityLocation.X - r.x), 2) + Math.Pow((cityLocation.Y - r.y), 2));

                            if (dis < tempDistance && dis > 0)
                            {
                                tempDistance = dis;
                                tempRegion = r.name;
                                toRemove = r;
                            }
                        }

                        int setIndex = tempSettlements.FindIndex(x => tempRegion == x.region);
                        settlementsToAdd.Add(tempSettlements[setIndex]);
                        tempSettlements.Remove(tempSettlements[setIndex]);
                        templist.Remove(toRemove);
                        tempDistance = 1000000;
                    }

                    //writeout the settlements
                    foreach (Settlement city in settlementsToAdd)
                    {
                        strat.WriteLine(city.outputSettlement());
                        tempsettles.Add(city.region);
                    }
                }

                else if (s.StartsWith("character") && !s.StartsWith("character_record"))
                {
                    string[] splitted = s.Split(',');

                    if (splitted[1].Trim().StartsWith("diplomat") || splitted[1].Trim().StartsWith("spy"))
                    {
                        isDiploOrSpy = true;
                        useModifier = true;
                        isAdmiral = false;
                    }

                    else if (splitted[1].Trim().StartsWith("admiral"))
                    {
                        isAdmiral = true;
                        useModifier = true;
                        isDiploOrSpy = false;
                        
                    }

                    else
                    {
                        isAdmiral = false;
                        isDiploOrSpy = false;
                        useModifier = false;
                        charnum++;
                    }


                    foreach (string s2 in splitted)
                    {
                        if (charnum > tempsettles.Count() - 1)
                        {
                            charnum = 0;    
                        }

                        if (s2.Trim().StartsWith("x"))
                        {
                            string[] splitAgain = s2.Split(' ');
                            int index = 0;
                            if (charnum < tempsettles.Count())
                               index = Data.rgbRegions.FindIndex(x => x.name == tempsettles[charnum]);
                            if (!useModifier)
                                splitAgain[1] = Convert.ToString(Data.rgbRegions[index].x);
                            else splitAgain[1] = Convert.ToString(modifierx);

                            splitted[splitted.Count() - 2] = "x" + " " + splitAgain[1];
                        }

                        if (s2.Trim().StartsWith("y"))
                        {
                            string[] splitAgain = s2.Split(' ');
                            int index = 0;
                            if (charnum < tempsettles.Count())
                               index = Data.rgbRegions.FindIndex(x => x.name == tempsettles[charnum]);
                            if (!useModifier)
                                splitAgain[1] = Convert.ToString(Data.rgbRegions[index].y);
                            else splitAgain[1] = Convert.ToString(modifiery);

                            splitted[splitted.Count() - 1] = "y" + " " + splitAgain[1];
                        }

                    }

                    Vector2 a = new Vector2();
                    double waterDis = 0;
                    double disMax = 100000;

                    if (isAdmiral)
                    {
                        for (int x = 0; x < 255; x++)
                            for (int y = 0; y < 156; y++)
                            {
                                if (Data.regionWater[x, y])
                                {
                                    Vector2 coords = Functions.getCoordsFromRegion(tempsettles, 0);

                                    waterDis = Functions.DistanceTo(coords, new Vector2(x, y));
                                    
                                    if (waterDis < disMax && waterDis > 3)
                                    {
                                        disMax = waterDis;
                                        a = new Vector2(x, y) ;
                                    }
                                }
                            }

                        Data.regionWater[(int)a.X, (int)a.Y] = false;
                    }

                    foreach (string s3 in splitted)
                     {

                        if (isAdmiral)
                        {
                            if (s3.Trim().StartsWith("x"))
                            {
                                string[] split = s3.Split(' ');
                                
                                split[1] = Convert.ToString(a.X);

                                string newStr = split[0] + " " + split[1];
                                strat.Write(newStr + ", ");
                            }

                            else if (s3.Trim().StartsWith("y"))
                            {
                                string[] split = s3.Split(' ');
                                split[1] = Convert.ToString(a.Y);
                                string newStr = split[0] + " " + split[1];
                                strat.Write(newStr + "\r\n");
                            }

                            else strat.Write(s3 + ", ");
                        }

                        else if (isDiploOrSpy)
                        {
                            if (s3.Trim().StartsWith("x"))
                            {
                                string[] split = s3.Split(' ');

                                a = Functions.getCoordsFromRegion(tempsettles, 0);
                                split[1] = Convert.ToString(a.X);

                                string newStr = split[0] + " " + split[1];
                                strat.Write(newStr + ", ");
                            }

                            else if (s3.Trim().StartsWith("y"))
                            {
                                string[] split = s3.Split(' ');
                                split[1] = Convert.ToString(a.Y);
                                string newStr = split[0] + " " + split[1];
                                strat.Write(newStr + "\r\n");
                            }

                            else strat.Write(s3 + ", ");
                        }

                        else if (!s3.Trim().StartsWith("y"))
                            strat.Write(s3 + ", ");
                        else strat.Write(s3 + "\r\n");
                    }
                }

                else if (s.StartsWith("relative"))
                {
                    charnum = -1;
                    useModifier = false;
                    strat.WriteLine(s);
                }

                else strat.WriteLine(s);
            }

            strat.Close();
        }

        public void SaveEDB()
        { 
        
        }

        private void chk_selectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_selectAll.Checked) {

                foreach (Control cb in groupBox1.Controls)
                {
                    CheckBox checkb;
                    if (cb is CheckBox)
                    {
                        checkb = cb as CheckBox;
                        checkb.Checked = true;
                    }
                    

                }

                foreach (Control cb in groupBox2.Controls)
                {
                    CheckBox checkb;
                    if (cb is CheckBox)
                    {
                        checkb = cb as CheckBox;
                        checkb.Checked = true;
                    }


                }
            }

            else {
                foreach (Control cb in groupBox1.Controls)
                {
                    CheckBox checkb;
                    if (cb is CheckBox)
                    {
                        checkb = cb as CheckBox;
                        checkb.Checked = false;
                    }


                }

                foreach (Control cb in groupBox2.Controls)
                {
                    CheckBox checkb;
                    if (cb is CheckBox)
                    {
                        checkb = cb as CheckBox;
                        checkb.Checked = false;
                    }


                }
            }


        }

        private void cbx_units_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewTabData.viewVan = chk_viewVanilla.Checked;
            ViewTabData.viewModded = chk_viewRandomised.Checked;

            txt_outputview.Clear();

            string selected = cbx_units.SelectedItem.ToString();

            int index = Functions.GetIndex<string>(selected, Data.Vanunits);

            if (ViewTabData.viewVan && index >= 0)
            {
                txt_outputview.AppendText(Data.Vanunits[index].unitOutput());
            }
            if (ViewTabData.viewModded && index >= 0)
            {
                txt_outputview.AppendText(Data.ModdedUnits[index].unitOutput() + "\r\n");
            }

        }
    }
}

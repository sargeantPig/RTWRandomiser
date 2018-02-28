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
           Data.ModFolderPath = @"G:\Games\Rome Total war testing\RANDOMTESTING";
            Data.RtwFolderPath = @"G:\Games\Rome Total war testing";

#endif

            string completeEduPath = Data.ModFolderPath + Data.EDUFILEPATH;
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

            cbox_regions.DataSource = tempRegions;
            cbox_regions.Refresh();

        }

        private void cbox_regions_SelectedIndexChanged(object sender, EventArgs e)
        {
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
            string selected = cbox_factions.SelectedItem.ToString();

            txt_outputview.Clear();

            int amount = 0;

            foreach (Unit unit in Data.units)
            {
                if ((unit.ownership & enumsToStrings.StringToFaction(selected)) == enumsToStrings.StringToFaction(selected))
                {
                    txt_outputview.AppendText(unit.type + " (" + unit.dictionary + ")\n");
                    amount++;
                }
            }
            txt_outputview.AppendText(" Units: " + amount);
        }

        private void but_randomize_Click(object sender, EventArgs e)
        {
            //if (cbx_ownershipPerUnit.SelectedItem.ToString() != "RANDOM")
            //  OwnershipPerUnit = Convert.ToInt16(cbx_ownershipPerUnit.SelectedItem.ToString());
            //else OwnershipPerUnit = Data.rnd.Next(1, 10);

            if (chk_UnitSizes.Checked)
               RandomiseData.unitSizes = true;
            else RandomiseData.unitSizes = false;

            if (chk_rndStats.Checked)
                RandomiseData.stats = true;
            else RandomiseData.stats = false;

            if (chk_costs.Checked)
                RandomiseData.rndCost = true;
            else RandomiseData.rndCost = false;

            if (chk_statsWithReason.Checked)
                RandomiseData.reasonableStats = true;
            else RandomiseData.reasonableStats = false;

            if (chk_rndSounds.Checked)
                RandomiseData.rndSounds = true;
            else RandomiseData.rndSounds = false;

            if (chx_useSeed.Checked)
            {
                Data.Seed = txt_Seed.Text.GetHashCode();
                Data.rnd = new Random(Data.Seed);
            }


            txt_randomiserOutput.AppendText(Data.Seed.ToString() + "\n");


            Randomise.RandomiseEdu();




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

            edu.WriteLine(";RANDOMISED\r\n\n");

            foreach (Unit unit in Data.units)
            {
                edu.Write(
                    "type\t\t\t\t " + unit.type + "\r\n" +
                    "dictionary\t\t\t " + unit.dictionary + "\r\n" +
                    "category\t\t\t " + unit.category + "\r\n" +
                    "class\t\t\t\t " + unit.unitClass + "\r\n" +
                    "voice_type\t\t\t " + unit.voiceType + "\r\n" +
                    "soldier\t\t\t\t " + unit.soldier.name + ", " + unit.soldier.number.ToString() + ", " + unit.soldier.extras.ToString() + ", " + unit.soldier.collisionMass.ToString());

                //edu.Write("\r\n");

                if (unit.engine != null)
                    edu.Write("\r\nengine\t\t\t " + unit.engine);

                if (unit.animal != null)
                    edu.Write("\r\nanimal\t\t\t " + unit.animal);

                if (unit.mount != null)
                    edu.Write("\r\nmount\t\t\t " + unit.mount);

                if (unit.officer.Count > 0)
                {
                    if (unit.officer[0] != null)
                    {
                        edu.Write("\r\nofficer\t\t\t " + unit.officer[0]);
                    }
                }

                if (unit.officer.Count > 1)
                {
                    if (unit.officer[1] != null)
                    {
                        edu.Write("\r\nofficer\t\t\t " + unit.officer[1]);
                    }
                }

                if (unit.officer.Count > 2)
                {
                    if (unit.officer[2] != null)
                    {
                        edu.Write("\r\nofficer\t\t\t " + unit.officer[2]);
                    }
                }

                if (unit.naval != null)
                    edu.Write("\r\nship\t\t\t\t " + unit.naval);

                edu.Write("\r\nattributes\t\t\t "); // write attributes

                bool firstAttr = false;
                if (unit.attributes.HasFlag(Attributes.sea_faring))
                {
                    if (!firstAttr)
                    {
                        firstAttr = true;
                    }

                    else edu.Write(", ");

                    edu.Write(enumsToStrings.AttributesToString(Attributes.sea_faring));
                }

                if (unit.attributes.HasFlag(Attributes.can_run_amok))
                {
                    if (!firstAttr)
                    {
                        firstAttr = true;
                    }

                    else edu.Write(", ");

                    edu.Write(enumsToStrings.AttributesToString(Attributes.can_run_amok));

                }
                if (unit.attributes.HasFlag(Attributes.can_sap))
                {
                    if (!firstAttr)
                    {
                        firstAttr = true;
                    }

                    else edu.Write(", ");

                    edu.Write(enumsToStrings.AttributesToString(Attributes.can_sap));
                }
                if (unit.attributes.HasFlag(Attributes.cantabrian_circle))
                {
                    if (!firstAttr)
                    {
                        firstAttr = true;
                    }

                    else edu.Write(", ");

                    edu.Write(enumsToStrings.AttributesToString(Attributes.cantabrian_circle));
                }

                if (unit.attributes.HasFlag(Attributes.command))
                {
                    if (!firstAttr)
                    {
                        firstAttr = true;
                    }

                    else edu.Write(", ");

                    edu.Write(enumsToStrings.AttributesToString(Attributes.command));
                }
                if (unit.attributes.HasFlag(Attributes.druid))
                {
                    if (!firstAttr)
                    {
                        firstAttr = true;
                    }

                    else edu.Write(", ");

                    edu.Write(enumsToStrings.AttributesToString(Attributes.druid));
                }
                if (unit.attributes.HasFlag(Attributes.frighten_foot))
                {
                    if (!firstAttr)
                    {
                        firstAttr = true;
                    }

                    else edu.Write(", ");

                    edu.Write(enumsToStrings.AttributesToString(Attributes.frighten_foot));
                }
                if (unit.attributes.HasFlag(Attributes.frighten_mounted))
                {
                    if (!firstAttr)
                    {
                        firstAttr = true;
                    }

                    else edu.Write(", ");

                    edu.Write(enumsToStrings.AttributesToString(Attributes.frighten_mounted));
                }
                if (unit.attributes.HasFlag(Attributes.general_unit))
                {
                    if (!firstAttr)
                    {
                        firstAttr = true;
                    }

                    else edu.Write(", ");

                    edu.Write(enumsToStrings.AttributesToString(Attributes.general_unit));
                }
                if (unit.attributes.HasFlag(Attributes.general_unit_upgrade))
                {
                    if (!firstAttr)
                    {
                        firstAttr = true;
                    }

                    else edu.Write(", ");

                    edu.Write(enumsToStrings.AttributesToString(Attributes.general_unit_upgrade));
                }
                if (unit.attributes.HasFlag(Attributes.hide_anywhere))
                {
                    if (!firstAttr)
                    {
                        firstAttr = true;
                    }

                    else edu.Write(", ");

                    edu.Write(enumsToStrings.AttributesToString(Attributes.hide_anywhere));
                }
                if (unit.attributes.HasFlag(Attributes.hide_forest))
                {
                    if (!firstAttr)
                    {
                        firstAttr = true;
                    }

                    else edu.Write(", ");

                    edu.Write(enumsToStrings.AttributesToString(Attributes.hide_forest));
                }
                if (unit.attributes.HasFlag(Attributes.hide_improved_forest))
                {
                    if (!firstAttr)
                    {
                        firstAttr = true;
                    }

                    else edu.Write(", ");

                    edu.Write(enumsToStrings.AttributesToString(Attributes.hide_improved_forest));
                }
                if (unit.attributes.HasFlag(Attributes.hide_long_grass))
                {
                    if (!firstAttr)
                    {
                        firstAttr = true;
                    }

                    else edu.Write(", ");

                    edu.Write(enumsToStrings.AttributesToString(Attributes.hide_long_grass));
                }
                if (unit.attributes.HasFlag(Attributes.mercenary_unit))
                {
                    if (!firstAttr)
                    {
                        firstAttr = true;
                    }

                    else edu.Write(", ");

                    edu.Write(enumsToStrings.AttributesToString(Attributes.mercenary_unit));
                }
                if (unit.attributes.HasFlag(Attributes.no_custom))
                {
                    if (!firstAttr)
                    {
                        firstAttr = true;
                    }

                    else edu.Write(", ");

                    edu.Write(enumsToStrings.AttributesToString(Attributes.no_custom));
                }
                if (unit.attributes.HasFlag(Attributes.warcry))
                {
                    if (!firstAttr)
                    {
                        firstAttr = true;
                    }

                    else edu.Write(", ");

                    edu.Write(enumsToStrings.AttributesToString(Attributes.warcry));
                }

                edu.Write("\r\n");

                edu.Write("formation\t\t\t "); // write formation
                foreach (float num in unit.formation.FormationTight)
                    edu.Write(num.ToString() + ", ");
                foreach (float num in unit.formation.FormationSparse)
                    edu.Write(num.ToString() + ", ");
                edu.Write(unit.formation.FormationRanks + ", ");

                bool firstForm = false;

                if (unit.formation.FormationFlags.HasFlag(FormationTypes.Formation_Phalanx))
                {
                    if (!firstForm)
                    {
                        firstForm = true;
                    }

                    else edu.Write(", ");

                    edu.Write(enumsToStrings.FormationTostring(FormationTypes.Formation_Phalanx));
                }

                if (unit.formation.FormationFlags.HasFlag(FormationTypes.Formation_Testudo))
                {
                    if (!firstForm)
                    {
                        firstForm = true;
                    }

                    else edu.Write(", ");

                    edu.Write(enumsToStrings.FormationTostring(FormationTypes.Formation_Testudo));
                }
                if (unit.formation.FormationFlags.HasFlag(FormationTypes.Formation_Schiltrom))
                {
                    if (!firstForm)
                    {
                        firstForm = true;
                    }

                    else edu.Write(", ");

                    edu.Write(enumsToStrings.FormationTostring(FormationTypes.Formation_Schiltrom));
                }
                if (unit.formation.FormationFlags.HasFlag(FormationTypes.Formation_Horde))
                {
                    if (!firstForm)
                    {
                        firstForm = true;
                    }

                    else edu.Write(", ");


                    edu.Write(enumsToStrings.FormationTostring(FormationTypes.Formation_Horde));

                }
                if (unit.formation.FormationFlags.HasFlag(FormationTypes.Formation_Square))
                {
                    if (!firstForm)
                    {
                        firstForm = true;
                    }

                    else edu.Write(", ");

                    edu.Write(enumsToStrings.FormationTostring(FormationTypes.Formation_Square));
                }
                if (unit.formation.FormationFlags.HasFlag(FormationTypes.Formation_Wedge))
                {
                    if (!firstForm)
                    {
                        firstForm = true;
                    }

                    else edu.Write(", ");

                    edu.Write(enumsToStrings.FormationTostring(FormationTypes.Formation_Wedge));

                }

                edu.Write("\r\n");

                edu.Write("stat_health\t\t\t "); //write health
                bool firstHealth = false;
                foreach (int health in unit.heatlh)
                {

                    if (!firstHealth)
                    {
                        firstHealth = true;
                    }

                    else edu.Write(", ");

                    edu.Write(health);

                }

                edu.Write("\r\n");

                edu.Write("stat_pri\t\t\t "); // write primary weapon
                foreach (int atk in unit.primaryWeapon.attack)
                    edu.Write(atk + ", ");
                edu.Write(enumsToStrings.MissleTypeToString(unit.primaryWeapon.missletypeFlags) + ", ");
                foreach (int miss in unit.primaryWeapon.Missleattri)
                    edu.Write(miss + ", ");
                edu.Write(
                    enumsToStrings.WeaponTypeToString(unit.primaryWeapon.WeaponFlags) + ", " +
                    enumsToStrings.TechTypeToString(unit.primaryWeapon.TechFlags) + ", " +
                    enumsToStrings.DamageTypeToString(unit.primaryWeapon.DamageFlags) + ", " +
                    enumsToStrings.SoundTypeToString(unit.primaryWeapon.SoundFlags) + ", ");

                bool firstattk = false;
                foreach (float atkd in unit.primaryWeapon.attackdelay)
                {
                    if (!firstattk)
                    {
                        firstattk = true;
                    }

                    else edu.Write(", ");

                    edu.Write(atkd);
                }

                edu.Write("\r\n");

                edu.Write("stat_pri_attr\t\t "); //attributes

                bool attrFirst = false;

                if (unit.priAttri.HasFlag(stat_pri_attr.ap))
                {
                    if (!attrFirst)
                    {
                        attrFirst = true;
                    }

                    else edu.Write(", ");


                    edu.Write(enumsToStrings.PriAttrToString(stat_pri_attr.ap));
                }

                if (unit.priAttri.HasFlag(stat_pri_attr.bp))
                {
                    if (!attrFirst)
                    {
                        attrFirst = true;
                    }

                    else edu.Write(", ");


                    edu.Write(enumsToStrings.PriAttrToString(stat_pri_attr.bp));
                }
                if (unit.priAttri.HasFlag(stat_pri_attr.pa_spear))
                {
                    if (!attrFirst)
                    {
                        attrFirst = true;
                    }

                    else edu.Write(", ");


                    edu.Write(enumsToStrings.PriAttrToString(stat_pri_attr.pa_spear));
                }
                if (unit.priAttri.HasFlag(stat_pri_attr.long_pike))
                {
                    if (!attrFirst)
                    {
                        attrFirst = true;
                    }

                    else edu.Write(", ");


                    edu.Write(enumsToStrings.PriAttrToString(stat_pri_attr.long_pike));
                }
                if (unit.priAttri.HasFlag(stat_pri_attr.short_pike))
                {
                    if (!attrFirst)
                    {
                        attrFirst = true;
                    }

                    else edu.Write(", ");


                    edu.Write(enumsToStrings.PriAttrToString(stat_pri_attr.short_pike));
                }
                if (unit.priAttri.HasFlag(stat_pri_attr.prec))
                {
                    if (!attrFirst)
                    {
                        attrFirst = true;
                    }

                    else edu.Write(", ");


                    edu.Write(enumsToStrings.PriAttrToString(stat_pri_attr.prec));
                }
                if (unit.priAttri.HasFlag(stat_pri_attr.pa_thrown))
                {
                    if (!attrFirst)
                    {
                        attrFirst = true;
                    }

                    else edu.Write(", ");


                    edu.Write(enumsToStrings.PriAttrToString(stat_pri_attr.pa_thrown));
                }
                if (unit.priAttri.HasFlag(stat_pri_attr.launching))
                {
                    if (!attrFirst)
                    {
                        attrFirst = true;
                    }

                    else edu.Write(", ");


                    edu.Write(enumsToStrings.PriAttrToString(stat_pri_attr.launching));
                }
                if (unit.priAttri.HasFlag(stat_pri_attr.area))
                {
                    if (!attrFirst)
                    {
                        attrFirst = true;
                    }

                    else edu.Write(", ");


                    edu.Write(enumsToStrings.PriAttrToString(stat_pri_attr.area));
                }
                if (unit.priAttri.HasFlag(stat_pri_attr.PA_no))
                {
                    if (!attrFirst)
                    {
                        attrFirst = true;
                    }

                    else edu.Write(", ");


                    edu.Write(enumsToStrings.PriAttrToString(stat_pri_attr.PA_no));
                }

                if (unit.priAttri.HasFlag(stat_pri_attr.fire))
                {
                    if (!attrFirst)
                    {
                        attrFirst = true;
                    }

                    else edu.Write(", ");


                    edu.Write(enumsToStrings.PriAttrToString(stat_pri_attr.fire));
                }

                edu.Write("\r\n");

                edu.Write("stat_sec\t\t\t "); // secondary weapon
                foreach (int atk in unit.secondaryWeapon.attack)
                    edu.Write(atk + ", ");
                edu.Write(enumsToStrings.MissleTypeToString(unit.secondaryWeapon.missletypeFlags) + ", ");
                foreach (int miss in unit.secondaryWeapon.Missleattri)
                    edu.Write(miss + ", ");
                edu.Write(
                    enumsToStrings.WeaponTypeToString(unit.secondaryWeapon.WeaponFlags) + ", " +
                    enumsToStrings.TechTypeToString(unit.secondaryWeapon.TechFlags) + ", " +
                    enumsToStrings.DamageTypeToString(unit.secondaryWeapon.DamageFlags) + ", " +
                    enumsToStrings.SoundTypeToString(unit.secondaryWeapon.SoundFlags) + ", ");

                bool firstatkD = false;
                foreach (float atkd in unit.secondaryWeapon.attackdelay)
                {
                    if (!firstatkD)
                    {
                        firstatkD = true;
                    }

                    else edu.Write(", ");


                    edu.Write(atkd);

                }

                edu.Write("\r\n");

                bool firstsecAttr = false;
                edu.Write("stat_sec_attr\t\t ");
                if (unit.secAttri.HasFlag(stat_pri_attr.ap))
                {
                    if (!firstsecAttr)
                    {
                        firstsecAttr = true;
                    }

                    else edu.Write(", ");

                    edu.Write(enumsToStrings.PriAttrToString(stat_pri_attr.ap));
                }
                if (unit.secAttri.HasFlag(stat_pri_attr.bp))
                {
                    if (!firstsecAttr)
                    {
                        firstsecAttr = true;
                    }

                    else edu.Write(", ");

                    edu.Write(enumsToStrings.PriAttrToString(stat_pri_attr.bp));
                }
                if (unit.secAttri.HasFlag(stat_pri_attr.pa_spear))
                {
                    if (!firstsecAttr)
                    {
                        firstsecAttr = true;
                    }

                    else edu.Write(", ");

                    edu.Write(enumsToStrings.PriAttrToString(stat_pri_attr.pa_spear));
                }
                if (unit.secAttri.HasFlag(stat_pri_attr.long_pike))
                {
                    if (!firstsecAttr)
                    {
                        firstsecAttr = true;
                    }

                    else edu.Write(", ");

                    edu.Write(enumsToStrings.PriAttrToString(stat_pri_attr.long_pike));
                }
                if (unit.secAttri.HasFlag(stat_pri_attr.short_pike))
                {
                    if (!firstsecAttr)
                    {
                        firstsecAttr = true;
                    }

                    else edu.Write(", ");

                    edu.Write(enumsToStrings.PriAttrToString(stat_pri_attr.short_pike));
                }
                if (unit.secAttri.HasFlag(stat_pri_attr.prec))
                {
                    if (!firstsecAttr)
                    {
                        firstsecAttr = true;
                    }

                    else edu.Write(", ");

                    edu.Write(enumsToStrings.PriAttrToString(stat_pri_attr.prec));
                }
                if (unit.secAttri.HasFlag(stat_pri_attr.pa_thrown))
                {
                    if (!firstsecAttr)
                    {
                        firstsecAttr = true;
                    }

                    else edu.Write(", ");

                    edu.Write(enumsToStrings.PriAttrToString(stat_pri_attr.pa_thrown));
                }
                if (unit.secAttri.HasFlag(stat_pri_attr.launching))
                {
                    if (!firstsecAttr)
                    {
                        firstsecAttr = true;
                    }

                    else edu.Write(", ");

                    edu.Write(enumsToStrings.PriAttrToString(stat_pri_attr.launching));
                }
                if (unit.secAttri.HasFlag(stat_pri_attr.area))
                {
                    if (!firstsecAttr)
                    {
                        firstsecAttr = true;
                    }

                    else edu.Write(", ");

                    edu.Write(enumsToStrings.PriAttrToString(stat_pri_attr.area));
                }
                if (unit.secAttri.HasFlag(stat_pri_attr.PA_no))
                {
                    if (!firstsecAttr)
                    {
                        firstsecAttr = true;
                    }

                    else edu.Write(", ");

                    edu.Write(enumsToStrings.PriAttrToString(stat_pri_attr.PA_no));
                }

                if (unit.secAttri.HasFlag(stat_pri_attr.fire))
                {
                    if (!firstsecAttr)
                    {
                        firstsecAttr = true;
                    }

                    else edu.Write(", ");


                    edu.Write(enumsToStrings.PriAttrToString(stat_pri_attr.fire));
                }

                edu.Write("\r\n");

                edu.Write("stat_pri_armour\t\t ");
                foreach (int numb in unit.primaryArmour.stat_pri_armour)
                    edu.Write(numb + ", ");
                edu.Write(enumsToStrings.ArmourSndToString(unit.primaryArmour.armour_sound));

                edu.Write("\r\n");

                edu.Write("stat_sec_armour\t\t ");
                foreach (int numb in unit.secondaryArmour.stat_sec_armour)
                    edu.Write(numb + ", ");
                edu.Write(enumsToStrings.ArmourSndToString(unit.secondaryArmour.sec_armour_sound));

                edu.Write("\r\n");

                edu.Write("stat_heat\t\t\t " + unit.heat);

                edu.Write("\r\n");

                edu.Write("stat_ground\t\t\t ");
                bool firstGround = false;
                foreach (int numb in unit.ground)
                {
                    if (!firstGround)
                    {
                        firstGround = true;
                    }

                    else edu.Write(", ");

                    edu.Write(numb);
                }

                edu.Write("\r\n");

                edu.Write("stat_mental\t\t\t " + unit.mental.morale + ", ");
                edu.Write(enumsToStrings.DisciplineToString(unit.mental.discipline) + ", " + enumsToStrings.TrainingToString(unit.mental.training));

                edu.Write("\r\n");

                edu.Write("stat_charge_dist\t " + unit.chargeDistance);

                edu.Write("\r\n");

                edu.Write("stat_fire_delay\t\t " + unit.fireDelay);

                edu.Write("\r\n");

                edu.Write("stat_food\t\t\t " + unit.food[0] + ", " + unit.food[1]);

                edu.Write("\r\n");

                edu.Write("stat_cost\t\t\t ");
                bool firstCost = false;
                foreach (int cost in unit.cost)
                {
                    if (!firstCost)
                    {
                        firstCost = true;
                    }

                    else edu.Write(", ");

                    edu.Write(cost);
                }

                edu.Write("\r\n");

                edu.Write("ownership\t\t\t ");

                bool firstStatOwnership = false;
                if (unit.ownership.HasFlag(FactionOwnership.armenia))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else edu.Write(", ");

                    edu.Write(enumsToStrings.FactionToString(FactionOwnership.armenia));

                }
                if (unit.ownership.HasFlag(FactionOwnership.britons))
                {
                    if(!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else edu.Write(", ");
                    edu.Write(enumsToStrings.FactionToString(FactionOwnership.britons));
                }
                if (unit.ownership.HasFlag(FactionOwnership.carthage))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else edu.Write(", ");

                    edu.Write(enumsToStrings.FactionToString(FactionOwnership.carthage));
                }
                if (unit.ownership.HasFlag(FactionOwnership.carthaginian))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else edu.Write(", ");
                    edu.Write(enumsToStrings.FactionToString(FactionOwnership.carthaginian));
                }
                if (unit.ownership.HasFlag(FactionOwnership.dacia))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else edu.Write(", ");

                    edu.Write(enumsToStrings.FactionToString(FactionOwnership.dacia));
                }
                if (unit.ownership.HasFlag(FactionOwnership.eastern))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else edu.Write(", ");

                    edu.Write(enumsToStrings.FactionToString(FactionOwnership.eastern));
                }
                if (unit.ownership.HasFlag(FactionOwnership.egypt))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else edu.Write(", ");

                    edu.Write(enumsToStrings.FactionToString(FactionOwnership.egypt));
                }
                if (unit.ownership.HasFlag(FactionOwnership.egyptian))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else edu.Write(", ");
                    edu.Write(enumsToStrings.FactionToString(FactionOwnership.egyptian));
                }
                if (unit.ownership.HasFlag(FactionOwnership.gauls))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else edu.Write(", ");
                    edu.Write(enumsToStrings.FactionToString(FactionOwnership.gauls));
                }
                if (unit.ownership.HasFlag(FactionOwnership.germans))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else edu.Write(", ");
                    edu.Write(enumsToStrings.FactionToString(FactionOwnership.germans));
                }
                if (unit.ownership.HasFlag(FactionOwnership.greek))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else edu.Write(", ");
                    edu.Write(enumsToStrings.FactionToString(FactionOwnership.greek));
                }
                if (unit.ownership.HasFlag(FactionOwnership.greek_cities))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else edu.Write(", ");
                    edu.Write(enumsToStrings.FactionToString(FactionOwnership.greek_cities));
                }
                if (unit.ownership.HasFlag(FactionOwnership.macedon))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else edu.Write(", ");
                    edu.Write(enumsToStrings.FactionToString(FactionOwnership.macedon));
                }
                if (unit.ownership.HasFlag(FactionOwnership.none))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else edu.Write(", ");
                    edu.Write(enumsToStrings.FactionToString(FactionOwnership.none));
                }
                if (unit.ownership.HasFlag(FactionOwnership.numidia))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else edu.Write(", ");
                    edu.Write(enumsToStrings.FactionToString(FactionOwnership.numidia));
                }
                if (unit.ownership.HasFlag(FactionOwnership.parthia))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else edu.Write(", ");
                    edu.Write(enumsToStrings.FactionToString(FactionOwnership.parthia));
                }
                if (unit.ownership.HasFlag(FactionOwnership.parthian))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else edu.Write(", ");
                    edu.Write(enumsToStrings.FactionToString(FactionOwnership.parthian));
                }
                if (unit.ownership.HasFlag(FactionOwnership.pontus))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else edu.Write(", ");
                    edu.Write(enumsToStrings.FactionToString(FactionOwnership.pontus));
                }
                if (unit.ownership.HasFlag(FactionOwnership.roman))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else edu.Write(", ");
                    edu.Write(enumsToStrings.FactionToString(FactionOwnership.roman));
                }
                if (unit.ownership.HasFlag(FactionOwnership.romans_brutii))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else edu.Write(", ");
                    edu.Write(enumsToStrings.FactionToString(FactionOwnership.romans_brutii));
                }
                if (unit.ownership.HasFlag(FactionOwnership.romans_julii))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else edu.Write(", ");
                    edu.Write(enumsToStrings.FactionToString(FactionOwnership.romans_julii));
                }
                if (unit.ownership.HasFlag(FactionOwnership.romans_scipii))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else edu.Write(", ");
                    edu.Write(enumsToStrings.FactionToString(FactionOwnership.romans_scipii));
                }
                if (unit.ownership.HasFlag(FactionOwnership.romans_senate))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else edu.Write(", ");
                    edu.Write(enumsToStrings.FactionToString(FactionOwnership.romans_senate));
                }
                if (unit.ownership.HasFlag(FactionOwnership.scythia))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else edu.Write(", ");
                    edu.Write(enumsToStrings.FactionToString(FactionOwnership.scythia));
                }
                if (unit.ownership.HasFlag(FactionOwnership.seleucid))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else edu.Write(", ");
                    edu.Write(enumsToStrings.FactionToString(FactionOwnership.seleucid));
                }
                if (unit.ownership.HasFlag(FactionOwnership.slave))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else edu.Write(", ");
                    edu.Write(enumsToStrings.FactionToString(FactionOwnership.slave));
                }
                if (unit.ownership.HasFlag(FactionOwnership.spain))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else edu.Write(", ");
                    edu.Write(enumsToStrings.FactionToString(FactionOwnership.spain));
                }
                if (unit.ownership.HasFlag(FactionOwnership.thrace))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else edu.Write(", ");
                    edu.Write(enumsToStrings.FactionToString(FactionOwnership.thrace));
                }
                if (unit.ownership.HasFlag(FactionOwnership.numidian))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else edu.Write(", ");
                    edu.Write(enumsToStrings.FactionToString(FactionOwnership.numidian));
                }
                if (unit.ownership.HasFlag(FactionOwnership.barbarian))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else edu.Write(", ");
                    edu.Write(enumsToStrings.FactionToString(FactionOwnership.barbarian));
                }


                edu.Write("\r\n\n");
            }

            edu.Close();
            
            
        }

        public void SaveDStrat()
        {

            StreamWriter strat = new StreamWriter(Data.ModFolderPath + Data.DESCSTRAT);

            strat.WriteLine(";RANDOMISED\r\n\n");

            int factionNo = 0;
            List<string> tempsettles = new List<string>();
            foreach (string s in Data.desc_StratData)
            {
                if (s.StartsWith("denari"))
                {
                    strat.WriteLine(s);
                    tempsettles.Clear();
                    factionNo++;
                    int rndNum = Data.rnd.Next(0, Data.settlements.Count - 1);
                    for (int i = 0; i < Data.rnd.Next(1, 5); i++)
                    {
                        
                        if (rndNum - i < 0)
                        {
                            strat.WriteLine(Data.settlements[rndNum + i].outputSettlement());
                            tempsettles.Add(Data.settlements[rndNum + i].region);
                            Data.settlements.RemoveAt(rndNum + i);
                        }

                        else if (rndNum + i >= Data.settlements.Count())
                        {
                            strat.WriteLine(Data.settlements[rndNum - i].outputSettlement());
                            tempsettles.Add(Data.settlements[rndNum - i].region);
                            Data.settlements.RemoveAt(rndNum - i);
                        }

                        else
                        {
                            strat.WriteLine(Data.settlements[rndNum + i].outputSettlement());
                            tempsettles.Add(Data.settlements[rndNum + i].region);
                            Data.settlements.RemoveAt(rndNum + i);
                        }

                       
                    }
                }

                else if (s.StartsWith("character") && !s.StartsWith("character_record"))
                {
                    string[] splitted = s.Split(',');

                    foreach (string s2 in splitted)
                    {

                        if (s2.Trim().StartsWith("admiral"))
                        {
                            break;
                        }

                        int rnd2 = Data.rnd.Next(0, tempsettles.Count() - 1);
                        int rnd3 = Data.rnd.Next(0, 0);

                        if (s2.Trim().StartsWith("x"))
                        {
                            string[] splitAgain = s2.Split(' ');

                            int index = Data.rgbRegions.FindIndex(x => x.name == tempsettles[0]);
                            splitAgain[1] = Convert.ToString(Data.rgbRegions[index].x);

                            splitted[splitted.Count() - 2] = "x" + " " + splitAgain[1];
                        }

                        if (s2.Trim().StartsWith("y"))
                        {
                            string[] splitAgain = s2.Split(' ');

                            int index = Data.rgbRegions.FindIndex(x => x.name == tempsettles[0]);
                            splitAgain[1] = Convert.ToString(Data.rgbRegions[index].y);

                            splitted[splitted.Count() - 1] = "y" + " " + splitAgain[1];
                        }

                    }
                        foreach (string s3 in splitted)
                        {
                            if (!s3.Trim().StartsWith("y"))
                                strat.Write(s3 + ", ");
                            else strat.Write(s3 + "\r\n");
                        }
                }

                else strat.WriteLine(s);
            }

            strat.Close();
        }

        public void SaveEDB()
        { 
        
        }

    }
}

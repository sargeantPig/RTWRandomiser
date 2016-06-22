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

        public static string RemoveFirstWord(string String)
        {
            string newString = "";

            string[] Temp = String.Split(' ');

            int i = 0;

            foreach(string temp in Temp)
            {
               if(i != 0)
                   newString += temp + " ";

                i++;
            }

            return newString; 
        }

        public FactionOwnership StringToFaction(string str)
        {
            FactionOwnership faction = FactionOwnership.none;

            switch(str)
            {
                case "roman":
                    faction = FactionOwnership.roman;
                    break;        

                case "romans_julii":
                    faction = FactionOwnership.romans_julii;
                    break;

                case "romans_brutii":
                    faction = FactionOwnership.romans_brutii;
                    break;

                case "romans_scipii":
                    faction = FactionOwnership.romans_scipii;
                    break;
                case "egypt":
                    faction = FactionOwnership.egypt;
                    break;
                case "seleucid":
                    faction = FactionOwnership.seleucid;
                    break;
                case "carthage":
                    faction = FactionOwnership.carthage;
                    break;
                case "parthia":
                    faction = FactionOwnership.parthia;
                    break;
                case "gauls":
                    faction = FactionOwnership.gauls;
                    break;
                case "germans":
                    faction = FactionOwnership.germans;
                    break;
                case "britons":
                    faction = FactionOwnership.britons;
                    break;
                case "greek_cities":
                    faction = FactionOwnership.greek_cities;
                    break;
                case "romans_senate":
                    faction = FactionOwnership.romans_senate;
                    break;
                case "macedon":
                    faction = FactionOwnership.macedon;
                    break;
                case "pontus":
                    faction = FactionOwnership.pontus;
                    break;
                case "armenia":
                    faction = FactionOwnership.armenia;
                    break;
                case "dacia":
                    faction = FactionOwnership.dacia;
                    break;
                case "numidia":
                    faction = FactionOwnership.numidia;
                    break;
                case "scythia":
                    faction = FactionOwnership.scythia;
                    break;
                case "spain":
                    faction = FactionOwnership.spain;
                    break;
                case "thrace":
                    faction = FactionOwnership.thrace;
                    break;
                case "slave":
                    faction = FactionOwnership.slave;
                    break;
            
            }



            return faction;
        
        }

        public string FactionToString(FactionOwnership faction)
        {

            string str = "";

            switch (faction)
            {
                case FactionOwnership.roman:
                    str = "roman";
                    break;

                case FactionOwnership.romans_julii:
                    str = "roman_julii";
                    break;

                case FactionOwnership.romans_brutii:
                    str = "romans_brutii";
                    break;

                case FactionOwnership.romans_scipii:
                    str = "romans_scipii";
                    break;
                case FactionOwnership.egypt:
                    str = "egypt";
                    break;
                case FactionOwnership.seleucid:
                    str = "seleucid" ;
                    break;
                case FactionOwnership.carthage:
                    str = "carthage";
                    break;
                case FactionOwnership.parthia:
                    str = "parthia";
                    break;
                case FactionOwnership.gauls:
                    str = "gauls";
                    break;
                case FactionOwnership.germans:
                    str = "germans";
                    break;
                case FactionOwnership.britons:
                    str = "britons";
                    break;
                case FactionOwnership.greek_cities:
                    str = "greek_cities";
                    break;
                case FactionOwnership.romans_senate:
                    str = "romans_senate";
                    break;
                case FactionOwnership.macedon:
                    str ="macedon";
                    break;
                case FactionOwnership.pontus:
                    str = "pontus";
                    break;
                case FactionOwnership.armenia:
                    str = "armenia";
                    break;
                case FactionOwnership.dacia:
                    str = "dacia";
                    break;
                case FactionOwnership.eastern:
                    str = "numidia";
                    break;
                case FactionOwnership.scythia:
                    str = "scythia";
                    break;
                case FactionOwnership.spain:
                    str = "spain";
                    break;
                case FactionOwnership.thrace:
                    str = "thrace";
                    break;
                case FactionOwnership.slave:
                    str = "slave";
                    break;

            }



            return str;

        }

        public string AttributesToString(Attributes attr)
        {
            string str = "";

            switch (attr)
            {
                case Attributes.sea_faring:
                    str = "sea_faring";
                    break;

                case Attributes.hide_forest:
                    str = "hide_forest";
                    break;

                case Attributes.hide_improved_forest:
                    str = "hide_improved_forest";
                    break;

                case Attributes.hide_long_grass:
                    str = "hide_long_grass";
                    break;
                case Attributes.hide_anywhere:
                    str = "hide_anywhere";
                    break;
                case Attributes.can_sap:
                    str = "can_sap";
                    break;
                case Attributes.frighten_foot:
                    str = "frighten_foot";
                    break;
                case Attributes.frighten_mounted:
                    str = "frighten_mounted";
                    break;
                case Attributes.can_run_amok:
                    str = "can_run_amok";
                    break;
                case Attributes.general_unit:
                    str = "general_unit";
                    break;
                case Attributes.general_unit_upgrade:
                    str = "general_unit_upgrade";
                    break;
                case Attributes.cantabrian_circle:
                    str = "cantabrian_circle";
                    break;
                case Attributes.no_custom:
                    str = "no_custom";
                    break;
                case Attributes.command:
                    str = "command";
                    break;
                case Attributes.mercenary_unit:
                    str = "mercenary_unit";
                    break;
                case Attributes.druid:
                    str = "druid";
                    break;
                case Attributes.warcry:
                    str = "warcry";
                    break;

            }

            return str;



        }

        public string FormationTostring(FormationTypes formation)
        {
            string str = "";

            switch(formation)
            {
                case FormationTypes.Formation_Phalanx:
                    str = "phalanx";
                    break;

                case FormationTypes.Formation_Testudo:
                    str = "testudo";
                    break;

                case FormationTypes.Formation_Schiltrom:
                    str = "schiltrom";
                    break;

                case FormationTypes.Formation_Horde:
                    str = "horde";
                    break;

                case FormationTypes.Formation_Square:
                    str = "square";
                    break;

                case FormationTypes.Formation_Wedge:
                    str = "wedge";
                    break;
            
            }

            return str;
        
        }

        public string MissleTypeToString(MissleType missle)
        {
            string str = "";

            switch (missle)
            {
                case MissleType.javelin:
                    str = "javelin";
                    break;

                case MissleType.stone:
                    str = "stone";
                    break;

                case MissleType.pilum:
                    str = "pilum";
                    break;

                case MissleType.arrow:
                    str = "arrow";
                    break;

                case MissleType.MT_no:
                    str = "no";
                    break;
            }

            return str;

        }

        public string WeaponTypeToString(WeaponType weapon)
        {
            string str = "";

            switch (weapon)
            {
                case WeaponType.melee:
                    str = "melee";
                    break;

                case WeaponType.thrown:
                    str = "thrown";
                    break;

                case WeaponType.missle:
                    str = "missle";
                    break;

                case WeaponType.siege_missle:
                    str = "siege_missle";
                    break;

                case WeaponType.WT_no:
                    str = "no";
                    break;
            }

            return str;
        }

        public string TechTypeToString(techType tech)
        {
            string str = "";

            switch (tech)
            {
                case techType.simple:
                    str = "simple";
                    break;

                case techType.other:
                    str = "other";
                    break;

                case techType.blade:
                    str = "blade";
                    break;

                case techType.archery:
                    str = "archery";
                    break;

                case techType.siege:
                    str = "siege";
                    break;

                case techType.TT_no:
                    str = "no";
                    break;
            }

            return str;
        }

        public string DamageTypeToString(DamageType dmg)
        {
            string str = "";

            switch (dmg)
            {
                case DamageType.piercing:
                    str = "piercing";
                    break;

                case DamageType.blunt:
                    str = "blunt";
                    break;

                case DamageType.slashing:
                    str = "slashing";
                    break;

                case DamageType.fire:
                    str = "fire";
                    break;

                case DamageType.DM_no:
                    str = "no";
                    break;
            }

            return str;
        }

        public string SoundTypeToString(SoundType snd)
        {
            string str = "";

            switch (snd)
            {
                case SoundType.knife:
                    str = "knife";
                    break;

                case SoundType.mace:
                    str = "mace";
                    break;

                case SoundType.axe:
                    str = "axe";
                    break;

                case SoundType.sword:
                    str = "sword";
                    break;

                case SoundType.spear:
                    str = "spear";
                    break;

                case SoundType.ST_no:
                    str = "no";
                    break;
            }

            return str;
        }

        public string ArmourSndToString(ArmourSound snd)
        {
            string str = "";

            switch (snd)
            {
                case ArmourSound.flesh:
                    str = "flesh";
                    break;

                case ArmourSound.leather:
                    str = "leather";
                    break;

                case ArmourSound.metal:
                    str = "metal";
                    break;
            }

            return str;
        }

        public string PriAttrToString(stat_pri_attr pri)
        {
            string str = "";

            switch (pri)
            {
                case stat_pri_attr.ap:
                    str = "ap";
                    break;

                case stat_pri_attr.bp:
                    str = "bp";
                    break;

                case stat_pri_attr.pa_spear:
                    str = "pa_spear";
                    break;

                case stat_pri_attr.long_pike:
                    str = "long_pike";
                    break;

                case stat_pri_attr.short_pike:
                    str = "short_pike";
                    break;

                case stat_pri_attr.prec:
                    str = "prec";
                    break;

                case stat_pri_attr.pa_thrown:
                    str = "pa_thrown";
                    break;

                case stat_pri_attr.launching:
                    str = "launching";
                    break;

                case stat_pri_attr.area:
                    str = "area";
                    break;

                case stat_pri_attr.PA_no:
                    str = "no";
                    break;
            }

            return str;


        }

        public string DisciplineToString(statmental_discipline dis)
        {
            string str = "";

            switch (dis)
            {
                case statmental_discipline.normal:
                    str = "normal";
                    break;

                case statmental_discipline.low:
                    str = "low";
                    break;

                case statmental_discipline.disciplined:
                    str = "disciplined";
                    break;

                case statmental_discipline.impetuous:
                    str = "impetuous";
                    break;
            }

            return str;


        }

        public string TrainingToString(statmental_training train)
        {
            string str = "";

            switch (train)
            {
                case statmental_training.untrained:
                    str = "untrained";
                    break;

                case statmental_training.trained:
                    str = "trained";
                    break;

                case statmental_training.highly_trained:
                    str = "highly_trained";
                    break;

            }

            return str;


        }

        public static class Data
        {
            public static Random rnd = new Random();

            public static List<Unit> units = new List<Unit>();

            public static string RtwFolderPath = "";
            public static  string EDUFILEPATH = @"\data\export_descr_unit.txt";
            public static string EDUFILEPATHTEST = @"\data\export_descr_unit_test.txt";
            public static  string EDBFILEPATH = @"\data\export_desc_buildings.txt";
        }

        private void butt_FolderSelect_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog;

            folderDialog = new FolderBrowserDialog();

            folderDialog.ShowDialog();

            Data.RtwFolderPath = @folderDialog.SelectedPath;

            txt_FolderPath.Text = Data.RtwFolderPath;
        }

        private void butt_LoadData_Click(object sender, EventArgs e)
        {
            string completeEduPath = Data.RtwFolderPath + Data.EDUFILEPATH;
            string completedEdbPath = Data.RtwFolderPath + Data.EDBFILEPATH;

            txt_Output.AppendText("Loading files...\r\n");
            
            txt_Output.AppendText("Loading " + completeEduPath + "\r\n");


            if (File.Exists(completeEduPath))
            {
                ParseEdu(completeEduPath);

            }

            else txt_Output.AppendText("File cannot be found!\r\n");

            Data.EDUFILEPATHTEST = Data.RtwFolderPath + Data.EDUFILEPATHTEST;

        }

        public void ParseEdu(string filePath)
        {
            Data.units.Clear();

            string line;
            int counter = -1;

            StreamReader edu = new StreamReader(filePath);

            while ((line = edu.ReadLine()) != null)
            {

                string[] key = line.Split(' ', ';');
                
                if(line.StartsWith("type"))
                {
                    counter++;

                    Data.units.Add(new Unit());

                    string trimmed = RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    Data.units[counter].type = trimmed;

                    txt_Output.AppendText(trimmed  + "\n");

                }

                else if (line.StartsWith("dictionary"))
                {
                    string trimmed = RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(';');

                    trimmed = splitted[0].TrimEnd();

                    Data.units[counter].dictionary = trimmed;
                }

                else if (line.StartsWith("category"))
                {
                    string trimmed = RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(';');

                    trimmed = splitted[0].TrimEnd();

                    Data.units[counter].category = trimmed;
                }

                else if (line.StartsWith("class"))
                {
                    string trimmed = RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(';');

                    trimmed = splitted[0].TrimEnd();

                    Data.units[counter].unitClass = trimmed;
                }

                else if (line.StartsWith("voice_type"))
                {
                    string trimmed = RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(';');

                    trimmed = splitted[0].TrimEnd();

                    Data.units[counter].voiceType = trimmed;
                }

                else if (line.StartsWith("soldier"))
                {
                    string trimmed = RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    Data.units[counter].soldier.name = splitted[0].Trim();
                    Data.units[counter].soldier.number = Convert.ToInt16(splitted[1].Trim());
                    Data.units[counter].soldier.extras = Convert.ToInt16(splitted[2].Trim());
                    Data.units[counter].soldier.collisionMass = (float)Convert.ToDouble(splitted[3].Trim());
                }

                else if (line.StartsWith("officer"))
                {
                    string trimmed = RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(';');

                    trimmed = splitted[0].TrimEnd();

                    Data.units[counter].officer.Add(trimmed);
                }

                else if (line.StartsWith("engine"))
                {
                    string trimmed = RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(';');
                    
                    trimmed = splitted[0].TrimEnd();

                    Data.units[counter].engine = trimmed;
                }

                else if (line.StartsWith("animal"))
                {
                    string trimmed = RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(';');

                    trimmed = splitted[0].TrimEnd();

                    Data.units[counter].animal = trimmed;
                }

                else if (line.StartsWith("mount_effect"))
                {
                    string trimmed = RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    string newCombined = "";
 
                    foreach(string full in splitted)
                    {
                        newCombined += full;
                    }

                    string[] reSplit = newCombined.Split(' ');

                    int i = 0;
                    foreach (string STRING in reSplit)
                    {

                        Data.units[counter].mountEffect.mountType.Add(reSplit[i]);
                        i++;
                        Data.units[counter].mountEffect.modifier.Add(Convert.ToInt16(reSplit[i]));
                        i++;

                        if (i > splitted.Count())
                            break;

                    }
                }        

                else if (line.StartsWith("mount"))
                {
                    string trimmed = RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(';');

                    trimmed = splitted[0].TrimEnd();

                    Data.units[counter].mount = trimmed;
                }

                else if (line.StartsWith("attributes"))
                {
                    string trimmed = RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    foreach (string STRING in splitted)
                    {
                        if (STRING == "sea_faring")
                            Data.units[counter].attributes |= Attributes.sea_faring;
                        else if(STRING == "hide_forest")
                            Data.units[counter].attributes |= Attributes.hide_forest;
                        else if (STRING == "hide_improved_forest")
                            Data.units[counter].attributes |= Attributes.hide_improved_forest;
                        else if (STRING == "hide_long_grass")
                            Data.units[counter].attributes |= Attributes.hide_long_grass;
                        else if (STRING == "hide_anywhere")
                            Data.units[counter].attributes |= Attributes.hide_anywhere;
                        else if (STRING == "can_sap")
                            Data.units[counter].attributes |= Attributes.can_sap;
                        else if (STRING == "frighten_foot")
                            Data.units[counter].attributes |= Attributes.frighten_foot;
                        else if (STRING == "frighten_mounted")
                            Data.units[counter].attributes |= Attributes.frighten_mounted;
                        else if (STRING == "can_run_amok")
                            Data.units[counter].attributes |= Attributes.can_run_amok;
                        else if (STRING == "general_unit")
                            Data.units[counter].attributes |= Attributes.general_unit;
                        else if (STRING == "general_unit_upgrade")
                            Data.units[counter].attributes |= Attributes.general_unit_upgrade;
                        else if (STRING == "cantabrian_circle")
                            Data.units[counter].attributes |= Attributes.cantabrian_circle;
                        else if (STRING == "no_custom")
                            Data.units[counter].attributes |= Attributes.no_custom;
                        else if (STRING == "command")
                            Data.units[counter].attributes |= Attributes.command;
                        else if (STRING == "mercenary_unit")
                            Data.units[counter].attributes |= Attributes.mercenary_unit;
                        else if (STRING == "druid")
                            Data.units[counter].attributes |= Attributes.druid;
                        else if (STRING == "warcry")
                            Data.units[counter].attributes |= Attributes.warcry;

                    }

                }

                else if (line.StartsWith("formation"))
                {
                    string trimmed = RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    trimmed = splitted[0].TrimEnd();

                    int i = 0;
                    int a = 0;
                    int b = 0;

                    foreach(string STRING in splitted)
                    {
                        if (i < 2)
                            Data.units[counter].formation.FormationTight[i] = (float)Convert.ToDouble(STRING.Trim());
                        else if (a < 2)
                        {
                            Data.units[counter].formation.FormationSparse[a] = (float)Convert.ToDouble(STRING.Trim());
                            a++;
                        }
                        else if (b < 1)
                        {
                            Data.units[counter].formation.FormationRanks = Convert.ToInt16(STRING.Trim());
                            b++;
                        }

                        else if (STRING.Trim() == "phalanx")
                            Data.units[counter].formation.FormationFlags |= FormationTypes.Formation_Phalanx;
                        else if (STRING.Trim() == "testudo")
                            Data.units[counter].formation.FormationFlags |= FormationTypes.Formation_Testudo;
                        else if (STRING.Trim() == "schiltrom")
                            Data.units[counter].formation.FormationFlags |= FormationTypes.Formation_Schiltrom;
                        else if (STRING.Trim() == "horde")
                            Data.units[counter].formation.FormationFlags |= FormationTypes.Formation_Horde;
                        else if (STRING.Trim() == "square")
                            Data.units[counter].formation.FormationFlags |= FormationTypes.Formation_Square;
                        else if (STRING.Trim() == "wedge")
                            Data.units[counter].formation.FormationFlags |= FormationTypes.Formation_Wedge;

                        i++;
                    }
                }

                else if (line.StartsWith("stat_health"))
                {
                    string trimmed = RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    Data.units[counter].heatlh[0] = Convert.ToInt16(splitted[0]);
                    Data.units[counter].heatlh[1] = Convert.ToInt16(splitted[1]);
                }

                else if (line.StartsWith("stat_pri_attr"))
                { 
                    string trimmed = RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    foreach (string STRING in splitted)
                    {
                        if (STRING == "ap")
                            Data.units[counter].priAttri |= stat_pri_attr.ap;
                        else if (STRING == "bp")
                            Data.units[counter].priAttri |= stat_pri_attr.bp;
                        else if (STRING == "pa_spear")
                            Data.units[counter].priAttri |= stat_pri_attr.pa_spear;
                        else if (STRING == "long_pike")
                            Data.units[counter].priAttri |= stat_pri_attr.long_pike;
                        else if (STRING == "short_pike")
                            Data.units[counter].priAttri |= stat_pri_attr.short_pike;
                        else if (STRING == "prec")
                            Data.units[counter].priAttri |= stat_pri_attr.prec;
                        else if (STRING == "pa_thrown")
                            Data.units[counter].priAttri |= stat_pri_attr.pa_thrown;
                        else if (STRING == "launching")
                            Data.units[counter].priAttri |= stat_pri_attr.launching;
                        else if (STRING == "area")
                            Data.units[counter].priAttri |= stat_pri_attr.area;
                        else if (STRING == "no")
                            Data.units[counter].priAttri |= stat_pri_attr.PA_no;
                    }

                }

                else if(line.StartsWith("stat_pri_armour"))
                {
                    string trimmed = RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    trimmed = splitted[0].TrimEnd();

                    Data.units[counter].primaryArmour.stat_pri_armour[0] = Convert.ToInt16(splitted[0]);
                    Data.units[counter].primaryArmour.stat_pri_armour[1] = Convert.ToInt16(splitted[1]);
                    Data.units[counter].primaryArmour.stat_pri_armour[2] = Convert.ToInt16(splitted[2]);

                    if (splitted[3] == "flesh")
                        Data.units[counter].primaryArmour.armour_sound = ArmourSound.flesh;
                    else if(splitted[3] == "leather")
                        Data.units[counter].primaryArmour.armour_sound = ArmourSound.leather;
                    else if (splitted[3] == "metal")
                        Data.units[counter].primaryArmour.armour_sound = ArmourSound.metal;
                    
                }

                else if (line.StartsWith("stat_pri"))
                {
                    string trimmed = RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    trimmed = splitted[0].TrimEnd();

                    Data.units[counter].primaryWeapon.attack[0] = Convert.ToInt16(splitted[0]);
                    Data.units[counter].primaryWeapon.attack[1] = Convert.ToInt16(splitted[1]);

                    Data.units[counter].primaryWeapon.Missleattri[0] = Convert.ToInt16(splitted[3]);
                    Data.units[counter].primaryWeapon.Missleattri[1] = Convert.ToInt16(splitted[4]);

                    Data.units[counter].primaryWeapon.attackdelay[0] = (float)Convert.ToDouble(splitted[9]);
                    Data.units[counter].primaryWeapon.attackdelay[1] = (float)Convert.ToDouble(splitted[10]);

                    if (splitted[2].Trim() == "javelin")
                        Data.units[counter].primaryWeapon.missletypeFlags = MissleType.javelin;
                    else if (splitted[2].Trim() == "stone")
                        Data.units[counter].primaryWeapon.missletypeFlags = MissleType.stone;
                    else if (splitted[2].Trim() == "pilum")
                        Data.units[counter].primaryWeapon.missletypeFlags = MissleType.pilum;
                    else if (splitted[2].Trim() == "arrow")
                        Data.units[counter].primaryWeapon.missletypeFlags = MissleType.arrow;
                    else if (splitted[2].Trim() == "no")
                        Data.units[counter].primaryWeapon.missletypeFlags = MissleType.MT_no;

                    if (splitted[5].Trim() == "melee")
                        Data.units[counter].primaryWeapon.WeaponFlags = WeaponType.melee;
                    else if (splitted[5].Trim() == "thrown")
                        Data.units[counter].primaryWeapon.WeaponFlags = WeaponType.thrown;
                    else if (splitted[5].Trim() == "missle")
                        Data.units[counter].primaryWeapon.WeaponFlags = WeaponType.missle;
                    else if (splitted[5].Trim() == "siege_missle")
                        Data.units[counter].primaryWeapon.WeaponFlags = WeaponType.siege_missle;
                    else if (splitted[5].Trim() == "no")
                        Data.units[counter].primaryWeapon.WeaponFlags = WeaponType.WT_no;

                    if (splitted[6].Trim() == "simple")
                        Data.units[counter].primaryWeapon.TechFlags = techType.simple;
                    else if (splitted[6].Trim() == "other")
                        Data.units[counter].primaryWeapon.TechFlags = techType.other;
                    else if (splitted[6].Trim() == "blade")
                        Data.units[counter].primaryWeapon.TechFlags = techType.blade;
                    else if (splitted[6].Trim() == "archery")
                        Data.units[counter].primaryWeapon.TechFlags = techType.archery;
                    else if (splitted[6].Trim() == "siege")
                        Data.units[counter].primaryWeapon.TechFlags = techType.siege;
                    else if (splitted[6].Trim() == "no")
                        Data.units[counter].primaryWeapon.TechFlags = techType.TT_no;

                    if (splitted[7].Trim() == "piercing")
                        Data.units[counter].primaryWeapon.DamageFlags = DamageType.piercing;
                    else if (splitted[7].Trim() == "blunt")
                        Data.units[counter].primaryWeapon.DamageFlags = DamageType.blunt;
                    else if (splitted[7].Trim() == "slashing")
                        Data.units[counter].primaryWeapon.DamageFlags = DamageType.slashing;
                    else if (splitted[7].Trim() == "fire")
                        Data.units[counter].primaryWeapon.DamageFlags = DamageType.fire;
                    else if (splitted[7].Trim() == "no")
                        Data.units[counter].primaryWeapon.DamageFlags = DamageType.DM_no;

                    if (splitted[8].Trim() == "no")
                        Data.units[counter].primaryWeapon.SoundFlags = SoundType.ST_no;
                    else if (splitted[8].Trim() == "knife")
                        Data.units[counter].primaryWeapon.SoundFlags = SoundType.knife;
                    else if (splitted[8].Trim() == "mace")
                        Data.units[counter].primaryWeapon.SoundFlags = SoundType.mace;
                    else if (splitted[8].Trim() == "axe")
                        Data.units[counter].primaryWeapon.SoundFlags = SoundType.axe;
                    else if (splitted[8].Trim() == "sword")
                        Data.units[counter].primaryWeapon.SoundFlags = SoundType.sword;
                    else if (splitted[8].Trim() == "spear")
                        Data.units[counter].primaryWeapon.SoundFlags = SoundType.spear;

                }

                else if (line.StartsWith("stat_sec_attr"))
                {
                    string trimmed = RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    foreach (string STRING in splitted)
                    {
                        if (STRING == "ap")
                            Data.units[counter].secAttri |= stat_pri_attr.ap;
                        else if (STRING == "bp")
                            Data.units[counter].secAttri |= stat_pri_attr.bp;
                        else if (STRING == "pa_spear")
                            Data.units[counter].secAttri |= stat_pri_attr.pa_spear;
                        else if (STRING == "long_pike")
                            Data.units[counter].secAttri |= stat_pri_attr.long_pike;
                        else if (STRING == "short_pike")
                            Data.units[counter].secAttri |= stat_pri_attr.short_pike;
                        else if (STRING == "prec")
                            Data.units[counter].secAttri |= stat_pri_attr.prec;
                        else if (STRING == "pa_thrown")
                            Data.units[counter].secAttri |= stat_pri_attr.pa_thrown;
                        else if (STRING == "launching")
                            Data.units[counter].secAttri |= stat_pri_attr.launching;
                        else if (STRING == "area")
                            Data.units[counter].secAttri |= stat_pri_attr.area;
                        else if (STRING == "no")
                            Data.units[counter].secAttri |= stat_pri_attr.PA_no;
                    }

                }

                else if (line.StartsWith("stat_sec_armour"))
                {
                    string trimmed = RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    trimmed = splitted[0].TrimEnd();

                    Data.units[counter].secondaryArmour.stat_sec_armour[0] = Convert.ToInt16(splitted[0]);
                    Data.units[counter].secondaryArmour.stat_sec_armour[1] = Convert.ToInt16(splitted[1]);

                    if (splitted[2] == "flesh")
                        Data.units[counter].secondaryArmour.sec_armour_sound = ArmourSound.flesh;
                    else if (splitted[2] == "leather")
                        Data.units[counter].secondaryArmour.sec_armour_sound = ArmourSound.leather;
                    else if (splitted[2] == "metal")
                        Data.units[counter].secondaryArmour.sec_armour_sound = ArmourSound.metal;

                }

                else if (line.StartsWith("stat_sec"))
                {
                    string trimmed = RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    trimmed = splitted[0].TrimEnd();

                    Data.units[counter].secondaryWeapon.attack[0] = Convert.ToInt16(splitted[0]);
                    Data.units[counter].secondaryWeapon.attack[1] = Convert.ToInt16(splitted[1]);

                    Data.units[counter].secondaryWeapon.Missleattri[0] = Convert.ToInt16(splitted[3]);
                    Data.units[counter].secondaryWeapon.Missleattri[1] = Convert.ToInt16(splitted[4]);

                    Data.units[counter].secondaryWeapon.attackdelay[0] = (float)Convert.ToDouble(splitted[9]);
                    Data.units[counter].secondaryWeapon.attackdelay[1] = (float)Convert.ToDouble(splitted[10]);

                    if (splitted[2].Trim() == "javelin")
                        Data.units[counter].secondaryWeapon.missletypeFlags = MissleType.javelin;
                    else if (splitted[2].Trim() == "stone")
                        Data.units[counter].secondaryWeapon.missletypeFlags = MissleType.stone;
                    else if (splitted[2].Trim() == "pilum")
                        Data.units[counter].secondaryWeapon.missletypeFlags = MissleType.pilum;
                    else if (splitted[2].Trim() == "arrow")
                        Data.units[counter].secondaryWeapon.missletypeFlags = MissleType.arrow;
                    else if (splitted[2].Trim() == "no")
                        Data.units[counter].secondaryWeapon.missletypeFlags = MissleType.MT_no;

                    if (splitted[5].Trim() == "melee")
                        Data.units[counter].secondaryWeapon.WeaponFlags = WeaponType.melee;
                    else if (splitted[5].Trim() == "thrown")
                        Data.units[counter].secondaryWeapon.WeaponFlags = WeaponType.thrown;
                    else if (splitted[5].Trim() == "missle")
                        Data.units[counter].secondaryWeapon.WeaponFlags = WeaponType.missle;
                    else if (splitted[5].Trim() == "siege_missle")
                        Data.units[counter].secondaryWeapon.WeaponFlags = WeaponType.siege_missle;
                    else if (splitted[5].Trim() == "no")
                        Data.units[counter].secondaryWeapon.WeaponFlags = WeaponType.WT_no;

                    if (splitted[6].Trim() == "simple")
                        Data.units[counter].secondaryWeapon.TechFlags = techType.simple;
                    else if (splitted[6].Trim() == "other")
                        Data.units[counter].secondaryWeapon.TechFlags = techType.other;
                    else if (splitted[6].Trim() == "blade")
                        Data.units[counter].secondaryWeapon.TechFlags = techType.blade;
                    else if (splitted[6].Trim() == "archery")
                        Data.units[counter].secondaryWeapon.TechFlags = techType.archery;
                    else if (splitted[6].Trim() == "siege")
                        Data.units[counter].secondaryWeapon.TechFlags = techType.siege;
                    else if (splitted[6].Trim() == "no")
                        Data.units[counter].secondaryWeapon.TechFlags = techType.TT_no;

                    if (splitted[7].Trim() == "piercing")
                        Data.units[counter].secondaryWeapon.DamageFlags = DamageType.piercing;
                    else if (splitted[7].Trim() == "blunt")
                        Data.units[counter].secondaryWeapon.DamageFlags = DamageType.blunt;
                    else if (splitted[7].Trim() == "slashing")
                        Data.units[counter].secondaryWeapon.DamageFlags = DamageType.slashing;
                    else if (splitted[7].Trim() == "fire")
                        Data.units[counter].secondaryWeapon.DamageFlags = DamageType.fire;
                    else if (splitted[7].Trim() == "no")
                        Data.units[counter].secondaryWeapon.DamageFlags = DamageType.DM_no;

                    if (splitted[8].Trim() == "no")
                        Data.units[counter].secondaryWeapon.SoundFlags = SoundType.ST_no;
                    else if (splitted[8].Trim() == "knife")
                        Data.units[counter].secondaryWeapon.SoundFlags = SoundType.knife;
                    else if (splitted[8].Trim() == "mace")
                        Data.units[counter].secondaryWeapon.SoundFlags = SoundType.mace;
                    else if (splitted[8].Trim() == "axe")
                        Data.units[counter].secondaryWeapon.SoundFlags = SoundType.axe;
                    else if (splitted[8].Trim() == "sword")
                        Data.units[counter].secondaryWeapon.SoundFlags = SoundType.sword;
                    else if (splitted[8].Trim() == "spear")
                        Data.units[counter].secondaryWeapon.SoundFlags = SoundType.spear;

                }

                else if (line.StartsWith("heat"))
                {
                    string trimmed = RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    trimmed = splitted[0].TrimEnd();

                    Data.units[counter].heat = Convert.ToInt16(trimmed);

                }

                else if (line.StartsWith("ground"))
                {
                    string trimmed = RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    trimmed = splitted[0].TrimEnd();

                    Data.units[counter].ground[0] = Convert.ToInt16(splitted[0]);
                    Data.units[counter].ground[1] = Convert.ToInt16(splitted[1]);
                    Data.units[counter].ground[2] = Convert.ToInt16(splitted[2]);
                    Data.units[counter].ground[3] = Convert.ToInt16(splitted[3]);

                }

                else if (line.StartsWith("stat_mental"))
                {
                    string trimmed = RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    trimmed = splitted[0].TrimEnd();

                    Data.units[counter].mental.morale = Convert.ToInt16(splitted[0]);

                    if (splitted[1].Trim() == "normal")
                        Data.units[counter].mental.discipline = statmental_discipline.normal;
                    else if (splitted[1].Trim() == "low")
                        Data.units[counter].mental.discipline = statmental_discipline.low;
                    else if (splitted[1].Trim() == "disciplined")
                        Data.units[counter].mental.discipline = statmental_discipline.disciplined;
                    else if (splitted[1].Trim() == "impetuous")
                        Data.units[counter].mental.discipline = statmental_discipline.impetuous;

                    if (splitted[2].Trim() == "untrained")
                        Data.units[counter].mental.training = statmental_training.untrained;
                    else if (splitted[2].Trim() == "trained")
                        Data.units[counter].mental.training = statmental_training.trained;
                    else if (splitted[2].Trim() == "highly_trained")
                        Data.units[counter].mental.training = statmental_training.highly_trained;
                }

                else if (line.StartsWith("stat_charge_dist"))
                {
                    string trimmed = RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    trimmed = splitted[0].TrimEnd();

                    Data.units[counter].chargeDistance = Convert.ToInt16(trimmed);

                }

                else if (line.StartsWith("stat_fire_delay"))
                {
                    string trimmed = RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    trimmed = splitted[0].TrimEnd();

                    Data.units[counter].fireDelay = Convert.ToInt16(trimmed);

                }

                else if (line.StartsWith("stat_food"))
                {
                    string trimmed = RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    trimmed = splitted[0].TrimEnd();

                    Data.units[counter].food[0] = Convert.ToInt16(splitted[0]);
                    Data.units[counter].food[1] = Convert.ToInt16(splitted[1]);

                }

                else if (line.StartsWith("stat_cost"))
                {
                    string trimmed = RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    trimmed = splitted[0].TrimEnd();

                    int i = 0;
                    foreach (string STRING in splitted)
                    {
                        Data.units[counter].cost[i] = Convert.ToInt16(STRING);
                        i++;
                    }

                }

                else if (line.StartsWith("ownership"))
                {
                    string trimmed = RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    trimmed = splitted[0].TrimEnd();

                    int i = 0;
                    foreach (string STRING in splitted)
                    {
                        if (STRING.Trim() == "romans_julii")
                            Data.units[counter].ownership |= FactionOwnership.roman;
                        else if (STRING.Trim() == "roman")
                            Data.units[counter].ownership |= FactionOwnership.roman;
                        else if (STRING.Trim() == "egyptian")
                            Data.units[counter].ownership |= FactionOwnership.egyptian;
                        else if (STRING.Trim() == "eastern")
                            Data.units[counter].ownership |= FactionOwnership.eastern;
                        else if (STRING.Trim() == "parthian")
                            Data.units[counter].ownership |= FactionOwnership.parthian;
                        else if (STRING.Trim() == "greek")
                            Data.units[counter].ownership |= FactionOwnership.greek;
                        else if (STRING.Trim() == "carthaginian")
                            Data.units[counter].ownership |= FactionOwnership.carthaginian;
                        else if (STRING.Trim() == "egypt")
                            Data.units[counter].ownership |= FactionOwnership.egypt;
                        else if (STRING.Trim() == "seleucid")
                            Data.units[counter].ownership |= FactionOwnership.seleucid;
                        else if (STRING.Trim() == "carthage")
                            Data.units[counter].ownership |= FactionOwnership.carthage;
                        else if (STRING.Trim() == "parthia")
                            Data.units[counter].ownership |= FactionOwnership.parthia;
                        else if (STRING.Trim() == "gauls")
                            Data.units[counter].ownership |= FactionOwnership.gauls;
                        else if (STRING.Trim() == "germans")
                            Data.units[counter].ownership |= FactionOwnership.germans;
                        else if (STRING.Trim() == "britons")
                            Data.units[counter].ownership |= FactionOwnership.britons;
                        else if (STRING.Trim() == "greek_cities")
                            Data.units[counter].ownership |= FactionOwnership.greek_cities;
                        else if (STRING.Trim() == "romans_senate")
                            Data.units[counter].ownership |= FactionOwnership.romans_senate;
                        else if (STRING.Trim() == "macedon")
                            Data.units[counter].ownership |= FactionOwnership.macedon;
                        else if (STRING.Trim() == "pontus")
                            Data.units[counter].ownership |= FactionOwnership.pontus;
                        else if (STRING.Trim() == "armenia")
                            Data.units[counter].ownership |= FactionOwnership.armenia;
                        else if (STRING.Trim() == "dacia")
                            Data.units[counter].ownership |= FactionOwnership.dacia;
                        else if (STRING.Trim() == "numidia")
                            Data.units[counter].ownership |= FactionOwnership.numidia;
                        else if (STRING.Trim() == "scythia")
                            Data.units[counter].ownership |= FactionOwnership.scythia;
                        else if (STRING.Trim() == "spain")
                            Data.units[counter].ownership |= FactionOwnership.spain;
                        else if (STRING.Trim() == "thrace")
                            Data.units[counter].ownership |= FactionOwnership.thrace;
                        else if (STRING.Trim() == "slave")
                            Data.units[counter].ownership |= FactionOwnership.slave;

                    }
                }
            }

            txt_Output.AppendText("\n" + Data.units.Count + "Units loaded from EDU");


        }

        private void cbox_factions_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = cbox_factions.SelectedItem.ToString();

            txt_outputview.Clear();

            int amount = 0;

            foreach (Unit unit in Data.units)
            {
                if ((unit.ownership & StringToFaction(selected)) == StringToFaction(selected))
                {
                    txt_outputview.AppendText(unit.type + " (" + unit.dictionary + ")\n");
                    amount++; 
                }
            }
            txt_outputview.AppendText(" Units: " + amount);
        }

        private void but_randomize_Click(object sender, EventArgs e)
        {
            int OwnershipPerUnit;
            bool unitSizes, stats, reasonableStats, rndCost, rndSounds;

            //if (cbx_ownershipPerUnit.SelectedItem.ToString() != "RANDOM")
              //  OwnershipPerUnit = Convert.ToInt16(cbx_ownershipPerUnit.SelectedItem.ToString());
            //else OwnershipPerUnit = Data.rnd.Next(1, 10);

            if (chk_UnitSizes.Checked)
                unitSizes = true;
            else unitSizes = false;

            if (chk_rndStats.Checked)
                stats = true;
            else stats = false;

            if (chk_costs.Checked)
                rndCost = true;
            else rndCost = false;

            if (chk_statsWithReason.Checked)
                reasonableStats = true;
            else reasonableStats = false;

            if (chk_rndSounds.Checked)
                rndSounds = true;
            else rndSounds = false;

            SaveEDU();
            foreach (Unit unit in Data.units)
            {
                if (unitSizes)
                { //unit size stuff here
                }

                if (stats)
                { //stats stuff here (weapon/armour) 
                }

                if(reasonableStats)
                {//stats here
                }

                if (rndSounds)
                { //sounds here
                
                }

                if (rndCost)
                { //costs here 
                
                }
            
            }


        }


        public void SaveEDU()
        {
            StreamWriter edu = new StreamWriter(Data.EDUFILEPATHTEST);

            edu.WriteLine(";RANDOMISED\r\n\n");

            foreach (Unit unit in Data.units)
            {
                edu.WriteLine(
                    "type\t\t\t" + unit.type + "\n" +
                    "dictionary\t\t\t" + unit.dictionary + "\n" +
                    "category\t\t\t" + unit.category + "\n" +
                    "class\t\t\t" + unit.unitClass + "\n" +
                    "voice_type\t\t\t" + unit.voiceType + "\n" +
                    "soldier\t\t\t" + unit.soldier.name + ", " + unit.soldier.number.ToString() + ", " + unit.soldier.extras.ToString() + ", " + unit.soldier.collisionMass.ToString());

                edu.Write("attributes\t\t\t"); // write attributes
                if (unit.attributes.HasFlag(Attributes.sea_faring))
                    edu.Write(AttributesToString(Attributes.sea_faring) + ", ");
                if (unit.attributes.HasFlag(Attributes.can_run_amok))
                    edu.Write(AttributesToString(Attributes.can_run_amok) + ", ");
                if (unit.attributes.HasFlag(Attributes.can_sap))
                    edu.Write(AttributesToString(Attributes.can_sap) + ", ");
                if (unit.attributes.HasFlag(Attributes.cantabrian_circle))
                    edu.Write(AttributesToString(Attributes.cantabrian_circle) + ", ");
                if (unit.attributes.HasFlag(Attributes.command))
                    edu.Write(AttributesToString(Attributes.command) + ", ");
                if (unit.attributes.HasFlag(Attributes.druid))
                    edu.Write(AttributesToString(Attributes.druid) + ", ");
                if (unit.attributes.HasFlag(Attributes.frighten_foot))
                    edu.Write(AttributesToString(Attributes.frighten_foot) + ", ");
                if (unit.attributes.HasFlag(Attributes.frighten_mounted))
                    edu.Write(AttributesToString(Attributes.frighten_mounted) + ", ");
                if (unit.attributes.HasFlag(Attributes.general_unit))
                    edu.Write(AttributesToString(Attributes.general_unit) + ", ");
                if (unit.attributes.HasFlag(Attributes.general_unit_upgrade))
                    edu.Write(AttributesToString(Attributes.general_unit_upgrade) + ", ");
                if (unit.attributes.HasFlag(Attributes.hide_anywhere))
                    edu.Write(AttributesToString(Attributes.hide_anywhere) + ", ");
                if (unit.attributes.HasFlag(Attributes.hide_forest))
                    edu.Write(AttributesToString(Attributes.hide_forest) + ", ");
                if (unit.attributes.HasFlag(Attributes.hide_improved_forest))
                    edu.Write(AttributesToString(Attributes.hide_improved_forest) + ", ");
                if (unit.attributes.HasFlag(Attributes.hide_long_grass))
                    edu.Write(AttributesToString(Attributes.hide_long_grass) + ", ");
                if (unit.attributes.HasFlag(Attributes.mercenary_unit))
                    edu.Write(AttributesToString(Attributes.mercenary_unit) + ", ");
                if (unit.attributes.HasFlag(Attributes.no_custom))
                    edu.Write(AttributesToString(Attributes.no_custom) + ", ");
                if (unit.attributes.HasFlag(Attributes.warcry))
                    edu.Write(AttributesToString(Attributes.warcry) + ", ");

                edu.Write("\n");

                edu.Write("formation\t\t\t"); // write formation
                foreach (float num in unit.formation.FormationTight)
                    edu.Write(num.ToString() + ", ");
                foreach (float num in unit.formation.FormationSparse)
                    edu.Write(num.ToString() + ", ");
                edu.Write(unit.formation.FormationRanks + ", ");

                if (unit.formation.FormationFlags.HasFlag(FormationTypes.Formation_Phalanx))
                    edu.Write(FormationTostring(FormationTypes.Formation_Phalanx) + ", ");
                if (unit.formation.FormationFlags.HasFlag(FormationTypes.Formation_Testudo))
                    edu.Write(FormationTostring(FormationTypes.Formation_Testudo) + ", ");
                if (unit.formation.FormationFlags.HasFlag(FormationTypes.Formation_Schiltrom))
                    edu.Write(FormationTostring(FormationTypes.Formation_Schiltrom) + ", ");
                if (unit.formation.FormationFlags.HasFlag(FormationTypes.Formation_Horde))
                    edu.Write(FormationTostring(FormationTypes.Formation_Horde) + ", ");
                if (unit.formation.FormationFlags.HasFlag(FormationTypes.Formation_Square))
                    edu.Write(FormationTostring(FormationTypes.Formation_Square) + ", ");
                if (unit.formation.FormationFlags.HasFlag(FormationTypes.Formation_Wedge))
                    edu.Write(FormationTostring(FormationTypes.Formation_Wedge) + ", ");

                edu.Write("\n");

                edu.Write("stat_health\t\t\t"); //write health
                foreach (int health in unit.heatlh)
                    edu.Write(health + ", ");

                edu.Write("\n");

                edu.Write("stat_pri\t\t\t"); // write primary weapon
                foreach (int atk in unit.primaryWeapon.attack)
                    edu.Write(atk + ", ");
                edu.Write(MissleTypeToString(unit.primaryWeapon.missletypeFlags) + ", ");
                foreach (int miss in unit.primaryWeapon.Missleattri)
                    edu.Write(miss + ", ");
                edu.Write(
                    WeaponTypeToString(unit.primaryWeapon.WeaponFlags) + ", " +
                    TechTypeToString(unit.primaryWeapon.TechFlags) + ", " +
                    DamageTypeToString(unit.primaryWeapon.DamageFlags) + ", " +
                    SoundTypeToString(unit.primaryWeapon.SoundFlags) + ", ");
                foreach (float atkd in unit.primaryWeapon.attackdelay)
                    edu.Write(atkd + ", ");

                edu.Write("\n");

                edu.Write("stat_pri_attr\t\t\t"); //attributes

                if (unit.priAttri.HasFlag(stat_pri_attr.ap))
                    edu.Write(PriAttrToString(stat_pri_attr.ap) + ", ");

                if (unit.priAttri.HasFlag(stat_pri_attr.bp))
                    edu.Write(PriAttrToString(stat_pri_attr.bp) + ", ");

                if (unit.priAttri.HasFlag(stat_pri_attr.pa_spear))
                    edu.Write(PriAttrToString(stat_pri_attr.pa_spear) + ", ");

                if (unit.priAttri.HasFlag(stat_pri_attr.long_pike))
                    edu.Write(PriAttrToString(stat_pri_attr.long_pike) + ", ");

                if (unit.priAttri.HasFlag(stat_pri_attr.short_pike))
                    edu.Write(PriAttrToString(stat_pri_attr.short_pike) + ", ");

                if (unit.priAttri.HasFlag(stat_pri_attr.prec))
                    edu.Write(PriAttrToString(stat_pri_attr.prec) + ", ");

                if (unit.priAttri.HasFlag(stat_pri_attr.pa_thrown))
                    edu.Write(PriAttrToString(stat_pri_attr.pa_thrown) + ", ");

                if (unit.priAttri.HasFlag(stat_pri_attr.launching))
                    edu.Write(PriAttrToString(stat_pri_attr.launching) + ", ");

                if (unit.priAttri.HasFlag(stat_pri_attr.area))
                    edu.Write(PriAttrToString(stat_pri_attr.area) + ", ");

                if (unit.priAttri.HasFlag(stat_pri_attr.PA_no))
                    edu.Write(PriAttrToString(stat_pri_attr.PA_no));

                edu.Write("\n");

                edu.Write("stat_sec\t\t\t"); // secondary weapon
                foreach (int atk in unit.secondaryWeapon.attack)
                    edu.Write(atk + ", ");
                edu.Write(MissleTypeToString(unit.secondaryWeapon.missletypeFlags) + ", ");
                foreach (int miss in unit.secondaryWeapon.Missleattri)
                    edu.Write(miss + ", ");
                edu.Write(
                    WeaponTypeToString(unit.secondaryWeapon.WeaponFlags) + ", " +
                    TechTypeToString(unit.secondaryWeapon.TechFlags) + ", " +
                    DamageTypeToString(unit.secondaryWeapon.DamageFlags) + ", " +
                    SoundTypeToString(unit.secondaryWeapon.SoundFlags) + ", ");
                foreach (float atkd in unit.secondaryWeapon.attackdelay)
                    edu.Write(atkd + ", ");

                edu.Write("\n");

                edu.Write("stat_sec_attr\t\t\t");
                if (unit.secAttri.HasFlag(stat_pri_attr.ap))
                    edu.Write(PriAttrToString(stat_pri_attr.ap) + ", ");

                if (unit.secAttri.HasFlag(stat_pri_attr.bp))
                    edu.Write(PriAttrToString(stat_pri_attr.bp) + ", ");

                if (unit.secAttri.HasFlag(stat_pri_attr.pa_spear))
                    edu.Write(PriAttrToString(stat_pri_attr.pa_spear) + ", ");

                if (unit.secAttri.HasFlag(stat_pri_attr.long_pike))
                    edu.Write(PriAttrToString(stat_pri_attr.long_pike) + ", ");

                if (unit.secAttri.HasFlag(stat_pri_attr.short_pike))
                    edu.Write(PriAttrToString(stat_pri_attr.short_pike) + ", ");

                if (unit.secAttri.HasFlag(stat_pri_attr.prec))
                    edu.Write(PriAttrToString(stat_pri_attr.prec) + ", ");

                if (unit.secAttri.HasFlag(stat_pri_attr.pa_thrown))
                    edu.Write(PriAttrToString(stat_pri_attr.pa_thrown) + ", ");

                if (unit.secAttri.HasFlag(stat_pri_attr.launching))
                    edu.Write(PriAttrToString(stat_pri_attr.launching) + ", ");

                if (unit.secAttri.HasFlag(stat_pri_attr.area))
                    edu.Write(PriAttrToString(stat_pri_attr.area) + ", ");

                if (unit.secAttri.HasFlag(stat_pri_attr.PA_no))
                    edu.Write(PriAttrToString(stat_pri_attr.PA_no));

                edu.Write("\n");

                edu.Write("stat_pri_armour\t\t\t");
                foreach (int numb in unit.primaryArmour.stat_pri_armour)
                    edu.Write(numb + ", ");
                edu.Write(ArmourSndToString(unit.primaryArmour.armour_sound));

                edu.Write("\n");

                edu.Write("stat_sec_armour\t\t\t");
                foreach (int numb in unit.secondaryArmour.stat_sec_armour)
                    edu.Write(numb + ", ");
                edu.Write(ArmourSndToString(unit.secondaryArmour.sec_armour_sound));

                edu.Write("\n");

                edu.Write("stat_heat\t\t\t" + unit.heat);

                edu.Write("\n");

                edu.Write("stat_ground\t\t\t");
                foreach (int numb in unit.ground)
                    edu.Write(numb + ", ");

                edu.Write("\n");

                edu.Write("stat_mental\t\t\t" + unit.mental.morale + ", ");
                edu.Write(DisciplineToString(unit.mental.discipline) + ", " + TrainingToString(unit.mental.training));

                edu.Write("\n");

                edu.Write("stat_charge_dist\t\t\t" + unit.chargeDistance);

                edu.Write("\n");

                edu.Write("stat_fire_delay\t\t\t" + unit.fireDelay);

                edu.Write("\n");

                edu.Write("stat_cost\t\t\t");
                foreach (int cost in unit.cost)
                    edu.Write(cost + ", ");

                edu.Write("\n");

                edu.Write("stat_ownership\t\t\t");

                if (unit.ownership.HasFlag(FactionOwnership.armenia))
                    edu.Write(FactionToString(FactionOwnership.armenia) + ", ");
                if (unit.ownership.HasFlag(FactionOwnership.britons))
                    edu.Write(FactionToString(FactionOwnership.britons) + ", ");
                if (unit.ownership.HasFlag(FactionOwnership.carthage))
                    edu.Write(FactionToString(FactionOwnership.carthage) + ", ");
                if (unit.ownership.HasFlag(FactionOwnership.carthaginian))
                    edu.Write(FactionToString(FactionOwnership.carthaginian) + ", ");
                if (unit.ownership.HasFlag(FactionOwnership.dacia))
                    edu.Write(FactionToString(FactionOwnership.dacia) + ", ");
                if (unit.ownership.HasFlag(FactionOwnership.eastern))
                    edu.Write(FactionToString(FactionOwnership.eastern) + ", ");
                if (unit.ownership.HasFlag(FactionOwnership.egypt))
                    edu.Write(FactionToString(FactionOwnership.egypt) + ", ");
                if (unit.ownership.HasFlag(FactionOwnership.egyptian))
                    edu.Write(FactionToString(FactionOwnership.egyptian) + ", ");
                if (unit.ownership.HasFlag(FactionOwnership.gauls))
                    edu.Write(FactionToString(FactionOwnership.gauls) + ", ");
                if (unit.ownership.HasFlag(FactionOwnership.germans))
                    edu.Write(FactionToString(FactionOwnership.germans) + ", ");
                if (unit.ownership.HasFlag(FactionOwnership.greek))
                    edu.Write(FactionToString(FactionOwnership.greek) + ", ");
                if (unit.ownership.HasFlag(FactionOwnership.greek_cities))
                    edu.Write(FactionToString(FactionOwnership.greek_cities) + ", ");
                if (unit.ownership.HasFlag(FactionOwnership.macedon))
                    edu.Write(FactionToString(FactionOwnership.macedon) + ", ");
                if (unit.ownership.HasFlag(FactionOwnership.none))
                    edu.Write(FactionToString(FactionOwnership.none) + ", ");
                if (unit.ownership.HasFlag(FactionOwnership.numidia))
                    edu.Write(FactionToString(FactionOwnership.numidia) + ", ");
                if (unit.ownership.HasFlag(FactionOwnership.parthia))
                    edu.Write(FactionToString(FactionOwnership.parthia) + ", ");
                if (unit.ownership.HasFlag(FactionOwnership.parthian))
                    edu.Write(FactionToString(FactionOwnership.parthian) + ", ");
                if (unit.ownership.HasFlag(FactionOwnership.pontus))
                    edu.Write(FactionToString(FactionOwnership.pontus) + ", ");
                if (unit.ownership.HasFlag(FactionOwnership.roman))
                    edu.Write(FactionToString(FactionOwnership.roman) + ", ");
                if (unit.ownership.HasFlag(FactionOwnership.romans_brutii))
                    edu.Write(FactionToString(FactionOwnership.romans_brutii) + ", ");
                if (unit.ownership.HasFlag(FactionOwnership.romans_julii))
                    edu.Write(FactionToString(FactionOwnership.romans_julii) + ", ");
                if (unit.ownership.HasFlag(FactionOwnership.romans_scipii))
                    edu.Write(FactionToString(FactionOwnership.romans_scipii) + ", ");
                if (unit.ownership.HasFlag(FactionOwnership.romans_senate))
                    edu.Write(FactionToString(FactionOwnership.romans_senate) + ", ");
                if (unit.ownership.HasFlag(FactionOwnership.scythia))
                    edu.Write(FactionToString(FactionOwnership.scythia) + ", ");
                if (unit.ownership.HasFlag(FactionOwnership.seleucid))
                    edu.Write(FactionToString(FactionOwnership.seleucid) + ", ");
                if (unit.ownership.HasFlag(FactionOwnership.slave))
                    edu.Write(FactionToString(FactionOwnership.slave) + ", ");
                if (unit.ownership.HasFlag(FactionOwnership.spain))
                    edu.Write(FactionToString(FactionOwnership.spain) + ", ");
                if (unit.ownership.HasFlag(FactionOwnership.thrace))
                    edu.Write(FactionToString(FactionOwnership.thrace) + ", ");

                edu.Write("\n\n\n");
            }
            
            
        }

        public void SaveEDB()
        { 
        
        }


    }
}

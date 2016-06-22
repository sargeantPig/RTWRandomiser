using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Randomiser
{
    public static class Parsers
    {
        public static void ParseEdu(string filePath, ref TextBox txt_Output)
        {
            Data.units.Clear();

            string line;
            int counter = -1;

            StreamReader edu = new StreamReader(filePath);

            while ((line = edu.ReadLine()) != null)
            {

                string[] key = line.Split(' ', ';');

                if (line.StartsWith("type"))
                {
                    counter++;

                    Data.units.Add(new Unit());

                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    Data.units[counter].type = trimmed;

                   txt_Output.AppendText(trimmed + "\n");

                }

                else if (line.StartsWith("dictionary"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(';');

                    trimmed = splitted[0].TrimEnd();

                    Data.units[counter].dictionary = trimmed;
                }

                else if (line.StartsWith("category"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(';');

                    trimmed = splitted[0].TrimEnd();

                    Data.units[counter].category = trimmed;
                }

                else if (line.StartsWith("class"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(';');

                    trimmed = splitted[0].TrimEnd();

                    Data.units[counter].unitClass = trimmed;
                }

                else if (line.StartsWith("voice_type"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(';');

                    trimmed = splitted[0].TrimEnd();

                    Data.units[counter].voiceType = trimmed;
                }

                else if (line.StartsWith("soldier"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    Data.units[counter].soldier.name = splitted[0].Trim();
                    Data.units[counter].soldier.number = Convert.ToInt16(splitted[1].Trim());
                    Data.units[counter].soldier.extras = Convert.ToInt16(splitted[2].Trim());
                    Data.units[counter].soldier.collisionMass = (float)Convert.ToDouble(splitted[3].Trim());
                }

                else if (line.StartsWith("officer"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(';');

                    trimmed = splitted[0].TrimEnd();

                    Data.units[counter].officer.Add(trimmed);
                }

                else if (line.StartsWith("engine"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(';');

                    trimmed = splitted[0].TrimEnd();

                    Data.units[counter].engine = trimmed;
                }

                else if (line.StartsWith("animal"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(';');

                    trimmed = splitted[0].TrimEnd();

                    Data.units[counter].animal = trimmed;
                }

                else if (line.StartsWith("mount_effect"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    string newCombined = "";

                    foreach (string full in splitted)
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
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(';');

                    trimmed = splitted[0].TrimEnd();

                    Data.units[counter].mount = trimmed;
                }

                else if (line.StartsWith("attributes"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    foreach (string STRING in splitted)
                    {
                        if (STRING == "sea_faring")
                            Data.units[counter].attributes |= Attributes.sea_faring;
                        else if (STRING == "hide_forest")
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
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    trimmed = splitted[0].TrimEnd();

                    int i = 0;
                    int a = 0;
                    int b = 0;

                    foreach (string STRING in splitted)
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
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    Data.units[counter].heatlh[0] = Convert.ToInt16(splitted[0]);
                    Data.units[counter].heatlh[1] = Convert.ToInt16(splitted[1]);
                }

                else if (line.StartsWith("stat_pri_attr"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
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

                else if (line.StartsWith("stat_pri_armour"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    trimmed = splitted[0].TrimEnd();

                    Data.units[counter].primaryArmour.stat_pri_armour[0] = Convert.ToInt16(splitted[0]);
                    Data.units[counter].primaryArmour.stat_pri_armour[1] = Convert.ToInt16(splitted[1]);
                    Data.units[counter].primaryArmour.stat_pri_armour[2] = Convert.ToInt16(splitted[2]);

                    if (splitted[3].Trim() == "flesh")
                        Data.units[counter].primaryArmour.armour_sound = ArmourSound.flesh;
                    else if (splitted[3].Trim() == "leather")
                        Data.units[counter].primaryArmour.armour_sound = ArmourSound.leather;
                    else if (splitted[3].Trim() == "metal")
                        Data.units[counter].primaryArmour.armour_sound = ArmourSound.metal;

                }

                else if (line.StartsWith("stat_pri"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
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
                    string trimmed = Functions.RemoveFirstWord(line);
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
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    trimmed = splitted[0].TrimEnd();

                    Data.units[counter].secondaryArmour.stat_sec_armour[0] = Convert.ToInt16(splitted[0]);
                    Data.units[counter].secondaryArmour.stat_sec_armour[1] = Convert.ToInt16(splitted[1]);

                    if (splitted[2].Trim() == "flesh")
                        Data.units[counter].secondaryArmour.sec_armour_sound = ArmourSound.flesh;
                    else if (splitted[2].Trim() == "leather")
                        Data.units[counter].secondaryArmour.sec_armour_sound = ArmourSound.leather;
                    else if (splitted[2].Trim() == "metal")
                        Data.units[counter].secondaryArmour.sec_armour_sound = ArmourSound.metal;

                }

                else if (line.StartsWith("stat_sec"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
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
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    trimmed = splitted[0].TrimEnd();

                    Data.units[counter].heat = Convert.ToInt16(trimmed);

                }

                else if (line.StartsWith("ground"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
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
                    string trimmed = Functions.RemoveFirstWord(line);
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
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    trimmed = splitted[0].TrimEnd();

                    Data.units[counter].chargeDistance = Convert.ToInt16(trimmed);

                }

                else if (line.StartsWith("stat_fire_delay"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    trimmed = splitted[0].TrimEnd();

                    Data.units[counter].fireDelay = Convert.ToInt16(trimmed);

                }

                else if (line.StartsWith("stat_food"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    trimmed = splitted[0].TrimEnd();

                    Data.units[counter].food[0] = Convert.ToInt16(splitted[0]);
                    Data.units[counter].food[1] = Convert.ToInt16(splitted[1]);

                }

                else if (line.StartsWith("stat_cost"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
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
                    string trimmed = Functions.RemoveFirstWord(line);
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
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

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

                else if (line.StartsWith("ship"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(';');

                    trimmed = splitted[0].TrimEnd();

                    Data.units[counter].naval = trimmed;
                }


                else if (line.StartsWith("attributes"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    foreach (string STRING in splitted)
                    {
                        trimmed = STRING.Trim();

                        if (trimmed == "sea_faring")
                            Data.units[counter].attributes |= Attributes.sea_faring;
                        else if (trimmed == "hide_forest")
                            Data.units[counter].attributes |= Attributes.hide_forest;
                        else if (trimmed == "hide_improved_forest")
                            Data.units[counter].attributes |= Attributes.hide_improved_forest;
                        else if (trimmed == "hide_long_grass")
                            Data.units[counter].attributes |= Attributes.hide_long_grass;
                        else if (trimmed == "hide_anywhere")
                            Data.units[counter].attributes |= Attributes.hide_anywhere;
                        else if (trimmed == "can_sap")
                            Data.units[counter].attributes |= Attributes.can_sap;
                        else if (trimmed == "frighten_foot")
                            Data.units[counter].attributes |= Attributes.frighten_foot;
                        else if (trimmed == "frighten_mounted")
                            Data.units[counter].attributes |= Attributes.frighten_mounted;
                        else if (trimmed == "can_run_amok")
                            Data.units[counter].attributes |= Attributes.can_run_amok;
                        else if (trimmed == "general_unit")
                            Data.units[counter].attributes |= Attributes.general_unit;
                        else if (trimmed == "general_unit_upgrade")
                            Data.units[counter].attributes |= Attributes.general_unit_upgrade;
                        else if (trimmed == "cantabrian_circle")
                            Data.units[counter].attributes |= Attributes.cantabrian_circle;
                        else if (trimmed == "no_custom")
                            Data.units[counter].attributes |= Attributes.no_custom;
                        else if (trimmed == "command")
                            Data.units[counter].attributes |= Attributes.command;
                        else if (trimmed == "mercenary_unit")
                            Data.units[counter].attributes |= Attributes.mercenary_unit;
                        else if (trimmed == "druid")
                            Data.units[counter].attributes |= Attributes.druid;
                        else if (trimmed == "warcry")
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
                        if (STRING.Trim() == "ap")
                            Data.units[counter].priAttri |= stat_pri_attr.ap;
                        else if (STRING.Trim() == "bp")
                            Data.units[counter].priAttri |= stat_pri_attr.bp;
                        else if (STRING.Trim() == "pa_spear")
                            Data.units[counter].priAttri |= stat_pri_attr.pa_spear;
                        else if (STRING.Trim() == "long_pike")
                            Data.units[counter].priAttri |= stat_pri_attr.long_pike;
                        else if (STRING.Trim() == "short_pike")
                            Data.units[counter].priAttri |= stat_pri_attr.short_pike;
                        else if (STRING.Trim() == "prec")
                            Data.units[counter].priAttri |= stat_pri_attr.prec;
                        else if (STRING.Trim() == "pa_thrown")
                            Data.units[counter].priAttri |= stat_pri_attr.pa_thrown;
                        else if (STRING.Trim() == "launching")
                            Data.units[counter].priAttri |= stat_pri_attr.launching;
                        else if (STRING.Trim() == "area")
                            Data.units[counter].priAttri |= stat_pri_attr.area;
                        else if (STRING.Trim() == "no")
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
                    else if (splitted[2].Trim() == "ballista")
                        Data.units[counter].primaryWeapon.missletypeFlags = MissleType.ballista;
                    else if (splitted[2].Trim() == "boulder")
                        Data.units[counter].primaryWeapon.missletypeFlags = MissleType.onager;
                    else if (splitted[2].Trim() == "big_boulder")
                        Data.units[counter].primaryWeapon.missletypeFlags = MissleType.heavy_onager;
                    else if (splitted[2].Trim() == "scorpion")
                        Data.units[counter].primaryWeapon.missletypeFlags = MissleType.scorpion;
                    else if (splitted[2].Trim() == "repeating_ballista")
                        Data.units[counter].primaryWeapon.missletypeFlags = MissleType.repeating_ballista;
                    else if (splitted[2].Trim() == "bullet")
                        Data.units[counter].primaryWeapon.missletypeFlags = MissleType.bullet;

                    if (splitted[5].Trim() == "melee")
                        Data.units[counter].primaryWeapon.WeaponFlags = WeaponType.melee;
                    else if (splitted[5].Trim() == "thrown")
                        Data.units[counter].primaryWeapon.WeaponFlags = WeaponType.thrown;
                    else if (splitted[5].Trim() == "missle")
                        Data.units[counter].primaryWeapon.WeaponFlags = WeaponType.missle;
                    else if (splitted[5].Trim() == "siege_missile")
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

                    if (splitted[8].Trim() == "none")
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
                        if (STRING.Trim() == "ap")
                            Data.units[counter].secAttri |= stat_pri_attr.ap;
                        else if (STRING.Trim() == "bp")
                            Data.units[counter].secAttri |= stat_pri_attr.bp;
                        else if (STRING.Trim() == "pa_spear")
                            Data.units[counter].secAttri |= stat_pri_attr.pa_spear;
                        else if (STRING.Trim() == "long_pike")
                            Data.units[counter].secAttri |= stat_pri_attr.long_pike;
                        else if (STRING.Trim() == "short_pike")
                            Data.units[counter].secAttri |= stat_pri_attr.short_pike;
                        else if (STRING.Trim() == "prec")
                            Data.units[counter].secAttri |= stat_pri_attr.prec;
                        else if (STRING.Trim() == "pa_thrown")
                            Data.units[counter].secAttri |= stat_pri_attr.pa_thrown;
                        else if (STRING.Trim() == "launching")
                            Data.units[counter].secAttri |= stat_pri_attr.launching;
                        else if (STRING.Trim() == "area")
                            Data.units[counter].secAttri |= stat_pri_attr.area;
                        else if (STRING.Trim() == "fire")
                            Data.units[counter].secAttri |= stat_pri_attr.fire;
                        else if (STRING.Trim() == "no")
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
                    else if (splitted[2].Trim() == "ballista")
                        Data.units[counter].secondaryWeapon.missletypeFlags = MissleType.ballista;
                    else if (splitted[2].Trim() == "boulder")
                        Data.units[counter].secondaryWeapon.missletypeFlags = MissleType.onager;
                    else if (splitted[2].Trim() == "big_boulder")
                        Data.units[counter].secondaryWeapon.missletypeFlags = MissleType.heavy_onager;
                    else if (splitted[2].Trim() == "scorpion")
                        Data.units[counter].secondaryWeapon.missletypeFlags = MissleType.scorpion;
                    else if (splitted[2].Trim() == "repeating_ballista")
                        Data.units[counter].secondaryWeapon.missletypeFlags = MissleType.repeating_ballista;
                    else if (splitted[2].Trim() == "bullet")
                        Data.units[counter].secondaryWeapon.missletypeFlags = MissleType.bullet;

                    if (splitted[5].Trim() == "melee")
                        Data.units[counter].secondaryWeapon.WeaponFlags = WeaponType.melee;
                    else if (splitted[5].Trim() == "thrown")
                        Data.units[counter].secondaryWeapon.WeaponFlags = WeaponType.thrown;
                    else if (splitted[5].Trim() == "missle")
                        Data.units[counter].secondaryWeapon.WeaponFlags = WeaponType.missle;
                    else if (splitted[5].Trim() == "siege_missile")
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

                    if (splitted[8].Trim() == "none")
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

                else if (line.StartsWith("stat_heat"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    trimmed = splitted[0].TrimEnd();

                    Data.units[counter].heat = Convert.ToInt16(trimmed);

                }

                else if (line.StartsWith("stat_ground"))
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
                    else if (splitted[1].Trim() == "berserker")
                        Data.units[counter].mental.discipline = statmental_discipline.berserker;

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
                        else if (STRING.Trim() == "numidian")
                            Data.units[counter].ownership |= FactionOwnership.numidian;
                        else if (STRING.Trim() == "barbarian")
                            Data.units[counter].ownership |= FactionOwnership.barbarian;

                    }
                }
            }

            txt_Output.AppendText("\n" + Data.units.Count + "Units loaded from EDU");

            edu.Close();
        }

        public static void ParseEdb(string filepath, ref TextBox txt_Output)
        {



        }

        public static void ParseVanRegions(string filePath, ref TextBox txt_Output)
        {

            //add an output for this in the tool section

            string line;

            StreamReader reg = new StreamReader(filePath);


            int counter = -1;


            while ((line = reg.ReadLine()) != null)
            {
                if (!line.Contains("\t") && !line.Contains(";") && !line.Contains(" ") && line != "")
                {
                    counter++;
                    Data.rgbRegions.Add(new Region());
                    Data.rgbRegions[counter].name = line.Trim();


                }

                else if(line.Split(' ').Count() == 3)
                {
                    decimal num;

                    string[] split = line.Split(' ');

                    var result = Decimal.TryParse(split[0].Trim(), out num);
                    if (result)
                    {
                        Data.rgbRegions[counter].r = Convert.ToInt32(split[0].Trim());
                        Data.rgbRegions[counter].g = Convert.ToInt32(split[1].Trim());
                        Data.rgbRegions[counter].b = Convert.ToInt32(split[2].Trim());
                    }


                }
            }

            reg.Close();

            Bitmap img = new Bitmap(Data.RtwFolderPath + Data.MAPREGIONSPATH);

            img.RotateFlip(RotateFlipType.RotateNoneFlipY);
            for (int x = 0; x < img.Width; x++)
                for(int y =0; y < img.Height; y++)
                {
                    if (img.GetPixel(x, y).R == 0 && img.GetPixel(x, y).G == 0 && img.GetPixel(x, y).B == 0)
                    {
                        int tr, tg, tb;
                        tr = img.GetPixel(x, y + 1).R;
                        tg = img.GetPixel(x, y + 1).G;
                        tb = img.GetPixel(x, y + 1).B;

                        int index = Data.rgbRegions.FindIndex(z => z.r == tr && z.g == tg && z.b == tb);

                        Data.rgbRegions[index].x = x;
                        Data.rgbRegions[index].y = y;

                        Data.regionWater[x, y] = false;
                    }

                    else if (img.GetPixel(x, y).R == 41 && img.GetPixel(x, y).G == 140 && img.GetPixel(x, y).B == 233)
                    {
                        Data.regionWater[x, y] = true;
                    }

                    else Data.regionWater[x, y] = false;

                }
            

        }

        public static void ParseDscrStrat(string filepath, ref TextBox txt_Output)
        {
            string PATH = filepath;

            string line;
            string notrim;

            StreamReader strat = new StreamReader(PATH);

            //get factions
            while ((line = strat.ReadLine()) != null)
            {
                if (line.StartsWith("settlement"))
                {
                    Settlement tempSettlement;
                    List<string> b_types = new List<string>();

                    string s_level = "", region = "", faction_creator = "";

                    int yearFounded = 0, population = 100;

                    while ((line = strat.ReadLine().TrimEnd()) != "}")
                    {
                        if (line.Trim().StartsWith("level"))
                        {
                            string trimmed = Functions.RemoveFirstWord(line);
                            trimmed = trimmed.Trim();

                            s_level = trimmed;

                        }

                        else if (line.Trim().StartsWith("region"))
                        {
                            string trimmed = Functions.RemoveFirstWord(line);
                            trimmed = trimmed.Trim();

                            region = trimmed;

                        }

                        else if (line.Trim().StartsWith("year_founded"))
                        {
                            string trimmed = Functions.RemoveFirstWord(line);
                            trimmed = trimmed.Trim();

                            yearFounded = Convert.ToInt32(trimmed);

                        }

                        else if (line.Trim().StartsWith("population"))
                        {
                            string trimmed = Functions.RemoveFirstWord(line);
                            trimmed = trimmed.Trim();

                            population = Convert.ToInt32(trimmed);

                        }

                        else if (line.Trim().StartsWith("faction_creator"))
                        {
                            string trimmed = Functions.RemoveFirstWord(line);
                            trimmed = trimmed.Trim();

                            faction_creator = trimmed;

                        }

                        else if (line.Trim().StartsWith("type"))
                        {
                            string trimmed = Functions.RemoveFirstWord(line);
                            trimmed = trimmed.Trim();

                            b_types.Add(trimmed);

                        }
                    }

                    txt_Output.AppendText("\n" + "Added: " + region + "\n");
                    tempSettlement = new Settlement(s_level, region, faction_creator, b_types, yearFounded, population);
                    Data.settlements.Add(tempSettlement);


                }

                else Data.desc_StratData.Add(line);


                /* if (line.StartsWith("region"))
                 {
                     string[] split = line.Split(' ', '\t');

                     split[1].Trim();
                     int rndRegion = Data.rnd.Next(Data.VAN_REGIONS.Count());
                     split[1] = Data.regions[rndRegion];

                     Data.regions.RemoveAt(rndRegion);

                     line = split[0] + "\t" + split[1];
                 }

                 else Data.strLine.Add(line.Trim());*/




            }

            strat.Close();

        }

        //coord changes
        public static void DsCoordGet(string filepath, ref TextBox txt_Output)
        {
            string PATH = Data.ModFolderPath + Data.DESCSTRAT;

            string line;
            string notrim;

            StreamReader strat = new StreamReader(PATH);

            int counter = 0;

            while ((line = strat.ReadLine()) != null)
            {
                notrim = line;

                line = line.Trim();

                if (line.StartsWith("landmark"))
                {
                    string[] splitLand = line.Split(',', ';');

                    double x = Convert.ToInt32(splitLand[0]);
                    double y = Convert.ToInt32(splitLand[1]);

                    x = x * 1.328125;
                    y = y * 1.3290598290598290598290598290598;

                    x = Math.Round(x);
                    y = Math.Round(y);

                    splitLand[0] = x.ToString();
                    splitLand[1] = y.ToString();

                    notrim = "";

                    int i = 0;

                    foreach (string str in splitLand)
                    {
                        if(i != 2)
                            notrim += str + ", ";

                        else notrim += str + ";";

                        i++;
                    }
                }

                else if (line.StartsWith("resource"))
                {
                    string[] splitLand = line.Split(',', ';');

                    double x = Convert.ToInt32(splitLand[1]);
                    double y = Convert.ToInt32(splitLand[2]);

                    x = x * 1.328125;
                    y = y * 1.3290598290598290598290598290598;

                    x = Math.Round(x);
                    y = Math.Round(y);

                    splitLand[1] = x.ToString();
                    splitLand[2] = y.ToString();

                    notrim = "";

                    int i = 0;

                    foreach (string str in splitLand)
                    {
                        if (i != 2)
                            notrim += str + ", ";

                        else notrim += str + ";";

                        i++;
                    }
                }

                else if (line.StartsWith("character"))
                {
                    Data.chars.Add(new Character(line));

                    string[] splitted = line.Split(',');

                    string newline = "";

                    foreach (string split in splitted)
                    {
                        string part = split.Trim();

                        if (part.StartsWith("x"))
                        {
                            string[] NewSplit = part.Split(' ');

                            double x = Convert.ToInt32(NewSplit[1].Trim());

                            txt_Output.AppendText(x.ToString());

                            x = x * 1.328125;

                            x = Math.Round(x);

                            Data.chars[counter].x = (int)x;

                            txt_Output.AppendText(" ->>" + x + "\n");

                            NewSplit[1] = x.ToString();

                            newline += "x " + NewSplit[1] + ",";
                        }

                        else if (part.StartsWith("y"))
                        {
                            string[] NewSplit = part.Split(' ');

                            double y = Convert.ToInt32(NewSplit[1].Trim());

                            txt_Output.AppendText(y.ToString());

                            y = y * 1.3290598290598290598290598290598;

                            y = Math.Round(y);

                            Data.chars[counter].y = (int)y;

                            txt_Output.AppendText(" ->>" + y + "\n");

                            NewSplit[1] = y.ToString();

                            newline += "y " + NewSplit[1];
                        }

                        else newline += split + ",";
                    }

                    notrim = newline;

                    counter++;
                }

                Data.strLine.Add(notrim);
            }

            strat.Close();

            StreamWriter file = new StreamWriter(File.Open("coords.txt", FileMode.Append))
            {
                
            };

            foreach (Character chr in Data.chars)
            {
                file.Write(chr.info + chr.spacer + "x " + chr.x + ", " + "y " + chr.y + "\n"); 
            }

            file.Close();

            StreamWriter file2 = new StreamWriter(File.Open("testy.txt", FileMode.Append))
            {

            };

            foreach (string stam in Data.strLine)
            {
                file2.Write(stam + "\r\n");
            }

            file2.Close();

        }
    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using TargaImage;

namespace Randomiser
{
    public static class Parsers
    {
        public static void M2TWParseEDU(string filePath, ref TextBox txt_Output)
        {
            Data.Vanunits.Clear();

            string line;
            int counter = -1;

            StreamReader edu = new StreamReader(filePath);

            while ((line = edu.ReadLine()) != null)
            {

                string[] key = line.Split(' ', ';');

                if (line.StartsWith("type"))
                {
                    counter++;

                    Data.Vanunits.Add(new Unit());

                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    Data.Vanunits[counter].type = trimmed;

                    txt_Output.AppendText(trimmed + "\n");

                }

                else if (line.StartsWith("dictionary"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(';');

                    trimmed = splitted[0].TrimEnd();

                    Data.Vanunits[counter].dictionary = trimmed;
                }

                else if (line.StartsWith("category"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(';');

                    trimmed = splitted[0].TrimEnd();

                    Data.Vanunits[counter].category = trimmed;
                }

                else if (line.StartsWith("class"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(';');

                    trimmed = splitted[0].TrimEnd();

                    Data.Vanunits[counter].unitClass = trimmed;
                }

                else if (line.StartsWith("voice_type"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(';');

                    trimmed = splitted[0].TrimEnd();

                    Data.Vanunits[counter].voiceType = trimmed;
                }

                else if (line.StartsWith("soldier"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    Data.Vanunits[counter].soldier.name = splitted[0].Trim();
                    Data.Vanunits[counter].soldier.number = Convert.ToInt16(splitted[1].Trim());
                    Data.Vanunits[counter].soldier.extras = Convert.ToInt16(splitted[2].Trim());
                    Data.Vanunits[counter].soldier.collisionMass = (float)Convert.ToDouble(splitted[3].Trim());
                }

                else if (line.StartsWith("officer"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(';');

                    trimmed = splitted[0].TrimEnd();

                    Data.Vanunits[counter].officer.Add(trimmed);
                }

                else if (line.StartsWith("engine"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(';');

                    trimmed = splitted[0].TrimEnd();

                    Data.Vanunits[counter].engine = trimmed;
                }

                else if (line.StartsWith("animal"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(';');

                    trimmed = splitted[0].TrimEnd();

                    Data.Vanunits[counter].animal = trimmed;
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

                        Data.Vanunits[counter].mountEffect.mountType.Add(reSplit[i]);
                        i++;
                        Data.Vanunits[counter].mountEffect.modifier.Add(Convert.ToInt16(reSplit[i]));
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

                    Data.Vanunits[counter].mount = trimmed;
                }

                else if (line.StartsWith("ship"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(';');

                    trimmed = splitted[0].TrimEnd();

                    Data.Vanunits[counter].naval = trimmed;
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
                            Data.Vanunits[counter].formation.FormationTight[i] = (float)Convert.ToDouble(STRING.Trim());
                        else if (a < 2)
                        {
                            Data.Vanunits[counter].formation.FormationSparse[a] = (float)Convert.ToDouble(STRING.Trim());
                            a++;
                        }
                        else if (b < 1)
                        {
                            Data.Vanunits[counter].formation.FormationRanks = Convert.ToInt16(STRING.Trim());
                            b++;
                        }

                        else if (STRING.Trim() == "phalanx")
                            Data.Vanunits[counter].formation.FormationFlags |= FormationTypes.Formation_Phalanx;
                        else if (STRING.Trim() == "testudo")
                            Data.Vanunits[counter].formation.FormationFlags |= FormationTypes.Formation_Testudo;
                        else if (STRING.Trim() == "schiltrom")
                            Data.Vanunits[counter].formation.FormationFlags |= FormationTypes.Formation_Schiltrom;
                        else if (STRING.Trim() == "horde")
                            Data.Vanunits[counter].formation.FormationFlags |= FormationTypes.Formation_Horde;
                        else if (STRING.Trim() == "square")
                            Data.Vanunits[counter].formation.FormationFlags |= FormationTypes.Formation_Square;
                        else if (STRING.Trim() == "wedge")
                            Data.Vanunits[counter].formation.FormationFlags |= FormationTypes.Formation_Wedge;

                        i++;
                    }
                }

                else if (line.StartsWith("stat_health"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    Data.Vanunits[counter].heatlh[0] = Convert.ToInt16(splitted[0]);
                    Data.Vanunits[counter].heatlh[1] = Convert.ToInt16(splitted[1]);
                }

                else if (line.StartsWith("stat_pri_attr"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    foreach (string STRING in splitted)
                    {
                        if (STRING.Trim() == "ap")
                            Data.Vanunits[counter].priAttri |= stat_pri_attr.ap;
                        else if (STRING.Trim() == "bp")
                            Data.Vanunits[counter].priAttri |= stat_pri_attr.bp;
                        else if (STRING.Trim() == "spear")
                            Data.Vanunits[counter].priAttri |= stat_pri_attr.pa_spear;
                        else if (STRING.Trim() == "long_pike")
                            Data.Vanunits[counter].priAttri |= stat_pri_attr.long_pike;
                        else if (STRING.Trim() == "short_pike")
                            Data.Vanunits[counter].priAttri |= stat_pri_attr.short_pike;
                        else if (STRING.Trim() == "prec")
                            Data.Vanunits[counter].priAttri |= stat_pri_attr.prec;
                        else if (STRING.Trim() == "thrown")
                            Data.Vanunits[counter].priAttri |= stat_pri_attr.pa_thrown;
                        else if (STRING.Trim() == "launching")
                            Data.Vanunits[counter].priAttri |= stat_pri_attr.launching;
                        else if (STRING.Trim() == "area")
                            Data.Vanunits[counter].priAttri |= stat_pri_attr.area;
                        else if (STRING.Trim() == "spear_bonus_4")
                            Data.Vanunits[counter].priAttri |= stat_pri_attr.spear_bonus_4;
                        else if (STRING.Trim() == "spear_bonus_8")
                            Data.Vanunits[counter].priAttri |= stat_pri_attr.spear_bonus_8;
                        else if (STRING.Trim() == "thrown ap")
                            Data.Vanunits[counter].priAttri |= stat_pri_attr.thrown_ap;
                        else if (STRING.Trim() == "no")
                            Data.Vanunits[counter].priAttri |= stat_pri_attr.PA_no;
                    }

                }

                else if (line.StartsWith("stat_pri_armour"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    trimmed = splitted[0].TrimEnd();

                    Data.Vanunits[counter].primaryArmour.stat_pri_armour[0] = Convert.ToInt16(splitted[0]);
                    Data.Vanunits[counter].primaryArmour.stat_pri_armour[1] = Convert.ToInt16(splitted[1]);
                    Data.Vanunits[counter].primaryArmour.stat_pri_armour[2] = Convert.ToInt16(splitted[2]);

                    if (splitted[3].Trim() == "flesh")
                        Data.Vanunits[counter].primaryArmour.armour_sound = ArmourSound.flesh;
                    else if (splitted[3].Trim() == "leather")
                        Data.Vanunits[counter].primaryArmour.armour_sound = ArmourSound.leather;
                    else if (splitted[3].Trim() == "metal")
                        Data.Vanunits[counter].primaryArmour.armour_sound = ArmourSound.metal;

                }

                else if (line.StartsWith("stat_pri"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    trimmed = splitted[0].TrimEnd();

                    Data.Vanunits[counter].primaryWeapon.attack[0] = Convert.ToInt16(splitted[0]);
                    Data.Vanunits[counter].primaryWeapon.attack[1] = Convert.ToInt16(splitted[1]);

                    Data.Vanunits[counter].primaryWeapon.Missleattri[0] = Convert.ToInt16(splitted[3]);
                    Data.Vanunits[counter].primaryWeapon.Missleattri[1] = Convert.ToInt16(splitted[4]);

                    if (Data.isM2TWMode && splitted.Count() == 12)
                    {
                        Data.Vanunits[counter].primaryWeapon.musketString = splitted[9];
                        Data.Vanunits[counter].primaryWeapon.attackdelay[0] = (float)Convert.ToDouble(splitted[10]);
                        Data.Vanunits[counter].primaryWeapon.attackdelay[1] = (float)Convert.ToDouble(splitted[11]);
                    }
                    else
                    {
                        Data.Vanunits[counter].primaryWeapon.attackdelay[0] = (float)Convert.ToDouble(splitted[9]);
                        Data.Vanunits[counter].primaryWeapon.attackdelay[1] = (float)Convert.ToDouble(splitted[10]);
                    }


                    if (splitted[2].Trim() == "arquebus_bullet")
                        Data.Vanunits[counter].primaryWeapon.m2twammunitionflags = M2TWAmmunition.arquebus_bullet;
                    else if (splitted[2].Trim() == "stone")
                        Data.Vanunits[counter].primaryWeapon.m2twammunitionflags = M2TWAmmunition.stone;
                    else if (splitted[2].Trim() == "arrow_fiery")
                        Data.Vanunits[counter].primaryWeapon.m2twammunitionflags = M2TWAmmunition.arrow_fiery;
                    else if (splitted[2].Trim() == "arrow")
                        Data.Vanunits[counter].primaryWeapon.m2twammunitionflags = M2TWAmmunition.arrow;
                    else if (splitted[2].Trim() == "ballista")
                        Data.Vanunits[counter].primaryWeapon.m2twammunitionflags = M2TWAmmunition.ballista;
                    else if (splitted[2].Trim() == "basilisk_shot")
                        Data.Vanunits[counter].primaryWeapon.m2twammunitionflags = M2TWAmmunition.basilisk_shot;
                    else if (splitted[2].Trim() == "bodkin_arrow")
                        Data.Vanunits[counter].primaryWeapon.m2twammunitionflags = M2TWAmmunition.bodkin_arrow;
                    else if (splitted[2].Trim() == "bodkin_arrow_fiery")
                        Data.Vanunits[counter].primaryWeapon.m2twammunitionflags = M2TWAmmunition.bodkin_arrow_fiery;
                    else if (splitted[2].Trim() == "bolt")
                        Data.Vanunits[counter].primaryWeapon.m2twammunitionflags = M2TWAmmunition.bolt;
                    else if (splitted[2].Trim() == "bombard_shot")
                        Data.Vanunits[counter].primaryWeapon.m2twammunitionflags = M2TWAmmunition.bombard_shot;
                    else if (splitted[2].Trim() == "camel_gun_bullet")
                        Data.Vanunits[counter].primaryWeapon.m2twammunitionflags = M2TWAmmunition.camel_gun_bullet;
                    else if (splitted[2].Trim() == "cav_bodkin_arrow")
                        Data.Vanunits[counter].primaryWeapon.m2twammunitionflags = M2TWAmmunition.cav_bodkin_arrow;
                    else if (splitted[2].Trim() == "catapult")
                        Data.Vanunits[counter].primaryWeapon.m2twammunitionflags = M2TWAmmunition.catapult;
                    else if (splitted[2].Trim() == "cav_bodkin_arrow_fiery")
                        Data.Vanunits[counter].primaryWeapon.m2twammunitionflags = M2TWAmmunition.cav_bodkin_arrow_fiery;
                    else if (splitted[2].Trim() == "cav_composite_arrow")
                        Data.Vanunits[counter].primaryWeapon.m2twammunitionflags = M2TWAmmunition.cav_composite_arrow;
                    else if (splitted[2].Trim() == "cav_composite_arrow_fiery")
                        Data.Vanunits[counter].primaryWeapon.m2twammunitionflags = M2TWAmmunition.cav_composite_arrow_fiery;
                    else if (splitted[2].Trim() == "composite_arrow")
                        Data.Vanunits[counter].primaryWeapon.m2twammunitionflags = M2TWAmmunition.composite_arrow;
                    else if (splitted[2].Trim() == "composite_arrow_fiery")
                        Data.Vanunits[counter].primaryWeapon.m2twammunitionflags = M2TWAmmunition.composite_arrow_fiery;
                    else if (splitted[2].Trim() == "crossbow_bolt")
                        Data.Vanunits[counter].primaryWeapon.m2twammunitionflags = M2TWAmmunition.crossbow_bolt;
                    else if (splitted[2].Trim() == "cow_carcass")
                        Data.Vanunits[counter].primaryWeapon.m2twammunitionflags = M2TWAmmunition.cow_carcass;
                    else if (splitted[2].Trim() == "culverin_shot")
                        Data.Vanunits[counter].primaryWeapon.m2twammunitionflags = M2TWAmmunition.culverin_shot;
                    else if (splitted[2].Trim() == "elephant_cannon_shot")
                        Data.Vanunits[counter].primaryWeapon.m2twammunitionflags = M2TWAmmunition.elephant_cannon_shot;
                    else if (splitted[2].Trim() == "elephant_rocket")
                        Data.Vanunits[counter].primaryWeapon.m2twammunitionflags = M2TWAmmunition.elephant_rocket;
                    else if (splitted[2].Trim() == "exploding_basilisk_shot")
                        Data.Vanunits[counter].primaryWeapon.m2twammunitionflags = M2TWAmmunition.exploding_basilisk_shot;
                    else if (splitted[2].Trim() == "exploding_cannon_shot")
                        Data.Vanunits[counter].primaryWeapon.m2twammunitionflags = M2TWAmmunition.exploding_cannon_shot;
                    else if (splitted[2].Trim() == "exploding_culverin_shot")
                        Data.Vanunits[counter].primaryWeapon.m2twammunitionflags = M2TWAmmunition.exploding_culverin_shot;
                    else if (splitted[2].Trim() == "fiery_catapult")
                        Data.Vanunits[counter].primaryWeapon.m2twammunitionflags = M2TWAmmunition.fiery_catapult;
                    else if (splitted[2].Trim() == "fiery_norman_catapult")
                        Data.Vanunits[counter].primaryWeapon.m2twammunitionflags = M2TWAmmunition.fiery_norman_catapult;
                    else if (splitted[2].Trim() == "fiery_trebuchet")
                        Data.Vanunits[counter].primaryWeapon.m2twammunitionflags = M2TWAmmunition.fiery_trebuchet;
                    else if (splitted[2].Trim() == "flaming_ballista")
                        Data.Vanunits[counter].primaryWeapon.m2twammunitionflags = M2TWAmmunition.flaming_ballista;
                    else if (splitted[2].Trim() == "flaming_bombard_shot")
                        Data.Vanunits[counter].primaryWeapon.m2twammunitionflags = M2TWAmmunition.flaming_bombard_shot;
                    else if (splitted[2].Trim() == "flaming_grand_bombard_shot")
                        Data.Vanunits[counter].primaryWeapon.m2twammunitionflags = M2TWAmmunition.flaming_grand_bombard_shot;
                    else if (splitted[2].Trim() == "flaming_scorpion")
                        Data.Vanunits[counter].primaryWeapon.m2twammunitionflags = M2TWAmmunition.flaming_scorpion;
                    else if (splitted[2].Trim() == "grand_bombard_shot")
                        Data.Vanunits[counter].primaryWeapon.m2twammunitionflags = M2TWAmmunition.grand_bombard_shot;
                    else if (splitted[2].Trim() == "hand_gun_bullet")
                        Data.Vanunits[counter].primaryWeapon.m2twammunitionflags = M2TWAmmunition.hand_gun_bullet;
                    else if (splitted[2].Trim() == "javelin")
                        Data.Vanunits[counter].primaryWeapon.m2twammunitionflags = M2TWAmmunition.javelin;
                    else if (splitted[2].Trim() == "monster_bombard_shot")
                        Data.Vanunits[counter].primaryWeapon.m2twammunitionflags = M2TWAmmunition.monster_bombard_shot;
                    else if (splitted[2].Trim() == "monster_ribault_shot")
                        Data.Vanunits[counter].primaryWeapon.m2twammunitionflags = M2TWAmmunition.monster_ribault_shot;
                    else if (splitted[2].Trim() == "mortar_shot")
                        Data.Vanunits[counter].primaryWeapon.m2twammunitionflags = M2TWAmmunition.mortar_shot;
                    else if (splitted[2].Trim() == "musket_bullet")
                        Data.Vanunits[counter].primaryWeapon.m2twammunitionflags = M2TWAmmunition.musket_bullet;
                    else if (splitted[2].Trim() == "naphtha_bomb")
                        Data.Vanunits[counter].primaryWeapon.m2twammunitionflags = M2TWAmmunition.naphtha_bomb;
                    else if (splitted[2].Trim() == "no")
                        Data.Vanunits[counter].primaryWeapon.m2twammunitionflags = M2TWAmmunition.no;
                    else if (splitted[2].Trim() == "norman_catapult")
                        Data.Vanunits[counter].primaryWeapon.m2twammunitionflags = M2TWAmmunition.norman_catapult;
                    else if (splitted[2].Trim() == "pistol_bullet")
                        Data.Vanunits[counter].primaryWeapon.m2twammunitionflags = M2TWAmmunition.pistol_bullet;
                    else if (splitted[2].Trim() == "repeating_ballista")
                        Data.Vanunits[counter].primaryWeapon.m2twammunitionflags = M2TWAmmunition.repeating_ballista;
                    else if (splitted[2].Trim() == "ribault_shot")
                        Data.Vanunits[counter].primaryWeapon.m2twammunitionflags = M2TWAmmunition.ribault_shot;
                    else if (splitted[2].Trim() == "rocket")
                        Data.Vanunits[counter].primaryWeapon.m2twammunitionflags = M2TWAmmunition.rocket;
                    else if (splitted[2].Trim() == "serpentine_shot")
                        Data.Vanunits[counter].primaryWeapon.m2twammunitionflags = M2TWAmmunition.serpentine_shot;
                    else if (splitted[2].Trim() == "scorpion")
                        Data.Vanunits[counter].primaryWeapon.m2twammunitionflags = M2TWAmmunition.scorpion;
                    else if (splitted[2].Trim() == "steel_crossbow_bolt")
                        Data.Vanunits[counter].primaryWeapon.m2twammunitionflags = M2TWAmmunition.steel_crossbow_bolt;
                    else if (splitted[2].Trim() == "stone")
                        Data.Vanunits[counter].primaryWeapon.m2twammunitionflags = M2TWAmmunition.stone;
                    else if (splitted[2].Trim() == "tarred_rock")
                        Data.Vanunits[counter].primaryWeapon.m2twammunitionflags = M2TWAmmunition.tarred_rock;
                    else if (splitted[2].Trim() == "test_cannon_ball")
                        Data.Vanunits[counter].primaryWeapon.m2twammunitionflags = M2TWAmmunition.test_cannon_ball;
                    else if (splitted[2].Trim() == "tower_ballista")
                        Data.Vanunits[counter].primaryWeapon.m2twammunitionflags = M2TWAmmunition.tower_ballista;
                    else if (splitted[2].Trim() == "tower_flaming_ballista")
                        Data.Vanunits[counter].primaryWeapon.m2twammunitionflags = M2TWAmmunition.tower_flaming_ballista;
                    else if (splitted[2].Trim() == "trebuchet")
                        Data.Vanunits[counter].primaryWeapon.m2twammunitionflags = M2TWAmmunition.trebuchet;

                    if (splitted[5].Trim() == "melee")
                        Data.Vanunits[counter].primaryWeapon.WeaponFlags = WeaponType.melee;
                    else if (splitted[5].Trim() == "missle")
                        Data.Vanunits[counter].primaryWeapon.WeaponFlags = WeaponType.missle;
                    else if (splitted[5].Trim() == "siege_missile")
                        Data.Vanunits[counter].primaryWeapon.WeaponFlags = WeaponType.siege_missle;
                    else if (splitted[5].Trim() == "thrown")
                        Data.Vanunits[counter].primaryWeapon.WeaponFlags = WeaponType.thrown;
                    else if (splitted[5].Trim() == "no")
                        Data.Vanunits[counter].primaryWeapon.WeaponFlags = WeaponType.WT_no;

                    if (splitted[6].Trim() == "artillery_gunpowder")
                        Data.Vanunits[counter].primaryWeapon.m2twTechType = M2TWtechType.artillery_gunpowder;
                    else if (splitted[6].Trim() == "artillery_mechanical")
                        Data.Vanunits[counter].primaryWeapon.m2twTechType = M2TWtechType.artillery_mechanical;
                    else if (splitted[6].Trim() == "melee_blade")
                        Data.Vanunits[counter].primaryWeapon.m2twTechType = M2TWtechType.melee_blade;
                    else if (splitted[6].Trim() == "melee_simple")
                        Data.Vanunits[counter].primaryWeapon.m2twTechType = M2TWtechType.melee_simple;
                    else if (splitted[6].Trim() == "missile_gunpowder")
                        Data.Vanunits[counter].primaryWeapon.m2twTechType = M2TWtechType.missile_gunpowder;
                    else if (splitted[6].Trim() == "missile_mechanical")
                        Data.Vanunits[counter].primaryWeapon.m2twTechType = M2TWtechType.missile_mechanical;
                    else if (splitted[6].Trim() == "TT_no")
                        Data.Vanunits[counter].primaryWeapon.m2twTechType = M2TWtechType.TT_no;

                    if (splitted[7].Trim() == "piercing")
                        Data.Vanunits[counter].primaryWeapon.DamageFlags = DamageType.piercing;
                    else if (splitted[7].Trim() == "blunt")
                        Data.Vanunits[counter].primaryWeapon.DamageFlags = DamageType.blunt;
                    else if (splitted[7].Trim() == "slashing")
                        Data.Vanunits[counter].primaryWeapon.DamageFlags = DamageType.slashing;
                    else if (splitted[7].Trim() == "fire")
                        Data.Vanunits[counter].primaryWeapon.DamageFlags = DamageType.fire;
                    else if (splitted[7].Trim() == "no")
                        Data.Vanunits[counter].primaryWeapon.DamageFlags = DamageType.DM_no;

                    if (splitted[8].Trim() == "none")
                        Data.Vanunits[counter].primaryWeapon.SoundFlags = SoundType.ST_no;
                    else if (splitted[8].Trim() == "knife")
                        Data.Vanunits[counter].primaryWeapon.SoundFlags = SoundType.knife;
                    else if (splitted[8].Trim() == "mace")
                        Data.Vanunits[counter].primaryWeapon.SoundFlags = SoundType.mace;
                    else if (splitted[8].Trim() == "axe")
                        Data.Vanunits[counter].primaryWeapon.SoundFlags = SoundType.axe;
                    else if (splitted[8].Trim() == "sword")
                        Data.Vanunits[counter].primaryWeapon.SoundFlags = SoundType.sword;
                    else if (splitted[8].Trim() == "spear")
                        Data.Vanunits[counter].primaryWeapon.SoundFlags = SoundType.spear;

                }

                else if (line.StartsWith("stat_sec_attr"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    foreach (string STRING in splitted)
                    {
                        if (STRING.Trim() == "ap")
                            Data.Vanunits[counter].secAttri |= stat_pri_attr.ap;
                        else if (STRING.Trim() == "bp")
                            Data.Vanunits[counter].secAttri |= stat_pri_attr.bp;
                        else if (STRING.Trim() == "pa_spear")
                            Data.Vanunits[counter].secAttri |= stat_pri_attr.pa_spear;
                        else if (STRING.Trim() == "long_pike")
                            Data.Vanunits[counter].secAttri |= stat_pri_attr.long_pike;
                        else if (STRING.Trim() == "short_pike")
                            Data.Vanunits[counter].secAttri |= stat_pri_attr.short_pike;
                        else if (STRING.Trim() == "prec")
                            Data.Vanunits[counter].secAttri |= stat_pri_attr.prec;
                        else if (STRING.Trim() == "pa_thrown")
                            Data.Vanunits[counter].secAttri |= stat_pri_attr.pa_thrown;
                        else if (STRING.Trim() == "launching")
                            Data.Vanunits[counter].secAttri |= stat_pri_attr.launching;
                        else if (STRING.Trim() == "area")
                            Data.Vanunits[counter].secAttri |= stat_pri_attr.area;
                        else if (STRING.Trim() == "fire")
                            Data.Vanunits[counter].secAttri |= stat_pri_attr.fire;
                        else if (STRING.Trim() == "no")
                            Data.Vanunits[counter].secAttri |= stat_pri_attr.PA_no;
                    }

                }

                else if (line.StartsWith("stat_sec_armour"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    trimmed = splitted[0].TrimEnd();

                    Data.Vanunits[counter].secondaryArmour.stat_sec_armour[0] = Convert.ToInt16(splitted[0]);
                    Data.Vanunits[counter].secondaryArmour.stat_sec_armour[1] = Convert.ToInt16(splitted[1]);

                    if (splitted[2].Trim() == "flesh")
                        Data.Vanunits[counter].secondaryArmour.sec_armour_sound = ArmourSound.flesh;
                    else if (splitted[2].Trim() == "leather")
                        Data.Vanunits[counter].secondaryArmour.sec_armour_sound = ArmourSound.leather;
                    else if (splitted[2].Trim() == "metal")
                        Data.Vanunits[counter].secondaryArmour.sec_armour_sound = ArmourSound.metal;

                }

                else if (line.StartsWith("stat_sec"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    trimmed = splitted[0].TrimEnd();

                    Data.Vanunits[counter].secondaryWeapon.attack[0] = Convert.ToInt16(splitted[0]);
                    Data.Vanunits[counter].secondaryWeapon.attack[1] = Convert.ToInt16(splitted[1]);

                    Data.Vanunits[counter].secondaryWeapon.Missleattri[0] = Convert.ToInt16(splitted[3]);
                    Data.Vanunits[counter].secondaryWeapon.Missleattri[1] = Convert.ToInt16(splitted[4]);

                    if (Data.isM2TWMode && splitted.Count() == 12)
                    {
                        Data.Vanunits[counter].secondaryWeapon.musketString = splitted[9];
                        Data.Vanunits[counter].secondaryWeapon.attackdelay[0] = (float)Convert.ToDouble(splitted[10]);
                        Data.Vanunits[counter].secondaryWeapon.attackdelay[1] = (float)Convert.ToDouble(splitted[11]);
                    }
                    else
                    {
                        Data.Vanunits[counter].secondaryWeapon.attackdelay[0] = (float)Convert.ToDouble(splitted[9]);
                        Data.Vanunits[counter].secondaryWeapon.attackdelay[1] = (float)Convert.ToDouble(splitted[10]);
                    }


                    if (splitted[2].Trim() == "arquebus_bullet")
                        Data.Vanunits[counter].secondaryWeapon.m2twammunitionflags = M2TWAmmunition.arquebus_bullet;
                    else if (splitted[2].Trim() == "stone")
                        Data.Vanunits[counter].secondaryWeapon.m2twammunitionflags = M2TWAmmunition.stone;
                    else if (splitted[2].Trim() == "arrow_fiery")
                        Data.Vanunits[counter].secondaryWeapon.m2twammunitionflags = M2TWAmmunition.arrow_fiery;
                    else if (splitted[2].Trim() == "arrow")
                        Data.Vanunits[counter].secondaryWeapon.m2twammunitionflags = M2TWAmmunition.arrow;
                    else if (splitted[2].Trim() == "ballista")
                        Data.Vanunits[counter].secondaryWeapon.m2twammunitionflags = M2TWAmmunition.ballista;
                    else if (splitted[2].Trim() == "basilisk_shot")
                        Data.Vanunits[counter].secondaryWeapon.m2twammunitionflags = M2TWAmmunition.basilisk_shot;
                    else if (splitted[2].Trim() == "bodkin_arrow")
                        Data.Vanunits[counter].secondaryWeapon.m2twammunitionflags = M2TWAmmunition.bodkin_arrow;
                    else if (splitted[2].Trim() == "bodkin_arrow_fiery")
                        Data.Vanunits[counter].secondaryWeapon.m2twammunitionflags = M2TWAmmunition.bodkin_arrow_fiery;
                    else if (splitted[2].Trim() == "bolt")
                        Data.Vanunits[counter].secondaryWeapon.m2twammunitionflags = M2TWAmmunition.bolt;
                    else if (splitted[2].Trim() == "bombard_shot")
                        Data.Vanunits[counter].secondaryWeapon.m2twammunitionflags = M2TWAmmunition.bombard_shot;
                    else if (splitted[2].Trim() == "camel_gun_bullet")
                        Data.Vanunits[counter].secondaryWeapon.m2twammunitionflags = M2TWAmmunition.camel_gun_bullet;
                    else if (splitted[2].Trim() == "cav_bodkin_arrow")
                        Data.Vanunits[counter].secondaryWeapon.m2twammunitionflags = M2TWAmmunition.cav_bodkin_arrow;
                    else if (splitted[2].Trim() == "catapult")
                        Data.Vanunits[counter].secondaryWeapon.m2twammunitionflags = M2TWAmmunition.catapult;
                    else if (splitted[2].Trim() == "cav_bodkin_arrow_fiery")
                        Data.Vanunits[counter].secondaryWeapon.m2twammunitionflags = M2TWAmmunition.cav_bodkin_arrow_fiery;
                    else if (splitted[2].Trim() == "cav_composite_arrow")
                        Data.Vanunits[counter].secondaryWeapon.m2twammunitionflags = M2TWAmmunition.cav_composite_arrow;
                    else if (splitted[2].Trim() == "cav_composite_arrow_fiery")
                        Data.Vanunits[counter].secondaryWeapon.m2twammunitionflags = M2TWAmmunition.cav_composite_arrow_fiery;
                    else if (splitted[2].Trim() == "composite_arrow")
                        Data.Vanunits[counter].secondaryWeapon.m2twammunitionflags = M2TWAmmunition.composite_arrow;
                    else if (splitted[2].Trim() == "composite_arrow_fiery")
                        Data.Vanunits[counter].secondaryWeapon.m2twammunitionflags = M2TWAmmunition.composite_arrow_fiery;
                    else if (splitted[2].Trim() == "crossbow_bolt")
                        Data.Vanunits[counter].secondaryWeapon.m2twammunitionflags = M2TWAmmunition.crossbow_bolt;
                    else if (splitted[2].Trim() == "cow_carcass")
                        Data.Vanunits[counter].secondaryWeapon.m2twammunitionflags = M2TWAmmunition.cow_carcass;
                    else if (splitted[2].Trim() == "culverin_shot")
                        Data.Vanunits[counter].secondaryWeapon.m2twammunitionflags = M2TWAmmunition.culverin_shot;
                    else if (splitted[2].Trim() == "elephant_cannon_shot")
                        Data.Vanunits[counter].secondaryWeapon.m2twammunitionflags = M2TWAmmunition.elephant_cannon_shot;
                    else if (splitted[2].Trim() == "elephant_rocket")
                        Data.Vanunits[counter].secondaryWeapon.m2twammunitionflags = M2TWAmmunition.elephant_rocket;
                    else if (splitted[2].Trim() == "exploding_basilisk_shot")
                        Data.Vanunits[counter].secondaryWeapon.m2twammunitionflags = M2TWAmmunition.exploding_basilisk_shot;
                    else if (splitted[2].Trim() == "exploding_cannon_shot")
                        Data.Vanunits[counter].secondaryWeapon.m2twammunitionflags = M2TWAmmunition.exploding_cannon_shot;
                    else if (splitted[2].Trim() == "exploding_culverin_shot")
                        Data.Vanunits[counter].secondaryWeapon.m2twammunitionflags = M2TWAmmunition.exploding_culverin_shot;
                    else if (splitted[2].Trim() == "fiery_catapult")
                        Data.Vanunits[counter].secondaryWeapon.m2twammunitionflags = M2TWAmmunition.fiery_catapult;
                    else if (splitted[2].Trim() == "fiery_norman_catapult")
                        Data.Vanunits[counter].secondaryWeapon.m2twammunitionflags = M2TWAmmunition.fiery_norman_catapult;
                    else if (splitted[2].Trim() == "fiery_trebuchet")
                        Data.Vanunits[counter].secondaryWeapon.m2twammunitionflags = M2TWAmmunition.fiery_trebuchet;
                    else if (splitted[2].Trim() == "flaming_ballista")
                        Data.Vanunits[counter].secondaryWeapon.m2twammunitionflags = M2TWAmmunition.flaming_ballista;
                    else if (splitted[2].Trim() == "flaming_bombard_shot")
                        Data.Vanunits[counter].secondaryWeapon.m2twammunitionflags = M2TWAmmunition.flaming_bombard_shot;
                    else if (splitted[2].Trim() == "flaming_grand_bombard_shot")
                        Data.Vanunits[counter].secondaryWeapon.m2twammunitionflags = M2TWAmmunition.flaming_grand_bombard_shot;
                    else if (splitted[2].Trim() == "flaming_scorpion")
                        Data.Vanunits[counter].secondaryWeapon.m2twammunitionflags = M2TWAmmunition.flaming_scorpion;
                    else if (splitted[2].Trim() == "grand_bombard_shot")
                        Data.Vanunits[counter].secondaryWeapon.m2twammunitionflags = M2TWAmmunition.grand_bombard_shot;
                    else if (splitted[2].Trim() == "hand_gun_bullet")
                        Data.Vanunits[counter].secondaryWeapon.m2twammunitionflags = M2TWAmmunition.hand_gun_bullet;
                    else if (splitted[2].Trim() == "javelin")
                        Data.Vanunits[counter].secondaryWeapon.m2twammunitionflags = M2TWAmmunition.javelin;
                    else if (splitted[2].Trim() == "monster_bombard_shot")
                        Data.Vanunits[counter].secondaryWeapon.m2twammunitionflags = M2TWAmmunition.monster_bombard_shot;
                    else if (splitted[2].Trim() == "monster_ribault_shot")
                        Data.Vanunits[counter].secondaryWeapon.m2twammunitionflags = M2TWAmmunition.monster_ribault_shot;
                    else if (splitted[2].Trim() == "mortar_shot")
                        Data.Vanunits[counter].secondaryWeapon.m2twammunitionflags = M2TWAmmunition.mortar_shot;
                    else if (splitted[2].Trim() == "musket_bullet")
                        Data.Vanunits[counter].secondaryWeapon.m2twammunitionflags = M2TWAmmunition.musket_bullet;
                    else if (splitted[2].Trim() == "naphtha_bomb")
                        Data.Vanunits[counter].secondaryWeapon.m2twammunitionflags = M2TWAmmunition.naphtha_bomb;
                    else if (splitted[2].Trim() == "no")
                        Data.Vanunits[counter].secondaryWeapon.m2twammunitionflags = M2TWAmmunition.no;
                    else if (splitted[2].Trim() == "norman_catapult")
                        Data.Vanunits[counter].secondaryWeapon.m2twammunitionflags = M2TWAmmunition.norman_catapult;
                    else if (splitted[2].Trim() == "pistol_bullet")
                        Data.Vanunits[counter].secondaryWeapon.m2twammunitionflags = M2TWAmmunition.pistol_bullet;
                    else if (splitted[2].Trim() == "repeating_ballista")
                        Data.Vanunits[counter].secondaryWeapon.m2twammunitionflags = M2TWAmmunition.repeating_ballista;
                    else if (splitted[2].Trim() == "ribault_shot")
                        Data.Vanunits[counter].secondaryWeapon.m2twammunitionflags = M2TWAmmunition.ribault_shot;
                    else if (splitted[2].Trim() == "rocket")
                        Data.Vanunits[counter].secondaryWeapon.m2twammunitionflags = M2TWAmmunition.rocket;
                    else if (splitted[2].Trim() == "serpentine_shot")
                        Data.Vanunits[counter].secondaryWeapon.m2twammunitionflags = M2TWAmmunition.serpentine_shot;
                    else if (splitted[2].Trim() == "scorpion")
                        Data.Vanunits[counter].secondaryWeapon.m2twammunitionflags = M2TWAmmunition.scorpion;
                    else if (splitted[2].Trim() == "steel_crossbow_bolt")
                        Data.Vanunits[counter].secondaryWeapon.m2twammunitionflags = M2TWAmmunition.steel_crossbow_bolt;
                    else if (splitted[2].Trim() == "stone")
                        Data.Vanunits[counter].secondaryWeapon.m2twammunitionflags = M2TWAmmunition.stone;
                    else if (splitted[2].Trim() == "tarred_rock")
                        Data.Vanunits[counter].secondaryWeapon.m2twammunitionflags = M2TWAmmunition.tarred_rock;
                    else if (splitted[2].Trim() == "test_cannon_ball")
                        Data.Vanunits[counter].secondaryWeapon.m2twammunitionflags = M2TWAmmunition.test_cannon_ball;
                    else if (splitted[2].Trim() == "tower_ballista")
                        Data.Vanunits[counter].secondaryWeapon.m2twammunitionflags = M2TWAmmunition.tower_ballista;
                    else if (splitted[2].Trim() == "tower_flaming_ballista")
                        Data.Vanunits[counter].secondaryWeapon.m2twammunitionflags = M2TWAmmunition.tower_flaming_ballista;
                    else if (splitted[2].Trim() == "trebuchet")
                        Data.Vanunits[counter].secondaryWeapon.m2twammunitionflags = M2TWAmmunition.trebuchet;

                    if (splitted[5].Trim() == "melee")
                        Data.Vanunits[counter].secondaryWeapon.WeaponFlags = WeaponType.melee;
                    else if (splitted[5].Trim() == "missle")
                        Data.Vanunits[counter].secondaryWeapon.WeaponFlags = WeaponType.missle;
                    else if (splitted[5].Trim() == "siege_missile")
                        Data.Vanunits[counter].secondaryWeapon.WeaponFlags = WeaponType.siege_missle;
                    else if (splitted[5].Trim() == "thrown")
                        Data.Vanunits[counter].secondaryWeapon.WeaponFlags = WeaponType.thrown;
                    else if (splitted[5].Trim() == "no")
                        Data.Vanunits[counter].secondaryWeapon.WeaponFlags = WeaponType.WT_no;

                    if (splitted[6].Trim() == "artillery_gunpowder")
                        Data.Vanunits[counter].secondaryWeapon.m2twTechType = M2TWtechType.artillery_gunpowder;
                    else if (splitted[6].Trim() == "artillery_mechanical")
                        Data.Vanunits[counter].secondaryWeapon.m2twTechType = M2TWtechType.artillery_mechanical;
                    else if (splitted[6].Trim() == "melee_blade")
                        Data.Vanunits[counter].secondaryWeapon.m2twTechType = M2TWtechType.melee_blade;
                    else if (splitted[6].Trim() == "melee_simple")
                        Data.Vanunits[counter].secondaryWeapon.m2twTechType = M2TWtechType.melee_simple;
                    else if (splitted[6].Trim() == "missile_gunpowder")
                        Data.Vanunits[counter].secondaryWeapon.m2twTechType = M2TWtechType.missile_gunpowder;
                    else if (splitted[6].Trim() == "missile_mechanical")
                        Data.Vanunits[counter].secondaryWeapon.m2twTechType = M2TWtechType.missile_mechanical;
                    else if (splitted[6].Trim() == "TT_no")
                        Data.Vanunits[counter].secondaryWeapon.m2twTechType = M2TWtechType.TT_no;

                    if (splitted[7].Trim() == "piercing")
                        Data.Vanunits[counter].secondaryWeapon.DamageFlags = DamageType.piercing;
                    else if (splitted[7].Trim() == "blunt")
                        Data.Vanunits[counter].secondaryWeapon.DamageFlags = DamageType.blunt;
                    else if (splitted[7].Trim() == "slashing")
                        Data.Vanunits[counter].secondaryWeapon.DamageFlags = DamageType.slashing;
                    else if (splitted[7].Trim() == "fire")
                        Data.Vanunits[counter].secondaryWeapon.DamageFlags = DamageType.fire;
                    else if (splitted[7].Trim() == "no")
                        Data.Vanunits[counter].secondaryWeapon.DamageFlags = DamageType.DM_no;

                    if (splitted[8].Trim() == "none")
                        Data.Vanunits[counter].secondaryWeapon.SoundFlags = SoundType.ST_no;
                    else if (splitted[8].Trim() == "knife")
                        Data.Vanunits[counter].secondaryWeapon.SoundFlags = SoundType.knife;
                    else if (splitted[8].Trim() == "mace")
                        Data.Vanunits[counter].secondaryWeapon.SoundFlags = SoundType.mace;
                    else if (splitted[8].Trim() == "axe")
                        Data.Vanunits[counter].secondaryWeapon.SoundFlags = SoundType.axe;
                    else if (splitted[8].Trim() == "sword")
                        Data.Vanunits[counter].secondaryWeapon.SoundFlags = SoundType.sword;
                    else if (splitted[8].Trim() == "spear")
                        Data.Vanunits[counter].secondaryWeapon.SoundFlags = SoundType.spear;

                }

                else if (line.StartsWith("stat_heat"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    trimmed = splitted[0].TrimEnd();

                    Data.Vanunits[counter].heat = Convert.ToInt16(trimmed);

                }

                else if (line.StartsWith("stat_ground"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    trimmed = splitted[0].TrimEnd();

                    Data.Vanunits[counter].ground[0] = Convert.ToInt16(splitted[0]);
                    Data.Vanunits[counter].ground[1] = Convert.ToInt16(splitted[1]);
                    Data.Vanunits[counter].ground[2] = Convert.ToInt16(splitted[2]);
                    Data.Vanunits[counter].ground[3] = Convert.ToInt16(splitted[3]);

                }

                else if (line.StartsWith("stat_mental"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    trimmed = splitted[0].TrimEnd();

                    Data.Vanunits[counter].mental.morale = Convert.ToInt16(splitted[0]);

                    if (splitted[1].Trim() == "normal")
                        Data.Vanunits[counter].mental.discipline = statmental_discipline.normal;
                    else if (splitted[1].Trim() == "low")
                        Data.Vanunits[counter].mental.discipline = statmental_discipline.low;
                    else if (splitted[1].Trim() == "disciplined")
                        Data.Vanunits[counter].mental.discipline = statmental_discipline.disciplined;
                    else if (splitted[1].Trim() == "impetuous")
                        Data.Vanunits[counter].mental.discipline = statmental_discipline.impetuous;
                    else if (splitted[1].Trim() == "berserker")
                        Data.Vanunits[counter].mental.discipline = statmental_discipline.berserker;

                    if (splitted[2].Trim() == "untrained")
                        Data.Vanunits[counter].mental.training = statmental_training.untrained;
                    else if (splitted[2].Trim() == "trained")
                        Data.Vanunits[counter].mental.training = statmental_training.trained;
                    else if (splitted[2].Trim() == "highly_trained")
                        Data.Vanunits[counter].mental.training = statmental_training.highly_trained;
                }

                else if (line.StartsWith("stat_charge_dist"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    trimmed = splitted[0].TrimEnd();

                    Data.Vanunits[counter].chargeDistance = Convert.ToInt16(trimmed);

                }

                else if (line.StartsWith("stat_fire_delay"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    trimmed = splitted[0].TrimEnd();

                    Data.Vanunits[counter].fireDelay = Convert.ToInt16(trimmed);

                }

                else if (line.StartsWith("stat_food"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    trimmed = splitted[0].TrimEnd();

                    Data.Vanunits[counter].food[0] = Convert.ToInt16(splitted[0]);
                    Data.Vanunits[counter].food[1] = Convert.ToInt16(splitted[1]);

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
                        if (Data.isRTWMode)
                            Data.Vanunits[counter].cost[i] = Convert.ToInt16(STRING);
                        else if (Data.isM2TWMode)
                            Data.Vanunits[counter].M2TWcost[i] = Convert.ToInt16(STRING);
                        i++;
                    }

                }

                else if (line.StartsWith("ownership") && Data.isM2TWMode)
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    trimmed = splitted[0].TrimEnd();

                    foreach (string STRING in splitted)
                    {
                        if (STRING.Trim() == "aztecs")
                            Data.Vanunits[counter].M2TWOwnership |= M2TWFactionOwnership.aztecs;
                        else if (STRING.Trim() == "byzantium")
                            Data.Vanunits[counter].M2TWOwnership |= M2TWFactionOwnership.byzantium;
                        else if (STRING.Trim() == "denmark")
                            Data.Vanunits[counter].M2TWOwnership |= M2TWFactionOwnership.denmark;
                        else if (STRING.Trim() == "eastern_european")
                            Data.Vanunits[counter].M2TWOwnership |= M2TWFactionOwnership.eastern_european;
                        else if (STRING.Trim() == "egypt")
                            Data.Vanunits[counter].M2TWOwnership |= M2TWFactionOwnership.egypt;
                        else if (STRING.Trim() == "england")
                            Data.Vanunits[counter].M2TWOwnership |= M2TWFactionOwnership.england;
                        else if (STRING.Trim() == "france")
                            Data.Vanunits[counter].M2TWOwnership |= M2TWFactionOwnership.france;
                        else if (STRING.Trim() == "greek")
                            Data.Vanunits[counter].M2TWOwnership |= M2TWFactionOwnership.greek;
                        else if (STRING.Trim() == "hre")
                            Data.Vanunits[counter].M2TWOwnership |= M2TWFactionOwnership.hre;
                        else if (STRING.Trim() == "hungary")
                            Data.Vanunits[counter].M2TWOwnership |= M2TWFactionOwnership.hungary;
                        else if (STRING.Trim() == "middle_eastern")
                            Data.Vanunits[counter].M2TWOwnership |= M2TWFactionOwnership.middle_eastern;
                        else if (STRING.Trim() == "milan")
                            Data.Vanunits[counter].M2TWOwnership |= M2TWFactionOwnership.milan;
                        else if (STRING.Trim() == "mongols")
                            Data.Vanunits[counter].M2TWOwnership |= M2TWFactionOwnership.mongols;
                        else if (STRING.Trim() == "moors")
                            Data.Vanunits[counter].M2TWOwnership |= M2TWFactionOwnership.moors;
                        else if (STRING.Trim() == "normans")
                            Data.Vanunits[counter].M2TWOwnership |= M2TWFactionOwnership.normans;
                        else if (STRING.Trim() == "northern_european")
                            Data.Vanunits[counter].M2TWOwnership |= M2TWFactionOwnership.northern_european;
                        else if (STRING.Trim() == "papal_states")
                            Data.Vanunits[counter].M2TWOwnership |= M2TWFactionOwnership.papal_states;
                        else if (STRING.Trim() == "poland")
                            Data.Vanunits[counter].M2TWOwnership |= M2TWFactionOwnership.poland;
                        else if (STRING.Trim() == "portugal")
                            Data.Vanunits[counter].M2TWOwnership |= M2TWFactionOwnership.portugal;
                        else if (STRING.Trim() == "russia")
                            Data.Vanunits[counter].M2TWOwnership |= M2TWFactionOwnership.russia;
                        else if (STRING.Trim() == "saxons")
                            Data.Vanunits[counter].M2TWOwnership |= M2TWFactionOwnership.saxons;
                        else if (STRING.Trim() == "scotland")
                            Data.Vanunits[counter].M2TWOwnership |= M2TWFactionOwnership.scotland;
                        else if (STRING.Trim() == "sicily")
                            Data.Vanunits[counter].M2TWOwnership |= M2TWFactionOwnership.sicily;
                        else if (STRING.Trim() == "slave")
                            Data.Vanunits[counter].M2TWOwnership |= M2TWFactionOwnership.slave;
                        else if (STRING.Trim() == "southern_european")
                            Data.Vanunits[counter].M2TWOwnership |= M2TWFactionOwnership.southern_european;
                        else if (STRING.Trim() == "spain")
                            Data.Vanunits[counter].M2TWOwnership |= M2TWFactionOwnership.spain;
                        else if (STRING.Trim() == "timurids")
                            Data.Vanunits[counter].M2TWOwnership |= M2TWFactionOwnership.timurids;
                        else if (STRING.Trim() == "turks")
                            Data.Vanunits[counter].M2TWOwnership |= M2TWFactionOwnership.turks;
                        else if (STRING.Trim() == "venice")
                            Data.Vanunits[counter].M2TWOwnership |= M2TWFactionOwnership.venice;

                    }

                }

                else if (line.StartsWith("attributes") && Data.isM2TWMode)
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    foreach (string STRING in splitted)
                    {
                        trimmed = STRING.Trim();

                        if (trimmed == "sea_faring")
                            Data.Vanunits[counter].M2TWAttributes |= M2TWAttributes.sea_faring;
                        else if (trimmed == "hide_forest")
                            Data.Vanunits[counter].M2TWAttributes |= M2TWAttributes.hide_forest;
                        else if (trimmed == "hide_improved_forest")
                            Data.Vanunits[counter].M2TWAttributes |= M2TWAttributes.hide_improved_forest;
                        else if (trimmed == "hide_long_grass")
                            Data.Vanunits[counter].M2TWAttributes |= M2TWAttributes.hide_long_grass;
                        else if (trimmed == "hide_anywhere")
                            Data.Vanunits[counter].M2TWAttributes |= M2TWAttributes.hide_anywhere;
                        else if (trimmed == "can_sap")
                            Data.Vanunits[counter].M2TWAttributes |= M2TWAttributes.can_sap;
                        else if (trimmed == "frighten_foot")
                            Data.Vanunits[counter].M2TWAttributes |= M2TWAttributes.frighten_foot;
                        else if (trimmed == "frighten_mounted")
                            Data.Vanunits[counter].M2TWAttributes |= M2TWAttributes.frighten_mounted;
                        else if (trimmed == "can_run_amok")
                            Data.Vanunits[counter].M2TWAttributes |= M2TWAttributes.can_run_amok;
                        else if (trimmed == "general_unit")
                            Data.Vanunits[counter].M2TWAttributes |= M2TWAttributes.general_unit;
                        else if (trimmed == "general_unit_upgrade")
                            Data.Vanunits[counter].M2TWAttributes |= M2TWAttributes.general_unit_upgrade;
                        else if (trimmed == "cantabrian_circle")
                            Data.Vanunits[counter].M2TWAttributes |= M2TWAttributes.cantabrian_circle;
                        else if (trimmed == "no_custom")
                            Data.Vanunits[counter].M2TWAttributes |= M2TWAttributes.no_custom;
                        else if (trimmed == "command")
                            Data.Vanunits[counter].M2TWAttributes |= M2TWAttributes.command;
                        else if (trimmed == "mercenary_unit")
                            Data.Vanunits[counter].M2TWAttributes |= M2TWAttributes.mercenary_unit;
                        else if (trimmed == "druid")
                            Data.Vanunits[counter].M2TWAttributes |= M2TWAttributes.druid;
                        else if (trimmed == "warcry")
                            Data.Vanunits[counter].M2TWAttributes |= M2TWAttributes.warcry;
                        else if (trimmed == "warcry")
                            Data.Vanunits[counter].M2TWAttributes |= M2TWAttributes.warcry;
                        else if (trimmed == "free_upkeep_unit")
                            Data.Vanunits[counter].M2TWAttributes |= M2TWAttributes.free_upkeep_unit;
                    }

                }

                else if (line.StartsWith("stat_pri_ex") && Data.isM2TWMode)
                {
                    Data.Vanunits[counter].stat_pri_ex = Functions.RemoveFirstWord(line.Trim()).Trim();

                }
                else if (Functions.GetFirstWord(line.Trim()) == "stat_ter" && Data.isM2TWMode)
                {
                    Data.Vanunits[counter].stat_ter = Functions.RemoveFirstWord(line.Trim()).Trim();

                }

                else if (Functions.GetFirstWord(line.Trim()) == "stat_ter_ex" && Data.isM2TWMode)
                {
                    Data.Vanunits[counter].stat_ter_ex = Functions.RemoveFirstWord(line.Trim()).Trim();

                }

                else if (Functions.GetFirstWord(line.Trim()) == "stat_ter_attr" && Data.isM2TWMode)
                {
                    Data.Vanunits[counter].stat_ter_attr = Functions.RemoveFirstWord(line.Trim()).Trim();

                }

                else if (line.StartsWith("stat_armour_ex") && Data.isM2TWMode)
                {
                    Data.Vanunits[counter].stat_armour_ex = Functions.RemoveFirstWord(line.Trim()).Trim();

                }

                else if (line.StartsWith("banner faction") && Data.isM2TWMode)
                {
                    string firstRemove = Functions.RemoveFirstWord(line.Trim()).Trim();
                    string secondRemove = Functions.RemoveFirstWord(firstRemove);
                    Data.Vanunits[counter].bannerFaction = secondRemove.Trim();

                }

                else if (line.StartsWith("banner holy") && Data.isM2TWMode)
                {
                    string firstRemove = Functions.RemoveFirstWord(line.Trim()).Trim();
                    string secondRemove = Functions.RemoveFirstWord(firstRemove);
                    Data.Vanunits[counter].bannerFaction = secondRemove.Trim();

                }

                else if (line.StartsWith("stat_sec_ex") && Data.isM2TWMode)
                {

                    Data.Vanunits[counter].stat_sec_ex = Functions.RemoveFirstWord(line.Trim()).Trim();

                }

                else if (line.StartsWith("stat_stl") && Data.isM2TWMode)
                {

                    Data.Vanunits[counter].stat_stl = Functions.RemoveFirstWord(line.Trim()).Trim();

                }
                else if (line.StartsWith("armour_ug_levels") && Data.isM2TWMode)
                {

                    Data.Vanunits[counter].armour_ug_levels = Functions.RemoveFirstWord(line.Trim()).Trim();

                }

                else if (line.StartsWith("armour_ug_models") && Data.isM2TWMode)
                {

                    Data.Vanunits[counter].armour_ug_models = Functions.RemoveFirstWord(line.Trim()).Trim();

                }

                else if (line.StartsWith("era0") && Data.isM2TWMode)
                {
                    string firstWordRemoved = Functions.RemoveFirstWord(line.Trim()).Trim();
                    Data.Vanunits[counter].era0 = Functions.RemoveFirstWord(firstWordRemoved);

                }

                else if (line.StartsWith("era1") && Data.isM2TWMode)
                {

                    string firstWordRemoved = Functions.RemoveFirstWord(line.Trim()).Trim();
                    Data.Vanunits[counter].era1 = Functions.RemoveFirstWord(firstWordRemoved);

                }
                else if (line.StartsWith("era2") && Data.isM2TWMode)
                {

                    string firstWordRemoved = Functions.RemoveFirstWord(line.Trim()).Trim();
                    Data.Vanunits[counter].era2 = Functions.RemoveFirstWord(firstWordRemoved);

                }

                else if (line.StartsWith("info_pic_dir") && Data.isM2TWMode)
                {

                    Data.Vanunits[counter].info_pic_dir = Functions.RemoveFirstWord(line.Trim()).Trim();

                }

                else if (line.StartsWith("card_pic_info") && Data.isM2TWMode)
                {

                    Data.Vanunits[counter].card_pic_info = Functions.RemoveFirstWord(line.Trim()).Trim();

                }

                else if (line.StartsWith("unit_info") && Data.isM2TWMode)
                {

                    Data.Vanunits[counter].unit_info = Functions.RemoveFirstWord(line.Trim()).Trim();

                }
            }

            txt_Output.AppendText("\n" + Data.Vanunits.Count + "Units loaded from EDU");

            edu.Close();

        }

        public static void ParseEdu(string filePath, ref TextBox txt_Output)
        {
            Data.Vanunits.Clear();

            string line;
            int counter = -1;

            StreamReader edu = new StreamReader(filePath);

            while ((line = edu.ReadLine()) != null)
            {

                string[] key = line.Split(' ', ';');

                if (line.StartsWith("type"))
                {
                    counter++;

                    Data.Vanunits.Add(new Unit());

                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    Data.Vanunits[counter].type = trimmed;

                    txt_Output.AppendText(trimmed + "\n");

                }

                else if (line.StartsWith("dictionary"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(';');

                    trimmed = splitted[0].TrimEnd();

                    Data.Vanunits[counter].dictionary = trimmed;
                }

                else if (line.StartsWith("category"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(';');

                    trimmed = splitted[0].TrimEnd();

                    Data.Vanunits[counter].category = trimmed;
                }

                else if (line.StartsWith("class"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(';');

                    trimmed = splitted[0].TrimEnd();

                    Data.Vanunits[counter].unitClass = trimmed;
                }

                else if (line.StartsWith("voice_type"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(';');

                    trimmed = splitted[0].TrimEnd();

                    Data.Vanunits[counter].voiceType = trimmed;
                }

                else if (line.StartsWith("soldier"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    Data.Vanunits[counter].soldier.name = splitted[0].Trim();
                    Data.Vanunits[counter].soldier.number = Convert.ToInt16(splitted[1].Trim());
                    Data.Vanunits[counter].soldier.extras = Convert.ToInt16(splitted[2].Trim());
                    Data.Vanunits[counter].soldier.collisionMass = (float)Convert.ToDouble(splitted[3].Trim());
                }

                else if (line.StartsWith("officer"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(';');

                    trimmed = splitted[0].TrimEnd();

                    Data.Vanunits[counter].officer.Add(trimmed);
                }

                else if (line.StartsWith("engine"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(';');

                    trimmed = splitted[0].TrimEnd();

                    Data.Vanunits[counter].engine = trimmed;
                }

                else if (line.StartsWith("animal"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(';');

                    trimmed = splitted[0].TrimEnd();

                    Data.Vanunits[counter].animal = trimmed;
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

                        Data.Vanunits[counter].mountEffect.mountType.Add(reSplit[i]);
                        i++;
                        Data.Vanunits[counter].mountEffect.modifier.Add(Convert.ToInt16(reSplit[i]));
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

                    Data.Vanunits[counter].mount = trimmed;
                }

                else if (line.StartsWith("ship"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(';');

                    trimmed = splitted[0].TrimEnd();

                    Data.Vanunits[counter].naval = trimmed;
                }


                else if (line.StartsWith("attributes") && Data.isRTWMode)
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    foreach (string STRING in splitted)
                    {
                        trimmed = STRING.Trim();

                        if (trimmed == "sea_faring")
                            Data.Vanunits[counter].attributes |= Attributes.sea_faring;
                        else if (trimmed == "hide_forest")
                            Data.Vanunits[counter].attributes |= Attributes.hide_forest;
                        else if (trimmed == "hide_improved_forest")
                            Data.Vanunits[counter].attributes |= Attributes.hide_improved_forest;
                        else if (trimmed == "hide_long_grass")
                            Data.Vanunits[counter].attributes |= Attributes.hide_long_grass;
                        else if (trimmed == "hide_anywhere")
                            Data.Vanunits[counter].attributes |= Attributes.hide_anywhere;
                        else if (trimmed == "can_sap")
                            Data.Vanunits[counter].attributes |= Attributes.can_sap;
                        else if (trimmed == "frighten_foot")
                            Data.Vanunits[counter].attributes |= Attributes.frighten_foot;
                        else if (trimmed == "frighten_mounted")
                            Data.Vanunits[counter].attributes |= Attributes.frighten_mounted;
                        else if (trimmed == "can_run_amok")
                            Data.Vanunits[counter].attributes |= Attributes.can_run_amok;
                        else if (trimmed == "general_unit")
                            Data.Vanunits[counter].attributes |= Attributes.general_unit;
                        else if (trimmed == "general_unit_upgrade")
                            Data.Vanunits[counter].attributes |= Attributes.general_unit_upgrade;
                        else if (trimmed == "cantabrian_circle")
                            Data.Vanunits[counter].attributes |= Attributes.cantabrian_circle;
                        else if (trimmed == "no_custom")
                            Data.Vanunits[counter].attributes |= Attributes.no_custom;
                        else if (trimmed == "command")
                            Data.Vanunits[counter].attributes |= Attributes.command;
                        else if (trimmed == "mercenary_unit")
                            Data.Vanunits[counter].attributes |= Attributes.mercenary_unit;
                        else if (trimmed == "druid")
                            Data.Vanunits[counter].attributes |= Attributes.druid;
                        else if (trimmed == "warcry")
                            Data.Vanunits[counter].attributes |= Attributes.warcry;

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
                            Data.Vanunits[counter].formation.FormationTight[i] = (float)Convert.ToDouble(STRING.Trim());
                        else if (a < 2)
                        {
                            Data.Vanunits[counter].formation.FormationSparse[a] = (float)Convert.ToDouble(STRING.Trim());
                            a++;
                        }
                        else if (b < 1)
                        {
                            Data.Vanunits[counter].formation.FormationRanks = Convert.ToInt16(STRING.Trim());
                            b++;
                        }

                        else if (STRING.Trim() == "phalanx")
                            Data.Vanunits[counter].formation.FormationFlags |= FormationTypes.Formation_Phalanx;
                        else if (STRING.Trim() == "testudo")
                            Data.Vanunits[counter].formation.FormationFlags |= FormationTypes.Formation_Testudo;
                        else if (STRING.Trim() == "schiltrom")
                            Data.Vanunits[counter].formation.FormationFlags |= FormationTypes.Formation_Schiltrom;
                        else if (STRING.Trim() == "horde")
                            Data.Vanunits[counter].formation.FormationFlags |= FormationTypes.Formation_Horde;
                        else if (STRING.Trim() == "square")
                            Data.Vanunits[counter].formation.FormationFlags |= FormationTypes.Formation_Square;
                        else if (STRING.Trim() == "wedge")
                            Data.Vanunits[counter].formation.FormationFlags |= FormationTypes.Formation_Wedge;

                        i++;
                    }
                }

                else if (line.StartsWith("stat_health"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    Data.Vanunits[counter].heatlh[0] = Convert.ToInt16(splitted[0]);
                    Data.Vanunits[counter].heatlh[1] = Convert.ToInt16(splitted[1]);
                }

                else if (line.StartsWith("stat_pri_attr"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    foreach (string STRING in splitted)
                    {
                        if (STRING.Trim() == "ap")
                            Data.Vanunits[counter].priAttri |= stat_pri_attr.ap;
                        else if (STRING.Trim() == "bp")
                            Data.Vanunits[counter].priAttri |= stat_pri_attr.bp;
                        else if (STRING.Trim() == "spear")
                            Data.Vanunits[counter].priAttri |= stat_pri_attr.pa_spear;
                        else if (STRING.Trim() == "long_pike")
                            Data.Vanunits[counter].priAttri |= stat_pri_attr.long_pike;
                        else if (STRING.Trim() == "short_pike")
                            Data.Vanunits[counter].priAttri |= stat_pri_attr.short_pike;
                        else if (STRING.Trim() == "prec")
                            Data.Vanunits[counter].priAttri |= stat_pri_attr.prec;
                        else if (STRING.Trim() == "thrown")
                            Data.Vanunits[counter].priAttri |= stat_pri_attr.pa_thrown;
                        else if (STRING.Trim() == "launching")
                            Data.Vanunits[counter].priAttri |= stat_pri_attr.launching;
                        else if (STRING.Trim() == "area")
                            Data.Vanunits[counter].priAttri |= stat_pri_attr.area;
                        else if (STRING.Trim() == "spear_bonus_4")
                            Data.Vanunits[counter].priAttri |= stat_pri_attr.spear_bonus_4;
                        else if (STRING.Trim() == "spear_bonus_8")
                            Data.Vanunits[counter].priAttri |= stat_pri_attr.spear_bonus_8;
                        else if (STRING.Trim() == "thrown ap")
                            Data.Vanunits[counter].priAttri |= stat_pri_attr.thrown_ap;
                        else if (STRING.Trim() == "no")
                            Data.Vanunits[counter].priAttri |= stat_pri_attr.PA_no;
                    }

                }

                else if (line.StartsWith("stat_pri_armour"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    trimmed = splitted[0].TrimEnd();

                    Data.Vanunits[counter].primaryArmour.stat_pri_armour[0] = Convert.ToInt16(splitted[0]);
                    Data.Vanunits[counter].primaryArmour.stat_pri_armour[1] = Convert.ToInt16(splitted[1]);
                    Data.Vanunits[counter].primaryArmour.stat_pri_armour[2] = Convert.ToInt16(splitted[2]);

                    if (splitted[3].Trim() == "flesh")
                        Data.Vanunits[counter].primaryArmour.armour_sound = ArmourSound.flesh;
                    else if (splitted[3].Trim() == "leather")
                        Data.Vanunits[counter].primaryArmour.armour_sound = ArmourSound.leather;
                    else if (splitted[3].Trim() == "metal")
                        Data.Vanunits[counter].primaryArmour.armour_sound = ArmourSound.metal;

                }

                else if (line.StartsWith("stat_pri"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    trimmed = splitted[0].TrimEnd();

                    Data.Vanunits[counter].primaryWeapon.attack[0] = Convert.ToInt16(splitted[0]);
                    Data.Vanunits[counter].primaryWeapon.attack[1] = Convert.ToInt16(splitted[1]);

                    Data.Vanunits[counter].primaryWeapon.Missleattri[0] = Convert.ToInt16(splitted[3]);
                    Data.Vanunits[counter].primaryWeapon.Missleattri[1] = Convert.ToInt16(splitted[4]);

                    if (Data.isM2TWMode && splitted.Count() == 12)
                    {
                        Data.Vanunits[counter].primaryWeapon.musketString = splitted[9];
                        Data.Vanunits[counter].primaryWeapon.attackdelay[0] = (float)Convert.ToDouble(splitted[10]);
                        Data.Vanunits[counter].primaryWeapon.attackdelay[1] = (float)Convert.ToDouble(splitted[11]);
                    }
                    else
                    {
                        Data.Vanunits[counter].primaryWeapon.attackdelay[0] = (float)Convert.ToDouble(splitted[9]);
                        Data.Vanunits[counter].primaryWeapon.attackdelay[1] = (float)Convert.ToDouble(splitted[10]);
                    }
                    

                    if (splitted[2].Trim() == "javelin")
                        Data.Vanunits[counter].primaryWeapon.missletypeFlags = MissleType.javelin;
                    else if (splitted[2].Trim() == "stone")
                        Data.Vanunits[counter].primaryWeapon.missletypeFlags = MissleType.stone;
                    else if (splitted[2].Trim() == "pilum")
                        Data.Vanunits[counter].primaryWeapon.missletypeFlags = MissleType.pilum;
                    else if (splitted[2].Trim() == "arrow")
                        Data.Vanunits[counter].primaryWeapon.missletypeFlags = MissleType.arrow;
                    else if (splitted[2].Trim() == "no")
                        Data.Vanunits[counter].primaryWeapon.missletypeFlags = MissleType.MT_no;
                    else if (splitted[2].Trim() == "ballista")
                        Data.Vanunits[counter].primaryWeapon.missletypeFlags = MissleType.ballista;
                    else if (splitted[2].Trim() == "boulder")
                        Data.Vanunits[counter].primaryWeapon.missletypeFlags = MissleType.onager;
                    else if (splitted[2].Trim() == "big_boulder")
                        Data.Vanunits[counter].primaryWeapon.missletypeFlags = MissleType.heavy_onager;
                    else if (splitted[2].Trim() == "scorpion")
                        Data.Vanunits[counter].primaryWeapon.missletypeFlags = MissleType.scorpion;
                    else if (splitted[2].Trim() == "repeating_ballista")
                        Data.Vanunits[counter].primaryWeapon.missletypeFlags = MissleType.repeating_ballista;
                    else if (splitted[2].Trim() == "bullet")
                        Data.Vanunits[counter].primaryWeapon.missletypeFlags = MissleType.bullet;

                    if (splitted[5].Trim() == "melee")
                        Data.Vanunits[counter].primaryWeapon.WeaponFlags = WeaponType.melee;
                    else if (splitted[5].Trim() == "thrown")
                        Data.Vanunits[counter].primaryWeapon.WeaponFlags = WeaponType.thrown;
                    else if (splitted[5].Trim() == "missle")
                        Data.Vanunits[counter].primaryWeapon.WeaponFlags = WeaponType.missle;
                    else if (splitted[5].Trim() == "siege_missile")
                        Data.Vanunits[counter].primaryWeapon.WeaponFlags = WeaponType.siege_missle;
                    else if (splitted[5].Trim() == "no")
                        Data.Vanunits[counter].primaryWeapon.WeaponFlags = WeaponType.WT_no;

                    if (splitted[6].Trim() == "simple")
                        Data.Vanunits[counter].primaryWeapon.TechFlags = techType.simple;
                    else if (splitted[6].Trim() == "other")
                        Data.Vanunits[counter].primaryWeapon.TechFlags = techType.other;
                    else if (splitted[6].Trim() == "blade")
                        Data.Vanunits[counter].primaryWeapon.TechFlags = techType.blade;
                    else if (splitted[6].Trim() == "archery")
                        Data.Vanunits[counter].primaryWeapon.TechFlags = techType.archery;
                    else if (splitted[6].Trim() == "siege")
                        Data.Vanunits[counter].primaryWeapon.TechFlags = techType.siege;
                    else if (splitted[6].Trim() == "no")
                        Data.Vanunits[counter].primaryWeapon.TechFlags = techType.TT_no;

                    if (splitted[7].Trim() == "piercing")
                        Data.Vanunits[counter].primaryWeapon.DamageFlags = DamageType.piercing;
                    else if (splitted[7].Trim() == "blunt")
                        Data.Vanunits[counter].primaryWeapon.DamageFlags = DamageType.blunt;
                    else if (splitted[7].Trim() == "slashing")
                        Data.Vanunits[counter].primaryWeapon.DamageFlags = DamageType.slashing;
                    else if (splitted[7].Trim() == "fire")
                        Data.Vanunits[counter].primaryWeapon.DamageFlags = DamageType.fire;
                    else if (splitted[7].Trim() == "no")
                        Data.Vanunits[counter].primaryWeapon.DamageFlags = DamageType.DM_no;

                    if (splitted[8].Trim() == "none")
                        Data.Vanunits[counter].primaryWeapon.SoundFlags = SoundType.ST_no;
                    else if (splitted[8].Trim() == "knife")
                        Data.Vanunits[counter].primaryWeapon.SoundFlags = SoundType.knife;
                    else if (splitted[8].Trim() == "mace")
                        Data.Vanunits[counter].primaryWeapon.SoundFlags = SoundType.mace;
                    else if (splitted[8].Trim() == "axe")
                        Data.Vanunits[counter].primaryWeapon.SoundFlags = SoundType.axe;
                    else if (splitted[8].Trim() == "sword")
                        Data.Vanunits[counter].primaryWeapon.SoundFlags = SoundType.sword;
                    else if (splitted[8].Trim() == "spear")
                        Data.Vanunits[counter].primaryWeapon.SoundFlags = SoundType.spear;

                }

                else if (line.StartsWith("stat_sec_attr"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    foreach (string STRING in splitted)
                    {
                        if (STRING.Trim() == "ap")
                            Data.Vanunits[counter].secAttri |= stat_pri_attr.ap;
                        else if (STRING.Trim() == "bp")
                            Data.Vanunits[counter].secAttri |= stat_pri_attr.bp;
                        else if (STRING.Trim() == "pa_spear")
                            Data.Vanunits[counter].secAttri |= stat_pri_attr.pa_spear;
                        else if (STRING.Trim() == "long_pike")
                            Data.Vanunits[counter].secAttri |= stat_pri_attr.long_pike;
                        else if (STRING.Trim() == "short_pike")
                            Data.Vanunits[counter].secAttri |= stat_pri_attr.short_pike;
                        else if (STRING.Trim() == "prec")
                            Data.Vanunits[counter].secAttri |= stat_pri_attr.prec;
                        else if (STRING.Trim() == "pa_thrown")
                            Data.Vanunits[counter].secAttri |= stat_pri_attr.pa_thrown;
                        else if (STRING.Trim() == "launching")
                            Data.Vanunits[counter].secAttri |= stat_pri_attr.launching;
                        else if (STRING.Trim() == "area")
                            Data.Vanunits[counter].secAttri |= stat_pri_attr.area;
                        else if (STRING.Trim() == "fire")
                            Data.Vanunits[counter].secAttri |= stat_pri_attr.fire;
                        else if (STRING.Trim() == "no")
                            Data.Vanunits[counter].secAttri |= stat_pri_attr.PA_no;
                    }

                }

                else if (line.StartsWith("stat_sec_armour"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    trimmed = splitted[0].TrimEnd();

                    Data.Vanunits[counter].secondaryArmour.stat_sec_armour[0] = Convert.ToInt16(splitted[0]);
                    Data.Vanunits[counter].secondaryArmour.stat_sec_armour[1] = Convert.ToInt16(splitted[1]);

                    if (splitted[2].Trim() == "flesh")
                        Data.Vanunits[counter].secondaryArmour.sec_armour_sound = ArmourSound.flesh;
                    else if (splitted[2].Trim() == "leather")
                        Data.Vanunits[counter].secondaryArmour.sec_armour_sound = ArmourSound.leather;
                    else if (splitted[2].Trim() == "metal")
                        Data.Vanunits[counter].secondaryArmour.sec_armour_sound = ArmourSound.metal;

                }

                else if (line.StartsWith("stat_sec"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    trimmed = splitted[0].TrimEnd();

                    Data.Vanunits[counter].secondaryWeapon.attack[0] = Convert.ToInt16(splitted[0]);
                    Data.Vanunits[counter].secondaryWeapon.attack[1] = Convert.ToInt16(splitted[1]);

                    Data.Vanunits[counter].secondaryWeapon.Missleattri[0] = Convert.ToInt16(splitted[3]);
                    Data.Vanunits[counter].secondaryWeapon.Missleattri[1] = Convert.ToInt16(splitted[4]);

                    Data.Vanunits[counter].secondaryWeapon.attackdelay[0] = (float)Convert.ToDouble(splitted[9]);
                    Data.Vanunits[counter].secondaryWeapon.attackdelay[1] = (float)Convert.ToDouble(splitted[10]);

                    if (splitted[2].Trim() == "javelin")
                        Data.Vanunits[counter].secondaryWeapon.missletypeFlags = MissleType.javelin;
                    else if (splitted[2].Trim() == "stone")
                        Data.Vanunits[counter].secondaryWeapon.missletypeFlags = MissleType.stone;
                    else if (splitted[2].Trim() == "pilum")
                        Data.Vanunits[counter].secondaryWeapon.missletypeFlags = MissleType.pilum;
                    else if (splitted[2].Trim() == "arrow")
                        Data.Vanunits[counter].secondaryWeapon.missletypeFlags = MissleType.arrow;
                    else if (splitted[2].Trim() == "no")
                        Data.Vanunits[counter].secondaryWeapon.missletypeFlags = MissleType.MT_no;
                    else if (splitted[2].Trim() == "ballista")
                        Data.Vanunits[counter].secondaryWeapon.missletypeFlags = MissleType.ballista;
                    else if (splitted[2].Trim() == "boulder")
                        Data.Vanunits[counter].secondaryWeapon.missletypeFlags = MissleType.onager;
                    else if (splitted[2].Trim() == "big_boulder")
                        Data.Vanunits[counter].secondaryWeapon.missletypeFlags = MissleType.heavy_onager;
                    else if (splitted[2].Trim() == "scorpion")
                        Data.Vanunits[counter].secondaryWeapon.missletypeFlags = MissleType.scorpion;
                    else if (splitted[2].Trim() == "repeating_ballista")
                        Data.Vanunits[counter].secondaryWeapon.missletypeFlags = MissleType.repeating_ballista;
                    else if (splitted[2].Trim() == "bullet")
                        Data.Vanunits[counter].secondaryWeapon.missletypeFlags = MissleType.bullet;

                    if (splitted[5].Trim() == "melee")
                        Data.Vanunits[counter].secondaryWeapon.WeaponFlags = WeaponType.melee;
                    else if (splitted[5].Trim() == "thrown")
                        Data.Vanunits[counter].secondaryWeapon.WeaponFlags = WeaponType.thrown;
                    else if (splitted[5].Trim() == "missle")
                        Data.Vanunits[counter].secondaryWeapon.WeaponFlags = WeaponType.missle;
                    else if (splitted[5].Trim() == "siege_missile")
                        Data.Vanunits[counter].secondaryWeapon.WeaponFlags = WeaponType.siege_missle;
                    else if (splitted[5].Trim() == "no")
                        Data.Vanunits[counter].secondaryWeapon.WeaponFlags = WeaponType.WT_no;

                    if (splitted[6].Trim() == "simple")
                        Data.Vanunits[counter].secondaryWeapon.TechFlags = techType.simple;
                    else if (splitted[6].Trim() == "other")
                        Data.Vanunits[counter].secondaryWeapon.TechFlags = techType.other;
                    else if (splitted[6].Trim() == "blade")
                        Data.Vanunits[counter].secondaryWeapon.TechFlags = techType.blade;
                    else if (splitted[6].Trim() == "archery")
                        Data.Vanunits[counter].secondaryWeapon.TechFlags = techType.archery;
                    else if (splitted[6].Trim() == "siege")
                        Data.Vanunits[counter].secondaryWeapon.TechFlags = techType.siege;
                    else if (splitted[6].Trim() == "no")
                        Data.Vanunits[counter].secondaryWeapon.TechFlags = techType.TT_no;

                    if (splitted[7].Trim() == "piercing")
                        Data.Vanunits[counter].secondaryWeapon.DamageFlags = DamageType.piercing;
                    else if (splitted[7].Trim() == "blunt")
                        Data.Vanunits[counter].secondaryWeapon.DamageFlags = DamageType.blunt;
                    else if (splitted[7].Trim() == "slashing")
                        Data.Vanunits[counter].secondaryWeapon.DamageFlags = DamageType.slashing;
                    else if (splitted[7].Trim() == "fire")
                        Data.Vanunits[counter].secondaryWeapon.DamageFlags = DamageType.fire;
                    else if (splitted[7].Trim() == "no")
                        Data.Vanunits[counter].secondaryWeapon.DamageFlags = DamageType.DM_no;

                    if (splitted[8].Trim() == "none")
                        Data.Vanunits[counter].secondaryWeapon.SoundFlags = SoundType.ST_no;
                    else if (splitted[8].Trim() == "knife")
                        Data.Vanunits[counter].secondaryWeapon.SoundFlags = SoundType.knife;
                    else if (splitted[8].Trim() == "mace")
                        Data.Vanunits[counter].secondaryWeapon.SoundFlags = SoundType.mace;
                    else if (splitted[8].Trim() == "axe")
                        Data.Vanunits[counter].secondaryWeapon.SoundFlags = SoundType.axe;
                    else if (splitted[8].Trim() == "sword")
                        Data.Vanunits[counter].secondaryWeapon.SoundFlags = SoundType.sword;
                    else if (splitted[8].Trim() == "spear")
                        Data.Vanunits[counter].secondaryWeapon.SoundFlags = SoundType.spear;

                }

                else if (line.StartsWith("stat_heat"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    trimmed = splitted[0].TrimEnd();

                    Data.Vanunits[counter].heat = Convert.ToInt16(trimmed);

                }

                else if (line.StartsWith("stat_ground"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    trimmed = splitted[0].TrimEnd();

                    Data.Vanunits[counter].ground[0] = Convert.ToInt16(splitted[0]);
                    Data.Vanunits[counter].ground[1] = Convert.ToInt16(splitted[1]);
                    Data.Vanunits[counter].ground[2] = Convert.ToInt16(splitted[2]);
                    Data.Vanunits[counter].ground[3] = Convert.ToInt16(splitted[3]);

                }

                else if (line.StartsWith("stat_mental"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    trimmed = splitted[0].TrimEnd();

                    Data.Vanunits[counter].mental.morale = Convert.ToInt16(splitted[0]);

                    if (splitted[1].Trim() == "normal")
                        Data.Vanunits[counter].mental.discipline = statmental_discipline.normal;
                    else if (splitted[1].Trim() == "low")
                        Data.Vanunits[counter].mental.discipline = statmental_discipline.low;
                    else if (splitted[1].Trim() == "disciplined")
                        Data.Vanunits[counter].mental.discipline = statmental_discipline.disciplined;
                    else if (splitted[1].Trim() == "impetuous")
                        Data.Vanunits[counter].mental.discipline = statmental_discipline.impetuous;
                    else if (splitted[1].Trim() == "berserker")
                        Data.Vanunits[counter].mental.discipline = statmental_discipline.berserker;

                    if (splitted[2].Trim() == "untrained")
                        Data.Vanunits[counter].mental.training = statmental_training.untrained;
                    else if (splitted[2].Trim() == "trained")
                        Data.Vanunits[counter].mental.training = statmental_training.trained;
                    else if (splitted[2].Trim() == "highly_trained")
                        Data.Vanunits[counter].mental.training = statmental_training.highly_trained;
                }

                else if (line.StartsWith("stat_charge_dist"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    trimmed = splitted[0].TrimEnd();

                    Data.Vanunits[counter].chargeDistance = Convert.ToInt16(trimmed);

                }

                else if (line.StartsWith("stat_fire_delay"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    trimmed = splitted[0].TrimEnd();

                    Data.Vanunits[counter].fireDelay = Convert.ToInt16(trimmed);

                }

                else if (line.StartsWith("stat_food"))
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    trimmed = splitted[0].TrimEnd();

                    Data.Vanunits[counter].food[0] = Convert.ToInt16(splitted[0]);
                    Data.Vanunits[counter].food[1] = Convert.ToInt16(splitted[1]);

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
                        if (Data.isRTWMode)
                            Data.Vanunits[counter].cost[i] = Convert.ToInt16(STRING);
                        else if (Data.isM2TWMode)
                            Data.Vanunits[counter].M2TWcost[i] = Convert.ToInt16(STRING);
                        i++;
                    }

                }

                else if (line.StartsWith("ownership") && Data.isRTWMode)
                {
                    string trimmed = Functions.RemoveFirstWord(line);
                    trimmed = trimmed.Trim();

                    string[] splitted = trimmed.Split(',');

                    trimmed = splitted[0].TrimEnd();

                    foreach (string STRING in splitted)
                    {
                        if (STRING.Trim() == "romans_julii")
                            Data.Vanunits[counter].ownership |= FactionOwnership.romans_julii;
                        else if (STRING.Trim() == "romans_brutii")
                            Data.Vanunits[counter].ownership |= FactionOwnership.romans_brutii;
                        else if (STRING.Trim() == "romans_scipii")
                            Data.Vanunits[counter].ownership |= FactionOwnership.romans_scipii;
                        else if (STRING.Trim() == "roman")
                            Data.Vanunits[counter].ownership |= FactionOwnership.roman;
                        else if (STRING.Trim() == "egyptian")
                            Data.Vanunits[counter].ownership |= FactionOwnership.egyptian;
                        else if (STRING.Trim() == "eastern")
                            Data.Vanunits[counter].ownership |= FactionOwnership.eastern;
                        else if (STRING.Trim() == "greek")
                            Data.Vanunits[counter].ownership |= FactionOwnership.greek;
                        else if (STRING.Trim() == "carthaginian")
                            Data.Vanunits[counter].ownership |= FactionOwnership.carthaginian;
                        else if (STRING.Trim() == "egypt")
                            Data.Vanunits[counter].ownership |= FactionOwnership.egypt;
                        else if (STRING.Trim() == "seleucid")
                            Data.Vanunits[counter].ownership |= FactionOwnership.seleucid;
                        else if (STRING.Trim() == "carthage")
                            Data.Vanunits[counter].ownership |= FactionOwnership.carthage;
                        else if (STRING.Trim() == "parthia")
                            Data.Vanunits[counter].ownership |= FactionOwnership.parthia;
                        else if (STRING.Trim() == "gauls")
                            Data.Vanunits[counter].ownership |= FactionOwnership.gauls;
                        else if (STRING.Trim() == "germans")
                            Data.Vanunits[counter].ownership |= FactionOwnership.germans;
                        else if (STRING.Trim() == "britons")
                            Data.Vanunits[counter].ownership |= FactionOwnership.britons;
                        else if (STRING.Trim() == "greek_cities")
                            Data.Vanunits[counter].ownership |= FactionOwnership.greek_cities;
                        else if (STRING.Trim() == "romans_senate")
                            Data.Vanunits[counter].ownership |= FactionOwnership.romans_senate;
                        else if (STRING.Trim() == "macedon")
                            Data.Vanunits[counter].ownership |= FactionOwnership.macedon;
                        else if (STRING.Trim() == "pontus")
                            Data.Vanunits[counter].ownership |= FactionOwnership.pontus;
                        else if (STRING.Trim() == "armenia")
                            Data.Vanunits[counter].ownership |= FactionOwnership.armenia;
                        else if (STRING.Trim() == "dacia")
                            Data.Vanunits[counter].ownership |= FactionOwnership.dacia;
                        else if (STRING.Trim() == "numidia")
                            Data.Vanunits[counter].ownership |= FactionOwnership.numidia;
                        else if (STRING.Trim() == "scythia")
                            Data.Vanunits[counter].ownership |= FactionOwnership.scythia;
                        else if (STRING.Trim() == "spain")
                            Data.Vanunits[counter].ownership |= FactionOwnership.spain;
                        else if (STRING.Trim() == "thrace")
                            Data.Vanunits[counter].ownership |= FactionOwnership.thrace;
                        else if (STRING.Trim() == "slave")
                            Data.Vanunits[counter].ownership |= FactionOwnership.slave;
                        else if (STRING.Trim() == "barbarian")
                            Data.Vanunits[counter].ownership |= FactionOwnership.barbarian;

                    }
                }


                else if (line.StartsWith("stat_pri_ex") && Data.isM2TWMode)
                {
                    Data.Vanunits[counter].stat_pri_ex = Functions.RemoveFirstWord(line.Trim()).Trim();

                }
                else if (line.StartsWith("stat_ter") && Data.isM2TWMode)
                {
                    Data.Vanunits[counter].stat_ter = Functions.RemoveFirstWord(line.Trim()).Trim();

                }

                else if (line.StartsWith("stat_ter_ex") && Data.isM2TWMode)
                {
                    Data.Vanunits[counter].stat_ter_ex = Functions.RemoveFirstWord(line.Trim()).Trim();

                }

                else if (line.StartsWith("stat_ter_attr") && Data.isM2TWMode)
                {
                    Data.Vanunits[counter].stat_ter_attr = Functions.RemoveFirstWord(line.Trim()).Trim();

                }

                else if (line.StartsWith("stat_armour_ex") && Data.isM2TWMode)
                {
                    Data.Vanunits[counter].stat_armour_ex = Functions.RemoveFirstWord(line.Trim()).Trim();

                }

                else if (line.StartsWith("banner faction") && Data.isM2TWMode)
                {
                    string firstRemove = Functions.RemoveFirstWord(line.Trim()).Trim();
                    string secondRemove = Functions.RemoveFirstWord(firstRemove);
                    Data.Vanunits[counter].bannerFaction = secondRemove.Trim();

                }

                else if (line.StartsWith("banner holy") && Data.isM2TWMode)
                {
                    string firstRemove = Functions.RemoveFirstWord(line.Trim()).Trim();
                    string secondRemove = Functions.RemoveFirstWord(firstRemove);
                    Data.Vanunits[counter].bannerFaction = secondRemove.Trim();

                }

                else if (line.StartsWith("stat_sec_ex") && Data.isM2TWMode)
                {

                    Data.Vanunits[counter].stat_sec_ex = Functions.RemoveFirstWord(line.Trim()).Trim();

                }

                else if (line.StartsWith("stat_stl") && Data.isM2TWMode)
                {

                    Data.Vanunits[counter].stat_stl = Functions.RemoveFirstWord(line.Trim()).Trim();

                }
                else if (line.StartsWith("armour_ug_levels") && Data.isM2TWMode)
                {

                    Data.Vanunits[counter].armour_ug_levels = Functions.RemoveFirstWord(line.Trim()).Trim();

                }

                else if (line.StartsWith("armour_ug_models") && Data.isM2TWMode)
                {

                    Data.Vanunits[counter].armour_ug_models = Functions.RemoveFirstWord(line.Trim()).Trim();

                }

                else if (line.StartsWith("era0") && Data.isM2TWMode)
                {
                    string firstWordRemoved = Functions.RemoveFirstWord(line.Trim()).Trim();
                    Data.Vanunits[counter].era0 = Functions.RemoveFirstWord(firstWordRemoved);

                }

                else if (line.StartsWith("era1") && Data.isM2TWMode)
                {

                    string firstWordRemoved = Functions.RemoveFirstWord(line.Trim()).Trim();
                    Data.Vanunits[counter].era1 = Functions.RemoveFirstWord(firstWordRemoved);

                }
                else if (line.StartsWith("era2") && Data.isM2TWMode)
                {

                    string firstWordRemoved = Functions.RemoveFirstWord(line.Trim()).Trim();
                    Data.Vanunits[counter].era2 = Functions.RemoveFirstWord(firstWordRemoved);

                }

                else if (line.StartsWith("info_pic_dir") && Data.isM2TWMode)
                {

                    Data.Vanunits[counter].info_pic_dir = Functions.RemoveFirstWord(line.Trim()).Trim();

                }

                else if (line.StartsWith("card_pic_info") && Data.isM2TWMode)
                {

                    Data.Vanunits[counter].card_pic_info = Functions.RemoveFirstWord(line.Trim()).Trim();

                }

                else if (line.StartsWith("unit_info") && Data.isM2TWMode)
                {

                    Data.Vanunits[counter].unit_info = Functions.RemoveFirstWord(line.Trim()).Trim();

                }
            }

            txt_Output.AppendText("\n" + Data.Vanunits.Count + "Units loaded from EDU");

            edu.Close();
        }

        public static void ParseEdb(string filepath, ref TextBox txt_Output)
        {
            string line;
            string notrim;
            string previous = "";
            int counter = -1;

            StreamReader strat = new StreamReader(filepath);

            //get factions
            while ((line = strat.ReadLine()) != null)
            {
                string trimmedLine = line.Trim();

                if (trimmedLine.StartsWith("hidden_resources"))
                {

                    string modified = Functions.RemoveFirstWord(trimmedLine);
                    string[] splitStr = modified.Split(' ');


                    foreach (string str in splitStr)
                    {
                        Data.EDBData.hiddenResources.Add(str);

                    }

                }


                if (trimmedLine.StartsWith("building"))
                {
                    counter++;

                    Data.EDBData.buildingTrees.Add(new coreBuilding());

                    //get building type
                    string[] split = trimmedLine.Split(' ');
                    Data.EDBData.buildingTrees[counter].buildingType = split[1].Trim();

                    //start new while loop after every { and stop at }
                    line = strat.ReadLine();

                    txt_Output.AppendText("Loading: " + split[1].Trim() + "\r\n");
                    if (line.Trim().StartsWith("{")) // start the while loop
                    {
                        bool whileOne = false;


                        while (!whileOne)
                        {
                            line = strat.ReadLine();

                            if (line.Trim().StartsWith("convert_to"))
                            {
                                string[] convSplit = line.Trim().Split(' ');

                                Data.EDBData.buildingTrees[counter].CBconvert_to = convSplit[1];
                            }

                            if (line.Trim().StartsWith("}"))
                            {
                                whileOne = true; //break out of loop
                                break;
                            }

                            if (line.Trim().StartsWith("levels"))
                            {
                                string firstWordRemoved = Functions.RemoveFirstWord(line.Trim());
                                string[] levelsSplit = firstWordRemoved.Split();

                                foreach (string str in levelsSplit)
                                {
                                    Data.EDBData.buildingTrees[counter].levels.Add(str);
                                }

                                line = strat.ReadLine(); //continue to next line

                                if (line.Trim().StartsWith("{"))
                                {
                                    bool whileTwo = false;

                                    //start another while loop (loop through the buildings foreach level)
                                    //line = strat.ReadLine(); //continue to next line
                                    bool buildingNext = true;

                                    Building newBuilding = new Building();
                                    

                                    while (!whileTwo)
                                    {
                                        line = strat.ReadLine(); //continue to next line

                                        if (line.Trim().StartsWith("}"))
                                        {
                                            whileTwo = true; //break out of loop
                                            break;
                                        }

                                        if (buildingNext)
                                        {
                                            newBuilding.factionsRequired = new List<string>();

                                            newBuilding.buildingName = Functions.GetFirstWord(line.Trim());
                                            //get factions
                                            string output = line.Trim().Substring(line.Trim().IndexOf('{') + 1);
                                            output = Functions.RemoveLastWord(output);
                                            List<string> factionSplit = output.Split(',').ToList();

                                            factionSplit.Remove(factionSplit.Last());

                                            foreach (string faction in factionSplit)
                                            {
                                                newBuilding.factionsRequired.Add(faction.Trim());
                                            }


                                            buildingNext = false;
                                        }


                                        if (line.Trim().StartsWith("{"))
                                        {
                                            bool whileThree = false;

                                            //start looping through capabilitys of buildings, constuction and plugins
                                            while (!whileThree)
                                            {
                                                line = strat.ReadLine(); //continue to next line

                                                if (line.Trim().StartsWith("convert_to"))
                                                {
                                                    string[] convSplit = line.Trim().Split(' ');

                                                    newBuilding.Bconvert_to = convSplit[1];

                                                }

                                                if (line.Trim().StartsWith("}"))
                                                {
                                                    whileThree = true; //break out of loop
                                                    break;
                                                }

                                                if (line.Trim().StartsWith("faction_capability"))
                                                {
                                                    bool whileSeven = false;

                                                    Fcapability FnewCapa = new Fcapability();

                                                    while (!whileSeven)
                                                    {
                                                        line = strat.ReadLine();

                                                        if (line.Trim().StartsWith("}"))
                                                        {

                                                            newBuilding.fcapability = FnewCapa;

                                                            whileSeven = true; //break out of loop
                                                            break;
                                                        }

                                                        else if (Functions.GetFirstWord(line.Trim()) == "{")
                                                        { }

                                                        else if (!line.Trim().StartsWith("}"))
                                                        {
                                                            FnewCapa.effectList.Add(line.Trim());
                                                        }


                                                    }

                                                }

                                                if (line.Trim().StartsWith("capability")) //loop through capabilities
                                                {
                                                    bool whileFour = false;

                                                    Bcapability newCapa = new Bcapability();

                                                    while (!whileFour)
                                                    {
                                                        line = strat.ReadLine();

                                                        if (line.Trim().StartsWith("}"))
                                                        {

                                                            newBuilding.capability = newCapa;

                                                            whileFour = true; //break out of loop
                                                            break;
                                                        }

                                                        if (Functions.GetFirstWord(line.Trim()) == "recruit" || Functions.GetFirstWord(line.Trim()) == "recruit_pool")
                                                        {
                                                            Brecruit newRecruit = new Brecruit();

                                                            //get unit name
                                                            string[] unitSplit = line.Trim().Split('"');
                                                            newRecruit.name = unitSplit[1]; // unit name should always be here;
                                                            if (Data.isRTWMode)
                                                            {
                                                                //get unit experience
                                                                string[] expSplit = unitSplit[2].Trim().Split(' ');
                                                                newRecruit.experience = Convert.ToInt32(expSplit[0].Trim());
                                                            }

                                                            else if (Data.isM2TWMode)
                                                            {
                                                                //get unit experience
                                                                string[] expSplit = unitSplit[2].Trim().Split(' ');
                                                                newRecruit.startingPoints = Convert.ToInt32(expSplit[0].Trim());
                                                                newRecruit.pointBuildingGains = Convert.ToDouble(expSplit[3].Trim());
                                                                newRecruit.maximumPoints = Convert.ToDouble(expSplit[6].Trim());
                                                                newRecruit.experience = Convert.ToInt32(expSplit[8].Trim());
                                                            }

                                                            //get factions
                                                            string output = line.Trim().Substring(line.Trim().IndexOf('{') + 1);
                                                            output = Functions.RemoveLastWord(output);
                                                            List<string> factionSplit = output.Split(',').ToList();

                                                            factionSplit.Remove(factionSplit.Last());

                                                            foreach (string faction in factionSplit)
                                                            {
                                                                newRecruit.requiresFactions.Add(faction);
                                                            }

                                                            newCapa.canRecruit.Add(newRecruit);
                                                        }

                                                        else if (Functions.GetFirstWord(line.Trim()) == "agent")
                                                        {
                                                            newCapa.agentList.Add(line.Trim());
                                                        }

                                                        else if (Functions.GetFirstWord(line.Trim()) == "{")
                                                        { }

                                                        else if (!line.Trim().StartsWith("}"))
                                                        {
                                                            newCapa.effectList.Add(line.Trim());
                                                        }

                                                    }

                                                }

                                                if (line.Trim().StartsWith("material"))
                                                {
                                                    newBuilding.material = Functions.RemoveFirstWord(line.Trim()).Trim();


                                                }

                                                if (line.Trim().StartsWith("construction"))
                                                {
                                                    bool whileFive = false;

                                                    Bconstruction newConstruction = new Bconstruction();

                                                    //set initial construction value
                                                    string[] constructionSplit = line.Trim().Split(' ');
                                                    newConstruction.turnsToBuild = Convert.ToInt32(constructionSplit[2].Trim());

                                                    
                                                    while (!whileFive)
                                                    {
                                                        line = strat.ReadLine();

                                                        if (line.Trim().StartsWith("}"))
                                                        {
                                                            whileFive = true; //break out of loop
                                                            break;
                                                        }


                                                        if (line.Trim().StartsWith("cost"))
                                                        {
                                                            newConstruction.cost = Convert.ToInt32(Functions.RemoveFirstWord(line.Trim()).Trim());

                                                        }

                                                        if (line.Trim().StartsWith("settlement_min"))
                                                        {
                                                            newConstruction.settlement_min = Functions.RemoveFirstWord(line.Trim()).Trim();

                                                        }

                                                        if (line.Trim().StartsWith("upgrades"))
                                                        {
                                                            bool whileSix = false;

                                                            while (!whileSix)
                                                            {
                                                                line = strat.ReadLine();

                                                                if (line.Trim().StartsWith("}"))
                                                                {
                                                                    if (newBuilding.buildingName == "alchemists_guild")
                                                                    {


                                                                    }
                                                                    newBuilding.construction = newConstruction;
                                                                    Data.EDBData.buildingTrees[counter].buildings.Add(new Building(newBuilding));
                                                                    buildingNext = true;
                                                                    whileFive = true; //break out of loop
                                                                    break;
                                                                }

                                                                if (!line.Trim().StartsWith("{"))
                                                                {
                                                                    newConstruction.upgrades.Add(line.Trim());
                                                                
                                                                }
                                                            }
                                                        }

                                                    }



                                                }

                                            }

                                        }


                                    }
                                    
                                    
                                }




                            }


                        }


                    }
                    



                }
            }

            strat.Close();

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

            Bitmap img = Paloma.TargaImage.LoadTargaImage(Data.MainFolderPath + Data.MAPREGIONSPATH);

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

                        if (tr == 41 && tg == 140 && tb == 233)
                        {
                            tr = img.GetPixel(x, y - 1).R;
                            tg = img.GetPixel(x, y - 1).G;
                            tb = img.GetPixel(x, y - 1).B;

                        }


                        int index = Data.rgbRegions.FindIndex(z => z.r == tr && z.g == tg && z.b == tb);

                        if (Data.isRTWMode)
                        {
                            Data.rgbRegions[index].x = x;
                            Data.rgbRegions[index].y = y;
                            Data.regionWater[x, y] = false;
                        }
                        else if (Data.isM2TWMode)
                        {
                            Data.rgbRegions[index].x = x;
                            Data.rgbRegions[index].y = y;
                            Data.M2TWregionWater[x, y] = false;
                        }
                    }

                    else if (img.GetPixel(x, y).R == 41 && img.GetPixel(x, y).G == 140 && img.GetPixel(x, y).B == 233)
                    {
                        if (Data.isRTWMode)
                            Data.regionWater[x, y] = true;
                        else if (Data.isM2TWMode)
                            Data.M2TWregionWater[x, y] = true;
                    }

                    else
                    {
                        if(Data.isRTWMode)
                            Data.regionWater[x, y] = false;
                        else if (Data.isM2TWMode)
                            Data.M2TWregionWater[x, y] = false;


                    }

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
				if(line.StartsWith("faction"))
				{
					string[] split = line.Split(',', ' ', '\t');

					if(Data.isRTWMode)
						FactionRosters.AddFactionKey(enumsToStrings.SpecialStringToFaction(split[1]));
					else if(Data.isM2TWMode)
						FactionRosters.AddFactionKey(enumsToStrings.M2TWStringToFaction(split[1]));
				}

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
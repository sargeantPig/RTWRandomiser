using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomiser
{

    [Flags]
    public enum Attributes
    { 
        sea_faring = 1 << 0,
        hide_forest = 1 << 1,
        hide_improved_forest = 1 << 2,
        hide_long_grass = 1 << 3,
        hide_anywhere = 1 << 4,
        can_sap = 1 << 5,
        frighten_foot = 1 << 6,
        frighten_mounted = 1 << 7,
        can_run_amok = 1 << 8,
        general_unit = 1 << 9,
        general_unit_upgrade = 1 << 10,
        cantabrian_circle = 1 << 11,
        no_custom = 1 << 12,
        command = 1 << 13,
        mercenary_unit = 1 << 14,
        druid = 1 << 15,
        warcry = 1 << 16,
    }

    [Flags]
    public enum M2TWAttributes
    {
        sea_faring = 1 << 0,
        hide_forest = 1 << 1,
        hide_improved_forest = 1 << 2,
        hide_long_grass = 1 << 3,
        hide_anywhere = 1 << 4,
        can_sap = 1 << 5,
        frighten_foot = 1 << 6,
        frighten_mounted = 1 << 7,
        can_run_amok = 1 << 8,
        general_unit = 1 << 9,
        general_unit_upgrade = 1 << 10,
        cantabrian_circle = 1 << 11,
        no_custom = 1 << 12,
        command = 1 << 13,
        mercenary_unit = 1 << 14,
        druid = 1 << 15,
        warcry = 1 << 16,
        free_upkeep_unit = 1 << 17,
    }

    [Flags]
    public enum FormationTypes
    {
        Formation_Phalanx = 1 << 0,
        Formation_Horde = 1 << 1,
        Formation_Square = 1 << 2,
        Formation_Testudo = 1 << 3,
        Formation_Schiltrom = 1 << 4,
        Formation_Wedge = 1 << 5,
        Formation_None = 1 << 6
    };

    public enum MissleType
    {
        javelin,
        stone,
        pilum,
        arrow,
        ballista,
        onager,
        heavy_onager,
        scorpion,
        repeating_ballista,
        bullet,
        MT_no
    };

    public enum M2TWAmmunition
    {
        no,
        arrow,
        arrow_fiery,
        composite_arrow,
        composite_arrow_fiery,
        cav_composite_arrow,
        cav_composite_arrow_fiery,
        bodkin_arrow,
        bodkin_arrow_fiery,
        cav_bodkin_arrow,
        cav_bodkin_arrow_fiery,
        catapult,
        fiery_catapult,
        trebuchet,
        fiery_trebuchet,
        tarred_rock,
        stone,
        bolt,
        javelin,
        ballista,
        flaming_ballista,
        tower_ballista,
        tower_flaming_ballista,
        scorpion,
        flaming_scorpion,
        repeating_ballista,
        bombard_shot,
        flaming_bombard_shot,
        ribault_shot,
        monster_ribault_shot,
        grand_bombard_shot,
        flaming_grand_bombard_shot,
        monster_bombard_shot,
        cannon_shot,
        exploding_cannon_shot,
        culverin_shot,
        exploding_culverin_shot,
        mortar_shot,
        basilisk_shot,
        exploding_basilisk_shot,
        serpentine_shot,
        elephant_cannon_shot,
        cow_carcass,
        rocket,
        elephant_rocket,
        test_cannon_ball,
        naphtha_bomb,
        hand_gun_bullet,
        arquebus_bullet,
        musket_bullet,
        pistol_bullet,
        camel_gun_bullet,
        crossbow_bolt,
        steel_crossbow_bolt,
        norman_catapult,
        fiery_norman_catapult,

    }

    public enum WeaponType
    {

        melee,
        thrown,
        missle,
        siege_missle,
        WT_no
    };

    public enum techType
    {

        simple,
        other,
        blade,
        archery,
        siege,
        TT_no
    };

    public enum M2TWtechType
    {
        melee_simple,
        melee_blade,
        missile_mechanical,
        missile_gunpowder,
        artillery_mechanical,
        artillery_gunpowder,
        TT_no
    };

    public enum DamageType
    {

        piercing,
        blunt,
        slashing,
        fire,
        DM_no
    };

    public enum SoundType
    {
        knife,
        mace,
        axe,
        sword,
        spear,
        ST_no
    };

    public enum ArmourSound
    {

        flesh = 1 << 0,
        leather = 1 << 1,
        metal = 1 << 2
    };

    public enum statmental_discipline
    {

        normal = 1 << 0,
        low = 1 << 1,
        disciplined = 1 << 2,
        impetuous = 1 << 3,
        berserker = 1 << 4
    };

    public enum statmental_training
    {

        untrained = 1 << 0,
        trained = 1 << 1,
        highly_trained = 1 << 2
    };

    [Flags]
    public enum stat_pri_attr
    {
        ap = 1 << 0,
        bp = 1 << 1,
        pa_spear = 1 << 2,
        long_pike = 1 << 3,
        short_pike = 1 << 4,
        prec = 1 << 5,
        pa_thrown = 1 << 6,
        launching = 1 << 7,
        area = 1 << 8,
        fire = 1 << 9,
        spear_bonus_4 = 1 << 10,
        spear_bonus_8 = 1 << 11,
        thrown_ap = 1 << 12,
        PA_no = 1 << 13
    };

    public enum Cultures
    {
        none,
        carthaginian,
        eastern,
        parthian,
        egyptian,
        greek,
        roman,
        barbarian,
        numidian
    }

    [Flags]
    public enum FactionOwnership
    { 
        romans_julii = 1 << 0,
	    romans_brutii  = 1 << 1,
        romans_scipii = 1 << 2,
        egypt = 1 << 3,
        seleucid = 1 << 4,
        carthage = 1 << 5,
        parthia = 1 << 6,
        gauls = 1 << 7,
        germans = 1 << 8,
        britons = 1 << 9,
        greek_cities = 1 << 10,
        romans_senate = 1 << 11,
        macedon = 1 << 12,
        pontus = 1 << 13,
        armenia = 1 << 14,
        dacia = 1 << 15,
        numidia = 1 << 16,
        scythia = 1 << 17,
        spain = 1 << 18,
        thrace = 1 << 19,
        slave = 1 << 20,
        roman = 1 << 21,
        carthaginian = 1 << 22,
        greek = 1 << 23,
        egyptian = 1 << 24,
        eastern = 1 << 25,
        barbarian = 1 << 26,
        none = 1 << 27
    }

    [Flags]
    public enum M2TWFactionOwnership
    {
        england = 1 << 0,
        france = 1 << 1,
        hre = 1 << 2,
        spain = 1 << 3,
        venice = 1 << 4,
        sicily = 1 << 5,
        milan = 1 << 6,
        scotland = 1 << 7,
        byzantium = 1 << 8,
        russia = 1 << 9,
        moors = 1 << 10,
        turks = 1 << 11,
        egypt = 1 << 12,
        denmark = 1 << 13,
        portugal = 1 << 14,
        poland = 1 << 15,
        hungary = 1 << 16,
        papal_states = 1 << 17,
        aztecs = 1 << 18,
        mongols = 1 << 19,
        timurids = 1 << 20,
        slave = 1 << 21,
        //cultures
        northern_european = 1 << 22,
        eastern_european = 1 << 23,
        middle_eastern = 1 << 24,
        southern_european = 1 << 25,
        normans = 1 << 26,
        saxons = 1 << 27,
        greek = 1 << 28,
        none = 1 << 29,


    }

    public class Soldier 
    {
        public string name; // name of model
        public int number, extras; // number of troops and number of extras (like dogs)
        public float collisionMass; // the collision mass

        public Soldier()
        {
        }
    }

    public class MountEffect
    {
        public List<string> mountType;
        public List<int> modifier;

        public MountEffect()
        {
            mountType = new List<string>();
            modifier = new List<int>();
        }
    }

    public class Formation
    { 
        public float[] FormationTight;
	    public float[] FormationSparse;
	    public int FormationRanks;
        public FormationTypes FormationFlags;

        public Formation()
        {
            FormationTight = new float[2];
            FormationSparse = new float[2];
        }
    }

    public class StatWeapons
    {
        public int[] attack; //0, 1
        public MissleType missletypeFlags; // 2
        public int[] Missleattri; // 3, 4
        public WeaponType WeaponFlags; // 5
        public techType TechFlags; // 6
        public DamageType DamageFlags; // 7
        public SoundType SoundFlags; //  8
        public float[] attackdelay; //9, 10

        //m2tw only
        public string musketString;
        public M2TWAmmunition m2twammunitionflags;
        public M2TWtechType m2twTechType;

        public StatWeapons()
        {
            attack = new int[2];
            Missleattri = new int[2];
            attackdelay = new float[2];
        }
    }

    public class StatPriArmour
    {
        public int[] stat_pri_armour;
        public ArmourSound armour_sound; 

        public StatPriArmour()
        {
            stat_pri_armour = new int[3];
        }
    }

    public class StatSecArmour
    {
        public int[] stat_sec_armour;
        public ArmourSound sec_armour_sound;
    
        public StatSecArmour()
        {
            stat_sec_armour = new int[2];
        }

    }

    public class Mentality
    {
        public int morale;
        public statmental_discipline discipline;
        public statmental_training training;

        public Mentality()
        { }
    }

    [Serializable]
    public class Unit 
    {
        public string type; //internal name
        public string dictionary; //tag for finding screen name
        public string category; // infantry, cavalry, siege, handler, ship or non_combatant
        public string unitClass; // light, heavy, spearman, or missle
        public string voiceType; //voice of the unit
        public Soldier soldier; //see soldier class
        public List<string> officer; //name of the officer model (can be up to three)
        public string engine; //type of siege used ( ballista, scorpion, onager, heavy_onager, repeating_ballista)
        public string animal; // The type of non-ridden on animals used by the  wardogs, pigs
        public string mount; // mount used by the unit
        public string naval;
        public MountEffect mountEffect; //modifiers vs different mounts
        public Attributes attributes; //abilities of unit
        public Formation formation; // formation values
        public int[] heatlh; // hitpoints and mount hitpoints
        public StatWeapons primaryWeapon;
        public stat_pri_attr priAttri;
        public StatWeapons secondaryWeapon;
        public stat_pri_attr secAttri;
        public StatPriArmour primaryArmour;
        public StatSecArmour secondaryArmour;
        public int heat; //fatigue suffered by units in hot climate
        public int[] ground; //
        public Mentality mental;
        public int chargeDistance;
        public int fireDelay;
        public int[] food;
        public int[] cost;
        public FactionOwnership ownership;


        //M2TW ONLY for now most of these will not be randomised
        public int[] M2TWcost;
        public string stat_ter; //M2TW
        public string stat_ter_ex; //M2TW
        public string stat_ter_attr; //M2tw
        public string stat_armour_ex; //M2TW
        public string stat_pri_ex; // M2TW
        public string bannerFaction; //M2TW BANNER
        public string bannerHoly; //M2TW HOLY banner
        public string stat_sec_ex; //M2TW
        public string stat_stl; //M2TW
        public string armour_ug_levels;
        public string armour_ug_models;
        public string era0;
        public string era1;
        public string era2;
        public string info_pic_dir;
        public string card_pic_info;
        public string unit_info;
        public M2TWFactionOwnership M2TWOwnership;
        public M2TWAttributes M2TWAttributes;

		public float unitPointValue = 0;


        public Unit()
        {
            soldier = new Soldier();
            mountEffect = new MountEffect();
            formation = new Formation();
            primaryWeapon = new StatWeapons();
            secondaryWeapon = new StatWeapons();
            primaryArmour = new StatPriArmour();
            secondaryArmour = new StatSecArmour();
            mental = new Mentality();
            officer = new List<string>();
          
            heatlh = new int[2];
            ground = new int[4];
            food = new int[2];
            cost = new int[6];
            M2TWcost = new int[8];
        
        }

        public string unitOutput()
        {
            string unitString = "";

            unitString += (
                "type\t\t\t\t " + type + "\r\n" +
                "dictionary\t\t\t " + dictionary + "\r\n" +
                "category\t\t\t " + category + "\r\n" +
                "class\t\t\t\t " + unitClass + "\r\n" +
                "voice_type\t\t\t " + voiceType + "\r\n");

            if (Data.isM2TWMode)
            {
                if (bannerFaction != null)
                    unitString += "banner faction\t\t\t " + bannerFaction + "\r\n";
                if (bannerHoly != null)
                    unitString += "banner faction\t\t\t " + bannerHoly + "\r\n";
            }


            unitString += "soldier\t\t\t\t " + soldier.name + ", " + soldier.number.ToString() + ", " + soldier.extras.ToString() + ", " + soldier.collisionMass.ToString();

                //unitString +=("\r\n");

                if (engine != null)
                    unitString +=("\r\nengine\t\t\t " + engine);

                if (animal != null)
                    unitString +=("\r\nanimal\t\t\t " + animal);

                if (mount != null)
                    unitString +=("\r\nmount\t\t\t " + mount);

                if (officer.Count > 0)
                {
                    if (officer[0] != null)
                    {
                        unitString +=("\r\nofficer\t\t\t " + officer[0]);
                    }
                }

                if (officer.Count > 1)
                {
                    if (officer[1] != null)
                    {
                        unitString +=("\r\nofficer\t\t\t " + officer[1]);
                    }
                }

                if (officer.Count > 2)
                {
                    if (officer[2] != null)
                    {
                        unitString +=("\r\nofficer\t\t\t " + officer[2]);
                    }
                }

                if (naval != null)
                    unitString +=("\r\nship\t\t\t\t " + naval);

                unitString +=("\r\nattributes\t\t\t "); // write attributes

                bool firstAttr = false;

            if (Data.isRTWMode)
            {
                if (attributes.HasFlag(Attributes.sea_faring))
                {
                    if (!firstAttr)
                    {
                        firstAttr = true;
                    }

                    else unitString += (", ");

                    unitString += (enumsToStrings.AttributesToString(Attributes.sea_faring));
                }

                if (attributes.HasFlag(Attributes.can_run_amok))
                {
                    if (!firstAttr)
                    {
                        firstAttr = true;
                    }

                    else unitString += (", ");

                    unitString += (enumsToStrings.AttributesToString(Attributes.can_run_amok));

                }
                if (attributes.HasFlag(Attributes.can_sap))
                {
                    if (!firstAttr)
                    {
                        firstAttr = true;
                    }

                    else unitString += (", ");

                    unitString += (enumsToStrings.AttributesToString(Attributes.can_sap));
                }
                if (attributes.HasFlag(Attributes.cantabrian_circle))
                {
                    if (!firstAttr)
                    {
                        firstAttr = true;
                    }

                    else unitString += (", ");

                    unitString += (enumsToStrings.AttributesToString(Attributes.cantabrian_circle));
                }

                if (attributes.HasFlag(Attributes.command))
                {
                    if (!firstAttr)
                    {
                        firstAttr = true;
                    }

                    else unitString += (", ");

                    unitString += (enumsToStrings.AttributesToString(Attributes.command));
                }
                if (attributes.HasFlag(Attributes.druid))
                {
                    if (!firstAttr)
                    {
                        firstAttr = true;
                    }

                    else unitString += (", ");

                    unitString += (enumsToStrings.AttributesToString(Attributes.druid));
                }
                if (attributes.HasFlag(Attributes.frighten_foot))
                {
                    if (!firstAttr)
                    {
                        firstAttr = true;
                    }

                    else unitString += (", ");

                    unitString += (enumsToStrings.AttributesToString(Attributes.frighten_foot));
                }
                if (attributes.HasFlag(Attributes.frighten_mounted))
                {
                    if (!firstAttr)
                    {
                        firstAttr = true;
                    }

                    else unitString += (", ");

                    unitString += (enumsToStrings.AttributesToString(Attributes.frighten_mounted));
                }
                if (attributes.HasFlag(Attributes.general_unit))
                {
                    if (!firstAttr)
                    {
                        firstAttr = true;
                    }

                    else unitString += (", ");

                    unitString += (enumsToStrings.AttributesToString(Attributes.general_unit));
                }
                if (attributes.HasFlag(Attributes.general_unit_upgrade))
                {
                    if (!firstAttr)
                    {
                        firstAttr = true;
                    }

                    else unitString += (", ");

                    unitString += (enumsToStrings.AttributesToString(Attributes.general_unit_upgrade));
                }
                if (attributes.HasFlag(Attributes.hide_anywhere))
                {
                    if (!firstAttr)
                    {
                        firstAttr = true;
                    }

                    else unitString += (", ");

                    unitString += (enumsToStrings.AttributesToString(Attributes.hide_anywhere));
                }
                if (attributes.HasFlag(Attributes.hide_forest))
                {
                    if (!firstAttr)
                    {
                        firstAttr = true;
                    }

                    else unitString += (", ");

                    unitString += (enumsToStrings.AttributesToString(Attributes.hide_forest));
                }
                if (attributes.HasFlag(Attributes.hide_improved_forest))
                {
                    if (!firstAttr)
                    {
                        firstAttr = true;
                    }

                    else unitString += (", ");

                    unitString += (enumsToStrings.AttributesToString(Attributes.hide_improved_forest));
                }
                if (attributes.HasFlag(Attributes.hide_long_grass))
                {
                    if (!firstAttr)
                    {
                        firstAttr = true;
                    }

                    else unitString += (", ");

                    unitString += (enumsToStrings.AttributesToString(Attributes.hide_long_grass));
                }
                if (attributes.HasFlag(Attributes.mercenary_unit))
                {
                    if (!firstAttr)
                    {
                        firstAttr = true;
                    }

                    else unitString += (", ");

                    unitString += (enumsToStrings.AttributesToString(Attributes.mercenary_unit));
                }
                if (attributes.HasFlag(Attributes.no_custom))
                {
                    if (!firstAttr)
                    {
                        firstAttr = true;
                    }

                    else unitString += (", ");

                    unitString += (enumsToStrings.AttributesToString(Attributes.no_custom));
                }
                if (attributes.HasFlag(Attributes.warcry))
                {
                    if (!firstAttr)
                    {
                        firstAttr = true;
                    }

                    else unitString += (", ");

                    unitString += (enumsToStrings.AttributesToString(Attributes.warcry));
                }

            }

            if (Data.isM2TWMode)
            {
                if (M2TWAttributes.HasFlag(M2TWAttributes.sea_faring))
                {
                    if (!firstAttr)
                    {
                        firstAttr = true;
                    }

                    else unitString += (", ");

                    unitString += (enumsToStrings.M2TWAttributesToString(M2TWAttributes.sea_faring));
                }

                if (M2TWAttributes.HasFlag(M2TWAttributes.can_run_amok))
                {
                    if (!firstAttr)
                    {
                        firstAttr = true;
                    }

                    else unitString += (", ");

                    unitString += (enumsToStrings.M2TWAttributesToString(M2TWAttributes.can_run_amok));

                }
                if (M2TWAttributes.HasFlag(M2TWAttributes.can_sap))
                {
                    if (!firstAttr)
                    {
                        firstAttr = true;
                    }

                    else unitString += (", ");

                    unitString += (enumsToStrings.M2TWAttributesToString(M2TWAttributes.can_sap));
                }
                if (M2TWAttributes.HasFlag(M2TWAttributes.cantabrian_circle))
                {
                    if (!firstAttr)
                    {
                        firstAttr = true;
                    }

                    else unitString += (", ");

                    unitString += (enumsToStrings.M2TWAttributesToString(M2TWAttributes.cantabrian_circle));
                }

                if (M2TWAttributes.HasFlag(M2TWAttributes.command))
                {
                    if (!firstAttr)
                    {
                        firstAttr = true;
                    }

                    else unitString += (", ");

                    unitString += (enumsToStrings.M2TWAttributesToString(M2TWAttributes.command));
                }
                if (M2TWAttributes.HasFlag(M2TWAttributes.druid))
                {
                    if (!firstAttr)
                    {
                        firstAttr = true;
                    }

                    else unitString += (", ");

                    unitString += (enumsToStrings.M2TWAttributesToString(M2TWAttributes.druid));
                }
                if (M2TWAttributes.HasFlag(M2TWAttributes.frighten_foot))
                {
                    if (!firstAttr)
                    {
                        firstAttr = true;
                    }

                    else unitString += (", ");

                    unitString += (enumsToStrings.M2TWAttributesToString(M2TWAttributes.frighten_foot));
                }
                if (M2TWAttributes.HasFlag(M2TWAttributes.frighten_mounted))
                {
                    if (!firstAttr)
                    {
                        firstAttr = true;
                    }

                    else unitString += (", ");

                    unitString += (enumsToStrings.M2TWAttributesToString(M2TWAttributes.frighten_mounted));
                }
                if (M2TWAttributes.HasFlag(M2TWAttributes.general_unit))
                {
                    if (!firstAttr)
                    {
                        firstAttr = true;
                    }

                    else unitString += (", ");

                    unitString += (enumsToStrings.M2TWAttributesToString(M2TWAttributes.general_unit));
                }
                if (M2TWAttributes.HasFlag(M2TWAttributes.general_unit_upgrade))
                {
                    if (!firstAttr)
                    {
                        firstAttr = true;
                    }

                    else unitString += (", ");

                    unitString += (enumsToStrings.M2TWAttributesToString(M2TWAttributes.general_unit_upgrade));
                }
                if (M2TWAttributes.HasFlag(M2TWAttributes.hide_anywhere))
                {
                    if (!firstAttr)
                    {
                        firstAttr = true;
                    }

                    else unitString += (", ");

                    unitString += (enumsToStrings.M2TWAttributesToString(M2TWAttributes.hide_anywhere));
                }
                if (M2TWAttributes.HasFlag(M2TWAttributes.hide_forest))
                {
                    if (!firstAttr)
                    {
                        firstAttr = true;
                    }

                    else unitString += (", ");

                    unitString += (enumsToStrings.M2TWAttributesToString(M2TWAttributes.hide_forest));
                }
                if (M2TWAttributes.HasFlag(M2TWAttributes.hide_improved_forest))
                {
                    if (!firstAttr)
                    {
                        firstAttr = true;
                    }

                    else unitString += (", ");

                    unitString += (enumsToStrings.M2TWAttributesToString(M2TWAttributes.hide_improved_forest));
                }
                if (M2TWAttributes.HasFlag(M2TWAttributes.hide_long_grass))
                {
                    if (!firstAttr)
                    {
                        firstAttr = true;
                    }

                    else unitString += (", ");

                    unitString += (enumsToStrings.M2TWAttributesToString(M2TWAttributes.hide_long_grass));
                }
                if (M2TWAttributes.HasFlag(M2TWAttributes.mercenary_unit))
                {
                    if (!firstAttr)
                    {
                        firstAttr = true;
                    }

                    else unitString += (", ");

                    unitString += (enumsToStrings.M2TWAttributesToString(M2TWAttributes.mercenary_unit));
                }
                if (M2TWAttributes.HasFlag(M2TWAttributes.no_custom))
                {
                    if (!firstAttr)
                    {
                        firstAttr = true;
                    }

                    else unitString += (", ");

                    unitString += (enumsToStrings.M2TWAttributesToString(M2TWAttributes.no_custom));
                }
                if (M2TWAttributes.HasFlag(M2TWAttributes.warcry))
                {
                    if (!firstAttr)
                    {
                        firstAttr = true;
                    }

                    else unitString += (", ");

                    unitString += (enumsToStrings.M2TWAttributesToString(M2TWAttributes.warcry));
                }
                if (M2TWAttributes.HasFlag(M2TWAttributes.free_upkeep_unit))
                {
                    if (!firstAttr)
                    {
                        firstAttr = true;
                    }

                    else unitString += (", ");

                    unitString += (enumsToStrings.M2TWAttributesToString(M2TWAttributes.free_upkeep_unit));
                }

            }

            unitString +=("\r\n");

                unitString +=("formation\t\t\t "); // write formation
                foreach (float num in formation.FormationTight)
                    unitString +=(num.ToString() + ", ");
                foreach (float num in formation.FormationSparse)
                    unitString +=(num.ToString() + ", ");
                unitString +=(formation.FormationRanks + ", ");

                bool firstForm = false;

                if (formation.FormationFlags.HasFlag(FormationTypes.Formation_Phalanx))
                {
                    if (!firstForm)
                    {
                        firstForm = true;
                    }

                    else unitString +=(", ");

                    unitString +=(enumsToStrings.FormationTostring(FormationTypes.Formation_Phalanx));
                }

                if (formation.FormationFlags.HasFlag(FormationTypes.Formation_Testudo))
                {
                    if (!firstForm)
                    {
                        firstForm = true;
                    }

                    else unitString +=(", ");

                    unitString +=(enumsToStrings.FormationTostring(FormationTypes.Formation_Testudo));
                }
                if (formation.FormationFlags.HasFlag(FormationTypes.Formation_Schiltrom))
                {
                    if (!firstForm)
                    {
                        firstForm = true;
                    }

                    else unitString +=(", ");

                    unitString +=(enumsToStrings.FormationTostring(FormationTypes.Formation_Schiltrom));
                }
                if (formation.FormationFlags.HasFlag(FormationTypes.Formation_Horde))
                {
                    if (!firstForm)
                    {
                        firstForm = true;
                    }

                    else unitString +=(", ");


                    unitString +=(enumsToStrings.FormationTostring(FormationTypes.Formation_Horde));

                }
                if (formation.FormationFlags.HasFlag(FormationTypes.Formation_Square))
                {
                    if (!firstForm)
                    {
                        firstForm = true;
                    }

                    else unitString +=(", ");

                    unitString +=(enumsToStrings.FormationTostring(FormationTypes.Formation_Square));
                }
                if (formation.FormationFlags.HasFlag(FormationTypes.Formation_Wedge))
                {
                    if (!firstForm)
                    {
                        firstForm = true;
                    }

                    else unitString +=(", ");

                    unitString +=(enumsToStrings.FormationTostring(FormationTypes.Formation_Wedge));

                }

                unitString +=("\r\n");

                unitString +=("stat_health\t\t\t "); //write health
                bool firstHealth = false;
                foreach (int health in heatlh)
                {

                    if (!firstHealth)
                    {
                        firstHealth = true;
                    }

                    else unitString +=(", ");

                    unitString +=(health);

                }

                unitString +=("\r\n");

                unitString +=("stat_pri\t\t\t "); // write primary weapon

                foreach (int atk in primaryWeapon.attack)
                    unitString +=(atk + ", ");

            if (Data.isRTWMode)
            {
                unitString += (enumsToStrings.MissleTypeToString(primaryWeapon.missletypeFlags) + ", ");
                foreach (int miss in primaryWeapon.Missleattri)
                    unitString += (miss + ", ");
                unitString += (
                    enumsToStrings.WeaponTypeToString(primaryWeapon.WeaponFlags) + ", " +
                    enumsToStrings.TechTypeToString(primaryWeapon.TechFlags) + ", " +
                    enumsToStrings.DamageTypeToString(primaryWeapon.DamageFlags) + ", " +
                    enumsToStrings.SoundTypeToString(primaryWeapon.SoundFlags) + ", ");

            }

            if (Data.isM2TWMode)
            {
                unitString += (enumsToStrings.M2TWMissleTypeToString(primaryWeapon.m2twammunitionflags) + ", ");
                foreach (int miss in primaryWeapon.Missleattri)
                    unitString += (miss + ", ");
                unitString += (
                    enumsToStrings.WeaponTypeToString(primaryWeapon.WeaponFlags) + ", " +
                    enumsToStrings.M2TWTechTypeToString(primaryWeapon.m2twTechType) + ", " +
                    enumsToStrings.DamageTypeToString(primaryWeapon.DamageFlags) + ", " +
                    enumsToStrings.SoundTypeToString(primaryWeapon.SoundFlags) + ", ");


            }

            if (Data.isM2TWMode && primaryWeapon.musketString != null)
            {
                unitString += primaryWeapon.musketString + ", ";

            }

                bool firstattk = false;
                foreach (float atkd in primaryWeapon.attackdelay)
                {
                    if (!firstattk)
                    {
                        firstattk = true;
                    }

                    else unitString +=(", ");

                    unitString +=(atkd);
                }

                unitString +=("\r\n");

                unitString +=("stat_pri_attr\t\t "); //attributes

                bool attrFirst = false;

                if (priAttri.HasFlag(stat_pri_attr.ap))
                {
                    if (!attrFirst)
                    {
                        attrFirst = true;
                    }
					
                    else unitString +=(", ");


                    unitString +=(enumsToStrings.PriAttrToString(stat_pri_attr.ap));
                }

                if (priAttri.HasFlag(stat_pri_attr.bp))
                {
                    if (!attrFirst)
                    {
                        attrFirst = true;
                    }

                    else unitString +=(", ");


                    unitString +=(enumsToStrings.PriAttrToString(stat_pri_attr.bp));
                }
                if (priAttri.HasFlag(stat_pri_attr.pa_spear))
                {
                    if (!attrFirst)
                    {
                        attrFirst = true;
                    }

                    else unitString +=(", ");


                    unitString +=(enumsToStrings.PriAttrToString(stat_pri_attr.pa_spear));
                }
                if (priAttri.HasFlag(stat_pri_attr.long_pike))
                {
                    if (!attrFirst)
                    {
                        attrFirst = true;
                    }

                    else unitString +=(", ");


                    unitString +=(enumsToStrings.PriAttrToString(stat_pri_attr.long_pike));
                }
                if (priAttri.HasFlag(stat_pri_attr.short_pike))
                {
                    if (!attrFirst)
                    {
                        attrFirst = true;
                    }

                    else unitString +=(", ");


                    unitString +=(enumsToStrings.PriAttrToString(stat_pri_attr.short_pike));
                }
                if (priAttri.HasFlag(stat_pri_attr.prec))
                {
                    if (!attrFirst)
                    {
                        attrFirst = true;
                    }

                    else unitString +=(", ");


                    unitString +=(enumsToStrings.PriAttrToString(stat_pri_attr.prec));
                }
                if (priAttri.HasFlag(stat_pri_attr.pa_thrown))
                {
                    if (!attrFirst)
                    {
                        attrFirst = true;
                    }

                    else unitString +=(", ");


                    unitString +=(enumsToStrings.PriAttrToString(stat_pri_attr.pa_thrown));
                }
                if (priAttri.HasFlag(stat_pri_attr.launching))
                {
                    if (!attrFirst)
                    {
                        attrFirst = true;
                    }

                    else unitString +=(", ");


                    unitString +=(enumsToStrings.PriAttrToString(stat_pri_attr.launching));
                }
                if (priAttri.HasFlag(stat_pri_attr.area))
                {
                    if (!attrFirst)
                    {
                        attrFirst = true;
                    }

                    else unitString +=(", ");


                    unitString +=(enumsToStrings.PriAttrToString(stat_pri_attr.area));
                }

                if (priAttri.HasFlag(stat_pri_attr.PA_no))
                {
                    if (!attrFirst)
                    {
                        attrFirst = true;
                    }

                    else unitString +=(", ");


                    unitString +=(enumsToStrings.PriAttrToString(stat_pri_attr.PA_no));
                }

                if (priAttri.HasFlag(stat_pri_attr.spear_bonus_4))
                {
                    if (!attrFirst)
                    {
                        attrFirst = true;
                    }

                    else unitString +=(", ");


                    unitString +=(enumsToStrings.PriAttrToString(stat_pri_attr.spear_bonus_4));
                }

                if (priAttri.HasFlag(stat_pri_attr.spear_bonus_8))
                {
                    if (!attrFirst)
                    {
                        attrFirst = true;
                    }

                    else unitString +=(", ");


                    unitString +=(enumsToStrings.PriAttrToString(stat_pri_attr.spear_bonus_8));
                }

                if (priAttri.HasFlag(stat_pri_attr.thrown_ap))
                {
                    if (!attrFirst)
                    {
                        attrFirst = true;
                    }

                    else unitString +=(", ");


                    unitString +=(enumsToStrings.PriAttrToString(stat_pri_attr.thrown_ap));
                }

                if (priAttri.HasFlag(stat_pri_attr.fire))
                {
                    if (!attrFirst)
                    {
                        attrFirst = true;
                    }

                    else unitString +=(", ");


                    unitString +=(enumsToStrings.PriAttrToString(stat_pri_attr.fire));
                }

                unitString +=("\r\n");

            if (Data.isM2TWMode)
            {
                if (stat_pri_ex != null)
                    unitString += "stat_pri_ex\t\t\t " + stat_pri_ex + "\r\n";

            } 

                unitString +=("stat_sec\t\t\t "); // secondary weapon
                foreach (int atk in secondaryWeapon.attack)
                    unitString +=(atk + ", ");

            if (Data.isRTWMode)
            {
                unitString += (enumsToStrings.MissleTypeToString(secondaryWeapon.missletypeFlags) + ", ");
                foreach (int miss in secondaryWeapon.Missleattri)
                    unitString += (miss + ", ");
                unitString += (
                    enumsToStrings.WeaponTypeToString(secondaryWeapon.WeaponFlags) + ", " +
                    enumsToStrings.TechTypeToString(secondaryWeapon.TechFlags) + ", " +
                    enumsToStrings.DamageTypeToString(secondaryWeapon.DamageFlags) + ", " +
                    enumsToStrings.SoundTypeToString(secondaryWeapon.SoundFlags) + ", ");

            }

            if (Data.isM2TWMode)
            {
                unitString += (enumsToStrings.M2TWMissleTypeToString(secondaryWeapon.m2twammunitionflags) + ", ");
                foreach (int miss in secondaryWeapon.Missleattri)
                    unitString += (miss + ", ");
                unitString += (
                    enumsToStrings.WeaponTypeToString(secondaryWeapon.WeaponFlags) + ", " +
                    enumsToStrings.M2TWTechTypeToString(secondaryWeapon.m2twTechType) + ", " +
                    enumsToStrings.DamageTypeToString(secondaryWeapon.DamageFlags) + ", " +
                    enumsToStrings.SoundTypeToString(secondaryWeapon.SoundFlags) + ", ");


            }

                bool firstatkD = false;
                foreach (float atkd in secondaryWeapon.attackdelay)
                {
                    if (!firstatkD)
                    {
                        firstatkD = true;
                    }

                    else unitString +=(", ");


                    unitString +=(atkd);

                }

            if (Data.isM2TWMode)
            {
                if (stat_sec_ex != null)
                    unitString += "\r\n" + "stat_sec_ex\t\t\t " + stat_sec_ex;
            }
                
                unitString +=("\r\n");

                bool firstsecAttr = false;
                unitString +=("stat_sec_attr\t\t ");
                if (secAttri.HasFlag(stat_pri_attr.ap))
                {
                    if (!firstsecAttr)
                    {
                        firstsecAttr = true;
                    }

                    else unitString +=(", ");

                    unitString +=(enumsToStrings.PriAttrToString(stat_pri_attr.ap));
                }
                if (secAttri.HasFlag(stat_pri_attr.bp))
                {
                    if (!firstsecAttr)
                    {
                        firstsecAttr = true;
                    }

                    else unitString +=(", ");

                    unitString +=(enumsToStrings.PriAttrToString(stat_pri_attr.bp));
                }
                if (secAttri.HasFlag(stat_pri_attr.pa_spear))
                {
                    if (!firstsecAttr)
                    {
                        firstsecAttr = true;
                    }

                    else unitString +=(", ");

                    unitString +=(enumsToStrings.PriAttrToString(stat_pri_attr.pa_spear));
                }
                if (secAttri.HasFlag(stat_pri_attr.long_pike))
                {
                    if (!firstsecAttr)
                    {
                        firstsecAttr = true;
                    }

                    else unitString +=(", ");

                    unitString +=(enumsToStrings.PriAttrToString(stat_pri_attr.long_pike));
                }
                if (secAttri.HasFlag(stat_pri_attr.short_pike))
                {
                    if (!firstsecAttr)
                    {
                        firstsecAttr = true;
                    }

                    else unitString +=(", ");

                    unitString +=(enumsToStrings.PriAttrToString(stat_pri_attr.short_pike));
                }
                if (secAttri.HasFlag(stat_pri_attr.prec))
                {
                    if (!firstsecAttr)
                    {
                        firstsecAttr = true;
                    }

                    else unitString +=(", ");

                    unitString +=(enumsToStrings.PriAttrToString(stat_pri_attr.prec));
                }
                if (secAttri.HasFlag(stat_pri_attr.pa_thrown))
                {
                    if (!firstsecAttr)
                    {
                        firstsecAttr = true;
                    }

                    else unitString +=(", ");

                    unitString +=(enumsToStrings.PriAttrToString(stat_pri_attr.pa_thrown));
                }
                if (secAttri.HasFlag(stat_pri_attr.launching))
                {
                    if (!firstsecAttr)
                    {
                        firstsecAttr = true;
                    }

                    else unitString +=(", ");

                    unitString +=(enumsToStrings.PriAttrToString(stat_pri_attr.launching));
                }
                if (secAttri.HasFlag(stat_pri_attr.area))
                {
                    if (!firstsecAttr)
                    {
                        firstsecAttr = true;
                    }

                    else unitString +=(", ");

                    unitString +=(enumsToStrings.PriAttrToString(stat_pri_attr.area));
                }
                if (secAttri.HasFlag(stat_pri_attr.PA_no))
                {
                    if (!firstsecAttr)
                    {
                        firstsecAttr = true;
                    }

                    else unitString +=(", ");

                    unitString +=(enumsToStrings.PriAttrToString(stat_pri_attr.PA_no));
                }

                if (secAttri.HasFlag(stat_pri_attr.fire))
                {
                    if (!firstsecAttr)
                    {
                        firstsecAttr = true;
                    }

                    else unitString +=(", ");


                    unitString +=(enumsToStrings.PriAttrToString(stat_pri_attr.fire));
                }

                unitString +=("\r\n");

            if (Data.isM2TWMode)
            {
                if (stat_ter != null)
                    unitString += ("stat_ter\t\t\t " + stat_ter + "\r\n");
                if (stat_ter_ex != null)
                    unitString += ("stat_ter_ex\t\t\t " + stat_ter_ex + "\r\n");
                if (stat_ter_attr != null)
                    unitString += ("stat_ter_attr\t\t\t " + stat_ter_attr + "\r\n");
                
            }

                unitString +=("stat_pri_armour\t\t ");
                foreach (int numb in primaryArmour.stat_pri_armour)
                    unitString +=(numb + ", ");
                unitString +=(enumsToStrings.ArmourSndToString(primaryArmour.armour_sound));

                unitString +=("\r\n");

            if (Data.isM2TWMode)
            {
                if (stat_armour_ex != null)
                    unitString += "stat_armour_ex\t\t\t " + stat_armour_ex + "\r\n";

            }

                unitString +=("stat_sec_armour\t\t ");
                foreach (int numb in secondaryArmour.stat_sec_armour)
                    unitString +=(numb + ", ");
                unitString +=(enumsToStrings.ArmourSndToString(secondaryArmour.sec_armour_sound));

                unitString +=("\r\n");

                unitString +=("stat_heat\t\t\t " + heat);

                unitString +=("\r\n");

                unitString +=("stat_ground\t\t\t ");
                bool firstGround = false;
                foreach (int numb in ground)
                {
                    if (!firstGround)
                    {
                        firstGround = true;
                    }

                    else unitString +=(", ");

                    unitString +=(numb);
                }

                unitString +=("\r\n");

                unitString +=("stat_mental\t\t\t " + mental.morale + ", ");
                unitString +=(enumsToStrings.DisciplineToString(mental.discipline) + ", " + enumsToStrings.TrainingToString(mental.training));

                unitString +=("\r\n");

                unitString +=("stat_charge_dist\t " + chargeDistance);

                unitString +=("\r\n");

                unitString +=("stat_fire_delay\t\t " + fireDelay);

                unitString +=("\r\n");

                unitString +=("stat_food\t\t\t " + food[0] + ", " + food[1]);

                unitString +=("\r\n");

                unitString +=("stat_cost\t\t\t ");
                bool firstCost = false;
            if (Data.isRTWMode)
            {
                foreach (int cost in cost)
                {
                    if (!firstCost)
                    {
                        firstCost = true;
                    }

                    else unitString += (", ");

                    unitString += (cost);
                }
            }

            if(Data.isM2TWMode)
            {
                foreach (int cost in M2TWcost)
                {
                    if (!firstCost)
                    {
                        firstCost = true;
                    }

                    else unitString += (", ");

                    unitString += (cost);
                }


            }

                unitString +=("\r\n");

            if (Data.isM2TWMode)
            {
                if (stat_stl != null)
                    unitString += "stat_stl\t\t\t " + stat_stl + "\r\n";
                if (armour_ug_levels != null)
                    unitString += "armour_ug_levels\t\t\t " + armour_ug_levels + "\r\n";
                if (armour_ug_models != null)
                    unitString += "armour_ug_models\t\t\t " + armour_ug_models + "\r\n";

            }

                unitString +=("ownership\t\t\t ");

                bool firstStatOwnership = false;

            if (Data.isRTWMode)
            {
                if (ownership.HasFlag(FactionOwnership.armenia))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else unitString += (", ");

                    unitString += (enumsToStrings.FactionToString(FactionOwnership.armenia));

                }
                if (ownership.HasFlag(FactionOwnership.britons))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else unitString += (", ");
                    unitString += (enumsToStrings.FactionToString(FactionOwnership.britons));
                }
                if (ownership.HasFlag(FactionOwnership.carthage))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else unitString += (", ");

                    unitString += (enumsToStrings.FactionToString(FactionOwnership.carthage));
                }
                if (ownership.HasFlag(FactionOwnership.carthaginian))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else unitString += (", ");
                    unitString += (enumsToStrings.FactionToString(FactionOwnership.carthaginian));
                }
                if (ownership.HasFlag(FactionOwnership.dacia))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else unitString += (", ");

                    unitString += (enumsToStrings.FactionToString(FactionOwnership.dacia));
                }
                if (ownership.HasFlag(FactionOwnership.eastern))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else unitString += (", ");

                    unitString += (enumsToStrings.FactionToString(FactionOwnership.eastern));
                }
                if (ownership.HasFlag(FactionOwnership.egypt))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else unitString += (", ");

                    unitString += (enumsToStrings.FactionToString(FactionOwnership.egypt));
                }
                if (ownership.HasFlag(FactionOwnership.egyptian))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else unitString += (", ");
                    unitString += (enumsToStrings.FactionToString(FactionOwnership.egyptian));
                }
                if (ownership.HasFlag(FactionOwnership.gauls))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else unitString += (", ");
                    unitString += (enumsToStrings.FactionToString(FactionOwnership.gauls));
                }
                if (ownership.HasFlag(FactionOwnership.germans))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else unitString += (", ");
                    unitString += (enumsToStrings.FactionToString(FactionOwnership.germans));
                }
                if (ownership.HasFlag(FactionOwnership.greek))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else unitString += (", ");
                    unitString += (enumsToStrings.FactionToString(FactionOwnership.greek));
                }
                if (ownership.HasFlag(FactionOwnership.greek_cities))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else unitString += (", ");
                    unitString += (enumsToStrings.FactionToString(FactionOwnership.greek_cities));
                }
                if (ownership.HasFlag(FactionOwnership.macedon))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else unitString += (", ");
                    unitString += (enumsToStrings.FactionToString(FactionOwnership.macedon));
                }
                if (ownership.HasFlag(FactionOwnership.none))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else unitString += (", ");
                    unitString += (enumsToStrings.FactionToString(FactionOwnership.none));
                }
                if (ownership.HasFlag(FactionOwnership.numidia))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else unitString += (", ");
                    unitString += (enumsToStrings.FactionToString(FactionOwnership.numidia));
                }
                if (ownership.HasFlag(FactionOwnership.parthia))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else unitString += (", ");
                    unitString += (enumsToStrings.FactionToString(FactionOwnership.parthia));
                }
                if (ownership.HasFlag(FactionOwnership.pontus))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else unitString += (", ");
                    unitString += (enumsToStrings.FactionToString(FactionOwnership.pontus));
                }
                if (ownership.HasFlag(FactionOwnership.roman))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else unitString += (", ");
                    unitString += (enumsToStrings.FactionToString(FactionOwnership.roman));
                }
                if (ownership.HasFlag(FactionOwnership.romans_brutii))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else unitString += (", ");
                    unitString += (enumsToStrings.FactionToString(FactionOwnership.romans_brutii));
                }
                if (ownership.HasFlag(FactionOwnership.romans_julii))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else unitString += (", ");
                    unitString += (enumsToStrings.FactionToString(FactionOwnership.romans_julii));
                }
                if (ownership.HasFlag(FactionOwnership.romans_scipii))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else unitString += (", ");
                    unitString += (enumsToStrings.FactionToString(FactionOwnership.romans_scipii));
                }
                if (ownership.HasFlag(FactionOwnership.romans_senate))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else unitString += (", ");
                    unitString += (enumsToStrings.FactionToString(FactionOwnership.romans_senate));
                }
                if (ownership.HasFlag(FactionOwnership.scythia))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else unitString += (", ");
                    unitString += (enumsToStrings.FactionToString(FactionOwnership.scythia));
                }
                if (ownership.HasFlag(FactionOwnership.seleucid))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else unitString += (", ");
                    unitString += (enumsToStrings.FactionToString(FactionOwnership.seleucid));
                }
                if (ownership.HasFlag(FactionOwnership.slave))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else unitString += (", ");
                    unitString += (enumsToStrings.FactionToString(FactionOwnership.slave));
                }
                if (ownership.HasFlag(FactionOwnership.spain))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else unitString += (", ");
                    unitString += (enumsToStrings.FactionToString(FactionOwnership.spain));
                }
                if (ownership.HasFlag(FactionOwnership.thrace))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else unitString += (", ");
                    unitString += (enumsToStrings.FactionToString(FactionOwnership.thrace));
                }
                if (ownership.HasFlag(FactionOwnership.barbarian))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else unitString += (", ");
                    unitString += (enumsToStrings.FactionToString(FactionOwnership.barbarian));
                }

            }

            if (Data.isM2TWMode) //
            {
                if (M2TWOwnership.HasFlag(M2TWFactionOwnership.aztecs))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else unitString += (", ");

                    unitString += (enumsToStrings.M2TWFactionToString(M2TWFactionOwnership.aztecs));

                }
                if (M2TWOwnership.HasFlag(M2TWFactionOwnership.byzantium))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else unitString += (", ");
                    unitString += (enumsToStrings.M2TWFactionToString(M2TWFactionOwnership.byzantium));
                }
                if (M2TWOwnership.HasFlag(M2TWFactionOwnership.denmark))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else unitString += (", ");

                    unitString += (enumsToStrings.M2TWFactionToString(M2TWFactionOwnership.denmark));
                }
                if (M2TWOwnership.HasFlag(M2TWFactionOwnership.eastern_european))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else unitString += (", ");
                    unitString += (enumsToStrings.M2TWFactionToString(M2TWFactionOwnership.eastern_european));
                }
                if (M2TWOwnership.HasFlag(M2TWFactionOwnership.egypt))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else unitString += (", ");

                    unitString += (enumsToStrings.M2TWFactionToString(M2TWFactionOwnership.egypt));
                }
                if (M2TWOwnership.HasFlag(M2TWFactionOwnership.england))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else unitString += (", ");

                    unitString += (enumsToStrings.M2TWFactionToString(M2TWFactionOwnership.england));
                }
                if (M2TWOwnership.HasFlag(M2TWFactionOwnership.france))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else unitString += (", ");

                    unitString += (enumsToStrings.M2TWFactionToString(M2TWFactionOwnership.france));
                }
                if (M2TWOwnership.HasFlag(M2TWFactionOwnership.greek))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else unitString += (", ");
                    unitString += (enumsToStrings.M2TWFactionToString(M2TWFactionOwnership.greek));
                }
                if (M2TWOwnership.HasFlag(M2TWFactionOwnership.hre))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else unitString += (", ");
                    unitString += (enumsToStrings.M2TWFactionToString(M2TWFactionOwnership.hre));
                }
                if (M2TWOwnership.HasFlag(M2TWFactionOwnership.hungary))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else unitString += (", ");
                    unitString += (enumsToStrings.M2TWFactionToString(M2TWFactionOwnership.hungary));
                }
                if (M2TWOwnership.HasFlag(M2TWFactionOwnership.middle_eastern))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else unitString += (", ");
                    unitString += (enumsToStrings.M2TWFactionToString(M2TWFactionOwnership.middle_eastern));
                }
                if (M2TWOwnership.HasFlag(M2TWFactionOwnership.milan))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else unitString += (", ");
                    unitString += (enumsToStrings.M2TWFactionToString(M2TWFactionOwnership.milan));
                }
                if (M2TWOwnership.HasFlag(M2TWFactionOwnership.mongols))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else unitString += (", ");
                    unitString += (enumsToStrings.M2TWFactionToString(M2TWFactionOwnership.mongols));
                }
                if (M2TWOwnership.HasFlag(M2TWFactionOwnership.none))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else unitString += (", ");
                    unitString += (enumsToStrings.M2TWFactionToString(M2TWFactionOwnership.none));
                }
                if (M2TWOwnership.HasFlag(M2TWFactionOwnership.moors))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else unitString += (", ");
                    unitString += (enumsToStrings.M2TWFactionToString(M2TWFactionOwnership.moors));
                }
                if (M2TWOwnership.HasFlag(M2TWFactionOwnership.normans))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else unitString += (", ");
                    unitString += (enumsToStrings.M2TWFactionToString(M2TWFactionOwnership.normans));
                }
                if (M2TWOwnership.HasFlag(M2TWFactionOwnership.northern_european))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else unitString += (", ");
                    unitString += (enumsToStrings.M2TWFactionToString(M2TWFactionOwnership.northern_european));
                }
                if (M2TWOwnership.HasFlag(M2TWFactionOwnership.papal_states))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else unitString += (", ");
                    unitString += (enumsToStrings.M2TWFactionToString(M2TWFactionOwnership.papal_states));
                }
                if (M2TWOwnership.HasFlag(M2TWFactionOwnership.poland))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else unitString += (", ");
                    unitString += (enumsToStrings.M2TWFactionToString(M2TWFactionOwnership.poland));
                }
                if (M2TWOwnership.HasFlag(M2TWFactionOwnership.portugal))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else unitString += (", ");
                    unitString += (enumsToStrings.M2TWFactionToString(M2TWFactionOwnership.portugal));
                }
                if (M2TWOwnership.HasFlag(M2TWFactionOwnership.russia))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else unitString += (", ");
                    unitString += (enumsToStrings.M2TWFactionToString(M2TWFactionOwnership.russia));
                }
                if (M2TWOwnership.HasFlag(M2TWFactionOwnership.saxons))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else unitString += (", ");
                    unitString += (enumsToStrings.M2TWFactionToString(M2TWFactionOwnership.saxons));
                }
                if (M2TWOwnership.HasFlag(M2TWFactionOwnership.scotland))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else unitString += (", ");
                    unitString += (enumsToStrings.M2TWFactionToString(M2TWFactionOwnership.scotland));
                }
                if (M2TWOwnership.HasFlag(M2TWFactionOwnership.sicily))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else unitString += (", ");
                    unitString += (enumsToStrings.M2TWFactionToString(M2TWFactionOwnership.sicily));
                }
                if (M2TWOwnership.HasFlag(M2TWFactionOwnership.slave))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else unitString += (", ");
                    unitString += (enumsToStrings.M2TWFactionToString(M2TWFactionOwnership.slave));
                }
                if (M2TWOwnership.HasFlag(M2TWFactionOwnership.southern_european))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else unitString += (", ");
                    unitString += (enumsToStrings.M2TWFactionToString(M2TWFactionOwnership.southern_european));
                }
                if (M2TWOwnership.HasFlag(M2TWFactionOwnership.spain))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else unitString += (", ");
                    unitString += (enumsToStrings.M2TWFactionToString(M2TWFactionOwnership.spain));
                }
                if (M2TWOwnership.HasFlag(M2TWFactionOwnership.timurids))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else unitString += (", ");
                    unitString += (enumsToStrings.M2TWFactionToString(M2TWFactionOwnership.timurids));
                }
                if (M2TWOwnership.HasFlag(M2TWFactionOwnership.turks))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else unitString += (", ");
                    unitString += (enumsToStrings.M2TWFactionToString(M2TWFactionOwnership.turks));
                }

                if (M2TWOwnership.HasFlag(M2TWFactionOwnership.venice))
                {
                    if (!firstStatOwnership)
                    {
                        firstStatOwnership = true;
                    }

                    else unitString += (", ");
                    unitString += (enumsToStrings.M2TWFactionToString(M2TWFactionOwnership.venice));
                }
            }

            if (Data.isM2TWMode)
            {
                if (era0 != null)
                    unitString += "era 0\t\t\t\t " + era0 + "\r\n";
                if (era1 != null)
                    unitString += "era 1\t\t\t\t " + era1 + "\r\n";
                if (era2 != null)
                    unitString += "era 2\t\t\t\t " + era2 + "\r\n";
                if (info_pic_dir != null)
                    unitString += "info_pic_dir\t\t\t\t " + info_pic_dir + "\r\n";
                if (card_pic_info != null)
                    unitString += "card_pic_info\t\t\t\t " + card_pic_info + "\r\n";
                if (unit_info != null)
                    unitString += "unit_info\t\t\t\t " + unit_info + "\r\n";
            }

            unitString +=("\r\n\n");

            return unitString;
        }

    }

    public class EDB
    {
        public List<string> hiddenResources = new List<string>();
        public List<coreBuilding> buildingTrees = new List<coreBuilding>();

        public EDB()
        {
        }

        public string outputEDB()
        {
            string a = "";

            a += "hidden_resources ";

            foreach (string resource in hiddenResources)
            {
                a += resource + " ";

            }

            a += "\r\n\r\n";

            foreach (coreBuilding cBuilding in buildingTrees)
            {
                a += cBuilding.outputCoreBuilding() + "\r\n";
            }

            return a;
        }

    }

    public class coreBuilding
    {
        public string buildingType; //eg. "core_building"
        public List<string> levels = new List<string>();
        public List<Building> buildings = new List<Building>();
        public string CBconvert_to;

        public coreBuilding()
        { }


        public string outputCoreBuilding()
        {
            string a = "";

            a += "building " + buildingType + "\r\n"
                + "{" + "\r\n";

            if (Data.isM2TWMode)
                a += Data.EDBTabSpacers[0] + "convert_to " + CBconvert_to + "\r\n";

               a += Data.EDBTabSpacers[0] + "levels ";

            foreach (string level in levels)
            {
                a += level + " ";

            }

            a += "\r\n" + Data.EDBTabSpacers[0] + "{" + "\r\n";

            foreach (Building building in buildings)
            {
                a += building.outputBuilding();

            }

            a += Data.EDBTabSpacers[0] + "}" + "\r\n";

            a += Data.EDBTabSpacers[0] + "plugins" + "\r\n"
                + Data.EDBTabSpacers[0] + "{" + "\r\n"
                + Data.EDBTabSpacers[0] + "}" + "\r\n"
                + "}"; 

            return a;
        }

    }

    public class Building
    {
        
        public string buildingName; //eg governors_house
        public List<string> factionsRequired = new List<string>();
        public Bcapability capability;
        public Fcapability fcapability;
        public Bconstruction construction;
        public string Bconvert_to;
        public string material;

        public Building()
        {

        }

        public Building(Building b)
        {
            buildingName = b.buildingName;
            factionsRequired = new List<string>(b.factionsRequired);
            capability = b.capability;
            construction = b.construction;
            Bconvert_to = b.Bconvert_to;
            fcapability = b.fcapability;
            material = b.material;
        }


        public string outputBuilding()
        {
            string a = "";

            a += Data.EDBTabSpacers[1] + buildingName + " requires factions { ";

            foreach (string faction in factionsRequired)
            {
                a += faction + ", ";
            }

            a += "}" + "\r\n"
                + Data.EDBTabSpacers[1] + "{" + "\r\n";
            if (Bconvert_to != null)
                a += Data.EDBTabSpacers[2] + "convert_to " + Bconvert_to + "\r\n";

            a += capability.outputCapability();

            if (fcapability != null)
                a += fcapability.outputFcapa();

            if (material != null)
                a += Data.EDBTabSpacers[2] + "material " + material + "\r\n";

            a += construction.outputConstruction();
            a += Data.EDBTabSpacers[1] + "}" + "\r\n";

            return a;

        }


    }

    public class Bcapability
    {
        public List<Brecruit> canRecruit = new List<Brecruit>();
        public List<string> agentList = new List<string>();
        public List<string> effectList = new List<string>();

        public Bcapability()
        { }

        public string outputCapability()
        {
            string a = "";

            a += Data.EDBTabSpacers[2] + "capability" + "\r\n"
                + Data.EDBTabSpacers[2] + "{" + "\r\n";

            foreach (Brecruit recruit in canRecruit)
            {
                a += recruit.outputRecruit() + "\r\n";

            }

            foreach (string agent in agentList)
            {
                a += Data.EDBTabSpacers[3] + agent + "\r\n";

            }

            foreach (string eff in effectList)
            {
                a += Data.EDBTabSpacers[3] + eff + "\r\n";
            }

            a += Data.EDBTabSpacers[2] + "}" + "\r\n";

            return a;

        }

    }

    public class Fcapability
    {
        public List<string> effectList = new List<string>();

        public Fcapability()
        {




        }

        public string outputFcapa()
        {
            string a = "";

            a += Data.EDBTabSpacers[2] + "faction_capability" + "\r\n"
                + Data.EDBTabSpacers[2] + "{" + "\r\n";

          
            foreach (string eff in effectList)
            {
                a += Data.EDBTabSpacers[3] + eff + "\r\n";
            }

            a += Data.EDBTabSpacers[2] + "}" + "\r\n";

            return a;



        }

    }

    public class Brecruit
    {
        public string name; //eg. carthaginian peasant
        public int experience;
        public int startingPoints;
        public double pointBuildingGains;
        public double maximumPoints;
        public List<string> requiresFactions = new List<string>();

        public Brecruit()
        {

        }

        public string outputRecruit()
        {
            string a = "";

            if(Data.isRTWMode)
                a += Data.EDBTabSpacers[3] + "recruit " + "\"" + name + "\"" + "  " + experience.ToString() + "  " + "requires factions " + "{ ";
            else if(Data.isM2TWMode)
                a += Data.EDBTabSpacers[3] + "recruit_pool " + "\"" + name + "\"" + "  " + startingPoints.ToString() + "  " + pointBuildingGains.ToString() + "  " + maximumPoints.ToString() + "  " + experience.ToString() + "  " + "requires factions " + "{ ";

            foreach (string faction in requiresFactions)
            {
                a += faction + ", ";

            }

            a += " }";

            return a;
        }


    }

    public class Bconstruction
    {
        public int turnsToBuild;
        public int cost;
        public string settlement_min;
        public List<string> upgrades = new List<string>();

        public Bconstruction()
        {


        }


        public string outputConstruction()
        {
            string a = "";

            a += Data.EDBTabSpacers[2] + "construction  " + turnsToBuild.ToString() + "\r\n"
                + Data.EDBTabSpacers[2] + "cost  " + cost.ToString() + "\r\n"
                + Data.EDBTabSpacers[2] + "settlement_min " + settlement_min + "\r\n"
                + Data.EDBTabSpacers[2] + "upgrades" + "\r\n"
                + Data.EDBTabSpacers[2] + "{" + "\r\n";

            foreach (string upgrade in upgrades)
            {
                a += Data.EDBTabSpacers[3] + upgrade + "\r\n";

            }

            a += Data.EDBTabSpacers[2] + "}" + "\r\n";

            return a;

        }

    }

    public class Character
    {
        public string info;
        public string spacer = "  ->>>>  ";
        public int x;
        public int y;

        public Character(string line)
        {
            info = line;
        }

    }

    public class Region
    {
        public string name ="";
        public int r=0, g=0, b=0;
        public int x=0, y =0;

        public Region(string n, int red, int green, int blue)
        {
            name = n;
            r = red;
            g = green;
            b = blue;

        }

        public Region()
        { }

    }

    public class Settlement
    {
        public List<string> b_types = new List<string>();

        string plan_set = "default_set";
        public string s_level, region, faction_creator;

        int yearFounded, population;

        public Settlement(string level, string reg, string creator, List<string> buildings, int yrFounded, int pop)
        {
            s_level = level;
            region = reg;
            faction_creator = creator;
            yearFounded = yrFounded;
            population = pop;
            b_types = buildings;


        }

        public string outputSettlement()
        {

            string settlement =
                "\r\nsettlement" +
                "\r\n{" +
                "\r\n\t" + "level " + s_level +
                "\r\n\t" + "region " + region +
                "\r\n\t" + "year_founded " + Convert.ToString(yearFounded) +
                "\r\n\t" + "population " + Convert.ToString(population) +
                "\r\n\t" + "plan_set " + plan_set +
                "\r\n\t" + "faction_creator " + faction_creator;

            foreach (string b in b_types)
            {
                settlement +=
                    "\r\n\t" + "building" +
                    "\r\n\t" + "{" +
                    "\r\n\t\t" + "type " + b +
                    "\r\n\t" + "}" +
                    "\r\n"; 
            }

            settlement += "\r\n}";

            return settlement;

        }



    }

    public class UnitFaction
    {
        public string dicName;
        public List<string> factions = new List<string>();

        public UnitFaction()
        { }

        public UnitFaction(UnitFaction uf)
        {
            dicName = uf.dicName;

            factions = new List<string>(uf.factions);
        }


    }

	public static class FactionRosters
	{
		static public Dictionary<FactionOwnership, List<Unit>> RTWrosters = new Dictionary<FactionOwnership, List<Unit>>();
		static public Dictionary<M2TWFactionOwnership, List<Unit>> M2TWRosters = new Dictionary<M2TWFactionOwnership, List<Unit>>();

		static public void AddUnitsToFaction(List<Unit> units, FactionOwnership faction)
		{
			RTWrosters[faction] = units;
		}

		static public void AddUnitToFaction(List<Unit> units, M2TWFactionOwnership faction)
		{
			M2TWRosters[faction] = units;
		}

		static public void AddFactionKey(FactionOwnership faction)
		{
			if(!RTWrosters.ContainsKey(faction))
				RTWrosters.Add(faction, new List<Unit>());
		}

		static public void AddFactionKey(M2TWFactionOwnership faction)
		{
			M2TWRosters.Add(faction, new List<Unit>());
		}

	}

}

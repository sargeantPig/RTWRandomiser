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
        warcry = 1 << 16
    }

    [Flags]
    public enum FormationTypes
    {

        Formation_Phalanx = 1 << 0,
        Formation_Testudo = 1 << 1,
        Formation_Schiltrom = 1 << 2,
        Formation_Horde = 1 << 3,
        Formation_Square = 1 << 4,
        Formation_Wedge = 1 << 5
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
        PA_no = 1 << 10
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
        parthian = 1 << 26,
        barbarian = 1 << 27,
        numidian = 1 << 28,
        none = 1 << 29
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
        public string animal; // The type of non-ridden on animals used by the unit. wardogs, pigs
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
        
        }

    }



    public class Capability
    {
        List<string> recruit;
        int value;
        List<string> FactionRecruit;

    }

    public class Building
    {
        string buildingName;
        List<string> levels;
        List<string> factionsRequired;


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

    

}

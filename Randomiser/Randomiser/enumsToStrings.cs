using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomiser
{
    static class enumsToStrings
    {
        static public FactionOwnership StringToFaction(string str)
        {
            FactionOwnership faction = FactionOwnership.none;

            switch (str)
            {
                case "roman":
                    faction = FactionOwnership.roman;
                    break;

                case "romans_julii":
                    faction = FactionOwnership.romans_julii | FactionOwnership.roman;
                    break;

                case "romans_brutii":
                    faction = FactionOwnership.romans_brutii | FactionOwnership.roman;
                    break;

                case "romans_scipii":
                    faction = FactionOwnership.romans_scipii | FactionOwnership.roman;
                    break;
                case "egypt":
                    faction = FactionOwnership.egypt | FactionOwnership.egyptian;
                    break;
                case "seleucid":
                    faction = FactionOwnership.seleucid | FactionOwnership.greek;
                    break;
                case "carthage":
                    faction = FactionOwnership.carthage | FactionOwnership.carthaginian;
                    break;
                case "parthia":
                    faction = FactionOwnership.parthia | FactionOwnership.eastern;
                    break;
                case "gauls":
                    faction = FactionOwnership.gauls | FactionOwnership.barbarian;
                    break;
                case "germans":
                    faction = FactionOwnership.germans | FactionOwnership.barbarian;
                    break;
                case "britons":
                    faction = FactionOwnership.britons | FactionOwnership.barbarian;
                    break;
                case "greek_cities":
                    faction = FactionOwnership.greek_cities | FactionOwnership.greek;
                    break;
                case "romans_senate":
                    faction = FactionOwnership.romans_senate | FactionOwnership.roman;
                    break;
                case "macedon":
                    faction = FactionOwnership.macedon | FactionOwnership.greek;
                    break;
                case "pontus":
                    faction = FactionOwnership.pontus | FactionOwnership.eastern;
                    break;
                case "armenia":
                    faction = FactionOwnership.armenia | FactionOwnership.eastern;
                    break;
                case "dacia":
                    faction = FactionOwnership.dacia | FactionOwnership.barbarian;
                    break;
                case "numidia":
                    faction = FactionOwnership.numidia | FactionOwnership.carthaginian;
                    break;
                case "scythia":
                    faction = FactionOwnership.scythia | FactionOwnership.barbarian;
                    break;
                case "spain":
                    faction = FactionOwnership.spain | FactionOwnership.barbarian;
                    break;
                case "thrace":
                    faction = FactionOwnership.thrace | FactionOwnership.greek;
                    break;
                case "slave":
                    faction = FactionOwnership.slave;
                    break;
                case "carthaginian":
                    faction = FactionOwnership.carthaginian;
                    break;
                case "barbarian":
                    faction = FactionOwnership.barbarian;
                    break;
                case "egyptian":
                    faction = FactionOwnership.egyptian;
                    break;
                case "greek":
                    faction = FactionOwnership.greek;
                    break;
                case "eastern":
                    faction = FactionOwnership.eastern;
                    break;
            }



            return faction;

        }

		static public FactionOwnership SpecialStringToFaction(string str)
		{
			FactionOwnership faction = FactionOwnership.none;

			switch (str)
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
				case "carthaginian":
					faction = FactionOwnership.carthaginian;
					break;
				case "barbarian":
					faction = FactionOwnership.barbarian;
					break;
				case "egyptian":
					faction = FactionOwnership.egyptian;
					break;
				case "greek":
					faction = FactionOwnership.greek;
					break;
				case "eastern":
					faction = FactionOwnership.eastern;
					break;
			}



			return faction;

		}

        static public M2TWFactionOwnership M2TWStringToFaction(string str)
        {
            M2TWFactionOwnership faction = M2TWFactionOwnership.none;

            switch (str)
            {
                case "england":
                    faction = M2TWFactionOwnership.england | M2TWFactionOwnership.northern_european;
                    break;
                case "france":
                    faction = M2TWFactionOwnership.france | M2TWFactionOwnership.northern_european;
                    break;
                case "hre":
                    faction = M2TWFactionOwnership.hre | M2TWFactionOwnership.northern_european;
                    break;
                case "spain":
                    faction = M2TWFactionOwnership.spain | M2TWFactionOwnership.southern_european;
                    break;
                case "venice":
                    faction = M2TWFactionOwnership.venice | M2TWFactionOwnership.southern_european;
                    break;
                case "sicily":
                    faction = M2TWFactionOwnership.sicily | M2TWFactionOwnership.southern_european;
                    break;
                case "milan":
                    faction = M2TWFactionOwnership.milan | M2TWFactionOwnership.southern_european;
                    break;
                case "scotland":
                    faction = M2TWFactionOwnership.scotland | M2TWFactionOwnership.northern_european;
                    break;
                case "byzantium":
                    faction = M2TWFactionOwnership.byzantium | M2TWFactionOwnership.greek;
                    break;
                case "russia":
                    faction = M2TWFactionOwnership.russia | M2TWFactionOwnership.eastern_european;
                    break;
                case "moors":
                    faction = M2TWFactionOwnership.moors | M2TWFactionOwnership.middle_eastern;
                    break;
                case "turks":
                    faction = M2TWFactionOwnership.turks | M2TWFactionOwnership.middle_eastern;
                    break;
                case "egypt":
                    faction = M2TWFactionOwnership.egypt | M2TWFactionOwnership.middle_eastern;
                    break;
                case "denmark":
                    faction = M2TWFactionOwnership.denmark | M2TWFactionOwnership.northern_european;
                    break;
                case "portugal":
                    faction = M2TWFactionOwnership.portugal | M2TWFactionOwnership.southern_european;
                    break;
                case "poland":
                    faction = M2TWFactionOwnership.poland | M2TWFactionOwnership.eastern_european;
                    break;
                case "hungary":
                    faction = M2TWFactionOwnership.hungary | M2TWFactionOwnership.eastern_european;
                    break;
                case "papal_states":
                    faction = M2TWFactionOwnership.papal_states | M2TWFactionOwnership.southern_european;
                    break;
                case "aztecs":
                    faction = M2TWFactionOwnership.aztecs;
                    break;
                case "mongols":
                    faction = M2TWFactionOwnership.mongols | M2TWFactionOwnership.middle_eastern;
                    break;
                case "timurids":
                    faction = M2TWFactionOwnership.timurids | M2TWFactionOwnership.middle_eastern;
                    break;
                case "slave":
                    faction = M2TWFactionOwnership.slave | M2TWFactionOwnership.northern_european;
                    break;
                case "northern_european":
                    faction = M2TWFactionOwnership.northern_european | M2TWFactionOwnership.england | M2TWFactionOwnership.france | M2TWFactionOwnership.hre | M2TWFactionOwnership.scotland | M2TWFactionOwnership.denmark | M2TWFactionOwnership.slave;
                    break;
                case "eastern_european":
                    faction = M2TWFactionOwnership.eastern_european | M2TWFactionOwnership.russia | M2TWFactionOwnership.hungary | M2TWFactionOwnership.poland;
                    break;
                case "middle_eastern":
                    faction = M2TWFactionOwnership.middle_eastern | M2TWFactionOwnership.moors | M2TWFactionOwnership.turks | M2TWFactionOwnership.egypt | M2TWFactionOwnership.mongols | M2TWFactionOwnership.timurids;
                    break;
                case "southern_european":
                    faction = M2TWFactionOwnership.southern_european | M2TWFactionOwnership.spain | M2TWFactionOwnership.venice | M2TWFactionOwnership.sicily | M2TWFactionOwnership.milan | M2TWFactionOwnership.portugal | M2TWFactionOwnership.papal_states;
                    break;
                case "normans":
                    faction = M2TWFactionOwnership.normans;
                    break;
                case "saxons":
                    faction = M2TWFactionOwnership.saxons;
                    break;
                case "greek":
                    faction = M2TWFactionOwnership.greek | M2TWFactionOwnership.byzantium ;
                    break;


            }

            return faction;

        }

        static public string FactionToString(FactionOwnership faction)
        {
			//account for 
            string str = "";

            switch (faction)
            {
                case FactionOwnership.roman:
                    str = "roman";
                    break;

                case FactionOwnership.romans_julii:
                    str = "romans_julii";
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
                    str = "seleucid";
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
                    str = "macedon";
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
                    str = "eastern";
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
                case FactionOwnership.carthaginian:
                    str = "carthaginian";
                    break;
                case FactionOwnership.egyptian:
                    str = "egyptian";
                    break;
                case FactionOwnership.greek:
                    str = "greek";
                    break;
                case FactionOwnership.barbarian:
                    str = "barbarian";
                    break;
                case FactionOwnership.numidia:
                    str = "numidia";
                    break;


            }



            return str;

        }

		static public string[] SpecialFactionToString(FactionOwnership faction)
		{
			//account for 
			List<string> str = new List<string>();

			switch (faction)
			{
				case FactionOwnership.roman:
					str = new List<string>(new string[] { "roman", "romans_brutii", "romans_julii", "romans_scipii", "romans_senate" });
					break;
				case FactionOwnership.romans_brutii:
					str = new List<string>(new string[] { "romans_brutii" });
					break;
				case FactionOwnership.romans_scipii:
					str = new List<string>(new string[] { "romans_scipii" });
					break;
				case FactionOwnership.romans_julii:
					str = new List<string>(new string[] { "romans_julii" });
					break;
				case FactionOwnership.romans_senate:
					str = new List<string>(new string[] { "romans_senate" });
					break;
				case FactionOwnership.egypt | FactionOwnership.egyptian:
					str = new List<string>(new string[] { "egypt" });
					break;
				case FactionOwnership.egypt:
					str = new List<string>(new string[] { "egypt"});
					break;
				case FactionOwnership.seleucid | FactionOwnership.greek:
					str = new List<string>(new string[] { "seleucid" });
					break;
				case FactionOwnership.seleucid:
					str = new List<string>(new string[] { "seleucid"});
					break;
				case FactionOwnership.carthage | FactionOwnership.carthaginian:
					str = new List<string>(new string[] { "carthage" });
					break;
				case FactionOwnership.carthage:
					str = new List<string>(new string[] { "carthage"});
					break;
				case FactionOwnership.parthia | FactionOwnership.eastern:
					str = new List<string>(new string[] { "parthia" });
					break;
				case FactionOwnership.parthia:
					str = new List<string>(new string[] { "parthia"});
					break;
				case FactionOwnership.gauls | FactionOwnership.barbarian:
					str = new List<string>(new string[] { "gauls" });
					break;
				case FactionOwnership.gauls:
					str = new List<string>(new string[] { "gauls"});
					break;
				case FactionOwnership.germans | FactionOwnership.barbarian:
					str = new List<string>(new string[] { "germans" });
					break;
				case FactionOwnership.germans:
					str = new List<string>(new string[] { "germans"});
					break;
				case FactionOwnership.britons | FactionOwnership.barbarian:
					str = new List<string>(new string[] { "britons" });
					break;
				case FactionOwnership.britons:
					str = new List<string>(new string[] { "britons"});
					break;
				case FactionOwnership.greek_cities | FactionOwnership.greek:
					str = new List<string>(new string[] { "greek_cities" });
					break;
				case FactionOwnership.greek_cities:
					str = new List<string>(new string[] { "greek_cities" });
					break;
				case FactionOwnership.macedon |FactionOwnership.greek:
					str = new List<string>(new string[] { "macedon" });
					break;
				case FactionOwnership.macedon:
					str = new List<string>(new string[] { "macedon" });
					break;
				case FactionOwnership.pontus | FactionOwnership.eastern:
					str = new List<string>(new string[] { "pontus" });
					break;
				case FactionOwnership.pontus:
					str = new List<string>(new string[] { "pontus" });
					break;
				case FactionOwnership.armenia | FactionOwnership.eastern:
					str = new List<string>(new string[] { "armenia" });
					break;
				case FactionOwnership.armenia:
					str = new List<string>(new string[] { "armenia" });
					break;
				case FactionOwnership.dacia | FactionOwnership.barbarian:
					str = new List<string>(new string[] { "dacia" });
					break;
				case FactionOwnership.dacia:
					str = new List<string>(new string[] { "dacia" });
					break;
				case FactionOwnership.eastern:
					str = new List<string>(new string[] { "pontus", "eastern", "armenia", "parthia" });
					break;
				case FactionOwnership.scythia | FactionOwnership.barbarian:
					str = new List<string>(new string[] { "scythia" });
					break;
				case FactionOwnership.scythia:
					str = new List<string>(new string[] { "scythia" });
					break;
				case FactionOwnership.spain | FactionOwnership.barbarian:
					str = new List<string>(new string[] { "spain" });
					break;
				case FactionOwnership.spain:
					str = new List<string>(new string[] { "spain" });
					break;
				case FactionOwnership.thrace | FactionOwnership.greek:
					str = new List<string>(new string[] { "thrace" });
					break;
				case FactionOwnership.thrace:
					str = new List<string>(new string[] { "thrace" });
					break;
				case FactionOwnership.slave:
					str = new List<string>(new string[] { "slave" });
					break;
				case FactionOwnership.carthaginian: 
					str = new List<string>(new string[] { "carthaginian", "carthage", "numidia"});
					break;
				case FactionOwnership.greek: 
					str = new List<string>(new string[] { "greek", "macedon", "seleucid", "thrace", "greek_cities" });
					break;
				case FactionOwnership.barbarian:
					str = new List<string>(new string[] { "barbarian", "dacia", "gauls", "britons", "germans", "spain", "scythia" });
					break;
				case FactionOwnership.numidia | FactionOwnership.carthaginian:
					str = new List<string>(new string[] { "numidia" });
					break;
				case FactionOwnership.numidia:
					str = new List<string>(new string[] { "numidia" });
					break;

			}



			return str.ToArray();

		}

		static public string M2TWFactionToString(M2TWFactionOwnership faction)
        {

            string str = "";

            switch (faction)
            {
                case M2TWFactionOwnership.aztecs:
                    str = "aztecs";
                    break;

                case M2TWFactionOwnership.byzantium:
                    str = "byzantium";
                    break;

                case M2TWFactionOwnership.denmark:
                    str = "denmark";
                    break;

                case M2TWFactionOwnership.eastern_european:
                    str = "eastern_european";
                    break;
                case M2TWFactionOwnership.egypt:
                    str = "egypt";
                    break;
                case M2TWFactionOwnership.england:
                    str = "england";
                    break;
                case M2TWFactionOwnership.france:
                    str = "france";
                    break;
                case M2TWFactionOwnership.greek:
                    str = "greek";
                    break;
                case M2TWFactionOwnership.hre:
                    str = "hre";
                    break;
                case M2TWFactionOwnership.hungary:
                    str = "hungary";
                    break;
                case M2TWFactionOwnership.middle_eastern:
                    str = "middle_eastern";
                    break;
                case M2TWFactionOwnership.milan:
                    str = "milan";
                    break;
                case M2TWFactionOwnership.mongols:
                    str = "mongols";
                    break;
                case M2TWFactionOwnership.moors:
                    str = "moors";
                    break;
                case M2TWFactionOwnership.normans:
                    str = "normans";
                    break;
                case M2TWFactionOwnership.northern_european:
                    str = "northern_european";
                    break;
                case M2TWFactionOwnership.papal_states:
                    str = "papal_states";
                    break;
                case M2TWFactionOwnership.poland:
                    str = "poland";
                    break;
                case M2TWFactionOwnership.portugal:
                    str = "portugal";
                    break;
                case M2TWFactionOwnership.russia:
                    str = "russia";
                    break;
                case M2TWFactionOwnership.saxons:
                    str = "saxons";
                    break;
                case M2TWFactionOwnership.scotland:
                    str = "scotland";
                    break;
                case M2TWFactionOwnership.sicily:
                    str = "sicily";
                    break;
                case M2TWFactionOwnership.slave:
                    str = "slave";
                    break;
                case M2TWFactionOwnership.southern_european:
                    str = "southern_european";
                    break;
                case M2TWFactionOwnership.spain:
                    str = "spain";
                    break;
                case M2TWFactionOwnership.timurids:
                    str = "timurids";
                    break;
                case M2TWFactionOwnership.turks:
                    str = "turks";
                    break;
                case M2TWFactionOwnership.venice:
                    str = "venice";
                    break;

            }



            return str;

        }

        static public string AttributesToString(Attributes attr)
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

        static public string M2TWAttributesToString(M2TWAttributes attr)
        {
            string str = "";

            switch (attr)
            {
                case M2TWAttributes.sea_faring:
                    str = "sea_faring";
                    break;

                case M2TWAttributes.hide_forest:
                    str = "hide_forest";
                    break;

                case M2TWAttributes.hide_improved_forest:
                    str = "hide_improved_forest";
                    break;

                case M2TWAttributes.hide_long_grass:
                    str = "hide_long_grass";
                    break;
                case M2TWAttributes.hide_anywhere:
                    str = "hide_anywhere";
                    break;
                case M2TWAttributes.can_sap:
                    str = "can_sap";
                    break;
                case M2TWAttributes.frighten_foot:
                    str = "frighten_foot";
                    break;
                case M2TWAttributes.frighten_mounted:
                    str = "frighten_mounted";
                    break;
                case M2TWAttributes.can_run_amok:
                    str = "can_run_amok";
                    break;
                case M2TWAttributes.general_unit:
                    str = "general_unit";
                    break;
                case M2TWAttributes.general_unit_upgrade:
                    str = "general_unit_upgrade";
                    break;
                case M2TWAttributes.cantabrian_circle:
                    str = "cantabrian_circle";
                    break;
                case M2TWAttributes.no_custom:
                    str = "no_custom";
                    break;
                case M2TWAttributes.command:
                    str = "command";
                    break;
                case M2TWAttributes.mercenary_unit:
                    str = "mercenary_unit";
                    break;
                case M2TWAttributes.druid:
                    str = "druid";
                    break;
                case M2TWAttributes.warcry:
                    str = "warcry";
                    break;
                case M2TWAttributes.free_upkeep_unit:
                    str = "free_upkeep_unit";
                    break;


            }

            return str;



        }

        static public string FormationTostring(FormationTypes formation)
        {
            string str = "";

            switch (formation)
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

        static public string MissleTypeToString(MissleType missle)
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

                case MissleType.ballista:
                    str = "ballista";
                    break;

                case MissleType.onager:
                    str = "boulder";
                    break;

                case MissleType.heavy_onager:
                    str = "big_boulder";
                    break;

                case MissleType.scorpion:
                    str = "scorpion";
                    break;

                case MissleType.repeating_ballista:
                    str = "repeating_ballista";
                    break;

                case MissleType.bullet:
                    str = "bullet";
                    break;
            }

            return str;

        }

        static public string WeaponTypeToString(WeaponType weapon)
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
                    str = "siege_missile";
                    break;

                case WeaponType.WT_no:
                    str = "no";
                    break;
            }

            return str;
        }

        static public string TechTypeToString(techType tech)
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

        static public string M2TWTechTypeToString(M2TWtechType tech)
        {
            string tt = "";

            switch(tech)
            {
                case M2TWtechType.artillery_gunpowder:
                    tt = "artillery_gunpowder";
                    break;
                case M2TWtechType.artillery_mechanical:
                    tt = "artillery_mechanical";
                    break;
                case M2TWtechType.melee_blade:
                    tt = "melee_blade";
                    break;
                case M2TWtechType.melee_simple:
                    tt = "melee_simple";
                    break;
                case M2TWtechType.missile_gunpowder:
                    tt = "missile_gunpowder";
                    break;
                case M2TWtechType.missile_mechanical:
                    tt = "missile_mechanical";
                    break;
                case M2TWtechType.TT_no:
                    tt = "TT_no";
                    break;
            }

            return tt;
        }

        static public string M2TWMissleTypeToString(M2TWAmmunition miss)
        {
            string missle = "";

            switch (miss)
            {
                case M2TWAmmunition.arquebus_bullet:
                    missle = "arquebus_bullet";
                    break;
                case M2TWAmmunition.arrow:
                    missle = "arrow";
                    break;
                case M2TWAmmunition.arrow_fiery:
                    missle = "arrow_fiery";
                    break;
                case M2TWAmmunition.ballista:
                    missle = "ballista";
                    break;
                case M2TWAmmunition.basilisk_shot:
                    missle = "basilisk_shot";
                    break;
                case M2TWAmmunition.bodkin_arrow:
                    missle = "bodkin_arrow";
                    break;
                case M2TWAmmunition.bodkin_arrow_fiery:
                    missle = "bodkin_arrow_fiery";
                    break;
                case M2TWAmmunition.bolt:
                    missle = "bolt";
                    break;
                case M2TWAmmunition.bombard_shot:
                    missle = "bombard_shot";
                    break;
                case M2TWAmmunition.camel_gun_bullet:
                    missle = "camel_gun_bullet";
                    break;
                case M2TWAmmunition.cannon_shot:
                    missle = "cannon_shot";
                    break;
                case M2TWAmmunition.catapult:
                    missle = "catapult";
                    break;
                case M2TWAmmunition.cav_bodkin_arrow:
                    missle = "cav_bodkin_arrow";
                    break;
                case M2TWAmmunition.cav_bodkin_arrow_fiery:
                    missle = "cav_bodkin_arrow_fiery";
                    break;
                case M2TWAmmunition.cav_composite_arrow:
                    missle = "cav_composite_arrow";
                    break;
                case M2TWAmmunition.cav_composite_arrow_fiery:
                    missle = "cav_composite_arrow_fiery";
                    break;
                case M2TWAmmunition.composite_arrow:
                    missle = "composite_arrow";
                    break;
                case M2TWAmmunition.composite_arrow_fiery:
                    missle = "composite_arrow_fiery";
                    break;
                case M2TWAmmunition.cow_carcass:
                    missle = "cow_carcass";
                    break;
                case M2TWAmmunition.crossbow_bolt:
                    missle = "crossbow_bolt";
                    break;
                case M2TWAmmunition.culverin_shot:
                    missle = "culverin_shot";
                    break;
                case M2TWAmmunition.elephant_cannon_shot:
                    missle = "elephant_cannon_shot";
                    break;
                case M2TWAmmunition.elephant_rocket:
                    missle = "elephant_rocket";
                    break;
                case M2TWAmmunition.exploding_basilisk_shot:
                    missle = "exploding_basilisk_shot";
                    break;
                case M2TWAmmunition.exploding_cannon_shot:
                    missle = "exploding_cannon_shot";
                    break;
                case M2TWAmmunition.exploding_culverin_shot:
                    missle = "exploding_culverin_shot";
                    break;
                case M2TWAmmunition.fiery_catapult:
                    missle = "fiery_catapult";
                    break;
                case M2TWAmmunition.fiery_norman_catapult:
                    missle = "fiery_norman_catapult";
                    break;
                case M2TWAmmunition.fiery_trebuchet:
                    missle = "fiery_trebuchet";
                    break;
                case M2TWAmmunition.flaming_ballista:
                    missle = "flaming_ballista";
                    break;
                case M2TWAmmunition.flaming_bombard_shot:
                    missle = "flaming_bombard_shot";
                    break;
                case M2TWAmmunition.flaming_grand_bombard_shot:
                    missle = "flaming_grand_bombard_shot";
                    break;
                case M2TWAmmunition.flaming_scorpion:
                    missle = "flaming_scorpion";
                    break;
                case M2TWAmmunition.grand_bombard_shot:
                    missle = "grand_bombard_shot";
                    break;
                case M2TWAmmunition.hand_gun_bullet:
                    missle = "hand_gun_bullet";
                    break;
                case M2TWAmmunition.javelin:
                    missle = "javelin";
                    break;
                case M2TWAmmunition.monster_bombard_shot:
                    missle = "monster_bombard_shot";
                    break;
                case M2TWAmmunition.monster_ribault_shot:
                    missle = "monster_ribault_shot";
                    break;
                case M2TWAmmunition.mortar_shot:
                    missle = "mortar_shot";
                    break;
                case M2TWAmmunition.musket_bullet:
                    missle = "musket_bullet";
                    break;
                case M2TWAmmunition.naphtha_bomb:
                    missle = "naphtha_bomb";
                    break;
                case M2TWAmmunition.no:
                    missle = "no";
                    break;
                case M2TWAmmunition.norman_catapult:
                    missle = "norman_catapult";
                    break;
                case M2TWAmmunition.pistol_bullet:
                    missle = "pistol_bullet";
                    break;
                case M2TWAmmunition.repeating_ballista:
                    missle = "repeating_ballista";
                    break;
                case M2TWAmmunition.ribault_shot:
                    missle = "ribault_shot";
                    break;
                case M2TWAmmunition.rocket:
                    missle = "rocket";
                    break;
                case M2TWAmmunition.scorpion:
                    missle = "scorpion";
                    break;
                case M2TWAmmunition.serpentine_shot:
                    missle = "serpentine_shot";
                    break;
                case M2TWAmmunition.steel_crossbow_bolt:
                    missle = "steel_crossbow_bolt";
                    break;
                case M2TWAmmunition.stone:
                    missle = "stone";
                    break;
                case M2TWAmmunition.tarred_rock:
                    missle = "tarred_rock";
                    break;
                case M2TWAmmunition.test_cannon_ball:
                    missle = "test_cannon_ball";
                    break;
                case M2TWAmmunition.tower_ballista:
                    missle = "tower_ballista";
                    break;
                case M2TWAmmunition.tower_flaming_ballista:
                    missle = "tower_flaming_ballista";
                    break;
                case M2TWAmmunition.trebuchet:
                    missle = "trebuchet";
                    break;
               
            }

            return missle;

        }

        static public string DamageTypeToString(DamageType dmg)
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

        static public string SoundTypeToString(SoundType snd)
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
                    str = "none";
                    break;
            }

            return str;
        }

        static public string ArmourSndToString(ArmourSound snd)
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

        static public string PriAttrToString(stat_pri_attr pri)
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
                    str = "spear";
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
                    str = "thrown";
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

                case stat_pri_attr.fire:
                    str = "fire";
                    break;

                case stat_pri_attr.spear_bonus_4:
                    str = "spear_bonus_4";
                    break;

                case stat_pri_attr.spear_bonus_8:
                    str = "spear_bonus_8";
                    break;

                case stat_pri_attr.thrown_ap:
                    str = "thrown ap";
                    break;
            }

            return str;


        }

        static public string DisciplineToString(statmental_discipline dis)
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

                case statmental_discipline.berserker:
                    str = "berserker";
                    break;
            }

            return str;


        }

        static public string TrainingToString(statmental_training train)
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

    }
}

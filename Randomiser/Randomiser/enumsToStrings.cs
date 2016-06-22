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

        static public string FactionToString(FactionOwnership faction)
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
                case FactionOwnership.carthaginian:
                    str = "carthaginian";
                    break;
                case FactionOwnership.egyptian:
                    str = "egyptian";
                    break;
                case FactionOwnership.greek:
                    str = "greek";
                    break;
                case FactionOwnership.parthian:
                    str = "parthian";
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
                    str = "siege_missle";
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
                    str = "no";
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

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
                    faction = FactionOwnership.roman | FactionOwnership.romans_brutii | FactionOwnership.romans_julii | FactionOwnership.romans_scipii | FactionOwnership.romans_senate;
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
                    faction = FactionOwnership.slave | FactionOwnership.roman;
                    break;
                case "carthaginian":
                    faction = FactionOwnership.carthaginian | FactionOwnership.carthage | FactionOwnership.numidia;
                    break;
                case "barbarian":
                    faction = FactionOwnership.barbarian | FactionOwnership.britons | FactionOwnership.dacia | FactionOwnership.gauls | FactionOwnership.germans | FactionOwnership.scythia | FactionOwnership.spain;
                    break;
                case "egyptian":
                    faction = FactionOwnership.egyptian | FactionOwnership.egypt;
                    break;
                case "greek":
                    faction = FactionOwnership.greek | FactionOwnership.greek_cities | FactionOwnership.macedon | FactionOwnership.seleucid | FactionOwnership.thrace;
                    break;
                case "eastern":
                    faction = FactionOwnership.eastern | FactionOwnership.armenia | FactionOwnership.parthia | FactionOwnership.pontus;
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

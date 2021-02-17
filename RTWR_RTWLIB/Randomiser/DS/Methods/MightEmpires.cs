using RTWLib.Data;
using RTWLib.Functions;
using RTWLib.Functions.EDU;
using RTWLib.Medieval2;
using RTWLib.Objects;
using RTWLib.Objects.Descr_strat;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RTWR_RTWLIB.Randomiser
{
    public partial class RandomDS
    {
        public static void MightyEmpires(Descr_Strat ds, EDU edu, NamesFile names, Descr_Region dr, EDB edb)
        {
            if (ds.GetType() == typeof(M2DS))
            {
                M2TWMightyEmpires(ds, edu, names, dr, edb);
                return;
            }

            else RomeMightyEmpires(ds, edu, names, dr, edb);
        }

        public static void RomeMightyEmpires(Descr_Strat ds, EDU edu, NamesFile names, Descr_Region dr, EDB edb)
        {
            foreach (Faction f in ds.factions)
            {
                if (f.name == "slave") //  skip slave
                {
                    f.characters.Clear();
                    f.relatives.Clear();
                    f.characterRecords.Clear();
                    continue;
                }

                List<string> usedNames = new List<string>();

                int CWithArmies = 0;
                foreach (DSCharacter c in f.characters)
                {
                    if (c.type == "named character" || c.type == "general")
                        CWithArmies++;
                    usedNames.Add(c.name.Trim());
                }

                foreach (CharacterRecord cr in f.characterRecords)
                {
                    usedNames.Add(cr.name);
                }

                int power = f.settlements.Count() * 2;
                int armyDeficit = f.settlements.Count() - CWithArmies;
                int armySize = power;
                if (armySize > 20)
                    armySize = 20;

                List<Unit> factionUnits = ((EDU)edu).FindUnitsByFaction(f.name);

                int emptySettlements = f.settlements.Count() - f.characters.Count();

                int rndSize = TWRandom.rnd.Next(armySize / 2, armySize);

                for (int i = 0; i < armyDeficit; i++)
                {
                    string name = names.GetRandomUniqueName(TWRandom.rnd, f.name, usedNames);

                    f.characters.Add(new DSCharacter(name, TWRandom.rnd));

                }

                foreach (DSCharacter character in f.characters)
                {
                    rndSize = TWRandom.rnd.Next(2, (armySize + 2) / 2);
                    if (rndSize == 0)
                        rndSize = 1;
                    if (character.type == "general" || character.type == "named character")
                    {
                        character.army.Clear();
                        for (int i = 0; i < rndSize; i++)
                        {
                            character.army.Add(new DSUnit(factionUnits[TWRandom.rnd.Next(factionUnits.Count)].type, 0, 0, 0));
                        }
                    }

                }

                LookUpTables lt = new LookUpTables();

                Cultures culture = lt.LookUpKey<Cultures>(f.name);

                if (culture == Cultures.barbarian)
                    power = 4;

                foreach (Settlement s in f.settlements)
                {
                    Action<string, int, List<DSBuilding>, int> ChangeSettlement = (string level, int pop, List<DSBuilding> dSBuildings, int mod) =>
                    {
                        s.s_level = level;
                        s.population = pop;
                        s.b_types = new List<DSBuilding>(dSBuildings);
                        power -= mod;
                    };

                    if (power > 32)
                    {
                        s.b_types.Clear();

                        string levels = "huge_city";
                        int population = 25000;

                        List<DSBuilding> dsbs = GetBuildings(levels, edb);

                        ChangeSettlement(levels, population, dsbs, 8);


                    }

                    else if (power > 16)
                    {
                        s.b_types.Clear();

                        string levels = "large_city";
                        int population = 20000;

                        List<DSBuilding> dsbs = GetBuildings(levels, edb);

                        ChangeSettlement(levels, population, dsbs, 4);
                    }

                    else if (power > 8)
                    {
                        s.b_types.Clear();

                        string levels = "city";
                        int population = 15000;

                        List<DSBuilding> dsbs = GetBuildings(levels, edb);

                        ChangeSettlement(levels, population, dsbs, 2);


                    }

                    else if (power > 4)
                    {
                        s.b_types.Clear();

                        string levels = "large_town";
                        int population = 9000;

                        List<DSBuilding> dsbs = GetBuildings(levels, edb);

                        ChangeSettlement(levels, population, dsbs, 1);


                    }

                    else if (power > 2)
                    {
                        s.b_types.Clear();

                        string levels = "town";
                        int population = 3500;

                        List<DSBuilding> dsbs = GetBuildings(levels, edb);

                        ChangeSettlement(levels, population, dsbs, 0);


                    }

                    else if (power > 1)
                    {
                        s.b_types.Clear();

                        string levels = "village";
                        int population = 1000;

                        //List<DSBuilding> dsbs = GetBuildings(levels, edb);

                        ChangeSettlement(levels, population, new List<DSBuilding>(), 0);

                    }
                }

                CharacterCoordinateFix(ds, dr);
            }
        }

        public static void M2TWMightyEmpires(Descr_Strat ds, EDU edu, NamesFile names, Descr_Region dr, EDB edb)
        {
            foreach (Faction f in ds.factions)
            {
                if (f.name == "slave") //  skip slave
                {
                    f.characters.Clear();
                    f.relatives.Clear();
                    f.characterRecords.Clear();
                    continue;
                }

                List<string> usedNames = new List<string>();

                int CWithArmies = 0;
                foreach (M2DSCharacter c in f.characters)
                {
                    if (c.type == "named character" || c.type == "general")
                        CWithArmies++;
                    usedNames.Add(c.name.Trim());
                }

                foreach (CharacterRecord cr in f.characterRecords)
                {
                    usedNames.Add(cr.name);
                }

                int power = f.settlements.Count() * 2;
                int armyDeficit = f.settlements.Count() - CWithArmies;
                int armySize = power;
                if (armySize > 20)
                    armySize = 20;

                List<Unit> factionUnits = ((EDU)edu).FindUnitsByFaction(f.name);

                int emptySettlements = f.settlements.Count() - f.characters.Count();

                int rndSize = TWRandom.rnd.Next(armySize / 2, armySize);

                for (int i = 0; i < armyDeficit; i++)
                {
                    string name = names.GetRandomUniqueName(TWRandom.rnd, f.name, usedNames);
                    f.characters.Add(new M2DSCharacter(name, TWRandom.rnd));
                }

                foreach (M2DSCharacter character in f.characters)
                {
                    rndSize = TWRandom.rnd.Next(2, (armySize + 2) / 2);
                    if (rndSize == 0)
                        rndSize = 1;
                    if (character.type == "general" || character.type == "named character")
                    {
                        character.army.Clear();
                        for (int i = 0; i < rndSize; i++)
                        {
                            character.army.Add(new DSUnit(factionUnits[TWRandom.rnd.Next(factionUnits.Count)].type, 0, 0, 0));
                        }
                    }

                }

                LookUpTables lt = new LookUpTables();

                foreach (Settlement s in f.settlements)
                {
                    Action<string, int, List<DSBuilding>, int> ChangeSettlement = (string level, int pop, List<DSBuilding> dSBuildings, int mod) =>
                    {
                        s.s_level = level;
                        s.population = pop;
                        s.b_types = new List<DSBuilding>(dSBuildings);
                        power -= mod;
                    };

                    if (power > 32)
                    {
                        s.b_types.Clear();

                        string levels = "huge_city";
                        int population = 25000;

                        List<DSBuilding> dsbs = GetBuildings(levels, edb);

                        ChangeSettlement(levels, population, dsbs, 8);


                    }

                    else if (power > 16)
                    {
                        s.b_types.Clear();

                        string levels = "large_city";
                        int population = 20000;

                        List<DSBuilding> dsbs = GetBuildings(levels, edb);

                        ChangeSettlement(levels, population, dsbs, 4);
                    }

                    else if (power > 8)
                    {
                        s.b_types.Clear();

                        string levels = "city";
                        int population = 15000;

                        List<DSBuilding> dsbs = GetBuildings(levels, edb);

                        ChangeSettlement(levels, population, dsbs, 2);


                    }

                    else if (power > 4)
                    {
                        s.b_types.Clear();

                        string levels = "large_town";
                        int population = 9000;

                        List<DSBuilding> dsbs = GetBuildings(levels, edb);

                        ChangeSettlement(levels, population, dsbs, 1);


                    }

                    else if (power > 2)
                    {
                        s.b_types.Clear();

                        string levels = "town";
                        int population = 3500;

                        List<DSBuilding> dsbs = GetBuildings(levels, edb);

                        ChangeSettlement(levels, population, dsbs, 0);


                    }

                    else if (power > 1)
                    {
                        s.b_types.Clear();

                        string levels = "village";
                        int population = 1000;

                        //List<DSBuilding> dsbs = GetBuildings(levels, edb);

                        ChangeSettlement(levels, population, new List<DSBuilding>(), 0);

                    }
                }

                CharacterCoordinateFix(ds, dr);
            }


        }

    }
}

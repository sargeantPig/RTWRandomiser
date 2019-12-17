using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RTWLib.Data;

namespace RTWR_RTWLIB.Data
{
    static public class ComparePersonalities
    {
        static Dictionary<Personality, Dictionary<Personality, int>> table = new Dictionary<Personality, Dictionary<Personality, int>>()
            {
                { Personality.Ambitous, new Dictionary<Personality, int> {

                    {Personality.Ambitous, 6 },
                    {Personality.Cowardly, 4 },
                    {Personality.Treachourous, 0 },
                    {Personality.Trustworthy, 4},
                    {Personality.Barbaric, 4}

                } },
                {Personality.Cowardly, new Dictionary<Personality, int>(){
                    {Personality.Ambitous, 4 },
                    {Personality.Cowardly, 0 },
                    {Personality.Treachourous, 2 },
                    {Personality.Trustworthy, 0 },
                    {Personality.Barbaric, 6}
                } },
                {Personality.Treachourous, new Dictionary<Personality, int>()
                {
                    {Personality.Ambitous, 0 },
                    {Personality.Cowardly, 1 },
                    {Personality.Treachourous, 4},
                    {Personality.Trustworthy, 0 },
                    {Personality.Barbaric, 0}
                } },
                {Personality.Trustworthy, new Dictionary<Personality, int>(){
                    {Personality.Ambitous, 4 },
                    {Personality.Cowardly, 0 },
                    {Personality.Treachourous, 4 },
                    {Personality.Trustworthy, 0 },
                    {Personality.Barbaric, 6 }
                }},
                {Personality.Barbaric, new Dictionary<Personality, int>(){

                    {Personality.Ambitous, 4 },
                    {Personality.Cowardly, 6},
                    {Personality.Treachourous, 0 },
                    {Personality.Trustworthy, 6 },
                    {Personality.Barbaric, 6 }

                } }

            };
        static public int Compare(this Personality a, Personality b)
        {
            return table[a][b];
        }
    }


    public enum Personality
    {
        Ambitous,
        Cowardly,
        Treachourous,
        Trustworthy,
        Barbaric
    }

   public class FPersonality
   {
        public FactionOwnership faction;
        public Personality personality;

        public FPersonality(FactionOwnership faction, Personality personality)
        {
            this.faction = faction;
            this.personality = personality;
        }
   }
}

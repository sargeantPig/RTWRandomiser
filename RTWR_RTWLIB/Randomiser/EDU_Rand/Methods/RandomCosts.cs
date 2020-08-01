using RTWLib.Functions;
using RTWLib.Objects;


namespace RTWR_RTWLIB.Randomiser
{
    public partial class RandomEDU
    {
        public static void RandomCosts(EDU edu)
        {
            foreach (Unit unit in edu.units)
            {
                int totalCost = 0;
                totalCost += unit.soldier.number * 5;
                totalCost += unit.primaryWeapon.attack[0] * 20;
                totalCost += unit.secondaryWeapon.attack[0] * 10;
                totalCost += unit.primaryArmour.stat_pri_armour[0] * 5;
                totalCost += unit.primaryArmour.stat_pri_armour[1] * 3;
                totalCost += unit.primaryArmour.stat_pri_armour[2] * 2;
                totalCost += unit.heatlh[0] * 10;

                unit.cost[1] = totalCost + TWRandom.rnd.Next(-(totalCost / 10), (totalCost / 10) + 1); // cost to build 
                unit.cost[2] = ((totalCost / 100) * unit.soldier.number); // cost to upkeep 
            }
        }

    }
}

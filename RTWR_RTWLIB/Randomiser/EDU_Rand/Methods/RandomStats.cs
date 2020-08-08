using RTWLib.Data;
using RTWLib.Functions;
using RTWLib.Functions.EDU;
using RTWLib.Objects;

namespace RTWR_RTWLIB.Randomiser
{
    public partial class RandomEDU
    {
		public static void RandomStats(EDU edu)
		{
			foreach (Unit unit in edu.units)
			{
				if (unit.primaryWeapon.WeaponFlags != WeaponType.WT_no)
				{
					unit.primaryWeapon.attack[0] = TWRandom.rnd.Next(1, 20); // attack factor
					unit.primaryWeapon.attack[1] = TWRandom.rnd.Next(1, 20); // attack charging
				}

				if (unit.secondaryWeapon.WeaponFlags != WeaponType.WT_no)
				{
					unit.secondaryWeapon.attack[0] = TWRandom.rnd.Next(1, 20); // attack factor
					unit.secondaryWeapon.attack[1] = TWRandom.rnd.Next(1, 20); // attack charging
				}

				unit.primaryArmour.stat_pri_armour[0] = TWRandom.rnd.Next(0, 20);
				unit.primaryArmour.stat_pri_armour[1] = TWRandom.rnd.Next(0, 10);
				unit.primaryArmour.stat_pri_armour[2] = TWRandom.rnd.Next(0, 7);
			}

		}
	}
}
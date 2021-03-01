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
			TWRandom.RefreshRndSeed();
			foreach (Unit unit in edu.units)
			{
				int mina, minb, minc;
				if (unit.priWep.WepFlags != WeaponType.no)
				{
					mina = (int)(LibFuncs.SafeDivide(1, unit.priWep.atk[0]) * 1000);
					minb = (int)(LibFuncs.SafeDivide(1, unit.priWep.atk[1]) * 1000);
					unit.priWep.atk[0] = (int)(unit.priWep.atk[0] * TWRandom.rnd.RandPercent(mina, 2000));// attack factor
					unit.priWep.atk[1] = (int)(unit.priWep.atk[1] * TWRandom.rnd.RandPercent(minb, 2000)); // attack charging
				}

				if (unit.secWep.WepFlags != WeaponType.no)
				{
					mina = (int)(LibFuncs.SafeDivide(1, unit.secWep.atk[0]) * 1000);
					minb = (int)(LibFuncs.SafeDivide(1, unit.secWep.atk[1]) * 1000);
					unit.secWep.atk[0] = (int)(unit.secWep.atk[0] * TWRandom.rnd.RandPercent(mina, 2000)); // attack factor
					unit.secWep.atk[1] = (int)(unit.secWep.atk[1] * TWRandom.rnd.RandPercent(minb, 2000)); // attack charging
				}

				mina = (int)(LibFuncs.SafeDivide(1, unit.priArm.priArm[0]) * 1000);
				minb = (int)(LibFuncs.SafeDivide(1, unit.priArm.priArm[1]) * 1000);
				minc = (int)(LibFuncs.SafeDivide(1, unit.priArm.priArm[2]) * 1000);

				unit.priArm.priArm[0] = (int)(unit.priArm.priArm[0] * TWRandom.rnd.RandPercent(mina, 2000));
				unit.priArm.priArm[1] = (int)(unit.priArm.priArm[1] * TWRandom.rnd.RandPercent(minb, 2000));
				unit.priArm.priArm[2] = (int)(unit.priArm.priArm[2] * TWRandom.rnd.RandPercent(minc, 2000));
			}

		}
	}
}
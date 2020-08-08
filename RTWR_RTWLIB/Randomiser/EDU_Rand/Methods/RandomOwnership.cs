using RTWLib.Data;
using RTWLib.Functions;
using RTWLib.Functions.EDU;
using RTWLib.Objects;
using System.Windows.Forms;

namespace RTWR_RTWLIB.Randomiser
{
    public partial class RandomEDU
    {
		public static void RandomOwnership(EDU edu, NumericUpDown maxOwnership)
		{
			if (maxOwnership is NumericUpDown)
			{
				NumericUpDown maxO = new NumericUpDown();
				maxO = maxOwnership as NumericUpDown;

				foreach (Unit unit in edu.units)
				{
					unit.ownership = FactionOwnership.slave;

					for (int i = 0; i < (int)maxO.Value - 1; i++)
					{
						FactionOwnership fo = FactionOwnership.slave;
						bool dup = false;

						while ((fo = Functions_General.RandomFlag<FactionOwnership>(TWRandom.rnd)) == FactionOwnership.slave
							|| (dup = FlagDuplicateCheck(fo, unit.ownership)) == true
							|| (fo = Functions_General.RandomFlag<FactionOwnership>(TWRandom.rnd)) == FactionOwnership.none)
						{

						}

						unit.ownership |= fo;

						//TWRandom.UnitByFaction.AddKV(fo, unit.type);

					}

				}

			}

			else
			{
				edu.PLog("Error: wrong param type");
				edu.DisplayLogExit();
			}

		}
	}
}

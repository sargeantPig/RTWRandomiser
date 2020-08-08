using RTWLib.Data;
using RTWLib.Functions;
using RTWLib.Functions.EDU;
using RTWLib.Objects;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RTWR_RTWLIB.Randomiser
{
    public partial class RandomEDU
    {
		public static void RandomAttributes(EDU edu, NumericUpDown maxAttributes)
		{
			if (maxAttributes is NumericUpDown)
			{
				NumericUpDown maxA = new NumericUpDown();
				maxA = maxAttributes as NumericUpDown;

				foreach (Unit unit in edu.units)
				{
					unit.attributes = Attributes.sea_faring;
					unit.attributes |= Attributes.mercenary_unit;

					int max = TWRandom.rnd.Next(1, (int)maxA.Value + 1);

					for (int i = 0; i < max; i++)
					{
						Attributes a = Functions_General.RandomFlag<Attributes>(TWRandom.rnd, 1, 17);

						if (!unit.attributes.HasFlag(a) && a != Attributes.general_unit && a != Attributes.general_unit_upgrade)
							unit.attributes |= a;
					}
				}
			}

			else
			{
				edu.PLog("Error: wrong param type");
				edu.DisplayLogExit();
			}

			FactionOwnership fo = FactionOwnership.romans_brutii | FactionOwnership.romans_scipii | FactionOwnership.romans_julii | FactionOwnership.seleucid | FactionOwnership.egypt | FactionOwnership.carthage | FactionOwnership.parthia
			| FactionOwnership.gauls | FactionOwnership.germans | FactionOwnership.britons | FactionOwnership.greek_cities | FactionOwnership.macedon | FactionOwnership.pontus | FactionOwnership.armenia | FactionOwnership.dacia | FactionOwnership.numidia | FactionOwnership.scythia |
			FactionOwnership.spain | FactionOwnership.thrace | FactionOwnership.slave;
			edu.units.Shuffle(TWRandom.rnd);
			foreach (Unit unit in edu.units)
			{
				if ((unit.ownership & fo) != 0 && !unit.type.Contains(new List<string> { "peasant", "navy", "boat" }))
				{
					unit.attributes |= Attributes.general_unit;
					fo = fo & ~unit.ownership;
				}
			}

			fo = FactionOwnership.romans_brutii | FactionOwnership.romans_scipii | FactionOwnership.romans_julii | FactionOwnership.seleucid | FactionOwnership.egypt | FactionOwnership.carthage | FactionOwnership.parthia
			| FactionOwnership.gauls | FactionOwnership.germans | FactionOwnership.britons | FactionOwnership.greek_cities | FactionOwnership.macedon | FactionOwnership.pontus | FactionOwnership.armenia | FactionOwnership.dacia | FactionOwnership.numidia | FactionOwnership.scythia |
			FactionOwnership.spain | FactionOwnership.thrace | FactionOwnership.slave;
			edu.units.Shuffle(TWRandom.rnd);
			foreach (Unit unit in edu.units)
			{
				if ((unit.ownership & fo) != 0 && !unit.attributes.HasFlag(Attributes.general_unit) && !unit.type.Contains(new List<string> { "peasant", "navy", "boat" }))
				{
					unit.attributes |= Attributes.general_unit_upgrade;
					fo = fo & ~unit.ownership;
				}
			}
		}
	}
}
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

			//set generals

			List<string> factions = new List<string>(TWRandom.factionList);

			edu.units.Shuffle(TWRandom.rnd);
			foreach (Unit unit in edu.units)
			{
				string factionFound = "";
				if (factions.ContainsMatch(unit.ownership, out factionFound) && !unit.type.Contains(new List<string> { "peasant", "navy", "boat" }))
				{
					unit.attributes |= Attributes.general_unit;
					factions.Remove(factionFound);
				}
			}

			factions = new List<string>(TWRandom.factionList);

			foreach (Unit unit in edu.units)
			{
				string factionFound = "";
				if (factions.ContainsMatch(unit.ownership, out factionFound) && !unit.attributes.HasFlag(Attributes.general_unit) && !unit.type.Contains(new List<string> { "peasant", "navy", "boat" }))
				{
					unit.attributes |= Attributes.general_unit_upgrade;
					factions.Remove(factionFound);
				}
			}
		}
	}
}
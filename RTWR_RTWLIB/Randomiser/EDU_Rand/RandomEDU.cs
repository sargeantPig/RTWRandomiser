using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using RTWLib.Functions;
using RTWLib.Objects;
using RTWLib.Data;
using RTWLib.Logger;
using System.Threading;
using RTWLib.Objects.Descr_strat;
using RTWR_RTWLIB.Data;

namespace RTWR_RTWLIB.Randomiser
{
	public partial class RandomEDU
	{
		public static void SetFactionUnitList(EDU edu)
		{
			foreach (Unit unit in edu.units)
			{
				foreach (Enum value in Enum.GetValues(unit.ownership.GetType()))
				{
					if(unit.ownership.HasFlag(value))
						TWRandom.UnitByFaction.AddKV((FactionOwnership)value, unit.type);
				}
			}
		}

		private static bool FlagDuplicateCheck<T>(T newFlag, T currFlags)
		{
			var nf = newFlag as Enum;
			var cf = currFlags as Enum;

			if (cf.HasFlag(nf))
				return true;
			else return false;


		}
	}
}

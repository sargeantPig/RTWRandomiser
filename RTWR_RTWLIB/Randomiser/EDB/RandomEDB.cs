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
using RTWLib.Objects.Buildings;
using RTWR_RTWLIB.Data;

namespace RTWR_RTWLIB.Randomiser
{

	public static class RandomEDB
	{
		public static Options advancedOptions { get; set; }

		public static void SetRecruitment(this EDB edb)
		{
			foreach (CoreBuilding cb in edb.buildingTrees)
				foreach (Building b in cb.buildings)
					foreach (Brecruit br in b.capability.canRecruit)
					{
						br.requiresFactions.Clear();

						br.requiresFactions = new List<string>(TWRandom.UnitByFaction.GetFactions(br.name));
					}

		}
	}


}

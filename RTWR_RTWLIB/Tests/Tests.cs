using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace RTWR_RTWLIB.Tests
{
	public class TestStore
	{
		public string DIRECTORY = @"randomiser\tests\";
		public List<Test> tests = new List<Test>();

	}

	public class Test 
	{
		public string name; 
		public int target;
		public int iter;

		public Test(string n, int t, int i)
		{
			name = n;
			target = t;
			iter = i;
		}

		public Test() { }

		public Test Parse(string file)
		{
			StreamReader sr = new StreamReader(file);
			string line = "";

			while ((line = sr.ReadLine()) != null)
			{
				if (line.StartsWith("test"))
				{
					name = line.Split('\t')[1];
				}

				else if (line.StartsWith("target"))
				{
					target = Convert.ToInt32(line.Split('\t')[1]);
				}

				else if (line.StartsWith("iter"))
				{
					iter = Convert.ToInt32(line.Split('\t')[1]);
				}

			}

			return new Test(name, target, iter);

		}
	}

}

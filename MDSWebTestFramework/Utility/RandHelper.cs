using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS.WebTestFramework.Utility
{
    public static class RandHelper
    {
        private static System.Random rnd = new System.Random();

        public static int GetRandomInt(int minValue, int maxValue)
        {
            return rnd.Next(minValue, maxValue);
        }

        public static double GetRandomDouble()
        {
            return rnd.NextDouble();
        }

    }
}

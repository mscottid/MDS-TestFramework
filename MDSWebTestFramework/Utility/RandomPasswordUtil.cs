using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS.WebTestFramework.Utility
{
    public static class PasswordUtil
    {
        #region User Pwd Gen
        public static string PasswordGen(int numChars)
        {
            char[] myChars = new char[numChars];

            for (int x = 0; x < numChars; x++)
            {
                myChars[x] = Convert.ToChar(RandHelper.GetRandomInt(65, 90));
            }

            return new string(myChars); ;
        }

        public static string PasswordAsterisks(int numChars)
        {
            char[] myChars = new char[numChars];

            for (int x = 0; x < numChars; x++)
            {
                myChars[x] = '*';
            }

            return new string(myChars); ;
        }
        #endregion
    }
}

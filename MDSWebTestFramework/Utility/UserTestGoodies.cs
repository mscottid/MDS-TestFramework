using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using MDS.WebTestFramework.Models.Utility;


namespace MDS.WebTestFramework.Utility
{
    public static class UserTestGoodies
    {
        public static FakeUserRootObject GetRandomUser()
        {

            string outputStr = null;
            FakeUserRootObject output = null;
            using (WebClient wc = new WebClient())
            {
                outputStr = wc.DownloadString("https://randomuser.me/api/");
            }
            if (!string.IsNullOrEmpty(outputStr))
            {
                output = JsonConvert.DeserializeObject<FakeUserRootObject>(outputStr);
            }
            return output;
        }


    }
}
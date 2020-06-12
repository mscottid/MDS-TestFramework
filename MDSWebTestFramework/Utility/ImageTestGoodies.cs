
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;

namespace MDSWebTestFramework.Utility
{
    public static class ImageTestGoodies
    {

        public static void DownloadRandomFile(int width, int height, string fileName)
        {
            using (WebClient wc = new WebClient())
            {
                wc.DownloadFile(string.Format("https://picsum.photos/{0}/{1}/?random", width.ToString(),
                    height.ToString()), fileName);
            }
        }

        public static byte[] DownloadRandomFileBytes(int width, int height)
        {
            byte[] output = null;
            using (WebClient wc = new WebClient())
            {
                output = wc.DownloadData(string.Format("https://picsum.photos/{0}/{1}/?random", width.ToString(),
                    height.ToString()));
            }

            return output;
        }


    }
}

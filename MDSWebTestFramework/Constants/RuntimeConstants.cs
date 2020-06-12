using System;
using System.Configuration;

namespace MDS.WebTestFramework.Constants
{
    public enum EntityCRUDOperation
    {
        Create,
        Read,
        Update,
        Delete
    }
    public static class RuntimeConstants
    {
        public static bool UseIEDriver = Convert.ToBoolean(ConfigurationManager.AppSettings["UseIEDriver"]);
        public static int WaitForLoadTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["WaitForLoadTimeout"]); 
        public static string IEDriverPath = ConfigurationManager.AppSettings["IEDriverPath"];
        public static string ChromeDriverPath = ConfigurationManager.AppSettings["ChromeDriverPath"];

        public static string RegistrationBasePageUrl = ConfigurationManager.AppSettings["RegBasePageUrl"];

    }
}

using System;


namespace API
{
    public static class Config
    {

        public static string baseUrl = "https://cockpit.educom.nu/api/collections";
        public static string token = "bd216b5098452677789be90f7c4f4f";

        public static string getCustomers = "/get/Customers";
        public static string saveCustomers = "/save/Customers";
        public static string removeCustomers = "/remove/Customers";


        public static string CreateUrl(string url)
        {
            string requestUrl = String.Format("{0}{1}?token={2}", Config.baseUrl, url, Config.token);         
            return (requestUrl);

        }

        public static void Log(string log)
        {
            Console.WriteLine(String.Format("*** {0} ***", log));
        }

    }
}

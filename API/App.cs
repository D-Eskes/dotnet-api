using System;
using System.Net;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

/// For easy deserialization
/// Nancy Serialization JsonNet NuGet package
using Nancy.Json;



namespace API
{
    public class App
    {
        /**
         * Generic: fetchData
         * Return: (unserialized) JSON String
         */
        private string fetchData(string url)
        {
            string result;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Config.CreateUrl(url));
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream receiveStream = response.GetResponseStream();
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);

            result = readStream.ReadToEnd();

            response.Close();
            readStream.Close();

            return (result);

        }

        /**
         * Generic: putData
         * Return: (unserialized) JSON String
         */
        private string putData(string url, string json)
        {
            string result;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Config.CreateUrl(url));
            request.ContentType = "application/json";
            request.Method = "POST";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(json);
            }


            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }

            return (result);
        }


        /// Specifics

        public Customer createCustomer(CustomerPost customer)        
        {
            string json = JsonSerializer.Serialize(customer);
            string result = putData(Config.saveCustomers, json);
            Customer newCustomer = new JavaScriptSerializer().Deserialize<Customer>(result);

            return (newCustomer);
        }

        public Customers getCustomers()
        {
            string result = fetchData(Config.getCustomers);           
            var allCustomers = new JavaScriptSerializer().Deserialize<Customers>(result);            

            return (allCustomers);

        }

    }
}

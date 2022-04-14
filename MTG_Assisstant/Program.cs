using System;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using AWSCommunication;

namespace MTG_Assisstant
{


    class Program
    {        
        static void Main(string[] args)
        {            
            Data().GetAwaiter().GetResult();
        }

        static async Task Data()
        {
            var newService = new CognitoCommunication("us-east-1:ef819d05-dc22-4b12-879b-d28c18a8aeb0",
                "35otkm9kefk1m5j9lprvamc0b2", "us-east-1_HZY2fnDBy", Amazon.RegionEndpoint.USEast1);

            //var result = await newService.SignUp("TestAccount", "guidry.dylan.95@gmail.com", "p@55wOrd");
            //var result = await newService.ConfirmRegistration("TestAccount", "645978");
            //var result = await newService.Login("TestAccount", "p@55wOrd");

            var table = new DynamoCommunication();
            await table.TryCreateTable("TestTable",
                new List<KeyValuePair<string, string>> { new KeyValuePair<string, string>("Id", "N") },
                new List<KeyValuePair<string, string>> { new KeyValuePair<string, string>("Id", "HASH") });

            //Console.WriteLine(result["Message"]);
        }
    }
}

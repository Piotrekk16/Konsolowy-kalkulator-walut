using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace ConsoleApplication8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("podaj pierwszą walutę");
            string waluta1 = Console.ReadLine();

            Console.WriteLine("podaj drugą walutę");
            string waluta2 = Console.ReadLine();

            Console.WriteLine("podaj datę w formacie YYYY-MM-DD");
            string data = Console.ReadLine();

            var exUrl = "http://api.fixer.io/" + data + "?base=" + waluta1 + "&symbols=" + waluta2; //stworzenie linku
            string kursWymiany="";
            using (var webClient = new System.Net.WebClient()) 
            {
                var json = webClient.DownloadString(exUrl); 

                var stuff = JObject.Parse(json);
                

                foreach (var rate in stuff["rates"].Cast<JProperty>()) 
                {
                     kursWymiany= rate.Value.ToString(); 
                }
            }

            Console.WriteLine(kursWymiany);
            Console.ReadKey();
        }
    }
}

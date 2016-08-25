using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace ApiHost
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://localhost:8082/";
            Console.WriteLine("Démarrage du serveur à l'adresse : " + url);
            using (WebApp.Start<Startup>(url))
            {
                Console.WriteLine("Serveur démarré.");
                Console.ReadKey();
            }
        }
    }


}

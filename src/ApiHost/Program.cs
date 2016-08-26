using System;
using Microsoft.Owin.Hosting;

namespace ApiHost
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var url = "http://localhost:8082/";
            Console.WriteLine("Démarrage du serveur à l'adresse : " + url);
            using (WebApp.Start<Startup>(url))
            {
                Console.WriteLine("Serveur démarré.");
                Console.ReadKey();
            }
        }
    }
}
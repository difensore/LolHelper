using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LolHelper
{
    static class Menu
    {
        private static string name;
        public static void Start()
        {
            bool ServerConnection = false;
            string name;
            Console.WriteLine("Enter your sql server name: ");
            name = Console.ReadLine();
            LolHelperContext.ServerName = name;
            using (LolHelperContext db = new LolHelperContext())
            {
                var c = from Champ in db.Champs
                        select Champ;               
                {
                    try
                    {
                        foreach (var v in c)
                        { }
                        ServerConnection = true;
                    }
                    catch
                    {
                        ServerConnection = false;
                        Console.WriteLine("Sorry, but you enter wrong server name, please try again");
                    }
                }
            }
            if (ServerConnection == false)
                Start();
        }
        public static void EnterName()
        {
            Console.WriteLine("Enter the champion that you want to contrpick: ");
            name = Console.ReadLine();
            Contrpick.GetContr(name);
            Contrpick.AsyncBuildContr();
        }
    }
}

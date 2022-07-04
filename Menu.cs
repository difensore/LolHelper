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
            Console.WriteLine("Welcome to LolHelper!");
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

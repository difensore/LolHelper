using System;
using System.IO;

namespace LolHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to LolHelper!");

           Menu.Start();
            Menu.EnterName();
        }
    }
}

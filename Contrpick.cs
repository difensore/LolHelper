using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace LolHelper
{
    static class Contrpick
    {

        public static int id { get; private set; }

        public static void GetContr(string name)
        {           
            using (LolHelperContext db = new LolHelperContext())
            {
                var champ = db.Champs;
                IQueryable<int> champq = null;
                foreach (Champ c in champ)
                {
                    if (name == c.Name)
                    {
                        var con = from Contr in db.Contrs
                                  where Contr.Champ == c.Id
                                  select Contr.Contr1;
                        champq = con;
                        break;
                    }
                }
                if (champq == null)
                {
                    Console.WriteLine("Sry, we haven't added this chimion to our database yet, chek it later");
                    Menu.EnterName();
                }
                foreach (var c in champq)
                {
                    id = c;
                }
            }
        }
        public static void AsyncBuildContr()
        {
            CreateContr cc = new CreateContr(new ChampAbility(), id);
            Task champ = cc.AsyncPrint();
            cc.printer = new SpellPrint();
            Task spells = cc.AsyncPrint();
            cc.printer = new ItemsPrint();
            Task items = cc.AsyncPrint();
            cc.printer = new RunesPrint();
            Task runes = cc.AsyncPrint();
            Task.WaitAll(champ, spells, items, runes);
            Menu.EnterName();
            Console.ReadLine();
        }
    }
}

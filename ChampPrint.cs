using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LolHelper
{
  class ChampPrint:IPrint
    {
        public async Task Asyncprint(int id)
        {
           await using (LolHelperContext db = new LolHelperContext())
            {
                var champ = from Champ in db.Champs
                            join Pick in db.Picks on Champ.Id equals Pick.Champ
                        where Pick.Id == id
                        select Champ;
                foreach(var ch in champ )
                {               
                    Console.WriteLine($"\nYou should pick {ch.Name}");
                }
            }
        }
    }
}

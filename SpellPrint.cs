using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LolHelper
{
    class SpellPrint : IPrint
    {
        public async Task Asyncprint(int id)
        {
            await using (LolHelperContext db = new LolHelperContext())
            {
                var FirstSpell =await(from Spell in db.Spells
                                 join Pick in db.Picks on Spell.Id equals Pick.FirstSpell
                                 where Pick.Id == id
                                 select Spell).ToListAsync();            
                Console.WriteLine("\nSpells:");
                foreach (var s in FirstSpell)
                {
                    Console.WriteLine($"First spell: {s.Name}, cooldowm-{s.Cooldown} seconds");
                }             
            }
            await using(LolHelperContext db = new LolHelperContext())
            {
                var SecondSpell = await(from Spell in db.Spells
                                  join Pick in db.Picks on Spell.Id equals Pick.SecondSpell
                                  where Pick.Id == id
                                  select Spell).ToListAsync();
                foreach (var s in SecondSpell)
                {
                    Console.WriteLine($"Second spell: {s.Name}, cooldowm-{s.Cooldown} seconds");
                }
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LolHelper
{
    class ItemsPrint : IPrint
    {
        public async Task Asyncprint(int id)
        {
            await using (LolHelperContext db = new LolHelperContext())
            {
                var Firstitem = await(from Item in db.Items
                                join Pick in db.Picks on Item.Id equals Pick.FirstStartedItem
                                where Pick.Id == id
                                select Item).ToListAsync();                                          
                Console.WriteLine("\nITEMS:");
                foreach (var i in Firstitem)
                {
                    Console.WriteLine($@"First started item: {i.Name}, price-{i.Price}");
                }
            }
            await using (LolHelperContext db = new LolHelperContext())
            {
                var Seconditem = await(from Item in db.Items
                                 join Pick in db.Picks on Item.Id equals Pick.SecondStartedItem
                                 where Pick.Id == id
                                 select Item).ToListAsync();
                foreach (var i in Seconditem)
                {
                    Console.WriteLine($@"Second started item: {i.Name}, price-{i.Price}");
                }
            }
            await using (LolHelperContext db = new LolHelperContext())
            {
                var Thirditem = await(from Item in db.Items
                                join Pick in db.Picks on Item.Id equals Pick.ThirdStartedItem
                                where Pick.Id == id
                                select Item).ToListAsync();
                foreach (var i in Thirditem)
                {
                    if (i != null)
                        Console.WriteLine($@"Third started item: {i.Name}, price-{i.Price}");
                }
            }
            await using (LolHelperContext db = new LolHelperContext())
            {
                var FirstMitem = await(from Item in db.Items
                                 join Pick in db.Picks on Item.Id equals Pick.FirstMainItem
                                 where Pick.Id == id
                                 select Item).ToListAsync();
                foreach (var i in FirstMitem)
                {
                    Console.WriteLine($@"First main item: {i.Name}, price-{i.Price}");
                }
            }
            await using (LolHelperContext db = new LolHelperContext())
            {
                var SecondMitem = await(from Item in db.Items
                                  join Pick in db.Picks on Item.Id equals Pick.SecondMainItem
                                  where Pick.Id == id
                                  select Item).ToListAsync();
                foreach (var i in SecondMitem)
                {
                    Console.WriteLine($@"Second main item: {i.Name}, price-{i.Price}");
                }
            }
            await using (LolHelperContext db = new LolHelperContext())
            {
                var ThirdMitem = await(from Item in db.Items
                                 join Pick in db.Picks on Item.Id equals Pick.ThirdMainItem
                                 where Pick.Id == id
                                 select Item).ToListAsync();
                foreach (var i in ThirdMitem)
                {
                    Console.WriteLine($@"Third main item: {i.Name}, price-{i.Price}");
                }
            }
            await using (LolHelperContext db = new LolHelperContext())
            {
                var FourthMitem = await(from Item in db.Items
                                  join Pick in db.Picks on Item.Id equals Pick.FivthMainItem
                                  where Pick.Id == id
                                  select Item).ToListAsync();
                foreach (var i in FourthMitem)
                {
                    Console.WriteLine($@"Fourth main item: {i.Name}, price-{i.Price}");
                }
            }
        }
    }
}

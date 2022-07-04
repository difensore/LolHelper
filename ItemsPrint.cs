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
                var Firstitem = from Item in db.Items
                                join Pick in db.Picks on Item.Id equals Pick.FirstStartedItem
                                where Pick.Id == id
                                select Item;
                var Seconditem = from Item in db.Items
                                 join Pick in db.Picks on Item.Id equals Pick.SecondStartedItem
                                 where Pick.Id == id
                                 select Item;
                var Thirditem = from Item in db.Items
                                join Pick in db.Picks on Item.Id equals Pick.ThirdStartedItem
                                where Pick.Id == id
                                select Item;
                var FirstMitem = from Item in db.Items
                                 join Pick in db.Picks on Item.Id equals Pick.FirstMainItem
                                 where Pick.Id == id
                                 select Item;
                var SecondMitem = from Item in db.Items
                                  join Pick in db.Picks on Item.Id equals Pick.SecondMainItem
                                  where Pick.Id == id
                                  select Item;
                var ThirdMitem = from Item in db.Items
                                 join Pick in db.Picks on Item.Id equals Pick.ThirdMainItem
                                 where Pick.Id == id
                                 select Item;
                var FourthMitem = from Item in db.Items
                                  join Pick in db.Picks on Item.Id equals Pick.FivthMainItem
                                  where Pick.Id == id
                                  select Item;
                Console.WriteLine("\nITEMS:");
                foreach (var i in Firstitem)
                {
                    Console.WriteLine($@"First started item: {i.Name}, price-{i.Price}");                 
                }
                foreach (var i in Seconditem)
                {
                    Console.WriteLine($@"Second started item: {i.Name}, price-{i.Price}");
                }
                foreach (var i in Thirditem)
                {
                    if (i != null)
                        Console.WriteLine($@"Third started item: {i.Name}, price-{i.Price}");
                }
                foreach (var i in FirstMitem)
                {
                    Console.WriteLine($@"First main item: {i.Name}, price-{i.Price}");
                }
                foreach (var i in SecondMitem)
                {
                    Console.WriteLine($@"Second main item: {i.Name}, price-{i.Price}");
                }
                foreach (var i in ThirdMitem)
                {
                    Console.WriteLine($@"Third main item: {i.Name}, price-{i.Price}");
                }
                foreach (var i in FourthMitem)
                {
                    Console.WriteLine($@"Fourth main item: {i.Name}, price-{i.Price}");
                }
            }

        }
    }
}

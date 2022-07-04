using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LolHelper
{
    class RunesPrint : IPrint
    {
        public async Task Asyncprint(int id)
        {
            await using (LolHelperContext db = new LolHelperContext())
            {
                IQueryable<string> Fmr = null;
                IQueryable<string> Smr = null;
                IQueryable<string> FR = null;
                IQueryable<string> SR = null;
                IQueryable<string> TR = null;
                IQueryable<string> FoR = null;
                IQueryable<string> FRS = null;
                IQueryable<string> SRS = null;
                IQueryable<string> FE = null;
                IQueryable<string> SE = null;
                IQueryable<string> TE = null;
                var RuneBuild = from RunesBuild in db.RunesBuilds
                                join Pick in db.Picks on RunesBuild.Id equals Pick.RunesBuild
                                where Pick.Id == id
                                select RunesBuild;
                foreach (var r in RuneBuild)
                {
                    var FirstMainRune = from MainRune in db.MainRunes
                                        join RunesBuild in db.RunesBuilds on MainRune.Id equals RunesBuild.MainrRune
                                        select MainRune.Name;
                    var SecondMainRune = from MainRune in db.MainRunes
                                         join RunesBuild in db.RunesBuilds on MainRune.Id equals RunesBuild.SecondMainRune
                                         select MainRune.Name;
                    var FirstRune = from Rune in db.Runes
                                    join RunesBuild in db.RunesBuilds on Rune.Id equals RunesBuild.FirstRune
                                    select Rune.Name;
                    var SecondRune = from Rune in db.Runes
                                     join RunesBuild in db.RunesBuilds on Rune.Id equals RunesBuild.SecondRune
                                     select Rune.Name;
                    var ThirdRune = from Rune in db.Runes
                                    join RunesBuild in db.RunesBuilds on Rune.Id equals RunesBuild.ThirdRune
                                    select Rune.Name;
                    var FourthRune = from Rune in db.Runes
                                     join RunesBuild in db.RunesBuilds on Rune.Id equals RunesBuild.FourthRune
                                     select Rune.Name;
                    var FirstRuneS = from Rune in db.Runes
                                     join RunesBuild in db.RunesBuilds on Rune.Id equals RunesBuild.FirstRuneS
                                     select Rune.Name;
                    var SecondRuneS = from Rune in db.Runes
                                      join RunesBuild in db.RunesBuilds on Rune.Id equals RunesBuild.SecondRuneS
                                      select Rune.Name;
                    var FirstExtra = from ExtraRune in db.ExtraRunes
                                     join RunesBuild in db.RunesBuilds on ExtraRune.Id equals RunesBuild.FirstExtraRune
                                     select ExtraRune.Name;
                    var SecondExtra = from ExtraRune in db.ExtraRunes
                                      join RunesBuild in db.RunesBuilds on ExtraRune.Id equals RunesBuild.SecondExtraRune
                                      select ExtraRune.Name;
                    var ThirdExtra = from ExtraRune in db.ExtraRunes
                                     join RunesBuild in db.RunesBuilds on ExtraRune.Id equals RunesBuild.ThirdExtraRune
                                     select ExtraRune.Name;
                    Fmr = FirstMainRune;
                    Smr = SecondMainRune;
                    FR = FirstRune;
                    SR = SecondRune;
                    TR = ThirdRune;
                    FoR = FourthRune;
                    FRS = FirstRuneS;
                    SRS = FirstRuneS;
                    SE = SecondRuneS;
                    FE = FirstExtra;
                    SE = SecondExtra;
                    TE = ThirdExtra;
                }
                Console.WriteLine("\nRUNES:");
                foreach (var r in Fmr)
                {
                    Console.WriteLine(r);
                }
                foreach (var r in FR)
                {
                    Console.WriteLine(r);
                }
                foreach (var r in SR)
                {
                    Console.WriteLine(r);
                }
                foreach (var r in TR)
                {
                    Console.WriteLine(r);
                }
                foreach (var r in FR)
                {
                    Console.WriteLine(r);
                }
                foreach (var r in Smr)
                {
                    Console.WriteLine(r);
                }
                foreach (var r in FRS)
                {
                    Console.WriteLine(r);
                }
                foreach (var r in SRS)
                {
                    Console.WriteLine(r);
                }
                foreach (var r in FE)
                {
                    Console.WriteLine(r);
                }
                foreach (var r in SE)
                {
                    Console.WriteLine(r);
                }
                foreach (var r in TE)
                {
                    Console.WriteLine(r);
                }
            }
        }
    }
}

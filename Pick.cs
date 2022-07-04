using System;
using System.Collections.Generic;

#nullable disable

namespace LolHelper
{
    public partial class Pick
    {
        public Pick()
        {
            Contrs = new HashSet<Contr>();
        }
        public int Id { get; set; }
        public string Position { get; set; }
        public int Champ { get; set; }
        public int FirstSpell { get; set; }
        public int SecondSpell { get; set; }
        public int RunesBuild { get; set; }
        public int FirstStartedItem { get; set; }
        public int SecondStartedItem { get; set; }
        public int? ThirdStartedItem { get; set; }
        public int FirstMainItem { get; set; }
        public int SecondMainItem { get; set; }
        public int ThirdMainItem { get; set; }
        public int FivthMainItem { get; set; }

        public virtual Champ ChampNavigation { get; set; }
        public virtual Item FirstMainItemNavigation { get; set; }
        public virtual Spell FirstSpellNavigation { get; set; }
        public virtual Item FirstStartedItemNavigation { get; set; }
        public virtual RunesBuild RunesBuildNavigation { get; set; }
        public virtual Item SecondMainItemNavigation { get; set; }
        public virtual Spell SecondSpellNavigation { get; set; }
        public virtual Item SecondStartedItemNavigation { get; set; }
        public virtual Item ThirdMainItemNavigation { get; set; }
        public virtual Item ThirdStartedItemNavigation { get; set; }
        public virtual ICollection<Contr> Contrs { get; set; }
    }
}

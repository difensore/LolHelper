using System;
using System.Collections.Generic;

#nullable disable

namespace LolHelper
{
    public partial class RunesBuild
    {
        public RunesBuild()
        {
            Picks = new HashSet<Pick>();
        }

        public int Id { get; set; }
        public int MainrRune { get; set; }
        public int FirstRune { get; set; }
        public int SecondRune { get; set; }
        public int ThirdRune { get; set; }
        public int FourthRune { get; set; }
        public int SecondMainRune { get; set; }
        public int FirstRuneS { get; set; }
        public int SecondRuneS { get; set; }
        public int FirstExtraRune { get; set; }
        public int SecondExtraRune { get; set; }
        public int ThirdExtraRune { get; set; }

        public virtual ExtraRune FirstExtraRuneNavigation { get; set; }
        public virtual Rune FirstRuneNavigation { get; set; }
        public virtual Rune FirstRuneSNavigation { get; set; }
        public virtual Rune FourthRuneNavigation { get; set; }
        public virtual MainRune MainrRuneNavigation { get; set; }
        public virtual ExtraRune SecondExtraRuneNavigation { get; set; }
        public virtual MainRune SecondMainRuneNavigation { get; set; }
        public virtual Rune SecondRuneNavigation { get; set; }
        public virtual Rune SecondRuneSNavigation { get; set; }
        public virtual ExtraRune ThirdExtraRuneNavigation { get; set; }
        public virtual Rune ThirdRuneNavigation { get; set; }
        public virtual ICollection<Pick> Picks { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;

#nullable disable

namespace LolHelper
{
    public partial class MainRune
    {
        public MainRune()
        {
            Runes = new HashSet<Rune>();
            RunesBuildMainrRuneNavigations = new HashSet<RunesBuild>();
            RunesBuildSecondMainRuneNavigations = new HashSet<RunesBuild>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public virtual ICollection<Rune> Runes { get; set; }
        public virtual ICollection<RunesBuild> RunesBuildMainrRuneNavigations { get; set; }
        public virtual ICollection<RunesBuild> RunesBuildSecondMainRuneNavigations { get; set; }
    }
}

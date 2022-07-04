﻿using System;
using System.Collections.Generic;

#nullable disable

namespace LolHelper
{
    public partial class ExtraRune
    {
        public ExtraRune()
        {
            RunesBuildFirstExtraRuneNavigations = new HashSet<RunesBuild>();
            RunesBuildSecondExtraRuneNavigations = new HashSet<RunesBuild>();
            RunesBuildThirdExtraRuneNavigations = new HashSet<RunesBuild>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public virtual ICollection<RunesBuild> RunesBuildFirstExtraRuneNavigations { get; set; }
        public virtual ICollection<RunesBuild> RunesBuildSecondExtraRuneNavigations { get; set; }
        public virtual ICollection<RunesBuild> RunesBuildThirdExtraRuneNavigations { get; set; }
    }
}

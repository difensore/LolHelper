using System;
using System.Collections.Generic;

#nullable disable

namespace LolHelper
{
    public partial class Spell
    {
        public Spell()
        {
            PickFirstSpellNavigations = new HashSet<Pick>();
            PickSecondSpellNavigations = new HashSet<Pick>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Cooldown { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public virtual ICollection<Pick> PickFirstSpellNavigations { get; set; }
        public virtual ICollection<Pick> PickSecondSpellNavigations { get; set; }
    }
}

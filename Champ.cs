using System;
using System.Collections.Generic;

#nullable disable

namespace LolHelper
{
    public partial class Champ
    {
        public Champ()
        {
            Contrs = new HashSet<Contr>();
            Picks = new HashSet<Pick>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Q { get; set; }
        public string W { get; set; }
        public string E { get; set; }
        public string R { get; set; }
        public string Passive { get; set; }
        public string Image { get; set; }

        public virtual ICollection<Contr> Contrs { get; set; }
        public virtual ICollection<Pick> Picks { get; set; }
    }
}

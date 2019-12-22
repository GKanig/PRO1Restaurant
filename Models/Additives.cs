using System;
using System.Collections.Generic;

namespace PRO1Restaurant.Models
{
    public partial class Additives
    {
        public Additives()
        {
            AdditivesList = new HashSet<AdditivesList>();
        }

        public int Id { get; set; }
        public int Name { get; set; }
        public decimal NetPrice { get; set; }

        public virtual ICollection<AdditivesList> AdditivesList { get; set; }
    }
}

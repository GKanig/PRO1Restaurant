using System;
using System.Collections.Generic;

namespace PRO1Restaurant.Models
{
    public partial class Promotion
    {
        public Promotion()
        {
            Order = new HashSet<Order>();
        }

        public int Id { get; set; }
        public int Name { get; set; }
        public int Amount { get; set; }
        public byte IsActive { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}

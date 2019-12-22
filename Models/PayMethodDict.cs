using System;
using System.Collections.Generic;

namespace PRO1Restaurant.Models
{
    public partial class PayMethodDict
    {
        public PayMethodDict()
        {
            Order = new HashSet<Order>();
        }

        public int Id { get; set; }
        public int Name { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}

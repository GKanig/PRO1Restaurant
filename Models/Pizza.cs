using System;
using System.Collections.Generic;

namespace PRO1Restaurant.Models
{
    public partial class Pizza
    {
        public Pizza()
        {
            OrderItem = new HashSet<OrderItem>();
        }

        public int Id { get; set; }
        public int Name { get; set; }
        public int Description { get; set; }
        public decimal NetPrice { get; set; }

        public virtual ICollection<OrderItem> OrderItem { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace PRO1Restaurant.Models
{
    public partial class OrderItem
    {
        public OrderItem()
        {
            AdditivesList = new HashSet<AdditivesList>();
        }

        public int Id { get; set; }
        public int OrderId { get; set; }
        public int PizzaId { get; set; }
        public int Count { get; set; }

        public virtual Order Order { get; set; }
        public virtual Pizza Pizza { get; set; }
        public virtual ICollection<AdditivesList> AdditivesList { get; set; }
    }
}

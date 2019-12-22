using System;
using System.Collections.Generic;

namespace PRO1Restaurant.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderItem = new HashSet<OrderItem>();
        }

        public int Id { get; set; }
        public int ClientId { get; set; }
        public byte IsPaid { get; set; }
        public int PromotionId { get; set; }
        public int StatusId { get; set; }
        public int PayMethodId { get; set; }

        public virtual Client Client { get; set; }
        public virtual PayMethodDict PayMethod { get; set; }
        public virtual Promotion Promotion { get; set; }
        public virtual StatusDict Status { get; set; }
        public virtual ICollection<OrderItem> OrderItem { get; set; }
    }
}

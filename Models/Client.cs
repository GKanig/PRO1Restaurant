using System;
using System.Collections.Generic;

namespace PRO1Restaurant.Models
{
    public partial class Client
    {
        public Client()
        {
            Order = new HashSet<Order>();
        }

        public int ClientId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}

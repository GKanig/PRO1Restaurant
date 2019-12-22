using System;
using System.Collections.Generic;

namespace PRO1Restaurant.Models
{
    public partial class AdditivesList
    {
        public int AdditivesListId { get; set; }
        public int OrderItemId { get; set; }
        public int AdditivesId { get; set; }

        public virtual Additives Additives { get; set; }
        public virtual OrderItem OrderItem { get; set; }
    }
}

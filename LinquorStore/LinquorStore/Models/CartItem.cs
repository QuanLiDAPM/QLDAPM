using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinquorStore.Models
{
    public class CartItem
    {
        public SanPham Product { get; set; }
        public int Quantity { get; set; }
    }
}

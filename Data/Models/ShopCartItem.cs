using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Data.Models
{
    public class ShopCartItem
    {
        public int Id { get; set; }
        public required Car Car { get; set; }
        public int Price { get; set; }
        public required string ShopCarID { get; set; }
    }
}

using SahibindenBitirmeProjesi.Web.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SahibindenBitirmeProjesi.Web.Models.Vms
{
    public class CartViewModel
    {
        public CartViewModel()
        {
            CartItems = new List<CartItem>();
        }

        public List<CartItem> CartItems { get; set; }
        public decimal GrandTotal { get; set; }

    }
}

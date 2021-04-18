using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SahibindenBitirmeProjesi.Web.Models.Dtos
{
    public class CartItem
    {
        public int ModelId { get; set; }
        public string ModelName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get => Quantity*Total ; }

        public CartItem() { }

        public CartItem(SahibindenBitirmeProjesi.Entity.Entities.Concrete.Models model)
        {
            ModelId = model.Id;
            ModelName = model.Name;
            Price = model.UnitPrice;
            Quantity = 1;
        }

    }
}

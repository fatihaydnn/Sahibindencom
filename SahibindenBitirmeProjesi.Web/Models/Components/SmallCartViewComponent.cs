using Microsoft.AspNetCore.Mvc;
using SahibindenBitirmeProjesi.Web.Models.Dtos;
using SahibindenBitirmeProjesi.Web.Models.Extensions;
using SahibindenBitirmeProjesi.Web.Models.Vms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SahibindenBitirmeProjesi.Web.Models.Components
{
    public class SmallCartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");

            SmallCartViewModel smallCartViewModel;

            if (cart == null || cart.Count == 0)
            {
                smallCartViewModel = null;
            }
            else
            {
                smallCartViewModel = new SmallCartViewModel
                {
                    NumberOfItems = cart.Sum(x => x.Quantity),
                    TotalAmount = cart.Sum(x => x.Quantity * x.Price)
                };
            }

            return View(smallCartViewModel);
        }
    }
}

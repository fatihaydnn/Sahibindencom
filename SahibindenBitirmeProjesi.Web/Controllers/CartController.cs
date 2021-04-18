using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SahbindenBitirmeProjesi.Data.Context;
using SahibindenBitirmeProjesi.Web.Models.Dtos;
using SahibindenBitirmeProjesi.Web.Models.Extensions;
using SahibindenBitirmeProjesi.Web.Models.Vms;

namespace SahibindenBitirmeProjesi.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public CartController(ApplicationDbContext applicationDbContext) => _applicationDbContext = applicationDbContext;

        public IActionResult Index()
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            CartViewModel cartViewModel = new CartViewModel
            {
                CartItems = cart,
                GrandTotal = cart.Sum(x => x.Price * x.Quantity)
            };

            return View(cartViewModel);
        }

        public async Task<IActionResult> Add(int id)
        {
            SahibindenBitirmeProjesi.Entity.Entities.Concrete.Models model = await _applicationDbContext.Models.FindAsync(id);

            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            CartItem cartItem = cart.Where(x => x.ModelId == id).FirstOrDefault();

            if (cartItem == null)
            {
                cart.Add(new CartItem(model));
            }
            else
            {
                cartItem.Quantity += 1;
            }

            HttpContext.Session.SetJson("Cart", cart);

            if(HttpContext.Request.Headers["X-Request-With"] != "XMLHttpRequest")
            {
                return RedirectToAction("Index");
            }

            return ViewComponent("SmallCart");

        }

        public IActionResult Decrease(int id)
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            CartItem cartItem = cart.Where(x => x.ModelId == id).FirstOrDefault();

            if (cartItem.Quantity > 1)
                --cartItem.Quantity;
            else
                cart.RemoveAll(x => x.ModelId == id);

            if (cart.Count == 0)
                HttpContext.Session.Remove("Cart");
            else
                HttpContext.Session.SetJson("Cart", cart);

            return RedirectToAction("Index");

        }

        public IActionResult Remove(int id)
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");
            cart.RemoveAll(x => x.ModelId == id);

            if (cart.Count == 0)
                HttpContext.Session.Remove("Cart");
            else
                HttpContext.Session.SetJson("Cart", cart);

            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            HttpContext.Session.Remove("Cart");
            return RedirectToAction("Page", "Page");
        }

    }
}

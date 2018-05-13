using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ECommPract.Models.MainClasses;
using ECommPract.Models;

namespace ECommPract.Controllers
{
    public class ShoppingCartController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: ShoppingCart
        public ActionResult Cart()
        {   
            ShoppingCartActions cart = new ShoppingCartActions();
            //string ShoppingCartID = cart.GetCartId();
            //var cartItems = (from c in db.SHOPPINGCART
            //                 where c.CartId==ShoppingCartID
            //                 join p in db.PRODUCTSETUP on c.ProductId equals p.ProductId
            //                 select new 
            //                 {
            //                     c,
            //                     p.ProductName,
            //                     p.ProductImageUrl,
            //                     p.PRICE,
            //                     p.SIZE,
            //                     p.COLOR
            //                 }).ToList();
            var cartItems = cart.getCartItems();
            return View(cartItems);
        }
        [HttpPost]
        public ActionResult AddCart(int id,int cartQuantity)
        {
            ShoppingCartActions cart = new ShoppingCartActions();
            cart.AddToCart(id, cartQuantity);
            return RedirectToAction("Cart");
        }
        public ActionResult RemoveFromCart(int id,int productid)
        {
            ShoppingCartActions cart = new ShoppingCartActions();
            cart.RemoveFromCart(id, productid);
            return RedirectToAction("Cart");
        }
        public JsonResult CalculateTotal()
        {
            ShoppingCartActions cart = new ShoppingCartActions();
            var cartItems = cart.getCartItems();
            List<decimal> total = new List<decimal>();
            foreach(var c in cartItems)
            {
                total.Add(c.Quantity * c.Product.PRICE);
            }
            return Json(total, JsonRequestBehavior.AllowGet);
        }
    }
}
using ECommPract.Models;
using ECommPract.Models.MainClasses;
using ECommPract.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommPract.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        // GET: Checkout
        public ActionResult Checkout()
        {
            CheckoutViewModel vmCheckout = new CheckoutViewModel();
            ShoppingCartActions cart = new ShoppingCartActions();
            var cartItems = cart.getCartItems();
            vmCheckout.shoppingCart = cartItems;
            vmCheckout.Grandtotal = cart.GetGrandTotal();
            return View(vmCheckout);
        }
        [HttpPost]
        public ActionResult Checkout(CheckoutViewModel vmModel)
        {
            if(ModelState.IsValid)
            {
                ApplicationDbContext db = new ApplicationDbContext();
                db.ORDER.Add(vmModel.order);
                db.SaveChanges();
                return RedirectToAction("Checkout");
            }
            else
            {
                return View(vmModel);
            }
        }
    }
}
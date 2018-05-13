using ECommPract.Models;
using ECommPract.Models.MainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ECommPract
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Session_End()
        {
            //ApplicationDbContext db = new ApplicationDbContext();
            //ShoppingCartActions cart = new ShoppingCartActions();
            //string _shoppingCartId = cart.GetCartId();
            //if(_shoppingCartId != User.Identity.Name)
            //{
            //    var cartItems = db.SHOPPINGCART.Where(x => x.CartId == _shoppingCartId).ToList();
            //    db.SHOPPINGCART.RemoveRange(cartItems);
            //    db.SaveChanges();
            //}
        }
        protected void Application_End()
        {
            //ApplicationDbContext db = new ApplicationDbContext();
            //ShoppingCartActions cart = new ShoppingCartActions();
            //string _shoppingCartId = cart.GetCartId();
            //if (_shoppingCartId != User.Identity.Name)
            //{
            //    var cartItems = db.SHOPPINGCART.Where(x => x.CartId == _shoppingCartId).ToList();
            //    db.SHOPPINGCART.RemoveRange(cartItems);
            //    db.SaveChanges();
            //}
        }
    }
}

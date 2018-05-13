using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using ECommPract.Models;
using ECommPract.Models.MainClasses;


namespace ECommPract.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Product(int? categoryid,int? page)
        {   
            int pageSize = 9;
            int pageNumber = page ?? 1;
            var model = from d in db.PRODUCTSETUP
                        where (categoryid??0)==0 || d.CATEGORYID == categoryid
                        select d;
            return View(model.OrderBy(m=>m.ProductId).ToPagedList(pageNumber,pageSize));
        }
        public ActionResult ProductDetails(int id)
        {
            var productDetail = db.PRODUCTSETUP.Where(x => x.ProductId == id).FirstOrDefault();
            return View(productDetail);
        }
        public JsonResult CheckCart(int productid)
        {
            ShoppingCartActions cart = new ShoppingCartActions();
            string _shoppingCartId = cart.GetCartId();
            int returnValue = 0;
            var cartItems = db.SHOPPINGCART.Where(p => p.ProductId == productid && p.CartId == _shoppingCartId).ToList();
            if(cartItems.Count>0)
            {
                returnValue = 1;
            }
            return Json(returnValue, JsonRequestBehavior.AllowGet);
        }
    }
}
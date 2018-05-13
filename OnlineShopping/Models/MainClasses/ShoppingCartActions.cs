using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
namespace ECommPract.Models.MainClasses
{
    public class ShoppingCartActions :IDisposable
    {
        public string ShoppingCartID { get; set; }
        public ApplicationDbContext db = new ApplicationDbContext();
        public const string cartSessionKey = "cartID";
        public void AddToCart(int id,int quantity)
        {
            ShoppingCartID = GetCartId();
            var cartItems = db.SHOPPINGCART.Where(x => x.CartId == ShoppingCartID && x.ProductId == id).SingleOrDefault();
            if(cartItems == null)
            {
                var cart = new ShoppingCart()
                {
                    CartId = ShoppingCartID,
                    ProductId = id,
                    Quantity = quantity,
                    Product = db.PRODUCTSETUP.SingleOrDefault(p => p.ProductId == id),
                    DateCreated = DateTime.Now
                };
                db.SHOPPINGCART.Add(cart);
            }
            else
            {
                //update code here
                cartItems.Quantity = quantity;
                db.Entry(cartItems).Property(x => x.Quantity).IsModified = true;
            }
            db.SaveChanges();
        }
        public List<ShoppingCart> getCartItems()
        {
            ShoppingCartID = GetCartId();
            return db.SHOPPINGCART.Where(x => x.CartId == ShoppingCartID).ToList();
        }
        public void RemoveFromCart(int id,int productid)
        {
            var cartItems = db.SHOPPINGCART.FirstOrDefault(p => p.ItemID == id && p.ProductId == productid);
            if(cartItems!=null)
            {
                db.SHOPPINGCART.Remove(cartItems);
                db.SaveChanges();
            }
        }
        public void MigrateCart(string cartId, string username)
        {
            var cartItems = db.SHOPPINGCART.Where(p => p.CartId == cartId);
            foreach(var items in cartItems)
            {
                items.CartId = username;
            }
            HttpContext.Current.Session[cartSessionKey] = username;
            db.SaveChanges();
        }
        public string GetCartId()
        {
            if(HttpContext.Current.Session[cartSessionKey]==null)
            {
                if(!string.IsNullOrWhiteSpace(HttpContext.Current.User.Identity.Name))
                {
                    HttpContext.Current.Session[cartSessionKey] = HttpContext.Current.User.Identity.Name;
                }
                else
                {
                    Guid tempId = Guid.NewGuid();
                    HttpContext.Current.Session[cartSessionKey] = tempId.ToString();
                }
            }
            return HttpContext.Current.Session[cartSessionKey].ToString();
        }
        public decimal GetTotal(int productId)
        {
            decimal _total = decimal.Zero;
            var _cartItems = db.SHOPPINGCART.Where(x => x.CartId == ShoppingCartID && x.ProductId==productId);
            foreach (var items in _cartItems)
            {
                _total += (items.Quantity * items.Product.PRICE);
            }
            return _total;
        }
        public double GetGrandTotal()
        {
            double _total = 0;
            double _grandTotal = 0;
            var _cartItems = db.SHOPPINGCART.Where(x => x.CartId == ShoppingCartID).ToList();
            foreach(var items in _cartItems)
            {
                _total += Convert.ToDouble(items.Quantity * items.Product.PRICE);
            }
            _grandTotal = _total - (_total * 0.175);
            return _grandTotal;
        }
        public void Dispose()
        {
            if(db!=null)
            {
                db.Dispose();
                db = null;
            }
        }
    }
}
using ECommPract.Models.MainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommPract.ViewModels
{
    public class CheckoutViewModel
    {
        public Order order { get; set; }
        public List<ShoppingCart> shoppingCart { get; set; }
        public double Grandtotal { get; set; }
    }
}
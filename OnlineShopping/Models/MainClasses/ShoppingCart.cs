using ECommPract.Models.SetupModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommPract.Models.MainClasses
{
    public class ShoppingCart
    {
        [Key]
        public int ItemID { get; set; }
        public string CartId { get; set; }
        public DateTime DateCreated { get; set; }
        public int ProductId { get; set; }
        public virtual ProductSetup Product { get; set; }
        public int Quantity { get; set; }
    }
}
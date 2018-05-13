using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommPract.Models.SetupModel
{
   
    public class ProductSetup
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ProductImageUrl { get; set; }
        public int QUANTITY { get; set; }
        public string SIZE { get; set; }
        public string COLOR { get; set; }
        public decimal PRICE { get; set; }
        public int CATEGORYID { get; set; }
        public virtual CategorySetup category { get; set; }
        public int BRANDID { get; set; }
        public virtual BrandSetup brand { get; set; }
        public string MODELNO { get; set; }
        public string PRODUCTDESC { get; set; }
        public string BRANDNAME { get; set; }
        public string CATEGORYNAME { get; set; }

    }
}
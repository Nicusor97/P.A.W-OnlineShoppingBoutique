using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommPract.Models.MainClasses
{
    public class OrderDetail
    {   
        [Key]
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
        public string quantity { get; set; }
        public double UnitPrice { get; set; }
    }
}
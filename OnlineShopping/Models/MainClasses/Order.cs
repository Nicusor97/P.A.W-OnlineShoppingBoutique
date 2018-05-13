using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommPract.Models.MainClasses
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime orderDate { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string TelNo { get; set; }
        public string Fax { get; set; }
        public string Company { get; set; }
        public string CompanyID { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Region_State { get; set; }
        public string Comment { get; set; }
        public List<ShoppingCart> shoppingCart { get; set; }
    }
}
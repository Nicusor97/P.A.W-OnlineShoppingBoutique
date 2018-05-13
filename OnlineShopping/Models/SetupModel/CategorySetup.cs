using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommPract.Models.SetupModel
{
    public class CategorySetup
    {
        [Key]
        public int CATEGORYID { get; set; }
        [Display(Name="Category Name")]
        public string CATEGORYNAME { get; set; }
    }
}
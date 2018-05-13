using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommPract.Models.SetupModel
{
    public class BrandSetup
    {
        [Key]
        public int BRANDID { get; set; }
        [Display(Name ="Brand Name")]
        public string BRANDNAME { get; set; }
        [Display(Name ="Brand Image")]
        public string BRANDIMAGEURL { get; set; }
    }
}
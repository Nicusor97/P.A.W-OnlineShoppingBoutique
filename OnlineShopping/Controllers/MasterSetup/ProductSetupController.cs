using ECommPract.Models;
using ECommPract.Models.SetupModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommPract.Controllers.MasterSetup
{
    public class ProductSetupController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: ProductSetup
        public ActionResult ProductSetup()
        {
           
            ViewBag.CategoryList = db.CATEGORYSETUP.ToList();
            ViewBag.BrandList = db.BRANDSETUP.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult ProductSetup(ProductSetup product,HttpPostedFileBase fileupload)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    if(fileupload!=null)
                    {
                        string path = "~/images/product/"+product.CATEGORYNAME+"/"+product.BRANDNAME;
                        if(!Directory.Exists(Server.MapPath(path)))
                        {
                            Directory.CreateDirectory(Server.MapPath(path));
                        }
                        fileupload.SaveAs(Server.MapPath(path+"/"+fileupload.FileName));
                        product.ProductImageUrl = path + "/" + fileupload.FileName.Replace(" ", "_");
                        db.PRODUCTSETUP.Add(product);
                        if(db.SaveChanges()>0)
                        {
                            ViewBag.Message = "Saved";
                        }
                        else
                        {
                            ViewBag.Message = "Not Saved";
                        }
                    }
                    return RedirectToAction("ProductSetup");
                }
                else
                {
                    return View();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
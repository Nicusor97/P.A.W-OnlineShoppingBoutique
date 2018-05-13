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
    public class CategoryController : Controller
    {
        public static string OPENAS
        {
            get; set;
        }
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Category
        public ActionResult CategorySetup(string openas)
        {
            TempData["OPENAS"] = ViewBag.OPENAS = openas;
            return View();
        }
        [HttpPost]
        public ActionResult CategorySetup(CategorySetup category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.CATEGORYSETUP.Add(category);
                    if (db.SaveChanges() > 0)
                    {
                        ViewBag.Message = "Saved";
                    }
                    else
                    {
                        ViewBag.Message = "Not Saved";
                    }
                }
                if (TempData["OPENAS"].ToString() != "popup")
                    return RedirectToAction("CategorySetup");
                else
                    return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public ActionResult Brand(string openas)
        {
            ViewBag.OPENAS = openas;
            return View();
        }
        [HttpPost]
        public ActionResult Brand(BrandSetup brandSetup, HttpPostedFileBase fileupload)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (fileupload != null)
                    {
                        brandSetup.BRANDIMAGEURL = "~/images/brand/" + fileupload.FileName;

                        string path = Server.MapPath(brandSetup.BRANDIMAGEURL);
                        if (!Directory.Exists(Server.MapPath("~/images/brand")))
                        {
                            Directory.CreateDirectory(Server.MapPath("~/images/brand"));
                        }
                        fileupload.SaveAs(path);
                        db.BRANDSETUP.Add(brandSetup);
                        if (db.SaveChanges() > 0)
                        {
                            ViewBag.Message = "Saved";
                        }
                        else
                        {
                            ViewBag.Message = "Not Saved";
                        }
                    }

                }
                return RedirectToAction("Brand");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult BrandDetails()
        {
            List<BrandSetup> brand = db.BRANDSETUP.ToList();
            return View(brand);
        }
        public ActionResult Model()
        {
            return View();
        }
    }
}
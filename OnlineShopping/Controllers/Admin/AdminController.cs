using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ECommPract.Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity.Owin;
using PagedList;
namespace ECommPract.Controllers.Admin
{
    [Authorize(Roles = "Admin,Super Admin")]
    public class AdminController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Charts()
        {
            return View();
        }
        public ActionResult ProductAdmin(int? page)
        {
            int pageSize = 9;
            int pageNumber = page ?? 1;
            var model = from d in db.PRODUCTSETUP select d;
            return View(model.OrderBy(x=>x.ProductId).ToPagedList(pageNumber,pageSize));
        }
        public ActionResult RoleIndex()
        {
            return View();
        }
        public ActionResult CreateRole()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult CreateRole(FormCollection role)
        {
            if(ModelState.IsValid)
            {
                
                db.Roles.Add(new IdentityRole() { Name = role["RoleName"] });
                db.SaveChanges();
                ViewBag.Message = "Role Created Successfully";
                return RedirectToAction("CreateRole");
            }
            else
            {
                return View();
            }
        }
        public ActionResult EditRole(string roleID)
        {
            var editrole = db.Roles.FirstOrDefault();
            return View(editrole);
        }
        [HttpPost]
        public ActionResult EditRole(IdentityRole role)
        {
            try
            {
                db.Entry(role).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ListRole");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult ListRole()
        {
            var roles = db.Roles.ToList();
            return View(roles);
        }
        public ActionResult Delete(string roleID)
        {
            var thisRole = db.Roles.Where(x => x.Id == roleID).FirstOrDefault();
            db.Roles.Remove(thisRole);
            db.SaveChanges();
            return RedirectToAction("ListRole");
        }
        public ActionResult ManageRoles()
        {
            ViewBag.listUsers = db.Users.ToList();
            ViewBag.listRole = db.Roles.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult RolesAddToUser(string lstUsers, string lstRoles)
        {
            ApplicationUser user = db.Users.Where(u => u.UserName.Equals(lstUsers, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            UserManager.AddToRole(user.Id, lstRoles);
            return RedirectToAction("ManageRoles");
        }
        public ActionResult GetRoles()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetRoles(string getUserName)
        {
            if(!string.IsNullOrWhiteSpace(getUserName))
            {
                ApplicationUser user = db.Users.Where(u => u.UserName.Equals(getUserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                ViewBag.RolesForThisUser = UserManager.GetRoles(user.Id);
                ViewBag.listRole = db.Roles.ToList();
            }
            return View();
        }
        [HttpPost]
        public ActionResult DeleteRoles(string userName,string roleName)
        {
            ApplicationUser user = db.Users.Where(u => u.UserName.Equals(userName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            var account = new AccountController();
            if(account.UserManager.IsInRole(user.Id,roleName))
            {
                account.UserManager.RemoveFromRole(user.Id, roleName);
                ViewBag.Message = "Role Removed from this user Successfully";
            }
            else
            {
                ViewBag.Message = "This user does not exist in selected Role.";
            }
            return RedirectToAction("ManageRoles");
        }
        
        public JsonResult GetUser()
        {
            var data = db.Users.Select(x=>x.UserName).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}

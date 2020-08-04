using InventorySystem.DAL;
using InventorySystem.Models.AdminModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace InventorySystem.Controllers
{

    [Authorize]
    public class AdminController : Controller
    {
        UserInfoDAL userInfoDAL = new UserInfoDAL();

        public ActionResult _addUnitView()
        {
            return PartialView("_addUnitView");
        }
        [HttpPost]
        public ActionResult ChangeTab(string ViewName, int ViewNo)
        {
            return PartialView(ViewName);
        }
        [HttpPost]
        public ActionResult ChangeMenuView(string ViewName)
        {
            return PartialView(ViewName);
        }
        
        [HttpPost]
        public ActionResult AddNewUser(UserInformation userInformation)
        {
            var identity = (ClaimsIdentity)User.Identity;
            int userId = Convert.ToInt32(identity.Name); 
            return Json(userInfoDAL.AddNewUser(userInformation,userId));
        }

        
    }
}
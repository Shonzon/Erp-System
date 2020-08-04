using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventorySystem.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult ChangeTab(string ViewName, int ViewNo)
        {
            return PartialView(ViewName);
        }
        [Authorize]
        [HttpPost]
        public ActionResult ChangeMenuView(string ViewName)
        {
            return PartialView(ViewName);
        }
    }
}
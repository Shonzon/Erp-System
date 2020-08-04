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
    public class HomeController : Controller
    {
        HomeDAL homeDAL = new HomeDAL();
        CommonDAL commonDAL = new CommonDAL();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        
        public ActionResult Homepage()
        {
             return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult GetInformation()
        {
            return Json("Hello");
        }
        [Authorize]
        [HttpPost]
        public ActionResult ChangeMenuView(string ViewName)
        {
           return PartialView(ViewName);
        }
        
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult GetAllCountry(int CountryId)
        {
            return Json(commonDAL.GetAllCountry(CountryId),JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SaveUserRegistration(UserRegistrationModel userRegistrationModel)
        {
            return Json(homeDAL.UserRegistration(userRegistrationModel));
        }
        [HttpPost]
        public ActionResult CheckUserLogin(string UserEmail, string UserPassword)
        {
            return Json(homeDAL.CheckLoginFrom(UserEmail, UserPassword));
        }
        [HttpPost]
        public ActionResult UploadLogoOrFile()
        {
            FileUploadModel fileUpload = new FileUploadModel();
            if (Request.Files.Count > 0)
            {
                var files = Request.Files;
                int count = 0;
                foreach (string str in files)
                {
                    count++;
                    HttpPostedFileBase file = Request.Files[str] as HttpPostedFileBase;
                    //Checking file is available to save.  
                    if (file != null)
                    {
                        var folderId = Convert.ToInt32(Request.Form["folderNo"]);
                        var folderName = "";
                        switch (folderId) {
                            case 1:
                                folderName = "CompanyLogo";
                                break;
                            case 2:
                                folderName = "ProfilePicture";
                                break;
                            default:
                                break;
                        }
                        
                        Stream strm = file.InputStream;
                        using (var image = System.Drawing.Image.FromStream(strm))
                        {
                            int newWidth = 128; // New Width of Image in Pixel  
                            int newHeight = 128; // New Height of Image in Pixel  
                            var thumbImg = new Bitmap(newWidth, newHeight);
                            var thumbGraph = Graphics.FromImage(thumbImg);
                            thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                            thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                            thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            var imgRectangle = new Rectangle(0, 0, newWidth, newHeight);
                            thumbGraph.DrawImage(image, imgRectangle);
                            var currentmilse = DateTime.Now.Ticks;
                            fileUpload.FileName = Path.GetFileNameWithoutExtension(file.FileName);
                            var InputFileExtention = Path.GetExtension(file.FileName);
                            fileUpload.ServerFileName = fileUpload.FileName + currentmilse + InputFileExtention;
                            fileUpload.FileUploadPath = Path.Combine(Server.MapPath("~/FilesAndImage/"+folderName+"/") + fileUpload.ServerFileName);
                            thumbImg.Save(fileUpload.FileUploadPath, image.RawFormat);
                        }
                    }
                }
            }
            return Json(fileUpload, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        [HttpGet]
        public ActionResult GetResource1()
        {
            var identity = (ClaimsIdentity)User.Identity;
            return Json("Hello: " + identity.Name,JsonRequestBehavior.AllowGet);
        }
    }
}
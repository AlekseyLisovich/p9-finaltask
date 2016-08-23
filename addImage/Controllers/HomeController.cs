using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using addImage.Models;
using System.IO;

namespace addImage.Controllers
{
    public class HomeController : Controller
    {
        PictureContext db = new PictureContext();

        public ActionResult Index()
        {
            return View(db.Pictures);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Picture pic, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid && uploadImage != null)
            {
                byte[] imageData = null;
                // считываем переданный файл в массив байтов
                using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                {
                    imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                }
                // установка массива байтов
                pic.Image = imageData;

                db.Pictures.Add(pic);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(pic);
        }

    }
}
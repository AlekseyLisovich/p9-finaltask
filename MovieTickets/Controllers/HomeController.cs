using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieTickets.Models;
using System.Data.Entity;
using System.IO;

namespace MovieTickets.Controllers
{
    public class HomeController : Controller
    {
        MovieTicketContext db = new MovieTicketContext();
        public ActionResult Index()
        {
            return View(db.Movies);
        }

        public ActionResult Edit(int id = 0)
        {
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        [HttpPost]
        public ActionResult Edit(Movie movie, HttpPostedFileBase uploadImage)
        {
            using (var binaryReader = new BinaryReader(uploadImage.InputStream))
            {
                movie.Image = binaryReader.ReadBytes(uploadImage.ContentLength);
            }

            db.Entry(movie).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Movie movie, HttpPostedFileBase uploadImage)
        {
            using (var binaryReader = new BinaryReader(uploadImage.InputStream))
            {
                movie.Image = binaryReader.ReadBytes(uploadImage.ContentLength);
            }

            db.Movies.Add(movie);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
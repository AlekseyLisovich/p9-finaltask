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
        public ViewResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "Date desc" : "Date";
            var movies = from m in db.Movies
                           select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Name.ToUpper().Contains(searchString.ToUpper())
                                       || s.Name.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "Name desc":
                    movies = movies.OrderByDescending(s => s.Name);
                    break;
                case "Date":
                    movies = movies.OrderBy(s => s.Date);
                    break;
                case "Date desc":
                    movies = movies.OrderByDescending(s => s.Date);
                    break;
                default:
                    movies = movies.OrderBy(s => s.Name);
                    break;
            }

            return View(movies.ToList());
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
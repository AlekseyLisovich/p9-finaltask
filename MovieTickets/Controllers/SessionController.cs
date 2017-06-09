using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MovieTickets.Models;
using MovieTickets.Models.Account;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.IO;

namespace MovieTickets.Controllers
{
    [Authorize(Roles = "admin")]
    public class SessionController : BaseController
    {
        public ActionResult Index()
        {
            return View(db.Cinemas);
        }

        [HttpGet]

        public ActionResult CreateCinema()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCinema(Cinema cinema, HttpPostedFileBase uploadImage)
        {
            if (cinema.Description != null && cinema.Name != null && uploadImage != null)
            {
                using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                {
                    cinema.Image = binaryReader.ReadBytes(uploadImage.ContentLength);
                }

                db.Cinemas.Add(cinema);
                db.SaveChanges();
            }
           
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditCinema(int id = 0)
        {
            Cinema cinema = db.Cinemas.Find(id);
            if (cinema == null)
            {
                return HttpNotFound();
            }
            return View(cinema);
        }

        [HttpPost]
        public ActionResult EditCinema(Cinema cinema)
        {
            db.Entry(cinema).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteCinema(int id)
        {
            Cinema cinema = db.Cinemas.Find(id);
            if (cinema == null)
            {
                return HttpNotFound();
            }
            return View(cinema);
        }
        [HttpPost, ActionName("DeleteCinema")]
        public ActionResult DeleteConfirmed(int id)
        {
            Cinema cinema = db.Cinemas.Find(id);
            if (cinema == null)
            {
                return HttpNotFound();
            }
            db.Cinemas.Remove(cinema);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SelectMovie(int id)
        {
            Cinema cinema = db.Cinemas.Find(id);
            
            MovieCinema model = new MovieCinema();
            model.Cinema = cinema;
            model.Movies = db.Movies;

            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult AddMovie(int cinemaId, int movieId)
        {
            Cinema cinema = db.Cinemas.Find(cinemaId);
            Movie movie = db.Movies.Find(movieId);

            cinema.Movies.Add(movie);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult MovieList(int id)
        {
            Cinema cinema = db.Cinemas.Find(id);

            MovieCinema model = new MovieCinema();
            model.Cinema = cinema;
            model.Movies = cinema.Movies;

            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
    }
}
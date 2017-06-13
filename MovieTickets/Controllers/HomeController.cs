using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieTickets.Models;
using System.Data.Entity;
using System.IO;
using MovieTickets.Models.Account;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MovieTickets.Controllers
{
    
    public class HomeController : BaseController
    {
        static public string[] ticketResult = new string[5];
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

        [Authorize(Roles = "moderator")]
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
            if (movie.Description != null && movie.Name != null && uploadImage != null)
            {
                using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                {
                    movie.Image = binaryReader.ReadBytes(uploadImage.ContentLength);
                }

                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        //[Authorize(Roles = "moderator")]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Movie movie, HttpPostedFileBase uploadImage)
        {
            if (movie.Description != null && movie.Name != null && uploadImage != null)
            {
                using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                {
                    movie.Image = binaryReader.ReadBytes(uploadImage.ContentLength);
                }

                db.Movies.Add(movie);
                db.SaveChanges();     
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "moderator")]
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
            Movie movie = db.Movies.Include(m => m.MovieComments).SingleOrDefault(m => m.ID == id);
            foreach (var cart in movie.MovieComments.ToList())
            {
                db.MovieComments.Remove(cart);
            }
                  
            if (movie == null)
            {
                return HttpNotFound();
            }
            
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            for (int i = 0; i < ticketResult.Length; i++)
            {
                ticketResult[i] = "";
            }
            Movie m = db.Movies.Find(id);
            ticketResult[0] = m.Name;
            ticketResult[1] = Convert.ToString(m.Price);
            ticketResult[2] = m.Date.Day + "/" + m.Date.Month;
            MovieViewModel model = new MovieViewModel();
            model.Movie = new Movie { Name = m.Name, ID = m.ID, Date = m.Date, Description = m.Description, Image = m.Image, MovieComments = m.MovieComments
            , Price = m.Price, Rating = m.Rating };
            model.Comment = m.MovieComments;
            foreach (var cinema in m.Cinemas)
            {
                model.cinema += cinema.Name + " ";
            }
            model.NewComment = new MovieComment();

            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Details(int id, MovieViewModel m)
        {
            User user = UserManager.FindByEmail(User.Identity.Name);
            Movie movie = db.Movies.Find(id);
            m.NewComment.MovieId = movie.ID;
            m.NewComment.PublishDate = DateTime.Now;
            m.NewComment.UserName = user.UserName;
            db.MovieComments.Add(m.NewComment);
            db.SaveChanges();

            return RedirectToAction("Details");
        }
        
        [HttpGet]
        public ActionResult ShowCinemas(string cinema)
        {
            string[] cinemasInfo = cinema.Split(' ');
            var cinemas = db.Cinemas;
            if (cinemas == null)
            {
                return HttpNotFound();
            }
            List<Cinema> c = new List<Cinema>();
            for (int i = 0; i < cinemasInfo.Length; i++)
            {
                foreach (var cinem in cinemas)
                {
                    if (cinem.Name == cinemasInfo[i])
                        c.Add(cinem);

                }
            }
            return View(c);
        }

        [HttpGet]
        public ActionResult ShowCinema(int id)
        {
            Cinema cinema = db.Cinemas.Find(id);
            ticketResult[3] = " " + cinema.Name;
            if (cinema == null)
            {
                return HttpNotFound();
            }
            return View(cinema);
        }

        [HttpGet]
        public ActionResult ShowTicket(int id)
        {
            if (id == 1)
                ticketResult[4] = " " + "12:00";
            else if(id == 2)
                ticketResult[4] = " " + "16:00";
            else if(id == 3)
                ticketResult[4] = " " + "20:00";

            return View(ticketResult);
        }

        [HttpGet]
        public ActionResult FindCinema()
        {
            string cinema = "";
            return View(cinema);
        }

        [HttpPost]
        public ActionResult ShowTicketAuto(string cinema, string date)
        {
            ticketResult[3] = cinema;
            ticketResult[4] = date;
            return View(ticketResult);
        }
    }
}
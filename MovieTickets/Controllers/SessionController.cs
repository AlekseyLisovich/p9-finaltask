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

namespace MovieTickets.Controllers
{
    [Authorize(Roles = "moderator")]
    public class SessionController : Controller
    {
        MovieTicketContext db = new MovieTicketContext();
        public ActionResult Index()
        {
            return View(db.Cinamas);
        }

        [HttpGet]

        public ActionResult CreateCinema()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCinema(Cinema cinema)
        {
            db.Cinamas.Add(cinema);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditCinema(int id = 0)
        {
            Cinema cinema = db.Cinamas.Find(id);
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
            Cinema cinema = db.Cinamas.Find(id);
            if (cinema == null)
            {
                return HttpNotFound();
            }
            return View(cinema);
        }
        [HttpPost, ActionName("DeleteCinema")]
        public ActionResult DeleteConfirmed(int id)
        {
            Cinema cinema = db.Cinamas.Find(id);
            if (cinema == null)
            {
                return HttpNotFound();
            }
            db.Cinamas.Remove(cinema);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
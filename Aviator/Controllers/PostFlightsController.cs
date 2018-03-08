using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Aviator.Models;

namespace Aviator.Controllers
{
    public class PostFlightsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult PostFlight()
        {
            return View();
        }


        // GET: PostFlights
        public ActionResult Index()
        {
            var postFlights = db.PostFlights.Include(p => p.FlightId);
            return View(postFlights.ToList());
        }

        // GET: PostFlights/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostFlight postFlight = db.PostFlights.Find(id);
            if (postFlight == null)
            {
                return HttpNotFound();
            }
            return View(postFlight);
        }

        // GET: PostFlights/Create
        public ActionResult Create()
        {
            ViewBag.Flight = new SelectList(db.Flights, "FlightId", "Destination");
            return View();
        }

        // POST: PostFlights/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostFlightId,Flight,EndingEngineHours,EndingHobbsHours,Squawks,SplitTime")] PostFlight postFlight)
        {
            if (ModelState.IsValid)
            {
                db.PostFlights.Add(postFlight);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Flight = new SelectList(db.Flights, "FlightId", "Destination", postFlight.Flight);
            return View(postFlight);
        }

        // GET: PostFlights/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostFlight postFlight = db.PostFlights.Find(id);
            if (postFlight == null)
            {
                return HttpNotFound();
            }
            ViewBag.Flight = new SelectList(db.Flights, "FlightId", "Destination", postFlight.Flight);
            return View(postFlight);
        }

        // POST: PostFlights/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PostFlightId,Flight,EndingEngineHours,EndingHobbsHours,Squawks,SplitTime")] PostFlight postFlight)
        {
            if (ModelState.IsValid)
            {
                db.Entry(postFlight).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Flight = new SelectList(db.Flights, "FlightId", "Destination", postFlight.Flight);
            return View(postFlight);
        }

        // GET: PostFlights/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostFlight postFlight = db.PostFlights.Find(id);
            if (postFlight == null)
            {
                return HttpNotFound();
            }
            return View(postFlight);
        }

        // POST: PostFlights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PostFlight postFlight = db.PostFlights.Find(id);
            db.PostFlights.Remove(postFlight);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

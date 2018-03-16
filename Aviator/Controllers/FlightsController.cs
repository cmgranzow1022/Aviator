using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Aviator.Models;
using Microsoft.AspNet.Identity;

namespace Aviator.Controllers
{
    public class FlightsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult PreFlight()
        {
            Flight newFlight = new Flight();
            var today = DateTime.Now.ToString();
            newFlight.Date = today;
            return View(newFlight);
        }

        [HttpPost]
        public ActionResult PreFlight([Bind(Include = "FlightId,AircraftNumber,Date,Destination,UserId")] Flight flight )
        {
            var MemberFlying = User.Identity.GetUserId();
            flight.UserId = MemberFlying;
            db.Flights.Add(flight);   
            db.SaveChanges();
            return RedirectToAction("PreFlight", "PreFlights");
        }


        // GET: Flights
        public ActionResult Index()
        {
            var flights = db.Flights.Include(f => f.AircraftNumber);
            return View(flights.ToList());
        }

        // GET: Flights/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = db.Flights.Find(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            return View(flight);
        }

        // GET: Flights/Create
        public ActionResult Create()
        {
            ViewBag.AircraftId = new SelectList(db.Planes, "PlaneId", "TailNumber");
            return View();
        }

        // POST: Flights/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FlightId,AircraftNumber,Destination,Date")] Flight flight)
        {
            if (ModelState.IsValid)
            {
                db.Flights.Add(flight);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AircraftNumber = new SelectList(db.Planes, "PlaneId", "TailNumber", flight.AircraftNumber);
            return View(flight);
        }

        // GET: Flights/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Flight flight = db.Flights.Find(id);
        //    if (flight == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.AircraftId = new SelectList(db.Planes, "PlaneId", "TailNumber", flight.AircraftNumber);
        //    return View(flight);
        //}

        // POST: Flights/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FlightId,AircraftId,Destination,Date")] Flight flight)
        {
            if (ModelState.IsValid)
            {
                db.Entry(flight).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AircraftId = new SelectList(db.Planes, "PlaneId", "TailNumber", flight.AircraftNumber);
            return View(flight);
        }

        // GET: Flights/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = db.Flights.Find(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            return View(flight);
        }

        // POST: Flights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Flight flight = db.Flights.Find(id);
            db.Flights.Remove(flight);
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

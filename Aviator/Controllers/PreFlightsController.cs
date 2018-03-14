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
    public class PreFlightsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult PreFlight()
        {
            
            List<Flight> ListOfFlights = db.Flights.ToList();
            List<PostFlight> LastFlightValues = db.PostFlights.ToList();
    
            PreFlight newFlight = new PreFlight();
            var FlightNumber = ListOfFlights[ListOfFlights.Count - 1].FlightId;
            var LastEntryEngineHours = LastFlightValues[LastFlightValues.Count - 1].EndingEngineHours;
            var LastEntryHobbsHours = LastFlightValues[LastFlightValues.Count - 1].EndingHobbsHours;
            newFlight.FlightIdentification = FlightNumber;
            newFlight.StartingEngineHours = LastEntryEngineHours;
            newFlight.StartingHobbsHours = LastEntryHobbsHours;
            return View(newFlight);
        } 

        [HttpPost]
        public ActionResult PreFlight([Bind(Include = "PreFlightId,FlightIdentification,StartingEngineHours,StartingHobbsHours,StartingOilLevel,AmountOilAdded,MaintenanceFlight")] PreFlight preFlight)
        {
            db.PreFlights.Add(preFlight);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        // GET: PreFlights
        public ActionResult Index()
        {
            var preFlights = db.PreFlights.Include(p => p.FlightIdentification);
            return View(preFlights.ToList());
        }

        // GET: PreFlights/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PreFlight preFlight = db.PreFlights.Find(id);
            if (preFlight == null)
            {
                return HttpNotFound();
            }
            return View(preFlight);
        }

        // GET: PreFlights/Create
        public ActionResult Create()
        {
            ViewBag.Flight = new SelectList(db.Flights, "FlightId", "Destination");
            return View();
        }

        // POST: PreFlights/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PreFlightId,Flight,StartingEngineHours,StartingHobbsHours,StartingOilLevel,AmountOilAdded,MaintenanceFlight")] PreFlight preFlight)
        {
            if (ModelState.IsValid)
            {
                db.PreFlights.Add(preFlight);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Flight = new SelectList(db.Flights, "FlightId", "Destination", preFlight.FlightIdentification);
            return View(preFlight);
        }

        // GET: PreFlights/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PreFlight preFlight = db.PreFlights.Find(id);
            if (preFlight == null)
            {
                return HttpNotFound();
            }
            ViewBag.Flight = new SelectList(db.Flights, "FlightId", "Destination", preFlight.FlightIdentification);
            return View(preFlight);
        }

        // POST: PreFlights/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PreFlightId,Flight,StartingEngineHours,StartingHobbsHours,StartingOilLevel,AmountOilAdded,MaintenanceFlight")] PreFlight preFlight)
        {
            if (ModelState.IsValid)
            {
                db.Entry(preFlight).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Flight = new SelectList(db.Flights, "FlightId", "Destination", preFlight.FlightIdentification);
            return View(preFlight);
        }

        // GET: PreFlights/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PreFlight preFlight = db.PreFlights.Find(id);
            if (preFlight == null)
            {
                return HttpNotFound();
            }
            return View(preFlight);
        }

        // POST: PreFlights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PreFlight preFlight = db.PreFlights.Find(id);
            db.PreFlights.Remove(preFlight);
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

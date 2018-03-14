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
    public class PostFlightsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult PostFlight()
        {
            PostFlightViewModel postViewModel = new PostFlightViewModel();
            Member LoggedInMember;
            List<Member> AllMembers = db.Members.ToList();
            List<Member> ListOfPilots = new List<Member>();
            string currentUserId = User.Identity.GetUserId();
            LoggedInMember = (from x in AllMembers where x.UserId == currentUserId select x).FirstOrDefault();
            AllMembers.Remove(LoggedInMember);

            for (int i = 0; i < AllMembers.Count; i++)
            {
                if (AllMembers[i].MemberRole == "Pilot")
                {
                      ListOfPilots.Add(AllMembers[i]);
                }
            }
            for(int i = 0; i < ListOfPilots.Count; i++)
            {
                if(ListOfPilots[i].MemberId != LoggedInMember.MemberId)
                {
                    SelectListItem item = new SelectListItem
                    {
                        Text = AllMembers[i].FullName,
                        Value = AllMembers[i].MemberId.ToString()
                    };
                    postViewModel.AvailablePilots.Add(item);
               }
            }
        
            return View(postViewModel);
        }

        [HttpPost]
        public ActionResult PostFlight(PostFlightViewModel model)
        {
            PostFlight postFlight = new PostFlight();
            List<Flight> ListOfFlights = db.Flights.ToList();
            var FlightNumber = ListOfFlights[ListOfFlights.Count - 1].FlightId;
            postFlight.FlightIdentification = FlightNumber;
            postFlight.EndingEngineHours = model.postModel.EndingEngineHours;
            postFlight.EndingHobbsHours = model.postModel.EndingHobbsHours;
            postFlight.Squawks = model.postModel.Squawks;
            postFlight.SplitTime = model.postModel.SplitTime;
            postFlight.SplitTimePilotId = model.postModel.SplitTimePilotId;

            db.PostFlights.Add(postFlight);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
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
        public ActionResult Create([Bind(Include = "PostFlightId,FlightIdentification,EndingEngineHours,EndingHobbsHours,Squawks,SplitTime,SplitTimePilotId")] PostFlight postFlight)
        {
            if (ModelState.IsValid)
            {
                db.PostFlights.Add(postFlight);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Flight = new SelectList(db.Flights, "FlightId", "Destination", postFlight.FlightIdentification);
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
            ViewBag.Flight = new SelectList(db.Flights, "FlightId", "Destination", postFlight.FlightIdentification);
            return View(postFlight);
        }

        // POST: PostFlights/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PostFlightId,FlightIdentification,EndingEngineHours,EndingHobbsHours,Squawks,SplitTime,SplitTimePilotId")] PostFlight postFlight)
        {
            if (ModelState.IsValid)
            {
                db.Entry(postFlight).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Flight = new SelectList(db.Flights, "FlightId", "Destination", postFlight.FlightIdentification);
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

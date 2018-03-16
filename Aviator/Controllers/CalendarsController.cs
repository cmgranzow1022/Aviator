using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Aviator.Models;
using DHTMLX.Scheduler;
using Microsoft.AspNet.Identity;

namespace Aviator.Controllers
{
    public class CalendarsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        public JsonResult GetEvents()
        {
             
            var events = db.Calendars.ToList();


            return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult MakeReservation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MakeReservation([Bind(Include = "EventId,Description,StartDate,StartTime,EndDate,EndTime")] Calendar newEvent)
        {
            List<Member> AllMembers = db.Members.ToList();
            string currentUserId = User.Identity.GetUserId();
            int currentMemberId = (from x in AllMembers where x.UserId == currentUserId select x.MemberId).FirstOrDefault();
            newEvent.MemberMakingReservation = currentMemberId;
            db.Calendars.Add(newEvent);
            db.SaveChanges();
            return RedirectToAction("Index", "Calendars");
        }

        // GET: Calendars
        public ActionResult Index()
        {

            //var calendars = db.Calendars.Include(c => c.MemberId);  
            return View();
        }

        // GET: Calendars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calendar calendar = db.Calendars.Find(id);
            if (calendar == null)
            {
                return HttpNotFound();
            }
            return View(calendar);
        }

        // GET: Calendars/Create
        public ActionResult Create()
        {
            ViewBag.MemberMakingReservation = new SelectList(db.Members, "MemberId", "MemberRole");
            return View();
        }

        // POST: Calendars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventId,MemberMakingReservation,EventDescription,Start,End,ThemeColor")] Calendar calendar)
        {
            if (ModelState.IsValid)
            {
                db.Calendars.Add(calendar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MemberMakingReservation = new SelectList(db.Members, "MemberId", "MemberRole", calendar.MemberMakingReservation);
            return View(calendar);
        }

        // GET: Calendars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calendar calendar = db.Calendars.Find(id);
            if (calendar == null)
            {
                return HttpNotFound();
            }
            ViewBag.MemberMakingReservation = new SelectList(db.Members, "MemberId", "MemberRole", calendar.MemberMakingReservation);
            return View(calendar);
        }

        // POST: Calendars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventId,MemberMakingReservation,EventDescription,Start,End,ThemeColor")] Calendar calendar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(calendar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MemberMakingReservation = new SelectList(db.Members, "MemberId", "MemberRole", calendar.MemberMakingReservation);
            return View(calendar);
        }

        // GET: Calendars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calendar calendar = db.Calendars.Find(id);
            if (calendar == null)
            {
                return HttpNotFound();
            }
            return View(calendar);
        }

        // POST: Calendars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Calendar calendar = db.Calendars.Find(id);
            db.Calendars.Remove(calendar);
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

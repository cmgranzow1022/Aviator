using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Aviator.Models;
using Stripe;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using System.Configuration;

namespace Aviator.Controllers
{
    



    public class InvoicesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult SeeInvoice()
        {
            TotalHoursViewModel model = new TotalHoursViewModel();
            Invoice NewInvoice = new Invoice();
            string currentUser = User.Identity.GetUserId();
            List<Flight> FlightList = db.Flights.Where(x => x.UserId == currentUser).ToList();
            PreFlight PreFlights = new PreFlight();
            PostFlight PostFlights = new PostFlight();
            double totalHoursFlown;
            double GrandTotal = 0; 
            for(int i = 0; i < FlightList.Count; i++)
            {
                var flightId = FlightList[i].FlightId;
                var PreF = db.PreFlights.Where(x => (int)x.FlightIdentification == flightId).Select(x => x.StartingHobbsHours).FirstOrDefault();
                var PostF = db.PostFlights.Where(x => (int)x.FlightIdentification == flightId).Select(x => x.EndingHobbsHours).FirstOrDefault();
                totalHoursFlown = PostF - PreF;
                GrandTotal += totalHoursFlown;
            }

            NewInvoice.HoursFlown = GrandTotal;
            NewInvoice.HourlyFlightRate = 75.00;
            NewInvoice.HoursBilled = GrandTotal * NewInvoice.HourlyFlightRate;
            NewInvoice.MonthlyDues = 130.00;
            NewInvoice.TotalAmountOwed = NewInvoice.MonthlyDues + NewInvoice.HoursBilled;
            var stripePublishKey = "PUBLICKEYHERE";

            ViewBag.StripePublishKey = stripePublishKey;
            return View(NewInvoice);
        }


        [HttpPost]
        public ActionResult SeeInvoice(Invoice invoice)
        {
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Charge(string stripeEmail, string stripeToken)
        {
            var customers = new StripeCustomerService();
            var charges = new StripeChargeService();

            var customer = customers.Create(new StripeCustomerCreateOptions
            {
                Email = stripeEmail,
                SourceToken = stripeToken
            });

            var charge = charges.Create(new StripeChargeCreateOptions
            {
                Amount = 500,//charge in cents
                Description = "Sample Charge",
                Currency = "usd",
                CustomerId = customer.Id
            });

            return RedirectToAction("Index", "Home");
        }

       


        // GET: Invoices
        public ActionResult Index()
        { 
            var invoices = db.Invoices.Include(i => i.MemberId);
            return View(invoices.ToList());
        }

        // GET: Invoices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // GET: Invoices/Create
        public ActionResult Create()
        {
            ViewBag.MemberBilledId = new SelectList(db.Members, "MemberId", "MemberRole");
            return View();
        }

        // POST: Invoices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InvoiceKey,MemberBilledId,HoursBilled,MonthlyDues")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                db.Invoices.Add(invoice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MemberBilledId = new SelectList(db.Members, "MemberId", "MemberRole", invoice.MemberBilledId);
            return View(invoice);
        }

        // GET: Invoices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            ViewBag.MemberBilledId = new SelectList(db.Members, "MemberId", "MemberRole", invoice.MemberBilledId);
            return View(invoice);
        }

        // POST: Invoices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InvoiceKey,MemberBilledId,HoursBilled,MonthlyDues")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invoice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MemberBilledId = new SelectList(db.Members, "MemberId", "MemberRole", invoice.MemberBilledId);
            return View(invoice);
        }

        // GET: Invoices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // POST: Invoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Invoice invoice = db.Invoices.Find(id);
            db.Invoices.Remove(invoice);
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

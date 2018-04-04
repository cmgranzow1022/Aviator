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
using System.Data.SqlClient;
using System.Configuration;
using DHTMLX.Common;
using DHTMLX.Scheduler.Data;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Twilio.TwiML;
using Twilio.AspNet.Mvc;

namespace Aviator.Controllers
{
    public class CalendarsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Calendars
        public ActionResult ViewIndex()
        {
            var scheduler = new DHXScheduler(this);
            scheduler.Skin = DHXScheduler.Skins.Flat;
            scheduler.Config.first_hour = 6;
            scheduler.Config.last_hour = 20;
            scheduler.LoadData = true;
            scheduler.EnableDataprocessor = true;
            return View(scheduler);
        }
        
        public ContentResult Data()
        {
            var apps = db.Calendars.ToList();
            return new SchedulerAjaxData(apps);
        }

        public ActionResult Save(int? id, FormCollection actionValues)
        {
            var action = new DataAction(actionValues);

            try
            {
                var changedEvent = DHXEventsHelper.Bind<Calendar>(actionValues);
                switch (action.Type)
                {
                    case DataActionTypes.Insert:
                        db.Calendars.Add(changedEvent);
                        break;
                    case DataActionTypes.Delete:
                        db.Entry(changedEvent).State = EntityState.Deleted;
                        SendSms();
                        break;
                    default:// "update"  
                        db.Entry(changedEvent).State = EntityState.Modified;
                        break;
                }
                db.SaveChanges();
                action.TargetId = changedEvent.Id;
            }
            catch (Exception a)
            {
                action.Type = DataActionTypes.Error;
            }

            return (new AjaxSaveResponse(action));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult SendSms()
        {
            var accountSid = "AC631bcc879b48b81a1c670651e094a778";
            var authToken = "563a341fb714e36dbc5c74cba6beb8c9";
            TwilioClient.Init(accountSid, authToken);

            var to = new PhoneNumber("+14144917218");
            var from = new PhoneNumber("+14142400281");

            var message = MessageResource.Create(
                to: to,
                from: from,
                body: "An reservation slot has become available for N926G. Please login to Aviator to view calendar.");


            return Content(message.Sid);
        }
    }
}

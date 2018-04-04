using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Twilio.TwiML;
using Twilio.AspNet.Mvc;
namespace Aviator.Controllers
{
    public class SmsController : Controller
    {
        // GET: Sms
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
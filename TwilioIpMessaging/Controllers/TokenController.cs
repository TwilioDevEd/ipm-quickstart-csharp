using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio;
using Twilio.Auth;
using JWT;
using Faker;

namespace TwilioIpMessaging.Controllers
{
    public class TokenController : Controller
    {
        // GET: /token
        public ActionResult Index(string Device)
        {
            // Load Twilio configuration from Web.config
            var AccountSid = ConfigurationManager.AppSettings["TwilioAccountSid"];
            var ApiKey = ConfigurationManager.AppSettings["TwilioApiKey"];
            var ApiSecret = ConfigurationManager.AppSettings["TwilioApiSecret"];
            var IpmServiceSid = ConfigurationManager.AppSettings["TwilioIpmServiceSid"];

            // Create a random identity for the client
            var Identity = Internet.UserName();

            // Create an Access Token generator
            var Token = new AccessToken(AccountSid, ApiKey, ApiSecret);
            Token.Identity = Identity;

            // Create an IP messaging grant for this token
            var grant = new IpMessagingGrant();
            grant.EndpointId = $"TwilioChatDemo:{Identity}:{Device}";
            grant.ServiceSid = IpmServiceSid;
            Token.AddGrant(grant);

            return Json(new {
                identity = Identity,
                token = Token.ToJWT()
            }, JsonRequestBehavior.AllowGet);
        }
    }
}
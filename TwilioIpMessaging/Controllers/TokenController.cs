using System.Configuration;
using System.Web.Mvc;
using Faker;
using Twilio.Jwt.AccessToken;
using System.Collections.Generic;

namespace TwilioIpMessaging.Controllers
{
    public class TokenController : Controller
    {
        // GET: /token
        public ActionResult Index(string Device)
        {
            // Load Twilio configuration from Web.config
            var accountSid = ConfigurationManager.AppSettings["TwilioAccountSid"];
            var apiKey = ConfigurationManager.AppSettings["TwilioApiKey"];
            var apiSecret = ConfigurationManager.AppSettings["TwilioApiSecret"];
            var ipmServiceSid = ConfigurationManager.AppSettings["TwilioIpmServiceSid"];

            // Create a random identity for the client
            var identity = Internet.UserName();

            // Create an IP messaging grant for this token
            var grant = new IpMessagingGrant();
            grant.EndpointId = $"TwilioChatDemo:{identity}:{Device}";
            grant.ServiceSid = ipmServiceSid;
            var grants = new HashSet<IGrant>
            {
                { grant }
            };

            // Create an Access Token generator
            var Token = new Token(accountSid, apiKey, apiSecret, identity: identity, grants: grants);

            return Json(new {
                identity = identity,
                token = Token.ToJwt()
            }, JsonRequestBehavior.AllowGet);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Twilio;
using Twilio.AspNet.Core;
using Twilio.AspNet.Common;
using Twilio.Rest.Api.V2010.Account;
using Twilio.TwiML;
using Twilio.Types;

namespace TextToEmail.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class TextController : TwilioController
   {
       [HttpPost]
       public async Task<IActionResult> Post()
       {
           var from = Request.Form["From"];
           var body = Request.Form["Body"];
           var testContent = $@"<Response><Message>your number:{from} and your message: '{body}'</Message></Response>";
           return Content(testContent, "text/xml");
       }

   }
}
using System;
using System.Net;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace TextToEmail
{
   public class Emailer
   {
       private readonly string _sendGridApiKey;
       public Emailer()
       {
           _sendGridApiKey = Environment.GetEnvironmentVariable("SENDGRID_KEY");
       }
   }
}
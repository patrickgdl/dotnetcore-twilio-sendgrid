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
            _sendGridApiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
        }

        public async Task<string> Send(string from, string body)
        {
            var email = new Email(from, body);

            var response = await SendEmail(email);

            var message = "Your message could not be processed at this time. Please try again later.";

            if (response.StatusCode == HttpStatusCode.Accepted)
            {
                message = "Thank you for your message, someone will be in touch soon!";
            }
            return message;
        }

        private async Task<Response> SendEmail(Email email)
        {
            var client = new SendGridClient(_sendGridApiKey);
            var msg = MailHelper.CreateSingleEmail(
                email.From, email.To, email.Subject, email.PlainTextContent, email.HtmlContent);
            var response = await client.SendEmailAsync(msg);
            return response;
        }
    }

    public class Email
    {
        public Email(string from, string body)
        {
            {
                To = new EmailAddress("patrickgoncalveslima@gmail.com", "Sender");
                From = new EmailAddress("patrickgoncalveslima@gmail.com", "Text to Email App");
                Subject = $"A new text message has been sent from {from}";
                HtmlContent = $"<strong>{body}<strong>";
                PlainTextContent = body;
            };
        }
        public EmailAddress From { get; set; }
        public EmailAddress To { get; set; }
        public string Subject { get; set; }
        public string PlainTextContent { get; set; }
        public string HtmlContent { get; set; }
    }
}
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MYCMS.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        public async Task Send(string to, string subject, string body)
        {
            // create message
            var message = new MailMessage();

            message.From = new MailAddress("cms2024.no.reply@gmail.com", "CMS App");
            message.Subject = subject;
            message.Body = body;
            message.To.Add(new MailAddress(to)); 
            message.IsBodyHtml = false;


            try
            {
                var emailClient = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("cms2024.no.reply@gmail.com", "CMS2024$$")
                };


                await emailClient.SendMailAsync(message);
            }catch(Exception e)
            {

            }
            // send email
         
        }
    }
}

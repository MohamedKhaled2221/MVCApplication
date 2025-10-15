using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Route.MVCAPP.DAL.Models.identity;

namespace Route.MVCAPP.BLL.Common.Service.EmailSettings
{
    public class EmailSettings : IEmailSettings
    {
        public void SendEmail(Email email)
        {
            // Mail Server : [ Gmail , Yahoo , Outlook, icloud,... ]
            //SMTP : Simple Mail Transfer Protocol
            var Client = new SmtpClient("smtp.gmail.com", 587); // Enable SMTP (Host , Port)
            Client.EnableSsl = true; // Secure Connection


            // Sender & Receiver
            Client.Credentials = new NetworkCredential("amer31824@gmail.com", "rmdbzmdkryfgmlpx");
            Client.Send("amer31824@gmail.com", email.To, email.Subject, email.Body);
        }
    }
}

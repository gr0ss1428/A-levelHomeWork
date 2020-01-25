using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace BlogMvc.Service
{
    public class EmailService:IEmailService
    {
        public SmtpClient smtpClient;

        public EmailService()
        {
            smtpClient = new SmtpClient();
        }

        public void SendSmpt(string subject,string body,string from,string to)
        {
            smtpClient.Send(from, to, subject, body);
        }
    }

    public interface IEmailService
    {
        void SendSmpt(string subject, string body, string from, string to);
    }
}
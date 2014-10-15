using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace Emails
{
    public static class Email
    {
        public static bool sendMail(string email,string subject,string message)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtpout.secureserver.net");

                mail.From = new MailAddress("noreply@thronewars.ca");
                mail.To.Add(email);
                mail.Subject = subject;
                mail.Body = message;

                SmtpServer.Port = 25;
                SmtpServer.Credentials = new System.Net.NetworkCredential("noreply@thronewars.ca", "ProjetDEC");
                SmtpServer.EnableSsl = false;

                SmtpServer.Send(mail);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}

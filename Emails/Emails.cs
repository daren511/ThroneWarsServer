﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace Emails
{
    public static class Email
    {
        public static string SujetInscription = "Confirmation compte Throne Wars";
        public static string bodyConfirmation = "Veuillez confirmer votre account lier à ce courriel." +
            "Voici votre lien pour confirmer : www.thronewars.ca/confirmaccount";
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

                SmtpServer.Port = 80;
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

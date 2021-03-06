﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;

namespace Emails
{
    public static class Email
    {
        // Variable en string pour différent message dans l'utilisation de la DLL
        public static string SujetInscription = "Confirmation compte - Throne Wars"; 
        public static string BodyConfirmation = "Veuillez confirmer votre compte lier à ce courriel." +
            "Voici votre lien pour confirmer : " ; 
        public static string SujetForgetUser = "Récupération de nom d'utilisateur - Throne Wars";
        public static string BodyForgetUser = "Voici votre nom d'utilisateur : ";
        public static string SubjectResetPass = "Changement de mot de passe - Throne Wars";
        public static string BodyResetPass = "Pour changer votre mot de passe, veuillez visiter" +
                                " ce lien et suivre les indications : ";

        public static bool sendMail(string email,string subject,string message)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtpout.secureserver.net");

                // À Qui , le sujet et le body du Email
                mail.From = new MailAddress("noreply@thronewars.ca");
                mail.To.Add(email);
                mail.Subject = subject;
                mail.Body = message;
                // Le body est en HTML ( pour les lien en a href
                mail.IsBodyHtml = true;

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

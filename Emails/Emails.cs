﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;

namespace Emails
{
    public static class Email
    {
        public static string SujetInscription = "Confirmation compte Throne Wars";
        public static string BodyConfirmation = "Veuillez confirmer votre account lier à ce courriel." +
            "Voici votre lien pour confirmer : www.thronewars.ca:8080/ConfirmAccount.aspx?User=";
        public static string SujetForgetPass = "Récupération de mot de passe - Throne Wars";
        public static string BodyForgetPass = "Veuillez réinitialiser votre mot de passe à partir de cette page" +
                                        "www.thronewars.ca:8080/ResetPassword.aspx?User=";
        public static string SujetForgetUser = "Répupération de nom d'utilisateur -Throne Wars";
        public static string BodyForgetUser = "Voici votre nom d'utilisateur :";
        public static string SubjectResetPass = "Changement de mot de passe -Throne Wars";
        public static string BodyResetPass = "Pour changer votre mot de passe, veuillez visiter" +
                                " ce lien et suivre les indications www.thronewars.com/ResetPassword.aspx?User=";

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

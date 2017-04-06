﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
/// <summary>
/// Summary description for Mail
/// </summary>
public class Mail
{

    public static void Send_Mail(string Email, string Body, string Subject)
    {
        using (MailMessage mm = new MailMessage("anchal.chaudhary329@gmail.com", Email))
        {
            mm.Subject = Subject;
            mm.Body = Body;
            mm.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            NetworkCredential NetworkCred = new NetworkCredential("anchal.chaudhary329@gmail.com", "Google.Anchal");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;
            smtp.Send(mm);
        }

    }
}
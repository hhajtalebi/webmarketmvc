using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace WebMarket.Utility
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtpServer = new SmtpClient("smtp.office365.com");
            mail.From = new MailAddress("hhajtalby@outlook.com");
            mail.To.Add(email);
            mail.Subject = subject;
            mail.Body = htmlMessage;

            mail.IsBodyHtml = true;

            //System.Net.Mail.Attachment attachment;
            // attachment = new System.Net.Mail.Attachment("c:/textfile.txt");
            // mail.Attachments.Add(attachment);

            smtpServer.Port = 587;
            smtpServer.Credentials = new System.Net.NetworkCredential("hhajtalby@outlook.com", "Aa750057351");
            smtpServer.EnableSsl = true;
            
            smtpServer.UseDefaultCredentials = false;
            smtpServer.Send(mail);

            return Task.CompletedTask;
        }
    }
}
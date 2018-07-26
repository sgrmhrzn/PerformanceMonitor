using System;
using System.IO;
using System.Net.Mail;
using System.Net.Mime;

namespace RealTimeSuite.Helper
{
    public class Mail
    {
        public void SendMail(string base64, string subject, string body)
        {
            string base64String = base64.Replace("data:image/png;base64,", "");
            string converted = base64String.Replace('-', '+');
            converted = converted.Replace('_', '/');
            byte[] bytes = Convert.FromBase64String(converted);

            Attachment att = new Attachment(new MemoryStream(bytes), "Telemetry");
            //add sender and receivers email here
            MailMessage mail = new MailMessage("", "");
            SmtpClient client = new SmtpClient();
            //add email credentials here
            client.Credentials = new System.Net.NetworkCredential("", "");
            client.Port = 25;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "smtp.gmail.com";
            mail.Subject = subject;
            mail.Body = body;
            mail.Attachments.Add(att);
            client.Send(mail);
        }
    }
}
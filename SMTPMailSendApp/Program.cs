using System;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Threading.Tasks;

namespace SmtpMailConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string fromMail = "testsmtpconsoleapp@gmail.com";
            string fromPassword = "birvxpevdwpevksl";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            Console.Write("Subject daxil et: ");
            string subject = Console.ReadLine();
            message.Subject= subject;
            message.To.Add(new MailAddress("testsmtpconsoleapp@gmail.com"));
            Console.Write("Mesajini yaz: ");
            string body = Console.ReadLine();
            message.Body = $"<html><body>{body}</body></html>";
            message.IsBodyHtml= true;

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = true
            };

            smtpClient.Send(message);
            Console.WriteLine("\nMail gönderildi.");
        }
    }
}

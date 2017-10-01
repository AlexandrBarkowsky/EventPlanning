using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using System.Net.Mail;
using System.Net;
using System.Web.Configuration;

namespace Domain.Concrete
{
    public class EmailProcessor : ISendEmail
    {
        public void SendMail(string email, string subject, string body)
        {
            //тут реализовать отправку сообщения email - кому, субъет - тема, боди - тело сообщения
            // отправитель - устанавливаем адрес и отображаемое в письме имя
            MailAddress from = new MailAddress(WebConfigurationManager.AppSettings["MailFromAddress"], "Alexandr");
            // кому отправляем
            MailAddress to = new MailAddress(email);
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            m.Subject = subject;
            // текст письма
            m.Body = body;
            // письмо представляет код html
            m.IsBodyHtml = true;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient(WebConfigurationManager.AppSettings["ServerName"], Int32.Parse(WebConfigurationManager.AppSettings["ServerPort"]));
            // логин и пароль
            smtp.Credentials = new NetworkCredential(WebConfigurationManager.AppSettings["Username"], WebConfigurationManager.AppSettings["Password"]);
            smtp.EnableSsl = true;
            smtp.Send(m);
        }
    }
}

using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using System.Net.Mail;
using System.Net;

namespace Domain.Concrete
{
    public class EmailSettings
    {
        public string MailFromAddress = "sdasdas12321@gmail.com";
        public string Username = "sdasdas12321@gmail.com";
        public string Password = "123aallalala";
        public string ServerName = "smtp.gmail.com";
        public int ServerPort = 587;
    }
    public class EmailProcessor : ISendEmail
    {
        private EmailSettings emailSettings = new EmailSettings();
        public void SendMail(string email, string subject, string body)
        {
            //тут реализовать отправку сообщения email - кому, субъет - тема, боди - тело сообщения
            // отправитель - устанавливаем адрес и отображаемое в письме имя
            MailAddress from = new MailAddress(emailSettings.MailFromAddress, "Alexandr");
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
            SmtpClient smtp = new SmtpClient(emailSettings.ServerName, emailSettings.ServerPort);
            // логин и пароль
            smtp.Credentials = new NetworkCredential(emailSettings.Username, emailSettings.Password);
            smtp.EnableSsl = true;
            smtp.Send(m);
        }
    }
}

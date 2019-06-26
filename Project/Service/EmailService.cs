using System.Net;

using System.Configuration;

using System.Diagnostics;

using SendGrid.Helpers.Mail;

using SendGrid;

using System.Net.Mail;

using System.Threading.Tasks;

using Microsoft.AspNet.Identity;
using System;

namespace Project.Service
{
    public class EmailService
    {
        public static void SendMail(string mailAdress, string id)
        {
            // отправитель - устанавливаем адрес и отображаемое в письме имя
            MailAddress from = new MailAddress("testproj231@gmail.com", "TestProject");
            // кому отправляем
            MailAddress to = new MailAddress(mailAdress);
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            m.Subject = "Email confirmation" ;
            // текст письма
            m.Body = "<a> Please confirm your account by clicking by following:</a> <a href=\"http://localhost:50897/Register/ConfirmEmail/"+id+"\">here</a>";
            // письмо представляет код html
            m.IsBodyHtml = true;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            // логин и пароль
            smtp.Credentials = new NetworkCredential("testproj231@gmail.com", "Dd2004995522");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }



}
}
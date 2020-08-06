using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using ProcessusFormation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProcessusFormation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        [HttpPost]
        [Route("SendEmail")]
        public object Sendmail(EmailClass em)
        {
            string Subject = em.Subject;
            string To = em.To;
            string Body = em.Body;
            MailMessage mm = new MailMessage();
            mm.From = new MailAddress("rim.benabdesslem@ensi-uma.tn");
            mm.To.Add(new MailAddress(To));
            mm.Subject = Subject;
            mm.Body = Body;
            mm.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.UseDefaultCredentials = true;
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("rim.benabdesslem@ensi-uma.tn", "rimfaten1996"); // Enter seders User name and password   
            smtp.EnableSsl = true;
            smtp.Send(mm);
            return Ok();


        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using ProcessusFormation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace ProcessusFormation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {

        private UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public EmailController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
           
            _roleManager = roleManager;
        }
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

        [HttpPost]
        [Route("SendEmailTous")]
        public async Task<object> SendmailTous(EmailClass em)
        {
            var query = _userManager.Users;
           
            foreach (var user in query)
            {

                var userRoles = await _userManager.GetRolesAsync(user);
                for (var i = 0; i < userRoles.Count; i++) {
                    if (userRoles[i] == "Directeur activité") //&& element.LabelId == model.LabelId
                    {
                        em.To = user.Email;
                        em.Subject = "Resencement des besoins en formation";
                        em.Body = "Bonjour, afin de participer activement dans la resencement " +
                        "de besoin en formation à Telnet, nous vous invitons à remplir le formulaire anonyme suivant :http://localhost:4200/elements/need-training";
                        Sendmail(em);

                    } }
            }

            return Ok(new { });

        }
    }
}
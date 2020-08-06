using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProcessusFormation.Data;
using ProcessusFormation.Models;
using ProcessusFormation.Models.Evaluation;
using System.Net.Mail;
namespace ProcessusFormation.Controllers.Evaluation
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvaluationFroidParticipantController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        /// private Database Database { get; set; }
        public static class MyGlobal
        {
            public static int key=0;
            public static int c = 0;
        }
        public static class Conteur
        {
           
            public static int c =0;
           public static List<int> ListId = new List<int>();
        }

        public EvaluationFroidParticipantController(UserManager<ApplicationUser> userManager,ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;

        }

       
        [HttpPost]
        [Route("RegisterEvaluationFroidParticipant/{id}")]
        public async Task<IActionResult> Evaluation(string id, EvaluationFroidParticipant model)

        {  //id : c'est l'id de directeur activité
            //lazem nrecuperi aussi id participant et id de cette formation aprés register 
            //id de participant njibha m3a model mel front w ba3ed nlawej aleha f back w nest8al id pour enregistre f tab jdid
            ApplicationUser participant = await _userManager.FindByIdAsync(model.Nom_Participant);
            ApplicationUser directeur= await _userManager.FindByIdAsync(id);
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

          

            var evalauation = new EvaluationFroidParticipant()
            {
                Theme = model.Theme,
                Lieu = model.Lieu,
                Organisme = model.Organisme,
                Formateur = directeur.UserName + directeur.FullName,
                Date_Evaluation_Froid = model.Date_Evaluation_Froid,
                Date_Debut = model.Date_Debut,
                Date_Fin = model.Date_Fin,
                Nom_Participant = participant.UserName,
                Prenom_Participant = participant.FullName,
                Matricule = model.Matricule,
                Fonction = model.Fonction,
                Direction = model.Direction,
                question_A = model.question_A,
                Lesquelles = model.Lesquelles,
                PourquoiA = model.PourquoiA,
                PourquoiB = model.PourquoiB,
                Autres1 = model.Autres1, 
                question_C = model.question_C,
                question_B = model.question_B,
                Comment = model.Comment,
                Commentaire1 = model.Commentaire1,
            };
            await _context.EvaluationFroidParticipants.AddAsync(evalauation);
             _context.SaveChanges();
          
            var res =  _context.EvaluationFroidParticipants.FindAsync(evalauation.Id);
            var intermidiare = new Intermidiaire()
            {
                ParticipantId = model.Nom_Participant,
                DirectActivId=id,
                EvaluatFroidId= evalauation.Id

            };
            await _context.Intermidiaires.AddAsync(intermidiare);
           _context.SaveChanges();

            MyGlobal.key = evalauation.Id;

            _context.SaveChanges();
           // ApplicationUser user = await _userManager.FindByIdAsync(id);
            var mail = directeur.Email;
            Sendmail(mail);
            return Ok(new { MyGlobal.key });


        }

        public object Sendmail(string mail)
        {
            string Subject = "notification mail";
            string To = mail;
            string Body = "(formulaire à rempli)";
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




        //get evaluation participant detail a partitir de Key
        [HttpGet]
        [Route("GetEvaluationFroidParticipant")]
        public async Task<object> GetUser()
        {

            var applicationUser = await _context.EvaluationFroidParticipants.FindAsync(MyGlobal.key);
            if (applicationUser == null)
            {
                return NotFound();
            }

            return (applicationUser);
        }

      

        //get user detail a partir de l'id de directeur conneté
        [HttpGet]
        [Route("GetEvaluationParticipant/{id}")]
        public async Task<object> GetEvaluationPartFroid([FromRoute] string id)
        {
             List<int> ListId = new List<int>();
            List<EvaluationFroidParticipant> List = new List<EvaluationFroidParticipant>();
            //   string Dire =id ;
            // je recupere les intermidaire qui coorespond au evaluat dont son direct est d'id = id
            var applicationUser = await _context.EvaluationFroidParticipants.FindAsync(MyGlobal.key);
            var evaluation = _context.EvaluationFroidParticipants;
            var intermediaires =  _context.Intermidiaires;
            Int32[] array = new int[2] ;
        //    for (int j = 0; j < 1; j++)
            
                foreach (var element in intermediaires)
                {
                Console.WriteLine(id);
                    if (element.DirectActivId == id)
                    { ListId.Add(element.EvaluatFroidId); }
                }
            for (int j = 0; j < ListId.Count; j++)
            {
                foreach (var eval in evaluation)
                {
                    if (ListId[j] == eval.Id)
                    {
                        List.Add(eval);
                      //  return eval;
                    }

                }
            }

         //   for (int k = 0; k < List.Count; k++)
          //  {  
                return List;
        //    }
               
        }
    }
}
// foreach (var element in intermediaires)
           //     {
            //        if (element.DirectActivId ==id)
             //       { ListId.Add(element.EvaluatFroidId); }
             //   }
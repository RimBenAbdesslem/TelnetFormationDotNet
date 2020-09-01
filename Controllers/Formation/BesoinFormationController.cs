using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProcessusFormation.Data;
using ProcessusFormation.Models.Formation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using Microsoft.EntityFrameworkCore;

namespace ProcessusFormation.Controllers.Formation

{[Route("api/[controller]")]
    [ApiController]
    public class BesoinFormationController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
       
        public static class MyGlobals
        {
            public static string key;

        }
        public BesoinFormationController(ApplicationDbContext context)
        {
          
            _context = context;

        }

        //ajouter un nouveau formation
        [HttpPost]
        [Route("RegisterFormation")]
        public async Task<IActionResult> PostBesoinFormation(BesoinFormationModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            var BesoinFormation = new BesoinFormationModel()
            {
                Activite = model.Activite,
                Intitule_Formation = model.Intitule_Formation,
                Priorite = model.Priorite,
                Justification_du_besoin = model.Justification_du_besoin,
                Nombre_de_participants = model.Nombre_de_participants,
                FormationType = "BesoinFormation"
        };
            //icij'ajoute une nouvelle formation et au meme temps je paaser l'id de cette formation comme un parametre ala fonction GetBesoinFormation()
            await _context.BesoinFormationModels.AddAsync(BesoinFormation);
            _context.SaveChanges();
             var application = await _context.BesoinFormationModels.FindAsync(BesoinFormation.BesoinFormationId);
            //Console.WriteLine(application.Id);
           // await GetBesoinFormation(application.Id);
          // MyGlobals.key = BesoinFormation.Id;

            //return Ok(new { MyGlobals.key });
            return Ok(BesoinFormation.BesoinFormationId);

        }

        // [HttpGet("{id}")] ;   public async Task<object> GetBesoinFormation([FromRoute] string id)

        [HttpGet] 
        [Route("GetOnBesoin")]
        public async Task<object> GetBesoinFormation()
        {
          
            Console.WriteLine(MyGlobals.key);
            if (MyGlobals.key is null)
            {
                return Ok(new { });
            }
            var BesoinFormation = await _context.BesoinFormationModels.FindAsync(MyGlobals.key);
            if (BesoinFormation == null)
            {
                return NotFound();
            }

            return (BesoinFormation);
        }


        [HttpGet]
        [Route("GetAllBesoin")]
        public IEnumerable<Object> GetAllBesoins()
        {

            var BesoinFormation = _context.BesoinFormationModels;
            if (BesoinFormation == null)
            {
                return (null);
            }

            return (BesoinFormation);
        }

        public static class obj
        {
            public static string IdFormation = "";
            public static Double NbParticipant = 0;
            public static Double NbEvaluation = 0;
            public static int Anne = 0;
            public static Double Taux = 0;
            //  public static string UserName = "";
        };
        public static class Evalobj
        {
            public static string IdFormation = "";
            public static int NbParticipant = 0;
           
            //  public static string UserName = "";
        };
        //top 5 formateurs 
        [HttpGet]
        [Route("getCountBesoinFormations")]
        public IActionResult getCountBesoinFormations()
        {
            DateTime thisDay = DateTime.Today;
            var réaliser  = _context.BesoinFormationModels.ToList().Where(x => x.FormationType == "BesoinCollecte" && x.Date_Fin< thisDay && x.Date_Fin.Year == thisDay.Year).Count();//BesoinFormation
         var planifier = _context.BesoinFormationModels.ToList().Where(x => x.FormationType == "BesoinCollecte" && x.Date_Fin > thisDay && x.Date_Fin.Year == thisDay.Year).Count();//BesoinCollecte
        return Ok(new { Formations_réalisées = réaliser, Formations_planifiées = planifier });
        }
        [HttpGet]
        [Route("TauxDeParticipation")]
        public IEnumerable<Object> getTauxParticipation()
        {
            DateTime thisDay = DateTime.Today;
            List<Object> List = new List<Object>();
            List<Object> ListEval = new List<Object>();
            var FormationRéaliser = _context.BesoinFormationModels.Where(x => x.FormationType == "BesoinCollecte" && x.Date_Fin < thisDay);//BesoinFormation
            var EvalautionFormation = _context.EvaluationFroidParticipants;
            foreach (var element in FormationRéaliser)
            {
             
                obj.IdFormation = element.BesoinFormationId;
                    obj.NbParticipant = int.Parse(element.Nombre_de_participants);
                    obj.NbEvaluation = _context.EvaluationFroidParticipants.Where(x => x.Lieu == element.BesoinFormationId).Count();
                obj.Taux = (obj.NbEvaluation / obj.NbParticipant)*100;
                 obj.Anne = element.Date_Fin.Year;
                //   obj.UserName = user.UserName + user.FullName;
                List.Add(new { obj.IdFormation, obj.NbParticipant, obj.NbEvaluation, obj.Anne, obj.Taux });
              //  return List;

            };

            foreach (var element in EvalautionFormation)
            {

                Evalobj.IdFormation = element.Lieu;
                Evalobj.NbParticipant = _context.EvaluationFroidParticipants.ToList().Where(x=>x.Lieu==element.Lieu).Count();

                //   obj.UserName = user.UserName + user.FullName;
                ListEval.Add(new { obj.IdFormation, obj.NbParticipant });
                //  return List;

            };
            //  return List;



           return List;
        }
    }
}
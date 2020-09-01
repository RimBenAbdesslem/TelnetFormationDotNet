using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProcessusFormation.Data;
using ProcessusFormation.Models.Compétence;
using ProcessusFormation.Models.Evaluation;

namespace ProcessusFormation.Controllers.Evaluation
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvaluationFroidController : ControllerBase
    {



        private readonly ApplicationDbContext _context;
        /// private Database Database { get; set; }
        public static class MyGlobals
        {
            public static int key;

        }
        public EvaluationFroidController(ApplicationDbContext context)
        {

            _context = context;

        }


        [HttpPost]
        [Route("RegisterEvaluationFroid")]
        public async Task<IActionResult> PostFroidEvaluation(EvaluationFroid model)

        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }
          
            var evalauation = new EvaluationFroid()
            {
                Theme = model.Theme,
                Lieu = model.Lieu,
                Organisme = model.Organisme,
                Formateur = model.Formateur,
                Date_Evaluation_Froid = model.Date_Evaluation_Froid,
                Date_Debut = model.Date_Debut,
                Date_Fin = model.Date_Fin,
                Nom_Participant = model.Nom_Participant,
                Prenom_Participant = model.Prenom_Participant,
                Matricule = model.Matricule,
                Fonction = model.Fonction,
                Direction = model.Direction,
                question_A = model.question_A,
                Lesquelles = model.Lesquelles,
                PourquoiA = model.PourquoiA,
                PourquoiB = model.PourquoiB,
                Autres1 = model.Autres1,
                Autres2 = model.Autres2,
                question_C = model.question_C,
                question_B = model.question_B,
                Comment = model.Comment,
                Critere1 = model.Critere1,
                Critere3 = model.Critere3,
                Critere2 = model.Critere2,
                Critere4 = model.Critere4,
                Critere5 = model.Critere5,
                Critere6 = model.Critere6,
                Critere7 = model.Critere7,
                Critere8 = model.Critere8,
                Critere9 = model.Critere9,
                Commentaire1 = model.Commentaire1,
                Sinon = model.Sinon,
            };

            await _context.EvaluationFroids.AddAsync(evalauation);
            _context.SaveChanges();
            var res = await _context.EvaluationFroids.FindAsync(evalauation.Id);

            MyGlobals.key = res.Id;

            _context.SaveChanges();
            return Ok(new { MyGlobals.key });


        }


        [HttpPost]
        [Route("RegisterComtepenceEvaluation")]
        public async Task<IActionResult> PostCompetenceEvaluation(CompetenceEvaluationFroidModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var evalauation = new CompetenceEvaluationFroidModel()
            {
                IdEvaluation = MyGlobals.key,
                Competence = model.Competence,
                Niveau_actuel = model.Niveau_actuel,
                Degre = model.Degre,
                Niveau_acquis = model.Niveau_acquis,
                Critere10 = model.Critere10,


            };

            await _context.CompetenceEvaluationFroids.AddAsync(evalauation);
            _context.SaveChanges();
            return Ok(new {});


        }
        //Get all Evaluation
        [HttpGet]
        [Route("GetAllEvaluationFoid")]
        public IEnumerable<Object> GetAllEvaluation()
        {
            var Evaluation = _context.EvaluationFroids;
            if (Evaluation == null)
            {
                return (null);
            }

            return (Evaluation);
        }
        //Calcule de taux d'efficacité d'une formation
        public static class Evalobj
        {
            public static Double NbTotalEvaluation = 0;
            public static Double NbEfficaceEval = 0;
            public static Double taux = 0;
            public static int annee = 0;

            //  public static string UserName = "";
        };
        [HttpGet]
        [Route("CalculeTauxEfficacite")]
        public IEnumerable<Object> TauxEfficacité()
        {
            List<int> distinctItems = new List<int>();
            List<Object> List = new List<Object>();
            var evaluation = _context.EvaluationFroids.Where(x => x.Critere9 == "oui");
            foreach (var element in evaluation)
            { if(!distinctItems.Contains(element.Date_Fin.Year))
                {
                    distinctItems.Add(element.Date_Fin.Year);
                }
            }
        
            for (var i=0;i< distinctItems.Count(); i++)
            {
                Evalobj.NbTotalEvaluation = _context.EvaluationFroids.Where(x => x.Date_Fin.Year == distinctItems[i]).Count();
                Evalobj.NbEfficaceEval = _context.EvaluationFroids.Where(x => x.Critere9 == "oui" && x.Date_Fin.Year==distinctItems[i]).Count();
                Evalobj.taux = (Evalobj.NbEfficaceEval / Evalobj.NbTotalEvaluation);
                Evalobj.annee = distinctItems[i];
                List.Add(new { Evalobj.NbTotalEvaluation, Evalobj.NbEfficaceEval, Evalobj.taux, Evalobj.annee }) ;
            }
            //  Double NbEfficaceEval = _context.EvaluationFroids.Where(x => x.Critere9 == "oui").Count();


           return List;
        }
    }
}
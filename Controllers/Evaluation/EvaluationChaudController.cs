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

namespace ProcessusFormation.Controllers.Evaluation
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvaluationChaudController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
       
        private readonly ApplicationDbContext _context;
        /// private Database Database { get; set; }

        public EvaluationChaudController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {

            _context = context;
            _userManager = userManager;

        }


        [HttpPost]
        [Route("RegisterEvaluationChaud")]
        public async Task<IActionResult> PostChaudEvaluation(EvaluationChaud model)

        {
           
           // List<string> domanie = new List<string>();
            var query = _userManager.Users;
            foreach (var element in query)
            {
                if (element.Id == model.IdParticipant) //&& element.LabelId == model.LabelId
                {

                    model.Nom_Participant = element.UserName;
                    model.Prenom_Participant = element.FullName;
                 //   var result = await _context.EvaluationChauds.AddAsync(model);  
                }
                if (element.Id == model.IdDirecteur) //&& element.LabelId == model.LabelId
                {

                    model.Formateur = element.UserName + "" + element.FullName;
                    //   var result = await _context.EvaluationChauds.AddAsync(model);  
                }
            };
            foreach (var element in query)
            {
                
                if (element.Id == model.IdDirecteur) //&& element.LabelId == model.LabelId
                {

                    model.Formateur = element.UserName + " " + element.FullName;
                    //   var result = await _context.EvaluationChauds.AddAsync(model);  
                }
            };
            var result = await _context.EvaluationChauds.AddAsync(model);
            _context.SaveChanges();

            return Ok(new { });


        }



        //Get all Evaluation
        [HttpGet]
        [Route("GetAllEvaluation")]
        public IEnumerable<Object> GetAllEvaluation()
        {
            var Evaluation = _context.EvaluationChauds;
            if (Evaluation == null)
            {
                return (null);
            }

            return (Evaluation);
        }
        //get evaluation chaud by Id
        [HttpGet]
        [Route("GetEvaluationChaud/{id}")]
        public IEnumerable<Object> GetEvaluationChaud(string id)
        {
            var Evaluation = _context.EvaluationChauds.Where(x=>x.IdParticipant== id);
            if (Evaluation == null)
            {
                return (null);
            }

            return (Evaluation);
        }
        [HttpGet]
        [Route("GetEvaluationDirec/{id}")]
        public IEnumerable<Object> GetEvaluationChaudDA(string id)
        {
            var Evaluation = _context.EvaluationChauds.Where(x => x.IdDirecteur == id);
            if (Evaluation == null)
            {
                return (null);
            }

            return (Evaluation);
        }
      
        //get evaluation froid by Id
        [HttpGet]
        [Route("GetEvaluationFroid/{id}")]
        public IEnumerable<Object> GetEvaluationFroid(string id)
        {
            var Evaluation = _context.EvaluationFroidParticipants.Where(x => x.IdParticipant == id);
            if (Evaluation == null)
            {
                return (null);
            }

            return (Evaluation);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProcessusFormation.Data;
using ProcessusFormation.Models.Evaluation;

namespace ProcessusFormation.Controllers.Evaluation
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvaluationFournisseurController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public EvaluationFournisseurController(ApplicationDbContext context )
        {

            _context = context;
           

        }

        [HttpPost]
        [Route("RegisterEvaluationFournisseur")]
        public async Task<IActionResult> PostChaudEvaluation(EvaluationFournisseurModel model)

        {


            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            var Model = new EvaluationFournisseurModel()
            {
                Nom_Fournisseur = model.Nom_Fournisseur,
                Categorie = model.Categorie,
                Conformite = model.Conformite,
                Date_Evaluation = model.Date_Evaluation,
                Semestre = model.Semestre,
                Totale_evaluation = model.Totale_evaluation,

            };
                var result = await _context.EvaluationFournisseurs.AddAsync(Model);
            _context.SaveChanges();

            return Ok(new { });

          

        }
    }
}
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
    public class EvaluationChaudController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        /// private Database Database { get; set; }

        public EvaluationChaudController(ApplicationDbContext context)
        {

            _context = context;

        }


        [HttpPost]
        [Route("RegisterEvaluationChaud")]
        public async Task<IActionResult> PostChaudEvaluation(EvaluationChaud model)

        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

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
    }
}
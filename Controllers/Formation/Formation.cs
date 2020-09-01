using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProcessusFormation.Data;
using ProcessusFormation.Models.Formation;

namespace ProcessusFormation.Controllers.Formation
{
    [Route("api/[controller]")]
    [ApiController]
    public class Formation : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public Formation(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("FormationPlanifier/{id}")]
        public IActionResult GetFormationPlanifier(string id)
        {
            DateTime thisDay = DateTime.Today;
            var query = _context.ParticipantFormation.Where(x => x.ParticipantId == id)
                .Join(
                _context.BesoinFormationModels.Where(x => x.FormationType == "BesoinCollecte"&& x.Date_Fin > thisDay),
                ParticipantFormation => ParticipantFormation.BesoinFormationId,

                BesoinFormationModel => BesoinFormationModel.BesoinFormationId,

                (ParticipantFormation, BesoinFormationModel) => 
                
                    BesoinFormationModel



                



                ).ToList();

            return Ok(query);
        }
        [HttpGet]
        [Route("FormationRealise/{id}")]
        public IActionResult Details(string id)
        {
            DateTime thisDay = DateTime.Today;
            var query = _context.ParticipantFormation.Where(x => x.ParticipantId == id)
                .Join(
                _context.BesoinFormationModels.Where(x => x.FormationType == "BesoinCollecte" && x.Date_Fin < thisDay),
                ParticipantFormation => ParticipantFormation.BesoinFormationId,

                BesoinFormationModel => BesoinFormationModel.BesoinFormationId,

                (ParticipantFormation, BesoinFormationModel) => 
                
                    BesoinFormationModel).ToList();

            return Ok(query);
        }
        //lazem nzid chams n7ot fih Id de participant
        [HttpGet]
        [Route("AffichageEvalChaud/{id}")]
        public IActionResult AffichageEvalChaud(string id)
        {

            var query = _context.EvaluationChauds.Where(x => x.IdParticipant == id);
              

            return Ok(query);
        }
        [HttpGet]
        [Route("AffichageEvalFroid/{id}")]
        public IActionResult AffichageEvalFroid(string id)
        {

            var query = _context.EvaluationChauds.Where(x => x.IdParticipant == id);


            return Ok(query);
        }
        // GET: api/Formation
        [HttpGet]
        public IEnumerable<BesoinFormationModel> GetBesoinFormations()
        {
            return _context.BesoinFormationModels;
        }

        // GET: api/Formation/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBesoinFormationModel([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var besoinFormationModel = await _context.BesoinFormationModels.FindAsync(id);

            if (besoinFormationModel == null)
            {
                return NotFound();
            }

            return Ok(besoinFormationModel);
        }

        // PUT: api/Formation/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBesoinFormationModel([FromRoute] string id, [FromBody] BesoinFormationModel besoinFormationModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != besoinFormationModel.BesoinFormationId)
            {
                return BadRequest();
            }

            _context.Entry(besoinFormationModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BesoinFormationModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // PUT: api/Formation/5
        [HttpPut("ChangeTocollectType/{idFormation}")]
        public async Task<IActionResult> ChangeTocollectType([FromRoute] string idFormation, [FromBody] BesoinFormationModel besoinFormationModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (idFormation != besoinFormationModel.BesoinFormationId)
            {
                return BadRequest();
            }
            //ici la formation enregistre apres que l'admin complete de remplire le resencement de besoin
            besoinFormationModel.FormationType = "BesoinCollecte";
            _context.Entry(besoinFormationModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BesoinFormationModelExists(idFormation))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Formation
        [HttpPost]
        public async Task<IActionResult> PostBesoinFormationModel([FromBody] BesoinFormationModel besoinFormationModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //besoin formation ici c'est la formulaire remplit par directeur activite
            besoinFormationModel.FormationType = "BesoinFormation";
            _context.BesoinFormationModels.Add(besoinFormationModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBesoinFormationModel", new { id = besoinFormationModel.BesoinFormationId }, besoinFormationModel);
        }
       
        //DELETE: api/Formation/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBesoinFormationModel([FromRoute] string id)
        {
            List<ParticipantFormation> distinctItems = new List<ParticipantFormation>();
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var besoin = _context.ParticipantFormation;
                foreach (var element in besoin)
                {
                    if (element.BesoinFormationId == id) //&& element.LabelId == model.LabelId
                    {
                        //  yield return element;
                        _context.ParticipantFormation.Remove(element);
                    //    distinctItems.Add(element);



                    }
                }
                await _context.SaveChangesAsync();
                var besoinFormationModel = await _context.BesoinFormationModels.FindAsync(id);
              
                if (besoinFormationModel == null)
                {
                    return NotFound();
                }

                _context.BesoinFormationModels.Remove(besoinFormationModel);
                await _context.SaveChangesAsync();

                return Ok(besoinFormationModel);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private bool BesoinFormationModelExists(string id)
        {
            return _context.BesoinFormationModels.Any(e => e.BesoinFormationId == id);
        }
    }
}
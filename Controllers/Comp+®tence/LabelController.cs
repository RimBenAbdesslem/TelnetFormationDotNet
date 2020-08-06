using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProcessusFormation.Data;
using ProcessusFormation.Models.Compétence;

namespace ProcessusFormation.Controllers.Compétence
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabelController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public LabelController(ApplicationDbContext context)
        {
            _context = context;
        }




        [HttpPost]
        [Route("RegisterLabel/{id}")]
        public async Task<IActionResult> PostBesoinFormation(LabelModel model, int id )
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            var Label = new LabelModel()
            {
                NomLabel = model.NomLabel,
                Niveau = model.Niveau,
                DomaineId = id,

            };

            var result = await _context.Labels.AddAsync(Label);
             _context.SaveChanges();
           // var application = await _context.BesoinFormations.FindAsync(applicationUser.Id);
           // _context.Labels.UpdateRange();
           //recuperer l'id de dernier element inseré puiis get cette element 
             return Ok(new { });

        }


        //Get all Domaine
        [HttpGet]
        [Route("GetAllLabels")]
        public IEnumerable<Object> GetAllLabels()
        {

            var label = _context.Labels;
            if (label == null)
            {
                return (null);
            }

            return (label);
        }

        //dellete Labels
        [HttpDelete]
        [Route("DeleteAllLabels/{id}")]
        public async Task<ActionResult> DelleteLabels(int id)
        {

            var Label = await _context.Labels.FindAsync(id);
            if (Label == null)
            {
                return NotFound();
            }

            _context.Labels.Remove(Label);
           await _context.SaveChangesAsync();

            return Ok();
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProcessusFormation.Data;
using ProcessusFormation.Models.Comp__tence;

namespace ProcessusFormation.Controllers.Comp__tence
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActiviteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ActiviteController(ApplicationDbContext context)
        {
            _context = context;
        }


        //ajouter Activite
        [HttpPost]
        [Route("RegisterActivite")]
        public async Task<IActionResult> PostBesoinFormation(ActiviteModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            var activite = new ActiviteModel()
            {
                NomActivite = model.NomActivite,

            };

            var result = await _context.Activites.AddAsync(activite);
            _context.SaveChanges();
            return Ok(new { });

        }
        //Gett All Activities

        [HttpGet]
        [Route("GetAllActivites")]
        public IEnumerable<Object> GetAllActivite()
        {

            var activite = _context.Activites;
            if (activite == null)
            {
                return (null);
            }

            return (activite);
        }
        //Dellete Activities
        [HttpDelete]
        [Route("deleteActivite/{id}")]
        public async Task<ActionResult> DeleteActivite(int id)
        {
            var activite = await _context.Activites.FindAsync(id);
            if (activite == null)
            {
                return NotFound();
            }

            _context.Activites.Remove(activite);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
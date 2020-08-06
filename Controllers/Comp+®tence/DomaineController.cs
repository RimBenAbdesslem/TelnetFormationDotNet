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
    public class DomaineController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        public DomaineController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("RegisterDomaine")]
        public async Task<IActionResult> PostBesoinFormation(DomaineModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            var domaine = new DomaineModel()
            {
                NomDomaine = model.NomDomaine,           

            };

            var result = await _context.Domaines.AddAsync(domaine);
            _context.SaveChanges();
            return Ok(new { });

        }



        [HttpPost]
        [Route("ModifierDomaine/{id}")]
        public async Task<IActionResult> ModifierBesoinFormation(int id,DomaineModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            var domaine = await _context.Domaines.FindAsync(id);


            domaine.NomDomaine = model.NomDomaine;

            _context.Update(domaine);

          //  var result = await _context.Domaines.Update(DomaineId);
            _context.SaveChanges();
            return Ok(new { });

        }

        //Get all Domaine
        [HttpGet]
        [Route("GetAllDomaines")]
        public IEnumerable<Object> GetAllDomaine()
        {

            var domaine = _context.Domaines;
            if (domaine == null)
            {
                return (null);
            }

            return (domaine);
        }



        [HttpDelete]
        [Route("deleteDomaine/{id}")]
        public async Task<ActionResult> DeleteDomaine(int id)
        {
            var domaine = await _context.Domaines.FindAsync(id);
            if (domaine == null)
            {
                return NotFound();
            }

            _context.Domaines.Remove(domaine);
            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}
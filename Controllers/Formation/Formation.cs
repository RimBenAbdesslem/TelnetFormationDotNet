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
            besoinFormationModel.FormationType = "BesoinFormation";
            _context.BesoinFormationModels.Add(besoinFormationModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBesoinFormationModel", new { id = besoinFormationModel.BesoinFormationId }, besoinFormationModel);
        }

        // DELETE: api/Formation/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBesoinFormationModel([FromRoute] string id)
        {
            try
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
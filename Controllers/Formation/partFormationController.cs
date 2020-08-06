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
    public class partFormationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public partFormationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/partFormation
        [HttpGet]
        public IEnumerable<ParticipantFormation> GetParticipantFormation()
        {
            return _context.ParticipantFormation;
        }

        // GET: api/partFormation/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetParticipantFormation([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var participantFormation = await _context.ParticipantFormation.FindAsync(id);

            if (participantFormation == null)
            {
                return NotFound();
            }

            return Ok(participantFormation);
        }

        // PUT: api/partFormation/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParticipantFormation([FromRoute] string id, [FromBody] ParticipantFormation participantFormation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != participantFormation.BesoinFormationId)
            {
                return BadRequest();
            }

            _context.Entry(participantFormation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticipantFormationExists(id))
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

        // POST: api/partFormation
        [HttpPost]
        public async Task<IActionResult> PostParticipantFormation([FromBody] ParticipantFormation participantFormation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ParticipantFormation.Add(participantFormation);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ParticipantFormationExists(participantFormation.BesoinFormationId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetParticipantFormation", new { id = participantFormation.BesoinFormationId }, participantFormation);
        }

        // DELETE: api/partFormation/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticipantFormation([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var participantFormation = await _context.ParticipantFormation.FindAsync(id);
            if (participantFormation == null)
            {
                return NotFound();
            }

            _context.ParticipantFormation.Remove(participantFormation);
            await _context.SaveChangesAsync();

            return Ok(participantFormation);
        }

        private bool ParticipantFormationExists(string id)
        {
            return _context.ParticipantFormation.Any(e => e.BesoinFormationId == id);
        }
    }

}
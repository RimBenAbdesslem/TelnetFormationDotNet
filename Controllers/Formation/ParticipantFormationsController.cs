using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProcessusFormation.Data;
using ProcessusFormation.Models;
using ProcessusFormation.Models.Formation;

namespace ProcessusFormation.Controllers.Formation
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantFormationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ParticipantFormationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ParticipantFormations
        [HttpGet]
        public IEnumerable<ParticipantFormation> GetParticipantFormation()
        {
            return _context.ParticipantFormation;
        }

        // GET: api/ParticipantFormations/5
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


        // GET: api/ParticipantFormations/5
        [HttpGet("getParticipants/{idBesoinFormation}")]
        public IActionResult GetBesoinFormationParticipants([FromRoute] string idBesoinFormation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            };

            var result = from ParticipantFormation in _context.ParticipantFormation
                         join user in _context.ApplicationUsers on ParticipantFormation.ParticipantId equals user.Id into Users
                         from m in Users.DefaultIfEmpty()
                         where ParticipantFormation.BesoinFormationId == idBesoinFormation
                         select new
                         {
                             id = ParticipantFormation.Id,
                             ParticipantId = ParticipantFormation.ParticipantId,
                             BesoinFormationId = ParticipantFormation.BesoinFormationId,
                             username = m.UserName
                         };

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // PUT: api/ParticipantFormations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParticipantFormation([FromRoute] string id, [FromBody] ParticipantFormation participantFormation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != participantFormation.Id)
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

        // POST: api/ParticipantFormations
        [HttpPost]
        public async Task<IActionResult> PostParticipantFormation([FromBody] ParticipantFormation participantFormation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ParticipantFormation.Add(participantFormation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParticipantFormation", new { id = participantFormation.Id }, participantFormation);
        }

        // DELETE: api/ParticipantFormations/5
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
            return _context.ParticipantFormation.Any(e => e.Id == id);
        }
    }

}
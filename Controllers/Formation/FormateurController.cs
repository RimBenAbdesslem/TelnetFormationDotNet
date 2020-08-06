using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProcessusFormation.Data;
using ProcessusFormation.Models.Formation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProcessusFormation.Controllers.Formation
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormateurController : ControllerBase
    {
        // private readonly ApplicationDbContext _context;
        private readonly ApplicationDbContext _context;

        public FormateurController(ApplicationDbContext context)
        {

            _context = context;

        }

       [HttpPost] 
       [Route("RegisterFormateur")]
        public async Task<IActionResult> PostFormateur(FormateurModel formateur)
        {
            if (formateur is null)
            {
                throw new ArgumentNullException(nameof(formateur));
            }
            var Organisme = new FormateurModel()
            {
                Theme = formateur.Theme,
                Organisme_prestataire = formateur.Organisme_prestataire,
                Nom_Formateur = formateur.Nom_Formateur,
                Period = formateur.Period,
                Score = formateur.Score,
            };
            var resultat = await _context.Formateurs.AddAsync(Organisme);
            _context.SaveChanges();
            return Ok(formateur);
        }

        //Get all Formateurs
        [HttpGet]
        [Route("GetAllFormateurs")]
        public IEnumerable<Object> GetAllFormateurs()
        {
           
            var Formateurs = _context.Formateurs;
            if (Formateurs == null)
            {
                return (null);
            }

            return (Formateurs);
        }



        //delete formateur
        [HttpDelete]
        [Route("deleteFormateur/{id}")]
        public async Task<ActionResult> DeleteFormateur(int id)
        {
            var FormateurDetail = await _context.Formateurs.FindAsync(id);
            if (FormateurDetail == null)
            {
                return NotFound();
            }

            _context.Formateurs.Remove(FormateurDetail);
            await _context.SaveChangesAsync();

            return Ok();
        }

        //top 5 formateurs 
        [HttpGet]
        [Route("top")]
        public async Task<IActionResult> Details()
        {

            //var Formateur = _context.Formateurs
                   // .FromSql("P 5 * from Formateurs order by Score desc")
                    // .ToList();
           string query = " Select TOP 5 * from Formateurs order by Score  desc";
            var Formateur = await _context.Formateurs
                .FromSql(query)
               // .FirstOrDefaultAsync();
                .ToListAsync();



            return Ok(Formateur);
        }
       
       





    }

}
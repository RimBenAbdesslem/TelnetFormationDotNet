using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProcessusFormation.Data;
using ProcessusFormation.Models.Formation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using Microsoft.EntityFrameworkCore;

namespace ProcessusFormation.Controllers.Formation
{
    [Route("api/[controller]")]
    [ApiController]
    public class BesoinFormationController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
       
        public static class MyGlobals
        {
            public static string key;

        }
        public BesoinFormationController(ApplicationDbContext context)
        {
          
            _context = context;

        }

        //ajouter un nouveau formation
        [HttpPost]
        [Route("RegisterFormation")]
        public async Task<IActionResult> PostBesoinFormation(BesoinFormationModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            var BesoinFormation = new BesoinFormationModel()
            {
                Activite = model.Activite,
                Intitule_Formation = model.Intitule_Formation,
                Priorite = model.Priorite,
                Justification_du_besoin = model.Justification_du_besoin,
                Nombre_de_participants = model.Nombre_de_participants,
                FormationType = "BesoinFormation"
        };
            //icij'ajoute une nouvelle formation et au meme temps je paaser l'id de cette formation comme un parametre ala fonction GetBesoinFormation()
            await _context.BesoinFormationModels.AddAsync(BesoinFormation);
            _context.SaveChanges();
             var application = await _context.BesoinFormationModels.FindAsync(BesoinFormation.BesoinFormationId);
            //Console.WriteLine(application.Id);
           // await GetBesoinFormation(application.Id);
          // MyGlobals.key = BesoinFormation.Id;

            //return Ok(new { MyGlobals.key });
            return Ok(BesoinFormation.BesoinFormationId);

        }

        // [HttpGet("{id}")] ;   public async Task<object> GetBesoinFormation([FromRoute] string id)

        [HttpGet] 
        [Route("GetOnBesoin")]
        public async Task<object> GetBesoinFormation()
        {
            Console.WriteLine(MyGlobals.key);
            if (MyGlobals.key is null)
            {
                return Ok(new { });
            }
            var BesoinFormation = await _context.BesoinFormationModels.FindAsync(MyGlobals.key);
            if (BesoinFormation == null)
            {
                return NotFound();
            }

            return (BesoinFormation);
        }


        [HttpGet]
        [Route("GetAllBesoin")]
        public IEnumerable<Object> GetAllBesoins()
        {

            var BesoinFormation = _context.BesoinFormationModels;
            if (BesoinFormation == null)
            {
                return (null);
            }

            return (BesoinFormation);
        }


        //top 5 formateurs 
        [HttpGet]
        [Route("getCountBesoinFormations")]
        public IActionResult getCountBesoinFormations()
        {
            var BesoinFormation = _context.BesoinFormationModels.ToList().Where(x => x.FormationType == "BesoinFormation").Count();
            var BesoinCollecte = _context.BesoinFormationModels.ToList().Where(x => x.FormationType == "BesoinCollecte").Count();
            return Ok(new { BesoinFormation = BesoinFormation, BesoinCollecte = BesoinCollecte });
        }

    }
}
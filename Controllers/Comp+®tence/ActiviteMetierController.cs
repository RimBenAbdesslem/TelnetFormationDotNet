using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProcessusFormation.Data;
using ProcessusFormation.Models;
using ProcessusFormation.Models.Comp__tence;
using ProcessusFormation.Models.Compétence;

namespace ProcessusFormation.Controllers.Comp__tence
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActiviteMetierController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        public ActiviteMetierController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("RegisterActiviteMetier")]
        public async Task<IActionResult> PostBesoinFormation(ActiviteMetierModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            var metier = new ActiviteMetierModel()
            {
                ActiviteId = model.ActiviteId,
                DomaineId = model.DomaineId,
                UserId = model.UserId,
                LabelId = model.LabelId,
                Niveau = model.Niveau,

            };

            var result = await _context.ActiviteMetiers.AddAsync(metier);
            _context.SaveChanges();
            return Ok(new { });

        }

      


        //Get all 
        [HttpGet]
        [Route("GetActiviteDomaine/{id}")]
        public IEnumerable<Object> GetAllDomaine(string id)
        {
            List<int> ListId = new List<int>();
            List<DomaineModel> List = new List<DomaineModel>();
            List<ActiviteModel> Liste = new List<ActiviteModel>();
            var metiers = _context.ActiviteMetiers;
            var domaines = _context.Domaines;
            if (metiers == null)
            {
                yield return (null);
            }
            // je doit recuperer dans une liste tout les labelId qui correspond à l'utilisateur element.UserId == model.UserId
            foreach (var element in metiers)
            {
                if (element.UserId == id)
                // && element.LabelId == model.LabelId
                {
                    ListId.Add(element.DomaineId);
                // yield return (element);
                };
            }
        }
    }
}
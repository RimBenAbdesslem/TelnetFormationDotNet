using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProcessusFormation.Data;
using ProcessusFormation.Models.Comp__tence;
using ProcessusFormation.Models.Compétence;
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
        //Get all 
        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<Object> GetAll()
        {
            var metiers = _context.ListeActivites;
            return metiers;
        }
        [HttpPost]
        [Route("RegisterListeActivite")]
        public async Task<IActionResult> PostBesoinFormation(ListeActiviteModel model)
        {
            var label = _context.Labels.Find(model.LabelId);
            var activite = _context.Activites.Find(model.ActiviteId);
            var domaine = _context.Domaines.Find(model.DomaineId);
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            var metier = new ListeActiviteModel()
            {
                ActiviteId = model.ActiviteId,
                DomaineId = model.DomaineId,
                LabelId = model.LabelId,
                NomActivite = activite.NomActivite,
                NomLabel = label.NomLabel,
                NomDomaine = domaine.NomDomaine,

            };

            var result = await _context.ListeActivites.AddAsync(metier);
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
        //Dellete Liste Activities
        [HttpDelete]
        [Route("deleteListeActivite/{id}")]
        public async Task<ActionResult> DeleteListeActivite(int id)
        {
            var activite = await _context.ListeActivites.FindAsync(id);
            if (activite == null)
            {
                return NotFound();
            }

            _context.ListeActivites.Remove(activite);
            await _context.SaveChangesAsync();

            return Ok();
        }
        [HttpGet]
        [Route("GetListe/{id}")]
        public IEnumerable<Object> GetListeActivite(string id)
        {

            List<int> activite = new List<int>();
            List<ActiviteModel> distinctItems = new List<ActiviteModel>();
            List<int> List = new List<int>();
            var metiers = _context.ActiviteMetiers;
            var ListeActivite = _context.Activites;

            //  return user;
            //  List<Object> ListUser = new List<Object>();
            foreach (var element in metiers)
            {
                if (element.UserId == id) //&& element.LabelId == model.LabelId
                {
                    //  yield return element;
                    activite.Add(element.ActiviteId);



                }
            }

            foreach (var element in ListeActivite)
            {

                for (int j = 0; j < activite.Count; j++)
                {
                    if (element.Id == activite[j] && !distinctItems.Contains(element))
                    {
                        distinctItems.Add(element);
                    }
                }

            };
            return distinctItems;
        }



        [HttpGet]
        [Route("listeActivite/{id}")]
        public IEnumerable<Object> GetAllLabel(int id)
        {
            List<int> ListId = new List<int>();
            List<LabelModel> List = new List<LabelModel>();
            var metiers = _context.ListeActivites;
         //   var labels = _context.Labels;
         //   var domaine = _context.Domaines;
            if (metiers == null)
            {
                yield return (null);
            }
            // je doit recuperer dans une liste tout les labelId qui correspond à l'utilisateur element.UserId == model.UserId
            foreach (var element in metiers)
            {
                if (element.ActiviteId == id) //&& element.LabelId == model.LabelId
                {
                //    ListId.Add(element.LabelId);
                   yield return (element);

                };
            }
            //ici il faut retourner la liste de label qui correspant au utilisateur d'id element.UserId == model.UserId

         //   for (int j = 0; j < ListId.Count; j++)
         //   {
              //  foreach (var label in labels)
           //     {
            //       if (ListId[j] == label.LabelId)
            //        {
            //            List.Add(label);
            //            //  return eval;
            //        }

              //  }
          //  }
           // for (int j = 0; j < List.Count; j++)
          //  {
            //    yield return List[j];
           // }
        }

    }
}
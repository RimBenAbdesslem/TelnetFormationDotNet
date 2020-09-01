using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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





        [HttpDelete]
        [Route("deleteActiviteMitier/{activMetId}")]
        public async Task<ActionResult> DeleteActiviteMitier(int activMetId)
        {
            var domaine = await _context.ActiviteMetiers.FindAsync(activMetId);
            if (domaine == null)
            {
                return NotFound();
            }

            _context.ActiviteMetiers.Remove(domaine);
            await _context.SaveChangesAsync();

            return Ok();
        }
        [HttpPost]
        [Route("RegisterActiviteMetier")]
        public async Task<IActionResult> PostBesoinFormation(ActiviteMetierModel model)
        {
            var label = _context.Labels.Find(model.LabelId);
            var activite = _context.Activites.Find(model.ActiviteId);
            var domaine = _context.Domaines.Find(model.DomaineId);
            
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
                NomActivite = activite.NomActivite,
                NomLabel = label.NomLabel,
                NomDomaine = domaine.NomDomaine,
                Niveau = model.Niveau,

            };

            var result = await _context.ActiviteMetiers.AddAsync(metier);
            _context.SaveChanges();
            return Ok(new { });

        }

        //Get Metier selon IDUser
        [HttpGet]
        [Route("GetAllmetieruser/{UserId}")]
        public IEnumerable<Object> GetUserMetier(string UserId)
        {
            return _context.ActiviteMetiers.ToList().Where(x => x.UserId == UserId);
        }
        // PUT: api/Metier/5
        [HttpPut("editLevel/{id}")]
        public async Task<IActionResult> PutMetier([FromRoute] int id, int niveau = 0)
        {
            try
            {

                var MetierModel = await _context.ActiviteMetiers.FindAsync(id);
                MetierModel.Niveau = niveau;

                _context.Entry(MetierModel).State = EntityState.Modified;

                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }

            return NoContent();
        }


        [HttpGet]
        [Route("GetAllUserLabel/{id}")]
        public IEnumerable<Object> GetAllLabel(int id)
        {
            List<int> ListId = new List<int>();
            List<LabelModel> List = new List<LabelModel>();
            var metiers = _context.ActiviteMetiers;
            var labels = _context.Labels;
            if (metiers == null)
            {
                yield return (null);
            }
            // je doit recuperer dans une liste tout les labelId qui correspond à l'utilisateur element.UserId == model.UserId
            foreach (var element in metiers)
            {
                if (element.ActiviteId == id) //&& element.LabelId == model.LabelId
                {
                   // ListId.Add(element.LabelId);
                        yield return (element);

                };
            }
         
        }
        //Get Metier selon IDUser
        [HttpGet]
        [Route("GetAllActivitemetieruser/{id}")]
        public  IEnumerable<Object> GetUserMetier(int id)
        {
            List<ApplicationUser> distinctItems = new List<ApplicationUser>();
            var metiers= _context.ActiviteMetiers.ToList().Where(x => x.ActiviteId == id);
          //  return metiers;
            var user =  _userManager.Users;
            foreach (var element in metiers)
            {
             //   yield return element;
                foreach (var ele in user) {
                    if (ele.Id == element.UserId && !distinctItems.Contains(ele))
                    {

                        distinctItems.Add( ele);

                    }
                        
                }

              
               
            }
            return distinctItems;
        }



        //get users par domaine d'activité
       // int domanie;
        [HttpGet]
        [Route("GetusersByDomaine/{id}")]
        public IEnumerable<Object> GetusersByDomaine(string id)
        {
            List<int> domanie = new List<int>();
            List<int> activite = new List<int>();
            List<ActiviteMetierModel> distinctItems = new List<ActiviteMetierModel>();
            List<String> List = new List<String>();
            //  var user = await _userManager.FindByIdAsync(id);
            var metiers = _context.ActiviteMetiers;
           
            var users = _userManager.Users;
            //  return user;
            //  List<Object> ListUser = new List<Object>();
            foreach (var element in metiers)
            {
                if (element.UserId == id) //&& element.LabelId == model.LabelId
                {
                   
                    domanie.Add(element.ActiviteId);


                }
            };
            foreach (var element in metiers)
            {
                for (int j = 0; j < domanie.Count; j++)
                {
                    if (element.ActiviteId == domanie[j])
                    {
                        yield return element;
                    }
                }
                
            };

            //   return List;




        }
        [HttpGet]
        [Route("GetusersByActivite/{id}")]
        public IEnumerable<Object> GetusersByActivite(string id)
        {
          
            List<int> activite = new List<int>();
            List<ListeActiviteModel> distinctItems = new List<ListeActiviteModel>();
            List<String> List = new List<String>();
            //  var user = await _userManager.FindByIdAsync(id);
            var metiers = _context.ActiviteMetiers;
            var ListeActivite = _context.ListeActivites;
          
            //  return user;
            //  List<Object> ListUser = new List<Object>();
            foreach (var element in metiers)
            {
                if (element.UserId == id) //&& element.LabelId == model.LabelId
                {
                    activite.Add(element.ActiviteId);
                }
            };

            foreach (var element in ListeActivite)
            {
                for (int j = 0; j < activite.Count; j++)
                {
                    if (element.ActiviteId == activite[j] && !distinctItems.Contains(element))
                    {
                        distinctItems.Add(element);
                    }
                }

            };
            return distinctItems;
        }


        [HttpGet]
        [Route("GetuserConnecteActivite/{id}")]
       
        public IEnumerable<Object> GetuserConnecteActivite(string id)
        {

            List<int> activite = new List<int>();
            List<ActiviteMetierModel> distinctItems = new List<ActiviteMetierModel>();
            List<String> List = new List<String>();
            //  var user = await _userManager.FindByIdAsync(id);
            var metiers = _context.ActiviteMetiers;
            var ListeActivite = _context.ListeActivites;

            //  return user;
            //  List<Object> ListUser = new List<Object>();
            foreach (var element in metiers)
            {
                if (element.UserId == id && !distinctItems.Contains(element)) //&& element.LabelId == model.LabelId
                {
                    distinctItems.Add(element);
                 //   activite.Add(element.ActiviteId);
                }
            };


       
            return distinctItems;
        }







        [HttpGet]
        [Route("GetusersActivite/{id}")]
        public IEnumerable<Object> GetuserActivite(string id)
        {

            List<int> activite = new List<int>();
            List<ApplicationUser> distinctItems = new List<ApplicationUser>();
            List<String> List = new List<String>();
            //  var user = await _userManager.FindByIdAsync(id);
            var metiers = _context.ActiviteMetiers;
            var ListeUser = _userManager.Users;

            //  return user;
            //  List<Object> ListUser = new List<Object>();
            foreach (var element in metiers)
            {
                if (element.UserId == id) //&& element.LabelId == model.LabelId
                {
                    activite.Add(element.ActiviteId);



                }
            };
           
            //   return List;

            foreach (var element in metiers)
            {
                for (int j = 0; j < activite.Count; j++)
                {
                    if (element.ActiviteId == activite[j])
                    {
                        List.Add(element.UserId);
                    }
                }

            };
            foreach (var element in ListeUser)
            {
                for (int j = 0; j < List.Count; j++ )
                {
                    if (element.Id == List[j] && !distinctItems.Contains(element))
                    {
                        distinctItems.Add(element);
                    }
                }

            };
            return distinctItems;
        }
        [HttpGet]
        [Route("ListeActivite/{id}")]
        public IEnumerable<Object> GetListeActivite(string id)
        {

            List<int> activite = new List<int>();
            List<ActiviteModel> distinctItems = new List<ActiviteModel>();
            List<int> List = new List<int>();
            var metiers = _context.ActiviteMetiers;
            var AllListeActivite = _context.Activites;

         //   return metiers;
            //  List<Object> ListUser = new List<Object>();
            foreach (var element in metiers)
            {
                if (element.UserId == id) //&& element.LabelId == model.LabelId
                {
                 //  yield return element;
                    activite.Add(element.ActiviteId);



                }
            }

            foreach (var element in AllListeActivite)
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

      




        //Get all 
        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<Object> GetAll()
        {
            var metiers = _context.ActiviteMetiers;
            return metiers;
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
        [HttpGet]
        [Route("GetAllActiviteUserLabel/{id}")]
        public IEnumerable<Object> GetAllLabel(string id)
        {
            List<int> ListId = new List<int>();
            List<LabelModel> List = new List<LabelModel>();
            var metiers = _context.ActiviteMetiers;
            var labels = _context.Labels;
            if (metiers == null)
            {
                yield return (null);
            }
            // je doit recuperer dans une liste tout les labelId qui correspond à l'utilisateur element.UserId == model.UserId
            foreach (var element in metiers)
            {
                if (element.UserId == id) //&& element.LabelId == model.LabelId
                {
                    ListId.Add(element.LabelId);
                    //    yield return (element);

                };
            }
            //ici il faut retourner la liste de label qui correspant au utilisateur d'id element.UserId == model.UserId

            for (int j = 0; j < ListId.Count; j++)
            {
                foreach (var label in labels)
                {
                    if (ListId[j] == label.LabelId)
                    {
                        List.Add(label);
                        //  return eval;
                    }

                }
            }
            for (int j = 0; j < List.Count; j++)
            {
                yield return List[j];
            }
        }
    }
}
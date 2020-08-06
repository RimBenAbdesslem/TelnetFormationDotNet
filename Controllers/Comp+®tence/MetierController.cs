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
using ProcessusFormation.Models.Compétence;

namespace ProcessusFormation.Controllers.Compétence
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetierController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        public MetierController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }




        // PUT: api/Metier/5
        [HttpPut("editLevel/{id}")]
        public async Task<IActionResult> PutMetier([FromRoute] int id, int niveau = 0)
        {
            try
            {

            var MetierModel = await _context.Metiers.FindAsync(id);
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

        [HttpPost]
        [Route("RegisterMetier")]
        public async Task<IActionResult> PostBesoinFormation(MetierModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            var metier = new MetierModel()
            {

                DomaineId = model.DomaineId,
                UserId = model.UserId,
                LabelId = model.LabelId,
                Niveau = model.Niveau,

            };

            var result = await _context.Metiers.AddAsync(metier);
            _context.SaveChanges();
            return Ok(new { });

        }
        [HttpPost]
        [Route("PostGet")]

        public IActionResult PostGetMetier(MetierModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            //  GetuserSelected(model);
            //   GetAllLabel(model);
            //  GetAllDomaine(model);
            return Ok();
        }
        //Get Metier selon IDUser
        [HttpGet]
        [Route("GetAllmetieruser/{UserId}")]
        public IEnumerable<Object> GetUserMetier(string UserId)
        {
            return _context.Metiers.ToList().Where(x=>x.UserId == UserId);
        }
        //Get all 
        [HttpGet]
        [Route("GetAllDomaineuser/{id}")]
        public IEnumerable<Object> GetAllDomaine(string id)
        {
            List<int> ListId = new List<int>();
            List<DomaineModel> List = new List<DomaineModel>();
            var metiers = _context.Metiers;
            var domaines = _context.Domaines;
            if (metiers == null)
            {
                yield return (null);
            }
            // je doit recuperer dans une liste tout les labelId qui correspond à l'utilisateur element.UserId == model.UserId
            foreach (var element in metiers)
            {
                if (element.UserId == id)//&& element.LabelId == model.LabelId
                {
                    ListId.Add(element.DomaineId);
                    //   yield return (element);

                };
            }
            //ici il faut retourner la liste de label qui correspant au utilisateur d'id element.UserId == model.UserId

            for (int j = 0; j < ListId.Count; j++)
            {
                foreach (var domaine in domaines)
                {
                    if (ListId[j] == domaine.DomaineId)
                    {
                        List.Add(domaine);
                        //  return eval;
                    }

                }
            }
            for (int j = 0; j < List.Count; j++)
            {
                yield return List[j];
            }



        }
        [HttpGet]
        [Route("GetAllUserLabel/{id}")]
        public IEnumerable<Object> GetAllLabel(string id)
        {
            List<int> ListId = new List<int>();
            List<LabelModel> List = new List<LabelModel>();
            var metiers = _context.Metiers;
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

        public static class obj
        {
            public static int labelId=0;
            public static int Niveau=0;
          //  public static string UserName = "";
        };
        public static class Userobj
        {
            public static int labelId = 0;
            public static int Niveau = 0;
            public static string UserId = "";
        };

        [HttpGet]
        [Route("Getuser/{id}")]
        public async Task<Object> Getuser(string id)
        {
            var user =await _userManager.FindByIdAsync(id);
            return user;


        }
        //cette fonction doit retourner tout les laId et Niveau de user selecté
        [HttpGet]
        [Route("GetuserSelected/{id}")]
        public  IEnumerable<Object> GetuserSelected(string id)
        {
       
        var metiers = _context.Metiers;
           
            List<Object> List = new List<Object>();
            //  var user =  _userManager.FindByIdAsync(id);
         //  var  user = _userManager.FindByIdAsync(id);
            foreach (var element in metiers)
            {
                if (element.UserId == id) //&& element.LabelId == model.LabelId
                {
                    obj.labelId = element.LabelId;
                    obj.Niveau = element.Niveau;
                 //   obj.UserName = user.UserName + user.FullName;
                    List.Add(new{ obj.labelId,obj.Niveau});

                }
            };


                 return List;
           
        }

        //get label and niveau par domaine d'activité
        int dom = 0;
        [HttpGet]
        [Route("GetuserDomaine/{id}")]
        public IEnumerable<Object> GetuserDomaine(string id)
        {
            
            var metiers = _context.Metiers;
            var domaine = _context.Domaines;
         //   var user = _userManager.FindByIdAsync(id);
            List<Object> List = new List<Object>();
            //  var user =  _userManager.FindByIdAsync(id);
            //  var  user = _userManager.FindByIdAsync(id);
            foreach (var element in metiers)
            {
                if (element.UserId == id) //&& element.LabelId == model.LabelId
                {
                    dom = element.DomaineId;


                }
            };
            foreach (var element in metiers)
            {
                if (element.DomaineId == dom) //&& element.LabelId == model.LabelId
                {
                    List.Add(element);

                }
            };


           return List;

        }

        //get users par domaine d'activité
        int domanie;
        [HttpGet]
        [Route("GetusersByDomaine/{id}")]
        public IEnumerable<Object> GetusersByDomaine(string id)
        {
            List<String> List = new List<String>();
          //  var user = await _userManager.FindByIdAsync(id);
            var metiers = _context.Metiers;
            var users = _userManager.Users;
            //  return user;
          //  List<Object> ListUser = new List<Object>();
            foreach (var element in metiers)
            {
                if (element.UserId == id) //&& element.LabelId == model.LabelId
                {
                    domanie = element.DomaineId;


                }
            };
            foreach (var element in metiers)
            {
                if (element.DomaineId == domanie) //&& element.LabelId == model.LabelId
                { 
                  //  userId.Id = element.UserId;

                    List.Add(element.UserId);
               //     yield return element;

                }
            };

          //   return List;



            foreach (var ele in users)
            {
              //  yield return ele;
                for (int j = 0; j < List.Count; j++)
                {
                    if (ele.Id == List[j])
                    {
                        yield return ele;
                    }
                }
            }
           
          }
        //ici bech nraja3 tout les labelId UserID et niveau de chacun
        int DomaineDA;
        [HttpGet]
        [Route("GetUserDetail/{id}")]
        public IEnumerable<Object> GetUserDetail(string id)
        {

            var metiers = _context.Metiers;

            List<Object> List = new List<Object>();
            //  var user =  _userManager.FindByIdAsync(id);
            //  var  user = _userManager.FindByIdAsync(id);
            foreach (var element in metiers)
            {
                if (element.UserId == id) //&& element.LabelId == model.LabelId
                {
                    DomaineDA = element.DomaineId;
                

                }
            };

            foreach (var element in metiers)
            {
                if (element.UserId == id) //&& element.LabelId == model.LabelId
                {
                    DomaineDA = element.DomaineId;
                    Userobj.labelId = element.LabelId;
                    Userobj.Niveau = element.Niveau;
                    Userobj.UserId = element.UserId;
                    //   obj.UserName = user.UserName + user.FullName;
                    List.Add(new { Userobj.labelId, Userobj.Niveau, Userobj.UserId });

                }
            };



            return List;

        }
        // je recuppere les label par Domaine delon directeur activité
        int DomaineSelecté;
        [HttpGet]
        [Route("GetLabelDA/{id}")]
        public IEnumerable<Object> GetLabelDA(string id)
        {
            List<int> ListId = new List<int>();
            List<LabelModel> List = new List<LabelModel>();
            var metiers = _context.Metiers;
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
                    DomaineSelecté = element.DomaineId;
                  

                };
            }
            foreach (var element in metiers)
            {
                if (element.DomaineId == DomaineSelecté) //&& element.LabelId == model.LabelId
                {
                  
                    ListId.Add(element.LabelId);
                   

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
        int DomaineDir=0;
        [HttpGet]
        [Route("GetDirecteurActiviteDomaine/{id}")]
        public IEnumerable<Object> GetDomanie(string id)
        {
            var metiers = _context.Metiers;
            var Domaine = _context.Domaines;
            foreach (var element in metiers)
            {
                if (element.UserId == id) //&& element.LabelId == model.LabelId
                {
                    DomaineDir = element.DomaineId;


                };
            }
            foreach (var element in Domaine)
            {

                if (element.DomaineId == DomaineDir) //&& element.LabelId == model.LabelId
                {
                   yield return element;


                };
            }
                
        }





        }
}     
        



        

// var applicationUser =  _userManager.FindByIdAsync(labele.UserId);

// var label = _context.Labels;
//  var metier = _context.Metiers;

//  foreach(var element in metier)
// {
//     yield return (element);
//    if ((element.UserId == labele.UserId) && (element.LabelId == labele.LabelId))
//  {
//      yield return (element);
//      foreach (LabelModel lab in label)
//     {

//       if (lab.LabelId == labele.LabelId)
//     {
//         yield return (lab);
//    }

// }

//  }

//   }
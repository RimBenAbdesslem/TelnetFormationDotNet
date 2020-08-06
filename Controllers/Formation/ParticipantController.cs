using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProcessusFormation.Data;
using ProcessusFormation.Models.Formation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Web.Http.OData;
using Remotion.Linq.Clauses;

namespace ProcessusFormation.Controllers.Formation
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        // private Database Database { get; set; }

        public ParticipantController(ApplicationDbContext context)
        {

            _context = context;

        }


        // ajouter un nouvelle participant
        [HttpPost]
        [Route("RegisterParticipant")]
        public async Task<IActionResult> PostParticipants(ParticipantModel model)

        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var participantss = new ParticipantModel()
            {
                Nom = model.Nom,
                Prenom = model.Prenom,

            };

            var result = await _context.ParticipantModels.AddAsync(participantss);
            _context.SaveChanges();
            return Ok(new { });


        }


        //ajouter un participant a une formation bien determiner ; id=id de la formation ; Name= name de participant
        [HttpPost]
        [Route("EditParticipantToFormation/{id}")]
        public async Task<ActionResult<Formation>> AddParticipantToFormationAsync(string id, string ParticipantId)
        {

            try
            {
                var Formation = await _context.BesoinFormationModels.FindAsync(id);

                if (Formation != null)
                {
                    Formation.ParticipantFormations = new List<ParticipantFormation>
           {
              new ParticipantFormation()
            {    BesoinFormationId=id,
                 ParticipantId = ParticipantId
           } };
                    _context.SaveChanges();



                    return Ok();

                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception e)
            {
                throw e;
            }



        }
        //get les participant de la formation d'id =id
        [HttpGet]
        [Route("GetFormationToParticipant/{id}")]
        public IEnumerable<Object> GetListePartcipant(string id)
        {
            var result = _context.BesoinFormationModels.Find(id);
            var exist = result.ParticipantFormations.Select(x => x.ParticipantId).ToList();

            return exist;


        }
        //Get all participants
        [HttpGet]
        [Route("GetAllParticipant")]
        public IEnumerable<Object> GetAllParticipants()
        {
            // if (!ModelState.IsValid)
            //   {
            //   return BadRequest(ModelState);
            //  }

            // var user = await _context.ApplicationUsers.FindAsync(id);
            // Console.WriteLine(id);
            var Participant = _context.ParticipantModels;
            if (Participant == null)
            {
                return (null);
            }

            return (Participant);
        }
       


        //tous les particpants 
        [HttpGet]
        [Route("taux_Participants")]
        public IActionResult Details()
        {

            var query = _context.ParticipantFormation
                .Join(
                _context.BesoinFormationModels,
                ParticipantFormation => ParticipantFormation.BesoinFormationId,
               
                BesoinFormationModel => BesoinFormationModel.BesoinFormationId,
            
                (ParticipantFormation, BesoinFormationModel) => new
                {
                    NombreParticipant = BesoinFormationModel.Nombre_de_participants,
                    idFormation = BesoinFormationModel.BesoinFormationId,
                    particpantPrensent = ParticipantFormation.ParticipantId,
                    titre = BesoinFormationModel.Intitule_Formation,

            
                }
               


                ).ToList();

            return Ok(query);
      }
        


    }



}



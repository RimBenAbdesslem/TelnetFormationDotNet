using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProcessusFormation.Data;
using ProcessusFormation.Models.Formation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ProcessusFormation.Controllers.Formation
{
    [Route("api/[controller]")]
    [ApiController]
    public class BesoinCollecteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public static DateTime Today { get; }
        public BesoinCollecteController(ApplicationDbContext context) {
            _context = context;
        }

        // enregistrement de besoin collecté en année
        [HttpPost]
        [Route("RegisterFormation")]
       
        public async Task<IActionResult> PostBesoinFormation(BesoinCollecteModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            var applicationUser = new BesoinCollecteModel()
            {
                Activite = model.Activite,
                Intitule_Formation = model.Intitule_Formation,
                Priorite = model.Priorite,
                Justification_du_besoin = model.Justification_du_besoin,
                Nombre_de_participants = model.Nombre_de_participants,
                Organisme_de_formation=model.Organisme_de_formation,
                Date_Debut=model.Date_Debut,
                Date_Fin=model.Date_Fin,
                type_de_formation=model.type_de_formation,
                Nombre_de_jours=model.Nombre_de_jours,
                Duree=model.Duree,
                Cout_unitaire=model.Cout_unitaire,
                Frais_de_deplacement=model.Frais_de_deplacement,
                Cout_Totale_previsionnel=model.Cout_Totale_previsionnel,
                Imputation=model.Imputation,
                Bareme_TFP=model.Bareme_TFP,
                Montant_recuperer=model.Montant_recuperer,
                nom_formateur = model.nom_formateur,


            };

            var result = await _context.BesoinCollectes.AddAsync(applicationUser);
            _context.SaveChanges();
            return Ok(new { });

        }

        //Get all Besoin
        //lien de authorisation with asp.net et angular 7 :ttps://www.youtube.com/watch?v=MGCC2zTb0t4&t=908s
        [HttpGet]
      //  [Authorize(Roles = "Formateur")]
        [Route("GetAll")]
       
        public IEnumerable<Object> GetAllBesoinCollecte()
        {

            var BesoinsCollecte = _context.BesoinCollectes;
            if (BesoinsCollecte == null)
            {
                return (null);
            }

            return (BesoinsCollecte);
        }



        //delete formateur
        [HttpDelete]
        [Route("deleteBesoinCollecte/{id}")]
        public async Task<ActionResult> deleteBesoinCollecte(string id)
        {
            var BesoinDetail = await _context.BesoinCollectes.FindAsync(id);
            if (BesoinDetail == null)
            {
                return NotFound();
            }

            _context.BesoinCollectes.Remove(BesoinDetail);
            await _context.SaveChangesAsync();

            return Ok();
        }





        //affichage de formation selon date 

        [Route("GetBesoin")]

        public IEnumerable<Object> GetBesoinCollecte()
        {
            DateTime thisDay = DateTime.Today;

            var BesoinsCollecte = _context.BesoinCollectes;

            if (BesoinsCollecte == null)
            {
                yield return(null);
            }

           
            foreach (var element in BesoinsCollecte)
            {
                if (element.Date_Fin < thisDay)
                {
                    yield return (element);

                };
            }
           
         //   return (BesoinsCollecte);
        }
    }
}
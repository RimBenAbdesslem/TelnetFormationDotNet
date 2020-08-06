using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessusFormation.Models.Formation
{
    public class BesoinCollecteModel
    {
        public string Id { get; set; }
        [Required]
        public string Activite { get; set; }
        [Required]
        public string Intitule_Formation { get; set; }
        [Required]
        public string Priorite { get; set; }
        [Required]
        public string Justification_du_besoin { get; set; }
        [Required]
        public string Nombre_de_participants { get; set; }
        [Required]
        public string Organisme_de_formation { get; set; }
        [Required]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{aaaa/mm/jj}")]
        public DateTime Date_Debut { get; set; }
        [Required]
       // [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{aaaa/mm/jj}")]
        public DateTime Date_Fin { get; set; }
        [Required]
        public string type_de_formation { get; set; }
        [Required]
        public int Nombre_de_jours { get; set; }
        [Required]
        public string Duree { get; set; }
        [Required]
        public float Cout_unitaire { get; set; }
        [Required]
        public float Frais_de_deplacement{ get; set; }
        [Required]
        public float Cout_Totale_previsionnel { get; set; }
        [Required]
        public float Imputation  { get; set; }
        [Required]
        public string Bareme_TFP { get; set; }
        [Required]
        public float Montant_recuperer { get; set; }
        public string nom_formateur { get; set; }
    }
}

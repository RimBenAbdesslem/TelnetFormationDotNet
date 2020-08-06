using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessusFormation.Models.Formation
{
    public class EtatFormationModel
    {    public int Id { get; set; }
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
        public string societe { get; set; }//société
        [Required]
        public DateTime Date_Debut { get; set; }
        [Required]
        public DateTime Date_Fin { get; set; }
        [Required]
        public string type_de_formation { get; set; }
        [Required]
        public int Nombre_de_jours { get; set; }
        [Required]
        public string Duree { get; set; }
        [Required]
        public float Coùt_unitaire { get; set; }
        [Required]
        public float Frais_de_deplacement { get; set; }
        [Required]
        public float Coùt_Totale_previsionnel { get; set; }
        [Required]
        public float Imputation { get; set; }
        [Required]
        public string Bareme_TFP { get; set; }
        [Required]
        public float Montant_recuperer { get; set; }
        [Required]
        public string Competence_visee { get; set; }
        [Required]
        public DateTime Date_EvaluationFroid { get; set; }
        [Required]
        public string Evaluation_Manquantes { get; set; }
    }
}

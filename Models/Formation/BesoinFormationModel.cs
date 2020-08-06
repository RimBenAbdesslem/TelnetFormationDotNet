using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessusFormation.Models.Formation
{
    public class BesoinFormationModel
    {
        [Column(TypeName = "nvarchar(150)")]
        [Key]
        public string BesoinFormationId { get; set; }
        public string Activite { get; set; }
        public string Intitule_Formation { get; set; }
        public string FormationType { get; set; }
        public string Priorite { get;  set; }
        public string Justification_du_besoin { get; set; }
        public string Nombre_de_participants { get; set; }
        public string Organisme_de_formation { get; set; }
        public DateTime Date_Debut { get; set; }
        public DateTime Date_Fin { get; set; }
        public string type_de_formation { get; set; }
        public int Nombre_de_jours { get; set; }
        public string Duree { get; set; }
        public float Cout_unitaire { get; set; }
        public float Frais_de_deplacement { get; set; }
        public float Cout_Totale_previsionnel { get; set; }
        public float Imputation { get; set; }
        public string Bareme_TFP { get; set; }
        public float Montant_recuperer { get; set; }
        public string nom_formateur { get; set; }

        public List<ParticipantFormation> ParticipantFormations { get; set; }
        public List<ParticipantToFormationModel> ParticipantToFormations { get; set; } = new List<ParticipantToFormationModel>();


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessusFormation.Models.Formation
{
    public class SuiviFormationModel
    {
        public int Id { get; set; }
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
        public string Nombre_Table { get; set; }//société
    }
}

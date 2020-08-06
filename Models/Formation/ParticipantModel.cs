using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessusFormation.Models.Formation
{
    public class ParticipantModel
    {
        [Column(TypeName = "nvarchar(150)")]
        [Key]
        public string ParticipantId { get; set; }
    
        public string Nom { get; set; }
        [Required]
        public string Prenom { get; set; }
     
        public List<ParticipantFormation> ParticipantFormations { get; set; } = new List<ParticipantFormation>();
        public IEnumerable<ParticipantFormation> BesoinFormationModel { get; internal set; }
    }
}

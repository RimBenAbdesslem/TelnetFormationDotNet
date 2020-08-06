using Microsoft.AspNetCore.Identity;
using ProcessusFormation.Models.Formation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessusFormation.Models
{
    public class ApplicationUser: IdentityUser
    {
        [Column(TypeName = "nvarchar(150)")]
        public string FullName { get; set; }
        public string Valide { get; set; }
        public string Role { get; internal set; }
        public List<ParticipantToFormationModel> ParticipantToFormations { get; set; }
        //public string Role { get; set; }
        // public IList<string> Roles { get; internal set; }

        public List<ParticipantFormation> ParticipantFormations { get; set; } = new List<ParticipantFormation>();
        public IEnumerable<ParticipantFormation> BesoinFormationModel { get; internal set; }
    }
 
} 
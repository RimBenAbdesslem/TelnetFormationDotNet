using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessusFormation.Models.Formation
{
    public class ParticipantFormation  
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }


        public string ParticipantId { get; set; }
        public ApplicationUser ParticipantModel { get; set; }

        public string BesoinFormationId { get; set; }
        public BesoinFormationModel BesoinFormationModel { get; set; }
    }
}

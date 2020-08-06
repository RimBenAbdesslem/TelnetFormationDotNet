using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessusFormation.Models.Compétence
{
    public class MetierModel
    {
        [Key]
        public int MetierId { get; set; }
        public int DomaineId { get; set; }
        public string UserId { get; set; }
        public int LabelId { get; set; }
        public int Niveau { get; set; }
    }
}

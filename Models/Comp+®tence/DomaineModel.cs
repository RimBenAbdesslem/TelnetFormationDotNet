using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessusFormation.Models.Compétence
{
    public class DomaineModel
    {
        [Key]
        public int DomaineId { get; set; }
        public string NomDomaine { get; set; }
        //domaine have a liste of label 
        public  ICollection<LabelModel> Labels { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessusFormation.Models.Compétence
{
    public class LabelModel
    {    [Key]
        public int LabelId { get; set; }
        public string NomLabel { get; set; }
        public int Niveau { get; set; }
        public int DomaineId { get; set; }
        //label have a juste one domaine(single instance of domaine)
        public  DomaineModel Domaines { get; set; }
    }
}

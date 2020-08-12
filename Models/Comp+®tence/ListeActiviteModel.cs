using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessusFormation.Models.Comp__tence
{
    public class ListeActiviteModel
    {
        [Key]
        public int ListActivId { get; set; }
        public int ActiviteId { get; set; }
        public int DomaineId { get; set; }
        public int LabelId { get; set; }
        public string NomLabel { get; set; }
        public string NomActivite { get; set; }
        public string NomDomaine { get; set; }
    }
}

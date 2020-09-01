using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessusFormation.Models.Evaluation
{
    public class EvaluationFournisseurModel
    {[Key]
        public int Id { get; set; }
        public string Nom_Fournisseur { get; set; }
        public string Categorie { get; set; }
        public string Conformite { get; set; }
        public DateTime Date_Evaluation { get; set; }
        public string Semestre { get; set; }
        public int Totale_evaluation { get; set; }
    }
}

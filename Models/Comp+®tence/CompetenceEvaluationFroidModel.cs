using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessusFormation.Models.Compétence
{
    public class CompetenceEvaluationFroidModel
    {
        public int Id { get; set; }
        public int IdEvaluation { get; set; }
        public string Competence { get; set; }
        public int Niveau_actuel { get; set; }
        public string Degre { get; set; }
        public int Niveau_acquis { get; set; }
        public string Critere10 { get; set; }//

    }
}

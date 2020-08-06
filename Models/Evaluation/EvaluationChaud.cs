using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessusFormation.Models.Evaluation
{
    public class EvaluationChaud
    {
        public int Id { get; set; }
        public string Theme { get; set; }
        public string Lieu { get; set; }
        public string Organisme { get; set; }
        public string Formateur { get; set; }
        public DateTime Date_Evaluation_Chaud { get; set; }
        public DateTime Date_DebutFormation { get; set; }
        public DateTime Date_FinFormation { get; set; }
        public string Nom_Participant { get; set; }
        public string Prenom_Participant { get; set; }
        public string Matricule { get; set; }
        public string Fonction { get; set; }
        public string Direction { get; set; }
        public string QuestionA { get; set; }
        public string Lequelles { get; set; }
        public string PourqouiA { get; set; }
        public string PourqouiB { get; set; }
        public string QuestionB { get; set; }
        public string Comment{ get; set; }
        public string QuestionC { get; set; }

        public int Score_Evaluation { get; set; }
        public int Score_Satisfaction { get; set; }
        public string Commentaire1 { get; set; }
        public string Commentaire2 { get; set; }
        public string Commentaire3 { get; set; }

    }
}

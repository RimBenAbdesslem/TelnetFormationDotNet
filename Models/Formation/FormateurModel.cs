using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessusFormation.Models.Formation
{
    public class FormateurModel
    {
        public int Id { get; set; }
        public string Theme { get; set; }
        public string Organisme_prestataire { get; set; }
        public string Nom_Formateur { get; set; }
        public string Period { get; set; }
        public int Score { get; set; }


    }
}

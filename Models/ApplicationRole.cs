    using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessusFormation.Models
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole()
        {
            Roles = new List<string>();
        }
        public string Access { get; set; }
        public int id { get; set; }
       
        public string RoleName { get; set; }
        [Required]
        public IList<string> Roles { get; internal set; }
    }
}

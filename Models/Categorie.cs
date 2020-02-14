using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FilActualite.Models
{
    public class Categorie
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Nom")]
        public string Nom { get; set; }
        public ICollection<ApplicationUser> User { get; set; }
    }
    
}
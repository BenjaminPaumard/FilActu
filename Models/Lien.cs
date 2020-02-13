using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FilActualite.Models
{
    public class Lien
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Adresse")]
        public string Adrs { get; set; }
        public Guid CategorieId { get; set; }
        public Categorie Categorie { get; set; }
    }
}
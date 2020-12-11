using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace Website_Project_Agile.Models
{
    public class Category
    {
        public int id { get; set; }
        [Display(Name = "Naam categorie")]
        [Required] public string Name { get; set; }
        [Display(Name = "Locatie categorie")]
        [Required] public int LocationId { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}

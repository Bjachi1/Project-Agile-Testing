using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Website_Project_Agile.Models
{
    public class Favorite
    {
        public int id { get; set; }
        [Display(Name = "Gebruiker ID")]
        [Required] public string User_id { get; set; }
        [Display(Name = "Product ID")]
        [Required] public int product_id { get; set; }
        [ForeignKey("product_id")] public Product Product { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Website_Project_Agile.Areas.Identity.Data;

namespace Website_Project_Agile.Models
{
    public class ShoppingList
    {
        public int id { get; set; }
        [Required] public string Customer_id { get; set; }
        [Display(Name = "Naam winkellijst")]

        [Required] public string Name { get; set; }
        [ForeignKey("Customer_id")] public ApplicationUser user { get; set; }
        public ICollection<Shoppinglist_Product> ShoppinglistProducts { get; set; }
    }
}

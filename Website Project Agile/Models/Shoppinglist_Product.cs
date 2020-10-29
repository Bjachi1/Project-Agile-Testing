using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.Operations;

namespace Website_Project_Agile.Models
{
    public class Shoppinglist_Product
    {
        public int id { get; set; }
        public int Shoppinglist_id { get; set; }
         public int Product_id { get; set; }
        [ForeignKey("Shoppinglist_id")] public ShoppingList ShoppingList { get; set; }
        [ForeignKey("Product_id")] public Product Product { get; set; }
    }
}

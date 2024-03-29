﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Website_Project_Agile.Models
{
    public class Product
    {
        [Required] public int Id { get; set; }
        [Display(Name = "Naam Product")]
        [Required] public string Name { get; set; }
        [Display(Name = "Beschrijving Product")]
        [Required] public string Description { get; set; }
        [Display(Name = "Prijs")]
        [Required] public double Price { get; set; }

        [Required] public int Category_id { get; set; }
        [ForeignKey("Category_id")] public Category Category { get; set; }
        public ICollection<Favorite> Favorites { get; set; }
        public ICollection<Shoppinglist_Product> ShoppinglistProducts { get; set; }
    }
}

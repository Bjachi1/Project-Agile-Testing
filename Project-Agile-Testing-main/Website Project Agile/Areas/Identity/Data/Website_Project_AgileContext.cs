using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Website_Project_Agile.Areas.Identity.Data;
using Website_Project_Agile.Models;

namespace Website_Project_Agile.Data
{
    public class Website_Project_AgileContext : IdentityDbContext<ApplicationUser>
    {
        public Website_Project_AgileContext(DbContextOptions<Website_Project_AgileContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Category>().ToTable("Categories");
            builder.Entity<Favorite>().ToTable("Favorites");
            builder.Entity<Product>().ToTable("Products");
            builder.Entity<ShoppingList>().ToTable("Shoppinglists");
            builder.Entity<Shoppinglist_Product>().ToTable("Shoppinglist_Product").HasOne(x=>x.Product).WithMany(x=>x.ShoppinglistProducts).OnDelete(DeleteBehavior.NoAction); 
            //miss moet dit ook voor de shopping list gedaan worden zodat hij de shoppinglist niet delete als je een product delete.
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingList> ShoppingLists { get; set; }
        public DbSet<Shoppinglist_Product> ShoppinglistProducts { get; set; }
    }
}

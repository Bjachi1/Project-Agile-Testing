using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Website_Project_Agile.Models;

namespace Website_Project_Agile.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public int? Favorite_id { get; set; }
        [ForeignKey("Favorite_id")] public Favorite Favorite { get; set; }
    }
}

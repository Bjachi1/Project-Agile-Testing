using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Website_Project_Agile.ViewModel
{
    public class ShoppingListViewModel
    {
        public string Name { get; set; }
        public List<ProductViewModel> Products { get; set; }
        public int id { get; set; }
    }
}

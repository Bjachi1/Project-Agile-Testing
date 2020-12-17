using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Website_Project_Agile.Areas.Identity.Data;
using Website_Project_Agile.Data;
using Website_Project_Agile.Models;
using Website_Project_Agile.ViewModel;

namespace Website_Project_Agile.Controllers
{
    public class ShoppingListsController : Controller
    {
        private readonly Website_Project_AgileContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ShoppingListsController(Website_Project_AgileContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: ShoppingLists
        public async Task<IActionResult> Index()
        {
            var website_Project_AgileContext = _context.ShoppingLists.Include(s => s.user).Include(c=>c.ShoppinglistProducts).Where(x=>x.Customer_id == _userManager.GetUserId(User));
            return View(await website_Project_AgileContext.ToListAsync());
        }

        // GET: ShoppingLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppingList = await _context.ShoppingLists
                .Include(s => s.user).Include(x=>x.ShoppinglistProducts).ThenInclude(c=>c.Product).ThenInclude(w=>w.Category)
                .FirstOrDefaultAsync(m => m.id == id);

            ShoppingListViewModel viewModel = new ShoppingListViewModel();
            viewModel.Name = shoppingList.Name;
            viewModel.id = shoppingList.id;
            viewModel.Products = new List<ProductViewModel>();
            foreach (var item in shoppingList.ShoppinglistProducts)
            {
                ProductViewModel product = new ProductViewModel();
                product.Name = item.Product.Name;
                product.Amount = item.Amount;
                product.Id = item.id;
                product.LocationId = item.Product.Category.LocationId;
                viewModel.Products.Add(product);
            }


            return View(viewModel);
        }

        // GET: ShoppingLists/Create
        public IActionResult Create()
        {
            ViewData["Customer_id"] = new SelectList(_context.Users, "Id","Id", _userManager.GetUserId(User));
            return View();
        }

        // POST: ShoppingLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Customer_id,Name")] ShoppingList shoppingList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shoppingList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Customer_id"] = new SelectList(_context.Users, "Id", "Id", shoppingList.Customer_id);
            return View(shoppingList);
        }

        // GET: ShoppingLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppingList = await _context.ShoppingLists.FindAsync(id);
            if (shoppingList == null)
            {
                return NotFound();
            }
            ViewData["Customer_id"] = new SelectList(_context.Users, "Id", "Id", shoppingList.Customer_id);
            return View(shoppingList);
        }

        // POST: ShoppingLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Customer_id,Name")] ShoppingList shoppingList)
        {
            if (id != shoppingList.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shoppingList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShoppingListExists(shoppingList.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Customer_id"] = new SelectList(_context.Users, "Id", "Id", shoppingList.Customer_id);
            return View(shoppingList);
        }

        // GET: ShoppingLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppingList = await _context.ShoppingLists
                .Include(s => s.user)
                .FirstOrDefaultAsync(m => m.id == id);
            if (shoppingList == null)
            {
                return NotFound();
            }

            return View(shoppingList);
        }

        // POST: ShoppingLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shoppingList = await _context.ShoppingLists.FindAsync(id);
            _context.ShoppingLists.Remove(shoppingList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShoppingListExists(int id)
        {
            return _context.ShoppingLists.Any(e => e.id == id);
        }
    }
}

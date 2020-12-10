using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Website_Project_Agile.Data;
using Website_Project_Agile.Models;

namespace Website_Project_Agile.Controllers
{
    public class Shoppinglist_ProductController : Controller
    {
        private readonly Website_Project_AgileContext _context;

        public Shoppinglist_ProductController(Website_Project_AgileContext context)
        {
            _context = context;
        }

        // GET: Shoppinglist_Product
        public async Task<IActionResult> Index()
        {
            var website_Project_AgileContext = _context.ShoppinglistProducts.Include(s => s.Product).Include(s => s.ShoppingList);
            return Redirect("/ShoppingLists");
        }

        // GET: Shoppinglist_Product/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppinglist_Product = await _context.ShoppinglistProducts
                .Include(s => s.Product)
                .Include(s => s.ShoppingList)
                .FirstOrDefaultAsync(m => m.id == id);
            if (shoppinglist_Product == null)
            {
                return NotFound();
            }

            return View(shoppinglist_Product);
        }

        // GET: Shoppinglist_Product/Create
        public IActionResult Create(int? idShoppingList)
        {
            ViewData["Product_id"] = new SelectList(_context.Products, "Id", "Description");
            ViewData["Shoppinglist_id"] = new SelectList(_context.ShoppingLists, "id", "Customer_id", idShoppingList);
            return View();
        }

        // POST: Shoppinglist_Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Shoppinglist_id,Product_id,Amount")] Shoppinglist_Product shoppinglist_Product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shoppinglist_Product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Product_id"] = new SelectList(_context.Products, "Id", "Description", shoppinglist_Product.Product_id);
            ViewData["Shoppinglist_id"] = new SelectList(_context.ShoppingLists, "id", "Customer_id", shoppinglist_Product.Shoppinglist_id);
            return Redirect("/ShoppingLists");
        }

        // GET: Shoppinglist_Product/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppinglist_Product = await _context.ShoppinglistProducts.FindAsync(id);
            if (shoppinglist_Product == null)
            {
                return NotFound();
            }
            ViewData["Product_id"] = new SelectList(_context.Products, "Id", "Description", shoppinglist_Product.Product_id);
            ViewData["Shoppinglist_id"] = new SelectList(_context.ShoppingLists, "id", "Customer_id", shoppinglist_Product.Shoppinglist_id);
            return View(shoppinglist_Product);
        }

        // POST: Shoppinglist_Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Shoppinglist_id,Product_id,Amount")] Shoppinglist_Product shoppinglist_Product)
        {
            if (id != shoppinglist_Product.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shoppinglist_Product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Shoppinglist_ProductExists(shoppinglist_Product.id))
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
            ViewData["Product_id"] = new SelectList(_context.Products, "Id", "Description", shoppinglist_Product.Product_id);
            ViewData["Shoppinglist_id"] = new SelectList(_context.ShoppingLists, "id", "Customer_id", shoppinglist_Product.Shoppinglist_id);
            return View(shoppinglist_Product);
        }

        // GET: Shoppinglist_Product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppinglist_Product = await _context.ShoppinglistProducts
                .Include(s => s.Product)
                .Include(s => s.ShoppingList)
                .FirstOrDefaultAsync(m => m.id == id);
            if (shoppinglist_Product == null)
            {
                return NotFound();
            }

            return View(shoppinglist_Product);
        }

        // POST: Shoppinglist_Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shoppinglist_Product = await _context.ShoppinglistProducts.FindAsync(id);
            _context.ShoppinglistProducts.Remove(shoppinglist_Product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Shoppinglist_ProductExists(int id)
        {
            return _context.ShoppinglistProducts.Any(e => e.id == id);
        }
    }
}

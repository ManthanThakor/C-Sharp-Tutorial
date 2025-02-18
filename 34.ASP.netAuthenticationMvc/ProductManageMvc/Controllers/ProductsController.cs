using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductManageMvc.Data;
using ProductManageMvc.Models.Entity;

namespace ProductManageMvc.Controllers
{

    public class ProductsController : Controller
    {
        private readonly ProductManageMvcContext _context;

        public ProductsController(ProductManageMvcContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.Include(p => p.Category).ToListAsync();
            return View(products);
        }

        public async Task<IActionResult> CreateOrEdit(int? id)
        {
            ViewData["Categories"] = await _context.ProductCategories.ToListAsync();

            if (id == null)
            {
                return View(new Product());
            }

            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit(int? id, [Bind("Id,Name,Price,CategoryId")] Product product)
        {
            if (id != null && id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (id == null)
                {
                    _context.Add(product);
                }
                else
                {
                    try
                    {
                        _context.Update(product);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!_context.Products.Any(e => e.Id == product.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Categories"] = await _context.ProductCategories.ToListAsync();

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}

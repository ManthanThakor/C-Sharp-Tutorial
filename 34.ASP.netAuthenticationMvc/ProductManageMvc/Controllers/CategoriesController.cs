using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductManageMvc.Data;
using ProductManageMvc.Models.Entity;

namespace ProductManageMvc.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ProductManageMvcContext _context;

        public CategoriesController(ProductManageMvcContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _context.ProductCategories.ToListAsync();

            return View(categories);
        }

        public async Task<IActionResult> CreateOrEdit(int? id)
        {
            if (id == null)
            {
                return View(new ProductCategory());
            }

            var category = await _context.ProductCategories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit(int? id, [Bind("Id,Name")] ProductCategory category)
        {
            if (id != null && id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (id == null)
                {
                    _context.Add(category);
                }
                else
                {
                    try
                    {
                        _context.Update(category);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!_context.ProductCategories.Any(e => e.Id == category.Id))
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
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.ProductCategories.FindAsync(id);

            if (category != null)
            {
                var products = _context.Products.Where(p => p.CategoryId == id);
                _context.Products.RemoveRange(products);

                _context.ProductCategories.Remove(category);

                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }


    }
}

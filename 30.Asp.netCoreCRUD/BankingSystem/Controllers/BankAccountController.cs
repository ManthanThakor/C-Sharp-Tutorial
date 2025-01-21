using BankingSystem.Data;
using BankingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Controllers
{
    public class BankAccountController : Controller
    {
        private readonly BankingDbContext _context;

        public BankAccountController(BankingDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return PartialView("_CreateEditModal", new BankAccount());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromBody] BankAccount model)
        {
            if (ModelState.IsValid)
            {
                _context.Add(model);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Bank Account created successfully." });
            }
            return Json(new { success = false, message = "Failed to create the Bank Account." });
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bankAccount = await _context.BankAccounts.FindAsync(id);
            if (bankAccount == null)
            {
                return NotFound();
            }
            return PartialView("_CreateEditModal", bankAccount);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromBody] BankAccount model)
        {
            if (id != model.AccountId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                    return Json(new { success = true, message = "Bank Account updated successfully." });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BankAccountExists(model.AccountId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return Json(new { success = false, message = "Failed to update the Bank Account." });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var bankAccount = await _context.BankAccounts.FindAsync(id);
            if (bankAccount != null)
            {
                _context.BankAccounts.Remove(bankAccount);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Bank Account deleted successfully." });
            }
            return Json(new { success = false, message = "Failed to delete the Bank Account." });
        }

        private bool BankAccountExists(int id)
        {
            return _context.BankAccounts.Any(e => e.AccountId == id);
        }
    }
}

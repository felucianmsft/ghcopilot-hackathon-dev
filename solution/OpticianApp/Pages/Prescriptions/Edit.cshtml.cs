using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OpticianApp.Models;

namespace OpticianApp.Pages.OpticalPrescriptions
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public OpticalPrescription OpticalPrescription { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opticalprescription =  await _context.OpticalPrescription.FirstOrDefaultAsync(m => m.ID == id);
            if (opticalprescription == null)
            {
                return NotFound();
            }
            OpticalPrescription = opticalprescription;
           ViewData["CustomerId"] = new SelectList(_context.Customer, "ID", "FullName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(OpticalPrescription).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OpticalPrescriptionExists(OpticalPrescription.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool OpticalPrescriptionExists(int id)
        {
            return _context.OpticalPrescription.Any(e => e.ID == id);
        }
    }
}

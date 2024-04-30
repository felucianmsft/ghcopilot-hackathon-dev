using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OpticianApp.Models;

namespace OpticianApp.Pages.OpticalPrescriptions
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
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

            var opticalprescription = await _context.OpticalPrescription.FirstOrDefaultAsync(m => m.ID == id);

            if (opticalprescription == null)
            {
                return NotFound();
            }
            else
            {
                OpticalPrescription = opticalprescription;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opticalprescription = await _context.OpticalPrescription.FindAsync(id);
            if (opticalprescription != null)
            {
                OpticalPrescription = opticalprescription;
                _context.OpticalPrescription.Remove(OpticalPrescription);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

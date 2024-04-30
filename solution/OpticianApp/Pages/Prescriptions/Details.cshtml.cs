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
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}

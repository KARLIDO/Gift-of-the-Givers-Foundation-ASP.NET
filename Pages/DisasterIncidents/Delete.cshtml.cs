using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Gift_of_the_Givers_Foundation.Data;
using Gift_of_the_Givers_Foundation.Models;

namespace Gift_of_the_Givers_Foundation.Pages.DisasterIncidents
{
    public class DeleteModel : PageModel
    {
        private readonly Gift_of_the_Givers_Foundation.Data.ApplicationDbContext _context;

        public DeleteModel(Gift_of_the_Givers_Foundation.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DisasterIncident DisasterIncident { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disasterincident = await _context.DisasterIncident.FirstOrDefaultAsync(m => m.Id == id);

            if (disasterincident == null)
            {
                return NotFound();
            }
            else
            {
                DisasterIncident = disasterincident;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disasterincident = await _context.DisasterIncident.FindAsync(id);
            if (disasterincident != null)
            {
                DisasterIncident = disasterincident;
                _context.DisasterIncident.Remove(DisasterIncident);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gift_of_the_Givers_Foundation.Data;
using Gift_of_the_Givers_Foundation.Models;

namespace Gift_of_the_Givers_Foundation.Pages.DisasterIncidents
{
    public class EditModel : PageModel
    {
        private readonly Gift_of_the_Givers_Foundation.Data.ApplicationDbContext _context;

        public EditModel(Gift_of_the_Givers_Foundation.Data.ApplicationDbContext context)
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

            var disasterincident =  await _context.DisasterIncident.FirstOrDefaultAsync(m => m.Id == id);
            if (disasterincident == null)
            {
                return NotFound();
            }
            DisasterIncident = disasterincident;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(DisasterIncident).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DisasterIncidentExists(DisasterIncident.Id))
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

        private bool DisasterIncidentExists(int id)
        {
            return _context.DisasterIncident.Any(e => e.Id == id);
        }
    }
}

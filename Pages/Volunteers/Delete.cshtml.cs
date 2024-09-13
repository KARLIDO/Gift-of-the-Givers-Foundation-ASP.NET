using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Gift_of_the_Givers_Foundation.Data;
using Gift_of_the_Givers_Foundation.Models;

namespace Gift_of_the_Givers_Foundation.Pages.Volunteers
{
    public class DeleteModel : PageModel
    {
        private readonly Gift_of_the_Givers_Foundation.Data.ApplicationDbContext _context;

        public DeleteModel(Gift_of_the_Givers_Foundation.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Volunteer Volunteer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var volunteer = await _context.Volunteer.FirstOrDefaultAsync(m => m.Id == id);

            if (volunteer == null)
            {
                return NotFound();
            }
            else
            {
                Volunteer = volunteer;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var volunteer = await _context.Volunteer.FindAsync(id);
            if (volunteer != null)
            {
                Volunteer = volunteer;
                _context.Volunteer.Remove(Volunteer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

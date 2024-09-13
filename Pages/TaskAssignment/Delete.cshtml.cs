using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Gift_of_the_Givers_Foundation.Data;
using Gift_of_the_Givers_Foundation.Models;

namespace Gift_of_the_Givers_Foundation.Pages.TaskAssignment
{
    public class DeleteModel : PageModel
    {
        private readonly Gift_of_the_Givers_Foundation.Data.ApplicationDbContext _context;

        public DeleteModel(Gift_of_the_Givers_Foundation.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Gift_of_the_Givers_Foundation.Models.TaskAssignment TaskAssignment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskassignment = await _context.TaskAssignment.FirstOrDefaultAsync(m => m.Id == id);

            if (taskassignment == null)
            {
                return NotFound();
            }
            else
            {
                TaskAssignment = taskassignment;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskassignment = await _context.TaskAssignment.FindAsync(id);
            if (taskassignment != null)
            {
                TaskAssignment = taskassignment;
                _context.TaskAssignment.Remove(TaskAssignment);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

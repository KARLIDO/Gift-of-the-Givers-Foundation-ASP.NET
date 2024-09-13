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

namespace Gift_of_the_Givers_Foundation.Pages.TaskAssignment
{
    public class EditModel : PageModel
    {
        private readonly Gift_of_the_Givers_Foundation.Data.ApplicationDbContext _context;

        public EditModel(Gift_of_the_Givers_Foundation.Data.ApplicationDbContext context)
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

            var taskassignment =  await _context.TaskAssignment.FirstOrDefaultAsync(m => m.Id == id);
            if (taskassignment == null)
            {
                return NotFound();
            }
            TaskAssignment = taskassignment;
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

            _context.Attach(TaskAssignment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskAssignmentExists(TaskAssignment.Id))
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

        private bool TaskAssignmentExists(int id)
        {
            return _context.TaskAssignment.Any(e => e.Id == id);
        }
    }
}

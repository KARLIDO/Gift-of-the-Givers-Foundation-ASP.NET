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
    public class DetailsModel : PageModel
    {
        private readonly Gift_of_the_Givers_Foundation.Data.ApplicationDbContext _context;

        public DetailsModel(Gift_of_the_Givers_Foundation.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}

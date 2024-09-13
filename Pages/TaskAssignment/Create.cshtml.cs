using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Gift_of_the_Givers_Foundation.Data;
using Gift_of_the_Givers_Foundation.Models;

namespace Gift_of_the_Givers_Foundation.Pages.TaskAssignment
{
    public class CreateModel : PageModel
    {
        private readonly Gift_of_the_Givers_Foundation.Data.ApplicationDbContext _context;

        public CreateModel(Gift_of_the_Givers_Foundation.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Gift_of_the_Givers_Foundation.Models.TaskAssignment TaskAssignment { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TaskAssignment.Add(TaskAssignment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

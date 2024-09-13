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
    public class IndexModel : PageModel
    {
        private readonly Gift_of_the_Givers_Foundation.Data.ApplicationDbContext _context;

        public IndexModel(Gift_of_the_Givers_Foundation.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Gift_of_the_Givers_Foundation.Models.TaskAssignment> TaskAssignment { get; set; } = default!;


        public async Task OnGetAsync()
        {
            TaskAssignment = await _context.TaskAssignment.ToListAsync();
        }
    }
}

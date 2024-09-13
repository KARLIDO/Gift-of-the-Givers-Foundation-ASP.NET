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
    public class IndexModel : PageModel
    {
        private readonly Gift_of_the_Givers_Foundation.Data.ApplicationDbContext _context;

        public IndexModel(Gift_of_the_Givers_Foundation.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Volunteer> Volunteer { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Volunteer = await _context.Volunteer.ToListAsync();
        }
    }
}

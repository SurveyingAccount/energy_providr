using energy_providr.Data;
using energy_providr.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace energy_providr.Pages
{
    public class Index1Model : PageModel
    {
        private readonly dtabaseContext _context;

        public Index1Model(dtabaseContext context)
        {
            _context = context;
        }

        // Holds the blog post that matches the requested ID
        public Blogs? Blog { get; set; }

        // OnGet method to fetch the correct blog based on ID
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Blog = await _context.Blogs.FirstOrDefaultAsync(b => b.Id == id);

            if (Blog == null)
            {
                return NotFound(); // Return 404 if no blog is found
            }

            return Page();
        }
    }
}

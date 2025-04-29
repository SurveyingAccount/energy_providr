using energy_providr.Data;
using energy_providr.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace energy_providr.Pages
{
    public class BlogChoiceModel(dtabaseContext context) : PageModel
    {
        private readonly dtabaseContext _context = context;

        public required IList<Blogs> Blogs { get; set; }
        public void OnGet()
        {
            Blogs = _context.Blogs.ToList();
        }
    }
}

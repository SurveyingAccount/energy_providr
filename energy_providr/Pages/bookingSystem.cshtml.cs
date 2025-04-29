using energy_providr.Data;
using energy_providr.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace energy_providr.Pages
{
    public class bookingSystemModel(dtabaseContext context) : PageModel
    {
        // Correctly name the context variable
        private readonly dtabaseContext _context = context;

        public required IList<Booking> Booking { get; set; }

        // OnGet method to retrieve the data
        public void OnGet()
        {
            
        }
    }
}

using energy_providr.Data;
using energy_providr.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace energy_providr.Pages
{
    public class SignUpModel(dtabaseContext context) : PageModel
    {
        private readonly dtabaseContext _context = context;

        // Properties to bind to the form inputs
        [BindProperty]
        public required string Username { get; set; }

        [BindProperty]
        public required string Password { get; set; }

        [BindProperty]
        public required string Email { get; set; }

        [BindProperty]
        public required string Address { get; set; }

        public required string ErrorMessage { get; set; }

        // OnGet doesn't need to do anything special for now
        public void OnGet()
        {
        }

        // OnPost to handle the form submission
        public async Task<IActionResult> OnPostAsync()
        {
            // Check if the user already exists (optional)
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Username == Username || u.Email == Email);
            if (existingUser != null)
            {
                ErrorMessage = "User already exists with this username or email.";
                return Page(); // Return to the page with error message
            }

            // Create a new login_details object to add to the database
            var newUser = new login_details
            {
                Username = Username,
                Password = Password,  // Consider hashing the password before storing!
                Email = Email
            };

            // Add the new user to the database
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            // Redirect to the login page after successful registration
            return RedirectToPage("/Login");
        }
    }
}

using energy_providr.Data;
using energy_providr.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace energy_providr.Pages
{
    public class loginModel(dtabaseContext context) : PageModel
    {
        private readonly dtabaseContext _context = context;

        [BindProperty]
        public required string Username { get; set; }

        [BindProperty]
        public required string Password { get; set; }
        public required string ErrorMessage { get; set; }

        public IActionResult OnPost()
        {
            // Check for matching user
            var user = _context.Users
                .FirstOrDefault(u => u.Username == Username && u.Password == Password);

            if (user != null)
            {
                // Create claims and sign the user in
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Email, user.Email)
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                // Sign the user in (store in a cookie)
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                // Redirect to home page after successful login
                return RedirectToPage("/Index");
            }
            else
            {
                // Show error message if credentials are incorrect
                ErrorMessage = "Invalid username or password.";
                return Page();
            }
        }
    }
}

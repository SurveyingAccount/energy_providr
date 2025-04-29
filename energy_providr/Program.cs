using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using energy_providr.Data;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Get connection string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrEmpty(connectionString))
    throw new InvalidOperationException("Database connection string is missing in appsettings.json.");

// Register DbContext with MySQL
builder.Services.AddDbContext<dtabaseContext>(options =>
    options.UseMySQL(connectionString));

// ✅ Add Cookie Authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/login"; // Path to the login page
        options.LogoutPath = "/logout"; // Path for the logout action
    });

// Add Razor Pages and other services
builder.Services.AddRazorPages();

var app = builder.Build();

// Middleware configuration
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// ✅ Use Authentication and Authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

// Map POST logout endpoint
app.MapPost("/logout", async context =>
{
    await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme); // Logout logic
    context.Response.Redirect("/"); // Redirect after logout
});

app.Run();

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AskeOgViktorProjekt.Data;
using AskeOgViktorProjekt.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
namespace AskeOgViktorProjekt.Areas.Identity.Pages.Account;

public class LoginModel : PageModel
{
    private readonly AppDbContext _context;
    private readonly ILogger<LoginModel> _logger;

    // 1. Input Model - match the form which uses `NewUser` fields
    [BindProperty]
    public User NewUser { get; set; } = new User();

    // 2. Inject AppDbContext
    public LoginModel(AppDbContext context, ILogger<LoginModel> logger)
    {
        _context = context;
        _logger = logger;
    }

    // 3. POST handler: validate input against the database
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var name = NewUser.Name?.Trim() ?? string.Empty;
        var password = NewUser.Password ?? string.Empty;

        _logger.LogInformation("Login attempt for user '{Name}'", name);

        var matched = await _context.ValidateUserAsync(name, password);

        if (matched == null)
        {
            _logger.LogInformation("Login failed for user '{Name}'", name);
            ModelState.AddModelError(string.Empty, "Invalid username or password.");
            return Page();
        }

        _logger.LogInformation("Login succeeded for user '{Name}' (Id: {Id})", matched.Name, matched.Id);

        // Create user claims and sign in with cookie authentication
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, matched.Id.ToString()),
            new Claim(ClaimTypes.Name, matched.Name)
        };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,
            new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddHours(8)
            });

        TempData["Message"] = $"Welcome, {matched.Name}!";
        return RedirectToPage("/Index");
    }
}
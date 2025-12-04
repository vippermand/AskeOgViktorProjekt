using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AskeOgViktorProjekt.Data;
using AskeOgViktorProjekt.Models;
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

        _logger.LogInformation("Login attempt for user '{Name}'", NewUser.Name);

        var matched = await _context.ValidateUserAsync(NewUser.Name, NewUser.Password);

        if (matched == null)
        {
            _logger.LogInformation("Login failed for user '{Name}'", NewUser.Name);
            ModelState.AddModelError(string.Empty, "Invalid username or password.");
            return Page();
        }

        _logger.LogInformation("Login succeeded for user '{Name}' (Id: {Id})", matched.Name, matched.Id);

        // Login succeeded. For now redirect to Index and set a TempData message.
        TempData["Message"] = $"Welcome, {matched.Name}!";
        return RedirectToPage("/Index");
    }
}
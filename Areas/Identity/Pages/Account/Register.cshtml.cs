using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AskeOgViktorProjekt.Data;
using AskeOgViktorProjekt.Models;

namespace AskeOgViktorProjekt.Areas.Identity.Pages.Account;

public class RegisterModel : PageModel
{
    private readonly AppDbContext _context;

    [BindProperty]
    public User NewUser { get; set; } = new User();

    public RegisterModel(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        // Add user to database
        _context.Users.Add(NewUser);
        await _context.SaveChangesAsync();

        TempData["Message"] = "Registration successful. You can now log in.";
        return RedirectToPage("/Index");
    }
}

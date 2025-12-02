using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AskeOgViktorProjekt.Data;
using AskeOgViktorProjekt.Models;
namespace AskeOgViktorProjekt.Pages;


public class IndexModel : PageModel
{
private readonly AppDbContext _context;
       
        // 1. Input Model
        [BindProperty]
        public User NewUser { get; set; } = default!;


        // 2. Inject AppDbContext
        public IndexModel(AppDbContext context)
        {
            _context = context;
        }


        public void OnGet()
        {
        }


        // 3. Handle Form Submission
        public async Task<IActionResult> OnPostAsync()
        {
            // Check validation rules (e.g., [Required] attributes on User model)
            if (!ModelState.IsValid)
            {
                return Page(); // If validation fails, redisplay the page
            }
           
            // 4. Add the new User object to the database context
            _context.Users.Add(NewUser);
           
            // 5. Save changes asynchronously to the SQLite database
            await _context.SaveChangesAsync();


            // Redirect to a success page or the home page
            return RedirectToPage("/Index");
        }
}

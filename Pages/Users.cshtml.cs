using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AskeOgViktorProjekt.Data;
using AskeOgViktorProjekt.Models;





namespace AskeOgViktorProjekt.Pages
{
    public class UsersModel : PageModel
    {
        private readonly AppDbContext _context;


        // Property to hold the list of Users, automatically available to the Razor page
        public IList<User> Users { get; set; } = default!;


        // Constructor for Dependency Injection (DI)
        public UsersModel(AppDbContext context)
        {
            _context = context;
        }


        // The function that prints all users
        // This runs automatically when the page is requested via GET
        public async Task OnGetAsync()
        {
            // 1. Access the Users DbSet
            // 2. Use .ToListAsync() to execute the query against the SQLite database
            // 3. The data is stored in the 'Users' property for the view to display
            Users = await _context.Users.ToListAsync();
        }
    }
}

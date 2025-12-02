using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AskeOgViktorProjekt.Data;
using AskeOgViktorProjekt.Models;





namespace AskeOgViktorProjekt.Pages
{
public class UsersModel : PageModel
{
    private readonly AppDbContext _db;

    public UsersModel(AppDbContext db)
    {
        _db = db;
    }

    // AJAX handler
    public JsonResult OnGetList()
    {
        var users = _db.Users.ToList();
        return new JsonResult(users);
    }
}

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AskeOgViktorProjekt.Data;

namespace AskeOgViktorProjekt.Pages
{
    public class Gallery : PageModel
    {
        private readonly AppDbContext _db;

        public Gallery(AppDbContext db)
        {
            _db = db;
        }

        public List<ImageItem> Images { get; } = new();

        public async Task OnGetAsync()
        {
            var items = await _db.Images
                .OrderByDescending(i => i.Id)
                .Select(i => new
                {
                    i.Id,
                    i.OriginalFileName,
                    i.RelativePath,
                    i.ContentType,
                    i.Title,
                    i.Description // added
                })
                .ToListAsync();

            foreach (var i in items)
            {
                var rel = i.RelativePath ?? "";
                // Normalize to a web path that static files middleware will serve
                if (rel.StartsWith("~")) rel = rel.TrimStart('~');
                if (!rel.StartsWith("/")) rel = "/" + rel.TrimStart('/');

                Images.Add(new ImageItem
                {
                    Id = i.Id,
                    FileName = i.OriginalFileName ?? "",
                    Url = rel,
                    Title = i.Title,
                    Description = i.Description // added
                });
            }
        }
    }

    public class ImageItem
    {
        public int Id { get; set; }
        public string FileName { get; set; } = "";
        public string Url { get; set; } = "";
        public string? Title { get; set; }
        public string? Description { get; set; } // added
    }
}
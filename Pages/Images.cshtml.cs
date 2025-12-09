using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using AskeOgViktorProjekt.Models;
using AskeOgViktorProjekt.Data;

namespace AskeOgViktorProjekt.Pages
{
    public class ImagesModel : PageModel
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;

        public ImagesModel(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        [BindProperty]
        public IFormFile? ImageFile { get; set; }

        [BindProperty]
        public string? ImageTitle { get; set; }

        [BindProperty]
        public string? ImageDescription { get; set; }
        
        public Image? RecentImage { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Validate presence
            if (ImageFile is null || ImageFile.Length == 0)
            {
                ModelState.AddModelError(nameof(ImageFile), "Please select a file.");
                return Page();
            }

            // Validate type + size
            var allowed = new[] { "image/jpeg", "image/png", "image/webp" };
            if (Array.IndexOf(allowed, ImageFile.ContentType) < 0)
            {
                ModelState.AddModelError(nameof(ImageFile), "Only JPG, PNG, or WebP images are allowed.");
                return Page();
            }

            const long maxBytes = 5 * 1024 * 1024; // 5 MB
            if (ImageFile.Length > maxBytes)
            {
                ModelState.AddModelError(nameof(ImageFile), "Image too large. Max 5 MB.");
                return Page();
            }

            var relativeFolder = Path.Combine("uploads", "misc",
                DateTime.UtcNow.ToString("yyyy"),
                DateTime.UtcNow.ToString("MM"));

            var physicalFolder = Path.Combine(_env.WebRootPath, relativeFolder);
            Directory.CreateDirectory(physicalFolder);

            var ext = Path.GetExtension(ImageFile.FileName);
            var newFileName = $"{Guid.NewGuid():N}{ext}";
            var physicalPath = Path.Combine(physicalFolder, newFileName);

            var relativePath = "/" + Path.Combine(relativeFolder, newFileName).Replace('\\', '/');

            using (var stream = System.IO.File.Create(physicalPath))
            {
                await ImageFile.CopyToAsync(stream);
            }

            var image = new Image
            {
                OriginalFileName = Path.GetFileName(ImageFile.FileName),
                ContentType = ImageFile.ContentType,
                RelativePath = relativePath,
                Title = ImageTitle,
                Description = ImageDescription, // added
                UploadedUtc = DateTime.UtcNow
            };

            _db.Images.Add(image);
            await _db.SaveChangesAsync();

            RecentImage = image;

            return Page();
        }
    }
}

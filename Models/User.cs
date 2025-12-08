
namespace AskeOgViktorProjekt.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Password { get; set; } = default!; // consider hashing!
        public ICollection<Image> Images { get; set; } = new List<Image>();
    }

    public class Image
    {
        public int Id { get; set; }
        public string OriginalFileName { get; set; } = default!;
        public string ContentType { get; set; } = default!;
        public string RelativePath { get; set; } = default!;
        public string? Title { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
        public DateTime UploadedUtc { get; set; } = DateTime.UtcNow;
    }
}


using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AquariumForum.Data
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        public string? Location { get; set; }

        public string? ImageFilename { get; set; }

        [NotMapped] // This will not be stored in the database
        public IFormFile? ImageFile { get; set; }
    }
}

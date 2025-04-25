using Microsoft.AspNetCore.Identity;

namespace ANU.Models
{
    // This class extends the built-in IdentityUser class to add custom user properties
    // It will be used by ASP.NET Core Identity for user management
    public class ApplicationUser : IdentityUser
    {
        // Add custom properties for your user
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        // You can add more custom properties as needed
        // public string ProfileImageUrl { get; set; } = string.Empty;
        // public int? FacultyId { get; set; }
        // public Faculty? Faculty { get; set; }
    }
}

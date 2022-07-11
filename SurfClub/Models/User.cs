using Microsoft.AspNetCore.Identity;

namespace SurfClub.Models
{
    public class User : IdentityUser<int>
    {
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public Guid? Photo { get; set; }
        public string? ContactInfo { get; set; }
        public string? About { get; set; }
        public string? Achievements { get; set; }
    }
}

using PPASystem.Entities;
using System.ComponentModel.DataAnnotations;

namespace PPASystem.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string IdentityNumber { get; set; } = string.Empty;

        public int Age { get; set; } = 0;

        public string Email { get; set; } = string.Empty;

        public string ContactNumber { get; set; } = string.Empty;

        public string ChipNumber { get; set; } = string.Empty;

        public EmergencyContact EmergencyContact { get; set; }

        public UserRole UserRole { get; set; }
    }
}

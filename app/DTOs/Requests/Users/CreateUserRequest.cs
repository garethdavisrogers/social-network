using System.ComponentModel.DataAnnotations;

namespace SocialNetworkV1.DTOs.Requests.Users
{
    public class CreateUserRequest
    {
        [Required, EmailAddress]
        public string email { get; set; } = string.Empty;

        [Required]
        public string password { get; set; } = string.Empty;
    }
}

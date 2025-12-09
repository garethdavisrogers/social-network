using System.ComponentModel.DataAnnotations;

namespace SocialNetworkV1.DTOs.Requests.Auth
{
    public class LoginUserRequest
    {
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
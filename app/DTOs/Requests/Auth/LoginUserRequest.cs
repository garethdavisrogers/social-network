using System.ComponentModel.DataAnnotations;

namespace SocialNetworkV1.DTOs.Requests.Auth
{
    public class LoginUserRequest
    {
        [Required, EmailAddress]
        public string email { get; set; } = string.Empty;

        [Required]
        public string password { get; set; } = string.Empty;
    }
}
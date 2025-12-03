using System.ComponentModel.DataAnnotations;

namespace SocialNetworkV1.DTOs.Requests.Auth
{
    public class LoginUserRequest
    {
        public string UserNameOrEmail { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
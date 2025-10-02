using SocialNetworkV1.Models;
using System.ComponentModel.DataAnnotations;

namespace SocialNetworkV1.DTOs.Requests.Users
{
    public class UpdateUserRequest
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}

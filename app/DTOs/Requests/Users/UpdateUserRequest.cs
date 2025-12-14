using SocialNetworkV1.Models;
using System.ComponentModel.DataAnnotations;

namespace SocialNetworkV1.DTOs.Requests.Users
{
    public class UpdateUserRequest
    {
        public string? name { get; set; }
        public string? email { get; set; }
    }
}

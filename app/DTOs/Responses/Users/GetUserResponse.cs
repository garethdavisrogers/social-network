using SocialNetworkV1.Models;

namespace SocialNetworkV1.DTOs.Responses.Users;
public record GetUserResponse(Guid id, string name, string email, ICollection<Post> posts);


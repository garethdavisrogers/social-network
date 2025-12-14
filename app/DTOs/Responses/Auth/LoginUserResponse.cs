using SocialNetworkV1.Models;

namespace SocialNetworkV1.DTOs.Responses.Users;
public record LoginUserResponse(Guid id, string name, string email, string token);


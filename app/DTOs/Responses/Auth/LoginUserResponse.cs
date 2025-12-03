using SocialNetworkV1.Models;

namespace SocialNetworkV1.DTOs.Responses.Users;
public record LoginUserResponse(Guid id, string Name, string Email, string Token);


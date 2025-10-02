using SocialNetworkV1.Models;

namespace SocialNetworkV1.DTOs.Responses.Users;
public record GetUserResponse(Guid id, string Name, string Email, List<Guid> Posts);


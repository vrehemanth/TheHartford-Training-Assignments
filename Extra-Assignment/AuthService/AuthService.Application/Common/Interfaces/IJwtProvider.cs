using AuthService.Domain.Entities;

namespace AuthService.Application.Common.Interfaces
{
    public interface IJwtProvider
    {
        string GenerateToken(User user);
    }
}

using System.Security.Claims;
using Blog.DAL.Entities.Responses;

namespace Blog.BLL.Services.Contracts;

public interface ITokenService
{
    TokenResponse GetToken(IEnumerable<Claim> claims);
    string GetRefreshToken();
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
}

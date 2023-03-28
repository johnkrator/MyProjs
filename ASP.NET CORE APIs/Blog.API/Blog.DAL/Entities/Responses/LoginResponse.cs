using Blog.DAL.Entities.DTOs;

namespace Blog.DAL.Entities.Responses;

public class LoginResponse : Status
{
    public string Token { get; set; }
    public string RefreshToken { get; set; }
    public DateTime? Expiration { get; set; }
    public string Name { get; set; }
    public string Username { get; set; }
}

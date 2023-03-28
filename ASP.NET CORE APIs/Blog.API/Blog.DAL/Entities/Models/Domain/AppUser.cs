using Microsoft.AspNetCore.Identity;

namespace Blog.DAL.Entities.Models.Domain;

public class AppUser : IdentityUser
{
    public string? Fullname { get; set; }
    public string? PhoneNumber { get; set; }
    public IList<BlogModel> Blogs { get; set; } = new List<BlogModel>();
}

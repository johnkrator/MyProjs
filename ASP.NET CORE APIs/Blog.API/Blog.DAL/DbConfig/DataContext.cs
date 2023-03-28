using Blog.DAL.Entities.Models;
using Blog.DAL.Entities.Models.Domain;
using Blog.DAL.Entities.Tokens;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Blog.DAL.DbConfig;

public class DataContext : IdentityDbContext<AppUser>
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<BlogModel> Blogs { get; set; }
    public DbSet<TokenInfo> TokenInfos { get; set; }
}

using Blog.DAL.Entities.DTOs;
using Blog.DAL.Entities.Models;

namespace Blog.BLL.Services.Contracts;

public interface IBlogService
{
    Task<IEnumerable<BlogModel>> GetAllUserBlog(string id);
    Task<BlogModel> AddBlogAsync(BlogDto blogDto);
    Task<BlogModel> GetBlogByIdAsync(Guid id);
    Task<BlogModel> UpdateBlogAsync(BlogDto blogDto);
    Task<BlogModel> DeleteBlogAsync(Guid id);
}

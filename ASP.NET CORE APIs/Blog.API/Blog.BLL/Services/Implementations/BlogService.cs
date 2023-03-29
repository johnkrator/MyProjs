using Blog.BLL.Services.Contracts;
using Blog.DAL.Entities.DTOs;
using Blog.DAL.Entities.Models;
using Blog.DAL.Entities.Models.Domain;
using Blog.DAL.Repository.Contracts;
using Microsoft.AspNetCore.Identity;

namespace Blog.BLL.Services.Implementations;

public class BlogService : IBlogService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<AppUser> _userManager;
    private readonly IRepository<BlogModel> _blogRepository;

    public BlogService(IUnitOfWork unitOfWork, UserManager<AppUser> userManager)
    {
        _unitOfWork = unitOfWork;
        _userManager = userManager;
    }

    public Task<IEnumerable<BlogModel>> GetAllUserBlog(string id)
    {
        throw new NotImplementedException();
    }

    public Task<BlogModel> AddBlogAsync(BlogDto blogDto)
    {
        throw new NotImplementedException();
    }

    public Task<BlogModel> GetBlogByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<BlogModel> UpdateBlogAsync(BlogDto blogDto)
    {
        throw new NotImplementedException();
    }

    public Task<BlogModel> DeleteBlogAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}

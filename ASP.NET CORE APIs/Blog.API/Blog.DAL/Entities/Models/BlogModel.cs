using System.ComponentModel.DataAnnotations.Schema;
using Blog.DAL.Entities.Models.Domain;

namespace Blog.DAL.Entities.Models;

public class BlogModel : BaseModel
{
    public string Title { get; set; }
    public string Description { get; set; }

    [ForeignKey("AppUser")] public string AppUserId { get; set; }
    public AppUser AppUser { get; set; }
}

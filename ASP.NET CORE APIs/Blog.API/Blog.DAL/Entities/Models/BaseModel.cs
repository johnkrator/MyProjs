namespace Blog.DAL.Entities.Models;

public class BaseModel
{
    public Guid Id { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public DateTime? DateUpdated { get; set; }
}

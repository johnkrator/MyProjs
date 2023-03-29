using System.ComponentModel.DataAnnotations;
using Blog.DAL.Enums;

namespace Blog.DAL.Entities.DTOs;

public class BlogDto
{
    [Required] public string Title { get; set; }
    [Required] public string Description { get; set; }
    [Required] public Category Category { get; set; }
    [Required] public string AppUserId { get; set; }
}

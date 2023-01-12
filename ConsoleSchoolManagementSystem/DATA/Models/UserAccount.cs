using System.ComponentModel.DataAnnotations;

namespace DATA.Models;

public class UserAccount
{
    public int Id { get; set; }
    [Required] public string? FirstName { get; set; }
    [Required] public string? LastName { get; set; }
    public string? MiddleName { get; set; }
    [Required] public long Password { get; set; }
    public int TotalLogin { get; set; }
    public bool IsLocked { get; set; }
}

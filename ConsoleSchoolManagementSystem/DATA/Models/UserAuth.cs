using System.ComponentModel.DataAnnotations;

namespace DATA.Models;

public class UserAuth
{
    public int Id { get; set; }
    [Required] public string FirstName { get; set; }
    [Required] public string LastName { get; set; }
    public string Middle { get; set; }
    [Required] public long Password { get; set; }
    public bool IsLoggedIn { get; set; }
}

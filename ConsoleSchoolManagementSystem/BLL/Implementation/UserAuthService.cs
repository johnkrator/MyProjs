using BLL.Interfaces;

namespace BLL.Implementation;

public class UserAuthService : IUserAuth
{
    public void Login()
    {
        Console.WriteLine("Welcome back james...");
    }
}

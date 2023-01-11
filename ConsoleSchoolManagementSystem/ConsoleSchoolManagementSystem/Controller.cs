using BLL.Implementation;
using UI;

namespace ConsoleSchoolManagementSystem;

public class Controller : UserAuthService
{
    public void Run()
    {
        AppScreen.WelcomeScreen();
        Utility.PressEnterToContinue();

        Login();
    }
}

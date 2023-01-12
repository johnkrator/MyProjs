using BLL.Implementation;
using UI;

namespace ConsoleSchoolManagementSystem;

public class Controller : UserAuthService
{
    public void Run()
    {
        AppScreen.Welcome();
        Utility.PressEnterToContinue();
        UserAuthService userAuthService = new UserAuthService();
        userAuthService.InitializedData();
        userAuthService.RunServices();

        CheckUserDetails();
    }
}

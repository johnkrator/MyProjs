using BLL.Interfaces;
using DATA.Models;
using UI;

namespace BLL.Implementation;

public class UserAuthService : IUserAuth
{
    private List<UserAuth> _userAuthList;
    private UserAuth _selectedUserAccount;
    private List<OperationsService> _listOfOperationsServices;

    public void InitializedData()
    {
        _userAuthList = new List<UserAuth>
        {
            new UserAuth
            {
                Id = 1, FirstName = "James", LastName = "Oma", MiddleName = "Kendrick", Password = 1122,
                IsLocked = true
            },
            new UserAuth
            {
                Id = 2, FirstName = "Phil", LastName = "Jones", MiddleName = "Kush", Password = 1111, IsLocked = true
            },
            new UserAuth
            {
                Id = 3, FirstName = "Amaka", LastName = "Hope", MiddleName = "Ngozi", Password = 2222,
                IsLocked = false
            }
        };
        _listOfOperationsServices = new List<OperationsService>();
    }

    public void CheckUserDetails()
    {
        bool isCorrectLogin = false;
        while (isCorrectLogin == false)
        {
            UserAuth userInputAccount = AppScreen.UserLoginForm();
            AppScreen.ShowLoginProgress();
            foreach (UserAuth account in _userAuthList)
            {
                _selectedUserAccount = account;
                if (userInputAccount.FirstName.Equals(_selectedUserAccount.FirstName))
                {
                    _selectedUserAccount = account;
                    if (_selectedUserAccount.IsLocked || _selectedUserAccount.TotalLogin > 3)
                    {
                        AppScreen.PrintLockScreen();
                    }
                    else
                    {
                        _selectedUserAccount.TotalLogin = 0;
                        isCorrectLogin = true;
                        break;
                    }
                }
            }
        }

        if (isCorrectLogin == false)
        {
            Utility.PrintMessage("Invalid name or password", false);
            _selectedUserAccount.IsLocked = _selectedUserAccount.TotalLogin == 3;
            if (_selectedUserAccount.IsLocked)
            {
                AppScreen.PrintLockScreen();
            }
        }

        Console.Clear();
    }
}

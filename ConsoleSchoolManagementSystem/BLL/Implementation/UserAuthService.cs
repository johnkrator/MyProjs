using BLL.Interfaces;
using DATA.Models;
using UI;

namespace BLL.Implementation;

public class UserAuthService : IUserAuth
{
    private List<UserAccount> _userAccountList;
    private UserAccount _selectedUserAccount;
    private List<OperationsService> _listOfOperationsServices;

    public void RunServices()
    {
        if (_selectedUserAccount != null)
        {
            WelcomeUser(_selectedUserAccount.FirstName);
        }
    }

    public void WelcomeUser(string fullName)
    {
        Console.Clear();
        Console.WriteLine($"Welcome back, {fullName}");
        Utility.PressEnterToContinue();
    }

    public void InitializedData()
    {
        _userAccountList = new List<UserAccount>
        {
            new UserAccount
            {
                Id = 1, FirstName = "James", LastName = "Oma", MiddleName = "Kendrick", Password = 1122, IsLocked = true
            },
            new UserAccount
            {
                Id = 2, FirstName = "Phil", LastName = "Jones", MiddleName = "Kush", Password = 1111, IsLocked = true
            },
            new UserAccount
            {
                Id = 3, FirstName = "Amaka", LastName = "Hope", MiddleName = "Ngozi", Password = 2222, IsLocked = false
            }
        };
        _listOfOperationsServices = new List<OperationsService>();
    }

    public void CheckUserDetails()
    {
        bool isCorrectLogin = false;
        while (isCorrectLogin == false)
        {
            UserAccount userInputAccount = AppScreen.UserLoginForm();
            AppScreen.ShowLoginProgress();
            if (_userAccountList != null)
            {
                foreach (UserAccount account in _userAccountList)
                {
                    _selectedUserAccount = account;
                    if (userInputAccount.FirstName.Equals(_selectedUserAccount.FirstName))
                    {
                        _selectedUserAccount.TotalLogin++;
                        if (userInputAccount.LastName.Equals(_selectedUserAccount.LastName))
                        {
                            _selectedUserAccount.TotalLogin++;
                            if (userInputAccount.MiddleName.Equals(_selectedUserAccount.MiddleName))
                            {
                                _selectedUserAccount.TotalLogin++;
                                if (userInputAccount.Password.Equals(_selectedUserAccount.Password))
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
                    }
                }
            }
        }

        if (isCorrectLogin == false)
        {
            Utility.PrintMessage("\nInvalid name or password", false);
            _selectedUserAccount.IsLocked = _selectedUserAccount.TotalLogin == 3;
            if (_selectedUserAccount.IsLocked)
            {
                AppScreen.PrintLockScreen();
            }
        }

        Console.Clear();
    }
}

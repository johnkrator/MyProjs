using System;
using System.Collections.Generic;
using ConsoleMusicPlayer.Domain.Entities;
using ConsoleMusicPlayer.Domain.Interfaces;
using ConsoleMusicPlayer.UI;

namespace ConsoleMusicPlayer.App
{
    public class Controller : UserAccount, IUserLogin
    {
        private List<UserAccount> _userAccountList;
        private UserAccount _selectedAccount;

        public void Run()
        {
            AppScreen.Welcome();
            InitializedData();
            CheckUsernameAndPassword();
            Welcome();
        }

        public void Welcome()
        {
            Console.WriteLine($"Welcome back, {_selectedAccount.Username}");
            Utility.PressEnterToContinue();
        }


        public void InitializedData()
        {
            _userAccountList = new List<UserAccount>
            {
                new UserAccount
                    { Id = 1, FullName = "James Oma", Username = "@james", Password = 123456, IsLocked = false },
                new UserAccount
                    { Id = 2, FullName = "Mutari Ahmed", Username = "@muktari", Password = 09876, IsLocked = true }
            };
        }

        public void CheckUsernameAndPassword()
        {
            bool isCorrectLogin = false;

            while (isCorrectLogin == false)
            {
                UserAccount inputAccount = AppScreen.UserLoginForm();
                AppScreen.LoginProgress();
                foreach (UserAccount account in _userAccountList)
                {
                    _selectedAccount = account;

                    if (inputAccount.Password.Equals(_selectedAccount.Password))
                    {
                        _selectedAccount.TotalLogin++;

                        if (_selectedAccount.IsLocked || _selectedAccount.TotalLogin > 3)
                        {
                            AppScreen.PrintLockScreen();
                        }
                        else
                        {
                            _selectedAccount.TotalLogin = 0;
                            isCorrectLogin = true;
                            break;
                        }
                    }
                }

                if (isCorrectLogin == false)
                {
                    Utility.PrintMessage("\nInvalid username and password.", false);
                    _selectedAccount.IsLocked = _selectedAccount.TotalLogin == 3;
                    if (_selectedAccount.IsLocked)
                    {
                        AppScreen.PrintLockScreen();
                    }
                }

                Console.Clear();
            }
        }
    }
}

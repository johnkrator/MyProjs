using System;
using System.Collections.Generic;
using ConsoleMusicPlayer.Domain.Entities;
using ConsoleMusicPlayer.Domain.Enums;
using ConsoleMusicPlayer.Domain.Interfaces;
using ConsoleMusicPlayer.UI;

namespace ConsoleMusicPlayer.App
{
    public class Controller : UserAccount, IUserLogin, IUserPrivileges
    {
        private List<UserAccount> _userAccountList;
        private UserAccount _selectedAccount;

        public void Run()
        {
            AppScreen.Welcome();
            InitializedData();
            CheckUsernameAndPassword();
            Welcome();
            while (true)
            {
                AppScreen.DisplayMenuOptions();
                PressMenuOption();
            }
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

        public void PressMenuOption()
        {
            switch (Validator.Convert<int>("an option: "))
            {
                case (int)UserOptions.UserAction:
                    UserAction();
                    break;
                case (int)UserOptions.CreatePlaylist:
                    Console.WriteLine("Creating a playlist");
                    break;
                case (int)UserOptions.ViewPlaylist:
                    Console.WriteLine("Viewing playlist");
                    break;
                case (int)UserOptions.Logout:
                    Console.WriteLine("Logging out");
                    Utility.PrintDotAnimation();
                    break;
                default:
                    Utility.PrintMessage("Invlid Option. Please try again.", false);
                    break;
            }
        }

        public void UserAction()
        {
            Console.Clear();
            AppScreen.DisplayUserActions();
            switch (Validator.Convert<int>("an option to continue: "))
            {
                case (int)UserActions.Add:
                    Console.WriteLine("addeing a song...");
                    break;
                case (int)UserActions.Edit:
                    Console.WriteLine("Editing a song...");
                    break;
                case (int)UserActions.Delete:
                    Console.WriteLine("Deleting a song...");
                    break;
                default:
                    Utility.PrintMessage("Invalid Option. Please try a again");
                    break;
            }
        }

        // User privileges
        public void Add()
        {
            throw new NotImplementedException();
        }

        public void Edit()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }
    }
}

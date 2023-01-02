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
        private List<string> songs = new List<string>();

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
                    { Id = 1, FullName = "James Oma", Username = "@james", Password = 112233, IsLocked = false },
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
                    AppScreen.LogoutProgress();
                    Utility.PrintMessage("You have successfully logged out.", true);
                    Run();
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
                    AddSong();
                    break;
                case (int)UserActions.Edit:
                    EditSong();
                    break;
                case (int)UserActions.Delete:
                    DeleteSong();
                    break;
                case (int)UserActions.DisplayAllSongs:
                    DisplaySongs();
                    break;
                default:
                    Utility.PrintMessage("Invalid Option. Please try a again", false);
                    break;
            }
        }

        // User privileges
        public void AddSong()
        {
            try
            {
                Console.Write("\nPlease enter a song title and name of artist: ");
                var songDescriptor = Console.ReadLine();

                songs.Add(songDescriptor);
                Utility.PrintMessage($"{songDescriptor} was added successfully.", true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void EditSong()
        {
            try
            {
                Console.WriteLine("\nHint: index starts at 0");
                Console.Write("Enter song number index: ");

                var index = int.Parse(Console.ReadLine());

                Console.Write("Enter the new name of song to be updated: ");
                var updatedSong = Console.ReadLine();

                songs[index] = updatedSong;
                Utility.PrintMessage($"{updatedSong} was successfully updated.", true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void DeleteSong()
        {
            try
            {
                Console.WriteLine("\nHint: index starts at 0");
                Console.Write("Enter the index of the song to be delete: ");
                var index = int.Parse(Console.ReadLine());

                songs.RemoveAt(index);
                Utility.PrintMessage($"The song at index {index} was successfully deleted.", true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void DisplaySongs()
        {
            try
            {
                Console.WriteLine("\nYour Songs:");
                foreach (var song in songs)
                {
                    Console.WriteLine($"-> {song}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

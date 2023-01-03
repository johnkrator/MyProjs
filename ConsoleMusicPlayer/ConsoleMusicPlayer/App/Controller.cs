using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleMusicPlayer.Domain.Entities;
using ConsoleMusicPlayer.Domain.Enums;
using ConsoleMusicPlayer.Domain.Interfaces;
using ConsoleMusicPlayer.UI;

namespace ConsoleMusicPlayer.App
{
    public class Controller : UserAccount, IUserLogin, IUserPrivileges, ISongsGenre, IPlaylistDisplayOrder
    {
        private List<UserAccount> _userAccountList;
        private UserAccount _selectedAccount;
        private List<string> _songs = new List<string>();
        private List<string> _songsGenre = new List<string>();
        private static Random _random = new Random();

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
                    SongsGenre();
                    break;
                case (int)UserOptions.ViewPlaylist:
                    DisplayPlayList();
                    break;
                case (int)UserOptions.ShufflePlaylist:
                    ShuffleSongsOnPlaylist();
                    break;
                case (int)UserOptions.DisplayPlaylistInAlphabeticalOrder:
                    DisplaySongsInAlphabeticalOrder();
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

        public void SongsGenre()
        {
            Console.Clear();
            AppScreen.DisplaySongsGenre();
            switch (Validator.Convert<int>("an option: "))
            {
                case (int)SongGenre.Raggae:
                    AddRaggaeSong();
                    break;
                case (int)SongGenre.Rap:
                    AddRapSong();
                    break;
                case (int)SongGenre.HipHop:
                    AddHipHopSong();
                    break;
                case (int)SongGenre.Afro:
                    AddAfroSong();
                    break;
                default:
                    Utility.PrintMessage("Invalid Option. Please check and try again", false);
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

                _songs.Add(songDescriptor);
                Utility.PrintMessage($"{songDescriptor} was added successfully.", true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
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

                _songs[index] = updatedSong;
                Utility.PrintMessage($"{updatedSong} was successfully updated.", true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void DeleteSong()
        {
            try
            {
                Console.WriteLine("\nHint: index starts at 0");
                Console.Write("Enter the index of the song to be delete: ");
                var index = int.Parse(Console.ReadLine());

                _songs.RemoveAt(index);
                Utility.PrintMessage($"The song at index {index} was successfully deleted.", true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void DisplaySongs()
        {
            try
            {
                Console.WriteLine("\nYour Songs:");
                foreach (var song in _songs)
                {
                    Console.WriteLine($"-> {song}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        // Raggae
        public void AddRaggaeSong()
        {
            try
            {
                Console.Write("\nAdd songs: ");
                var raggae = Console.ReadLine();
                _songsGenre.Add(raggae);
                Utility.PrintMessage($"{raggae} was successfully added.", true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void AddRapSong()
        {
            try
            {
                Console.Write("\nAdd songs: ");
                var rap = Console.ReadLine();
                _songsGenre.Add(rap);
                Utility.PrintMessage($"{rap} was successfully added.", true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void AddHipHopSong()
        {
            try
            {
                Console.Write("\nAdd songs: ");
                var hip = Console.ReadLine();
                _songsGenre.Add(hip);
                Utility.PrintMessage($"{hip} was successfully added.", true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void AddAfroSong()
        {
            try
            {
                Console.Write("Add songs: ");
                var afro = Console.ReadLine();
                _songsGenre.Add(afro);
                Utility.PrintMessage($"{afro} was successfully added.", true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void DisplayPlayList()
        {
            Console.WriteLine("\nYour songs: ");
            foreach (var song in _songsGenre)
            {
                Console.WriteLine($"-> {song}");
            }
        }

        public void ShuffleSongsOnPlaylist()
        {
            foreach (var song in _songs)
            {
                Console.WriteLine(song.Reverse());
            }
        }

        public void DisplaySongsInAlphabeticalOrder()
        {
            foreach (var song in _songs)
            {
                Console.WriteLine(song);
            }
        }
    }
}

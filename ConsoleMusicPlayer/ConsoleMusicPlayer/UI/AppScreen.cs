using System;
using ConsoleMusicPlayer.Domain.Entities;

namespace ConsoleMusicPlayer.UI
{
    public static class AppScreen
    {
        internal static void Welcome()
        {
            Console.Clear();
            Console.WriteLine("\n**********************************************************");
            Console.WriteLine("Hello, there! Welcome to my console music player app.");
            Console.WriteLine("**********************************************************");
            Console.ForegroundColor = ConsoleColor.White;

            Utility.PressEnterToContinue();
        }

        internal static UserAccount UserLoginForm()
        {
            UserAccount tempUserAccount = new UserAccount();
            tempUserAccount.Username = Utility.GetUserInput("your name: ");
            tempUserAccount.Password = Convert.ToInt32(Utility.GetSecretInput("your password: "));
            return tempUserAccount;
        }

        internal static void LoginProgress()
        {
            Console.WriteLine("\nChecking username and password.");
            Utility.PrintDotAnimation();
        }

        internal static void PrintLockScreen()
        {
            Console.Clear();
            Utility.PrintMessage("Oops. Your account has blocked.", false);
            Utility.PressEnterToContinue();
            Environment.Exit(1);
        }

        internal static void DisplayMenuOptions()
        {
            Console.WriteLine("");
            Console.WriteLine("1. User Action");
            Console.WriteLine("2. Create a Playlist");
            Console.WriteLine("3. View Playlist");
            Console.WriteLine("4. Display Shuffled Playlist");
            Console.WriteLine("5. Display Playlist in Alphabetical Order");
            Console.WriteLine("6. Logout");
            Console.WriteLine("");
        }

        internal static void DisplayUserActions()
        {
            Console.WriteLine("1. Add a new song");
            Console.WriteLine("2. Edit a song");
            Console.WriteLine("3. Delete a song");
            Console.WriteLine("4. Display songs");
            Console.WriteLine("");
        }

        internal static void DisplaySongsGenre()
        {
            Console.WriteLine("1. Raggae");
            Console.WriteLine("2. Rap");
            Console.WriteLine("3. HipHop");
            Console.WriteLine("4. Afro");
            Console.WriteLine("");
        }

        internal static void LogoutProgress()
        {
            Console.WriteLine("Thank you for using our app.");
            Utility.PrintDotAnimation();
            Console.Clear();
        }
    }
}

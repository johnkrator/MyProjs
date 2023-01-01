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
            Utility.PrintDotAnimation();
        }

        internal static void PrintLockScreen()
        {
            Console.Clear();
            Utility.PrintMessage("Oops. Your account has blocked.", false);
            Utility.PressEnterToContinue();
            Environment.Exit(1);
        }
    }
}

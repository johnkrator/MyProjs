using DATA.Models;

namespace UI;

public class AppScreen
{
    public static void Welcome()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\nHello there, Welcome!");
    }

    public static void ShowLoginProgress()
    {
        Utility.PrintDotAnimation();
    }

    public static UserAccount UserLoginForm()
    {
        UserAccount temporaryAccountUser = new UserAccount();
        temporaryAccountUser.FirstName = Validator.Convert<string>("your first name: ");
        temporaryAccountUser.LastName = Validator.Convert<string>("your last name: ");
        temporaryAccountUser.MiddleName = Validator.Convert<string>("your middle name: ");
        temporaryAccountUser.Password = Convert.ToInt32(Utility.GetSecretUserInput("your password: "));
        Console.WriteLine("");
        return temporaryAccountUser;
    }

    public static void PrintLockScreen()
    {
        Console.Clear();
        Utility.PrintMessage("This account is locked. Please try again later", false);
        Utility.PressEnterToContinue();
        Environment.Exit(1);
    }
}

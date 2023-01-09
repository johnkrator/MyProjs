namespace UI;

public static class Utility
{
    public static void PressEnterToContinue()
    {
        Console.WriteLine("\nPress enter to continue");
        Console.ReadLine();
    }

    public static string GetUserInput(string prompt)
    {
        Console.Write($"\nEnter {prompt}");
        return Console.ReadLine();
    }

    public static void PrintMessage(string message, bool success = true)
    {
        if (success)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
        }

        Console.WriteLine(message);
        Console.ResetColor();
        PressEnterToContinue();
    }

    public static void PrintDotAnimation(int timer = 10)
    {
        for (int i = 0; i <= timer; i++)
        {
            Console.Write(".");
            Thread.Sleep(200);
        }
    }

    public static void LogoutProcess()
    {
        Console.Clear();
        Console.WriteLine("Logging out");
    }
}

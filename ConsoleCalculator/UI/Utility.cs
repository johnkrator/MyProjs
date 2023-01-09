namespace UI;

public class Utility
{
    public static void PressEnterToContinue()
    {
        Console.WriteLine("\nPress enter to continue");
        Console.ReadLine();
    }

    public static string GetUserInput(string prompt)
    {
        Console.Write($"Enter {prompt}");
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
}

using System.Text;

namespace UI;

public class Utility
{
    public static void PressEnterToContinue()
    {
        Console.WriteLine("Press enter to continue.");
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
            Console.ForegroundColor = ConsoleColor.Red;
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

    public static string GetSecretUserInput(string prompt)
    {
        bool isPrompt = true;
        string asterics = "";
        StringBuilder input = new StringBuilder();
        while (true)
        {
            if (isPrompt) Console.WriteLine(prompt);
            isPrompt = false;
            ConsoleKeyInfo inputKey = Console.ReadKey(true);

            if (inputKey.Key == ConsoleKey.Enter)
            {
                if (input.Length == 4)
                {
                    break;
                }
                else
                {
                    PrintMessage("Please enter 4 digits.", false);
                    isPrompt = true;
                    input.Clear();
                    continue;
                }
            }

            if (inputKey.Key == ConsoleKey.Backspace && input.Length > 0)
            {
                input.Remove(input.Length - 1, 1);
            }
            else if (inputKey.Key != ConsoleKey.Backspace)
            {
                input.Append(inputKey.KeyChar);
                Console.Write(asterics + "x");
            }
        }

        return input.ToString();
    }
}

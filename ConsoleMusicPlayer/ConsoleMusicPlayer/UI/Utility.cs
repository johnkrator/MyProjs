using System;
using System.Text;
using System.Threading;

namespace ConsoleMusicPlayer.UI
{
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
            try
            {
                if (success)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }

                Console.WriteLine(message);
                Console.ResetColor();
                PressEnterToContinue();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public static string GetSecretInput(string prompt)
        {
            bool isPrompt = true;
            string asterics = "";

            StringBuilder input = new StringBuilder();

            while (true)
            {
                if (isPrompt)
                    Console.Write(prompt);
                isPrompt = false;
                ConsoleKeyInfo inputKey = Console.ReadKey(true);
                if (inputKey.Key == ConsoleKey.Enter)
                {
                    if (input.Length >= 5)
                    {
                        break;
                    }
                    else
                    {
                        PrintMessage("\nPlease enter 5 or more digit", false);
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
                    Console.Write(asterics + "*");
                }
            }

            return input.ToString();
        }

        public static void PrintDotAnimation(int timer = 10)
        {
            Console.WriteLine("\nChecking username and password.");

            for (int i = 0; i < timer; i++)
            {
                Console.Write(".");
                Thread.Sleep(200);
            }

            Console.Clear();
        }
    }
}

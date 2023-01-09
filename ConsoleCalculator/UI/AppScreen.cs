namespace UI;

public class AppScreen
{
    public static void WelcomeScreen()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\nHello there! Welcome to my calculator app.");
    }

    public static void DisplayUserAction()
    {
        Console.WriteLine("\nChoose what operation to perform: ");
        Console.WriteLine("1. Addition\n2. Subtraction\n3. Multiplication\n4. Division\n5. SquareRoot\n6. Exit");
    }
}

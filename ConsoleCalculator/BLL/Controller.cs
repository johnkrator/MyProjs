using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using UI;

namespace BLL;

public class Controller : Operation, IOperations
{
    public void Run()
    {
        AppScreen.WelcomeScreen();
        Utility.PressEnterToContinue();
        while (true)
        {
            GetUserAction();
        }
    }

    public static void GetUserAction()
    {
        AppScreen.DisplayUserAction();
        switch (Validator.Convert<int>("an option: "))
        {
            case (int)OperationTypes.Addition:
                Console.WriteLine("Hello Addition");
                break;
            case (int)OperationTypes.Subtraction:
                Console.WriteLine("Hello Subtraction");
                break;
            case (int)OperationTypes.Multiplication:
                Console.WriteLine("Hello Multiplication");
                break;
            case (int)OperationTypes.Division:
                Console.WriteLine("Hello Division");
                break;
            case (int)OperationTypes.SquareRoot:
                Console.WriteLine("Hello SquareRoot");
                break;
            case (int)OperationTypes.Exit:
                Utility.PrintDotAnimation();
                Utility.PrintMessage("\nExiting was successful", true);
                // Run();
                break;
            default:
                Utility.PrintMessage("Invalid Option. Please try again.", false);
                break;
        }
    }

    // Interface logic
    public void Addition()
    {
        Console.WriteLine("Enter first number: ");
        var a = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter second number: ");
        var b = double.Parse(Console.ReadLine());
        Console.WriteLine($"\n\tResult:--> {a + b}");
    }

    public void Subtraction()
    {
        Console.WriteLine("Enter first number: ");
        var a = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter second number: ");
        var b = double.Parse(Console.ReadLine());
        Console.WriteLine($"\n\tResult:--> {a - b}");
    }

    public void Multiplication()
    {
        Console.WriteLine("Enter first number: ");
        var a = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter second number: ");
        var b = double.Parse(Console.ReadLine());
        Console.WriteLine($"\n\tResult:--> {a * b}");
    }

    public void Division()
    {
        Console.WriteLine("Enter first number: ");
        var a = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter second number: ");
        var b = double.Parse(Console.ReadLine());
        if (b == 0)
        {
            throw new DivideByZeroException();
        }

        Console.WriteLine($"\n\tResult:--> {a / b}");
    }

    public void SquareRoot()
    {
        Console.WriteLine("Enter first number: ");
        var a = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter second number: ");
        var b = double.Parse(Console.ReadLine());
        // return a * *b;
        // Console.WriteLine($"\n\tResult:--> {a ** b}");
    }
}

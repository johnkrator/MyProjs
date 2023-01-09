using Domain.Enums;
using Domain.Interfaces;
using UI;

namespace BLL;

public class Controller : IOperations
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

    public void GetUserAction()
    {
        AppScreen.DisplayUserAction();
        switch (Validator.Convert<int>("an option: "))
        {
            case (int)OperationTypes.Addition:
                Addition();
                break;
            case (int)OperationTypes.Subtraction:
                Subtraction();
                break;
            case (int)OperationTypes.Multiplication:
                Multiplication();
                break;
            case (int)OperationTypes.Division:
                Division();
                break;
            case (int)OperationTypes.SquareRoot:
                SquareRoot();
                break;
            case (int)OperationTypes.Exit:
                Utility.LogoutProcess();
                Utility.PrintDotAnimation();
                Utility.PrintMessage("\nExiting was successful", true);
                Run();
                break;
            default:
                Utility.PrintMessage("Invalid Option. Please try again.", false);
                break;
        }
    }

    // Interface logic
    public void Addition()
    {
        Console.WriteLine("\nPICK TWO NUMBERS TO ADD");
        Console.Write("Enter first number: ");
        var a = double.Parse(Console.ReadLine());

        Console.Write("Enter second number: ");
        var b = double.Parse(Console.ReadLine());
        Console.WriteLine($"\n\tResult:--> {a + b}");
    }

    public void Subtraction()
    {
        Console.WriteLine("\nPICK TWO NUMBERS TO SUBTRACT");
        Console.Write("Enter first number: ");
        var a = double.Parse(Console.ReadLine());

        Console.Write("Enter second number: ");
        var b = double.Parse(Console.ReadLine());
        Console.WriteLine($"\n\tResult:--> {a - b}");
    }

    public void Multiplication()
    {
        Console.WriteLine("\nPICK TWO NUMBERS TO MULTIPLY");
        Console.Write("Enter first number: ");
        var a = double.Parse(Console.ReadLine());

        Console.Write("Enter second number: ");
        var b = double.Parse(Console.ReadLine());
        Console.WriteLine($"\n\tResult:--> {a * b}");
    }

    public void Division()
    {
        Console.WriteLine("\nPICK TWO NUMBERS TO DIVIDE");
        Console.Write("Enter first number: ");
        var a = double.Parse(Console.ReadLine());

        Console.Write("Enter second number: ");
        var b = double.Parse(Console.ReadLine());
        if (b == 0)
        {
            throw new DivideByZeroException();
        }

        Console.WriteLine($"\n\tResult:--> {a / b}");
    }

    public void SquareRoot()
    {
        Console.WriteLine("\nPICK A NUMBER TO GET IT'S SQUARE ROOT");
        Console.Write("Enter number: ");
        var a = double.Parse(Console.ReadLine());

        var b = Math.Sqrt(a);

        Console.WriteLine($"\n\tResult:--> {b}");
    }
}

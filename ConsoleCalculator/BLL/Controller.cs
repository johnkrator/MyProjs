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
        GetUserAction();
    }

    public static void GetUserAction()
    {
        AppScreen.DisplayUserAction();
        switch (Validator.Convert<int>("an option: "))
        {
            case (int)OperationTypes.Addition:
                Console.WriteLine("Addition");
                break;
            case (int)OperationTypes.Subtraction:
                Console.WriteLine("Subtraction");
                break;
            case (int)OperationTypes.Multiplication:
                Console.WriteLine("Multiplication");
                break;
            case (int)OperationTypes.Division:
                Console.WriteLine("Division");
                break;
            case (int)OperationTypes.SquareRoot:
                Console.WriteLine("SquareRoot");
                break;
            case (int)OperationTypes.Exit:
                Utility.PrintMessage("Exiting was successful", true);
                break;
            default:
                Utility.PrintMessage("Invalid Option. Please try again.", false);
                break;
        }
    }

    // Interface logic
    public void Addition()
    {
        throw new NotImplementedException();
    }

    public void Subtraction()
    {
        throw new NotImplementedException();
    }

    public void Multiplication()
    {
        throw new NotImplementedException();
    }

    public void Division()
    {
        throw new NotImplementedException();
    }

    public void SquareRoot()
    {
        throw new NotImplementedException();
    }
}

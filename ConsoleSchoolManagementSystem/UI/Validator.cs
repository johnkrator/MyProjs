using System.ComponentModel;

namespace UI;

public static class Validator
{
    public static T Convert<T>(string prompt)
    {
        var valid = false;
        string userInput;

        while (!valid)
        {
            userInput = Utility.GetUserInput(prompt);

            try
            {
                var converter = TypeDescriptor.GetConverter(typeof(T));
                if (converter != null)
                {
                    return (T)converter.ConvertFromString(userInput);
                }
                else
                {
                    return default;
                }
            }
            catch
            {
                Console.WriteLine();
                Utility.PrintMessage("Invlid Input. Try again", false);
            }
        }

        return default;
    }
}

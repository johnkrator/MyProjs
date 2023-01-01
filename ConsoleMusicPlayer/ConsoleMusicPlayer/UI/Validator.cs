using System;
using System.ComponentModel;

namespace ConsoleMusicPlayer.UI
{
    public class Validator
    {
        public static T Convert<T>(string prompt)
        {
            bool valid = false;
            string userInput;

            while (!valid)
            {
                userInput = Utility.GetUserInput(prompt);
                try
                {
                    var convert = TypeDescriptor.GetConverter(typeof(T));
                    if (convert != null)
                    {
                        return (T)convert.ConvertFromString(userInput);
                    }
                    else
                    {
                        return default;
                    }
                }
                catch
                {
                    Utility.PrintMessage("Invalid input. Please try again!", false);
                    throw;
                }
            }

            return default;
        }
    }
}

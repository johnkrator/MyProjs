using System;

namespace NoteTakingApp
{
    public class Display
    {
        private int options;

        public void DisplayOptions()
        {
            UserOperations userOperations = new UserOperations();

            do
            {
                Console.WriteLine(
                    "\n*****************************************\n" +
                    "Please select a command to continue: \n1. Add new notes\n2. Display notes added\n" +
                    "3. Update note\n4. Delete note\n5. Filter notes\n6. Exit\n" +
                    "*****************************************\n");
                options = int.Parse(Console.ReadLine());

                switch (options)
                {
                    case 1:
                        userOperations.AddNote();
                        break;
                    case 2:
                        userOperations.DisplayNotesAdded();
                        break;
                    case 3:
                        userOperations.UpdateNote();
                        break;
                    case 4:
                        userOperations.DeleteNote();
                        break;
                    case 5:
                        userOperations.FilterNotes();
                        break;
                    default:
                        if (options == 6)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid option. Choose between (1-5) for a valid response. Or 6 to exit.");
                        }

                        break;
                }
            } while (options != 6);
        }

        public void PrintMessage()
        {
            DisplayOptions();
        }
    }
}

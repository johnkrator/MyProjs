using System;

namespace ToDo
{
    public class DisplayScreen
    {        private int description;
        private Controller _controller = new Controller();

        public void CommandPrompts()
        {
            try
            {
                do
                {
                    Console.WriteLine(
                        "\nEnter a new task: \n1. Add task\n2. Update task\n3. Delete task\n4. Display tasks\n5. Exit app\n");
                    description = int.Parse(Console.ReadLine());

                    switch (description)
                    {
                        case 1:
                            _controller.AddTask();
                            break;
                        case 2:
                            _controller.UpdateTask();
                            break;
                        case 3:
                            _controller.DeleteTask();
                            break;
                        case 4:
                            _controller.ViewTask();
                            break;
                        default:
                            if (description == 5)
                            {
                                Console.WriteLine("Exiting now...");
                            }
                            else
                            {
                                Console.WriteLine(
                                    "Invalid entry. Please choose you options between (1-3). Enter 4 to exit the app.");
                            }

                            break;
                    }
                } while (description != 5);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void PrintMessage()
        {
            CommandPrompts();
        }
    }
}

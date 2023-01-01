using System;
using System.Collections.Generic;

namespace ToDo
{
    public class Controller
    {
        private List<string> tasks = new List<string>();

        public void AddTask()
        {
            try
            {
                Console.Write("\nEnter task description: ");
                var newTask = Console.ReadLine();
                tasks.Add(newTask);
                Console.WriteLine("\nNew task created successfully!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void UpdateTask()
        {
            try
            {
                Console.Write("\nEnter task index: ");
                var index = int.Parse(Console.ReadLine());
                Console.Write("Enter new task description: ");
                var updatedTask = Console.ReadLine();

                tasks[index] = updatedTask;
                Console.WriteLine("\nTask updated  🥰");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void DeleteTask()
        {
            try
            {
                Console.Write("Enter task index: ");
                var index = int.Parse(Console.ReadLine());
                tasks.RemoveAt(index);
                Console.WriteLine($"\nTask deleted successfully!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void ViewTask()
        {
            try
            {
                Console.WriteLine("\nHere are a list of your tasks: ");
                foreach (var task in tasks)
                {
                    Console.WriteLine($"-> {task}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}

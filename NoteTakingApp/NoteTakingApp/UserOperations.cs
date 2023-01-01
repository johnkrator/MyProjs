using System;
using System.Collections.Generic;

namespace NoteTakingApp
{
    public class UserOperations
    {
        private List<string> notes = new List<string>();

        public void AddNote()
        {
            try
            {
                Console.Write("Enter notes: ");
                var noteDescription = Console.ReadLine();

                notes.Add(noteDescription);
                Console.WriteLine(
                    "\n*****************************************\nNotes added successfully!\n*****************************************\n");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void DisplayNotesAdded()
        {
            // Display all the notes added in a descending order
            try
            {
                Console.WriteLine("Here are your notes:");
                foreach (var note in notes)
                {
                    Console.WriteLine($"-> \tNote: {note}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void UpdateNote()
        {
            // Use note id to update a note
            try
            {
                Console.Write("Enter the index of the note you wish to update: ");
                var index = int.Parse(Console.ReadLine());
                Console.Write("Enter the update note: ");
                var updatedNote = Console.ReadLine();
                notes[index] = updatedNote;
                Console.WriteLine($"\nNote with index at {index} has been updated successfully!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void DeleteNote()
        {
            // Use note id to delete a note
            try
            {
                Console.Write("Enter the note index: ");
                var index = int.Parse(Console.ReadLine());
                notes.RemoveAt(index);
                Console.WriteLine($"Note with index at {index} has been deleted successfully!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void FilterNotes()
        {
            // Use id and username to query note list
            try
            {
                Console.Write("Filter notes");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}

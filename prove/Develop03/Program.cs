using System;
using System.Collections.Generic;

namespace ScriptureProgram
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Scripture> scriptures = new List<Scripture>()
            {
                new Scripture("Psalm 27:10", "When my father and my mother forsake me, then the LORD will take care of me."),
                new Scripture("Jeremiah 32:27", "Behold, I am the LORD, the God of all flesh. Is anything too hard for me?"),
                new Scripture("Proverbs 16:3", "Commit your work to the LORD, and your plans will be established.")
            };

            foreach (var scripture in scriptures)
            {
                scripture.Display();
                scripture.PerformAction();
                while (true)
                {
                    Console.WriteLine("Press Enter to continue, 'hide' to hide a word, 'journal' to add a journal entry, 'view' to view journal entries, or 'quit' to exit: ");
                    string userInput = Console.ReadLine();
                    if (userInput == "quit")
                        return;
                    else if (userInput == "hide")
                    {
                        scripture.Hide();
                        scripture.Display();
                    }
                    else if (userInput == "journal")
                    {
                        Console.WriteLine("Enter your journal entry: ");
                        string entry = Console.ReadLine();
                        scripture.AddJournalEntry(entry);
                        scripture.DisplayJournalEntries();
                    }
                    else if (userInput == "view")
                    {
                        scripture.DisplayJournalEntries();
                    }
                    else
                    {
                        scripture.Display();
                    }
                }
            }
        }
    }
}

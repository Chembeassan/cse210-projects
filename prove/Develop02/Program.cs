using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello To My Journal World!");
        Journal journal = new Journal();

        while (true)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Set a reminder");
            Console.WriteLine("6. Display reminders");
            Console.WriteLine("7. Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter your response: ");
                    string response = Console.ReadLine();
                    string[] prompts = {
                        "Who was the most interesting person I interacted with today?",
                        "What was the best part of my day?",
                        "How did I see the hand of the Lord in my life today?",
                        "What was the strongest emotion I felt today?",
                        "If I had one thing I could do over today, what would it be?"
                    };
                    string prompt = prompts[new Random().Next(prompts.Length)];
                    journal.AddEntry(prompt, response);
                    Console.WriteLine("Entry added!\n");
                    break;
                case "2":
                    journal.DisplayEntries();
                    break;
                case "3":
                    Console.Write("Enter the file path to save the journal: ");
                    string saveFilePath = Console.ReadLine();
                    // Save the journal to a file
                    Console.WriteLine("Journal saved to file!\n");
                    break;
                case "4":
                    Console.Write("Enter the file path to load the journal: ");
                    string loadFilePath = Console.ReadLine();
                    // Load the journal from a file
                    Console.WriteLine("Journal loaded from file!\n");
                    break;
                case "5":
                    Console.Write("Enter the activity: ");
                    string activity = Console.ReadLine();
                    Console.Write("Enter the reminder date (YYYY-MM-DD HH:MM): ");
                    DateTime reminderDate = DateTime.Parse(Console.ReadLine());
                    Console.Write("Enter the reminder type: ");
                    string reminderType = Console.ReadLine();
                    journal.SetReminder(activity, reminderDate, reminderType);
                    Console.WriteLine("Reminder set!\n");
                    break;
                case "6":
                    journal.DisplayReminders();
                    break;
                case "7":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.\n");
                    break;
            }
        }
    }
}

using System;

class MainProgram
{
    static void Main()
    {
        Activity[] activities = new Activity[]
        {
            new ListingActivity("Listing", "Activity to list items", new string[] { "Who are people that you appreciate?", "What are personal strengths of yours?", "Who are people that you have helped this week?", "When have you felt the Holy Ghost this month?", "Who are some of your personal heroes?" }),
            new ReflectionActivity("Reflection", "Activity for reflection", new string[] { "Think of a time when you stood up for someone else.", "Think of a time when you did something really difficult.", "Think of a time when you helped someone in need.", "Think of a time when you did something truly selfless." }, new string[] { "Why was this experience meaningful to you?", "Have you ever done anything like this before?", "How did you get started?", "How did you feel when it was complete?", "What made this time different than other times when you were not as successful?", "What is your favorite thing about this experience?", "What could you learn from this experience that applies to other situations?", "What did you learn about yourself through this experience?", "How can you keep this experience in mind in the future?" }),
            new BreathingActivity("Breathing", "Activity for breathing"),
            new MoodBasedActivity("Mood", "Activity based on your mood", new string[] { "How are you feeling today?", "What is one thing that made you happy recently?", "Describe a challenging situation you faced recently.", "What is something that helps you relax?" })
        };

        while (true)
        {
            Console.WriteLine("Choose an activity to perform:");
            Console.WriteLine("1. Listing");
            Console.WriteLine("2. Reflection");
            Console.WriteLine("3. Breathing");
            Console.WriteLine("4. Mood");
            Console.WriteLine("0. Exit");

            int choice = int.Parse(Console.ReadLine());

            if (choice == 0)
                break;

            if (choice < 1 || choice > activities.Length)
            {
                Console.WriteLine("Invalid choice. Please try again.");
                continue;
            }

            Activity selectedActivity = activities[choice - 1];

            if (selectedActivity is MoodBasedActivity)
            {
                Console.WriteLine("How are you feeling today?");
                Console.WriteLine("1. Stressed");
                Console.WriteLine("2. Anxious");
                Console.WriteLine("3. Down");
                Console.WriteLine("4. Motivated");

                int moodSelection = int.Parse(Console.ReadLine());
                ((MoodBasedActivity)selectedActivity).PerformMoodBasedActivity(moodSelection);
            }
            else
            {
                selectedActivity.PerformActivity();
            }
        }

        Console.WriteLine("All activities completed. Press any key to exit.");
        Console.ReadKey();
    }
}

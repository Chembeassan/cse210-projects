using System;

public class BreathingActivity : Activity
{
    public BreathingActivity(string name, string description) : base(name, description, null)
    {
    }

    public override void PerformActivity()
    {
        Console.WriteLine($"Activity: {activityName}");
        Console.WriteLine($"Description: {activityDescription}");
        Console.WriteLine("------------------------------");

        Console.WriteLine("Please enter the duration of the activity in seconds:");
        duration = int.Parse(Console.ReadLine());

        Console.WriteLine($"Preparing for {activityName} activity...");
        DisplaySpinner(3);

        Console.WriteLine("Let's begin breathing...");
        int breathCount = duration / 2;

        for (int i = 0; i < breathCount; i++)
        {
            Console.WriteLine("Breathe in...");
            ShowCountdown(3);

            Console.WriteLine("Breathe out...");
            ShowCountdown(3);
        }

        Console.WriteLine("Good job! You have completed the breathing activity.");
        Console.WriteLine($"Duration: {duration} seconds");
        DisplaySpinner(3);
    }
}

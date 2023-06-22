using System;

public class ListingActivity : Activity
{
    private string[] prompts;

    public ListingActivity(string name, string description, string[] activityPrompts) : base(name, description, activityPrompts)
    {
        prompts = activityPrompts;
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

        Console.WriteLine("Let's begin listing...");
        string prompt = GetRandomPrompt();
        Console.WriteLine($"Prompt: {prompt}");
        ShowCountdown(3);
        Console.WriteLine("Think and start listing items:");
        int itemCount = GetItemCount();
        Console.WriteLine($"You listed {itemCount} items.");

        Console.WriteLine("Good job! You have completed the listing activity.");
        Console.WriteLine($"Duration: {duration} seconds");
        DisplaySpinner(3);
    }

    private string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(0, prompts.Length);
        return prompts[index];
    }

    private int GetItemCount()
    {
        int itemCount = 0;
        DateTime endTime = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            string item = Console.ReadLine();
            if (!string.IsNullOrEmpty(item))
                itemCount++;
        }

        return itemCount;
    }
}

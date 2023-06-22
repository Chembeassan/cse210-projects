using System;

public class ReflectionActivity : Activity
{
    private string[] prompts;
    private string[] reflectionQuestions;

    public ReflectionActivity(string name, string description, string[] activityPrompts, string[] questions) : base(name, description, activityPrompts)
    {
        prompts = activityPrompts;
        reflectionQuestions = questions;
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

        Console.WriteLine("Let's begin reflection...");

        string prompt = GetRandomPrompt();
        Console.WriteLine($"Prompt: {prompt}");
        ShowCountdown(3);

        foreach (string question in reflectionQuestions)
        {
            Console.WriteLine($"Question: {question}");
            DisplaySpinner(3);
        }

        Console.WriteLine("Good job! You have completed the reflection activity.");
        Console.WriteLine($"Duration: {duration} seconds");
        DisplaySpinner(3);
    }

    private string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(0, prompts.Length);
        return prompts[index];
    }
}

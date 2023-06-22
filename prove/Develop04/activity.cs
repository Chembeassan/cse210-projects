using System;
using System.Collections.Generic;
using System.Threading;

public abstract class Activity
{
    public string activityName;
    public string activityDescription;
    protected int duration = 0;

    public Activity(string name, string description, string[] prompts)
    {
        activityName = name;
        activityDescription = description;
        // Optionally, you can handle the 'prompts' array if needed.
    }

    public abstract void PerformActivity();

    protected void DisplaySpinner(int seconds)
    {
        List<string> animationStrings = new List<string>();
        animationStrings.Add("~");
        animationStrings.Add("\\");
        animationStrings.Add("-");
        animationStrings.Add("/");
        animationStrings.Add("~");
        animationStrings.Add("\\");
        animationStrings.Add("-");
        animationStrings.Add("/");

        foreach (string s in animationStrings)
        {
            Console.Write(s);
            Thread.Sleep(500);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }

    protected void DelayMilliseconds(int milliseconds)
    {
        Thread.Sleep(milliseconds);
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i} ");
            DelayMilliseconds(1000);
        }
        Console.WriteLine();
    }
}

using System;

namespace EternalQuest
{
    public class ChecklistGoal : Goal
    {
        public int BonusCount { get; set; }
        public int BonusValue { get; set; }
        public int Progress { get; set; }
        public new int Number { get; set; }
        public List<string> Tasks { get; set; } 

        public void IncrementProgress()
        {
            Progress++;
        }

public override void DisplayProgress()
{
    string status = IsCompleted ? "[X]" : "[ ]";
    Console.WriteLine($"Name: {Name}");
    Console.WriteLine($"Value: {Value}");
    Console.WriteLine($"Value: {BonusCount}");
    Console.WriteLine($"Progress: Completed {Progress}/{BonusCount} times");
    Console.WriteLine($"Status: {(IsCompleted ? "Completed" : "Incomplete")}");
    Console.WriteLine($"{Number + 1}. {status} {Name} - {Value} points");
}



public override void Complete()
{
    if (!IsCompleted)
    {
        IncrementProgress();
        if (Progress >= BonusCount)
        {
            Value += BonusValue;
            IsCompleted = true;
        }
    }
}

    }
}

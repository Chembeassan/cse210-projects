using System;

namespace EternalQuest
{
    public class SimpleGoal : Goal
    {
        public new string Description { get; set; }
    public new int Number { get; set; }
    public bool IsChecked { get; private set; }

    public void Check()
    {
        IsChecked = true;
    }

        public override void Complete()
        {
            if (!Completed)
            {
                Completed = true;
                Console.WriteLine($"Goal '{Name}' completed.");
                Console.WriteLine($"Congratulations! You earned {Value} points.");
            }
            else
            {
                Console.WriteLine("Goal already completed.");
            }
        }

        public override void DisplayProgress()
        {
            string status = Completed ? "[X]" : "[ ]";
            Console.WriteLine("Your goals are:");
            Console.WriteLine($"{Number + 1}. {status} {Name} - {Value} points");
        }
    }
}

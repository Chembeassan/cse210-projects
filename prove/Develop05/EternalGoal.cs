using System;

namespace EternalQuest
{
    public class EternalGoal : Goal
    {
        public new string Description { get; set; }
        public new int Number { get; set; }

        public override void Complete()
        {
            if (!Completed)
            {
                Completed = true;
                Console.WriteLine($"Goal '{Name}' completed.");
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
            Console.WriteLine($"{status} {Name} - {Value} points");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Points: {Value}");
            Console.WriteLine($"Status: {(Completed ? "Completed" : "Not Completed")}");
            Console.WriteLine($"{Number + 1 }. {status} {Name} - {Value} points");
        }
    }
}

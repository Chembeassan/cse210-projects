using System;

namespace EternalQuest
{
    public abstract class Goal
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public bool Completed { get; set; }
        public bool IsCompleted { get; set; }
        public int Number { get; set; }

        public abstract void Complete();
        public abstract void DisplayProgress();
        public string Description { get; set; }

        public int CompletedCount { get; set; }   // Added property
        public int TargetCount { get; set; }      // Added property
    }
}

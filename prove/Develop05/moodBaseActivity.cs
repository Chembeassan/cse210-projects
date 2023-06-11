using System;


class MoodBasedActivity : Activity
{
    public MoodBasedActivity(string name, string description, string[] prompts) : base(name, description, prompts)
    {
    }

    public override void PerformActivity()
    {
        // Implement the specific logic for the MoodBased activity here
    }

    public void PerformMoodBasedActivity(int moodSelection)
    {
        switch (moodSelection)
        {
            case 1:
                PerformStressManagementActivities();
                break;
            case 2:
                PerformEmotionalIntelligenceActivities();
                break;
            case 3:
                PerformResilienceBuildingActivities();
                break;
            case 4:
                PerformArtTherapyActivities();
                break;
            default:
                Console.WriteLine("Invalid mood selection. Please try again.");
                break;
        }
    }

    private void PerformStressManagementActivities()
    {
        Console.WriteLine("Performing stress management activities...");
        
        Console.WriteLine("Take a deep breath and count to 10.");
        Console.WriteLine("Go for a walk in nature.");
        Console.WriteLine("Listen to calming music.");
    }

    private void PerformEmotionalIntelligenceActivities()
    {
        Console.WriteLine("Performing emotional intelligence activities...");
        
        Console.WriteLine("Practice active listening in a conversation.");
        Console.WriteLine("Express gratitude to someone you appreciate.");
        Console.WriteLine("Engage in self-reflection and identify your emotions.");
    }

    private void PerformResilienceBuildingActivities()
    {
        Console.WriteLine("Performing resilience building activities...");

        Console.WriteLine("Set goals and create a plan to achieve them.");
        Console.WriteLine("Seek support from friends or a support group.");
        Console.WriteLine("Practice positive affirmations and self-talk.");
    }

    private void PerformArtTherapyActivities()
    {
        Console.WriteLine("Performing art therapy activities...");
        Console.WriteLine("Create a piece of artwork that represents your emotions.");
        Console.WriteLine("Engage in coloring or drawing to relax your mind.");
        Console.WriteLine("Write a poem or journal entry expressing your feelings.");
    }
}

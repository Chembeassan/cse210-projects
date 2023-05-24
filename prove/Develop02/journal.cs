class Journal
{
    private List<string> entries;
    private List<string> reminders;

    public Journal()
    {
        entries = new List<string>();
        reminders = new List<string>();
    }

    public void AddEntry(string prompt, string response)
    {
        string entry = $"{prompt}: {response}";
        entries.Add(entry);
    }

    public void DisplayEntries()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("The journal is empty.");
        }
        else
        {
            Console.WriteLine("Journal Entries:");
            foreach (string entry in entries)
            {
                Console.WriteLine(entry);
            }
        }
    }

    public void SetReminder(string activity, DateTime reminderDate, string reminderType)
    {
        string reminder = $"{activity} - {reminderType} ({reminderDate.ToString("yyyy-MM-dd HH:mm")})";
        reminders.Add(reminder);
    }

    public void DisplayReminders()
    {
        if (reminders.Count == 0)
        {
            Console.WriteLine("No reminders set.");
        }
        else
        {
            Console.WriteLine("Reminders:");
            foreach (string reminder in reminders)
            {
                Console.WriteLine(reminder);
            }
        }
    }
}


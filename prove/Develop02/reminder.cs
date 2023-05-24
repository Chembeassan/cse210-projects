using System;

class Reminder
{
    public string Activity {get; set; }
    public DateTime ReminderDate{get; set; }
    public string ReminderType{get; set; }

    public Reminder(string activity, DateTime reminderDate, string reminderType)
    {
        Activity = activity;
        ReminderDate = reminderDate;
        ReminderType = reminderType;
    }
}
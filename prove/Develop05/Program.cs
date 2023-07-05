using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;


namespace EternalQuest
{
    public class Program
    {
        private List<Goal> goals;
        private int points;
        private DailyInspirations dailyInspirations;

        public Program()
        {
            goals = new List<Goal>();
            points = 0;
            dailyInspirations = new DailyInspirations();
        }

        public void Start()
        {
            Console.WriteLine("Welcome to Eternal Quest!");
            DisplayPoints();

            bool quit = false;
            while (!quit)
            {
                Console.WriteLine();
                Console.WriteLine("Menu Options:");
                Console.WriteLine("1. Create a new goal");
                Console.WriteLine("2. List goals");
                Console.WriteLine("3. Save goals");
                Console.WriteLine("4. Load goals");
                Console.WriteLine("5. Record an event");
                Console.WriteLine("6. Get Daily Inspiration");
                Console.WriteLine("7. Quit");
                Console.WriteLine("Select an option:");

                string input = Console.ReadLine();
                Console.WriteLine();

                switch (input)
                {
                    case "1":
                        CreateGoal();
                        break;
                    case "2":
                        ListGoals();
                        break;
                    case "3":
                        SaveGoals();
                        break;
                    case "4":
                        LoadGoals();
                        break;
                    case "5":
                        RecordEvent();
                        break;
                    case "6":
                        GetDailyInspiration();
                        break;
                    case "7":
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }

            Console.WriteLine("Thank you for playing Eternal Quest!");
            DisplayPoints();
        }

        private void DisplayPoints()
        {
            Console.WriteLine($"You have {points} points.");
        }

        private void CreateGoal()
        {
            Console.WriteLine("Goal Type:");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");
            Console.WriteLine("Select a goal type:");

            string input = Console.ReadLine();
            Console.WriteLine();

            switch (input)
            {
                case "1":
                    CreateSimpleGoal();
                    break;
                case "2":
                    CreateEternalGoal();
                    break;
                case "3":
                    CreateChecklistGoal();
                    break;
                default:
                    Console.WriteLine("Invalid goal type. Please try again.");
                    break;
            }
        }

        public void CreateSimpleGoal()
        {
            Console.WriteLine("What is the name of your goal? ");
            string name = Console.ReadLine();

            Console.WriteLine("What is a short description of it?");
            string description = Console.ReadLine();

            Console.WriteLine("What is the amount of points associated with this goal? ");
            int value = GetIntegerInput();

            SimpleGoal goal = new SimpleGoal
            {
                Name = name,
                Value = value,
                Description = description
            };

            goals.Add(goal);

            Console.WriteLine("Simple Goal created successfully.");
            DisplayPoints();
        }

        public void CreateEternalGoal()
        {
            Console.WriteLine("What is the name of your goal? ");
            string name = Console.ReadLine();

            Console.WriteLine("What is a short description of it?");
            string description = Console.ReadLine();

            Console.WriteLine("What is the amount of points associated with this goal? ");
            int value = GetIntegerInput();

            EternalGoal goal = new EternalGoal
            {
                Name = name,
                Value = value,
                Description = description
            };

            goals.Add(goal);

            Console.WriteLine("Eternal Goal created successfully.");
            DisplayPoints();

        }

                public void CreateChecklistGoal()
        {
            Console.WriteLine("What is the name of your goal? ");
            string name = Console.ReadLine();

            Console.WriteLine("What is a short description of it?");
            string description = Console.ReadLine();

            Console.WriteLine("What is the amount of points associated with this goal? ");
            int value = GetIntegerInput();

            Console.WriteLine("Enter the number of times this goal needs to be accomplished for a bonus:");
            int bonusCount = GetIntegerInput();

            Console.WriteLine("Enter the bonus value for accomplishing the goal that many times:");
            int bonusValue = GetIntegerInput();

            ChecklistGoal goal = new ChecklistGoal
            {
                Name = name,
                Value = value,
                Description = description,
                BonusCount = bonusCount,
                BonusValue = bonusValue
            };

            goals.Add(goal);

            Console.WriteLine("Checklist Goal created successfully.");
            DisplayPoints();
        }

public void ListGoals()
{
    if (goals.Count == 0)
    {
        Console.WriteLine("No goals available.");
        return;
    }

    Console.WriteLine("The goals are:");

    for (int i = 0; i < goals.Count; i++)
    {
        string status = goals[i].IsCompleted ? "[X]" : "[ ]";
        int goalNumber = i + 1;

        
        
    if (goals[i] is ChecklistGoal checklistGoal && checklistGoal.Progress >= checklistGoal.BonusCount)
       {
            Console.WriteLine($" - Completed {checklistGoal.Progress}/{checklistGoal.BonusCount} times");
        }
        else
        {
        Console.WriteLine($"{goalNumber}. {status} {goals[i].Name} - ({goals[i].Description})");
        Console.WriteLine();
        }
    }
}


private void SaveGoals()
{
    if (goals.Count == 0)
    {
        Console.WriteLine("You have no goals to save.");
        return;
    }

    Console.WriteLine("Enter a filename to save the goals to: ");
    string filename = Console.ReadLine();

    try
    {
        string json = JsonSerializer.Serialize(goals);
        File.WriteAllText(filename, json);
        Console.WriteLine("Goals saved successfully.");
    }
    catch (Exception e)
    {
        Console.WriteLine("Error saving goals: " + e.Message);
    }
}

private void LoadGoals()
{
    Console.WriteLine("Enter the filename of the goals to load (without extension): ");
    string filename = Console.ReadLine();

    try
    {
        string[] supportedExtensions = { ".json", ".txt" };  // Add more supported extensions if needed

        string goalFile = null;
        foreach (string extension in supportedExtensions)
        {
            string filePath = filename + extension;
            if (File.Exists(filePath))
            {
                goalFile = filePath;
                break;
            }
        }

        if (goalFile == null)
        {
            Console.WriteLine("Goals file not found.");
            return;
        }

        string json = File.ReadAllText(goalFile);
        List<Goal> loadedGoals = JsonSerializer.Deserialize<List<Goal>>(json);
        goals = loadedGoals;
        Console.WriteLine("Goals loaded successfully.");
    }
    catch (Exception e)
    {
        Console.WriteLine("Error loading goals: " + e.Message);
    }
}

        public void RecordEvent()
        {
            if (goals.Count == 0)
            {
                Console.WriteLine("No goals available. Please load or add goals first.");
                return;
            }

            Console.WriteLine("Your Goals");
            Console.WriteLine("-------------");

            if (goals.Count == 0)
            {
                Console.WriteLine("No goals available.");
            }
            else
            {
                for (int i = 0; i < goals.Count; i++)
                {
                    string status = goals[i].IsCompleted ? "[X]" : "[ ]";
                    Console.WriteLine($"{i + 1}. {status} {goals[i].Name}");
                }
            }


            Console.WriteLine();
            Console.WriteLine("Which goal did you accomplish? (Enter the goal number):");
            int goalNumber;
            bool isValidGoalNumber = int.TryParse(Console.ReadLine(), out goalNumber);

            if (!isValidGoalNumber || goalNumber < 1 || goalNumber > goals.Count)
            {
                Console.WriteLine("Invalid goal number. Please try again.");
                return;
            }

            Goal goal = goals[goalNumber - 1];
            if (goal is EternalGoal)
            {
                Console.WriteLine("Eternal Goals cannot be completed or checked.");
                Console.WriteLine("Points will be added, but the goal will not be marked as completed.");
                points += goal.Value;
                Console.WriteLine($"You earned {goal.Value} points.");
                Console.WriteLine();
            }
            else if (goal.IsCompleted)
            {
                Console.WriteLine("Goal already completed.");
                Console.WriteLine();
            }
            else
            {
                goal.Complete();
                goal.IsCompleted = true;

                // Store the previous points value for comparison
                int previousPoints = points;

                // Increase points by the goal value
                points += goal.Value;

                // Check if points have increased after completing the goal
                if (points > previousPoints)
                {
                    // Play a sound effect or perform any other visual/audio effect
                    Console.WriteLine("Congratulations! Goal completed!");
                    Console.WriteLine($"You earned {goal.Value} points.");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Goal completed, but no points earned.");
                    Console.WriteLine();
                }

                 // Check if the goal is a checklist goal
       if (goal is ChecklistGoal checklistGoal)
        {
            if (checklistGoal.Progress >= checklistGoal.BonusCount)
            {
                Console.WriteLine($"Goal fully completed {checklistGoal.Progress}/{checklistGoal.BonusCount} times.");
                Console.WriteLine("Bonus achieved!");
                points += checklistGoal.BonusValue;
                Console.WriteLine($"You earned an additional {checklistGoal.BonusValue} points.");
            }
            else
            {
                 checklistGoal.Progress--;
                Console.WriteLine($"Goal completed {checklistGoal.Progress}/{checklistGoal.BonusCount} times.");
            }
        
                    if (goal is SimpleGoal simpleGoal)
                    {
                        simpleGoal.Check();
                        Console.WriteLine("Goal checked.");
                        Console.WriteLine();
                        string status = simpleGoal.IsChecked ? "[X]" : "[ ]";
                        Console.WriteLine($"{goalNumber}. {status} {goal.Name}");
                    }
                }
            }

            DisplayPoints();
        }
        private void GetDailyInspiration()
        {
            Console.WriteLine("Today's Daily Inspiration:");
            string inspiration = dailyInspirations.GetRandomInspiration();
            Console.WriteLine(inspiration);
        }

         private string GetGoalType(Goal goal)
        {
            if (goal is SimpleGoal simpleGoal)
            {
                return simpleGoal.Description;
            }
            else if (goal is EternalGoal eternalGoal)
            {
                return eternalGoal.Description;
            }
            else if (goal is ChecklistGoal checklistGoal)
            {
                return checklistGoal.Description;
            }
            else
            {
                return "Unknown Goal";
            }
        }

        private int GetIntegerInput()
        {
            int value;
            while (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer value.");
            }
            return value;
        }

        public static void Main(string[] args)
        {
            Program program = new Program();
            program.Start();
        }
    }
}

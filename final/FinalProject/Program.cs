using System;
using System.Collections.Generic;

namespace Farmer_s_Cooperative_Management_System
{
    class Program
    {
        private static List<Farmer> farmers;
        private static Dictionary<string, decimal> inventory;
        private static Assets totalAssets = new Assets("", 0, 0, 0);

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Farmer's Cooperative Management System!");

            farmers = new List<Farmer>();
            inventory = new Dictionary<string, decimal>();

            Run();

            Console.WriteLine("\nThank you for using the Farmer's Cooperative Management System!");
            Console.ReadLine();
        }

        static void Run()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("1. Register Farmer");
                Console.WriteLine("2. Manage Inventory");
                Console.WriteLine("3. Manage Assets");
                Console.WriteLine("4. Farming Selection");
                Console.WriteLine("5. Generate Summary Report");
                Console.WriteLine("6. Exit");

                int choice = GetMenuChoice(1, 6);

                switch (choice)
                {
                    case 1:
                        RegisterFarmer();
                        break;
                    case 2:
                        ManageInventory();
                        break;
                    case 3:
                        ManageAssets();
                        break;
                    case 4:
                        FarmingSelection();
                        break;
                    case 5:
                        GenerateSummaryReport();
                        break;
                    case 6:
                        exit = true;
                        break;
                }
            }
        }


        static void RegisterFarmer()
        {
            Console.WriteLine("Farmer Registration");
            Console.WriteLine("-------------------");

            string name = GetStringInput("Enter your name: ");
            string specialization = GetStringInput("Enter your farming specialization: ");
            string contactNumber = GetContactNumber();

            Farmer farmer = new Farmer(name, specialization, contactNumber);
            farmers.Add(farmer);

            Console.WriteLine("Registration successful!");
        }

        static string GetStringInput(string prompt)
        {
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine().Trim();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            } while (string.IsNullOrEmpty(input));

            return input;
        }

        static string GetContactNumber()
        {
            string contactNumber;
            while (true)
            {
                Console.Write("Enter your contact number: ");
                contactNumber = Console.ReadLine();

                if (IsValidContactNumber(contactNumber))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid contact number. Please enter a valid 10-digit number or press Enter to skip.");
                    string choice = Console.ReadLine();

                    if (string.IsNullOrEmpty(choice))
                    {
                        contactNumber = "N/A";
                        break;
                    }
                }
            }

            return contactNumber;
        }

        static bool IsValidContactNumber(string contactNumber)
        {
            return contactNumber.Length == 10 && long.TryParse(contactNumber, out _);
        }

        static void ManageInventory()
        {
            Console.WriteLine("Farm Inventory Management");
            Console.WriteLine("-------------------------");

            for (int i = 1; i <= 3; i++)
            {
                Console.Write($"Enter the inventory item you have on your farm {i}: ");
                string item = Console.ReadLine();

                decimal samplePrice = GetDecimalInput($"Enter the sample price for {item}: ");
                inventory.Add(item, samplePrice);
            }

            Console.WriteLine("\nInventory List:");
            foreach (var item in inventory)
            {
                Console.WriteLine($"{item.Key} - Sample Price: {item.Value:C}");
            }

            Console.WriteLine("Inventory updated successfully!");
        }

        static decimal GetDecimalInput(string fieldName)
        {
            decimal value;
            while (true)
            {
                Console.Write($"Enter your {fieldName}: ");
                string input = Console.ReadLine();

                if (decimal.TryParse(input, out value))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Invalid {fieldName}. Please enter a valid decimal value or press Enter to skip.");
                    string choice = Console.ReadLine();

                    if (string.IsNullOrEmpty(choice))
                    {
                        value = 0;
                        break;
                    }
                }
            }

            return value;
        }

        static void ManageAssets()
        {
            Console.WriteLine("\nAssets Management");
            Console.WriteLine("-----------------");

            Console.Write("Enter your farming specialization: ");
            string farmingSpecialization = Console.ReadLine();

            decimal cash = GetDecimalInput("How much cash do you have: ");
            decimal land = GetDecimalInput("How big is your farm in terms of land: ");
            decimal goodwill = GetDecimalInput("How much is your goodwill: ");

            decimal totalInventoryCost = 0;
            foreach (var item in inventory)
            {
                totalInventoryCost += item.Value;
            }

            decimal totalCashAcrossFarmers = cash + totalInventoryCost;

            Console.WriteLine("\nFarm Data Summary Report");
            Console.WriteLine("------------------------");
            Console.WriteLine($"Total farmers registered: {farmers.Count}");
            Console.WriteLine($"Total cash across all farmers: ${totalCashAcrossFarmers:F2}");
            Console.WriteLine($"Total land across all farmers in acres: {land:F2} acres");
            Console.WriteLine($"Total goodwill across all farmers: ${goodwill:F2}");

            totalAssets.FarmingSpecialization = farmingSpecialization;
            totalAssets.Cash = cash;
            totalAssets.Land = land;
            totalAssets.Goodwill = goodwill + totalInventoryCost;
        }

        static int GetMenuChoice(int min, int max)
        {
            int choice;
            while (true)
            {
                Console.Write("Enter your choice: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out choice) && choice >= min && choice <= max)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid choice.");
                }
            }

            return choice;
        }

        static void FarmingSelection()
        {
            Console.WriteLine("\nChoose the type of farming you want to explore:");
            Console.WriteLine("\nThese are the types of farming that the cooperative is supporting for the youth:");
            Console.WriteLine("1. Poultry Farming");
            Console.WriteLine("2. Fish Farming");
            Console.WriteLine("3. Vegetable Farming");

            int choice = GetMenuChoice(1, 3);
            string farmingType = string.Empty;

            if (choice == 1)
            {
                farmingType = "Poultry Farming";
            }
            else if (choice == 2)
            {
                farmingType = "Fish Farming";
            }
            else if (choice == 3)
            {
                farmingType = "Vegetable Farming";
            }

            Console.WriteLine($"\nSelected Farming Type: {farmingType}");
            Console.WriteLine("Inventory Items:");

            List<FarmProduct> inventoryItems = GetInventoryItems(farmingType);

            DisplayInventoryItems(inventoryItems);
            Console.WriteLine();

            BusinessPlan businessPlan = new BusinessPlan();
            businessPlan.Generate(farmingType, inventoryItems);
        }

        static List<FarmProduct> GetInventoryItems(string farmingType)
        {
            List<FarmProduct> inventoryItems = new List<FarmProduct>();

            if (farmingType == "Poultry Farming")
            {
                inventoryItems.Add(new Feed("Chicken Feed", 10.0m));
                inventoryItems.Add(new Medication("Vaccine", 5.0m));
                inventoryItems.Add(new Equipment("Incubator", 50.0m));
            }
            else if (farmingType == "Fish Farming")
            {
                inventoryItems.Add(new Feed("Fish Feed", 8.0m));
                inventoryItems.Add(new Medication("Medication", 4.0m));
                inventoryItems.Add(new Equipment("Aquarium", 30.0m));
            }
            else if (farmingType == "Vegetable Farming")
            {
                inventoryItems.Add(new Feed("Fertilizer", 6.0m));
                inventoryItems.Add(new Medication("Pesticide", 3.0m));
                inventoryItems.Add(new Equipment("Gardening Tools", 20.0m));
            }

            return inventoryItems;
        }

        static void DisplayInventoryItems(List<FarmProduct> items)
        {
            Console.WriteLine("\nInventory Items:");

            foreach (FarmProduct item in items)
            {
                Console.WriteLine($"- {item.Name}: ${item.SamplePrice}");
            }
        }

        static void GenerateSummaryReport()
        {
            Console.WriteLine("\nFarm Data Summary Report");
            Console.WriteLine("------------------------");
            Console.WriteLine($"Total farmers registered: {farmers.Count}");
            Console.WriteLine($"Total cash across all farmers: ${totalAssets.TotalCash:F2}");
            Console.WriteLine($"Total land across all farmers in acres: {totalAssets.TotalLand:F2} acres");
            Console.WriteLine($"Total goodwill across all farmers: ${totalAssets.TotalGoodwill:F2}");
        }
    }
}

using System;
using System.Collections.Generic;

namespace Farmer_s_Cooperative_Management_System
{
    class Farmer
    {
        private string Name { get; set; }
         public string Specialization { get; set; }
        private string ContactNumber { get; set; }
        private List<FarmProduct> Inventory { get; set; }

        public Farmer(string name, string specialization, string contactNumber)
        {
            Name = name;
            Specialization = specialization;
            ContactNumber = contactNumber;
            Inventory = new List<FarmProduct>();
        }

        public void UpdateInventory(FarmProduct product, int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                Inventory.Add(product);
            }
        }

        public void DisplayInformation()
        {
            Console.WriteLine("+-------------------------+");
            Console.WriteLine("|         Farmer          |");
            Console.WriteLine("+-------------------------+");
            Console.WriteLine($"| - Name: {Name,-18} |");
            Console.WriteLine($"| - Specialization: {Specialization,-10} |");
            Console.WriteLine($"| - ContactNumber: {ContactNumber,-14} |");
            Console.WriteLine("+-------------------------+");
        }
    }
}

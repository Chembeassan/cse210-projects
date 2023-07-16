using System;

namespace Farmer_s_Cooperative_Management_System
{
    class Assets
    {
        public string CurrentFarmingSpecialization { get; set; }
        public string FarmingSpecialization { get; set; }
        public decimal Cash { get; set; }
        public decimal Land { get; set; }
        public decimal Goodwill { get; set; }

        public Assets(string farmingSpecialization, decimal cash, decimal land, decimal goodwill)
        {
            CurrentFarmingSpecialization = farmingSpecialization;
            Cash = cash;
            Land = land;
            Goodwill = goodwill;
        }

        public void DisplayAssets()
        {
            Console.WriteLine("\nAssets:");
            Console.WriteLine($"Current Farming Specialization: {CurrentFarmingSpecialization}");
            Console.WriteLine($"Cash: {Cash}");
            Console.WriteLine($"Land: {Land}");
            Console.WriteLine($"Goodwill: {Goodwill}");
        }
    }
}

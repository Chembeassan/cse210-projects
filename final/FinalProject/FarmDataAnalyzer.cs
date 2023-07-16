using System;
using System.Collections.Generic;
using System.Linq;

namespace Farmer_s_Cooperative_Management_System
{
    class FarmDataAnalyzer
    {
        private List<Farmer> farmers;
        private List<Assets> assetsList;

        public FarmDataAnalyzer(List<Farmer> farmers, List<Assets> assetsList)
        {
            this.farmers = farmers;
            this.assetsList = assetsList;
        }

        public void GenerateSummaryReport()
{
    Console.WriteLine("Farm Data Summary Report");
    Console.WriteLine("------------------------");

    Console.WriteLine($"Total farmers registered: {farmers.Count}");

    decimal totalCash = assetsList.Sum(a => a.Cash);
    decimal totalLand = assetsList.Sum(a => a.Land);
    decimal totalGoodwill = assetsList.Sum(a => a.Goodwill);

    Console.WriteLine($"Total cash across all farmers: {totalCash:C}");
    Console.WriteLine($"Total land across all farmers: {totalLand:N2} acres");
    Console.WriteLine($"Total goodwill across all farmers: {totalGoodwill:C}");

    Console.WriteLine();

    var farmingSpecializations = farmers.Select(f => f.Specialization).Distinct();
    foreach (var specialization in farmingSpecializations)
    {
        int farmerCount = farmers.Count(f => f.Specialization == specialization);
        var assetsWithSpecialization = assetsList.Where(a => a.FarmingSpecialization == specialization).ToList();

        Console.WriteLine($"Farming Specialization: {specialization}");
        Console.WriteLine($"Number of farmers: {farmerCount}");

        if (farmerCount > 0)
        {
            if (assetsWithSpecialization.Count > 0)
            {
                decimal averageCash = assetsWithSpecialization.Average(a => a.Cash);
                Console.WriteLine($"Average cash: {averageCash:C}");
            }
            else
            {
                Console.WriteLine("No assets recorded for this specialization.");
            }
        }
        else
        {
            Console.WriteLine("No farmers with this specialization.");
        }

        Console.WriteLine();
    }
}

    }
}

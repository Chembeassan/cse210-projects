using System;
using System.Collections.Generic;
using System.IO;

namespace Farmer_s_Cooperative_Management_System
{
    class BusinessPlan
    {
        public void Generate(string farmingType, List<FarmProduct> inventoryItems)
        {
            Console.WriteLine("\n Welcome to my Business plan!!");
            Console.WriteLine("Business Plan for Poultry, Fish, and Vegetable Farming");

            Console.WriteLine("\n1. Executive Summary:");
            Console.WriteLine("Provide an overview of your farming business, including the products (poultry, fish, vegetables) you plan to produce, your target market, and the goals and objectives of your business.");

            Console.WriteLine("\n2. Business Description:");
            Console.WriteLine("Describe your farming operations in detail. Include information about the size and location of your farm, the production capacity, the type of poultry (e.g., broilers, layers), fish species, and vegetable crops you intend to raise, and any unique selling points or advantages your farm offers.");

            Console.WriteLine("\n3. Market Analysis:");
            Console.WriteLine("Conduct a comprehensive analysis of the market for your poultry, fish, and vegetables. Identify your target customers, their preferences, and demand trends. Assess the competition and explain how your farm will differentiate itself in the market.");

            Console.WriteLine($"\n4. Products and Services ({farmingType}):");

            if (farmingType == "Poultry Farming")
            {
                Console.WriteLine("\n4.1 Poultry Farming:");
                Console.WriteLine("For poultry farming, we plan to raise high-quality broilers and layers. We will implement best practices in poultry farming, ensuring the birds are healthy and well-cared for. Our poultry products will meet the highest quality standards and we aim to obtain organic certification.");
            }
            else if (farmingType == "Fish Farming")
            {
                Console.WriteLine("\n4.2 Fish Farming:");
                Console.WriteLine("In fish farming, we will focus on raising freshwater fish species such as tilapia and catfish. Our fish will be grown in clean and controlled environments, providing optimal conditions for their growth. We will prioritize sustainable practices and strive to achieve certification for responsible aquaculture.");
            }
            else if (farmingType == "Vegetable Farming")
            {
                Console.WriteLine("\n4.3 Vegetable Farming:");
                Console.WriteLine("For vegetable farming, we will cultivate a diverse range of high-quality vegetables. Our farming methods will emphasize organic and sustainable practices, minimizing the use of chemicals and pesticides. We will offer a variety of seasonal vegetables and aim to meet the increasing demand for locally grown, fresh produce.");
            }

            Console.WriteLine("\n5. Marketing and Sales Strategy:");
            Console.WriteLine("Outline your strategies for promoting and selling your products. Describe your pricing strategy, distribution channels (e.g., direct sales to consumers, farmers markets, local retailers), and marketing tactics (e.g., advertising, social media, partnerships). Explain how you will reach your target customers and build brand awareness.");

            Console.WriteLine("\n6. Operations and Management:");
            Console.WriteLine("Explain the day-to-day operations of your farm. Describe the farm layout, infrastructure, and equipment needed for poultry housing, fish farming, and vegetable cultivation. Detail the staffing requirements, including any specialized skills or expertise required. Outline your production processes, feeding protocols, and quality control measures.");

            Console.WriteLine("\n7. Financial Projections:");
            Console.WriteLine("Present financial forecasts for your farm. Include projected revenue and sales volume for each product category, as well as anticipated costs such as feed, seed, equipment, labor, and marketing expenses. Develop a cash flow statement, balance sheet, and income statement for at least the first three years of your operation. Discuss your break-even point and the return on investment (ROI) you expect.");

            Console.WriteLine("\n8. Risk Assessment:");
            Console.WriteLine("Identify potential risks and challenges that could impact your farming business. This may include disease outbreaks, extreme weather events, price volatility, regulatory changes, or market fluctuations. Develop contingency plans to mitigate these risks and explain how you will adapt to unforeseen circumstances.");

            Console.WriteLine("\n9. Sustainability and Environmental Impact:");
            Console.WriteLine("Discuss your commitment to sustainable farming practices. Explain how you will manage waste, conserve water and energy, and minimize the use of chemicals or pesticides. Highlight any certifications or eco-friendly initiatives you plan to implement.");

            Console.WriteLine("\n10. Appendices:");
            Console.WriteLine("Include any supporting documents or additional information relevant to your business plan, such as market research data, permits or licenses, resumes of key team members, supplier agreements, or partnership contracts.");

            Console.WriteLine($"\nSelected Farming Type: {farmingType}");
            
            // Display inventory items
            DisplayInventoryItems(inventoryItems);

            // Prompt user to save the business plan
            Console.WriteLine("\nWould you like to save the business plan? (Y/N)");
            string choice = Console.ReadLine();

            if (choice.ToUpper() == "Y")
            {
                Console.WriteLine("\nPlease enter the file format for saving (TXT/CSV):");
                string fileFormat = Console.ReadLine();

                SaveBusinessPlan(farmingType, inventoryItems, fileFormat);
            }
        }

        private void SaveBusinessPlan(string farmingType, List<FarmProduct> inventoryItems, string fileFormat)
        {
            string fileName = $"BusinessPlan_{farmingType}.{fileFormat}";

            if (fileFormat.ToUpper() == "TXT")
            {
                SaveAsText(fileName, farmingType, inventoryItems);
            }
            else if (fileFormat.ToUpper() == "CSV")
            {
                SaveAsCSV(fileName, farmingType, inventoryItems);
            }
            else
            {
                Console.WriteLine("Invalid file format. Business plan not saved.");
            }
        }

        private void SaveAsText(string fileName, string farmingType, List<FarmProduct> inventoryItems)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    writer.WriteLine("\nWelcome to my Business plan!!");
                    writer.WriteLine("Business Plan for Poultry, Fish, and Vegetable Farming");
                    writer.WriteLine();
                    writer.WriteLine("1. Executive Summary:");
                    writer.WriteLine("Provide an overview of your farming business, including the products (poultry, fish, vegetables) you plan to produce, your target market, and the goals and objectives of your business.");
                    writer.WriteLine();
                    writer.WriteLine("2. Business Description:");
                    writer.WriteLine("Describe your farming operations in detail. Include information about the size and location of your farm, the production capacity, the type of poultry (e.g., broilers, layers), fish species, and vegetable crops you intend to raise, and any unique selling points or advantages your farm offers.");
                    writer.WriteLine();
                    writer.WriteLine("3. Market Analysis:");
                    writer.WriteLine("Conduct a comprehensive analysis of the market for your poultry, fish, and vegetables. Identify your target customers, their preferences, and demand trends. Assess the competition and explain how your farm will differentiate itself in the market.");
                    writer.WriteLine();

                    // Based on the farming type, display the corresponding section
                    if (farmingType == "Poultry Farming")
                    {
                        writer.WriteLine("\n4.1 Poultry Farming:");
                        writer.WriteLine("For poultry farming, we plan to raise high-quality broilers and layers. We will implement best practices in poultry farming, ensuring the birds are healthy and well-cared for. Our poultry products will meet the highest quality standards and we aim to obtain organic certification.");
                    }
                    else if (farmingType == "Fish Farming")
                    {
                        writer.WriteLine("\n4.2 Fish Farming:");
                        writer.WriteLine("In fish farming, we will focus on raising freshwater fish species such as tilapia and catfish. Our fish will be grown in clean and controlled environments, providing optimal conditions for their growth. We will prioritize sustainable practices and strive to achieve certification for responsible aquaculture.");
                    }
                    else if (farmingType == "Vegetable Farming")
                    {
                        writer.WriteLine("\n4.3 Vegetable Farming:");
                        writer.WriteLine("For vegetable farming, we will cultivate a diverse range of high-quality vegetables. Our farming methods will emphasize organic and sustainable practices, minimizing the use of chemicals and pesticides. We will offer a variety of seasonal vegetables and aim to meet the increasing demand for locally grown, fresh produce.");
                    }

                    writer.WriteLine();
                    writer.WriteLine("5. Marketing and Sales Strategy:");
                    writer.WriteLine("Outline your strategies for promoting and selling your products. Describe your pricing strategy, distribution channels (e.g., direct sales to consumers, farmers markets, local retailers), and marketing tactics (e.g., advertising, social media, partnerships). Explain how you will reach your target customers and build brand awareness.");
                    writer.WriteLine();
                    writer.WriteLine("6. Operations and Management:");
                    writer.WriteLine("Explain the day-to-day operations of your farm. Describe the farm layout, infrastructure, and equipment needed for poultry housing, fish farming, and vegetable cultivation. Detail the staffing requirements, including any specialized skills or expertise required. Outline your production processes, feeding protocols, and quality control measures.");
                    writer.WriteLine();
                    writer.WriteLine("7. Financial Projections:");
                    writer.WriteLine("Present financial forecasts for your farm. Include projected revenue and sales volume for each product category, as well as anticipated costs such as feed, seed, equipment, labor, and marketing expenses. Develop a cash flow statement, balance sheet, and income statement for at least the first three years of your operation. Discuss your break-even point and the return on investment (ROI) you expect.");
                    writer.WriteLine();
                    writer.WriteLine("8. Risk Assessment:");
                    writer.WriteLine("Identify potential risks and challenges that could impact your farming business. This may include disease outbreaks, extreme weather events, price volatility, regulatory changes, or market fluctuations. Develop contingency plans to mitigate these risks and explain how you will adapt to unforeseen circumstances.");
                    writer.WriteLine();
                    writer.WriteLine("9. Sustainability and Environmental Impact:");
                    writer.WriteLine("Discuss your commitment to sustainable farming practices. Explain how you will manage waste, conserve water and energy, and minimize the use of chemicals or pesticides. Highlight any certifications or eco-friendly initiatives you plan to implement.");
                    writer.WriteLine();
                    writer.WriteLine("10. Appendices:");
                    writer.WriteLine("Include any supporting documents or additional information relevant to your business plan, such as market research data, permits or licenses, resumes of key team members, supplier agreements, or partnership contracts.");
                    writer.WriteLine();

                    writer.WriteLine("\nSample Cost for selected Farming:");
                    writer.WriteLine($"\nSelected Farming Type: {farmingType}");

                    // Display inventory items
                    writer.WriteLine("\nInventory Items:");
                    foreach (FarmProduct item in inventoryItems)
                    {
                        writer.WriteLine($"- {item.Name}: ${item.SamplePrice}");
                    }
                }

                Console.WriteLine($"Business plan saved as {fileName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while saving the business plan: {ex.Message}");
            }
        }

        private void SaveAsCSV(string fileName, string farmingType, List<FarmProduct> inventoryItems)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    writer.WriteLine("Welcome to my Business plan!!");
                    writer.WriteLine("Business Plan for Poultry, Fish, and Vegetable Farming");
                    writer.WriteLine();
                    writer.WriteLine("1. Executive Summary:");
                    writer.WriteLine("Provide an overview of your farming business, including the products (poultry, fish, vegetables) you plan to produce, your target market, and the goals and objectives of your business.");
                    writer.WriteLine();
                    writer.WriteLine("2. Business Description:");
                    writer.WriteLine("Describe your farming operations in detail. Include information about the size and location of your farm, the production capacity, the type of poultry (e.g., broilers, layers), fish species, and vegetable crops you intend to raise, and any unique selling points or advantages your farm offers.");
                    writer.WriteLine();
                    writer.WriteLine("3. Market Analysis:");
                    writer.WriteLine("Conduct a comprehensive analysis of the market for your poultry, fish, and vegetables. Identify your target customers, their preferences, and demand trends. Assess the competition and explain how your farm will differentiate itself in the market.");
                    writer.WriteLine();

                    // Based on the farming type, display the corresponding section
                    if (farmingType == "Poultry Farming")
                    {
                        writer.WriteLine("\n4.1 Poultry Farming:");
                        writer.WriteLine("For poultry farming, we plan to raise high-quality broilers and layers. We will implement best practices in poultry farming, ensuring the birds are healthy and well-cared for. Our poultry products will meet the highest quality standards and we aim to obtain organic certification.");
                    }
                    else if (farmingType == "Fish Farming")
                    {
                        writer.WriteLine("\n4.2 Fish Farming:");
                        writer.WriteLine("In fish farming, we will focus on raising freshwater fish species such as tilapia and catfish. Our fish will be grown in clean and controlled environments, providing optimal conditions for their growth. We will prioritize sustainable practices and strive to achieve certification for responsible aquaculture.");
                    }
                    else if (farmingType == "Vegetable Farming")
                    {
                        writer.WriteLine("\n4.3 Vegetable Farming:");
                        writer.WriteLine("For vegetable farming, we will cultivate a diverse range of high-quality vegetables. Our farming methods will emphasize organic and sustainable practices, minimizing the use of chemicals and pesticides. We will offer a variety of seasonal vegetables and aim to meet the increasing demand for locally grown, fresh produce.");
                    }

                    writer.WriteLine();
                    writer.WriteLine("5. Marketing and Sales Strategy:");
                    writer.WriteLine("Outline your strategies for promoting and selling your products. Describe your pricing strategy, distribution channels (e.g., direct sales to consumers, farmers markets, local retailers), and marketing tactics (e.g., advertising, social media, partnerships). Explain how you will reach your target customers and build brand awareness.");
                    writer.WriteLine();
                    writer.WriteLine("6. Operations and Management:");
                    writer.WriteLine("Explain the day-to-day operations of your farm. Describe the farm layout, infrastructure, and equipment needed for poultry housing, fish farming, and vegetable cultivation. Detail the staffing requirements, including any specialized skills or expertise required. Outline your production processes, feeding protocols, and quality control measures.");
                    writer.WriteLine();
                    writer.WriteLine("7. Financial Projections:");
                    writer.WriteLine("Present financial forecasts for your farm. Include projected revenue and sales volume for each product category, as well as anticipated costs such as feed, seed, equipment, labor, and marketing expenses. Develop a cash flow statement, balance sheet, and income statement for at least the first three years of your operation. Discuss your break-even point and the return on investment (ROI) you expect.");
                    writer.WriteLine();
                    writer.WriteLine("8. Risk Assessment:");
                    writer.WriteLine("Identify potential risks and challenges that could impact your farming business. This may include disease outbreaks, extreme weather events, price volatility, regulatory changes, or market fluctuations. Develop contingency plans to mitigate these risks and explain how you will adapt to unforeseen circumstances.");
                    writer.WriteLine();
                    writer.WriteLine("9. Sustainability and Environmental Impact:");
                    writer.WriteLine("Discuss your commitment to sustainable farming practices. Explain how you will manage waste, conserve water and energy, and minimize the use of chemicals or pesticides. Highlight any certifications or eco-friendly initiatives you plan to implement.");
                    writer.WriteLine();
                    writer.WriteLine("10. Appendices:");
                    writer.WriteLine("Include any supporting documents or additional information relevant to your business plan, such as market research data, permits or licenses, resumes of key team members, supplier agreements, or partnership contracts.");
                    writer.WriteLine();

                    writer.WriteLine("\nSample Cost for selected Farming:");
                    writer.WriteLine($"\nSelected Farming Type: {farmingType}");

                    // Display inventory items
                    writer.WriteLine("\nInventory Items:");
                    foreach (FarmProduct item in inventoryItems)
                    {
                        writer.WriteLine($"{item.Name}: {item.SamplePrice}");
                    }
                }

                Console.WriteLine($"Business plan saved as {fileName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while saving the business plan: {ex.Message}");
            }
        }

        private void DisplayInventoryItems(List<FarmProduct> items)
        {
            Console.WriteLine("\nInventory Items:");

            foreach (FarmProduct item in items)
            {
                Console.WriteLine($"- {item.Name}: ${item.SamplePrice}");
            }
        }
    }
}

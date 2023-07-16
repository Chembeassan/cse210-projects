using System;

namespace Farmer_s_Cooperative_Management_System
{
    abstract class FarmProduct
    {
        public string Name { get; }
        public decimal SamplePrice { get; }

        public FarmProduct(string name, decimal samplePrice)
        {
            Name = name;
            SamplePrice = samplePrice;
        }

        public abstract void Display();
    }
}

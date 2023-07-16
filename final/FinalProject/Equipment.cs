using System;

namespace Farmer_s_Cooperative_Management_System
{
    class Equipment : FarmProduct
    {
        public Equipment(string name, decimal samplePrice) : base(name, samplePrice)
        {
        }

        public override void Display()
        {
            Console.WriteLine($"- {Name}: ${SamplePrice}");
        }
    }
}

using System;

namespace Farmer_s_Cooperative_Management_System
{
    class Feed : FarmProduct
    {
        public Feed(string name, decimal samplePrice) : base(name, samplePrice)
        {
        }

        public override void Display()
        {
            Console.WriteLine($"- {Name}: ${SamplePrice}");
        }
    }
}

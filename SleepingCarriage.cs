using Laba;

namespace Laba2
{

    public class SleepingCarriage : Carriage
    {
        public int CompartmentsCount { get; set; }
        public bool HasShowers { get; set; }

        public SleepingCarriage(double weight, double length, int compartmentsCount, bool hasShowers)
            : base("Sleeping", weight, length)
        {
            CompartmentsCount = compartmentsCount;
            HasShowers = hasShowers;
        }

        public override string ToString()
        {
            return base.ToString() + $", Кількість купе: {CompartmentsCount}, Наявність душових: {HasShowers}";
        }
    }
}

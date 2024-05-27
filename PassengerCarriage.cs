using Laba;

namespace Laba2
{

    public class PassengerCarriage : Carriage
    {
        public int SeatsCount { get; set; }
        public string ComfortLevel { get; set; }

        public PassengerCarriage(double weight, double length, int seatsCount, string comfortLevel)
            : base("Passenger", weight, length)
        {
            SeatsCount = seatsCount;
            ComfortLevel = comfortLevel;
        }

        public override string ToString()
        {
            return base.ToString() + $", Кількість місць: {SeatsCount}, Рівень комфорту: {ComfortLevel}";
        }
    }
}

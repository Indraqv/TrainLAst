using Laba;

namespace Laba2
{

    public class FreightCarriage : Carriage
    {
        public double MaxLoadCapacity { get; set; }
        public string CargoType { get; set; }

        public FreightCarriage(double weight, double length, double maxLoadCapacity, string cargoType)
            : base("Freight", weight, length)
        {
            MaxLoadCapacity = maxLoadCapacity;
            CargoType = cargoType;
        }

        public override string ToString()
        {
            return base.ToString() + $", Макс. вантажопідйомність: {MaxLoadCapacity}т, Тип вантажу: {CargoType}";
        }
    }
}

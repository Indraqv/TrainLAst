using Laba;

namespace Laba2
{

    public class DiningCarriage : Carriage
    {
        public int TablesCount { get; set; }
        public bool HasKitchen { get; set; }

        public DiningCarriage(double weight, double length, int tablesCount, bool hasKitchen)
            : base("Dining", weight, length)
        {
            TablesCount = tablesCount;
            HasKitchen = hasKitchen;
        }

        public override string ToString()
        {
            return base.ToString() + $", Кількість столів: {TablesCount}, Наявність кухні: {HasKitchen}";
        }
    }
}

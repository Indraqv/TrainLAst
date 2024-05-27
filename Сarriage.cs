using System;

namespace Laba
{

    public class Carriage
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public double Weight { get; set; }
        public double Length { get; set; }

        public Carriage(string type, double weight, double length)
        {
            Id = Guid.NewGuid();
            Type = type;
            Weight = weight;
            Length = length;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Тип: {Type}, Вага: {Weight}т, Довжина: {Length}м";
        }
    }
}

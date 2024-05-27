using Laba;
using Laba2;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Laba2
{

    public class Train
    {
        public LinkedList<Carriage> Carriages { get; set; }
        public string Name { get; set; }
        public string RouteNumber { get; set; }

        public Train(string name, string routeNumber)
        {
            Name = name;
            RouteNumber = routeNumber;
            Carriages = new LinkedList<Carriage>();
        }

        public bool AddCarriage(Carriage carriage, int? position = null)
        {
            if (Carriages.Any(c => c.Id == carriage.Id))
            {
                Console.WriteLine("Вагон з таким самим ID вже існує.");
                return false;
            }

            if (Carriages.Count > 0)
            {
                var existingType = Carriages.First.Value.Type;
                if (existingType != carriage.Type)
                {
                    Console.WriteLine("Не можна змішувати пасажирські та вантажні вагони в одному потязі.");
                    return false;
                }
            }

            if (position == null || position >= Carriages.Count)
            {
                Carriages.AddLast(carriage);
            }
            else
            {
                var node = Carriages.First;
                for (int i = 0; i < position; i++)
                {
                    node = node.Next;
                }
                Carriages.AddBefore(node, carriage);
            }
            return true;
        }

        public void RemoveCarriage(int? position = null)
        {
            if (position == null || position >= Carriages.Count - 1)
            {
                Carriages.RemoveLast();
            }
            else
            {
                var node = Carriages.First;
                for (int i = 0; i < position; i++)
                {
                    node = node.Next;
                }
                Carriages.Remove(node);
            }
        }

        public IEnumerable<Carriage> SearchCarriages(Func<Carriage, bool> criteria)
        {
            return Carriages.Where(criteria);
        }

        public IEnumerable<Carriage> FilterByType(string type)
        {
            return Carriages.Where(c => c.Type == type);
        }

        public IEnumerable<FreightCarriage> FilterByMaxLoadCapacity(double capacity)
        {
            return Carriages.OfType<FreightCarriage>().Where(c => c.MaxLoadCapacity >= capacity);
        }

        public IEnumerable<PassengerCarriage> FilterBySeatsCount(int seatsCount)
        {
            return Carriages.OfType<PassengerCarriage>().Where(c => c.SeatsCount >= seatsCount);
        }

        public double CalculateTotalWeight()
        {
            return Carriages.Sum(c => c.Weight);
        }

        public int CalculateTotalPassengerSeats()
        {
            return Carriages.OfType<PassengerCarriage>().Sum(c => c.SeatsCount);
        }

        public FreightCarriage GetCarriageWithMaxLoadCapacity()
        {
            return Carriages.OfType<FreightCarriage>().OrderByDescending(c => c.MaxLoadCapacity).FirstOrDefault();
        }

        public Dictionary<string, int> CountCarriagesByType()
        {
            return Carriages.GroupBy(c => c.Type)
                            .ToDictionary(g => g.Key, g => g.Count());
        }

        public bool ContainsSpecialCarriages(Func<Carriage, bool> criteria)
        {
            return Carriages.Any(criteria);
        }

        public void ListCarriages()
        {
            foreach (var carriage in Carriages)
            {
                Console.WriteLine(carriage);
            }
        }

        public Carriage GetCarriageById(Guid id)
        {
            return Carriages.FirstOrDefault(c => c.Id == id);
        }
    }
}

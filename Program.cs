using Laba2;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Laba2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вітаємо у системі потягів!");


            var trains = new List<Train>
            {
                new Train("Інтерсіті", "IC001"),
                new Train("Експрес", "EX002"),
                new Train("Локальний", "LC003")
            };


            Console.WriteLine("Доступні потяги:");
            for (int i = 0; i < trains.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {trains[i].Name} - Маршрут: {trains[i].RouteNumber}");
            }


            Console.Write("Оберіть номер потягу для управління: ");
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > trains.Count)
            {
                Console.Write("Будь ласка, введіть коректний номер: ");
            }

            var selectedTrain = trains[choice - 1];


            while (true)
            {
                Console.WriteLine($"\nОбрано потяг \"{selectedTrain.Name}\" - Маршрут: {selectedTrain.RouteNumber}");
                Console.WriteLine("1. Додати вагон");
                Console.WriteLine("2. Видалити вагон");
                Console.WriteLine("3. Пошук вагонів");
                Console.WriteLine("4. Розрахувати загальну вагу потягу");
                Console.WriteLine("5. Вивести інформацію про всі вагони");
                Console.WriteLine("6. Вийти");

                Console.Write("\nВаш вибір: ");
                int option;
                while (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > 6)
                {
                    Console.Write("Будь ласка, введіть коректний варіант: ");
                }

                switch (option)
                {
                    case 1:
                        Console.WriteLine("\nДодавання вагона:");
                        Console.Write("Введіть тип вагона (Passenger/Freight/Dining/Sleeping): ");
                        string type = Console.ReadLine();
                        Console.Write("Введіть вагу вагона: ");
                        double weight;
                        while (!double.TryParse(Console.ReadLine(), out weight) || weight <= 0)
                        {
                            Console.Write("Будь ласка, введіть коректну вагу: ");
                        }
                        Console.Write("Введіть довжину вагона: ");
                        double length;
                        while (!double.TryParse(Console.ReadLine(), out length) || length <= 0)
                        {
                            Console.Write("Будь ласка, введіть коректну довжину: ");
                        }

                        switch (type.ToLower())
                        {
                            case "passenger":
                                Console.Write("Введіть кількість місць: ");
                                int seatsCount;
                                while (!int.TryParse(Console.ReadLine(), out seatsCount) || seatsCount <= 0)
                                {
                                    Console.Write("Будь ласка, введіть коректну кількість місць: ");
                                }
                                Console.Write("Введіть рівень комфорту (economy/business): ");
                                string comfortLevel = Console.ReadLine();
                                selectedTrain.AddCarriage(new PassengerCarriage(weight, length, seatsCount, comfortLevel));
                                Console.WriteLine("Пасажирський вагон успішно додано до потягу.");
                                break;
                            case "freight":
                                Console.Write("Введіть максимальну вантажопідйомність: ");
                                double maxLoadCapacity;
                                while (!double.TryParse(Console.ReadLine(), out maxLoadCapacity) || maxLoadCapacity <= 0)
                                {
                                    Console.Write("Будь ласка, введіть коректну максимальну вантажопідйомність: ");
                                }
                                Console.Write("Введіть тип вантажу: ");
                                string cargoType = Console.ReadLine();
                                selectedTrain.AddCarriage(new FreightCarriage(weight, length, maxLoadCapacity, cargoType));
                                Console.WriteLine("Вантажний вагон успішно додано до потягу.");
                                break;
                            case "dining":
                                Console.Write("Введіть кількість столів: ");
                                int tablesCount;
                                while (!int.TryParse(Console.ReadLine(), out tablesCount) || tablesCount <= 0)
                                {
                                    Console.Write("Будь ласка, введіть коректну кількість столів: ");
                                }
                                Console.Write("Чи є в вагоні кухня (true/false): ");
                                bool hasKitchen;
                                while (!bool.TryParse(Console.ReadLine(), out hasKitchen))
                                {
                                    Console.Write("Будь ласка, введіть true або false: ");
                                }
                                selectedTrain.AddCarriage(new DiningCarriage(weight, length, tablesCount, hasKitchen));
                                Console.WriteLine("Ресторанний вагон успішно додано до потягу.");
                                break;
                            case "sleeping":
                                Console.Write("Введіть кількість купе: ");
                                int compartmentsCount;
                                while (!int.TryParse(Console.ReadLine(), out compartmentsCount) || compartmentsCount <= 0)
                                {
                                    Console.Write("Будь ласка, введіть коректну кількість купе: ");
                                }
                                Console.Write("Чи є у вагоні душові кабіни (true/false): ");
                                bool hasShowers;
                                while (!bool.TryParse(Console.ReadLine(), out hasShowers))
                                {
                                    Console.Write("Будь ласка, введіть true або false: ");
                                }
                                selectedTrain.AddCarriage(new SleepingCarriage(weight, length, compartmentsCount, hasShowers));
                                Console.WriteLine("Спальний вагон успішно додано до потягу.");
                                break;
                            default:
                                Console.WriteLine("Невідомий тип вагона.");
                                break;
                        }
                        break;

                    case 2:

                        Console.WriteLine("\nВидалення останнього вагона:");
                        selectedTrain.RemoveCarriage();
                        break;
                    case 3:

                        Console.WriteLine("\nПошук вагонa");

                        break;
                    case 4:

                        Console.WriteLine($"\nЗагальна вага потягу \"{selectedTrain.Name}\": {selectedTrain.CalculateTotalWeight()}т");
                        break;
                    case 5:

                        Console.WriteLine("\nІнформація про всі вагони:");
                        selectedTrain.ListCarriages();
                        break;
                    case 6:

                        return;
                    default:
                        Console.WriteLine("Невірний вибір.");
                        break;
                }
            }
        }
    }
}

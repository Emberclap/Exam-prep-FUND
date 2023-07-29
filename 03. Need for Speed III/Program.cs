namespace _03._Need_for_Speed_III
{
    internal class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                string[] car = Console.ReadLine()
                   .Split('|')
                   .ToArray();
                string model = car[0];
                int mileage = int.Parse(car[1]);
                int fuel = int.Parse(car[2]);
                cars.Add(new Car(model, mileage, fuel));
            }

            string input =string.Empty;
            while ((input = Console.ReadLine()) != "Stop")
            {
                string[] commands = input
                    .Split(" : ")
                    .ToArray();
                string model = commands[1];
                switch(commands[0])
                {
                    case "Drive":
                        int distance = int.Parse(commands[2]);
                        int fuel = int.Parse(commands[3]);
                        foreach (Car car in cars)
                        {
                            if (car.Model == model)
                            {
                                if (car.Fuel < fuel)
                                {
                                    Console.WriteLine("Not enough fuel to make that ride");
                                }
                                else
                                {
                                    car.Fuel -= fuel;
                                    car.Mileage += distance;
                                    Console.WriteLine($"{car.Model} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                                    if (car.Mileage > 100_000)
                                    {
                                        Console.WriteLine($"Time to sell the {car.Model}!");
                                        cars.Remove(car);
                                        break;
                                    }
                                }
                            }
                        }
                        break;
                    case "Refuel":
                        int refuel = int.Parse(commands[2]);
                        foreach (Car car in cars)
                        {
                            if (car.Model == model)
                            {
                                if (car.Fuel + refuel >= 75)
                                {
                                    Console.WriteLine($"{car.Model} refueled with {75 - car.Fuel} liters");
                                    car.Fuel = 75;
                                }
                                else
                                {
                                    car.Fuel += refuel;
                                    Console.WriteLine($"{car.Model} refueled with {refuel} liters");
                                }
                            }
                        }
                        break;
                    case "Revert":
                        int kilometers = int.Parse(commands[2]);
                        foreach(Car car in cars)
                        {
                            if (car.Model == model)
                            {
                                if (car.Mileage - kilometers < 10000)
                                {
                                    car.Mileage = 10000;
                                }
                                else
                                {
                                    car.Mileage -= kilometers;
                                    Console.WriteLine($"{car.Model} mileage decreased by {kilometers} kilometers");
                                }
                            }
                        }
                        break;
                }
            }
            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model} -> Mileage: {car.Mileage} kms, Fuel in the tank: {car.Fuel} lt.");
            }
        }
    }
    public class Car
    {
        public Car(string model, int mileage, int fuel)
        {
            Model = model;
            Mileage = mileage;
            Fuel = fuel;
        }

        public string Model { get; set; }
        public int Mileage { get; set; }
        public int Fuel { get; set; }
    }
}
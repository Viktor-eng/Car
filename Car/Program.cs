using System.Collections.Generic;

namespace Car
{
    class Program
    {
        static void Main(string[] args)
        {
            ICarFactory carFactory = new CarFactory();
            List<ICar> cars = new List<ICar>();

            for (int i = 0; i < 20; i++)
            {
                cars.Add(carFactory.ProduceCar(TransmissionType.Mechanic, CarBrand.Lada, Color.Red, 15));
                cars.Add(carFactory.ProduceCar(TransmissionType.Automatic, CarBrand.Toyota, Color.Green, 16));
                cars.Add(carFactory.ProduceCar(TransmissionType.Mechanic, CarBrand.Hyuidnai, Color.Yellow, 14));
                cars.Add(carFactory.ProduceCar(TransmissionType.Automatic, CarBrand.BMW, Color.Black, 15));
                cars.Add(carFactory.ProduceCar(TransmissionType.Automatic, CarBrand.Lada, Color.Orange, 17));
            }

            CarStorage.SafeToFile(cars);
            var carsRead = CarStorage.ReadFile();

            CarsFiltrator carsFiltrator = new CarsFiltrator(carsRead);
            var brokenCarsOrderedByBrandAndEngineDisplacemant = carsFiltrator.GetBrokenCarsOrderedByBrandAndEngineDisplacemant();
            var brandCarWhichBreaksTheMost = carsFiltrator.GetBrandCarWhichBreaksTheMost();
            var colorCarWichBreaksTheLeast = carsFiltrator.GetColorCarWichBreaksTheLeast();
            var greatestWheelsDiameterCarWichBreaksTheLeast = carsFiltrator.GetGreatestWheelsDiameterCarWichBreaksTheLeast();
            var carBrandWithTheLargestEngineDisplacement = carsFiltrator.GetCarBrandWithTheLargestEngineDisplacement();
            var brokenWheels = carsFiltrator.GetBrokenWheels();
        }
    }
}

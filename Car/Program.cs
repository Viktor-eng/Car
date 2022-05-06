using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

            CarsFiltrator carsFiltrator = new CarsFiltrator(cars);
            carsFiltrator.GetBrokenCarsOrderedByBrandAndEngineDisplacemant();
            carsFiltrator.GetBrandCarWhichBreaksTheMost();
            carsFiltrator.GetColorCarWichBreaksTheLeast();
            carsFiltrator.GetWheelsDiameterCarWichBreaksTheLeast();
            carsFiltrator.GetCarBrandWithTheLargestEngineDisplacement();
            carsFiltrator.GetBrokenWheels();
        }
    }
}

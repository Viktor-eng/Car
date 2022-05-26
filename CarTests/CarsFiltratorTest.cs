using Car;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarTests
{
    class CarsFiltratorTest
    {
        CarsFiltrator _carsFiltrator;
        IEnumerable<ICar> _cars;

        [SetUp]
        public void Setup()
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
            _carsFiltrator = carsFiltrator;
            _cars = carsRead;
        }

        [Test]
        public void GetBrokenCarsOrderedByBrandAndEngineDisplacemant_Test()
        {
            // Arrange

            // Act
            var carsBrokenCarsOrderedByBrandAndEngineDisplacemant = _carsFiltrator.GetBrokenCarsOrderedByBrandAndEngineDisplacemant();

            //Assert
            Assert.AreEqual(carsBrokenCarsOrderedByBrandAndEngineDisplacemant, cars);
        }
    }
}

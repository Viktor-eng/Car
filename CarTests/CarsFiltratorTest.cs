using Car;
using NUnit.Framework;
using System.Collections.Generic;

namespace CarTests
{
    class CarsFiltratorTest
    {
        [Test]
        public void GetBrokenCarsOrderedByBrandAndEngineDisplacemant_Test()
        {
            // Arrange
            List<ICar> carsTests = new List<ICar>();
            var wheelDiameter = 15;
            var wheels = new Wheel[] { new Wheel(1, wheelDiameter, false), new Wheel(2, wheelDiameter, false), new Wheel(3, wheelDiameter, false), new Wheel(4, wheelDiameter, false) };

            carsTests = new List<ICar>()
            {
                new CarAutomatic(10, CarBrand.Hyuidnai, Color.White, wheels, 1.6d, false),
                new CarAutomatic(0, CarBrand.Lada, Color.Black, wheels, 1.6d, true),
                new CarAutomatic(5, CarBrand.Hyuidnai, Color.White, wheels, 1.6d, false),
                new CarAutomatic(15, CarBrand.Lada, Color.Black, wheels, 1.7d, true),
                new CarAutomatic(20, CarBrand.Lada, Color.White, wheels, 1.8d, true),
                new CarAutomatic(30, CarBrand.BMW, Color.White, wheels, 2.0d, true),
                new CarAutomatic(25, CarBrand.Lada, Color.White, wheels, 1.9d, true),
            };

            var sortCar = new List<ICar>()
            {
                new CarAutomatic(0, CarBrand.Lada, Color.Black, wheels, 1.6d, true),
                new CarAutomatic(15, CarBrand.Lada, Color.Black, wheels, 1.7d, true),
                new CarAutomatic(20, CarBrand.Lada, Color.White, wheels, 1.8d, true),
                new CarAutomatic(25, CarBrand.Lada, Color.White, wheels, 1.9d, true),
                new CarAutomatic(30, CarBrand.BMW, Color.White, wheels, 2.0d, true),
            };

            // Act
            CarsFiltrator carsFiltrator = new CarsFiltrator(carsTests);
            var carsBrokenCarsOrderedByBrandAndEngineDisplacemant = carsFiltrator.GetBrokenCarsOrderedByBrandAndEngineDisplacemant();

            //Assert
            Assert.AreEqual(carsBrokenCarsOrderedByBrandAndEngineDisplacemant.Count, sortCar.Count);

            for (int i = 0; i < sortCar.Count; i++)
            {
                Assert.AreEqual(carsBrokenCarsOrderedByBrandAndEngineDisplacemant[i], sortCar[i]);
            }
        }

        [Test]
        public void GetBrandCarWhichBreaksTheMost_Test()
        {
            // Arrange
            List<ICar> carsTests = new List<ICar>();
            var wheelDiameter = 15;
            var wheels = new Wheel[] { new Wheel(1, wheelDiameter, false), new Wheel(2, wheelDiameter, false), new Wheel(3, wheelDiameter, false), new Wheel(4, wheelDiameter, false) };

            carsTests = new List<ICar>()
            {
                new CarAutomatic(10, CarBrand.Hyuidnai, Color.White, wheels, 1.6d, false),
                new CarAutomatic(0, CarBrand.BMW, Color.Black, wheels, 1.6d, true),
                new CarAutomatic(5, CarBrand.Hyuidnai, Color.White, wheels, 1.6d, true),
                new CarMechanic(15, CarBrand.Lada, Color.Black, wheels, 1.7d, true),
                new CarMechanic(20, CarBrand.Lada, Color.White, wheels, 1.8d, true),
                new CarAutomatic(30, CarBrand.BMW, Color.White, wheels, 2.0d, true),
                new CarAutomatic(25, CarBrand.Lada, Color.White, wheels, 1.9d, true),
                new CarMechanic(35, CarBrand.BMW, Color.White, wheels, 1.9d, true),
                new CarMechanic(45, CarBrand.BMW, Color.White, wheels, 1.9d, false)
            };

            List<CarBrand> carBrands = new List<CarBrand>();
            carBrands.Add(CarBrand.BMW);
            carBrands.Add(CarBrand.Lada);

            // Act
            CarsFiltrator carsFiltrator = new CarsFiltrator(carsTests);
            var carBrandTest = carsFiltrator.GetBrandCarWhichBreaksTheMost();

            // Assert
            Assert.AreEqual(carBrands, carBrandTest);
        }

        [Test]
        public void GetColorCarWichBreaksTheLeast_Test()
        {
            // Arrange
            List<ICar> cars = new List<ICar>();
            var wheelDiameter = 15;
            var wheels = new Wheel[] { new Wheel(1, wheelDiameter, false), new Wheel(2, wheelDiameter, false), new Wheel(3, wheelDiameter, false), new Wheel(4, wheelDiameter, false) };

            cars = new List<ICar>()
            {
                new CarAutomatic(10, CarBrand.Hyuidnai, Color.Green, wheels, 1.6d, true),
                new CarAutomatic(0, CarBrand.Lada, Color.Green, wheels, 1.6d, true),
                new CarAutomatic(5, CarBrand.Hyuidnai, Color.Green, wheels, 1.6d, true),
                new CarMechanic(15, CarBrand.Lada, Color.Green, wheels, 1.7d, true),
                new CarMechanic(20, CarBrand.Lada, Color.Green, wheels, 1.8d, true),
                new CarAutomatic(30, CarBrand.BMW, Color.Green, wheels, 2.0d, true),
                new CarAutomatic(25, CarBrand.Hyuidnai, Color.Red, wheels, 1.9d, true),
                new CarMechanic(35, CarBrand.Ford, Color.Red, wheels, 1.9d, true),
                new CarMechanic(35, CarBrand.Ford, Color.Black, wheels, 1.9d, false),
                new CarMechanic(35, CarBrand.Ford, Color.Black, wheels, 1.9d, true),
                new CarMechanic(35, CarBrand.Ford, Color.Black, wheels, 1.9d, true)
            };

            List<Color> colors = new List<Color>();
            colors.Add(Color.Red);
            colors.Add(Color.Black);

            // Act
            CarsFiltrator carsFiltrator = new CarsFiltrator(cars);
            var carBrandTest = carsFiltrator.GetColorCarWichBreaksTheLeast();

            // Assert 
            Assert.AreEqual(carBrandTest, colors);
        }

        [Test]
        public void GetGreatestWheelsDiameterCarWichBreaksTheLeast_Test()
        {
            // Arrange
            List<ICar> cars = new List<ICar>();
            var wheelDiameterSmall = 15;
            var wheelDiameterBig = 16;
            var wheelDiameterGigant = 23;

            var wheelsSmall = new Wheel[] { new Wheel(1, wheelDiameterSmall, false), new Wheel(2, wheelDiameterSmall, false), new Wheel(3, wheelDiameterSmall, false), new Wheel(4, wheelDiameterSmall, false) };
            var wheelsBig = new Wheel[] { new Wheel(1, wheelDiameterBig, false), new Wheel(2, wheelDiameterBig, false), new Wheel(3, wheelDiameterBig, false), new Wheel(4, wheelDiameterBig, false) };
            var wheelsGigant = new Wheel[] { new Wheel(1, wheelDiameterGigant, false), new Wheel(2, wheelDiameterGigant, false), new Wheel(3, wheelDiameterGigant, false), new Wheel(4, wheelDiameterGigant, false) };

            cars = new List<ICar>()
            {
                new CarAutomatic(10, CarBrand.Hyuidnai, Color.Green, wheelsSmall, 1.6d, true),
                new CarAutomatic(10, CarBrand.Hyuidnai, Color.Green, wheelsSmall, 1.6d, false),
                new CarAutomatic(0, CarBrand.Lada, Color.Green,wheelsBig, 1.6d, true),
                new CarAutomatic(5, CarBrand.Lada, Color.Green, wheelsSmall, 1.6d, true),
                new CarMechanic(15, CarBrand.Lada, Color.Green, wheelsBig, 1.7d, true),
                new CarMechanic(15, CarBrand.Lada, Color.Green, wheelsBig, 1.7d, false),
                new CarMechanic(20, CarBrand.Lada, Color.Green, wheelsBig, 1.8d, true),
                new CarAutomatic(30, CarBrand.BMW, Color.Green, wheelsSmall, 2.0d, true),
                new CarAutomatic(25, CarBrand.Hyuidnai, Color.White, wheelsGigant, 1.9d, true),
                new CarMechanic(35, CarBrand.Ford, Color.Red, wheelsGigant, 1.9d, true),
                new CarMechanic(35, CarBrand.Ford, Color.Red, wheelsGigant, 1.9d, false)
            };

            List<int> diametrWheels = new List<int>();
            diametrWheels.Add(15);
            diametrWheels.Add(23);
            // Act
            CarsFiltrator carsFiltrator = new CarsFiltrator(cars);
            List<int> diameterWheelsTests = carsFiltrator.GetGreatestWheelsDiameterCarWichBreaksTheLeast();

            // Assert
            Assert.AreEqual(diametrWheels, diameterWheelsTests);
        }

        [Test]
        public void GetCarBrandWithTheLargestEngineDisplacement_Test()
        {
            // Arrange
            List<ICar> cars = new List<ICar>();
            var wheelDiameterSmall = 15;
            var wheelDiameterBig = 16;
            var wheelDiameterGigant = 23;

            var wheelsSmall = new Wheel[] { new Wheel(1, wheelDiameterSmall, false), new Wheel(2, wheelDiameterSmall, false), new Wheel(3, wheelDiameterSmall, false), new Wheel(4, wheelDiameterSmall, false) };
            var wheelsBig = new Wheel[] { new Wheel(1, wheelDiameterBig, false), new Wheel(2, wheelDiameterBig, false), new Wheel(3, wheelDiameterBig, false), new Wheel(4, wheelDiameterBig, false) };
            var wheelsGigant = new Wheel[] { new Wheel(1, wheelDiameterGigant, false), new Wheel(2, wheelDiameterGigant, false), new Wheel(3, wheelDiameterGigant, false), new Wheel(4, wheelDiameterGigant, false) };

            cars = new List<ICar>()
            {
                new CarAutomatic(10, CarBrand.Hyuidnai, Color.Green, wheelsSmall, 1.6d, true),
                new CarAutomatic(0, CarBrand.Lada, Color.Green,wheelsBig, 1.6d, true),
                new CarAutomatic(5, CarBrand.Lada, Color.Green, wheelsSmall, 1.6d, true),
                new CarMechanic(15, CarBrand.Lada, Color.Green, wheelsBig, 1.7d, true),
                new CarMechanic(20, CarBrand.Lada, Color.Green, wheelsBig, 1.8d, true),
                new CarAutomatic(30, CarBrand.BMW, Color.Green, wheelsSmall, 3.0d, true),
                new CarAutomatic(25, CarBrand.Hyuidnai, Color.White, wheelsGigant, 1.9d, true),
                new CarMechanic(35, CarBrand.Ford, Color.Red, wheelsGigant, 3.0d, true)
            };

            List<CarBrand> carBrands = new List<CarBrand>();
            carBrands.Add(CarBrand.BMW);
            carBrands.Add(CarBrand.Ford);

            // Act
            CarsFiltrator carsFiltrator = new CarsFiltrator(cars);
            List<CarBrand> carBrandTest = carsFiltrator.GetCarBrandWithTheLargestEngineDisplacement();

            // Assert
            Assert.AreEqual(carBrands, carBrandTest);
        }

        [Test]
        public void GetBrokenWheels_Test()
        {
            // Arrange
            List<ICar> cars = new List<ICar>();
            var wheelDiameter = 15;
            var wheels = new Wheel[] { new Wheel(1, wheelDiameter, false), new Wheel(2, wheelDiameter, false), new Wheel(3, wheelDiameter, false), new Wheel(4, wheelDiameter, false) };
            var wheelsBroken = new Wheel[] { new Wheel(1, wheelDiameter, true), new Wheel(2, wheelDiameter, true), new Wheel(3, wheelDiameter, true), new Wheel(4, wheelDiameter, true) };
            cars = new List<ICar>()
            {
                new CarAutomatic(10, CarBrand.Hyuidnai, Color.White, wheelsBroken, 1.6d, true),
                new CarAutomatic(0, CarBrand.Lada, Color.Black, wheelsBroken, 1.6d, true),
                new CarAutomatic(5, CarBrand.Hyuidnai, Color.White, wheelsBroken, 1.6d, true)
,           };

            // Act
            int brokenWheels = 12;
            CarsFiltrator carsFiltrator = new CarsFiltrator(cars);
            int brokenWheelsTest = carsFiltrator.GetBrokenWheels();

            //Assert
            Assert.AreEqual(brokenWheels, brokenWheelsTest);
        }
    }
}

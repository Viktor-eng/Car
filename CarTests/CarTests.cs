using Car;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarTests
{
    public class Tests
    {
        IEnumerable<ICar> cars;

        [SetUp]
        public void Setup()
        {
            var wheelDiam = 15;
            var wheels = new Wheel[] { new Wheel(1, wheelDiam, false), new Wheel(2, wheelDiam, false), new Wheel(3, wheelDiam, false), new Wheel(4, wheelDiam, false) };

            cars = new List<ICar>()
            {
                new CarAutomatic(1, CarBrand.BMW, Color.Black, wheels, 1.6d, true),
            };
        }

        [Test]
        public void PassNullCars_ThrowArgumentNullException_Success_Test()
        {
            Assert.Throws<ArgumentNullException>(() => new CarsFiltrator(null));
        }

        [Test]
        public void PassEmptyCars_DoesNotThrowException_Success_Test()
        {
            Assert.DoesNotThrow(() => new CarsFiltrator(Enumerable.Empty<ICar>()));
        }
    }
}

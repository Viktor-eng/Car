using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car
{
    class CarsFiltrator
    {
        private readonly List<ICar> _cars;


        public CarsFiltrator(List<ICar> cars)
        {
            _cars = cars;
        }


        public void GetBrokenCarsOrderedByBrandAndEngineDisplacemant()
        {
            var sortCars = _cars
                 .Where(c => c.IsBroken)
                .OrderBy(c => c.CarBrand)
                .ThenBy(c => c.EngineDisplacement)
                .ToList();
        }

        public void GetBrandCarWhichBreaksTheMost()
        {
            var sortCars = _cars
                .Where(c => c.IsBroken)
                .GroupBy(c => c.CarBrand)
                .Select(c => new { CarBrand = c.Key, Count = c.Count() })
                .OrderByDescending(c => c.Count)
                .First().CarBrand;
        }

        public void GetColorCarWichBreaksTheLeast()
        {
            var sortCars = _cars
                .Where(c => c.IsBroken)
                .GroupBy(c => c.Color)
                .Select(c => new { Color = c.Key, Count = c.Count() })
                .OrderByDescending(c => c.Count)
                .First().Color;
        }

        public void GetWheelsDiameterCarWichBreaksTheLeast()
        {
            var sortCars = _cars
                .Where(c => c.IsBroken)
                .GroupBy(c => c.CarBrand)
                .ToDictionary(c => c.Key, c => c.ToArray());

            var minCarBrand = sortCars.Min(c => c.Value.Length);
            var endCar = sortCars.Where(c => c.Value.Length == minCarBrand).First().Value.First().Wheels.First().WheelDiameter;
        }

        public void GetCarBrandWithTheLargestEngineDisplacement()
        {
            var sortCars = _cars
                .OrderByDescending(c => c.EngineDisplacement)
                .First().CarBrand;
        }

        public void GetBrokenWheels()
        {
            var sortCars = _cars
                .SelectMany(c => c.Wheels)
                .Where(w => w.IsBroken).Count();
        }
    }
}

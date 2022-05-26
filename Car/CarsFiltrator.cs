using System;
using System.Collections.Generic;
using System.Linq;

namespace Car
{
    class CarsFiltrator
    {
        private readonly IEnumerable<ICar> _cars;

        public CarsFiltrator(IEnumerable<ICar> cars)
        {
            _cars = cars ?? throw new ArgumentNullException(nameof(cars));
        }

        public IEnumerable<ICar> GetBrokenCarsOrderedByBrandAndEngineDisplacemant()
        {
            return _cars.Where(c => c.IsBroken)
                        .OrderBy(c => c.CarBrand)
                        .ThenBy(c => c.EngineDisplacement)
                        .ToList();
        }

        public CarBrand GetBrandCarWhichBreaksTheMost()
        {
            return _cars
                .Where(c => c.IsBroken)
                .GroupBy(c => c.CarBrand)
                .Select(c => new { CarBrand = c.Key, Count = c.Count() })
                .OrderByDescending(c => c.Count)
                .First().CarBrand;
            
        }

        public Color GetColorCarWichBreaksTheLeast()
        {
            return _cars
                .Where(c => c.IsBroken)
                .GroupBy(c => c.Color)
                .Select(c => new { Color = c.Key, Count = c.Count() })
                .OrderByDescending(c => c.Count)
                .First().Color;
        }

        public int GetWheelsDiameterCarWichBreaksTheLeast()
        {
            var sortCars = _cars
                .Where(c => c.IsBroken)
                .GroupBy(c => c.CarBrand)
                .ToDictionary(c => c.Key, c => c.ToArray());

            var minCarBrand = sortCars.Min(c => c.Value.Length);
            return sortCars.Where(c => c.Value.Length == minCarBrand).First().Value.First().Wheels.First().WheelDiameter;
        }

        public CarBrand GetCarBrandWithTheLargestEngineDisplacement()
        {
            return _cars
                .OrderByDescending(c => c.EngineDisplacement)
                .First().CarBrand;
        }

        public int GetBrokenWheels()
        {
            return _cars
                .SelectMany(c => c.Wheels)
                .Where(w => w.IsBroken).Count();
        }
    }
}

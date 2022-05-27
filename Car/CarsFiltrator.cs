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

        public List<ICar> GetBrokenCarsOrderedByBrandAndEngineDisplacemant()
        {
            return _cars.Where(c => c.IsBroken)
                        .OrderBy(c => c.CarBrand)
                        .ThenBy(c => c.EngineDisplacement)
                        .ToList();
        }

        public List<CarBrand> GetBrandCarWhichBreaksTheMost()
        {
            var sortCars = _cars
                .Where(c => c.IsBroken)
                .GroupBy(c => c.CarBrand)
                .ToDictionary(c => c.Key, c => c.ToArray());

            var max = sortCars.Max(c => c.Value.Length);

            List<CarBrand> brandBreaksCar = new List<CarBrand>();

            foreach (var item in sortCars)
            {
                if (item.Value.Length == max)
                {
                    brandBreaksCar.Add(item.Key);
                }
            }
            return brandBreaksCar;

            //return _cars
            //     .Where(c => c.IsBroken)
            //     .GroupBy(c => c.CarBrand)
            //     .Select(c => new { CarBrand = c.Key, Count = c.Count() })
            //     .OrderByDescending(c => c.Count)
            //     .First().CarBrand;
        }

        public List<Color> GetColorCarWichBreaksTheLeast()
        {
            var sortCars = _cars
                .Where(c => c.IsBroken)
                .GroupBy(c => c.Color)
                .ToDictionary(c => c.Key, c => c.ToArray());

            var minColor = sortCars.Min(c => c.Value.Length);
            List<Color> listColor = new List<Color>();

            foreach (var item in sortCars)
            {
                if (item.Value.Length == minColor)
                {
                    listColor.Add(item.Key);
                }
            }
            return listColor;
        }

        public List<int> GetWheelsDiameterCarWichBreaksTheLeast()
        {
            var sortCars = _cars
                .Where(c => c.IsBroken)
                .GroupBy(c => c.CarBrand)
                .ToDictionary(c => c.Key, c => c.ToArray());

            List<int> listDiameter = new List<int>();
            var minCarBrand = sortCars.Min(c => c.Value.Length);
            var minDiametr = sortCars.Where(c => c.Value.Length == minCarBrand).First().Value.First().Wheels.First().WheelDiameter;

            foreach (var item in sortCars)
            {
                if (item.Value.Length == minCarBrand)
                {
                    listDiameter.Add((item.Value).First().Wheels.First().WheelDiameter);
                }
            }
            return listDiameter;
        }

        public List<CarBrand> GetCarBrandWithTheLargestEngineDisplacement()
        {
            var maxEngineDisplacement = _cars
                .Max(c => c.EngineDisplacement);

            var sortCars = _cars
                .Where(c => c.EngineDisplacement == maxEngineDisplacement)
                .GroupBy(c => c.CarBrand);

            List<CarBrand> carBrands = new List<CarBrand>();

            foreach (var item in sortCars)
            {
                carBrands.Add(item.Key);
            }
            return carBrands;

            //return _cars
            //    .OrderByDescending(c => c.EngineDisplacement)
            //    .First().CarBrand;
        }

        public int GetBrokenWheels()
        {
            return _cars
               .SelectMany(c => c.Wheels)
               .Where(w => w.IsBroken).Count();
        }
    }
}

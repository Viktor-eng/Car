using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car
{
    class CarStorage
    {
        static string _automaticFileName = "Automatic.txt";
        static string _mechanicFileName = "Mechanic.txt";

        public static void SafeToFile(List<ICar> cars)
        {
            List<CarAutomatic> carsAutomatic = new List<CarAutomatic>();
            List<CarMechanic> carsMechanic = new List<CarMechanic>();

            foreach (var car in cars)
            {
                if (car is CarAutomatic automatic)
                {
                    carsAutomatic.Add(automatic);
                }
            }

            foreach (var car in cars)
            {
                if (car is CarMechanic mechanic)
                {
                    carsMechanic.Add(mechanic);
                }
            }

            StreamWriter swAutomatic = new StreamWriter(_automaticFileName);
            string jsonAutomatic = JsonConvert.SerializeObject(carsAutomatic);
            swAutomatic.Write(jsonAutomatic);
            swAutomatic.Close();

            StreamWriter swMechanic = new StreamWriter(_mechanicFileName);
            string jsonMechanic = JsonConvert.SerializeObject(carsMechanic);
            swMechanic.Write(jsonMechanic);
            swMechanic.Close();
        }

        public static List<ICar> ReadFile()
        {
            StreamReader srAutomatic = new StreamReader(_automaticFileName);
            string readJsonAutomaticCar = srAutomatic.ReadToEnd();
            var carsReadAutomatic = JsonConvert.DeserializeObject<List<CarAutomatic>>(readJsonAutomaticCar) ?? new List<CarAutomatic>();
            srAutomatic.Close();

            StreamReader srMechanic = new StreamReader(_mechanicFileName);
            string readJsonMechanic = srMechanic.ReadToEnd();
            var carsReadMechanic = JsonConvert.DeserializeObject<List<CarMechanic>>(readJsonMechanic) ?? new List<CarMechanic>();
            srMechanic.Close();

            List<ICar> cars = new List<ICar>();
            cars.AddRange(new List<ICar>(carsReadAutomatic));
            cars.AddRange(new List<ICar>(carsReadMechanic));
            return cars;
        }
    }
}

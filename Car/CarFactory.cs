using System;
using System.Linq;

namespace Car
{
    class CarFactory : ICarFactory
    {
        IIdFactory _idFactory = new IdFactory();
        public static Random _rnd = new Random();

        public ICar ProduceCar(TransmissionType transmissionType, CarBrand carBrand, Color color, int wheelDiameter)
        {
            Wheel[] wheels = GetWheels(wheelDiameter);
            bool broken = GetIsBroken();
            double engineDisplacement = GetengineDisplacement();

            switch (transmissionType)
            {
                case TransmissionType.Automatic:
                    return new CarAutomatic(_idFactory.GetId(), carBrand, color, wheels, engineDisplacement, broken);

                case TransmissionType.Mechanic:
                    return new CarMechanic(_idFactory.GetId(), carBrand, color, wheels, engineDisplacement, broken);

                default:
                    throw new ArgumentException("Error");
            }
        }

        private Wheel[] GetWheels(int wheelDiameter)
        {
            //Wheel[] wheels = new Wheel[4];

            //for (int i = 0; i < 4; i++)
            //{
            //    wheels[i] = new Wheel(_idFactory.GetId(), wheelDiameter, GetIsBroken());
            //}
            //return wheels;

            return Enumerable.Range(0, 4).Select(w => new Wheel(_idFactory.GetId(), wheelDiameter, GetIsBroken())).ToArray();
        }

        private bool GetIsBroken()
        {
            int value = _rnd.Next(1, 11);

            if (value < 2)
                return true;
            
            else
                return false;
        }
        
        private double GetengineDisplacement()
        {
            double value1 = _rnd.Next(1, 4);
            double value2 = _rnd.NextDouble();
            double result = value1 + value2;
            return Math.Round(result,1);
        }
    }
}

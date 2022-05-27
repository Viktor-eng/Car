using System;

namespace Car
{
    class CarMechanic : CarBase
    {
        public CarMechanic(int id, CarBrand carBrand, Color color, Wheel[] wheels, double engineDisplacement, bool broken) : base(id, carBrand, wheels, engineDisplacement, color, broken) { }


        public override bool Equals(object obj)
        {
            return obj is CarAutomatic automatic &&
                   Color == automatic.Color &&
                   CarBrand == automatic.CarBrand &&
                   EngineDisplacement == automatic.EngineDisplacement &&
                   IsBroken == automatic.IsBroken;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Color, CarBrand, EngineDisplacement, IsBroken);
        }

        protected override void TransmissionDrive()
        {
            Console.WriteLine("Снимаю с ручника");
            Console.WriteLine("Выжимаю педаль сцепления");
            Console.WriteLine("Включаю первую скорость");
        }
    }
}

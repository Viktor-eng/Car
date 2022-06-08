using System;

namespace Car
{
    class CarMechanic : CarBase
    {
        public CarMechanic(int id, CarBrand carBrand, Color color, Wheel[] wheels, double engineDisplacement, bool broken) : base(id, carBrand, wheels, engineDisplacement, color, broken) { }


        public override bool Equals(object obj)
        {
            return obj is CarAutomatic mechanic &&
                   Id == mechanic.Id &&
                   Color == mechanic.Color &&
                   CarBrand == mechanic.CarBrand &&
                   EngineDisplacement == mechanic.EngineDisplacement &&
                   IsBroken == mechanic.IsBroken;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Color, CarBrand, EngineDisplacement, IsBroken);
        }

        protected override void TransmissionDrive()
        {
            Console.WriteLine("Снимаю с ручника");
            Console.WriteLine("Выжимаю педаль сцепления");
            Console.WriteLine("Включаю первую скорость");
        }
    }
}

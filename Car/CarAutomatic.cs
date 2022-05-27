using System;

namespace Car
{
    class CarAutomatic : CarBase
    {
        public CarAutomatic(int id, CarBrand carBrand, Color color, Wheel[] wheels, double engineDisplacement, bool broken) : base(id, carBrand, wheels, engineDisplacement, color, broken) { }


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
            Console.WriteLine("Включаю коробку в редим \"D\"");
            Console.WriteLine("Нажимаю педаль газа");
        }
    }
}

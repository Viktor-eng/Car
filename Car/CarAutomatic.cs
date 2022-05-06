using System;

namespace Car
{
    class CarAutomatic : CarBase
    {
        public CarAutomatic(int id, CarBrand carBrand, Color color, Wheel[] wheels, double engineDisplacement, bool broken) : base(id, carBrand, wheels, engineDisplacement, color, broken) { }


        protected override void TransmissionDrive()
        {
            Console.WriteLine("Включаю коробку в редим \"D\"");
            Console.WriteLine("Нажимаю педаль газа");
        }
    }
}

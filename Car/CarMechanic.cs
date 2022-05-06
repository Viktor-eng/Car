using System;

namespace Car
{
    class CarMechanic : CarBase
    {
        public CarMechanic(int id, CarBrand carBrand, Color color, Wheel[] wheels, double engineDisplacement, bool broken) : base(id, carBrand, wheels, engineDisplacement, color, broken) { }


        protected override void TransmissionDrive()
        {
            Console.WriteLine("Снимаю с ручника");
            Console.WriteLine("Выжимаю педаль сцепления");
            Console.WriteLine("Включаю первую скорость");
        }
    }
}

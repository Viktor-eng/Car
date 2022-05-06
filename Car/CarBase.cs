using System;
using System.Linq;

namespace Car
{
    abstract class CarBase : ICar
    {
        bool _isBroken;


        public CarBase(int id, CarBrand carBrand, Wheel[] wheels, double engineDisplacement, Color color, bool broken)
        {
            Id = id;
            CarBrand = carBrand;
            Wheels = wheels;
            EngineDisplacement = engineDisplacement;
            _isBroken = broken;
            Color = color;
        }


        public int Id { get; set; }

        public Wheel[] Wheels { get; set; }

        public Color Color { get; set; }

        public CarBrand CarBrand { get; set; }

        public double EngineDisplacement { get; set; }

        public bool IsBroken
        {
            get
            {
                if (_isBroken)
                    return true;
                return Wheels.Any(w => w.IsBroken);
            }
            set
            {
                _isBroken = value;
            }
        }

        public virtual void Drive()
        {
            Console.WriteLine("Пытаюсь поехать...");
            if (IsBroken)
                Console.WriteLine("Машина сломана и не может поехать!!!");
            else
            {
                Console.WriteLine("Завожу машину");
                TransmissionDrive();
                Console.WriteLine("Поехали");
            }
        }

        abstract protected void TransmissionDrive();

        public void CheckCar()
        {
            Console.WriteLine("Тестирование машины перед запуском...");
            if (IsBroken)
                Console.WriteLine($"Id = {Id} - машина неисправна, возможна поломка двигателя!");

            var wheelsIsBroken = Wheels.Where(w => w.IsBroken);
            foreach (var wheelIsBroken in wheelsIsBroken)
                Console.WriteLine($"Id = {wheelIsBroken.Id} - колесо неисправно!");

            if (!IsBroken && wheelsIsBroken.Count() == 0)
                Console.WriteLine("Машина исправна");
        }
    }
}

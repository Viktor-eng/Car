namespace Car
{
    interface ICar
    {
        public CarBrand CarBrand { get; set; }

        public Color Color { get; set; }

        public Wheel[] Wheels { get; set; }

        public double EngineDisplacement { get; set; }

        bool IsBroken { get; set; }

        void Drive();

        void CheckCar();
    }
}

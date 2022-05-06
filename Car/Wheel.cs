namespace Car
{
    class Wheel
    {
        public Wheel(int id, int wheelDiameter, bool broken)
        {
            Id = id;
            WheelDiameter = wheelDiameter;
            IsBroken = broken;
        }


        public int Id { get; set; }

        public bool IsBroken { get; set; }

        public int WheelDiameter { get; set; }
    }
}

namespace Car
{
    class IdFactory : IIdFactory
    {
        public static int Id;

        public int GetId()
        {
            return Id++;
        }
    }
}

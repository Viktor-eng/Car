namespace Car
{
    interface ICarFactory
    {
        ICar ProduceCar(TransmissionType transmissionType, CarBrand carBrand, Color color, int wheelDiameter);
    }
}

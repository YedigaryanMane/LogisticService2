namespace LogisticService.Models
{
    public class CarTypeRequest
    {
        public CarTypeRequest(string carType)
        {
            CarType = carType;
        }

        public string CarType { get; set; }

    }
}

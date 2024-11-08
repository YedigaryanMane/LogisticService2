using LogisticService.Models;

namespace LogisticService.Service
{
    public class CalculationModel
    {
        public CalculationModel(CarType carType, Containers containers, Crashed crashed, Direction direction)
        {
            CarType = carType;
            Containers = containers;
            Crashed = crashed;
            Direction = direction;
        }

        public CarType CarType { get; set; }
        public Containers Containers { get; set; }
        public Crashed Crashed { get; set; }
        public Direction Direction { get; set; }
    }
}

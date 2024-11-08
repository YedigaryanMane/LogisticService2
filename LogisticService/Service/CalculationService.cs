namespace LogisticService.Service
{
    public class CalculationService : ICalculationService
    {
        public float Calculate(CalculationModel model)
        {
            if (model.Direction.Price != 0)
            {
                return (float)model.Direction.Price * model.Containers.Coef * model.CarType.Coef * model.Crashed.Coef;
            }
            else
            {
                return (float)model.Direction.Distance * 100 * model.Containers.Coef * model.CarType.Coef * model.Crashed.Coef;
            }
        }
    }
}

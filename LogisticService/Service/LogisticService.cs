using LogisticService.Models;
using LogisticService.Repository;

namespace LogisticService.Service
{
    public class LogisticService : ILogisticService
    {
        private readonly IRepository<CarType, CarTypeRequest> _carTypeRepository;
        private readonly IRepository<Direction, DirectionRequest> _directionRepository;
        private readonly IRepository<Crashed, CrashedRequest> _crashedRepository;
        private readonly IRepository<Containers, ContainerRequest> _containerRepository;
        private readonly ICalculationService _calculationService;

        public LogisticService(IRepository<CarType, CarTypeRequest> carTypeRepository,
            IRepository<Direction, DirectionRequest> directionRepository,
            IRepository<Crashed, CrashedRequest> crashedRepository,
            IRepository<Containers, ContainerRequest> containerRepository,
            ICalculationService calculationService)
        {
            _carTypeRepository = carTypeRepository;
            _directionRepository = directionRepository;
            _crashedRepository = crashedRepository;
            _containerRepository = containerRepository;
            _calculationService = calculationService;
        }

        public float GetPrice(LogisticModel model)
        {
            var carType = _carTypeRepository.Find(new CarTypeRequest(model.CarType));
            var direction = _directionRepository.Find(new DirectionRequest(model.From1, model.To1));
            var crashed = _crashedRepository.Find(new CrashedRequest(model.IsCrashed));
            var container = _containerRepository.Find(new ContainerRequest(model.IsClosed));

            return _calculationService.Calculate(new CalculationModel(carType, container, crashed, direction));
        }
    }
}

using LogisticService.Models;

namespace LogisticService.Repository
{
    public class CarTypeRepository : IRepository<CarType, CarTypeRequest>
    {

        private readonly DataContext dataContext;

        public CarTypeRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void Add(CarType cartype)
        {
            dataContext.CarTypes.Add(cartype);
            dataContext.SaveChanges();
        }

        public void Update(CarType cartype)
        {
            dataContext.CarTypes.Update(cartype);
            dataContext.SaveChanges();
        }

        public void Delete(CarType cartype)
        {
            dataContext.CarTypes.Remove(cartype);
            dataContext.SaveChanges();
        }

        public IEnumerable<CarType> GetAll()
        {
            return dataContext.CarTypes.ToList();
        }

        public CarType Get(int id)
        {
            return dataContext.CarTypes.FirstOrDefault(x => x.Id == id);
        }

        public CarType Find(CarTypeRequest cartype)
        {
            return dataContext.CarTypes.FirstOrDefault(x => x.Model == cartype.CarType);
        }
    }
}


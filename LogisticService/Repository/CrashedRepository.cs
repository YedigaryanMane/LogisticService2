using LogisticService.Models;

namespace LogisticService.Repository
{
    public class CrashedRepository : IRepository<Crashed, CrashedRequest>
    {
        private readonly DataContext dataContext;

        public CrashedRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }


        public void Add(Crashed crashed)
        {
            dataContext.Crasheds.Add(crashed);
            dataContext.SaveChanges();
        }

        public void Delete(Crashed crashed)
        {
            dataContext.Crasheds.Remove(crashed);
            dataContext.SaveChanges();
        }

        public Crashed Get(int id)
        {
            return dataContext.Crasheds.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Crashed> GetAll()
        {
            return dataContext.Crasheds.ToList();
        }
        public void Update(Crashed crashed)
        {
            dataContext.Crasheds.Update(crashed);
            dataContext.SaveChanges();
        }

        public Crashed Find(CrashedRequest request)
        {
            return dataContext.Crasheds.FirstOrDefault(x => x.IsCrashed == request.IsCrashed);
        }

    }
}

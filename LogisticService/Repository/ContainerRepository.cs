using LogisticService.Models;


namespace LogisticService.Repository
{
    public class ContainerRepository : IRepository<Containers, ContainerRequest>
    {
        private readonly DataContext _context;

        public ContainerRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(Containers container)
        {
            _context.Containers.Add(container);
            _context.SaveChanges();
        }

        public void Update(Containers container)
        {
            _context.Containers.Update(container);
            _context.SaveChanges();
        }

        public void Delete(Containers container)
        {
            _context.Containers.Remove(container);
            _context.SaveChanges();
        }

        public IEnumerable<Containers> GetAll()
        {
            return _context.Containers.ToList();
        }

        public Containers Get(int id)
        {
            return _context.Containers.FirstOrDefault(x => x.Id == id);
        }

        public Containers Find(ContainerRequest containerRequest)
        {
            return _context.Containers.FirstOrDefault(x => x.IsClosed == containerRequest.IsClosed);
        }
    }
}

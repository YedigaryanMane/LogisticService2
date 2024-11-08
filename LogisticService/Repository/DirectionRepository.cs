using LogisticService.Models;

namespace LogisticService.Repository
{
    public class DirectionRepository : IRepository<Direction, DirectionRequest>
    {
        private readonly DataContext _context;

        public DirectionRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(Direction direction)
        {
            _context.Directions.Add(direction);
            _context.SaveChanges();
        }

        public void Delete(Direction direction)
        {
            _context.Directions.Remove(direction);
            _context.SaveChanges();
        }

        public Direction Get(int id)
        {
            return _context.Directions.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Direction> GetAll()
        {
            return _context.Directions.ToList();
        }

        public void Update(Direction direction)
        {
            _context.Directions.Update(direction);
            _context.SaveChanges();
        }

        public Direction Find(DirectionRequest request)
        {
            return _context.Directions.FirstOrDefault(x => x.From1 == request.From1 && x.To1 == request.To1);
        }

    }
}

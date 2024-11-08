using LogisticService.Models;

namespace LogisticService.Repository
{
    public class OrderRepository
    {
        private readonly DataContext dataContext;

        public OrderRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void Add(Order order)
        {
            dataContext.Orders.Add(order);
            dataContext.SaveChanges();
        }
    }
}

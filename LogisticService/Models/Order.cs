namespace LogisticService.Models
{
    public class Order
    {
        public int Id { get; set; }
        public float Price { get; set; }
        public User Users { get; set; }
    }
}

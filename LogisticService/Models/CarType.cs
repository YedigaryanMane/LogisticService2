namespace LogisticService.Models
{
    public class CarType
    {
        public CarType(string model, float coef)
        {
            Model = model;
            Coef = coef;
        }

        public CarType() { }
        public int Id { get; set; }
        public string Model { get; set; }
        public float Coef { get; set; }
    }
}

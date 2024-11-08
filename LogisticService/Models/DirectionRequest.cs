namespace LogisticService.Models
{
    public class DirectionRequest
    {
        public DirectionRequest(string from1, string to1)
        {
            From1 = from1;
            To1 = to1;
        }

        public string From1 { get; set; }
        public string To1 { get; set; }
    }
}

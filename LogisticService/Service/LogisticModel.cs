namespace LogisticService.Service
{
    public class LogisticModel
    {
        public LogisticModel(string carType, string from1, string to1, bool isClosed, bool isCrashed)
        {
            CarType = carType;
            From1 = from1;
            To1 = to1;
            IsClosed = isClosed;
            IsCrashed = isCrashed;
        }

        public string CarType { get; set; }
        public string From1 { get; set; }
        public string To1 { get; set; }
        public bool IsClosed { get; set; }
        public bool IsCrashed { get; set; }
    }
}

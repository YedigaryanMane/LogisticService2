namespace LogisticService.Models
{
    public class ContainerRequest
    {
        public ContainerRequest(bool isClosed)
        {
            IsClosed = isClosed;
        }

        public bool IsClosed { get; set; }
    }
}

namespace LogisticService.Models
{
    public class CrashedRequest
    {
        public CrashedRequest(bool isCrashed)
        {
            IsCrashed = isCrashed;
        }

        public bool IsCrashed { get; set; }
    }
}

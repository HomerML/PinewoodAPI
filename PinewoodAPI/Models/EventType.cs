namespace PinewoodAPI.Models
{
    public class EventType
    {
        public int EventTypeId { get; set; }
        public string EventDescription { get; set; } = "";
        public int StatusId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int UpdatedBy { get; set; }

    }
}

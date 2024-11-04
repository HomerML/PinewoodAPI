namespace PinewoodAPI.Models
{
    public class Activity
    {
        public int ActivityId { get; set; }
        public int CustomerId { get; set; }
        public int EventTypeId { get; set; }
        public DateTime ActivityDate { get; set; }
        public string Notes { get; set; } = "";
        public int StatusId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int UpdatedBy { get; set; }

    }
}

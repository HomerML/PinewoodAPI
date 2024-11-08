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

    public class ActivityViewModel
    {
        public int ActivityId { get; set; }
        public DateTime ActivityDate { get; set; }
        public string EventDescription { get; set; } = "";
        public string Notes { get; set; } = "";
        public string UpdatedBy { get; set; }
    }
}

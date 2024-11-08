namespace PinewoodRazor.Models
{
    public class Status
    {
        public int StatusId { get; set; }
        public string StatusDescription { get; set; } = "";
        public DateTime ModifiedDate { get; set; }

        public ICollection<Status> statuses { get; set; }
    }
}

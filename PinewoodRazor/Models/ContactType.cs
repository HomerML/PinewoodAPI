namespace PinewoodRazor.Models
{
    public class ContactType
    {
        public int ContactTypeId { get; set; }
        public string ContactDescription { get; set; } = "";
        public int StatusId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int UpdatedBy { get; set; }

    }
}

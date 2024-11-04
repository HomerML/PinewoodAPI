namespace PinewoodRazor.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        public int CustomerId { get; set; }
        public int ContactTypeId { get; set; }
        public string Description { get; set; } = "";
        public string ContactDetail { get; set; } = "";
        public Boolean MarketingAllowed { get; set; }
        public int StatusId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int UpdatedBy { get; set; }
    }
}

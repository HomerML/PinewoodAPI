namespace PinewoodRazor.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public int TitleId { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string KnownAs { get; set; } = "";
        public DateTime BirthDate { get; set; }
        public int StatusId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int UpdatedBy { get; set; }

    }
}

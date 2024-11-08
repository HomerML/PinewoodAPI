namespace PinewoodAPI.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public int CustomerId { get; set; }
        public int AddressTypeId { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? AddressLine3 { get; set; }
        public string? Town { get; set; }
        public string? City { get; set; }
        public string? County { get; set; }
        public string? PostCode { get; set; }
        public Boolean MarketingAllowed { get; set; }
        public int StatusId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int UpdatedBy { get; set; }
    }

    public class AddressViewModel
    {
        public int AddressId { get; set; }
        public string? AddressDescription { get; set; }
        public string? AddressLine1 { get; set; }
        public string? Town { get; set; }
        public string? County { get; set; }
        public string? PostCode { get; set; }
        public Boolean MarketingAllowed { get; set; }
    }
}

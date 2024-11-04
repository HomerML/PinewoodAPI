namespace PinewoodAPI.Models
{
    public class AddressType
    {
        public int AddressTypeId { get; set; }
        public string AddressDescription { get; set; } = "";
        public int StatusId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int UpdatedBy { get; set; }


    }
}

namespace PinewoodAPI.Models
{
    public class Title
    {
        public int TitleId { get; set; }
        public string TitleDescription { get; set; } = "";
        public int StatusId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int UpdatedBy { get; set; }
    }
}

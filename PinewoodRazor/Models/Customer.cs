using Microsoft.AspNetCore.Mvc.Rendering;

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


    public class CustomerViewModel
    {
        public Customer Customer { get; set; }
        public Contact Contact { get; set; }
        public Address Address { get; set; }
        public Activity Activity { get; set; }
        public IEnumerable<SelectListItem> TitleList { get; set; }
        public IEnumerable<SelectListItem> StatusList { get; set; }
        public ICollection<ContactViewModel> ContactList { get; set; }
        public ICollection<AddressViewModel> AddressList { get; set; }
        public ICollection<ActivityViewModel> ActivityList { get; set; }

        public ContactViewModel ContactViewModel { get; set; }
        public AddressViewModel AddressViewModel { get; set; }
        public ActivityViewModel ActivityViewModel { get; set; }
    }
}

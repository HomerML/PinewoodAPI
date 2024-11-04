using Microsoft.EntityFrameworkCore;
using PinewoodAPI.Data;
using PinewoodAPI.Models;

namespace PinewoodAPI
{
    public class Seed
    {
        private readonly DataContext _context;

        public Seed(DataContext context)
        {
            this._context = context;
        }


        public void SeedDataContext(DataContext dataContext)
        {
            if (!_context.Statuses.Any())
            {
                using (var transaction = dataContext.Database.BeginTransaction())
                {
                    var status = new List<Status>()
                    {
                        new Status()
                        {
                            StatusId = 1,
                            StatusDescription = "Active",
                            ModifiedDate = DateTime.Now
                        },
                        new Status()
                        {
                            StatusId = 2,
                            StatusDescription = "Disabled",
                            ModifiedDate = DateTime.Now
                        }
                    };

                    dataContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Statuses ON");

                    dataContext.Statuses.AddRange(status);
                    dataContext.SaveChanges();

                    dataContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Statuses OFF");

                    transaction.Commit();
                }
            }


            if (!_context.Users.Any())
            {
                using (var transaction = dataContext.Database.BeginTransaction())
                {
                    var user = new List<User>()
                    {
                        new User()
                        {
                            UserId = 1,
                            FirstName = "Matthew",
                            LastName = "Homer",
                            StatusId = 1,
                            CreatedDate = DateTime.Now,
                            ModifiedDate = DateTime.Now
                        },
                        new User()
                        {
                            UserId = 2,
                            FirstName = "Otto",
                            LastName = "Mann",
                            StatusId = 1,
                            CreatedDate = DateTime.Now,
                            ModifiedDate = DateTime.Now
                        }
                    };

                    dataContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Users ON");

                    dataContext.Users.AddRange(user);
                    dataContext.SaveChanges();

                    dataContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Users OFF");

                    transaction.Commit();
                }
            }


            if (!_context.Titles.Any())
            {
                using (var transaction = dataContext.Database.BeginTransaction())
                {
                    var title = new List<Title>()
                    {
                        new Title()
                        {
                            TitleId = 1,
                            TitleDescription = "Mr",
                            StatusId = 1,
                            ModifiedDate = DateTime.Now,
                            UpdatedBy = 1
                        },
                        new Title()
                        {
                            TitleId = 2,
                            TitleDescription = "Mrs",
                            StatusId = 1,
                            ModifiedDate = DateTime.Now,
                            UpdatedBy = 1
                        },
                        new Title()
                        {
                            TitleId = 3,
                            TitleDescription = "Miss",
                            StatusId = 1,
                            ModifiedDate = DateTime.Now,
                            UpdatedBy = 1
                        },
                        new Title()
                        {
                            TitleId = 4,
                            TitleDescription = "Dr",
                            StatusId = 1,
                            ModifiedDate = DateTime.Now,
                            UpdatedBy = 1
                        },
                        new Title()
                        {
                            TitleId = 5,
                            TitleDescription = "Prefer Not To Say",
                            StatusId = 1,
                            ModifiedDate = DateTime.Now,
                            UpdatedBy = 1
                        }
                    };

                    dataContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Titles ON");

                    dataContext.Titles.AddRange(title);
                    dataContext.SaveChanges();

                    dataContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Titles OFF");

                    transaction.Commit();
                }
            }


            if (!_context.EventTypes.Any())
            {
                using (var transaction = dataContext.Database.BeginTransaction())
                {
                    var eventTypes = new List<EventType>()
                    {
                        new EventType()
                        {
                            EventTypeId = 1,
                            EventDescription = "Email Sent",
                            StatusId = 1,
                            ModifiedDate = DateTime.Now,
                            UpdatedBy = 1
                        },
                        new EventType()
                        {
                            EventTypeId = 2,
                            EventDescription = "Email Received",
                            StatusId = 1,
                            ModifiedDate = DateTime.Now,
                            UpdatedBy = 1
                        },
                        new EventType()
                        {
                            EventTypeId = 3,
                            EventDescription = "Phone Call Made",
                            StatusId = 1,
                            ModifiedDate = DateTime.Now,
                            UpdatedBy = 1
                        },
                        new EventType()
                        {
                            EventTypeId = 4,
                            EventDescription = "Phone Call Received",
                            StatusId = 1,
                            ModifiedDate = DateTime.Now,
                            UpdatedBy = 1
                        }
                    };

                    dataContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT EventTypes ON");

                    dataContext.EventTypes.AddRange(eventTypes);
                    dataContext.SaveChanges();

                    dataContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT EventTypes OFF");

                    transaction.Commit();
                }
            }


            if (!_context.Customers.Any())
            {
                using (var transaction = dataContext.Database.BeginTransaction())
                {
                    var customers = new List<Customer>()
                    {
                        new Customer()
                        {
                            CustomerId = 1,
                            TitleId = 1,
                            FirstName = "Homer Jay",
                            LastName = "Simpson",
                            KnownAs = "Homer",
                            BirthDate = new DateTime(1956, 5, 12),
                            StatusId = 1,
                            CreatedDate = DateTime.Now,
                            ModifiedDate = DateTime.Now,
                            UpdatedBy = 1
                        },
                        new Customer()
                        {
                            CustomerId = 2,
                            TitleId = 1,
                            FirstName = "Walter Seymour",
                            LastName = "Skinner",
                            KnownAs = "Seymour",
                            BirthDate = new DateTime(1944, 7, 12),
                            StatusId = 1,
                            CreatedDate = DateTime.Now,
                            ModifiedDate = DateTime.Now,
                            UpdatedBy = 1
                        }
                    };

                    dataContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Customers ON");

                    dataContext.Customers.AddRange(customers);
                    dataContext.SaveChanges();

                    dataContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Customers OFF");

                    transaction.Commit();
                }
            }


            if (!_context.ContactTypes.Any())
            {
                using (var transaction = dataContext.Database.BeginTransaction())
                {
                    var contactTypes = new List<ContactType>()
                    {
                        new ContactType
                        {
                            ContactTypeId = 1,
                            ContactDescription = "Mobile",
                            StatusId = 1,
                            ModifiedDate = DateTime.Now,
                            UpdatedBy = 1
                        },
                        new ContactType
                        {
                            ContactTypeId = 2,
                            ContactDescription = "email",
                            StatusId = 1,
                            ModifiedDate = DateTime.Now,
                            UpdatedBy = 1
                        }
                    };

                    dataContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT ContactTypes ON");

                    dataContext.ContactTypes.AddRange(contactTypes);
                    dataContext.SaveChanges();

                    dataContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT ContactTypes OFF");

                    transaction.Commit();
                }
            }


            if (!_context.Contacts.Any())
            {
                using (var transaction = dataContext.Database.BeginTransaction())
                {
                    var contacts = new List<Contact>()
                    {
                        new Contact
                        {
                            ContactId = 1,
                            CustomerId = 1,
                            ContactTypeId = 1,
                            ContactDetail = "07917 633 706",
                            Description = "Main Contact",
                            MarketingAllowed = true,
                            StatusId = 1,
                            CreatedDate = DateTime.Now,
                            ModifiedDate = DateTime.Now,
                            UpdatedBy = 1
                        },
                        new Contact
                        {
                            ContactId = 2,
                            CustomerId = 1,
                            ContactTypeId = 2,
                            ContactDetail = "chunkylover53@aol.com",
                            Description = "Main Contact",
                            MarketingAllowed = true,
                            StatusId = 1,
                            CreatedDate = DateTime.Now,
                            ModifiedDate = DateTime.Now,
                            UpdatedBy = 1
                        },
                        new Contact
                        {
                            ContactId = 3,
                            CustomerId = 2,
                            ContactTypeId = 1,
                            ContactDetail = "07917 633 706",
                            Description = "School Mobile",
                            MarketingAllowed = true,
                            StatusId = 1,
                            CreatedDate = DateTime.Now,
                            ModifiedDate = DateTime.Now,
                            UpdatedBy = 1
                        },
                        new Contact
                        {
                            ContactId = 4,
                            CustomerId = 2,
                            ContactTypeId = 2,
                            ContactDetail = "Seymour@SpringfieldElementarySchool.com",
                            Description = "Personal School contact",
                            MarketingAllowed = true,
                            StatusId = 1,
                            CreatedDate = DateTime.Now,
                            ModifiedDate = DateTime.Now,
                            UpdatedBy = 1
                        }
                    };

                    dataContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Contacts ON");

                    dataContext.Contacts.AddRange(contacts);
                    dataContext.SaveChanges();

                    dataContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Contacts OFF");

                    transaction.Commit();
                }
            }


            if (!_context.AddressTypes.Any())
            {
                using (var transaction = dataContext.Database.BeginTransaction())
                {
                    var addressTypes = new List<AddressType>()
                    {
                        new AddressType
                        {
                            AddressTypeId = 1,
                            AddressDescription = "Home Address",
                            StatusId =  1,
                            ModifiedDate = new DateTime(),
                            UpdatedBy = 1
                        },
                        new AddressType
                        {
                            AddressTypeId = 2,
                            AddressDescription = "Business Address",
                            StatusId = 1,
                            ModifiedDate = new DateTime(),
                            UpdatedBy = 1
                        }
                    };

                    dataContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT AddressTypes ON");

                    dataContext.AddressTypes.AddRange(addressTypes);
                    dataContext.SaveChanges();

                    dataContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT AddressTypes OFF");

                    transaction.Commit();
                }
            }


            if (!_context.Addresses.Any())
            {
                using (var transaction = dataContext.Database.BeginTransaction())
                {
                    var addresses = new List<Address>()
                    {
                        new Address
                        {
                            AddressId = 1,
                            CustomerId = 1,
                            AddressTypeId = 1,
                            AddressLine1 = "743 Evergreen Terrace",
                            Town = "Springfield",
                            County = "North Takoma",
                            PostCode = "80085",
                            MarketingAllowed = true,
                            StatusId = 1,
                            CreatedDate = new DateTime(),
                            ModifiedDate = new DateTime(),
                            UpdatedBy = 1
                        },
                        new Address
                        {
                            AddressId = 2,
                            CustomerId = 2,
                            AddressTypeId = 2,
                            AddressLine1 = "Springfield Elementary School",
                            AddressLine2 = "19 Plympton Street",
                            Town = "Springfield",
                            County = "North Takoma",
                            PostCode = "80086",
                            MarketingAllowed = true,
                            StatusId = 1,
                            CreatedDate = new DateTime(),
                            ModifiedDate = new DateTime(),
                            UpdatedBy = 1
                        }
                    };

                    dataContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Addresses ON");

                    dataContext.Addresses.AddRange(addresses);
                    dataContext.SaveChanges();

                    dataContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Addresses OFF");

                    transaction.Commit();
                }
            }


            if (!_context.Activities.Any())
            {
                using (var transaction = dataContext.Database.BeginTransaction())
                {
                    var activities = new List<Activity>()
                    {
                        new Activity
                        {
                            ActivityId = 1,
                            CustomerId = 1,
                            EventTypeId = 4,
                            ActivityDate = new DateTime(),
                            Notes = "Wants Info about new Estate Car",
                            StatusId = 1,
                            ModifiedDate = DateTime.Now,
                            UpdatedBy = 1
                        },
                        new Activity
                        {
                            ActivityId = 2,
                            CustomerId = 1,
                            EventTypeId = 3,
                            ActivityDate = new DateTime(),
                            Notes = "No answer, send info",
                            StatusId = 1,
                            ModifiedDate = DateTime.Now,
                            UpdatedBy = 2
                        },
                        new Activity
                        {
                            ActivityId = 3,
                            CustomerId = 1,
                            EventTypeId = 1,
                            ActivityDate = new DateTime(),
                            Notes = "Sent email of available cars",
                            StatusId = 1,
                            ModifiedDate = DateTime.Now,
                            UpdatedBy = 2
                        },
                        new Activity
                        {
                            ActivityId = 4,
                            CustomerId = 2,
                            EventTypeId = 4,
                            ActivityDate = new DateTime(),
                            Notes = "Wants another minibus",
                            StatusId = 1,
                            ModifiedDate = DateTime.Now,
                            UpdatedBy = 2
                        },
                        new Activity
                        {
                            ActivityId = 5,
                            CustomerId = 2,
                            EventTypeId = 1,
                            ActivityDate = new DateTime(),
                            Notes = "Sent email of Minibus details",
                            StatusId = 1,
                            ModifiedDate = DateTime.Now,
                            UpdatedBy = 1
                        }
                    };

                    dataContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Activities ON");

                    dataContext.Activities.AddRange(activities);
                    dataContext.SaveChanges();

                    dataContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Activities OFF");

                    transaction.Commit();
                }
            }



        }


    }
}

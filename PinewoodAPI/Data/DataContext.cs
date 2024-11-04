using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PinewoodAPI.Models;
using System.Collections.Generic;

namespace PinewoodAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Status> Statuses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ContactType> ContactTypes { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<AddressType> AddressTypes { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Activity> Activities { get; set; }
    }
}

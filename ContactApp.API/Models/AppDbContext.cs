using ContactAppModels;
using Microsoft.EntityFrameworkCore;

namespace ContactApp.API.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
           
        }

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed Contact Table
            modelBuilder.Entity<Contact>().HasData(new Contact
            {
                Id = 1001,
                FirstName = "John",
                LastName = "Doe",
                Email = "johndoe@example.com",
                DateOfBirth = new DateTime(1990, 5, 15),
                Phonenumber = "+2349050160648",
                Address = "Lagos",
                Gender = Gender.Male,
                Occupation = "Engineer",
                PhotoPath = "Images/john.jpg"
            });

            modelBuilder.Entity<Contact>().HasData(new Contact
            {
                Id = 1002,
                FirstName = "Sarah",
                LastName = "Johnson",
                Email = "sarahj@example.com",
                DateOfBirth = new DateTime(1985, 11, 3),
                Phonenumber = "+2347069357893",
                Address = "Kano",
                Gender = Gender.Female,
                Occupation = "Entrepreneur",
                PhotoPath = "Images/sarah.jpg"
            });

            modelBuilder.Entity<Contact>().HasData(new Contact
            {
                Id = 1003,
                FirstName = "Michael",
                LastName = "Smith",
                Email = "michaels@example.com",
                DateOfBirth = new DateTime(1988, 7, 25),
                Phonenumber = "+2348165473980",
                Address = "Jamaica",
                Gender = Gender.Male,
                Occupation = "Doctor",
                PhotoPath = "Images/michael.jpeg"
            });

            modelBuilder.Entity<Contact>().HasData(new Contact
            {
                Id = 1004,
                FirstName = "Maurice",
                LastName = "Gray",
                Email = "mauriceg@example.com",
                DateOfBirth = new DateTime(1989, 9, 26),
                Phonenumber = "+2347684567806",
                Address = "USA",
                Gender = Gender.Male,
                Occupation = "Banker",
                PhotoPath = "Images/maurice.jpg"
            });

        }
    }
}


using Microsoft.EntityFrameworkCore;

namespace Clubb.Model.Data
{
    public class AppDbcontext:DbContext
    {
        public AppDbcontext(DbContextOptions options) : base(options)
        {
        }

       

        public DbSet<Member> Members { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Member 1 : 1 Membership
            modelBuilder.Entity<Membership>()
                .HasOne(m => m.Member)
                .WithOne(m => m.Membership)
                .HasForeignKey<Membership>(m => m.MemberId);

            // Member 1 : M Booking
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Member)
                .WithMany(m => m.Bookings)
                .HasForeignKey(b => b.MemberId);

            // Facility 1 : M Booking
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Facility)
                .WithMany(f => f.Bookings)
                .HasForeignKey(b => b.FacilityId);

            // Membership 1 : M Payment
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Membership)
                .WithMany(m => m.Payments)
                .HasForeignKey(p => p.MembershipId);

            // Unique Facility Name
            modelBuilder.Entity<Facility>()
                .HasIndex(f => f.Name)
                .IsUnique();

            // Members
            modelBuilder.Entity<Member>().HasData(
                new Member
                {
                    Id = 1,
                    FullName = "Ahmed Mohamed",
                    Email = "ahmed@example.com",
                    Phone = "01011112222",
                    BirthDate = new DateTime(2000, 5, 15)
                },
                new Member
                {
                    Id = 2,
                    FullName = "Mona Ali",
                    Email = "mona@example.com",
                    Phone = "01022223333",
                    BirthDate = new DateTime(1998, 9, 20)
                },
                new Member
                {
                    Id = 3,
                    FullName = "Omar Hassan",
                    Email = "omar@example.com",
                    Phone = "01033334444",
                    BirthDate = new DateTime(2002, 1, 10)
                }
            );

            // Memberships
            modelBuilder.Entity<Membership>().HasData(
                new Membership
                {
                    Id = 1,
                    Type = "Gold",
                    StartDate = new DateTime(2026, 1, 1),
                    EndDate = new DateTime(2027, 1, 1),
                    Price = 5000,
                    Status = "Active",
                    MemberId = 1
                },
                new Membership
                {
                    Id = 2,
                    Type = "Silver",
                    StartDate = new DateTime(2026, 3, 1),
                    EndDate = new DateTime(2027, 3, 1),
                    Price = 3000,
                    Status = "Active",
                    MemberId = 2
                },
                new Membership
                {
                    Id = 3,
                    Type = "Basic",
                    StartDate = new DateTime(2025, 1, 1),
                    EndDate = new DateTime(2026, 1, 1),
                    Price = 1500,
                    Status = "Expired",
                    MemberId = 3
                }
            );

            // Facilities
            modelBuilder.Entity<Facility>().HasData(
                new Facility
                {
                    Id = 1,
                    Name = "Swimming Pool",
                    Capacity = 30,
                    HourlyPrice = 250
                },
                new Facility
                {
                    Id = 2,
                    Name = "Gym Hall",
                    Capacity = 40,
                    HourlyPrice = 150
                },
                new Facility
                {
                    Id = 3,
                    Name = "Tennis Court",
                    Capacity = 10,
                    HourlyPrice = 200
                }
            );

            // Bookings
            modelBuilder.Entity<Booking>().HasData(
                new Booking
                {
                    Id = 1,
                    BookingDate = new DateTime(2026, 10, 10),
                    StartTime = new TimeSpan(10, 0, 0),
                    EndTime = new TimeSpan(12, 0, 0),
                    GroupSize = 10,
                    Status = "Confirmed",
                    MemberId = 1,
                    FacilityId = 1
                },
                new Booking
                {
                    Id = 2,
                    BookingDate = new DateTime(2026, 10, 11),
                    StartTime = new TimeSpan(14, 0, 0),
                    EndTime = new TimeSpan(15, 0, 0),
                    GroupSize = 8,
                    Status = "Confirmed",
                    MemberId = 2,
                    FacilityId = 2
                },
                new Booking
                {
                    Id = 3,
                    BookingDate = new DateTime(2026, 10, 12),
                    StartTime = new TimeSpan(16, 0, 0),
                    EndTime = new TimeSpan(17, 0, 0),
                    GroupSize = 4,
                    Status = "Cancelled",
                    MemberId = 3,
                    FacilityId = 3
                }
            );

            // Payments
            modelBuilder.Entity<Payment>().HasData(
                new Payment
                {
                    Id = 1,
                    Amount = 5000,
                    PaymentDate = new DateTime(2026, 1, 1),
                    PaymentMethod = "Card",
                    MembershipId = 1
                },
                new Payment
                {
                    Id = 2,
                    Amount = 3000,
                    PaymentDate = new DateTime(2026, 3, 1),
                    PaymentMethod = "Cash",
                    MembershipId = 2
                },
                new Payment
                {
                    Id = 3,
                    Amount = 1500,
                    PaymentDate = new DateTime(2025, 1, 1),
                    PaymentMethod = "Wallet",
                    MembershipId = 3
                }
            );
        }
    }
}

using Microsoft.EntityFrameworkCore;
using TemplateApi.Entities;

namespace TemplateApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    public DbSet<Participant> Participants { get; set; }
    public DbSet<Registration> Registrations { get; set; }
    public DbSet<Venue> Venues { get; set; }
    public DbSet<Speaker> Speakers { get; set; }
    public DbSet<Workshop> Workshops { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Registration>().HasKey( x => new {x.ParticipantId, x.WorkshopId});

        modelBuilder.Entity<Participant>().HasData(
            new Participant{ParticipantId = 1, FirstName = "John", LastName = "Doe", Email = "JOhnDoe@gmail.com", Phone = "2345678"},
            new Participant{ParticipantId = 2, FirstName = "John", LastName = "Doe", Email = "JOhnDoe@gmail.com", Phone = "2345678"},
            new Participant{ParticipantId = 3, FirstName = "John", LastName = "Doe", Email = "JOhnDoe@gmail.com", Phone = "2345678"});

        modelBuilder.Entity<Speaker>().HasData(
            new Speaker{SpeakerId = 1, FirstName = "John", LastName = "Pork", Bio = "goodBio", Email = "JohnPorl@gmail.com"},
            new Speaker{SpeakerId = 2, FirstName = "John", LastName = "Pork", Bio = "goodBio", Email = "JohnPorl@gmail.com"},
            new Speaker{SpeakerId = 3, FirstName = "John", LastName = "Pork", Bio = "goodBio", Email = "JohnPorl@gmail.com"});
        
        modelBuilder.Entity<Venue>().HasData(
            new Venue { VenueId = 1, Name = "London", Address = "London", Capacity = 19, HasProj = 1 },
            new Venue{VenueId = 2, Name = "London", Address = "London", Capacity = 19, HasProj = 1},
            new Venue{VenueId = 3, Name = "Tokyo", Address = "Shibuya", Capacity = 19, HasProj = 1});
        
        modelBuilder.Entity<Workshop>().HasData(
            new Workshop{WorkShopId = 1, SpeakerId = 1, VenueId = 1, Title = "writing", Description = "Writing fast", WorkshopDate = new DateTime(2026, 1, 1), MaxCapacity = 30, DifficultyLevel = "Hard"},
            new Workshop{WorkShopId = 2, SpeakerId = 1, VenueId = 1, Title = "writing", Description = "Writing fast", WorkshopDate = new DateTime(2026, 1, 1), MaxCapacity = 30, DifficultyLevel = "Hard"},
            new Workshop{WorkShopId = 3, SpeakerId = 1, VenueId = 1, Title = "writing", Description = "Writing fast", WorkshopDate = new DateTime(2026, 1, 1), MaxCapacity = 30, DifficultyLevel = "Hard"}
        );

        modelBuilder.Entity<Registration>().HasData(
            new Registration{WorkshopId = 1, ParticipantId = 1, Registered = new DateTime(2020,1,1), FeedbackId = 1},
            new Registration{WorkshopId = 1, ParticipantId = 2, Registered = new DateTime(2020,1,1), FeedbackId = 1},
            new Registration{WorkshopId = 2, ParticipantId = 1, Registered = new DateTime(2020,1,1), FeedbackId = 1});
    }
}

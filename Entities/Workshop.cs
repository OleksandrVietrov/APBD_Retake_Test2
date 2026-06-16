using System.ComponentModel.DataAnnotations;

namespace TemplateApi.Entities;

public class Workshop
{
    public int WorkShopId { get; set; }
    
    public int SpeakerId { get; set; }
    public Speaker Speaker { get; set; } = null!;
    
    public int VenueId { get; set; }
    public Venue Venue { get; set; } = null!;

    [MaxLength(200)] public string Title { get; set; } = null!;
    [MaxLength(500)] public string Description { get; set; } = null!;
    public DateTime WorkshopDate { get; set; }
    public int MaxCapacity { get; set; }
    [MaxLength(50)]
    public string DifficultyLevel { get; set; } = null!;
}
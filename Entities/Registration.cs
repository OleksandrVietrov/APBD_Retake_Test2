namespace TemplateApi.Entities;

public class Registration
{
    public int WorkshopId { get; set; }
    public Workshop Workshop { get; set; } = null!;
    
    public int ParticipantId { get; set; }
    public Participant Participant { get; set; } = null!;
    
    public DateTime Registered { get; set; }
    public int? FeedbackId { get; set; }
}
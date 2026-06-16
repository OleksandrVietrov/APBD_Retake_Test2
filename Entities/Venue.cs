namespace TemplateApi.Entities;

public class Venue
{
    public int VenueId {get; set;}
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public int Capacity { get; set; }
    public int HasProj {get; set; }
    
    public List<Workshop> Workshops { get; set; } = null!;
}
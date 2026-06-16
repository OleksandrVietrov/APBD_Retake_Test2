using System.ComponentModel.DataAnnotations;

namespace TemplateApi.DTOs;

public class ItemGetDto
{
    public int SpeakerId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Bio { get; set; } = null!;
    public string Email { get; set; } = null!;
    public List<WorkshopDto> Workshops { get; set; } = null!;
}

public class WorkshopDto
{
    public int WorkshopId { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime WorkshopDate { get; set; }
    public int MaxCapacity { get; set; }
    public string DifficultyLevel { get; set; } = null!;
    public VenueDto Venue { get; set; } = null!;
    public List<RegistrationDto> Registrations { get; set; } = null!;
}
public class VenueDto
{
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public int Capacity { get; set; }
    public int HasProject { get; set; }
}

public class RegistrationDto
{
    public string ParticipantId { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime RegisteredAt { get; set; }
    public int HasProjector { get; set; }
}











// ============ INPUT DTOs (shape of POST.json / PUT.json) -- WITH validation ============
public class CreateItemDto
{
    [Required][MaxLength(50)]
    public string FirstName { get; set; } = null!;
    [Required][MaxLength(100)]
    public string LastName { get; set; } = null!;
    [Required][MaxLength(100)]
    public string Email { get; set; } = null!;
    [Required] [MaxLength(9)] 
    public string Phone { get; set; } = null!;
}


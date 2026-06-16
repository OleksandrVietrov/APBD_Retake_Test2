using System.ComponentModel.DataAnnotations;

namespace TemplateApi.Entities;

public class Participant
{
    public int ParticipantId { get; set; }
    [MaxLength(50)] public string FirstName { get; set; } = null!;
    [MaxLength(100)] public string LastName { get; set; } = null!;
    [MaxLength(100)] public string Email { get; set; } = null!;
    [MaxLength(9)] public string Phone { get; set; } = null!;

}
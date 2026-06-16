using System.ComponentModel.DataAnnotations;

namespace TemplateApi.Entities;

public class Speaker
{
    public int SpeakerId {get; set;}
    [MaxLength(50)]
    public string FirstName { get; set; } = null!;
    [MaxLength(100)]
    public string LastName { get; set; } = null!;
    [MaxLength(500)]
    public string Bio { get; set; } = null!;
    [MaxLength(100)]
    public string Email { get; set; } = null!;
    
    public List<Workshop> Workshops { get; set; } = null!;
}
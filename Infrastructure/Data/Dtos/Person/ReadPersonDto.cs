using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Data.Dtos.Person;

public class ReadPersonDto
{
    [Required, StringLength(20)]
    public string? FirstName { get; set; }
    [Required, StringLength(50)]
    public string? LastName { get; set; }
    [Required, StringLength(9)]
    public string? Gender { get; set; }
}

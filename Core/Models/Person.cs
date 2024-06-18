using System.ComponentModel.DataAnnotations;

namespace Core.Models;

public class Person
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required, MaxLength(20)]
    public string? FirstName { get; set; }
    [Required, MaxLength(50)]
    public string? LastName { get; set; }
    [Required, MaxLength(9)]
    public string? Gender { get; set; }
}

using System.ComponentModel.DataAnnotations;
using Api.Models;

namespace Api.Domain.Entities;

public class User : Login
{
    [Key]
    public Guid Id { get; init; } = Guid.NewGuid();
    [Required]
    [StringLength(50)]
    public string Name { get; private set; } = default!;
    [Required]
    [StringLength(50)]
    public string ContractType { get; private set; } = default!;
}

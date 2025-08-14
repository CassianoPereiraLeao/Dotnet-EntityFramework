using System.ComponentModel.DataAnnotations;
using Api.Models;
using Api.OwnedType;

namespace Api.Domain.Entities;

public class Admin : Login
{
    [Key]
    public Guid Id { get; init; } = Guid.NewGuid();
    [Required]
    [StringLength(30)]
    public string Profile { get; private set; } = default!;
}


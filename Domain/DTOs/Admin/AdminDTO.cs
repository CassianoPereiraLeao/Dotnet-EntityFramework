using Api.OwnedType;

namespace Api.Domain.DTOs.Admin;

public class AdminDTO
{
    public Email Email { get; set; } = default!;
    public Password Password { get; set; } = default!;
    public Password ConfirmPassword { get; set; } = default!;
}
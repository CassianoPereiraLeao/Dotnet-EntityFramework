using System.ComponentModel.DataAnnotations;
using Api.OwnedType;

namespace Api.Models;

public class Login
{
    [Required]
    [StringLength(100)]
    public Email Email { get; set; } = default!;
    [Required]
    [MinLength(8)]
    [MaxLength(12)]
    public Password Password { get; set; } = default!;

    public virtual void CreateEmail(Email email)
    {
        Email = email;
    }

    public virtual void CreatePassword(Password password)
    {
        string passwordToHash = Password.ToHash(password);
        Password = new Password(passwordToHash);
    }
}
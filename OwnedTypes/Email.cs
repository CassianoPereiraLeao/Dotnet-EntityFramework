using System.Text.RegularExpressions;

namespace Api.OwnedType;

public class Email
{
    public string Value { get; private set; } = default!;

    protected Email() { }

    public Email(string email)
    {
        Value = Validate(email);
    }

    private string Validate(string email)
    {
        if (string.IsNullOrEmpty(email))
        {
            throw new ArgumentNullException("O Email não pode ser vazio");
        }

        string pattern = @"^[a-zA-Z0-9._%+\-]+@[a-zA-Z0-9.\-]+\.[a-zA-Z]{2,}$";

        if (!Regex.IsMatch(email, pattern))
        {
            throw new ArgumentException("Email inválido");
        }

        return email;
    }

    public override string ToString()
    {
        return Value;
    }
}
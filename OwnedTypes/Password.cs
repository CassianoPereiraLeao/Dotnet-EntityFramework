using BCrypt.Net;

namespace Api.OwnedType;

public class Password
{
    public string Value { get; private set; } = default!;

    protected Password() { }

    public Password(string password)
    {
        Value = Validate(password);
    }

    private string Validate(string password)
    {
        if (string.IsNullOrEmpty(password))
        {
            throw new ArgumentNullException("A senha não pode ser vazia");
        }

        if (password.Length < 8 || password.Length > 12)
        {
            throw new ArgumentException("A senha deve conter entre 8 e 12 caracteres");
        }

        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool Verify(string password)
    {
        return BCrypt.Net.BCrypt.Verify(Value, password);
    }

    public override string ToString()
    {
        return Value;
    }
}
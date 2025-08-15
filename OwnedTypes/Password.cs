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

        if (password.Length < 8)
        {
            throw new ArgumentException("A senha deve conter mais de 8 caracteres");
        }

        return password;
    }

    public static string ToHash(Password password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password.ToString());
    }

    public bool Verify(string password)
    {
        return BCrypt.Net.BCrypt.Verify(password, Value);
    }

    public override string ToString()
    {
        return Value;
    }
}
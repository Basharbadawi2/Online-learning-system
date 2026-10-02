namespace Online_learning_system.Services;

public class PasswordResetService
{
    private readonly Dictionary<string, (string Token, DateTime Expiry)> _tokens
        = new();

    public string GenerateToken(string email)
    {
        var token = Guid.NewGuid().ToString();

        var expiry = DateTime.UtcNow.AddMinutes(15);

        _tokens[email] = (token, expiry);

        return token;
    }

    public bool ValidateToken(string email, string token)
    {
        if (!_tokens.TryGetValue(email, out var resetData))
        {
            return false;
        }

        if (resetData.Expiry < DateTime.UtcNow)
        {
            _tokens.Remove(email);
            return false;
        }

        return resetData.Token == token;
    }

    public void RemoveToken(string email)
    {
        _tokens.Remove(email);
    }
}
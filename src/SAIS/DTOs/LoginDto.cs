namespace SAIS.DTOs;
public class LoginDto
{
    public string Email { get; set; }
    public string Password { get; set; }
    public bool Remember { get; set; }
}

public class SelectItem
{
    public string Value { get; set; }
    public string Text { get; set; }
}

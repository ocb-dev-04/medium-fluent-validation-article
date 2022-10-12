namespace Fluent.Validation.API.Models;

public class User
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string ConfirmEmail { get; set; }
    public int Age { get; set; }
    public List<string> Phones { get; set; }
}

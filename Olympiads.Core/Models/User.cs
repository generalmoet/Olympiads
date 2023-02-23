namespace Olympiads.Core.Models;

public class User
{
    public User( string firstName, string lastName, string email, string password, string phoneNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        PhoneNumber = phoneNumber;
    }

    public User() { }

    public readonly int Id;
    public int? TeamId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public bool EmailConfirmed { get; set; }
    public List<QuestionResponse>? Responses { get; set; }
    public int Scores { get; private set; }
}

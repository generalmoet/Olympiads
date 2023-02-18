namespace Olympiads.Core.Models;

public class User
{
    public User(int id, string firstName, string lastName, string email, string password, string phoneNumber, bool emailConfirmed, OlympiadTeam team = null)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        PhoneNumber = phoneNumber;
        EmailConfirmed = emailConfirmed;
        Team = team;
    }

    public readonly int Id;
    public int TeamId;
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public bool EmailConfirmed { get; set; }
    public OlympiadTeam? Team { get; set; }
    public Result Result { get; set; }
}

namespace Olympiads.Core.Authorization.Register;

public class RegisterRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Surname { get; set; }
    public string City { get; set; }
    public string SchoolClass { get; set; }
    public DateTime Birthday { get; set; }
    public string School { get; set; }
    public string PhoneNumber { get; set; }
    public bool EmailConfirmed { get; set; }
    public bool IsTeacher { get; set; }
    public string TeamName { get; set; }
}

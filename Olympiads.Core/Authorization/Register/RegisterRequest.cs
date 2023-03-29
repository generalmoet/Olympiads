using Olympiads.Core.Models;

namespace Olympiads.Core.Authorization.Register;

public class RegisterRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string City { get; set; }
    public string SchoolClass { get; set; }
    public DateTime Birthday { get; set; }
    public string School { get; set; }
    public string PhoneNumber { get; set; }
    public bool EmailConfirmed { get; set; }
    public string TeamName { get; set; }
    public string TeacherName { get; set; }
    public string TeacherPhone { get; set; }
    public string TeacherPost { get; set; }
}

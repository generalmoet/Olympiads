namespace Olympiads.Core.Models.Abstractions;

public abstract class User
{
    public User(string firstName, string lastName, string surname, string city, string schoolClass, string school, string email, string password, string phoneNubmer)
    {
        FirstName = firstName;
        LastName = lastName;
        Surname = surname;
        City = city;
        SchoolClass = schoolClass;
        School = school;
        Email = email;
        Password = password;
        PhoneNumber = phoneNubmer;
    }

    public User() { }

    public int Id;
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Surname { get; set; }
    public string City { get; set; }
    public string SchoolClass { get; set; }
    public string School { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public bool EmailConfirmed { get; set; }
}

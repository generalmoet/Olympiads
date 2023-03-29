namespace Olympiads.Core.Models;

public class User
{
    public User(string firstName, string lastName, string surname, string city, string schoolClass, string school, string email, string password, string phoneNubmer, DateTime birthday, List<UserAnswer> answers)
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
        Birthday = birthday;
        Answers = answers;
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
    public string TeacherName { get; set; }
    public string TeacherPhone { get; set; }
    public string TeacherPost { get; set; }
    public int TeamId { get; set; }
    public DateTime Birthday { get; set; }
    public List<UserAnswer>? Answers { get; set; }
    public int Scores { get; private set; }
}

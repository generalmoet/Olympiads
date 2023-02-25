using Olympiads.Core.Models.Abstractions;

namespace Olympiads.Core.Models;

public class Student : User
{
    public Student() { }

    public Student(string firstName, string lastName, string surname, string city, string schoolClass, string school, string email, string password, string phoneNubmer, DateTime birthday) 
        : base(firstName, lastName, surname, city, schoolClass, school, email, password, phoneNubmer)
    {
        Birthday = birthday;
    }

    public int? TeamId { get; set; }
    public DateTime Birthday { get; set; }
    public List<StudentAnswer>? Answers { get; set; }
    public int Scores { get; private set; }
}

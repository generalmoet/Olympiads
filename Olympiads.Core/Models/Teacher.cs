using System.Runtime.CompilerServices;
using Olympiads.Core.Models.Abstractions;

namespace Olympiads.Core.Models;

public class Teacher : User
{
    public Teacher(string firstName, string lastName, string surname, string city, string schoolClass, string school, string email, string password, string phoneNubmer) : base(firstName, lastName, surname, city, schoolClass, school, email, password, phoneNubmer)
    {

    }

    public Teacher() { }
    public Team Team { get; set; }
}

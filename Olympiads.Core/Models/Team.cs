namespace Olympiads.Core.Models;

public class Team
{
    public Team(string name, string city, Teacher teacher)
    {
        Name = name;
        City = city;
        Teacher = teacher;
        TeacherId = teacher.Id;
    }

    public Team() { }

    public int Id { get; set; }
    public string Name { get; set; }
    public string City { get; set; }
    public Teacher Teacher { get; set; }
    public int TeacherId { get; set; }
    public List<Student>? Students { get; set; }

    public void AddUser(Student user) => Students.Add(user);
    public void RemoveUser(Student user) => Students.Remove(user);
}

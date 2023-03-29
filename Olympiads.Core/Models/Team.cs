namespace Olympiads.Core.Models;

public class Team
{
    public Team(string name, string city)
    {
        Name = name;
        City = city;
    }

    public Team() { }
    public int Id { get; }
    public string Name { get; set; }
    public string City { get; set; }
    public List<User>? Students { get; set; }

    public void AddUser(User user) => Students.Add(user);
    public void RemoveUser(User user) => Students.Remove(user);
}

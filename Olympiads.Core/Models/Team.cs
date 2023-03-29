namespace Olympiads.Core.Models;

public class Team
{
    public Team(string name, string city, List<User> users)
    {
        Name = name;
        City = city;
        Users = users;
    }

    public Team() { }
    public int Id { get; }
    public string Name { get; set; }
    public string City { get; set; }
    public List<User>? Users { get; set; }

    public void AddUser(User user) => Users.Add(user);
    public void RemoveUser(User user) => Users.Remove(user);
}

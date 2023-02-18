namespace Olympiads.Core.Models;

public class OlympiadTeam
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<User> Users { get; set; }

    public void AddUser(User user) => Users.Add(user);
    public void RemoveUser(User user) => Users.Remove(user);
}

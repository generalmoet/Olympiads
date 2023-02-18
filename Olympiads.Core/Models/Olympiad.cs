namespace Olympiads.Core.Models;

public class Olympiad
{
    public Olympiad(int id, string name, string description, List<Question> questions)
    {
        Id = id;
        Name = name;
        Description = description;
        Questions = questions;
    }

    public int Id { get; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Question> Questions { get; private set; }


    public void AddQuestion(Question question) => Questions.Add(question);
    public void RemoveQuestion(Question question) => Questions.Remove(question);
}
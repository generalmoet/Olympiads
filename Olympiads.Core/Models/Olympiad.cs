namespace Olympiads.Core.Models;

public class Olympiad
{
    public Olympiad(int id, string name, string description, List<Question> questions, DateTime startTime, DateTime endTime)
    {
        Id = id;
        Name = name;
        Description = description;
        Questions = questions;
        StartTime = startTime;
        EndTime = endTime;
    }

    public int Id { get; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Question> Questions { get; private set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    public void AddQuestion(Question question) => Questions.Add(question);
    public void RemoveQuestion(Question question) => Questions.Remove(question);
}
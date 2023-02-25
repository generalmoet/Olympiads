namespace Olympiads.Core.Models.Abstractions;

public abstract class Answer
{
    public int Id { get; private set; }
    public int QuestionId { get; set; }
    public string Value { get; set; }

    public Answer(string value, int questionId)
    {
        QuestionId = questionId;
        Value = value;
    }

    public Answer() { }
}

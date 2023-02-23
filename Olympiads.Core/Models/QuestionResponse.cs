namespace Olympiads.Core.Models; 

public class QuestionResponse 
{
    public QuestionResponse(int id, string value, int questionId)
    {
        Id = id;
        Value = value;
        QuestionId = questionId;
    }

    public QuestionResponse() { }
    public int Id { get; private set; }
    public int QuestionId { get; private set; }
    public string Value { get; private set; }

    public bool Right { get; private set; }

    public void Update(string value) => Value = value;

    public void Update(QuestionResponse response) => Value = response.Value;
}

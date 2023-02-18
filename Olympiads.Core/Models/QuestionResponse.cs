namespace Olympiads.Core.Models; 

public class QuestionResponse 
{
    public QuestionResponse(int id, object value)
    {
        Id = id;
        Value = value;
    }

    public int Id { get; private set; }
    public object Value { get; private set; }

    public void Update(object value) => Value = value;

    public void Update(QuestionResponse response) => Value = response.Value;
}

using Olympiads.Core.Models.Abstractions;

namespace Olympiads.Core.Models;

public class QuestionAnswer : Answer
{
    public bool RightAnswer { get; private set; }

    public QuestionAnswer(string value, int questionId) : base(value, questionId)
    {
        Value= value;
        QuestionId= questionId;
    }

    public QuestionAnswer() { }

    public void ChangeValue(string value) => Value = value;
    public void ChangeValue(QuestionAnswer answer) => Value = answer.Value;
}

using Olympiads.Core.Models.Abstractions;

namespace Olympiads.Core.Models;

public class StudentAnswer : Answer
{
    public StudentAnswer() { }

    public StudentAnswer(string value, int questionId, int studentId) : base(value, questionId)
    {
        Value= value;
        QuestionId= questionId;
        StudentId = studentId;
    }

    public int StudentId { get; set; }
}

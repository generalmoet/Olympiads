using Olympiads.Core.Models.Abstractions;

namespace Olympiads.Core.Models;

public class Question
{
    public Question(int questionId, string questionText, int olympiadId, int countOfScore = 1)
    {
        Id = questionId;
        QuestionText = questionText;
        OlympiadId = olympiadId;
        CountOfScore = countOfScore;
    }

    public Question() { }

    public int Id { get; private set; }
    public int OlympiadId { get; private set; }
    public int CountOfScore { get; set; }
    public string QuestionText { get; set; }
    public List<QuestionAnswer> QuestionAnswers = new();
    public List<StudentAnswer> StudentAnswers = new();

    public void AddAnswer(QuestionAnswer answer) => QuestionAnswers.Add(answer);
    
    public void RemoveAnswer(QuestionAnswer answer) => QuestionAnswers.Remove(answer);

    public void UpdateQuestion(Question questions)
    {
        CountOfScore = questions.CountOfScore;
        QuestionText = questions.QuestionText;
    }

    public void UpdateAnswer(QuestionAnswer newAnswer)
    {
        QuestionAnswers.FirstOrDefault(answer => answer.Id == newAnswer.Id).ChangeValue(newAnswer);
    }
}

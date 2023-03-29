namespace Olympiads.Core.Models;

public class Question
{
    public Question(string questionText, int olympiadId, List<QuestionAnswer> questionAnswers, List<UserAnswer> userAnswers, int countOfScore = 1)
    {
        QuestionText = questionText;
        OlympiadId = olympiadId;
        CountOfScore = countOfScore;
        QuestionAnswers = questionAnswers;
        UserAnswers = userAnswers;
    }

    public Question() { }

    public int Id { get; private set; }
    public int OlympiadId { get;  set; }
    public int CountOfScore { get; set; }
    public string QuestionText { get; set; }
    public List<QuestionAnswer>? QuestionAnswers;
    public List<UserAnswer>? UserAnswers;

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

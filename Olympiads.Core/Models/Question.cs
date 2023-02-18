namespace Olympiads.Core.Models;

public class Question
{
    public Question(int questionId, string questionText, HashSet<QuestionResponse> questionResponses, QuestionResponse rightResponse, int olympiadId, int countOfScore = 1)
    {
        QuestionId = questionId;
        QuestionText = questionText;
        QuestionResponses = questionResponses;
        RightResponse = rightResponse;
        OlympiadId = olympiadId;
        CountOfScore = countOfScore;
    }

    public int QuestionId { get; private set; }
    public int OlympiadId { get; private set; }
    public int CountOfScore { get; set; }
    public string QuestionText { get; set; }
    public HashSet<QuestionResponse> QuestionResponses { get; private set; }
    public QuestionResponse RightResponse { get; private set; }

    public void AddResponse(QuestionResponse response) => QuestionResponses.Add(response);
    
    public void RemoveResponse(QuestionResponse response) => QuestionResponses.Remove(response);

    public void UpdateResponse(QuestionResponse newResponse)
    {
        QuestionResponses.FirstOrDefault(response => response.Id == newResponse.Id).Update(newResponse);
    }

    public void ChangeRightResponse(QuestionResponse resposne) => RightResponse = resposne;
}

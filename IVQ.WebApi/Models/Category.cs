namespace IVQ.WebApi.Models;

public class Category
{
    public int Id { get; set; }
    public IEnumerable<Question> Questions { get; set; }
    public int QuestionId { get; set; }
}
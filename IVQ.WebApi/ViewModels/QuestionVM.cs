using IVQ.WebApi.Models;

namespace IVQ.WebApi.ViewModels;

public class QuestionVM
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public QuestionComplexity Complexity { get; set; }
    public IEnumerable<CategoryIdNameVM> Categories { get; set; }
    public int Likes { get; set; }
    public int Answers { get; set; }
}

public static partial class QuestionMappingExtensions
{
    public static QuestionVM ToVm(this Question question)
    {
        return new QuestionVM
        {
            Id = question.Id ,
            Title = question.Title,
            Description = question.Description,
            Complexity = question.Complexity,
            Categories = question.Categories.Select(c=>c.ToIdNameVm()),
            Likes = question.Likes,
            Answers = question.Answers
            
        };
    }
}
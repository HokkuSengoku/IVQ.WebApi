using IVQ.WebApi.Models;

namespace IVQ.WebApi.ViewModels;

public class CreateQuestionVM
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public QuestionComplexity Complexity { get; set; }
}

public static partial class QuestionMappingExtensions
{
    public static Question ToEntity(this CreateQuestionVM vm)
    {
        return new Question
        {
            Title = vm.Title,
            Description = vm.Description,
            Complexity = vm.Complexity
        };
    }
}
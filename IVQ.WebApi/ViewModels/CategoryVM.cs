namespace IVQ.WebApi.ViewModels;

public class CategoryVM
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public IEnumerable<QuestionVM> Questions { get; set; }
}

public static partial class CategoryMappingExtensions
{
}
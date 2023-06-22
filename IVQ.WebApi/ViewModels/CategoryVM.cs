namespace IVQ.WebApi.ViewModels;

public class CategoryVM
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public IEnumerable<QuestionVM> Questions { get; set; } = new HashSet<QuestionVM>();
}

public static partial class CategoryMappingExtensions
{
}
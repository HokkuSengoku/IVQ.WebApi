
namespace IVQ.WebApi.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public IEnumerable<Question> Questions { get; set; } = new HashSet<Question>();
}
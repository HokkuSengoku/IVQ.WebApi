using IVQ.WebApi.Models;

namespace IVQ.WebApi.ViewModels;

public class CategoryIdNameVM
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
}

public static partial class CategoryMappingExtensions
{
    public static CategoryIdNameVM ToIdNameVm(this Category category)
    {
        return new CategoryIdNameVM
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description
        };
    }
}
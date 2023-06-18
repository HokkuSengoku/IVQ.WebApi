using System.ComponentModel.DataAnnotations;

namespace IVQ.WebApi.Models;

public class Question
{
    [Key]
    public int Id { get; set; }
    public int Likes { get; set; }
    public int Answers { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public QuestionComplexity Complexity { get; set; }
}
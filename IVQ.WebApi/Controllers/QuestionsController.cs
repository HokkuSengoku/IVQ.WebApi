using IVQ.WebApi.Data;
using IVQ.WebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IVQ.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuestionsController : ControllerBase
{
    private readonly IVQDbContext _db;

    public QuestionsController(IVQDbContext db)
    {
        _db = db;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<QuestionVM>>> GetQuestions()
    {
        var questions = await _db.Questions
            .Include(q => q.Categories)
            .Select(q => q.ToVm())
            .AsNoTracking()
            .ToListAsync();

        return Ok(questions);
    }

    [HttpPost]
    public async Task<ActionResult<QuestionVM>> CreateQuestion(CreateQuestionVM request)
    {
        var createdQuestion = _db.Questions.Add(request.ToEntity());

        await _db.SaveChangesAsync();

        return Ok(createdQuestion.Entity.ToVm());
    }

}
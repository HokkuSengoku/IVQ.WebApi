using IVQ.WebApi.Data;
using IVQ.WebApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IVQ.WebApi.Repositories.Contracts;

public class QuestionRepository : IQuestionRepository
{
    private readonly IVQDbContext _context;

    public QuestionRepository(IVQDbContext context)
    {
        _context = context;
    }

    private async Task<bool> CategoryExists(int categoryId, int questionId)
    {
        return await _context.Categories.AnyAsync(c => c.Id == categoryId && c.QuestionId == questionId);
    }

    public async Task<IEnumerable<Question>> GetAllAsync()
    {
        var questions = await _context.Questions.ToListAsync();
        return questions;
    }

    public async Task<Question> GetAsync(int id)
    {
        var question = await _context.Questions.FindAsync(id);
        return question;
    }

    public Task<IEnumerable<Category>> GetAllCategoriesAsync()
    {
        // processing
        throw new NotImplementedException();
    }

    public Task<Category> GetCategoryAsync(int id)
    {
        // processing
        throw new NotImplementedException();
    }

    public void Add(Question questionToAdd)
    {
        _context.Add(questionToAdd);
        _context.SaveChanges();
    }

    public Task<Question> PutAsync(Question question)
    {
        throw new NotImplementedException();
    }

    public Task<Question> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}
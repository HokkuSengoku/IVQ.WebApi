using IVQ.WebApi.Models;

namespace IVQ.WebApi.Repositories.Contracts;

public interface IQuestionRepository
{
    Task<IEnumerable<Question>> GetAllAsync();
    Task<Question> GetAsync(int id);
    Task<IEnumerable<Category>> GetAllCategoriesAsync();
    Task<Category> GetCategoryAsync(int id);
    void Add(Question question);
    Task<Question> PutAsync(Question question);
    Task<Question> DeleteAsync(int id);
    
}
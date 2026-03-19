using LMS.Domain.Entities;
namespace LMS.Domain.Interfaces.Repositories;

public interface IFeedbackRepository : IGenericRepository<Feedback>
{
    Task<IEnumerable<Feedback>> GetAllFeedbacksByBookIdAsync(int bookId);
}

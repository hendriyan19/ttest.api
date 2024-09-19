using test.api.Models;

namespace test.api.Repository
{
    public interface IRepositoryChecklist
    {
        Task<IEnumerable<Checklist>> GetAllChecklistsAsync();
        Task<Checklist> CreateChecklistAsync(Checklist checklist);
        Task<bool> DeleteChecklistAsync(int checklistId);
    }

}

using Microsoft.EntityFrameworkCore;
using test.api.Context;
using test.api.Models;

namespace test.api.Repository
{
    public class ChecklistRepository : IRepositoryChecklist
    {
        private readonly MyContext _context;

        public ChecklistRepository(MyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Checklist>> GetAllChecklistsAsync()
        {
            return await _context.Checklist.ToListAsync();
        }

        public async Task<Checklist> CreateChecklistAsync(Checklist checklist)
        {
            _context.Checklist.Add(checklist);
            await _context.SaveChangesAsync();
            return checklist;
        }

        public async Task<bool> DeleteChecklistAsync(int checklistId)
        {
            var checklist = await _context.Checklist.FindAsync(checklistId);
            if (checklist == null) return false;

            _context.Checklist.Remove(checklist);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

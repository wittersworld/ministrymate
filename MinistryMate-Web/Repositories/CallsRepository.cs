using Microsoft.EntityFrameworkCore;
using MinistryMate_Web.Data;
using MinistryMate_Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinistryMate_Web.Repositories
{
    public interface ICallsRepository
    {
        Task<IEnumerable<Call>> Get(string userId);
        Task<Call> Get(string userId, int? callId);
        Task Add(Call call);
        Task Update(Call call);
        Task Delete(string userId, int callId);
    }

    public class CallsRepository : ICallsRepository
    {
        private readonly ApplicationDbContext _context;

        public CallsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Call>> Get(string userId)
        {
            return await _context.Call.Where(c => c.UserId == userId).ToListAsync();
        }

        public async Task<Call> Get(string userId, int? callId)
        {
            return await _context.Call.SingleOrDefaultAsync(c => c.Id == callId && c.UserId == userId);
        }

        public async Task Add(Call call)
        {
            _context.Add(call);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Call call)
        {
            _context.Update(call);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(string userId, int callId)
        {
            var call = await _context.Call.SingleOrDefaultAsync(c => c.Id == callId && c.UserId == userId);
            _context.Call.Remove(call);
            await _context.SaveChangesAsync();
        }
    }
}

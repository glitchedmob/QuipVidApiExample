using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuipVid.Core.Data;
using QuipVid.Core.Models;

namespace QuipVid.Core.Repositories
{
    public class UserRepository : IReadRepository<User>
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<User>> GetAll()
        {
            return await _context.Users.AsNoTracking()
                .Include(u => u.Quips)
                .ThenInclude(q => q.Media)
                .ToListAsync();
        }

        public async Task<User> GetById(Guid id)
        {
            return await _context.Users.AsNoTracking()
                .Include(u => u.Quips)
                .ThenInclude(q => q.Media)
                .SingleOrDefaultAsync(u => u.Id == id);
        }
    }
}

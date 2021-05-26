using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuipVid.Core.Data;
using QuipVid.Core.Models;

namespace QuipVid.Core.Repositories
{
    public class QuipRepository : IRepository<Quip>
    {
        private readonly AppDbContext _context;

        public QuipRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IList<Quip>> GetAll()
        {
            return await _context.Quips.AsNoTracking()
                .Include(q => q.Media)
                .Include(q => q.Uploader)
                .ToListAsync();
        }

        public async Task<Quip> GetById(Guid id)
        {
            return await _context.Quips
                .AsNoTracking()
                .Include(q => q.Media)
                .Include(q => q.Uploader)
                .SingleOrDefaultAsync(q => q.Id == id);
        }

        public async Task<Quip> Create(Quip model)
        {
            var now = DateTimeOffset.Now;

            model.CreatedAt = now;
            model.UpdatedAt = now;

            _context.Quips.Add(model);
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task<Quip> Update(Quip model)
        {
            _context.Quips.Attach(model);
            _context.Entry(model).State = EntityState.Modified;

            model.UpdatedAt = DateTimeOffset.Now;

            await _context.SaveChangesAsync();

            return model;
        }

        public async Task<bool> Delete(Quip model)
        {
            if (_context.Entry(model).State == EntityState.Detached)
            {
                _context.Quips.Attach(model);
            }

            _context.Quips.Remove(model);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}

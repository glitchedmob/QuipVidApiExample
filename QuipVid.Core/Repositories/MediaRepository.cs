using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuipVid.Core.Data;
using QuipVid.Core.Models;

namespace QuipVid.Core.Repositories
{
    public class MediaRepository : IRepository<Media>
    {
        private readonly AppDbContext _context;

        public MediaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IList<Media>> GetAll()
        {
            return await _context.Media.AsNoTracking()
                .Include(m => m.Quips)
                .ThenInclude(q => q.Uploader)
                .ToListAsync();
        }

        public async Task<Media> GetById(Guid id)
        {
            return await _context.Media
                .AsNoTracking()
                .Include(m => m.Quips)
                .ThenInclude(q => q.Uploader)
                .SingleOrDefaultAsync(q => q.Id == id);
        }

        public async Task<Media> Create(Media model)
        {
            var now = DateTimeOffset.Now;

            model.CreatedAt = now;
            model.UpdatedAt = now;

            _context.Media.Add(model);
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task<Media> Update(Media model)
        {
            _context.Media.Attach(model);
            _context.Entry(model).State = EntityState.Modified;

            model.UpdatedAt = DateTimeOffset.Now;

            await _context.SaveChangesAsync();

            return model;
        }

        public async Task<bool> Delete(Media model)
        {
            if (_context.Entry(model).State == EntityState.Detached)
            {
                _context.Media.Attach(model);
            }

            _context.Media.Remove(model);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}

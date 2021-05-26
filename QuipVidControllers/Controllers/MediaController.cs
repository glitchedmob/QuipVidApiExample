using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuipVid.Core.Data;
using QuipVid.Core.Models;

namespace QuipVidControllers.Controllers
{
    [Route("media")]
    [ApiController]
    public class MediaController : Controller
    {
        private readonly AppDbContext _context;

        public MediaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Media>>> Index()
        {
            var media = await _context.Media.AsNoTracking()
                .Include(m => m.Quips)
                .ThenInclude(q => q.Uploader)
                .ToListAsync();

            media.ForEach(m =>
            {
                m.Quips.ToList().ForEach(q =>
                {
                    q.Media = null;
                    q.Uploader.Quips = new List<Quip>();
                });
            });

            return media;
        }
    }
}

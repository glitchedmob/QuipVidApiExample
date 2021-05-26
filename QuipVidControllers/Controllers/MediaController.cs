using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuipVid.Core.Models.Dto;
using QuipVid.Core.Repositories;

namespace QuipVidControllers.Controllers
{
    [Route("media")]
    [ApiController]
    public class MediaController : Controller
    {
        private readonly MediaRepository _mediaRepository;
        private readonly IMapper _mapper;

        public MediaController(MediaRepository mediaRepository, IMapper mapper)
        {
            _mediaRepository = mediaRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<MediaDto>>> Index()
        {
            var media = await _mediaRepository.GetAll();

            return _mapper.Map<List<MediaDto>>(media);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuipVid.Core.Models;
using QuipVid.Core.Repositories;
using QuipVidControllers.Requests;
using QuipVidControllers.Results;

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
        public async Task<ActionResult<IList<ListMediaResult>>> List()
        {
            var media = await _mediaRepository.GetAll();

            return _mapper.Map<List<ListMediaResult>>(media);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<GetMediaResult>> Get(Guid id)
        {
            var media = await _mediaRepository.GetById(id);

            if (media == null)
            {
                return NotFound();
            }

            return _mapper.Map<GetMediaResult>(media);
        }

        [HttpPost]
        public async Task<ActionResult<CreateMediaResult>> Create(CreateMediaRequest createMedia)
        {
            var media = new Media
            {
                Title = createMedia.Title,
            };

            await _mediaRepository.Create(media);

            var mediaDto = _mapper.Map<CreateMediaResult>(media);

            return CreatedAtAction(nameof(Get), new { id = mediaDto.Id }, mediaDto);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Update(Guid id, UpdateMediaRequest updateMedia)
        {
            var media = await _mediaRepository.GetById(id);

            if (media == null)
            {
                return NotFound();
            }

            media.Title = updateMedia.Title;

            await _mediaRepository.Update(media);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Destroy(Guid id)
        {
            var media = await _mediaRepository.GetById(id);

            if (media == null)
            {
                return NotFound();
            }

            await _mediaRepository.Delete(media);

            return NoContent();
        }
    }
}

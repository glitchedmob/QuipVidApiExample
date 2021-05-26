using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuipVid.Core.Models;
using QuipVid.Core.Models.Dto;
using QuipVid.Core.Repositories;
using QuipVidControllers.Requests;

namespace QuipVidControllers.Controllers
{
    [Route("quips")]
    [ApiController]
    public class QuipController : Controller
    {
        private readonly QuipRepository _quipRepository;
        private readonly IMapper _mapper;

        public QuipController(QuipRepository quipRepository, IMapper mapper)
        {
            _quipRepository = quipRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<QuipDto>>> Index()
        {
            var quips = await _quipRepository.GetAll();

            return _mapper.Map<List<QuipDto>>(quips);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<QuipDto>> Show(Guid id)
        {
            var quip = await _quipRepository.GetById(id);

            if (quip == null)
            {
                return NotFound();
            }

            return _mapper.Map<QuipDto>(quip);
        }

        [HttpPost]
        public async Task<ActionResult<QuipDto>> Create(CreateQuipRequest createQuip)
        {
            var quip = new Quip
            {
                Title = createQuip.Title,
                VideoUrl = createQuip.VideoUrl,
                ThumbnailUrl = createQuip.ThumbnailUrl,
                MediaId = createQuip.MediaId,
                UploaderId = createQuip.UploaderId,
            };

            await _quipRepository.Create(quip);

            quip = await _quipRepository.GetById(quip.Id);

            var quipDto = _mapper.Map<QuipDto>(quip);

            return CreatedAtAction(nameof(Show), new { id = quipDto.Id }, quipDto);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Update(Guid id, UpdateQuipRequest updateQuip)
        {
            var quip = await _quipRepository.GetById(id);

            if (quip == null)
            {
                return NotFound();
            }

            quip.Title = updateQuip.Title;
            quip.Views = updateQuip.Views;
            quip.VideoUrl = updateQuip.VideoUrl;
            quip.ThumbnailUrl = updateQuip.ThumbnailUrl;
            quip.MediaId = updateQuip.MediaId;
            quip.UploaderId = updateQuip.UploaderId;

            await _quipRepository.Update(quip);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Destroy(Guid id)
        {
            var quip = await _quipRepository.GetById(id);

            if (quip == null)
            {
                return NotFound();
            }

            await _quipRepository.Delete(quip);

            return NoContent();
        }
    }
}

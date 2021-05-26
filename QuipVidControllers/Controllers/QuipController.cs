using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuipVid.Core.Data;
using QuipVid.Core.Models.Dto;
using QuipVid.Core.Repositories;

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
    }
}

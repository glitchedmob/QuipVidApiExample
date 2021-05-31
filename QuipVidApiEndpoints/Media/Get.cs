using System;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuipVid.Core.Models.Dto;
using QuipVid.Core.Repositories;

namespace QuipVidApiEndpoints.Media
{
    [Route(Routes.Media)]
    public class Get : BaseAsyncEndpoint
        .WithRequest<GetMediaRequest>
        .WithResponse<MediaDto>
    {
        private readonly MediaRepository _mediaRepository;
        private readonly IMapper _mapper;

        public Get(MediaRepository mediaRepository, IMapper mapper)
        {
            _mediaRepository = mediaRepository;
            _mapper = mapper;
        }

        [HttpGet("{id:guid}")]
        public override async Task<ActionResult<MediaDto>> HandleAsync(GetMediaRequest request,
            CancellationToken cancellationToken = default)
        {
            var media = await _mediaRepository.GetById(request.Id);

            if (media == null)
            {
                return NotFound();
            }

            return _mapper.Map<MediaDto>(media);
        }
    }
}

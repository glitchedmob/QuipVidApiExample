using System.Collections.Generic;
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
    public class List : BaseAsyncEndpoint
        .WithoutRequest
        .WithResponse<List<MediaDto>>
    {
        private readonly MediaRepository _mediaRepository;
        private readonly IMapper _mapper;

        public List(MediaRepository mediaRepository, IMapper mapper)
        {
            _mediaRepository = mediaRepository;
            _mapper = mapper;
        }

        public override async Task<ActionResult<List<MediaDto>>> HandleAsync(
            CancellationToken cancellationToken = default)
        {
            var media = await _mediaRepository.GetAll();

            return _mapper.Map<List<MediaDto>>(media);
        }
    }
}

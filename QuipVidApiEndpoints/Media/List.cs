using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuipVid.Core.Repositories;

namespace QuipVidApiEndpoints.Media
{
    [Route(Routes.Media)]
    public class List : BaseAsyncEndpoint
        .WithoutRequest
        .WithResponse<IList<ListMediaResult>>
    {
        private readonly MediaRepository _mediaRepository;
        private readonly IMapper _mapper;

        public List(MediaRepository mediaRepository, IMapper mapper)
        {
            _mediaRepository = mediaRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public override async Task<ActionResult<IList<ListMediaResult>>> HandleAsync(
            CancellationToken cancellationToken)
        {
            var media = await _mediaRepository.GetAll();

            return _mapper.Map<List<ListMediaResult>>(media);
        }
    }
}

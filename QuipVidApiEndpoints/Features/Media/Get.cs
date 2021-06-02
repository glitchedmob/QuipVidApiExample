using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuipVid.Core.Repositories;
using Swashbuckle.AspNetCore.Annotations;

namespace QuipVidApiEndpoints.Features.Media
{
    [Route(Routes.Media)]
    public class Get : BaseAsyncEndpoint
        .WithRequest<GetMediaRequest>
        .WithResponse<GetMediaResult>
    {
        private readonly MediaRepository _mediaRepository;
        private readonly IMapper _mapper;

        public Get(MediaRepository mediaRepository, IMapper mapper)
        {
            _mediaRepository = mediaRepository;
            _mapper = mapper;
        }

        [HttpGet("{id:guid}")]
        [SwaggerOperation(Tags = new []{ "Media" })]
        public override async Task<ActionResult<GetMediaResult>> HandleAsync(GetMediaRequest request,
            CancellationToken cancellationToken)
        {
            var media = await _mediaRepository.GetById(request.Id);

            if (media == null)
            {
                return NotFound();
            }

            return _mapper.Map<GetMediaResult>(media);
        }
    }
}

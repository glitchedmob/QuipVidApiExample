using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuipVid.Core.Repositories;
using Swashbuckle.AspNetCore.Annotations;

namespace QuipVidApiEndpoints.Features.Quip
{
    [Route(Routes.Quips)]
    public class Get : BaseAsyncEndpoint
        .WithRequest<GetQuipRequest>
        .WithResponse<GetQuipResult>
    {
        private readonly QuipRepository _quipRepository;
        private readonly IMapper _mapper;

        public Get(QuipRepository quipRepository, IMapper mapper)
        {
            _quipRepository = quipRepository;
            _mapper = mapper;
        }

        [HttpGet("{id:guid}")]
        [SwaggerOperation(Tags = new []{ "Quip" })]
        public override async Task<ActionResult<GetQuipResult>> HandleAsync(GetQuipRequest request,
            CancellationToken cancellationToken)
        {
            var quip = await _quipRepository.GetById(request.Id);

            if (quip == null)
            {
                return NotFound();
            }

            return _mapper.Map<GetQuipResult>(quip);
        }
    }
}

using System.Collections.Generic;
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
    public class List : BaseAsyncEndpoint
        .WithoutRequest
        .WithResponse<IList<ListQuipResult>>
    {
        private readonly QuipRepository _quipRepository;
        private readonly IMapper _mapper;

        public List(QuipRepository quipRepository, IMapper mapper)
        {
            _quipRepository = quipRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [SwaggerOperation(Tags = new []{ "Quip" })]
        public override async Task<ActionResult<IList<ListQuipResult>>> HandleAsync(CancellationToken cancellationToken)
        {
            var quips = await _quipRepository.GetAll();

            return _mapper.Map<List<ListQuipResult>>(quips);
        }
    }
}

using System;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuipVid.Core.Repositories;
using QuipVidApiEndpoints.Extensions;
using Models = QuipVid.Core.Models;

namespace QuipVidApiEndpoints.Media
{
    [Route(Routes.Media)]
    public class Create : BaseAsyncEndpoint
        .WithRequest<CreateMediaRequest>
        .WithResponse<CreateMediaResult>
    {
        private readonly MediaRepository _mediaRepository;
        private readonly IMapper _mapper;

        public Create(MediaRepository mediaRepository, IMapper mapper)
        {
            _mediaRepository = mediaRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public override async Task<ActionResult<CreateMediaResult>> HandleAsync([FromBody] CreateMediaRequest request,
            CancellationToken cancellationToken)
        {
            var media = new Models.Media
            {
                Title = request.Title,
            };

            await _mediaRepository.Create(media);

            var result = _mapper.Map<CreateMediaResult>(media);

            return Created(new Uri($"{Request.GetAbsoluteUrl()}/{result.Id}"), result);
        }
    }
}

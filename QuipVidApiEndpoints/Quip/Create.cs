using System;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuipVid.Core.Repositories;
using QuipVidApiEndpoints.Extensions;
using Models = QuipVid.Core.Models;

namespace QuipVidApiEndpoints.Quip
{
    [Route(Routes.Quips)]
    public class Create : BaseAsyncEndpoint
        .WithRequest<CreateQuipRequest>
        .WithResponse<CreateQuipResult>
    {
        private readonly QuipRepository _quipRepository;
        private readonly IMapper _mapper;

        public Create(QuipRepository quipRepository, IMapper mapper)
        {
            _quipRepository = quipRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public override async Task<ActionResult<CreateQuipResult>> HandleAsync(CreateQuipRequest request,
            CancellationToken cancellationToken)
        {
            var quip = new Models.Quip
            {
                Title = request.Title,
                VideoUrl = request.VideoUrl,
                ThumbnailUrl = request.ThumbnailUrl,
                MediaId = request.MediaId,
                UploaderId = request.UploaderId,
            };

            await _quipRepository.Create(quip);

            quip = await _quipRepository.GetById(quip.Id);

            var result = _mapper.Map<CreateQuipResult>(quip);

            return Created(new Uri($"{Request.GetAbsoluteUrl()}/{result.Id}"), result);
        }
    }
}

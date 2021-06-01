using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuipVid.Core.Models.Dto;
using QuipVid.Core.Repositories;
using Models = QuipVid.Core.Models;

namespace QuipVidApiEndpoints.Media
{
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
        public override async Task<ActionResult<CreateMediaResult>> HandleAsync(CreateMediaRequest request,
            CancellationToken cancellationToken = default)
        {
            var media = new Models.Media
            {
                Title = request.Title,
            };

            await _mediaRepository.Create(media);

            var result = _mapper.Map<CreateMediaResult>(media);

            return CreatedAtAction(nameof(Get.HandleAsync), new { id = result.Id }, result);
        }
    }
}

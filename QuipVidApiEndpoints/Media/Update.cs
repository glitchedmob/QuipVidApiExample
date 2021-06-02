using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using QuipVid.Core.Repositories;

namespace QuipVidApiEndpoints.Media
{
    [Route(Routes.Media)]
    public class Update : BaseAsyncEndpoint
        .WithRequest<UpdateMediaRequest>
        .WithoutResponse
    {
        private readonly MediaRepository _mediaRepository;

        public Update(MediaRepository mediaRepository)
        {
            _mediaRepository = mediaRepository;
        }

        [HttpPut("{id:guid}")]
        public override async Task<ActionResult> HandleAsync(UpdateMediaRequest request,
            CancellationToken cancellationToken)
        {
            var media = await _mediaRepository.GetById(request.Id);

            if (media == null)
            {
                return NotFound();
            }

            media.Title = request.Title;

            await _mediaRepository.Update(media);

            return NoContent();
        }
    }
}

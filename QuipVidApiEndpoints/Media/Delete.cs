using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using QuipVid.Core.Repositories;

namespace QuipVidApiEndpoints.Media
{
    [Route(Routes.Media)]
    public class Delete : BaseAsyncEndpoint
        .WithRequest<DeleteMediaRequest>
        .WithoutResponse
    {
        private readonly MediaRepository _mediaRepository;

        public Delete(MediaRepository mediaRepository)
        {
            _mediaRepository = mediaRepository;
        }

        [HttpDelete("{id:guid}")]
        public override async Task<ActionResult> HandleAsync(DeleteMediaRequest request,
            CancellationToken cancellationToken)
        {
            var media = await _mediaRepository.GetById(request.Id);

            if (media == null)
            {
                return NotFound();
            }

            await _mediaRepository.Delete(media);

            return NoContent();
        }
    }
}

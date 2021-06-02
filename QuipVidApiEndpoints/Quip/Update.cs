using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using QuipVid.Core.Repositories;
using Swashbuckle.AspNetCore.Annotations;

namespace QuipVidApiEndpoints.Quip
{
    [Route(Routes.Quips)]
    public class Update : BaseAsyncEndpoint
        .WithRequest<UpdateQuipRequest>
        .WithoutResponse
    {
        private readonly QuipRepository _quipRepository;

        public Update(QuipRepository quipRepository)
        {
            _quipRepository = quipRepository;
        }

        [HttpPut("{id:guid}")]
        [SwaggerOperation(Tags = new []{ "Quip" })]
        public override async Task<ActionResult> HandleAsync(UpdateQuipRequest request,
            CancellationToken cancellationToken)
        {
            var quip = await _quipRepository.GetById(request.Id);

            if (quip == null)
            {
                return NotFound();
            }

            quip.Title = request.Title;
            quip.Views = request.Views;
            quip.VideoUrl = request.VideoUrl;
            quip.ThumbnailUrl = request.ThumbnailUrl;
            quip.MediaId = request.MediaId;
            quip.UploaderId = request.UploaderId;

            await _quipRepository.Update(quip);

            return NoContent();
        }
    }
}

using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using QuipVid.Core.Repositories;
using Swashbuckle.AspNetCore.Annotations;

namespace QuipVidApiEndpoints.Features.Quip
{
    [Route(Routes.Quips)]
    public class Delete : BaseAsyncEndpoint
        .WithRequest<DeleteQuipRequest>
        .WithoutResponse
    {
        private readonly QuipRepository _quipRepository;

        public Delete(QuipRepository quipRepository)
        {
            _quipRepository = quipRepository;
        }

        [HttpDelete("{id:guid}")]
        [SwaggerOperation(Tags = new []{ "Quip" })]
        public override async Task<ActionResult> HandleAsync(DeleteQuipRequest request,
            CancellationToken cancellationToken)
        {
            var quip = await _quipRepository.GetById(request.Id);

            if (quip == null)
            {
                return NotFound();
            }

            await _quipRepository.Delete(quip);

            return NoContent();
        }
    }
}

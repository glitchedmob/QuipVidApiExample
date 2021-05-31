using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using QuipVid.Core.Models.Dto;

namespace QuipVidApiEndpoints.Media
{
    public class Create : BaseAsyncEndpoint
        .WithRequest<CreateMediaRequest>
        .WithResponse<MediaDto>
    {
        public override Task<ActionResult<MediaDto>> HandleAsync(CreateMediaRequest request,
            CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}

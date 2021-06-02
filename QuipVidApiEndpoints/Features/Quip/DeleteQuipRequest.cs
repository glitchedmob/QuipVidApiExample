using System;
using Microsoft.AspNetCore.Mvc;

namespace QuipVidApiEndpoints.Features.Quip
{
    public class DeleteQuipRequest
    {
        [FromRoute]
        public Guid Id { get; set; }
    }
}

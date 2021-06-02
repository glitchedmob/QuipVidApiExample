using System;
using Microsoft.AspNetCore.Mvc;

namespace QuipVidApiEndpoints.Features.Quip
{
    public class GetQuipRequest
    {
        [FromRoute]
        public Guid Id { get; set; }
    }
}

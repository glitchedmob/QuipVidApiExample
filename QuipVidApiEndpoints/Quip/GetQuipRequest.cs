using System;
using Microsoft.AspNetCore.Mvc;

namespace QuipVidApiEndpoints.Quip
{
    public class GetQuipRequest
    {
        [FromRoute]
        public Guid Id { get; set; }
    }
}

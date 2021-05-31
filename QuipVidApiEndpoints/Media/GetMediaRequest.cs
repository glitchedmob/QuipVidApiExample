using System;
using Microsoft.AspNetCore.Mvc;

namespace QuipVidApiEndpoints.Media
{
    public class GetMediaRequest
    {
        [FromRoute]
        public Guid Id { get; set; }
    }
}

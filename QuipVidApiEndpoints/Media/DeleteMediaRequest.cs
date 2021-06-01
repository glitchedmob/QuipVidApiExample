using System;
using Microsoft.AspNetCore.Mvc;

namespace QuipVidApiEndpoints.Media
{
    public class DeleteMediaRequest
    {
        [FromRoute]
        public Guid Id { get; set; }
    }
}

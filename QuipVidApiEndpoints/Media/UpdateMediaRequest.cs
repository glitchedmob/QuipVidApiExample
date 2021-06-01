using System;
using Microsoft.AspNetCore.Mvc;

namespace QuipVidApiEndpoints.Media
{
    public class UpdateMediaRequest
    {
        [FromRoute]
        public Guid Id { get; set; }

        public string Title { get; set; }
    }
}

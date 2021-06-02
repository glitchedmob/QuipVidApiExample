using System;
using Microsoft.AspNetCore.Mvc;

namespace QuipVidApiEndpoints.Features.User
{
    public class GetUserRequest
    {
        [FromRoute]
        public Guid Id { get; set; }
    }
}

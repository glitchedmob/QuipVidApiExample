using System;
using Microsoft.AspNetCore.Mvc;

namespace QuipVidApiEndpoints.User
{
    public class GetUserRequest
    {
        [FromRoute]
        public Guid Id { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace QuipVidApiEndpoints.User
{
    public class GetUserResult
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public IList<UserQuipDto> Quips { get; set; } = new List<UserQuipDto>();
    }
}

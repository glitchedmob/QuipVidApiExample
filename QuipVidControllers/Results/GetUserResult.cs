using System;
using System.Collections.Generic;
using QuipVidControllers.Classes;

namespace QuipVidControllers.Results
{
    public class GetUserResult
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public IList<UserQuipDto> Quips { get; set; } = new List<UserQuipDto>();
    }
}

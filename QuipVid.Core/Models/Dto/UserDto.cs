using System;
using System.Collections.Generic;

namespace QuipVid.Core.Models.Dto
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public ICollection<UserQuipDto> Quips { get; set; }
    }
}
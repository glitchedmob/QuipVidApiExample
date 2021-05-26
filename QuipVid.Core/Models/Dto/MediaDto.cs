using System;
using System.Collections.Generic;

namespace QuipVid.Core.Models.Dto
{
    public class MediaDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public ICollection<MediaQuipDto> Quips { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace QuipVid.Core.Models.Dto
{
    public class MediaDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public IList<MediaQuipDto> Quips { get; set; } = new List<MediaQuipDto>();
    }
}

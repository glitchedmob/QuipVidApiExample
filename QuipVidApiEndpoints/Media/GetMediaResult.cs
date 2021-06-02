using System;
using System.Collections.Generic;

namespace QuipVidApiEndpoints.Media
{
    public class GetMediaResult
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public IList<MediaQuipDto> Quips { get; set; } = new List<MediaQuipDto>();
    }
}

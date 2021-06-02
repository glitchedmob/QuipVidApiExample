using AutoMapper;
using Models = QuipVid.Core.Models;

namespace QuipVidApiEndpoints.Features.Media
{
    public class MediaMappingProfile : Profile
    {
        public MediaMappingProfile()
        {
            CreateMap<Models.Media, ListMediaResult>();
            CreateMap<Models.Media, GetMediaResult>();

            CreateMap<Models.Quip, MediaQuipDto>()
                .ForMember(
                    dest => dest.UploaderUserName,
                    opt => opt.MapFrom(src => src.Uploader.UserName));


            CreateMap<Models.Media, CreateMediaResult>();
        }
    }
}

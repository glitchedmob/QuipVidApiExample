using AutoMapper;
using QuipVidApiEndpoints.Media;
using Models = QuipVid.Core.Models;

namespace QuipVidApiEndpoints.Media
{
    public class MediaMappingProfile : Profile
    {
        public MediaMappingProfile()
        {
            CreateMap<Models.Media, ListMediaResult>();
            CreateMap<Models.Quip, ListMediaResult.Quip>()
                .ForMember(
                    dest => dest.UploaderUserName,
                    opt => opt.MapFrom(src => src.Uploader.UserName));

            CreateMap<Models.Media, GetMediaResult>();
            CreateMap<Models.Quip, GetMediaResult.Quip>()
                .ForMember(
                    dest => dest.UploaderUserName,
                    opt => opt.MapFrom(src => src.Uploader.UserName));

            CreateMap<Models.Media, CreateMediaResult>();
        }
    }
}

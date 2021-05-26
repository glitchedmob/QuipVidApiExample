using AutoMapper;
using QuipVid.Core.Models;
using QuipVid.Core.Models.Dto;

namespace QuipVid.Core.Data
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<Quip, MediaQuipDto>()
                .ForMember(
                    dest => dest.UploaderUserName,
                    opt => opt.MapFrom(src => src.Uploader.UserName));
            CreateMap<Quip, UserQuipDto>()
                .ForMember(
                    dest => dest.MediaTitle,
                    opt => opt.MapFrom(src => src.Media.Title));
            CreateMap<Quip, QuipDto>()
                .ForMember(
                    dest => dest.MediaTitle,
                    opt => opt.MapFrom(src => src.Media.Title))
                .ForMember(
                    dest => dest.UploaderUserName,
                    opt => opt.MapFrom(src => src.Uploader.UserName));
            CreateMap<User, UserDto>();
            CreateMap<Media, MediaDto>();
        }
    }
}

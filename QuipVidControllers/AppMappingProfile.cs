using AutoMapper;
using QuipVid.Core.Models;
using QuipVidControllers.Classes;
using QuipVidControllers.Results;

namespace QuipVidControllers
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<Media, ListMediaResult>();
            CreateMap<Media, GetMediaResult>();
            CreateMap<Quip, MediaQuipDto>()
                .ForMember(
                    dest => dest.UploaderUserName,
                    opt => opt.MapFrom(src => src.Uploader.UserName));

            CreateMap<Media, CreateMediaResult>();

            CreateMap<Quip, GetQuipResult>()
                .ForMember(
                    dest => dest.MediaTitle,
                    opt => opt.MapFrom(src => src.Media.Title))
                .ForMember(
                    dest => dest.UploaderUserName,
                    opt => opt.MapFrom(src => src.Uploader.UserName));

            CreateMap<Quip, ListQuipResult>()
                .ForMember(
                    dest => dest.MediaTitle,
                    opt => opt.MapFrom(src => src.Media.Title))
                .ForMember(
                    dest => dest.UploaderUserName,
                    opt => opt.MapFrom(src => src.Uploader.UserName));

            CreateMap<Quip, CreateQuipResult>()
                .ForMember(
                    dest => dest.MediaTitle,
                    opt => opt.MapFrom(src => src.Media.Title))
                .ForMember(
                    dest => dest.UploaderUserName,
                    opt => opt.MapFrom(src => src.Uploader.UserName));

            CreateMap<User, ListUserResult>();
            CreateMap<User, GetUserResult>();
            CreateMap<Quip, UserQuipDto>()
                .ForMember(
                    dest => dest.MediaTitle,
                    opt => opt.MapFrom(src => src.Media.Title));
        }
    }
}

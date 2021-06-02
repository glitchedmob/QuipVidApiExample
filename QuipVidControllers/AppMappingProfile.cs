using AutoMapper;
using QuipVid.Core.Models;
using QuipVidControllers.Results;

namespace QuipVidControllers
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<Media, ListMediaResult>();
            CreateMap<Quip, ListMediaResult.Quip>()
                .ForMember(
                    dest => dest.UploaderUserName,
                    opt => opt.MapFrom(src => src.Uploader.UserName));

            CreateMap<Media, GetMediaResult>();
            CreateMap<Quip, GetMediaResult.Quip>()
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
            CreateMap<Quip, ListUserResult.Quip>()
                .ForMember(
                    dest => dest.MediaTitle,
                    opt => opt.MapFrom(src => src.Media.Title));

            CreateMap<User, GetUserResult>();
            CreateMap<Quip, GetUserResult.Quip>()
                .ForMember(
                    dest => dest.MediaTitle,
                    opt => opt.MapFrom(src => src.Media.Title));
        }
    }
}

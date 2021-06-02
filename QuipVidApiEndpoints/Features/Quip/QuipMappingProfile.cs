using AutoMapper;
using Models = QuipVid.Core.Models;

namespace QuipVidApiEndpoints.Features.Quip
{
    public class QuipMappingProfile : Profile
    {
        public QuipMappingProfile()
        {
            CreateMap<Models.Quip, GetQuipResult>()
                .ForMember(
                    dest => dest.MediaTitle,
                    opt => opt.MapFrom(src => src.Media.Title))
                .ForMember(
                    dest => dest.UploaderUserName,
                    opt => opt.MapFrom(src => src.Uploader.UserName));

            CreateMap<Models.Quip, ListQuipResult>()
                .ForMember(
                    dest => dest.MediaTitle,
                    opt => opt.MapFrom(src => src.Media.Title))
                .ForMember(
                    dest => dest.UploaderUserName,
                    opt => opt.MapFrom(src => src.Uploader.UserName));

            CreateMap<Models.Quip, CreateQuipResult>()
                .ForMember(
                    dest => dest.MediaTitle,
                    opt => opt.MapFrom(src => src.Media.Title))
                .ForMember(
                    dest => dest.UploaderUserName,
                    opt => opt.MapFrom(src => src.Uploader.UserName));
        }
    }
}

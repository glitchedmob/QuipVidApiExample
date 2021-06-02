using AutoMapper;
using Models = QuipVid.Core.Models;

namespace QuipVidApiEndpoints.User
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<Models.User, ListUserResult>();
            CreateMap<Models.Quip, ListUserResult.Quip>()
                .ForMember(
                    dest => dest.MediaTitle,
                    opt => opt.MapFrom(src => src.Media.Title));

            CreateMap<Models.User, GetUserResult>();
            CreateMap<Models.Quip, GetUserResult.Quip>()
                .ForMember(
                    dest => dest.MediaTitle,
                    opt => opt.MapFrom(src => src.Media.Title));
        }
    }
}

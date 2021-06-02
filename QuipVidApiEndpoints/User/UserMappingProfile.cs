using AutoMapper;
using Models = QuipVid.Core.Models;

namespace QuipVidApiEndpoints.User
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<Models.User, ListUserResult>();
            CreateMap<Models.User, GetUserResult>();

            CreateMap<Models.Quip, UserQuipDto>()
                .ForMember(
                    dest => dest.MediaTitle,
                    opt => opt.MapFrom(src => src.Media.Title));

        }
    }
}

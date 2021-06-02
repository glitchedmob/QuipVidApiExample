using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuipVid.Core.Repositories;

namespace QuipVidApiEndpoints.User
{
    [Route(Routes.Users)]
    public class Get : BaseAsyncEndpoint
        .WithRequest<GetUserRequest>
        .WithResponse<GetUserResult>
    {
        private readonly UserRepository _userRepository;
        private readonly IMapper _mapper;

        public Get(UserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet("{id:guid}")]
        public override async Task<ActionResult<GetUserResult>> HandleAsync(GetUserRequest request,
            CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetById(request.Id);

            if (user == null)
            {
                return NotFound();
            }

            return _mapper.Map<GetUserResult>(user);
        }
    }
}

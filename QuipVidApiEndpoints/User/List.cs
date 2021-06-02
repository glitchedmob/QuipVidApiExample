using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuipVid.Core.Repositories;
using Swashbuckle.AspNetCore.Annotations;

namespace QuipVidApiEndpoints.User
{
    [Route(Routes.Users)]
    public class List : BaseAsyncEndpoint
        .WithoutRequest
        .WithResponse<IList<ListUserResult>>
    {
        private readonly UserRepository _userRepository;
        private readonly IMapper _mapper;

        public List(UserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [SwaggerOperation(Tags = new []{ "User" })]
        public override async Task<ActionResult<IList<ListUserResult>>> HandleAsync(CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAll();

            return _mapper.Map<List<ListUserResult>>(users);
        }
    }
}

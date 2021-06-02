using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuipVid.Core.Repositories;
using QuipVidControllers.Results;

namespace QuipVidControllers.Controllers
{
    [Route("users")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly UserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(UserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IList<ListUserResult>>> List()
        {
            var users = await _userRepository.GetAll();

            return _mapper.Map<List<ListUserResult>>(users);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<GetUserResult>> Get(Guid id)
        {
            var user = await _userRepository.GetById(id);

            if (user == null)
            {
                return NotFound();
            }

            return _mapper.Map<GetUserResult>(user);
        }
    }
}

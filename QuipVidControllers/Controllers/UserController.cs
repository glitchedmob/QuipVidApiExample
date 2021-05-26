using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuipVid.Core.Data;
using QuipVid.Core.Models.Dto;
using QuipVid.Core.Repositories;

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
        public async Task<ActionResult<List<UserDto>>> Index()
        {
            var users = await _userRepository.GetAll();

            return _mapper.Map<List<UserDto>>(users);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<UserDto>> Show(Guid id)
        {
            var user = await _userRepository.GetById(id);

            if (user == null)
            {
                return NotFound();
            }

            return _mapper.Map<UserDto>(user);
        }
    }
}

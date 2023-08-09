using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using KidsBazaar.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace KidsBazaar.Controllers
{
    public class UserController : BaseController
    {
        private readonly IGenericRepository<User> userRepository;
        private readonly IMapper mapper;

        public UserController(IGenericRepository<User> userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyCollection<UserToReturnDTO>>> GetUsersAsync([FromQuery]UserSpecParams specParams)
        {
            var spec = new UserSpecification(specParams);
            var users = await userRepository.ListAsync(spec);
            var usersDTO = mapper.Map<IReadOnlyList<User>, IReadOnlyList<UserToReturnDTO>>(users);

            return Ok(usersDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserToReturnDTO>> GetUsersByIdAsync(int id)
        {
            var spec = new UserSpecification(id);
            var user = await userRepository.GetByIdAsync(spec);
            var usersDTO = mapper.Map<UserToReturnDTO>(user);

            return Ok(usersDTO);
        }
    }
}

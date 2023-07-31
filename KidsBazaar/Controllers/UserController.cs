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
        public async Task<ActionResult<IReadOnlyCollection<UserToReturnDTO>>> GetUsersAsync()
        {
            var spec = new UserWithProductsSpecification();
            var users = await userRepository.ListAllAsync(spec);
            var usersDTO = mapper.Map<IReadOnlyList<User>, IReadOnlyList<UserToReturnDTO>>(users);

            return Ok(usersDTO);
        }
    }
}

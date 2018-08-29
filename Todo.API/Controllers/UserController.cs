
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Todo.API.Data;
using Todo.API.Models;
using Todo.API.Data.Repositories;

namespace Todo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _uintOfWork;
        public UserController(IUserRepository userRepository, IUnitOfWork uintOfWork){
            _userRepository = userRepository;
            _uintOfWork = uintOfWork;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return _userRepository.GetAll().ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            return _userRepository.GetById(id);
        }

        [HttpPost]
        public void Post([FromBody]User user)
        {
            _userRepository.Add(user);
            _uintOfWork.Commit();
        }

        [HttpPut]
        public void Put([FromBody]User user)
        {
            _userRepository.Update(user);
            _uintOfWork.Commit();
        }
    }
}
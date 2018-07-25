
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
        public UserController(IUserRepository userRepository){
            _userRepository = userRepository;
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
        public ActionResult<bool> Post([FromBody]User user)
        {
            _userRepository.Add(user);

            return true;
        }

        [HttpPut]
        public ActionResult<bool> Put([FromBody]User user){

            _userRepository.Update(user);

            return true;
        }
    }
}
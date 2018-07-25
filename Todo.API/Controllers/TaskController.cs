using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Todo.API.Data.Repositories;
using Todo.API.Models;

namespace Todo.API.Controllers
{
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private ITaskRepository _taskRepository;
        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Task>> Get()
        {
            return _taskRepository.GetAll().ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Task> Get(int id){
            return _taskRepository.GetById(id);
        }

        [HttpPost]
        public void Post([FromBody]Task task){
            _taskRepository.Add(task);
        }

        [HttpPut]
        public void Put([FromBody]Task task){
            _taskRepository.Update(task);
        }

        [HttpDelete("{id}")]
        public void Delete(int id){
            _taskRepository.Delete(id);
        }
    }
}
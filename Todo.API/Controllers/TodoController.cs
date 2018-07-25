using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Todo.API.Data.Repositories;
using Todo.API.Models;

namespace Todo.API.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _todoRepository;
        public TodoController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        [HttpGet()]
        public ActionResult<IEnumerable<TodoItem>> Get()
        {
            return _todoRepository.GetAll().ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<TodoItem> Get(int id)
        {
            return _todoRepository.GetById(id);
        }

        [HttpPost]
        public void Post([FromBody]TodoItem todo)
        {
            _todoRepository.Add(todo);
        }

        public void Put([FromBody]TodoItem todo)
        {
            _todoRepository.Update(todo);
        }
        /*[HttpGet]
        public ActionResult<IEnumerable<TodoItem>> GetIncomepleteItems() 
        {
            return  _todoRepository.GetMany(t => t.IsCompleted == true, t => t.Task );
        }
        */
    }
}
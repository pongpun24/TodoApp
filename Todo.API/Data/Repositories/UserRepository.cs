using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Todo.API.Models;

namespace Todo.API.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(TodoContext context) : base(context)
        {

        }
    }
}
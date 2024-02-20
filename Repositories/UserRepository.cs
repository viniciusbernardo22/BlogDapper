using BlogDapper.Interfaces;
using BlogDapper.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace BlogDapper.Repositories
{

    public class UserRepository : IUser
    {
        private readonly SqlConnection _connection;

        public UserRepository(SqlConnection connection) => _connection = connection;

        public IEnumerable<User> Get() => _connection.GetAll<User>();

        public User GetOne(int id) => _connection.Get<User>(id);

        public long Create(User user)
        {
            user.Id = 0;
            return _connection.Insert(user);
        }

        public void Update(User user)
        {
            if(user.Id is not 0)
                _connection.Update(user);
            
        }
        
        public void Delete(User user)
        {
            if(user.Id is not 0)
                _connection.Delete(user);
        }
             
        public void Delete(int id)
        {
            if (id is not 0) return;
            
            User user = _connection.Get<User>(id);
            _connection.Delete(user);
        }
    }
}
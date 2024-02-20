using System.Data;
using System.Data.Common;
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
        
        public long Create(User user) => _connection.Insert(user);

        public void Update(User user) => _connection.Update(user);


        // public void Delete(int id) => _connection.Delete<User>(id);
    }
}
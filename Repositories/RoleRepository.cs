using BlogDapper.Interfaces;
using BlogDapper.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace BlogDapper.Repositories
{
    public class RoleRepository : IRole
    {
        private readonly SqlConnection _connection;

        public RoleRepository(SqlConnection connection) => _connection = connection;
        
        public IEnumerable<Role> Get() => _connection.GetAll<Role>();

        public Role GetOne(int id) => _connection.Get<Role>(id);
        
        public long Create(Role role) => _connection.Insert(role);

        public void Update(Role role) => _connection.Update(role);
        
    }
}
using BlogDapper.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BlogDapper.Repositories;

public class UserRepository : Repository<User>
{
    private readonly SqlConnection _connection;

    public UserRepository(SqlConnection conn) : base(conn) => _connection = conn;

    public List<User> GetWithRoles()
    {
        var query =  @"
            SELECT 
                [User].*, [Role].*
            FROM
                [User]
                LEFT JOIN [UserRole] ON [UserRole].[UserId] = [User].Id
                LEFT JOIN [Role] ON [UserRole].[RoleId] = [Role].[Id]
            ";

        List<User> users = new();

        var items = _connection.Query<User, Role, User>(query, (user, role) =>
        {
            var usr = users.FirstOrDefault(x => x.Id == user.Id);
            
            if (usr is null)
            {
                usr = user;
                
                if(role is not null)
                    usr.Roles.Add(role);
                
                users.Add(usr);
            }
            else usr.Roles.Add(role);

            return user;

        }, splitOn: "Id");
        
        return users;
    }
    


}
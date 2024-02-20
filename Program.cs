using BlogDapper.Models;
using BlogDapper.Repositories;
using Microsoft.Data.SqlClient;

namespace BlogDapper;

class Program
{
    private const string CONNECTION_STRING = "Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False;TrustServerCertificate=True;";

    static void Main(string[] args)
    {
        var connection = new SqlConnection(CONNECTION_STRING);
        connection.Open();

        ReadUsers(connection);
        
        connection.Close();
    }

    //Users
    private static void ReadUsers(SqlConnection connection)
    {
        var repo = new Repository<User>(connection);
        IEnumerable<User> users = repo.Get();

        foreach (User user in users)
            Console.WriteLine(user.Name);

    }

    public static void ReadUser(SqlConnection connection)
    {
        var repo = new Repository<User>(connection);
        var user = repo.GetOne(1);
        Console.WriteLine(user.Name);
    }


    public static void CreateUser(SqlConnection connection)
    {
        var randomUser = new User().GenerateRandomUser();
        var repo = new Repository<User>(connection);
        var id = repo.Create(randomUser);
        Console.WriteLine($"Usuário Id: ${id} - Email: ${randomUser.Email} Cadastrado com sucesso");
    }


    public static void UpdateUser(SqlConnection connection)
    {
        var user = new User().GenerateRandomUser();
        user.Id = 2;
        var repo = new Repository<User>(connection);
        repo.Update(user);

    }
    
    //Roles
    public static void ReadRoles(SqlConnection connection)
    {
        var repo = new Repository<Role>(connection);
        IEnumerable<Role> roles = repo.Get();

        foreach (var role in roles)
            Console.WriteLine(role.Name);
    }

    public static void ReadRole(SqlConnection connection)
    {
        var repo = new Repository<Role>(connection);
        var user = repo.GetOne(1);
        Console.WriteLine(user.Name);
    }


    public static void CreateRole(SqlConnection connection)
    {
        var randomRole = new Role().GenerateRandomUser();
        var repo = new Repository<Role>(connection);
        var id = repo.Create(randomRole);
        Console.WriteLine($"Role Id: ${id} - Nome: ${randomRole.Name} Cadastrada com sucesso");
    }


    public static void UpdateRole(SqlConnection connection)
    {
        var role = new Role().GenerateRandomUser();
        role.Id = 2;
        var repo = new Repository<Role>(connection);
        repo.Update(role);
    }


}
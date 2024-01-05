using System.Text;
using BlogDapper.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace BlogDapper;

class Program
{
    private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False;TrustServerCertificate=True;";
    static void Main(string[] args)
    {
      
    }

    public static void ReadUsers()
    {
        using (var connection = new SqlConnection(CONNECTION_STRING))
        {
            var users = connection.GetAll<User>();

            foreach (var user in users)
            {
                Console.WriteLine(user.Name);
            }
        }
    }


    public static void ReadUser()
    {
        using (var connection = new SqlConnection(CONNECTION_STRING))
        {
            var user = connection.Get<User>(1);

            Console.WriteLine(user.Name);

        }
    }


    public static void CreateUser()
    {
        var randomUser = new User().GenerateRandomUser();

        using (var connection = new SqlConnection(CONNECTION_STRING))
        {
            var InsertedId = connection.Insert(randomUser);

            Console.WriteLine($"Usuário Id: ${InsertedId} - Email: ${randomUser.Email} Cadastrado com sucesso");

        }
    }


    public static void UpdateUser()
    {
        var user = new User().GenerateRandomUser();
        user.Id = 2;


        using (var connection = new SqlConnection(CONNECTION_STRING))
        {

            var Modified = connection.Update(user);

            Console.WriteLine($"Usuário {user.Email} modificado com sucesso");
        }
    }

    public static void DeleteUser()
    {
        var user = new User().GenerateRandomUser();
        user.Id = 2;


        using (var connection = new SqlConnection(CONNECTION_STRING))
        {

            var Modified = connection.Delete(user);

            Console.WriteLine($"Usuário {user.Email} excluido com sucesso");
        }
    }

}
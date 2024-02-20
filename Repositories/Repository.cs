using BlogDapper.Interfaces;
using Microsoft.Data.SqlClient;
using Dapper.Contrib.Extensions;

namespace BlogDapper.Repositories;

public class Repository<TModel> : IRepository<TModel> where TModel : class
{
    private readonly SqlConnection _connection;

    public Repository(SqlConnection conn) => _connection = conn;

    public IEnumerable<TModel> Get() => _connection.GetAll<TModel>();

    public TModel GetOne(int id) => _connection.Get<TModel>(id);

    public long Create(TModel model) => _connection.Insert(model);
    
    public void Update(TModel model) => _connection.Update(model);
    
    public void Delete(TModel model) => _connection.Delete(model);
    
    public void Delete(int id)
    {
        if (id is not 0) return;
        TModel user = _connection.Get<TModel>(id);
        _connection.Delete(user);
    }
    
}
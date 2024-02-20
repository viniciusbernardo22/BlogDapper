using BlogDapper.Models;

namespace BlogDapper.Interfaces;

public interface IRepository<T> where T : class
{
    public IEnumerable<T> Get();

    public T GetOne(int id);

    public long Create(T role);

    public void Update(T role);
    
    public void Delete(T user);
    
    public void Delete(int id);
}
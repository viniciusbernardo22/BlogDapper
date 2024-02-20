using BlogDapper.Models;

namespace BlogDapper.Interfaces;

public interface IRole
{
    public IEnumerable<Role> Get();

    public Role GetOne(int id);

    public long Create(Role role);

    public void Update(Role role);
    
    public void Delete(Role user);
    
    public void Delete(int id);
}
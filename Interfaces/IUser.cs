using BlogDapper.Models;

namespace BlogDapper.Interfaces;

public interface IUser
{

    public IEnumerable<User> Get();

    public User GetOne(int id);
    
    public long Create(User user);

    public void Update(User user);
}
using HW12.Entity;
using HW12.Interface;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HW12.Repository;

public class UserRepository : IUserRepository
{
    private readonly AppDBContext _appContext;
    public UserRepository()
    {
        _appContext = new AppDBContext();
    }
    public void Add(User user)
    {
        _appContext.users.Add(user);
        _appContext.SaveChanges();
    }

    public void Delete(int id)
    {
        var users = Get(id);
        _appContext.users.Remove(users);
        _appContext.SaveChanges();
    }

    public User Get(int id)
    {
        var users = _appContext.users.Where(t => t.Id == id).FirstOrDefault();
        return users;
    }



    public List<User> GetAll()
    {
        var users = _appContext.users.ToList();
        return users;
    }

    public void Update(User user)
    {
        var updateUser = Get(user.Id);
        if (updateUser != null)
        {
            updateUser.FullName = user.FullName;
            updateUser.UserName = user.UserName;
            updateUser.Password = user.Password;
            updateUser.Tassks = user.Tassks;
            _appContext.SaveChanges();
        }
    }
}

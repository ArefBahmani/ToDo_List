using HW12.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW12.Interface;

public interface IUserRepository
{
    public void Add(User user);
    public List<User> GetAll();
    public User Get(int id);
    public void Update(User user);
    public void Delete(int id);
}

using HW12.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW12.Interface;

public interface ITaskRepository
{
    public void Add(Tassk task);
    public List<Tassk> GetAll();
    public Tassk Get(int id);
    public void Delete(int id);
    public void Update(int id, Tassk task);
}

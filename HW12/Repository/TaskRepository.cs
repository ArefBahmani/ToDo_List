using HW12.Entity;
using HW12.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW12.Repository;

public class TaskRepository : ITaskRepository
{
    private readonly AppDBContext _appContext;
    public TaskRepository()
    {
        _appContext = new AppDBContext();
    }


    public void Add(Tassk tassk)
    {
        _appContext.tassks.Add(tassk);
        _appContext.SaveChanges();
    }

    public void Delete(int id)
    {
        var task = Get(id);
        _appContext.tassks.Remove(task);
        _appContext.SaveChanges();
    }

    public Tassk Get(int id)
    {
        var tasks = _appContext.tassks.Where(t => t.Id == id).FirstOrDefault();
        return tasks;
    }

    public List<Tassk> GetAll()
    {
        var tasks = _appContext.tassks.ToList();
        return tasks;


    }

    public void Update(int id, Tassk task)
    {
        var tassk = _appContext.tassks.FirstOrDefault(t => t.Id == id);
        tassk.Titel = task.Titel;
        tassk.TimeToDone = task.TimeToDone;
        tassk.State = task.State;
        tassk.Priority = task.Priority;
        tassk.UserID = task.UserID;
        _appContext.SaveChanges();

    }


}

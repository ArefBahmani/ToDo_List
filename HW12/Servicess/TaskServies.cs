using Colors.Net;
using Colors.Net.StringColorExtensions;
using HW12.Entity;
using HW12.Enum;
using HW12.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW12.Servicess;

public class TaskServies : TaskRepository
{
    public void Creat(string title, DateTime dateTime, PriorityEnum priority, int userid)
    {
        try
        {
            var tasks = GetAll();
            bool isExistance = tasks.Any(t => t.Titel == title);
            if (isExistance)
            {
                Console.WriteLine("The title entered is a duplicate.");
                return;
            }

            var newTassk = new Tassk()
            {
                Titel = title,
                TimeToDone = dateTime,
                Priority = priority,
                UserID = userid,

            };
            Add(newTassk);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");

        }

    }

    public void TaskList(int userId)
    {
        var tasks = GetAll().Where(t => t.UserID == userId);
        
        foreach (var item in tasks)
        {


            ColoredConsole.WriteLine($"Id = {item.Id} - Titel = {item.Titel} - DataTime = {item.TimeToDone} - State = {item.State} - Priority = {item.Priority}".DarkGreen());
            ColoredConsole.WriteLine("------------------------------------------------------------------------------------------------------------".DarkMagenta());

        }
    }

    public void Edit(int id, Tassk tsk)
    {
        Update(id, tsk);

    }

    public void Remove(int id, int userId)
    {
        var task = Get(id);
        if (task.UserID != userId)
        {
            throw new Exception("You CanNot Delete TaskID");
        }
        else if (task != null)
        {
            Delete(id);
        }
        else
        {
            Console.WriteLine("Id Not Found!");
        }

    }


    public void ChangState(int id, int State)
    {
        try
        {
            var task = Get(id);
            if (task == null)
            {
                Console.WriteLine("Task Not Found");
                return;
            }
            if (State == 1)
            {
                task.State = StateEnum.done;
                Update(id, task);
            }
            else if (State == 2)
            {
                task.State = StateEnum.inPending;
                Update(id, task);
            }
            else if (State == 3)
            {
                task.State = StateEnum.cancelled;
                Update(id, task);
            }
            else
            {
                Console.WriteLine("The state entered is a duplicate.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");

        }


    }

    public void Search(string title)
    {
        var tasks = GetAll().Where(t => t.Titel.Contains(title)).ToList();
        if (tasks.Count == 0)
        {
            ColoredConsole.WriteLine("Not Task Found".Red());
        }
        else
        {
            foreach (var item in tasks)
            {
                ColoredConsole.WriteLine($"ID = {item.Id} - Titel = {item.Titel} - DataTime = {item.TimeToDone} - State = {item.State} - Priority = {item.Priority}".Yellow());
            }
        }
    }
}


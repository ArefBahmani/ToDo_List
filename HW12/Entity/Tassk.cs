using HW12.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW12.Entity;

public class Tassk
{
    public int Id { get; set; }

    public string Titel { get; set; }

    public DateTime TimeToDone { get; set; }

    public PriorityEnum Priority { get; set; }

    public StateEnum State { get; set; } = StateEnum.inPending;
    public User User { get; set; }
    public int UserID { get; set; }

}

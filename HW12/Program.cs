using Colors.Net;
using Colors.Net.StringColorExtensions;
using HW12.Entity;
using HW12.Enum;
using HW12.Repository;
using HW12.Servicess;
TaskServies _taskServisces = new TaskServies();
UserService _userService = new UserService();
bool isExist = false;
while (true)
{
    Console.Clear();
    ColoredConsole.WriteLine("                                   *********   Welcome ToDo List  *********".DarkYellow());
    Console.WriteLine("");
    Console.WriteLine("");
    Console.WriteLine("");
    ColoredConsole.WriteLine("1.Register".Green());
    Console.WriteLine("");
    ColoredConsole.WriteLine("2.Login".Green());
    Console.WriteLine("");
    ColoredConsole.WriteLine("3.Exit".Red());
    ColoredConsole.WriteLine("--------------------------------------------------------".Green());



    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            ColoredConsole.Write("Enter FullName : ".Gray());
            string fullName = Console.ReadLine();
            ColoredConsole.Write("Enter Username : ".Gray());
            string userName = Console.ReadLine();
            ColoredConsole.Write("Enter Password : ".Gray());
            string password = Console.ReadLine();

            try
            {
                _userService.Register(fullName, userName, password);
                ColoredConsole.WriteLine("Successful".DarkGreen());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.ReadKey();
            break;

        case "2":
            ColoredConsole.Write("Enter Username : ".Gray());
            string username = Console.ReadLine();
            ColoredConsole.Write("Enter Password : ".Gray());
            string pass = Console.ReadLine();

            try
            {
                _userService.Login(username, pass);
                var currentUser = _userService.GetCurrentUser();
                if (currentUser == null)
                {
                    ColoredConsole.WriteLine("User Not Logged".Red());
                    Console.ReadKey();
                    break;
                }
                isExist = true;
                ColoredConsole.WriteLine("Login Successful".Green());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.ReadKey();
            break;

        case "3":
            return;
        default:
            ColoredConsole.WriteLine("Invalid".DarkRed());
            Console.ReadKey();
            break;
    }

    if (isExist)
    {
        bool inMenu = true;
        while (inMenu)

        {
            try
            {
                Console.Clear();
                var currentUser = _userService.GetCurrentUser();


                Console.WriteLine("Please select the desired option");
                ColoredConsole.WriteLine("1. Add New Task".Blue());
                ColoredConsole.WriteLine("2. Show All Task".Blue());
                ColoredConsole.WriteLine("3. Edit Task".Blue());
                ColoredConsole.WriteLine("4. Remove Task".Blue());
                ColoredConsole.WriteLine("5. Change Status".Blue());
                ColoredConsole.WriteLine("6. Search".Blue());
                ColoredConsole.WriteLine("7. LogOut".DarkRed());
                ColoredConsole.WriteLine("--------------------------------------------------------".DarkRed());

                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {

                    case 1:

                        ColoredConsole.WriteLine("Pls Enter The Title".DarkBlue());
                        string title = Console.ReadLine();
                        Console.WriteLine("Pls Enter Time To Done");
                        DateTime timeDon = DateTime.Parse(Console.ReadLine());
                        ColoredConsole.WriteLine("Pls Chose Priority (1.low 2.medium 3.high )".DarkBlue());
                        int prio = Convert.ToInt32(Console.ReadLine());
                        PriorityEnum priority = PriorityEnum.medium;
                        if (prio == 1)
                        {
                            priority = PriorityEnum.low;
                            _taskServisces.Creat(title, timeDon, priority, currentUser.Id);
                            ColoredConsole.WriteLine("Done".DarkGreen());
                            Console.ReadKey();
                        }
                        else if (prio == 2)
                        {
                            priority = PriorityEnum.medium;
                            _taskServisces.Creat(title, timeDon, priority, currentUser.Id);
                            ColoredConsole.WriteLine("Done".DarkGreen());
                            Console.ReadKey();
                        }
                        else if (prio == 3)
                        {
                            priority = PriorityEnum.high;
                            _taskServisces.Creat(title, timeDon, priority, currentUser.Id);
                            ColoredConsole.WriteLine("Done".DarkGreen());
                            Console.ReadKey();
                        }
                        else
                        {
                            ColoredConsole.WriteLine("There is no selected priority".Red());
                        }

                        break;
                    case 2:
                        _taskServisces.TaskList(currentUser.Id);
                        Console.ReadKey();
                        break;
                    case 3:
                        _taskServisces.TaskList(currentUser.Id);
                        ColoredConsole.WriteLine("Pls Enter The Task ID".DarkGray());
                        int idd = Convert.ToInt32(Console.ReadLine());
                        var curTask = _taskServisces.Get(idd);
                        ColoredConsole.WriteLine("Pls Enter New Tilte OR enter <N>".DarkGray());
                        string nTitle = Console.ReadLine();
                        if (nTitle == "N")
                        {
                            nTitle = curTask.Titel;
                        }
                        ColoredConsole.WriteLine("Pls Enter New Time OR enter <N>".DarkGray());
                        string nTimedon = Console.ReadLine();
                        DateTime nt = curTask.TimeToDone;
                        if (nTimedon != "N")
                        {
                            nt = DateTime.Parse(nTimedon);
                        }
                        ColoredConsole.WriteLine("Pls Chose New Priority (1.low 2.medium 3.high ) OR <N>".DarkGray());
                        string nPriority = Console.ReadLine();
                        PriorityEnum priorityEnum = curTask.Priority;
                        if (nPriority == "1")
                        {
                            priorityEnum = PriorityEnum.low;
                        }
                        else if (nPriority == "2")
                        {
                            priorityEnum = PriorityEnum.medium;
                        }
                        else if (nPriority == "3")
                        {
                            priorityEnum = PriorityEnum.high;
                        }

                        ColoredConsole.WriteLine("Pls Chose New State (1.done 2.inPending 3.cancelled ) OR <N>".DarkGray());
                        string nState = Console.ReadLine();
                        StateEnum stateEnum = curTask.State;
                        if (nState == "1")
                        {
                            stateEnum = StateEnum.done;
                        }
                        else if (nState == "2")
                        {
                            stateEnum = StateEnum.inPending;
                        }
                        else if (nState == "3")
                        {
                            stateEnum = StateEnum.cancelled;
                        }
                        Tassk nnTask = new Tassk()
                        {
                            Titel = nTitle,
                            TimeToDone = nt,
                            State = stateEnum,
                            Priority = priorityEnum,
                            UserID = currentUser.Id,
                        };
                        _taskServisces.Edit(idd, nnTask);
                        ColoredConsole.WriteLine("Done".DarkGreen());
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.WriteLine("Pls Enter The Task ID");
                        int rID = Convert.ToInt32(Console.ReadLine());
                        _taskServisces.Remove(rID, currentUser.Id);
                        ColoredConsole.WriteLine("Done".DarkGreen());
                        Console.ReadKey();

                        break;
                    case 5:
                        Console.Clear();
                        _taskServisces.TaskList(currentUser.Id);
                        Console.WriteLine("Pls Enter The Task ID");
                        int cID = Convert.ToInt32(Console.ReadLine());
                        ColoredConsole.WriteLine("Pls Chose New State (1.done 2.inPending 3.cancelled )".DarkGray());
                        int cState = Convert.ToInt32(Console.ReadLine());
                        _taskServisces.ChangState(cID, cState);
                        ColoredConsole.WriteLine("Done".DarkGreen());
                        Console.ReadKey();

                        break;
                    case 6:
                        Console.WriteLine("Pls Enter The title");
                        string input = Console.ReadLine();
                        _taskServisces.Search(input);
                        Console.ReadKey();

                        break;
                    case 7:
                        currentUser = null;
                        inMenu = false;
                        isExist = false;


                        break;
                    default:

                        break;



                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error: {ex.Message}");
                Console.ReadKey();
            }




        }
    }
}
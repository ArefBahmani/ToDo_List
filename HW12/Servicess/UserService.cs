using HW12.Entity;
using HW12.Repository;

namespace HW12.Servicess;

public class UserService
{
    private readonly UserRepository _userRepository;
    public UserService()
    {
        _userRepository = new UserRepository();
    }
    private User _currentUser;

    public void Register(string fullName, string userName, string password)
    {
        try
        {
            bool isSpecial = password.Any(s => (s >= 33 && s <= 47) || s == 64);

            if (password.Length < 5 || password.Length > 10 || !isSpecial)
            {
                throw new Exception("Password > 4  Char And One Special Character");
            }

          
            var user = new User
            {
                FullName = fullName,
                UserName = userName,
                Password = password,
                Tassks = new List<Tassk>()
            };

            _userRepository.Add(user);
        }

        catch (Exception ex)
        {
            throw new Exception($"Error : {ex.Message}", ex);
        }
    }

    public void Login(string username, string password)
    {
        try
        {
            var user = _userRepository.GetAll().FirstOrDefault(u => u.UserName == username && u.Password == password);

            if (user == null)
            {
                throw new Exception("Invalid username or password.");
            }

            _currentUser = user;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error : {ex.Message}", ex);

        }
    }

    public bool Logout()
    {
        _currentUser = null;
        return true;
    }

    public User GetCurrentUser()
    {
        return _currentUser;
    }
}


using test.api.Models;

public interface IUserRepository
{
    Task<User> GetUserByUsernameAndPassword(string username, string password);
    Task AddUser(User user);
}
using DatasetAPI;
using RecipeBook;

namespace Services
{
    public class UserLoginService
    {
        private readonly AppDbContext _dbContext;

        public UserLoginService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<UserLogin> GetAllUserLogins()
        {
            return _dbContext.UserLogins.ToList();
        }

        public UserLogin GetUserLoginById(int id)
        {
            return _dbContext.UserLogins.Find(id);
        }

        public void AddUserLogin(UserLogin userLogin)
        {
            _dbContext.UserLogins.Add(userLogin);
            _dbContext.SaveChanges();
        }

        public string UpdateUserLogin(int id, UserLogin userLogin)
        {
            var existingUserLogin = _dbContext.UserLogins.Find(id);
            if (existingUserLogin == null)
            {
                return "User login not found";
            }

            try
            {
                existingUserLogin.Username = userLogin.Username;
                existingUserLogin.Password = userLogin.Password;

                _dbContext.SaveChanges();
                return "User login updated successfully"; 
            }
            catch (Exception)
            {
                return "An error occurred while updating the user login"; 
            }
        }

        public string DeleteUserLogin(int id)
        {
            var userLogin = _dbContext.UserLogins.Find(id);
            if (userLogin != null)
            {
                _dbContext.UserLogins.Remove(userLogin);
                _dbContext.SaveChanges();
                return "User login deleted successfully";
            }
            else
            {
                return "User login not found";
            }
        }
    }
}
